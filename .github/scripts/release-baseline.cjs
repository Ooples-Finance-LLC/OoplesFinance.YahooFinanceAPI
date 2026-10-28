function assertBaseline(version, tag) {
  const parse = value => {
    const match = /^v?(\d+)\.(\d+)\.(\d+)$/.exec(value);
    if (!match) throw new Error(`Expected a stable semantic version, received ${value}`);
    return match.slice(1).map(BigInt);
  };
  const baseline = parse(version); const published = parse(tag);
  for (let i = 0; i < 3; i++) {
    if (baseline[i] > published[i]) return; // A newly merged release PR carries the next version.
    if (baseline[i] < published[i]) throw new Error('Release manifest is behind the latest published release. Synchronize version.txt and .release-please-manifest.json before proceeding.');
  }
}
module.exports = { assertBaseline };
