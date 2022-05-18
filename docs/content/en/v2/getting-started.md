---
id: "v2-getting-started"
title: "Getting started"
description: ""
lead: ""
date: 2020-10-06T08:48:57+00:00
lastmod: 2020-10-06T08:48:57+00:00
draft: false
images: []
menu:
  docs:
    parent: "v2"
weight: 1
toc: true
---

## Requirements

Working with Fabulous requires a few different tools:
- .NET 6.0 SDK or newer ([link](https://dotnet.microsoft.com/))
- A compatible IDE:
  - Visual Studio 2021 or newer ([link](https://visualstudio.microsoft.com/vs/))
  - Visual Studio 2019 for Mac or newer ([link](https://visualstudio.microsoft.com/vs/mac/))
  - JetBrains Rider ([link](https://www.jetbrains.com/rider/) - Windows and macOS)  
- During installation, you will be asked to choose the workloads you want. Be sure to select the mobile development workload and F#.  
  Note if you choose JetBrains Rider, you will also need to install either VS or VS Mac since Rider doesn't install workloads.

## Creating a new Fabulous project

### 1) Download the latest templates

First, we need to install the latest templates for Fabulous. This is done via command line.  
Open a terminal in the folder where you want to store the new solution, and type the following command:

```sh
dotnet new -i Fabulous.XamarinForms.Templates
```

This will add `fabulous-xf-app` to the templates available for `dotnet new`.

```sh
dotnet new --list
```

![Result of dotnet new --list](dotnet-new-list.png)

### 2) Create the project

Now, we can create the solution using the newly installed template:

```sh
dotnet new fabulous-xf-app -n FabHelloWorld
```

TBD: Show what it looks like in an IDE

### 3) Build and run

TBD: Show the selection of Debug|AnyCPU + Android project vs Debug|iPhone/iPhoneSimulator + iOS Project to debug  
TBD: Show interaction with the default app

## Understanding the default structure

TBD: Give a quick tour of the code with a very quick MVU explanation