module Fabulous.Maui.Attributes

open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Primitives
open Fabulous.Controls
open Fabulous.Maui.Widgets
open System.Collections.Generic

module PropertyAttributes =
    let private _propertyAttributes = Dictionary<AttributeKey, string>()

    let tryGetMauiPropertyName (attr: Attribute) =
        match _propertyAttributes.TryGetValue(attr.Key) with
        | false, _ -> ValueNone
        | true, propertyName -> ValueSome propertyName

    let defineCollection<'T> debugName mauiPropertyName =
        let attr = Attributes.defineCollection<'T> debugName
        _propertyAttributes.[attr.Key] <- mauiPropertyName
        attr
    
    let define<'T when 'T : equality> debugName mauiPropertyName defaultValue =
        let attr = Attributes.define<'T> debugName defaultValue
        _propertyAttributes.[attr.Key] <- mauiPropertyName
        attr

module Application =
    let Windows = PropertyAttributes.defineCollection<IWindowWidget> "Application_Windows" "Windows"
    let ThemeChanged = Attributes.defineEvent<unit> "Application_ThemeChanged"

module Window =
    let Activated = Attributes.defineEvent<unit> "Window_Activated"
    let Created = Attributes.defineEvent<unit> "Window_Created"
    let Deactivated = Attributes.defineEvent<unit> "Window_Deactivated"
    let Destroying = Attributes.defineEvent<unit> "Window_Destroying"
    let Resumed = Attributes.defineEvent<unit> "Window_Resumed"
    let Stopped = Attributes.defineEvent<unit> "Window_Stopped"
    let Title = PropertyAttributes.define<string> "Window_Title" "Title" (fun () -> "")
    let Content = PropertyAttributes.define<IViewWidget voption> "Content" "Window_Content" (fun () -> ValueNone)

module Container =
    let Children = Attributes.defineCollection<IViewWidget> "Container_Children"

module Text =
    let Text = PropertyAttributes.define<string> "Text_Text" "Text" (fun () -> "")

module TextStyle =
    let CharacterSpacing = PropertyAttributes.define<float> "TextStyle_CharacterSpacing" "CharacterSpacing" (fun () -> 0.)
    let Font = PropertyAttributes.define<Font> "TextStyle_Font" "Font" (fun () -> Font.Default)
    let TextColor = PropertyAttributes.define<Color> "TextStyle_TextColor" "TextColor" (fun () -> null)

module Button =
    let Clicked = Attributes.defineEvent<unit> "Button_Clicked"
    let Pressed = Attributes.defineEvent<unit> "Button_Pressed"
    let Released = Attributes.defineEvent<unit> "Button_Released"
    let ImageSource = PropertyAttributes.define<IImageSource> "Button_ImageSource" "ImageSource" (fun () -> null)
    let ImageSourceLoaded = Attributes.defineEvent<unit> "Button_ImageSourceLoaded"

module StackLayout =
    let Spacing = PropertyAttributes.define<float> "StackLayout_Spacing" "Spacing" (fun () -> 0.)

