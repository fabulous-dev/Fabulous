namespace AllControls.Controls

open AllControls.Helpers

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

module TabbedPage1 =
    type Msg =
        | SetTabbed1CurrentPage of int
        | IncrementForSlider
        | DecrementForSlider
        | ChangeMinimumMaximumForSlider1
        | ChangeMinimumMaximumForSlider2
        | SliderValueChanged of int
        | UpdateNewGridSize of double * GestureStatus
        | UpdateGridPortal of int * int
        
    type Model =
        { Tabbed1CurrentPageIndex: int
          CountForSlider : int
          StepForSlider : int 
          MinimumForSlider : int
          MaximumForSlider : int 
          GridSize: int
          NewGridSize: double // used during pinch
          GridPortal: int * int }
        
    let mapToCmd _ = Cmd.none
        
    let init () =
        { Tabbed1CurrentPageIndex = 0
          CountForSlider = 0
          StepForSlider = 3
          MinimumForSlider = 0
          MaximumForSlider = 10
          GridSize = 6
          NewGridSize = 6.0
          GridPortal = (0, 0) }
        
    let update msg model =
        match msg with
        | SetTabbed1CurrentPage index ->
            { model with Tabbed1CurrentPageIndex = index }, []
        | IncrementForSlider ->
            { model with CountForSlider = model.CountForSlider + model.StepForSlider }, []
        | DecrementForSlider ->
            { model with CountForSlider = model.CountForSlider - model.StepForSlider }, []
        | ChangeMinimumMaximumForSlider1 ->
            { model with MinimumForSlider = 0; MaximumForSlider = 10 }, []
        | ChangeMinimumMaximumForSlider2 ->
            { model with MinimumForSlider = 15; MaximumForSlider = 20 }, []
        | SliderValueChanged n ->
            { model with StepForSlider = n }, []
        | UpdateNewGridSize (n, status) -> 
            match status with 
            | GestureStatus.Running ->
                { model with NewGridSize = model.NewGridSize * n}, []
            | GestureStatus.Completed ->
                let sz = int (model.NewGridSize + 0.5)
                { model with GridSize = sz; NewGridSize = float sz }, []
            | GestureStatus.Canceled ->
                { model with NewGridSize = double model.GridSize }, []
            | _ ->
                model, []
        | UpdateGridPortal (x, y) ->
            { model with GridPortal = (x, y) }, []
    
    let tab1View minimum maximum count step dispatch =
        View.ScrollingContentPage(
            title = "Slider",
            content = View.StackLayout([
                View.Label(text = "Label:")
                View.Label(
                    text = sprintf "%d" count,
                    horizontalOptions = LayoutOptions.CenterAndExpand
                )

                View.Label(text = "Button:")
                View.Button(
                    text = "Increment",
                    command = (fun () -> dispatch IncrementForSlider),
                    horizontalOptions = LayoutOptions.CenterAndExpand
                )
         
                View.Label(text = "Button:")
                View.Button(
                    text = "Decrement",
                    command = (fun () -> dispatch DecrementForSlider),
                    horizontalOptions = LayoutOptions.CenterAndExpand
                )

                View.Label(text = "Button:")
                View.Button(
                    text = "Set Minimum = 0 / Maximum = 10",
                    command = (fun () -> dispatch ChangeMinimumMaximumForSlider1),
                    horizontalOptions = LayoutOptions.CenterAndExpand
                )
                View.Button(
                    text = "Set Minimum = 15 / Maximum = 20",
                    command = (fun () -> dispatch ChangeMinimumMaximumForSlider2),
                    horizontalOptions = LayoutOptions.CenterAndExpand
                )

                View.Label(
                    text = sprintf "Slider: (Minimum %d, Maximum %d, Value %d)" minimum maximum step
                )
                View.Slider(
                    minimumMaximum = (float minimum, float maximum), 
                    value = double step, 
                    valueChanged = (fun args -> dispatch (SliderValueChanged (int (args.NewValue + 0.5)))), 
                    horizontalOptions=LayoutOptions.Fill
                ) 

                View.Button(
                    text = "Go to Image", 
                    command = (fun () -> dispatch (SetTabbed1CurrentPage 4)), 
                    horizontalOptions = LayoutOptions.CenterAndExpand, verticalOptions=LayoutOptions.End
                )
        ])
    )
    
    let tab2View () =
        View.NonScrollingContentPage(
            title = "Grid",
            content = View.StackLayout([
                View.Label(text = sprintf "Grid (6x6, *):")
                View.Grid(
                    rowdefs = [for _ in 1 .. 6 -> Star],
                    coldefs = [for _ in 1 .. 6 -> Star], 
                    children = [
                        for i in 1 .. 6 do 
                            for j in 1 .. 6 -> 
                                let color = Color((1.0/float i), (1.0/float j), (1.0/float (i+j)), 1.0) 
                                View.BoxView(color).Row(i-1).Column(j-1)
                    ]
                )
            ])
        )
        
    let tab3View gridSize newGridSize dispatch =
        View.NonScrollingContentPage(
            title = "Grid+Pinch",
            content = View.StackLayout(
                gestureRecognizers = [
                    View.PinchGestureRecognizer(
                        pinchUpdated = (fun pinchArgs -> 
                            dispatch (UpdateNewGridSize (pinchArgs.Scale, pinchArgs.Status))
                        )
                    )
                ],
                children = [
                    View.Label(text=sprintf "Grid (nxn, pinch, size = %f):" newGridSize)
                    // The Grid doesn't change during the pinch...
                    dependsOn gridSize (fun _ _ -> 
                        View.Grid(
                            rowdefs = [for _ in 1 .. gridSize -> Star],
                            coldefs = [for _ in 1 .. gridSize -> Star], 
                            children = [ 
                                for i in 1 .. gridSize do 
                                    for j in 1 .. gridSize -> 
                                        let color = Color((1.0/float i), (1.0/float j), (1.0/float (i+j)), 1.0) 
                                        View.BoxView(color).Row(i-1).Column(j-1)
                            ]
                        )
                    )
            ])
        )
        
    let tab4View gridPortal dispatch =
        let dx, dy = gridPortal
        View.NonScrollingContentPage(
            title = "Grid+Pan",
            content = View.StackLayout(
                gestureRecognizers = [
                    View.PanGestureRecognizer(
                        touchPoints = 1,
                        panUpdated = (fun panArgs -> 
                            if panArgs.StatusType = GestureStatus.Running then 
                                dispatch (UpdateGridPortal (dx - int (panArgs.TotalX/10.0), dy - int (panArgs.TotalY/10.0)))
                        )
                    )
                ],
                children = [
                    View.Label(text = sprintf "Grid (nxn, auto, edit entries, 1-touch pan, (%d, %d):" dx dy)
                    View.Grid(
                        rowdefs = [for _ in 1 .. 6 -> Star],
                        coldefs = [for _ in 1 .. 6 -> Star], 
                        children = [
                            for row in 1 .. 6 do 
                                for col in 1 .. 6 ->
                                    View.Label(
                                        text = sprintf "(%d, %d)" (col+dx) (row+dy),
                                        backgroundColor = Color.White,
                                        textColor = Color.Black
                                    ).Row(row-1)
                                     .Column(col-1)
                        ]
                    )
                ] 
            )
        )
        
    let tab5View () =
        View.NonScrollingContentPage(
            title = "Image",
            content = View.StackLayout([
                View.Label(text = "Image (URL):")
                View.Image(
                    source = Path "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg", 
                    horizontalOptions = LayoutOptions.Fill,
                    verticalOptions = LayoutOptions.FillAndExpand
                )
                View.Label(
                    text = "Image (Embedded):",
                    margin = Thickness (0., 20., 0., 0.)
                )
                View.Image(
                    source = Source (ImageSource.FromResource("AllControls.Baboon_Serengeti.jpg", typeof<Msg>.Assembly)), 
                    horizontalOptions = LayoutOptions.Fill,
                    verticalOptions = LayoutOptions.FillAndExpand
                )
            ])
        )
                
    
    let view model dispatch = 
        View.TabbedPage(
            useSafeArea = true,
            currentPageChanged = (fun index ->
                match index with
                | None -> printfn "No tab selected"
                | Some ind ->
                    printfn "Tab changed : %i" ind
                    dispatch (SetTabbed1CurrentPage ind)
            ),
            currentPage = model.Tabbed1CurrentPageIndex,
            children = [
                dependsOn (model.MinimumForSlider, model.MaximumForSlider, model.CountForSlider, model.StepForSlider) (fun model (minimum, maximum, count, step) ->
                    tab1View minimum maximum count step dispatch
                )

                dependsOn () (fun model () ->
                    tab2View ()
                )

                dependsOn (model.GridSize, model.NewGridSize) (fun model (gridSize, newGridSize) ->
                    tab3View gridSize newGridSize dispatch
                )

                dependsOn model.GridPortal (fun model gridPortal ->
                    tab4View gridPortal dispatch
                )

                dependsOn () (fun model () ->
                    tab5View ()
                )
            ]
        )

