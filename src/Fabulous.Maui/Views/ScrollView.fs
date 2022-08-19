namespace Fabulous.Maui

open Microsoft.Maui
open Microsoft.Maui.Handlers

module ScrollView =

    type FabulousScrollView(handler: IViewHandler) =
        inherit ContentView.FabulousContentView(handler)
       
        new() = FabulousScrollView(ScrollViewHandler())

        interface IScrollView with
            member this.RequestScrollTo(horizontalOffset, verticalOffset, instant) = failwith "todo"
            member this.ScrollFinished() = failwith "todo"
            member this.ContentSize = failwith "todo"
            member this.HorizontalOffset
                with get () = failwith "todo"
                and set value = failwith "todo"
            member this.HorizontalScrollBarVisibility = failwith "todo"
            member this.Orientation = failwith "todo"
            member this.VerticalOffset
                with get () = failwith "todo"
                and set value = failwith "todo"
            member this.VerticalScrollBarVisibility = failwith "todo"
