module Fabulous.Maui.Attributes

open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Primitives
open Fabulous.Widgets.Controls
open Fabulous.Maui.Widgets

module Application =
    let Windows = Attributes.defineCollection<IWindowWidget> "Application_Windows"
    let ThemeChanged = Attributes.defineNoCompare<unit -> unit> "Application_ThemeChanged" (fun () -> ignore)

module Window =
    let Activated = Attributes.defineEvent<unit> "Window_Activated"
    let Created = Attributes.defineEvent<unit> "Window_Created"
    let Deactivated = Attributes.defineEvent<unit> "Window_Deactivated"
    let Destroying = Attributes.defineEvent<unit> "Window_Destroying"
    let Resumed = Attributes.defineEvent<unit> "Window_Resumed"
    let Stopped = Attributes.defineEvent<unit> "Window_Stopped"
    let Title = Attributes.define<string> "Window_Title" (fun () -> "")
    let Content = Attributes.define<IViewWidget voption> "Window_Content" (fun () -> ValueNone)

module Container =
    let Children = Attributes.defineCollection<IViewWidget> "Container_Children"

module Text =
    let Text = Attributes.define<string> "Text_Text" (fun () -> "")

module TextStyle =
    let CharacterSpacing = Attributes.define<float> "TextStyle_CharacterSpacing" (fun () -> 0.)
    let Font = Attributes.define<Font> "TextStyle_Font" (fun () -> Font.Default)
    let TextColor = Attributes.define<Color> "TextStyle_TextColor" (fun () -> null)

module Button =
    let Clicked = Attributes.defineEvent<unit> "Button_Clicked"
    let Pressed = Attributes.defineEvent<unit> "Button_Pressed"
    let Released = Attributes.defineEvent<unit> "Button_Released"
    let ImageSource = Attributes.define<IImageSource> "Button_ImageSource" (fun () -> null)
    let ImageSourceLoaded = Attributes.defineEvent<unit> "Button_ImageSourceLoaded"

module StackLayout =
    let Spacing = Attributes.define<float> "StackLayout_Spacing" (fun () -> 0.)

module View =
    let AutomationId = Attributes.define<string> "View_AutomationId" (fun () -> null)
    let Background = Attributes.define<Paint> "View_Background" (fun () -> null)
    let Clip = Attributes.define<IShape> "View_Clip" (fun () -> null)
    let FlowDirection = Attributes.define<FlowDirection> "View_FlowDirection" (fun () -> FlowDirection.LeftToRight) // TODO: Why setting this one to MatchParent breaks the app? This is the default in MVVM MAUI...
    let Height = Attributes.define<float> "View_Height" (fun () -> -1.)
    let HorizontalLayoutAlignment = Attributes.define<LayoutAlignment> "View_HorizontalLayoutAlignment" (fun () -> LayoutAlignment.Start)
    let IsEnabled = Attributes.define<bool> "View_IsEnabled" (fun () -> true)
    let Margin = Attributes.define<Thickness> "View_Margin" (fun () -> Thickness.Zero)
    let MaximumHeight = Attributes.define<float> "View_MaximumHeight" (fun () -> -1.)
    let MaximumWidth = Attributes.define<float> "View_MaximumWidth" (fun () -> -1.)
    let MinimumHeight = Attributes.define<float> "View_MinimumHeight" (fun () -> -1.)
    let MinimumWidth = Attributes.define<float> "View_MinimumWidth" (fun () -> -1.)
    let Opacity = Attributes.define<float> "View_Opacity" (fun () -> 1.)
    let Semantics = Attributes.define<Semantics> "View_Semantics" (fun () -> null)
    let VerticalLayoutAlignment = Attributes.define<LayoutAlignment> "View_VerticalLayoutAlignment" (fun () -> LayoutAlignment.Fill)
    let Visibility = Attributes.define<Visibility> "View_Visibility" (fun () -> Visibility.Visible)
    let Width = Attributes.define<float> "View_Width" (fun () -> -1.)

module Transform =
    let AnchorX = Attributes.define<float> "Transform_AnchorX" (fun () -> 0.5)
    let AnchorY = Attributes.define<float> "Transform_AnchorY" (fun () -> 0.5)
    let Rotation = Attributes.define<float> "Transform_Rotation" (fun () -> 0.)
    let RotationX = Attributes.define<float> "Transform_RotationX" (fun () -> 0.)
    let RotationY = Attributes.define<float> "Transform_RotationY" (fun () -> 0.)
    let Scale = Attributes.define<float> "Transform_Scale" (fun () -> 1.)
    let ScaleX = Attributes.define<float> "Transform_ScaleX" (fun () -> 1.)
    let ScaleY = Attributes.define<float> "Transform_ScaleY" (fun () -> 1.)
    let TranslationX = Attributes.define<float> "Transform_TranslationX" (fun () -> 0.)
    let TranslationY = Attributes.define<float> "Transform_TranslationY" (fun () -> 0.)

module Layout =
    let Padding = Attributes.define<Thickness> "Layout_Padding" (fun () -> Thickness.Zero)

module SafeAreaView =
    let IgnoreSafeArea = Attributes.define<bool> "SafeAreaView_IgnoreSafeArea" (fun () -> false)

module Label =
    let LineBreakMode = Attributes.define<LineBreakMode> "Label_LineBreakMode" (fun () -> LineBreakMode.WordWrap)
    let LineHeight = Attributes.define<float> "Label_LineHeight" (fun () -> -1.)
    let MaxLines = Attributes.define<int> "Label_MaxLines" (fun () -> -1)
    let TextDecorations = Attributes.define<TextDecorations> "Label_TextDecorations" (fun () -> TextDecorations.None)

module TextAlignment =
    let HorizontalTextAlignment = Attributes.define<TextAlignment> "TextAlignment_HorizontalTextAlignment" (fun () -> TextAlignment.Start)
    let VerticalTextAlignment = Attributes.define<TextAlignment> "TextAlignment_VerticalTextAlignment" (fun () -> TextAlignment.Start)