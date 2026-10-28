const fs = require('node:fs');

async function checkToken(token, request = fetch) {
  if (!token || !token.trim()) return false;
  let response;
  try {
    response = await request('https://sonarcloud.io/api/authentication/validate', {
      headers: { Authorization: `Basic ${Buffer.from(token + ':').toString('base64')}` },
      signal: AbortSignal.timeout(30000)
    });
  } catch {
    throw new Error('SonarCloud authentication check could not reach the server. Retry the job; analysis was not skipped.');
  }
  if (!response.ok) throw new Error(`SonarCloud authentication check returned HTTP ${response.status}. Check service availability and SONAR_TOKEN.`);
  let payload;
  try { payload = await response.json(); }
  catch { throw new Error('SonarCloud returned an invalid authentication response. Analysis was not skipped.'); }
  if (payload.valid !== true) throw new Error('SONAR_TOKEN is invalid or expired. Replace the repository secret with a valid SonarCloud token.');
  return true;
}

module.exports = { checkToken };
if (require.main === module) {
  checkToken(process.env.SONAR_TOKEN).then(valid => {
    fs.appendFileSync(process.env.GITHUB_OUTPUT, `valid=${valid}\n`);
    if (!valid) console.log('::warning::SONAR_TOKEN is unavailable (for example, on fork or Dependabot PRs); SonarCloud analysis is skipped. Build and tests still run.');
  }).catch(error => { console.error(`::error::${error.message}`); process.exitCode = 1; });
}