module View =
    let AutomationId = PropertyAttributes.define<string> "View_AutomationId" "AutomationId" (fun () -> null)
    let Background = PropertyAttributes.define<Paint> "View_Background" "Background" (fun () -> null)
    let Clip = PropertyAttributes.define<IShape> "View_Clip" "Clip" (fun () -> null)
    let FlowDirection = PropertyAttributes.define<FlowDirection> "View_FlowDirection" "FlowDirection" (fun () -> FlowDirection.LeftToRight) // TODO: Why setting this one to MatchParent breaks the app? This is the default in MVVM MAUI...
    let Height = PropertyAttributes.define<float> "View_Height" "Height" (fun () -> -1.)
    let HorizontalLayoutAlignment = PropertyAttributes.define<LayoutAlignment> "View_HorizontalLayoutAlignment" "HorizontalLayoutAlignment" (fun () -> LayoutAlignment.Start)
    let IsEnabled = PropertyAttributes.define<bool> "View_IsEnabled" "IsEnabled" (fun () -> true)
    let Margin = PropertyAttributes.define<Thickness> "View_Margin" "Margin" (fun () -> Thickness.Zero)
    let MaximumHeight = PropertyAttributes.define<float> "View_MaximumHeight" "MaximumHeight" (fun () -> -1.)
    let MaximumWidth = PropertyAttributes.define<float> "View_MaximumWidth" "MaximumWidth" (fun () -> -1.)
    let MinimumHeight = PropertyAttributes.define<float> "View_MinimumHeight" "MinimumHeight" (fun () -> -1.)
    let MinimumWidth = PropertyAttributes.define<float> "View_MinimumWidth" "MinimumWidth" (fun () -> -1.)
    let Opacity = PropertyAttributes.define<float> "View_Opacity" "Opacity" (fun () -> 1.)
    let Semantics = PropertyAttributes.define<Semantics> "View_Semantics" "Semantics" (fun () -> null)
    let VerticalLayoutAlignment = PropertyAttributes.define<LayoutAlignment> "View_VerticalLayoutAlignment" "VerticalLayoutAlignment" (fun () -> LayoutAlignment.Fill)
    let Visibility = PropertyAttributes.define<Visibility> "View_Visibility" "Visibility" (fun () -> Visibility.Visible)
    let Width = PropertyAttributes.define<float> "View_Width" "Width" (fun () -> -1.)

module Transform =
    let AnchorX = PropertyAttributes.define<float> "Transform_AnchorX" "AnchorX" (fun () -> 0.5)
    let AnchorY = PropertyAttributes.define<float> "Transform_AnchorY"  "AnchorY" (fun () -> 0.5)
    let Rotation = PropertyAttributes.define<float> "Transform_Rotation" "Rotation" (fun () -> 0.)
    let RotationX = PropertyAttributes.define<float> "Transform_RotationX" "RotationX" (fun () -> 0.)
    let RotationY = PropertyAttributes.define<float> "Transform_RotationY" "RotationY" (fun () -> 0.)
    let Scale = PropertyAttributes.define<float> "Transform_Scale" "Scale" (fun () -> 1.)
    let ScaleX = PropertyAttributes.define<float> "Transform_ScaleX" "ScaleX" (fun () -> 1.)
    let ScaleY = PropertyAttributes.define<float> "Transform_ScaleY" "ScaleY" (fun () -> 1.)
    let TranslationX = PropertyAttributes.define<float> "Transform_TranslationX" "TranslationX" (fun () -> 0.)
    let TranslationY = PropertyAttributes.define<float> "Transform_TranslationY" "TranslationY" (fun () -> 0.)

module Layout =
    let Padding = PropertyAttributes.define<Thickness> "Layout_Padding" "Padding" (fun () -> Thickness.Zero)

module SafeAreaView =
    let IgnoreSafeArea = PropertyAttributes.define<bool> "SafeAreaView_IgnoreSafeArea" "IgnoreSafeArea" (fun () -> false)

module Label =
    let LineBreakMode = PropertyAttributes.define<LineBreakMode> "Label_LineBreakMode" "LineBreakMode" (fun () -> LineBreakMode.WordWrap)
    let LineHeight = PropertyAttributes.define<float> "Label_LineHeight" "LineHeight" (fun () -> -1.)
    let MaxLines = PropertyAttributes.define<int> "Label_MaxLines" "MaxLines" (fun () -> -1)
    let TextDecorations = PropertyAttributes.define<TextDecorations> "Label_TextDecorations" "TextDecorations" (fun () -> TextDecorations.None)

module TextAlignment =
    let HorizontalTextAlignment = PropertyAttributes.define<TextAlignment> "TextAlignment_HorizontalTextAlignment" "HorizontalTextAlignment" (fun () -> TextAlignment.Start)
    let VerticalTextAlignment = PropertyAttributes.define<TextAlignment> "TextAlignment_VerticalTextAlignment" "VerticalTextAlignment" (fun () -> TextAlignment.Start)