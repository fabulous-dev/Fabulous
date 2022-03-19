---
title: "Using nightly builds"
description: ""
lead: ""
date: 2020-10-06T08:48:57+00:00
lastmod: 2020-10-06T08:48:57+00:00
draft: false
images: []
menu:
  docs:
    parent: "tutorials"
weight: 300
toc: true
---

On every commit to the `main` branch, packages for each project and template are automatically generated and published to the GitHub Packages Registry.

If you plan to use those packages, you'll need to add a `nuget.config` file to your solution folder and you'll need to add a source pointing to `https://nuget.pkg.github.com/TimLariviere/index.json`.

You'll also new to generate a GitHub PAT (personal access token) for your account and set that token in the `nuget.config` file.

For instructions on how to generate a GitHub PAT, see [Authenticating with a Personal Access Token](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-nuget-registry#authenticating-with-a-personal-access-token).

Example of `nuget.config`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
    <packageSources>
        <clear />
        <add key="nuget" value="https://api.nuget.org/v3/index.json" />
        <!-- For nightly builds -->
        <add key="fabulous" value="https://nuget.pkg.github.com/TimLariviere/index.json" />
    </packageSources>
    <packageSourceCredentials>
        <fabulous>
            <add key="Username" value="USERNAME" />
            <add key="ClearTextPassword" value="TOKEN" />
        </fabulous>
    </packageSourceCredentials>
</configuration>
```

## Using nightly templates

It's the same than above, except you'll need to create `nuget.config` first so the `dotnet` CLI can retrieve the templates from GitHub.

Once you configured `nuget.config`, you can run

```sh
dotnet new -i Fabulous.XamarinForms.Templates::XYZ
```

where `XYZ` is the latest version from [Fabulous.XamarinForms.Templates versions](https://github.com/TimLariviere/Fabulous-new/packages/1191236/versions).
