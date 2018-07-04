Elmish.XamarinForms Guide
=======

{% include_relative contents-views.md %}

Multi-page Applications and Navigation
-------

Multiple pages are generated as part of the overall view. Five multi-page navigation models are shown in the `AllControls` sample:

* NavigationPage using push/pop
* NavigationPage Toolbar
* TabbedPage
* CarouselPage
* MasterDetail

### NavigationPage using push/pop

The basic principles of implementing push/pop navigation are as follows:

1. Keep some information in your model indicating the page stack (e.g. a list of page identifiers or page models)
2. Return the current visual page stack in the `pages` property of `NavigationPage`.
3. Set `HasNavigationBar` and `HasBackButton` on each sub-page according to your desire
4. Dispatch messages in order to navigate, where the corresponding `update` adjusts the page stack in the model

```fsharp
let view model dispatch =
    Xaml.NavigationPage(pages=
        [ for page in model.PageStack do
            match page with
            | "Home" ->
                yield Xaml.ContentPage(...).HasNavigationBar(true).HasBackButton(true)
            | "PageA" ->
                yield Xaml.ContentPage(...).HasNavigationBar(true).HasBackButton(true)
            | "PageB" ->
                yield Xaml.ContentPage(...).HasNavigationBar(true).HasBackButton(true)
        ])
```

### NavigationPage Toolbar

A toolbar can be added to a navigation page using `.ToolbarItems([ ... ])` as follows:

```fsharp
let view model dispatch =
    ...
    Xaml.NavigationPage(pages =
        [ Xaml.ContentPage(...)
            .ToolbarItems([Xaml.ToolbarItem(text = "About", command = (fun () -> dispatch (ShowAbout true))) ] )
```

### Example: Modal pages by pushing an extra page

A modal page can be achieved by yielding an additional page in the NavigationPage. For example, here is an "About" page example:

```fsharp
type Model =
    { ShowAbout: bool
      ...
    }

type Msg =
    | ...
    | ShowAbout of bool

let view model dispatch =
    ...
    let rootPage dispatch =
        Xaml.ContentPage(title = "Root Page", content = Xaml.Button(text = "About", command = (fun () -> dispatch (ShowAbout true))))

    let modalPage dispatch =
        Xaml.ContentPage(title = "About",
            content= Xaml.StackLayout(
                children = [
                    Xaml.Label(text = "Elmish.XamarinForms!")
                    Xaml.Button(text = "Continue", command = (fun () -> dispatch (ShowAbout false) ))
                ]))

    Xaml.NavigationPage(pages=
        [ yield rootPage dispatch
          if model.ShowAbout then
              yield modalPage dispatch
        ])
```

### TabbedPage navigation

Return a `TabbedPage` from your view:

```fsharp
let view model dispatch =
    Xaml.TabbedPage(children = [ ... ])
```

### CarouselPage navigation

Return a `CarouselPage` from your view:

```fsharp
let view model dispatch =
    Xaml.CarouselPage(children = [ ... ])
```

### MasterDetail Page navigation

Return a `MasterDetailPage` from your view, choosing the appropriate `MasterBehavior`:

```fsharp
let view model dispatch =
    Xaml.MasterDetailPage(
        masterBehavior=MasterBehavior.Popover,
        master = Xaml.ContentPage(...),
        detail = Xaml.ContentPage(...))
```

See also

* The `AllControls` sample.
