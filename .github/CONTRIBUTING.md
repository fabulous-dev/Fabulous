# Contributing

Thank you for your interest in contributing to Fabulous! In this document, we'll outline what you need to know about contributing and how to get started.

## Contributing code

By contributing to this repository, you can contribute to 4 distinct products:
- Fabulous
- Fabulous.CodeGen
- Fabulous.XamarinForms
- Fabulous.StaticView.XamarinForms

Fabulous is placed at the root of the repository, the 3 others have their own separate folders.

In the future, Fabulous.CodeGen, Fabulous.XamarinForms, and Fabulous.StaticView.XamarinForms might move in their own repositories, hence the importance to keep them separated.

### What to work on

If you're looking for something to work on, please browse [open issues](https://github.com/fsprojects/Fabulous/issues). Any issue that is not already assigned is up for grabs. You can also look for issues tagged [help wanted](https://github.com/fsprojects/Fabulous/issues?q=is%3Aissue+is%3Aopen+label%3A%22help+wanted%22) and [good first issue](https://github.com/fsprojects/Fabulous/issues?q=is%3Aissue+is%3Aopen+label%3A%22good+first+issue%22).

Regarding coding style, we try to follow the [F# code formatting guidelines](https://docs.microsoft.com/en-us/dotnet/fsharp/style-guide/formatting).  
What's really important is to be consistent with the existing nearby code.

### Pull Request Requirements

When working on a bug fix or a new feature, try to include unit tests and documentation - at least for the important or non-trivial parts.

If you're adding new controls to Fabulous.XamarinForms (either through an extension, or directly from Xamarin.Forms), validate your work by adding the new controls to the [AllControls sample app](https://github.com/fsprojects/Fabulous/tree/master/Fabulous.XamarinForms/samples/AllControls) with matching [documentation](https://fsprojects.github.io/Fabulous/Fabulous.XamarinForms/views-basic-elements.html).

Please check the "Allow edits from maintainers" checkbox on your pull request. This allows us to quickly make minor fixes and resolve conflicts for you.

Once created, the pull request will be automatically validated by 2 builds: a Windows one (compile the projects and run unit tests) and a macOS one (same as Windows + compile the samples and test the templates). It takes about 30min to complete.

If one of those builds failed, don't hesitate to go ahead and look at the build output to fix potential issues in your code, even before a reviewer could read your pull request.

We might also run a more comprehensive build (Windows, macOS, and Linux) if required.

## Review Process

All pull requests need to be reviewed and tested by at least one maintainer. We do our best to review pull requests in a timely manner, but please be patient, we do that on our spare time. :)

If there are any changes requested, the contributor should make them at their earliest convenience or let the reviewers know that they are unable to make further contributions. If the pull request requires only minor changes, then someone else may pick it up and finish it. We will do our best to make sure that all credit is retained for contributors.

Once a pull request has been approved, it can be merged.

## Merge Process

Bug fixes should be targeted at the earliest appropriate branch.

- The current stable branch corresponds to the latest stable version available on NuGet.org. This branch will now only accept regressions or fixes that meet a very high bar and low risk.
- The current prerelease branch corresponds to the latest prerelease version available on NuGet.org. This branch will only accept bug fixes without API changes or breaking changes, with the exception of any API that is under an experimental flag.
- Master corresponds to a version that is not yet tagged. This is also the "nightly" branch. This is where anything that doesn't fit into the stable or prerelease branches should be targeted.

Commits will be merged up from stable to prerelease to master branches on a regular basis (typically every Monday and whenever a new release is tagged).

## Other readings

- [Getting started](GETTINGSTARTED.md)
- [Maintaining guide](MAINTAINING.md)