const { test } = require('node:test');
const assert = require('node:assert/strict');
const { assertBaseline } = require('./release-baseline.cjs');
test('ordinary pushes and newly merged release PRs pass', () => {
  for (const [version, tag] of [['1.7.2', 'v1.7.2'], ['1.7.3', 'v1.7.2'], ['1.8.0', 'v1.7.2'], ['2.0.0', 'v1.9.9']]) assert.doesNotThrow(() => assertBaseline(version, tag));
});
test('an intervening release cannot reuse or roll back a published version', () => {
  for (const [version, tag] of [['1.7.1', 'v1.7.2'], ['1.9.9', 'v1.10.0'], ['1.99.0', 'v2.0.0']]) assert.throws(() => assertBaseline(version, tag), /behind/);
  assert.throws(() => assertBaseline('invalid', 'v1.7.2'), /semantic/);
});
