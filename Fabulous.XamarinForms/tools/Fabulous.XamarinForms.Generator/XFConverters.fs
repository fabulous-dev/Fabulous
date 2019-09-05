namespace Fabulous.XamarinForms.Generator

open System
open Fabulous.CodeGen.AssemblyReader
open Xamarin.Forms

module XFConverters =
    let isTypeResolvable typeName =
        match typeName with
        | "Xamarin.Forms.UriImageSource"
        | "Xamarin.Forms.ItemsView"
        | "Xamarin.Forms.ListItemsLayout" -> false
        | _ -> true
        
    let convertTypeName (typeName: string) =
        match typeName with
        | "Xamarin.Forms.Grid.IGridList<Xamarin.Forms.View>"
        | "System.Collections.Generic.IList<Xamarin.Forms.Effect>"
        | "System.Collections.Generic.IList<T>"
        | "System.Collections.Generic.IList<Xamarin.Forms.Behavior>"
        | "System.Collections.Generic.IList<Xamarin.Forms.Span>" -> "ViewElement list"
        | "System.Windows.Input.ICommand" -> "unit -> unit"
        | "Xamarin.Forms.Button+ButtonContentLayout" -> "Xamarin.Forms.Button.ButtonContentLayout"
        | "System.EventHandler<Xamarin.Forms.VisualElement/FocusRequestArgs>" -> "System.EventHandler<Xamarin.Forms.VisualElement.FocusRequestArgs>"
        | "System.EventHandler<System.Tuple<System.String,System.String>>" -> "System.EventHandler<string * string>"
        | _ -> Converters.convertTypeName typeName
        
    let convertEventType (eventArgsTypeOpt: string option) =
        match eventArgsTypeOpt with
        | Some "Xamarin.Forms.VisualElement/FocusRequestArgs" -> "Xamarin.Forms.VisualElement.FocusRequestArgs"
        | Some "System.Tuple<System.String,System.String>" -> "(string * string) -> unit"
        | Some "System.Object" -> "obj -> unit"
        | _ -> Converters.convertEventType eventArgsTypeOpt
        
    let rec tryGetStringRepresentationOfDefaultValue (defaultValue: obj) : string option =
        match defaultValue with
        | :? Color as color when color = Color.Default || color = Unchecked.defaultof<Color> -> Some "Xamarin.Forms.Color.Default"
        | :? Keyboard as keyboard when keyboard = Keyboard.Default -> Some "Xamarin.Forms.Keyboard.Default"
        | :? Font as font when font.IsDefault -> Some "Xamarin.Forms.Font.Default"
        | :? Thickness as thickness when thickness = Unchecked.defaultof<Thickness> -> Some "Xamarin.Forms.Thickness(0.)"
        | :? CornerRadius as cornerRadius when cornerRadius = Unchecked.defaultof<CornerRadius> -> Some "Xamarin.Forms.CornerRadius(0.)"
        | :? LayoutOptions as layoutOptions ->
            match layoutOptions with
            | x when x = LayoutOptions.Start -> Some "Xamarin.Forms.LayoutOptions.Start"
            | x when x = LayoutOptions.Center -> Some "Xamarin.Forms.LayoutOptions.Center"
            | x when x = LayoutOptions.End -> Some "Xamarin.Forms.LayoutOptions.End"
            | x when x = LayoutOptions.Fill -> Some "Xamarin.Forms.LayoutOptions.Fill"
            | x when x = LayoutOptions.StartAndExpand -> Some "Xamarin.Forms.LayoutOptions.StartAndExpand"
            | x when x = LayoutOptions.CenterAndExpand -> Some "Xamarin.Forms.LayoutOptions.CenterAndExpand"
            | x when x = LayoutOptions.EndAndExpand -> Some "Xamarin.Forms.LayoutOptions.EndAndExpand"
            | x when x = LayoutOptions.FillAndExpand -> Some "Xamarin.Forms.LayoutOptions.FillAndExpand"
            | x -> Some (sprintf "Xamarin.Forms.LayoutOptions(Xamarin.Forms.LayoutAlignment.%s, %s)" (Enum.GetName(typeof<LayoutAlignment>, x.Alignment)) (if x.Expands then "true" else "false"))
        | :? Button.ButtonContentLayout as buttonContentLayout ->
            tryGetStringRepresentationOfDefaultValue buttonContentLayout.Position
            |> Option.map (fun positionName -> sprintf "Xamarin.Forms.Button.ButtonContentLayout(%s, %s)" positionName (Converters.floatToString buttonContentLayout.Spacing))
        | :? Rectangle as rectangle when rectangle = Rectangle.Zero -> Some "Xamarin.Forms.Rectangle.Zero"
        | :? Rectangle as rectangle -> Some (sprintf "Xamarin.Forms.Rectangle(%s, %s, %s, %s)" (Converters.floatToString rectangle.X) (Converters.floatToString rectangle.Y) (Converters.floatToString rectangle.Width) (Converters.floatToString rectangle.Height))
        | :? Size as size when size.IsZero -> Some "Xamarin.Forms.Size.Zero"
        | :? Size as size -> Some (sprintf "Xamarin.Forms.Size(%s, %s)" (Converters.floatToString size.Width) (Converters.floatToString size.Height))
        | :? IVisual as visual ->
            match visual.GetType().Name with
            | "MatchParentVisual" -> Some "Xamarin.Forms.VisualMarker.MatchParent"
            | "Default" -> Some "Xamarin.Forms.VisualMarker.Default"
            | "Material" -> Some "Xamarin.Forms.VisualMarker.Material"
            | _ -> None
        | :? FlexBasis as flexBasis when flexBasis = FlexBasis.Auto -> Some "Xamarin.Forms.FlexBasis.Auto"
        | :? FlexBasis as flexBasis -> Some (sprintf "Xamarin.Forms.FlexBasis(%s)" (Converters.float32ToString flexBasis.Length))
        | _ -> Converters.tryGetStringRepresentationOfDefaultValue defaultValue

