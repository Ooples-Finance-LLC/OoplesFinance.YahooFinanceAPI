# Maintainer triage

Daily triage runs at 13:30 UTC and can also be started manually from Actions. It keeps one `Maintainer triage backlog` issue, linking unanswered external issues after 3 days, non-draft PRs awaiting maintainer review after 7 days, and the latest completed failing default-branch workflows from the past 30 days. A new item triggers one @ooples notification; unchanged findings do not trigger daily reminders. Successful CI recovery clears its alert. Check the backlog for unresolved items even after the first notification.

The workflow uses the repository GITHUB_TOKEN with issues write and repository/PR/Actions read access. It never closes user issues, merges pull requests, or publishes releases. The old stale workflow is removed. Watch this repository's Issues/PRs and Actions notifications in GitHub; the scheduled triage run itself can fail if GitHub is unavailable or permissions change, so it complements rather than replaces those notifications. Scheduled workflows require this change on the default branch and GitHub can disable schedules after prolonged repository inactivity.

Dependabot groups all NuGet version updates across the repository into one PR and groups security updates separately. A group does not bypass CI or approval. The config takes effect after merge; existing individual PRs are not automatically combined by this code change.
