namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IEditor =
    inherit IInputView

module Editor =
    let WidgetKey = Widgets.register<Editor>()

    let AutoSize =
        Attributes.defineBindableEnum<EditorAutoSizeOption> Editor.AutoSizeProperty

    let FontAttributes =
        Attributes.defineBindable<FontAttributes> Editor.FontAttributesProperty

    let FontFamily =
        Attributes.defineBindable<string> Editor.FontFamilyProperty

    let FontSize =
        Attributes.defineBindableFloat Editor.FontSizeProperty

    let IsTextPredictionEnabled =
        Attributes.defineBindableBool Editor.IsTextPredictionEnabledProperty

    let Completed =
        Attributes.defineEventNoArg "Editor_Completed" (fun target -> (target :?> Editor).Completed)

[<AutoOpen>]
module EditorBuilders =
    type Fabulous.XamarinForms.View with
        static member inline Editor<'msg>(text: string, onTextChanged: string -> 'msg) =
            WidgetBuilder<'msg, IEditor>(
                Editor.WidgetKey,
                InputView.TextWithEvent.WithValue(
                    ValueEventData.create text (fun args -> onTextChanged args.NewTextValue |> box)
                )
            )

[<Extension>]
type EditorModifiers =
    [<Extension>]
    static member inline font
        (
            this: WidgetBuilder<'msg, #IEditor>,
            ?size: float,
            ?namedSize: NamedSize,
            ?attributes: FontAttributes,
            ?fontFamily: string
        ) =

        let mutable res = this

        match size with
        | None -> ()
        | Some v -> res <- res.AddScalar(Editor.FontSize.WithValue(v))

        match namedSize with
        | None -> ()
        | Some v -> res <- res.AddScalar(Editor.FontSize.WithValue(Device.GetNamedSize(v, typeof<Editor>)))

        match attributes with
        | None -> ()
        | Some v -> res <- res.AddScalar(Editor.FontAttributes.WithValue(v))

        match fontFamily with
        | None -> ()
        | Some v -> res <- res.AddScalar(Editor.FontFamily.WithValue(v))

        res

    /// <summary>Sets a value that controls whether the editor will change size to accommodate input as the user enters it.</summary>
    /// <param name="value">Value that controls whether the editor will change size to accommodate input</param>
    [<Extension>]
    static member inline autoSize(this: WidgetBuilder<'msg, #IEditor>, value: EditorAutoSizeOption) =
        this.AddScalar(Editor.AutoSize.WithValue(value))

    /// <summary>Sets a value that controls whether the editor will allow text prediction.</summary>
    /// <param name="true will allow text prediction. otherwise false.</param>
    [<Extension>]
    static member inline isPredictionEnabled(this: WidgetBuilder<'msg, #IEditor>, value: bool) =
        this.AddScalar(Editor.IsTextPredictionEnabled.WithValue(value))

    /// <summary>Event that is fired when editing has completed.</summary>
    /// <param name="onCompleted">Msg to dispatch when editing has completed.</param>
    [<Extension>]
    static member inline onCompleted(this: WidgetBuilder<'msg, #IEditor>, onCompleted: 'msg) =
        this.AddScalar(Editor.Completed.WithValue(onCompleted))

    /// <summary>Link a ViewRef to access the direct Editor control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IEditor>, value: ViewRef<Editor>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
