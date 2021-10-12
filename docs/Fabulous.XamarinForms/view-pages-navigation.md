{% include_relative _header.md %}

{% include_relative contents.md %}

Multi-page Applications and Navigation
-------
##### (topic last updated: pending)
<br /> 

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
5. Utilize `popped` event to handle page removal

```fsharp
let view model dispatch =
    View.NavigationPage(pages=
        [ for page in model.PageStack do
            match page with
            | "Home" ->
                yield View.ContentPage(...).HasNavigationBar(true).HasBackButton(true)
            | "PageA" ->
                yield View.ContentPage(...).HasNavigationBar(true).HasBackButton(true)
            | "PageB" ->
                yield View.ContentPage(...).HasNavigationBar(true).HasBackButton(true)
        ],
        popped = (fun _ -> dispatch NavigationPopped))
```

### NavigationPage Toolbar

A toolbar can be added to a navigation page using `.ToolbarItems([ ... ])` as follows:

```fsharp
let view model dispatch =
    ...
    View.NavigationPage(pages =
        [ View.ContentPage(...)
            .ToolbarItems([View.ToolbarItem(text = "About", command = (fun () -> dispatch (ShowAbout true))) ] )
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
        View.ContentPage(title = "Root Page", content = View.Button(text = "About", command = (fun () -> dispatch (ShowAbout true))))

    let modalPage dispatch =
        View.ContentPage(title = "About",
            content= View.StackLayout(
                children = [
                    View.Label(text = "Fabulous!")
                    View.Button(text = "Continue", command = (fun () -> dispatch (ShowAbout false) ))
                ]))

    View.NavigationPage(pages=
        [ yield rootPage dispatch
          if model.ShowAbout then
              yield modalPage dispatch
        ])
```

### TabbedPage navigation

Return a `TabbedPage` from your view:

```fsharp
let view model dispatch =
    View.TabbedPage(children = [ ... ])
```

### CarouselPage navigation

Return a `CarouselPage` from your view:

```fsharp
let view model dispatch =
    View.CarouselPage(children = [ ... ])
```

### MasterDetail Page navigation

Return a `FlyoutPage` from your view:

```fsharp
let view model dispatch =
    View.FlyoutPage(
        flyout = View.ContentPage(title ="flyoutPage", ...), // 'title' is needed for the flyout page
        detail = View.ContentPage(...)        
    )
```

See also

* [The `AllControls` sample](https://github.com/fsprojects/Fabulous/blob/v1.0/Fabulous.XamarinForms/samples/AllControls/AllControls/App.fs)
