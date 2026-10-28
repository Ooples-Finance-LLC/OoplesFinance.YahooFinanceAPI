const { test } = require('node:test');
const assert = require('node:assert/strict');
const { selectAlerts, run } = require('./daily-triage.cjs');
const now = Date.parse('2026-10-28T13:30:00Z');
const old = '2026-10-01T00:00:00Z';
const recent = '2026-10-27T00:00:00Z';
const issue = { number: 157, title: 'ETF data', state: 'open', created_at: old, author_association: 'NONE', html_url: 'https://example.test/157' };
const pr = { number: 167, head: { sha: 'reviewed-head' }, title: 'Fix data', state: 'open', created_at: old, lastCommitAt: old, html_url: 'https://example.test/167' };
const ci = { workflow_id: 10, name: 'CI', status: 'completed', conclusion: 'failure', created_at: old, html_url: 'https://example.test/run' };
const select = overrides => selectAlerts({ issues: [], pulls: [], runs: [], now, ...overrides }).map(a => a.key);
test('thresholds and maintainer responses distinguish actionable issues', () => {
  assert.deepEqual(select({ issues: [issue] }), ['issue:157']);
  assert.deepEqual(select({ issues: [{ ...issue, body: '<!-- yahoo-daily-triage -->' }] }), ['issue:157']);
  for (const change of [{ created_at: recent }, { state: 'closed' }, { author_association: 'OWNER' }, { commentsData: [{ author_association: 'MEMBER' }] }])
    assert.deepEqual(select({ issues: [{ ...issue, ...change }] }), []);
});
test('PR reviews cover only the reviewed commits and drafts are excluded', () => {
  assert.deepEqual(select({ pulls: [pr] }), ['pr:167']);
  assert.deepEqual(select({ pulls: [{ ...pr, draft: true }] }), []);
  const review = { commit_id: 'reviewed-head', author_association: 'MEMBER', state: 'APPROVED', submitted_at: '2026-10-02T00:00:00Z' };
  assert.deepEqual(select({ pulls: [{ ...pr, reviewsData: [review] }] }), []);
  assert.deepEqual(select({ pulls: [{ ...pr, head: { sha: 'new-head' }, lastCommitAt: '2026-10-03T00:00:00Z', reviewsData: [review] }] }), ['pr:167']);
  // A backdated commit must not make an old approval cover a different head.
  assert.deepEqual(select({ pulls: [{ ...pr, head: { sha: 'backdated-head' }, reviewsData: [review] }] }), ['pr:167']);
});
test('CI recovery clears an alert; an in-progress rerun does not hide the failed completed run', () => {
  assert.deepEqual(select({ runs: [ci, { ...ci, created_at: recent, status: 'in_progress', conclusion: null }] }), ['ci:10']);
  assert.deepEqual(select({ runs: [ci, { ...ci, created_at: recent, conclusion: 'success' }] }), []);
});
test('daily dashboard updates notify once; notification failures do not commit deduplication state', async () => {
  let dashboard; let comments = 0; let failComment = true;
  const rest = { repos: { get: async () => ({ data: { default_branch: 'master' } }) },
    issues: { listForRepo: 'issues', listComments: 'comments',
      create: async ({ body }) => { dashboard = { number: 200, body, user: { login: 'github-actions[bot]' } }; return { data: dashboard }; },
      update: async ({ body }) => { dashboard.body = body; },
      createComment: async () => { if (failComment) throw new Error('transient'); comments++; } },
    pulls: { list: 'pulls' }, actions: { listWorkflowRunsForRepo: 'runs' } };
  const github = { rest, paginate: async endpoint => endpoint === 'issues' ? [issue, ...(dashboard ? [dashboard] : [])] : [] };
  const args = { github, context: { repo: { owner: 'owner', repo: 'repo' } }, core: { info() {}, warning() {} }, now };
  await assert.rejects(run(args), /transient/);
  assert.ok(!dashboard.body.includes('issue:157'));
  failComment = false;
  await run(args); await run(args);
  assert.equal(comments, 1);
  assert.ok(dashboard.body.includes('issue:157'));
});
