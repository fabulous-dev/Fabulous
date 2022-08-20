namespace Fabulous.Maui

open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open Microsoft.Maui
open Microsoft.Maui.Handlers

module ScrollView =
    let HorizontalScrollBarVisibility = Attributes.defineMauiScalarWithEquality<ScrollBarVisibility> "HorizontalScrollBarVisibility"
    let Orientation = Attributes.defineMauiScalarWithEquality<ScrollOrientation> "Orientation"
    let VerticalScrollBarVisibility = Attributes.defineMauiScalarWithEquality<ScrollBarVisibility> "VerticalScrollBarVisibility"
    
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
            member this.HorizontalScrollBarVisibility = this.GetScalar(HorizontalScrollBarVisibility, ScrollBarVisibility.Default)
            member this.Orientation = this.GetScalar(Orientation, ScrollOrientation.Vertical)
            member this.VerticalOffset
                with get () = failwith "todo"
                and set value = failwith "todo"
            member this.VerticalScrollBarVisibility = this.GetScalar(VerticalScrollBarVisibility, ScrollBarVisibility.Default)
            
    let WidgetKey = Widgets.register<FabulousScrollView>()
            
[<AutoOpen>]
module ScrollViewBuilders =
    type Fabulous.Maui.View with
        static member inline ScrollView<'msg, 'marker when 'marker :> IView>(content: WidgetBuilder<'msg, 'marker>) =
            WidgetBuilder<'msg, IScrollView>(
                ScrollView.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome [|
                        ContentView.Content.WithValue(content.Compile())
                    |],
                    ValueNone
                )
            )
