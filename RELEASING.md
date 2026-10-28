# Releases

Release Please maintains one rolling release PR on `master`. Manual dispatch also requires the `master` ref; other refs are skipped. Use conventional PR titles (`fix:`, `feat:`, `build(deps):`) so squash merges appear in the changelog. Merging ordinary changes does not publish a package. Review and merge the release PR to create its version tag and GitHub release; only then are all declared frameworks tested, packed, verified, and published to NuGet.

`version.txt` and `.release-please-manifest.json` start at the last published release, 1.7.2. The project reads `version.txt`; Release Please updates it and the changelog. The old per-push release workflow is removed so two publishers cannot race.

## Repository setup

- Configure `AUTOFIX_PAT` (or grant this repository access to the organization secret of that name). It needs contents, pull requests, and issues write access. Use a dedicated automation identity. This token is required so release PRs trigger ordinary CI; the workflow does not silently fall back to `GITHUB_TOKEN`.
- Retain a valid `NUGET_API_KEY` authorized for this package. Only the publish job receives it.
- Keep `SONAR_TOKEN` valid for authenticated SonarCloud analysis.

Normal PR CI must pass before merging the release PR. Release builds check out the exact generated tag, run all target-framework tests, and verify every declared DLL plus the NuGet version. No release or publish is triggered while this setup PR is unmerged. If packaging or publishing fails after a release is created, rerun the failed jobs from that release's workflow run; do not create another version just to retry.
