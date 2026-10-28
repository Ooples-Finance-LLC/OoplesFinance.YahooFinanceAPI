const MARKER = '<!-- yahoo-daily-triage -->';
const STATE = /<!-- triage-alerts:([^\n]+) -->/;
const DAY = 86400000;
const maintainers = new Set(['OWNER', 'MEMBER', 'COLLABORATOR']);
const isMaintainer = x => maintainers.has(x.author_association);
const time = x => new Date(x).getTime();
const safe = x => String(x).replace(/@/g, '@\u200b').replace(/[\r\n]/g, ' ').replace(/[\[\]<>]/g, '').slice(0, 180);

function selectAlerts({ issues, pulls, runs, now = Date.now() }) {
  const alerts = [];
  for (const issue of issues) {
    if (issue.pull_request || issue.state !== 'open' || isMaintainer(issue)) continue;
    const comments = issue.commentsData || [];
    const acknowledged = comments.some(isMaintainer);
    if (!acknowledged && now - time(issue.created_at) >= 3 * DAY)
      alerts.push({ key: `issue:${issue.number}`, text: `Issue #${issue.number}: ${safe(issue.title)} — no maintainer response for at least 3 days`, url: issue.html_url });
  }
  for (const pr of pulls) {
    if (pr.draft || pr.state !== 'open') continue;
    const review = (pr.reviewsData || []).filter(r => isMaintainer(r) && ['APPROVED', 'CHANGES_REQUESTED'].includes(r.state))
      .sort((a, b) => time(b.submitted_at) - time(a.submitted_at))[0];
    if (review?.commit_id && review.commit_id === pr.head?.sha) continue;
    const waitingSince = review ? pr.lastCommitAt : pr.created_at;
    if (now - time(waitingSince) >= 7 * DAY)
      alerts.push({ key: `pr:${pr.number}`, text: `PR #${pr.number}: ${safe(pr.title)} — awaiting review for at least 7 days`, url: pr.html_url });
  }
  const latest = new Map();
  for (const run of runs) {
    if (run.status !== 'completed') continue;
    if (!latest.has(run.workflow_id) || time(run.created_at) > time(latest.get(run.workflow_id).created_at)) latest.set(run.workflow_id, run);
  }
  for (const run of latest.values()) {
    if (['failure', 'timed_out', 'action_required', 'startup_failure'].includes(run.conclusion))
      alerts.push({ key: `ci:${run.workflow_id}`, text: `${safe(run.name)}: ${run.conclusion} on the default branch`, url: run.html_url });
  }
  return alerts.sort((a, b) => a.key.localeCompare(b.key));
}

async function run({ github, context, core, now = Date.now() }) {
  const repo = context.repo;
  const { data: metadata } = await github.rest.repos.get(repo);
  const allIssues = await github.paginate(github.rest.issues.listForRepo, { ...repo, state: 'all', per_page: 100 });
  const dashboard = allIssues.find(i => !i.pull_request && i.user?.login === 'github-actions[bot]' && i.body?.startsWith(MARKER));
  const issues = allIssues.filter(i => !i.pull_request && i.state === 'open' && i.number !== dashboard?.number);
  for (const issue of issues) issue.commentsData = await github.paginate(github.rest.issues.listComments, { ...repo, issue_number: issue.number, per_page: 100 });
  const pulls = await github.paginate(github.rest.pulls.list, { ...repo, state: 'open', per_page: 100 });
  for (const pr of pulls) {
    pr.reviewsData = await github.paginate(github.rest.pulls.listReviews, { ...repo, pull_number: pr.number, per_page: 100 });
    const commits = await github.paginate(github.rest.pulls.listCommits, { ...repo, pull_number: pr.number, per_page: 100 });
    pr.lastCommitAt = commits.at(-1)?.commit?.committer?.date || pr.created_at;
  }
  const runs = await github.paginate(github.rest.actions.listWorkflowRunsForRepo, { ...repo, branch: metadata.default_branch, per_page: 100, exclude_pull_requests: true, created: '>=' + new Date(now - 30 * DAY).toISOString() });
  const alerts = selectAlerts({ issues, pulls, runs, now });
  let previous = [];
  try { previous = JSON.parse(dashboard?.body?.match(STATE)?.[1] || '[]'); } catch { core.warning('Could not parse previous triage state; treating findings as new.'); }
  const fresh = alerts.filter(a => !previous.includes(a.key));
  const body = `${MARKER}\n# Maintainer backlog\n\nUpdated ${new Date(now).toISOString()}. Daily triage never closes issues or merges PRs.\n\n` +
    (alerts.length ? alerts.map(a => `- [${a.text}](${a.url})`).join('\n') : 'No items currently exceed the response/review thresholds; no latest default-branch workflow failures found in the last 30 days.') +
    `\n\nOpen issues: ${issues.length}. Open PRs: ${pulls.length}.\n\n<!-- triage-alerts:${JSON.stringify(alerts.map(a => a.key))} -->`;
  let number = dashboard?.number;
  if (!number) number = (await github.rest.issues.create({ ...repo, title: 'Maintainer triage backlog', body: `${MARKER}\nInitializing triage; findings will appear after notification succeeds.` })).data.number;
  if (fresh.length) await github.rest.issues.createComment({ ...repo, issue_number: number,
    body: '@ooples — new items need attention:\n\n' + fresh.map(a => `- [${a.text}](${a.url})`).join('\n') });
  // Persist notified keys only after the notification succeeds, so a transient API error cannot suppress an alert forever.
  await github.rest.issues.update({ ...repo, issue_number: number, state: 'open', body });
  core.info(`Updated #${number}: ${alerts.length} actionable items, ${fresh.length} new alerts.`);
}
module.exports = { run, selectAlerts };
