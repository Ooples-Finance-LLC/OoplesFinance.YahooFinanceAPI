const { test } = require('node:test');
const assert = require('node:assert/strict');
const { checkToken } = require('./check-sonar-token.cjs');
test('absent secrets skip without calling the server', async () => {
  for (const token of [undefined, '', '   ']) assert.equal(await checkToken(token, () => { throw new Error('unexpected request'); }), false);
});
test('valid credentials enable analysis', async () => {
  assert.equal(await checkToken('test-token', async (url, options) => {
    assert.equal(url, 'https://sonarcloud.io/api/authentication/validate');
    assert.equal(options.headers.Authorization, 'Basic ' + Buffer.from('test-token:').toString('base64'));
    return { ok: true, json: async () => ({ valid: true }) };
  }), true);
});
test('invalid token, service errors and malformed responses fail instead of hiding analysis failures', async () => {
  for (const response of [
    { ok: true, json: async () => ({ valid: false }) },
    { ok: false, status: 503 },
    { ok: true, json: async () => { throw new Error('bad JSON'); } }
  ]) await assert.rejects(checkToken('test-token', async () => response));
  await assert.rejects(checkToken('test-token', async () => { throw new Error('network'); }), /not skipped/);
});
