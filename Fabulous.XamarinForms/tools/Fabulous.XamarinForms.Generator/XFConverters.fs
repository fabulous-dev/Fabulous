namespace Fabulous.XamarinForms.Generator

open Fabulous.CodeGen.AssemblyReader
open Xamarin.Forms
open System

module XFConverters =
    let isTypeResolvable typeName =
        match typeName with
        | "Xamarin.Forms.UriImageSource"
        | "Xamarin.Forms.ItemsView"
        | "Xamarin.Forms.ListItemsLayout" -> false
        | _ -> true
        
    let convertTypeName (typeName: string) =
        match typeName with
        | "Xamarin.Forms.Grid.IGridList`1<Xamarin.Forms.View>" -> "ViewElement list"
        | "System.Collections.Generic.IList`1<Xamarin.Forms.Effect>" -> "ViewElement list"
        | "System.Collections.Generic.IList`1<T>" -> "ViewElement list"
        | "System.Collections.Generic.IList`1<Xamarin.Forms.Behavior>" -> "ViewElement list"
        | "System.Windows.Input.ICommand" -> "unit -> unit"
        | _ -> Converters.convertTypeName typeName
        
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
            |> Option.map (fun positionName -> sprintf "Xamarin.Forms.Button.ButtonContentLayout(%s, %s)" positionName (buttonContentLayout.Spacing.ToString()))
        | :? Rectangle as rectangle when rectangle = Rectangle.Zero -> Some "Xamarin.Forms.Rectangle.Zero"
        | :? Rectangle as rectangle -> Some (sprintf "Xamarin.Forms.Rectangle(%s, %s, %s, %s)" (rectangle.X.ToString()) (rectangle.Y.ToString()) (rectangle.Width.ToString()) (rectangle.Height.ToString()))
        | :? Size as size when size.IsZero -> Some "Xamarin.Forms.Size.Zero"
        | :? Size as size -> Some (sprintf "Xamarin.Forms.Size(%s, %s)" (size.Width.ToString()) (size.Height.ToString()))
        | _ -> Converters.tryGetStringRepresentationOfDefaultValue defaultValue
        
    let convertEventType (eventArgsType: string option) =
        Converters.convertEventType eventArgsType

