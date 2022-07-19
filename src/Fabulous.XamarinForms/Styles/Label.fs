namespace Fabulous.XamarinForms

open System
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.ScalarAttributeDefinitions
open Fabulous.StackAllocatedCollections.StackList
open Xamarin.Forms

type IStyle =
    interface
    end

type IElementStyle =
    interface
    end

type INavigableElementStyle =
    inherit IElementStyle

type IVisualElementStyle =
    inherit INavigableElementStyle

type IViewStyle =
    inherit IVisualElementStyle

type ILabelStyle =
    inherit IViewStyle

module LabelStyle =
    let registerStyle<'T> () =
        let key = WidgetDefinitionStore.getNextKey()

        let definition =
            { Key = key
              Name = $"Style<{typeof<'T>}>"
              TargetType = typeof<Style>
              CreateView =
                  fun (widget, treeContext, parentNode) ->
                      treeContext.Logger.Debug("Creating style for {0}", typeof<'T>.Name)

                      let style = Style(typeof<'T>)
                      let weakReference = WeakReference(style)

                      let parentNode =
                          match parentNode with
                          | ValueNone -> None
                          | ValueSome node -> Some node

                      let node =
                          ViewNode(parentNode, treeContext, weakReference)

                      StyleViewNode.set node style

                      Reconciler.update treeContext.CanReuseView ValueNone widget node
                      struct (node :> IViewNode, box style) }

        WidgetDefinitionStore.set key definition
        key

    let defineSetter<'T when 'T: equality> (bindableProperty: BindableProperty) : SimpleScalarAttributeDefinition<'T> =
        let updateNode (_prevOpt: 'T voption) (currOpt: 'T voption) (node: IViewNode) =
            let style = node.Target :?> Style

            let index =
                let mutable found = -1

                for i = 0 to style.Setters.Count - 1 do
                    let setter = style.Setters.[i]

                    if setter.Property = bindableProperty then
                        found <- i

                found

            match struct (currOpt, index) with
            | struct (ValueNone, -1) -> ()
            | struct (ValueNone, index) -> style.Setters.RemoveAt(index)

            | struct (ValueSome curr, -1) ->
                let setter =
                    Setter(Property = bindableProperty, Value = curr)

                style.Setters.Add(setter)

            | struct (ValueSome curr, index) ->
                let setter = style.Setters.[index]
                setter.Value <- curr

        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(ScalarAttributeComparers.equalityCompare, updateNode)
            |> AttributeDefinitionStore.registerScalar

        { Key = key
          Name = bindableProperty.PropertyName }

    let WidgetKey = registerStyle<Label>()

    let TextColor =
        defineSetter<Color> Label.TextColorProperty

    let TextDecorations =
        defineSetter<TextDecorations> Label.TextDecorationsProperty

[<AutoOpen>]
module LabelStyleBuilders =
    type Fabulous.XamarinForms.View with
        static member inline LabelStyle<'msg>() =
            WidgetBuilder<'msg, ILabelStyle>(
                LabelStyle.WidgetKey,
                AttributesBundle(StackList.empty(), ValueNone, ValueNone)
            )

[<Extension>]
type LabelStyleModifiers =
    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #ILabelStyle>, value: Color) =
        this.AddScalar(LabelStyle.TextColor.WithValue(value))

    [<Extension>]
    static member inline textDecorations(this: WidgetBuilder<'msg, #ILabelStyle>, value: TextDecorations) =
        this.AddScalar(LabelStyle.TextDecorations.WithValue(value))
