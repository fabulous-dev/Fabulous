namespace Fabulous.Maui.Attributes

open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Primitives
open Fabulous
open Fabulous.Maui

module Application =
    let Windows = MauiAttributes.defineCollection<Widget> "Application_Windows" "Windows"
    let ThemeChanged = MauiAttributes.defineEvent<unit> "Application_ThemeChanged"

module Window =
    let Activated = MauiAttributes.defineEvent<unit> "Window_Activated"
    let Created = MauiAttributes.defineEvent<unit> "Window_Created"
    let Deactivated = MauiAttributes.defineEvent<unit> "Window_Deactivated"
    let Destroying = MauiAttributes.defineEvent<unit> "Window_Destroying"
    let Resumed = MauiAttributes.defineEvent<unit> "Window_Resumed"
    let Stopped = MauiAttributes.defineEvent<unit> "Window_Stopped"
    let Title = MauiAttributes.define<string> "Window_Title" "Title" (fun () -> "")
    let Content = MauiAttributes.define<Widget voption> "Window_Content" "Content" (fun () -> ValueNone)

module Container =
    let Children = MauiAttributes.defineCollection<Widget> "Container_Children" "Children"

module Text =
    let Text = MauiAttributes.define<string> "Text_Text" "Text" (fun () -> "")

module TextStyle =
    let CharacterSpacing = MauiAttributes.define<float> "TextStyle_CharacterSpacing" "CharacterSpacing" (fun () -> 0.)
    let Font = MauiAttributes.define<Font> "TextStyle_Font" "Font" (fun () -> Font.Default)
    let TextColor = MauiAttributes.define<Color> "TextStyle_TextColor" "TextColor" (fun () -> null)

module Button =
    let Clicked = MauiAttributes.defineEvent<unit> "Button_Clicked"
    let Pressed = MauiAttributes.defineEvent<unit> "Button_Pressed"
    let Released = MauiAttributes.defineEvent<unit> "Button_Released"
    let ImageSource = MauiAttributes.define<IImageSource> "Button_ImageSource" "ImageSource" (fun () -> null)
    let ImageSourceLoaded = MauiAttributes.defineEvent<unit> "Button_ImageSourceLoaded"

module StackLayout =
    let Spacing = MauiAttributes.define<float> "StackLayout_Spacing" "Spacing" (fun () -> 0.)

module View =
    let AutomationId = MauiAttributes.define<string> "View_AutomationId" "AutomationId" (fun () -> null)
    let Background = MauiAttributes.define<Paint> "View_Background" "Background" (fun () -> null)
    let Clip = MauiAttributes.define<IShape> "View_Clip" "Clip" (fun () -> null)
    let FlowDirection = MauiAttributes.define<FlowDirection> "View_FlowDirection" "FlowDirection" (fun () -> FlowDirection.LeftToRight) // TODO: Why setting this one to MatchParent breaks the app? This is the default in MVVM MAUI...
    let Height = MauiAttributes.define<float> "View_Height" "Height" (fun () -> -1.)
    let HorizontalLayoutAlignment = MauiAttributes.define<LayoutAlignment> "View_HorizontalLayoutAlignment" "HorizontalLayoutAlignment" (fun () -> LayoutAlignment.Start)
    let IsEnabled = MauiAttributes.define<bool> "View_IsEnabled" "IsEnabled" (fun () -> true)
    let Margin = MauiAttributes.define<Thickness> "View_Margin" "Margin" (fun () -> Thickness.Zero)
    let MaximumHeight = MauiAttributes.define<float> "View_MaximumHeight" "MaximumHeight" (fun () -> -1.)
    let MaximumWidth = MauiAttributes.define<float> "View_MaximumWidth" "MaximumWidth" (fun () -> -1.)
    let MinimumHeight = MauiAttributes.define<float> "View_MinimumHeight" "MinimumHeight" (fun () -> -1.)
    let MinimumWidth = MauiAttributes.define<float> "View_MinimumWidth" "MinimumWidth" (fun () -> -1.)
    let Opacity = MauiAttributes.define<float> "View_Opacity" "Opacity" (fun () -> 1.)
    let Semantics = MauiAttributes.define<Semantics> "View_Semantics" "Semantics" (fun () -> null)
    let VerticalLayoutAlignment = MauiAttributes.define<LayoutAlignment> "View_VerticalLayoutAlignment" "VerticalLayoutAlignment" (fun () -> LayoutAlignment.Fill)
    let Visibility = MauiAttributes.define<Visibility> "View_Visibility" "Visibility" (fun () -> Visibility.Visible)
    let Width = MauiAttributes.define<float> "View_Width" "Width" (fun () -> -1.)

module Transform =
    let AnchorX = MauiAttributes.define<float> "Transform_AnchorX" "AnchorX" (fun () -> 0.5)
    let AnchorY = MauiAttributes.define<float> "Transform_AnchorY"  "AnchorY" (fun () -> 0.5)
    let Rotation = MauiAttributes.define<float> "Transform_Rotation" "Rotation" (fun () -> 0.)
    let RotationX = MauiAttributes.define<float> "Transform_RotationX" "RotationX" (fun () -> 0.)
    let RotationY = MauiAttributes.define<float> "Transform_RotationY" "RotationY" (fun () -> 0.)
    let Scale = MauiAttributes.define<float> "Transform_Scale" "Scale" (fun () -> 1.)
    let ScaleX = MauiAttributes.define<float> "Transform_ScaleX" "ScaleX" (fun () -> 1.)
    let ScaleY = MauiAttributes.define<float> "Transform_ScaleY" "ScaleY" (fun () -> 1.)
    let TranslationX = MauiAttributes.define<float> "Transform_TranslationX" "TranslationX" (fun () -> 0.)
    let TranslationY = MauiAttributes.define<float> "Transform_TranslationY" "TranslationY" (fun () -> 0.)

module Layout =
    let Padding = MauiAttributes.define<Thickness> "Layout_Padding" "Padding" (fun () -> Thickness.Zero)

module SafeAreaView =
    let IgnoreSafeArea = MauiAttributes.define<bool> "SafeAreaView_IgnoreSafeArea" "IgnoreSafeArea" (fun () -> false)

module Label =
    let LineBreakMode = MauiAttributes.define<LineBreakMode> "Label_LineBreakMode" "LineBreakMode" (fun () -> LineBreakMode.WordWrap)
    let LineHeight = MauiAttributes.define<float> "Label_LineHeight" "LineHeight" (fun () -> -1.)
    let MaxLines = MauiAttributes.define<int> "Label_MaxLines" "MaxLines" (fun () -> -1)
    let TextDecorations = MauiAttributes.define<TextDecorations> "Label_TextDecorations" "TextDecorations" (fun () -> TextDecorations.None)

module TextAlignment =
    let HorizontalTextAlignment = MauiAttributes.define<TextAlignment> "TextAlignment_HorizontalTextAlignment" "HorizontalTextAlignment" (fun () -> TextAlignment.Start)
    let VerticalTextAlignment = MauiAttributes.define<TextAlignment> "TextAlignment_VerticalTextAlignment" "VerticalTextAlignment" (fun () -> TextAlignment.Start)