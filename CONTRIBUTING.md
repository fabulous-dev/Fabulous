# Contributing to Fabulous

Fabulous is primarily maintained through agentic development under human guidance. Maintainers
review and discuss proposed work, then direct coding agents to make the complete, repository-wide
change, including implementation, tests, documentation, samples, and other affected files.

## Repo Assist

[Repo Assist] is an automated AI assistant that runs regularly in this repository. It may triage or
respond to issues, investigate bugs, suggest improvements, and attempt implementations as draft pull
requests. Its comments and pull requests identify it as automated, and its work remains subject to
human review. Repo Assist does not merge pull requests or make final maintenance decisions.

Maintainers can also invoke Repo Assist with `/repo-assist <instructions>` to perform a specific
agentic task, such as investigating an issue, preparing a fix, adding tests, or updating
documentation. These directed tasks follow the same review process as its scheduled work.

## Start With an Issue

We generally prefer contributions as [GitHub issues] rather than pull requests. An issue is the best
place to report a bug, request a feature, suggest a documentation improvement, or propose another
change.

Before opening an issue, search for an existing report. If there is one, add any useful context there
instead of creating a duplicate.

A useful issue explains:

- the problem or desired outcome;
- why the change would be valuable;
- steps to reproduce a bug, including relevant platform and version details;
- examples, screenshots, logs, API sketches, or other supporting material when applicable.

You are welcome to include a proposed implementation, a patch, or a link to a fork or branch. This
material can help the discussion, but it does not need to be a complete contribution. Maintainers may
refine the scope with you and then assign the issue to an agent to implement and validate the full
change.

## Pull Requests

Pull requests are still welcome, but every pull request must have a matching issue that has been
discussed with the maintainers. Open the issue before investing substantial effort, especially for
new features, public API changes, or broad refactoring.

Link the pull request to its issue. For example, include `Fixes #1234` in the pull request description
when the change fully resolves that issue.

Submitting a pull request does not guarantee that its commits will be merged. Maintainers may close
the pull request and use the issue as the basis for an agent-produced implementation instead. This
lets maintainers ensure that the final change follows current architecture, covers all affected
projects, and includes the necessary tests, documentation, samples, and validation. The original
report, analysis, and proposed code remain valuable inputs to that work.

If a pull request is the agreed approach, please:

- keep it focused on one issue;
- follow the existing code and project conventions;
- add or update deterministic tests for behavior changes;
- update documentation and samples when applicable;
- avoid unrelated refactoring or generated files;
- ensure the relevant focused checks pass before submission.

## Building and Validation

Use the .NET SDK selected by [global.json] and follow the setup guidance in the project [README]. Run
focused tests for the projects you changed before running broader validation.

The main repository checks are:

```bash
python3 -B eng/monorepo/validate-inventory.py
dotnet restore Fabulous.sln
dotnet test Fabulous.sln -c Release
```

For changes to core F# projects, restore the local tools and run the relevant formatting checks:

```bash
dotnet tool restore
dotnet fantomas --check src/neutral/Fabulous.Core
dotnet fantomas --check src/neutral/Fabulous.Tests
dotnet fantomas --check src/neutral/Fabulous.Benchmarks
```

Some platform projects require additional workloads or operating systems. If you cannot run an
applicable check locally, say so in the pull request and describe what you did validate.

## Community

Questions and early ideas can also be discussed on [Discord], but actionable bugs and proposals
should be recorded in a GitHub issue so that decisions and follow-up work remain discoverable.

[Discord]: https://discord.com/channels/196693847965696000/1541149327701971026
[GitHub issues]: https://github.com/fabulous-dev/Fabulous/issues
[global.json]: global.json
[README]: README.md
[Repo Assist]: https://github.com/githubnext/agentics/blob/main/docs/repo-assist.md