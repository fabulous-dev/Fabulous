# Contribution Guidelines

**Note:** If these contribution guidelines are not followed your issue or PR might be closed, so
please read these instructions carefully.


## Contribution types


### Bug Reports

- If you find a bug, please first report it using [Github issues].
  - First check if there is not already an issue for it; duplicated issues will be closed.


### Bug Fix

- If you'd like to submit a fix for a bug, please read the [How To](#how-to-contribute) for how to
   send a Pull Request.
- Indicate on the open issue that you are working on fixing the bug and the issue will be assigned
   to you.
- Write `Fixes #xxxx` in your PR text, where xxxx is the issue number (if there is one).
- Include a test that isolates the bug and verifies that it was fixed.


### New Features

- If you'd like to add a feature to the library that doesn't already exist, feel free to describe
   the feature in a new [GitHub issue].
  - You can also join us on [Discord] to discuss some initials thoughts.
- If you'd like to implement the new feature, please wait for feedback from the project maintainers
   before spending too much time writing the code. In some cases, enhancements may not align well
   with the project future development direction.
- Implement the code for the new feature and please read the [How To](#how-to-contribute).


### Documentation & Miscellaneous

- If you have suggestions for improvements to the documentation, tutorial or examples (or something
   else), we would love to hear about it.
- As always first file a [Github issue].
- Implement the changes to the documentation, please read the [How To](#how-to-contribute).


## How To Contribute


### Requirements

For a contribution to be accepted:

- Format the code using
```
dotnet tool restore
dotnet fantomas -r src samples templates
```
- Check that all tests pass: `dotnet test`;
- Documentation should always be updated or added (if applicable);
- Examples should always be updated or added (if applicable);
- Tests should always be updated or added (if applicable).

If the contribution doesn't meet these criteria, a maintainer will discuss it with you on the issue
or PR. You can still continue to add more commits to the branch you have sent the Pull Request from
and it will be automatically reflected in the PR.


## Open an issue and fork the repository

- If it is a bigger change or a new feature, first of all
   [file a bug or feature report][GitHub issue], so that we can discuss what direction to follow.
- [Fork the project][fork guide] on GitHub.
- Clone the forked repository to your local development machine
   (e.g. `git clone git@github.com:<YOUR_GITHUB_USER>/Fabulous.Avalonia.git`).


### Environment Setup

To build Fabulous.Avalonia, you will need to install:
- the [.NET 7.0 SDK]
- the iOS and Android workloads by executing at the root of the project the following command: `dotnet workload restore`
- an IDE of your preference between: Visual Studio (Windows and macOS) or [JetBrains Rider]

Once everything is set up, you can either open the Fabulous.MauiControls.sln file at the root with your preferred IDE and build the solution or execute the command `dotnet build Fabulous.Avalonia.sln`.


### Performing changes

- Create a new local branch from `main` (e.g. `git checkout -b my-new-feature`)
- Make your changes (try to split them up with one PR per feature/fix).
- When committing your changes, make sure that each commit message is clear.
- Push your new branch to your own fork into the same remote branch
 (e.g. `git push origin my-username.my-new-feature`, replace `origin` if you use another remote.)


### Open a pull request

Go to the [pull request page of Fabulous.Avalonia][PRs] and in the top
of the page it will ask you if you want to open a pull request from your newly created branch.

The title of the pull request should be descriptive of the work you did.


## Maintainers

These instructions are for the maintainers of Fabulous.Avalonia.


### Merging a pull request

When merging a pull request, make sure that the title of the merge commit has a descriptive title.


### Creating a release

There are a few things to think about when doing a release:

- Search through the codebase for `[<Obsolete>]` methods/fields and remove the ones that are marked
   for removal in the version that you are intending to release.
- Create a PR containing the changes for removing the deprecated entities.
- Update [CHANGELOG.md] with the latest fixes and features since the last release.
- Go through the PRs with breaking changes and add migration documentation to the changelog.
   There should be migration docs on each PR, if they haven't been copied to the commit message.
- Bump the version number in the [build workflow] file so Github can release nightly packages with the new version.
- Make sure the build pipeline is succeeding on the main branch.
- Once you are satisfied, create a new release via the [Github releases page], create a new tag with the version you want (eg. `2.2.0`), use the version number as the release name, paste the [CHANGELOG.md] section about this release into the description, and hit Submit.
- The release pipeline will need to be approved by one of the maintainers with release rights.


[GitHub issue]: https://github.com/fabulous-dev/Fabulous.Avalonia/issues
[GitHub issues]: https://github.com/fabulous-dev/Fabulous.Avalonia/issues
[GitHub releases page]: https://github.com/fabulous-dev/Fabulous.Avalonia/releases/new
[PRs]: https://github.com/fabulous-dev/Fabulous.Avalonia/pulls
[fork guide]: https://docs.github.com/en/get-started/quickstart/contributing-to-projects
[Discord]: https://discord.gg/bpTJMbSSYK
[.NET 7.0 SDK]: https://dotnet.microsoft.com/en-us/download
[build workflow]: .github/workflows/build.yml
[CHANGELOG.md]: CHANGELOG.md
[JetBrains Rider]: https://www.jetbrains.com/rider/
