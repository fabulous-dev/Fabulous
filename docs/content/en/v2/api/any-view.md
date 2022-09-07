---
id: "v2-any-view"
title: "AnyView"
description: ""
lead: ""
date: 2022-06-21T00:00:00+00:00
lastmod: 2022-06-21T00:00:00+00:00
draft: false
images: []
menu:
  docs:
    parent: "api"
toc: true
---

**AnyView** allows changing the type of view used in a given view hierarchy. Whenever the type of view used with an AnyView changes.

## Constructors

| Constructors | Description |
|--|--|
| AnyView<'msg, 'marker when 'marker :> IView>(widget: WidgetBuilder<'msg, 'marker>) | Downcast to IView to allow to return different types of views in a single expression (e.g. if/else, match with pattern, etc.) |
| AnyView<'msg, 'marker when 'marker :> IPage>(widget: WidgetBuilder<'msg, 'marker>) | Downcast to IPage to allow to return different types of pages in a single expression (e.g. if/else, match with pattern, etc.) |
| AnyView<'msg, 'marker when 'marker :> ICell>(widget: WidgetBuilder<'msg, 'marker>) | Downcast to ICell to allow to return different types of cells in a single expression (e.g. if/else, match with pattern, etc.) |
