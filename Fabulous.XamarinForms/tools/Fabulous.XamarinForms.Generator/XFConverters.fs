namespace Fabulous.XamarinForms.Generator

open Mono.Cecil
open Fabulous.CodeGen.AssemblyReader
open Xamarin.Forms
open System

module XFConverters =
    let shouldIgnoreType (tdef: TypeDefinition) =
        match tdef.FullName with
        | "Xamarin.Forms.UriImageSource"
        | "Xamarin.Forms.ItemsView"
        | "Xamarin.Forms.ListItemsLayout" -> true
        | _ -> false
        
    let convertTypeName (typeName: string) =
        match typeName with
        | "Xamarin.Forms.Grid/IGridList`1<Xamarin.Forms.View>" -> "ViewElement list"
        | "System.Windows.Input.ICommand" -> "unit -> unit"
        | "System.Collections.Generic.IList`1[[Xamarin.Forms.Behavior, Xamarin.Forms.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]" -> "ViewElement list"
        | _ -> Converters.convertTypeName typeName
        
    let rec getStringRepresentationOfDefaultValue (defaultValue: obj) : string =
        match defaultValue with
        | :? Color as color when color = Color.Default || color = Unchecked.defaultof<Color> -> "Xamarin.Forms.Color.Default"
        | :? TimeSpan as timeSpan when timeSpan = TimeSpan.Zero -> "System.TimeSpan.Zero"
        | :? Keyboard as keyboard when keyboard = Keyboard.Default -> "Xamarin.Forms.Keyboard.Default"
        | :? Font as font when font.IsDefault -> "Xamarin.Forms.Font.Default"
        | :? Thickness as thickness when thickness = Unchecked.defaultof<Thickness> -> "Xamarin.Forms.Thickness(0.)"
        | :? CornerRadius as cornerRadius when cornerRadius = Unchecked.defaultof<CornerRadius> -> "Xamarin.Forms.CornerRadius(0.)"
        | :? LayoutOptions as layoutOptions ->
            match layoutOptions with
            | x when x = LayoutOptions.Start -> "Xamarin.Forms.LayoutOptions.Start"
            | x when x = LayoutOptions.Center -> "Xamarin.Forms.LayoutOptions.Center"
            | x when x = LayoutOptions.End -> "Xamarin.Forms.LayoutOptions.End"
            | x when x = LayoutOptions.Fill -> "Xamarin.Forms.LayoutOptions.Fill"
            | x when x = LayoutOptions.StartAndExpand -> "Xamarin.Forms.LayoutOptions.StartAndExpand"
            | x when x = LayoutOptions.CenterAndExpand -> "Xamarin.Forms.LayoutOptions.CenterAndExpand"
            | x when x = LayoutOptions.EndAndExpand -> "Xamarin.Forms.LayoutOptions.EndAndExpand"
            | x when x = LayoutOptions.FillAndExpand -> "Xamarin.Forms.LayoutOptions.FillAndExpand"
            | _ -> "failwith \"Value of LayoutOptions not supported by the generator.\""
        | :? Button.ButtonContentLayout as buttonContentLayout ->
            let positionName = getStringRepresentationOfDefaultValue buttonContentLayout.Position
            sprintf "Xamarin.Forms.Button.ButtonContentLayout(%s, %f)" positionName buttonContentLayout.Spacing
        | :? Rectangle as rectangle when rectangle = Rectangle.Zero -> "Xamarin.Forms.Rectangle.Zero"
        | :? Rectangle as rectangle -> sprintf "Xamarin.Forms.Rectangle(%0f, %0f, %0f, %0f)" rectangle.X rectangle.Y rectangle.Width rectangle.Height
        | :? Size as size when size.IsZero -> "Xamarin.Forms.Size.Zero"
        | _ -> Converters.getStringRepresentationOfDefaultValue defaultValue

