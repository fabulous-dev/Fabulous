namespace AllControls

module Router =        
    type Pages =
        | Root
        | SkiaSharp
    
    type PageModel =
        | HomeModel of Home.Model
        | SkiaSharpModel of Extensions.SkiaSharp.Model
        
    type PageMsg =
        | HomeMsg of AllControls.Home.Msg
        | SkiaSharpMsg of Extensions.SkiaSharp.Msg
        
    type RouterCmdMsg =
        | NavigateTo of Pages
            
    let initForPage page =
        match page with
        | Root -> HomeModel (Home.init())
        | SkiaSharp -> SkiaSharpModel (Extensions.SkiaSharp.init())
        
    let updateForPage msg (model: PageModel) =
        match msg, model with
        | HomeMsg pageMsg, HomeModel pageModel ->
            let newPageModel, _, newPageExternalMsg = Home.update pageMsg pageModel
                        
            (HomeModel newPageModel), [
                match newPageExternalMsg with
                | Some Home.ExternalMsg.GoToPage ->
                    yield (NavigateTo SkiaSharp)
                | _ -> ()
            ]
            
        | SkiaSharpMsg pageMsg, SkiaSharpModel pageModel ->
            let newPageModel, _, _ = Extensions.SkiaSharp.update pageMsg pageModel
            
            (SkiaSharpModel newPageModel), []
            
        | _ ->
            model, []

    let viewForPage (model: PageModel) dispatch =
        match model with
        | HomeModel homeModel ->
            Home.view homeModel (HomeMsg >> dispatch)
        | SkiaSharpModel skiaSharpModel ->
            Extensions.SkiaSharp.view skiaSharpModel (SkiaSharpMsg >> dispatch)
