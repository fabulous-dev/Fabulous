# fabulous.dev

## How to build locally on macOS

- Install Hugo via command line: `brew install hugo`
- At the root of the repository, run `hugo server`
- Open a browser at `http://localhost:1313`

For more information: https://gohugo.io/installation/

## Basic ideas for this repository

- This repository will be the home of https://fabulous.dev
- It will be compiled as a static website from this Hugo template and published on GitHub Pages
- docs.fabulous.dev and api.fabulous.dev will have their own repositories, with their own GitHub Pages
- A Hugo theme `Fabulous` is available in the `themes` folder, ideally it should be generic enough to be reused on the docs and api websites directly. Everything related to fabulous.dev itself should be in the folders at the root of this repo.
- Most configurations (like the page title, icon, description, etc) are set in the `config.toml` file