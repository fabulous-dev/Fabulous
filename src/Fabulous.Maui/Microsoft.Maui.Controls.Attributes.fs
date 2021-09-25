module Fabulous.Maui.Attributes

open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Primitives

module Application =
    let Windows = Attributes.createDefinitionWithConverter<IWindowWidget seq, _> "Application_Windows" (fun () -> Seq.empty) Seq.toArray
    let ThemeChanged = Attributes.createDefinition<unit -> unit> "Application_ThemeChanged" (fun () -> ignore)

module Window =
    let Activated = Attributes.createDefinition<unit -> unit> "Window_Activated" (fun () -> ignore)
    let Created = Attributes.createDefinition<unit -> unit> "Window_Created" (fun () -> ignore)
    let Deactivated = Attributes.createDefinition<unit -> unit> "Window_Deactivated" (fun () -> ignore)
    let Destroying = Attributes.createDefinition<unit -> unit> "Window_Destroying" (fun () -> ignore)
    let Resumed = Attributes.createDefinition<unit -> unit> "Window_Resumed" (fun () -> ignore)
    let Stopped = Attributes.createDefinition<unit -> unit> "Window_Stopped" (fun () -> ignore)
    let Title = Attributes.createDefinition<string> "Window_Title" (fun () -> "")
    let Content = Attributes.createDefinition<IViewWidget voption> "Window_Content" (fun () -> ValueNone)

module Container =
    let Children = Attributes.createDefinitionWithConverter<IViewWidget seq,_> "Container_Children" (fun () -> Seq.empty) Seq.toArray

module Text =
    let Text = Attributes.createDefinition<string> "Text_Text" (fun () -> "")

module TextStyle =
    let CharacterSpacing = Attributes.createDefinition<float> "TextStyle_CharacterSpacing" (fun () -> 0.)
    let Font = Attributes.createDefinition<Font> "TextStyle_Font" (fun () -> Font.Default)
    let TextColor = Attributes.createDefinition<Color> "TextStyle_TextColor" (fun () -> null)

module Button =
    let Clicked = Attributes.createDefinition<unit -> unit> "Button_Clicked" (fun () -> ignore)
    let Pressed = Attributes.createDefinition<unit -> unit> "Button_Pressed" (fun () -> ignore)
    let Released = Attributes.createDefinition<unit -> unit> "Button_Released" (fun () -> ignore)
    let ImageSource = Attributes.createDefinition<IImageSource> "Button_ImageSource" (fun () -> null)
    let ImageSourceLoaded = Attributes.createDefinition<unit -> unit> "Button_ImageSourceLoaded" (fun () -> ignore)

module StackLayout =
    let Spacing = Attributes.createDefinition<float> "StackLayout_Spacing" (fun () -> 0.)

module View =
    let AutomationId = Attributes.createDefinition<string> "View_AutomationId" (fun () -> "")
    let Background = Attributes.createDefinition<Paint> "View_Background" (fun () -> null)
    let Clip = Attributes.createDefinition<IShape> "View_Clip" (fun () -> null)
    let FlowDirection = Attributes.createDefinition<FlowDirection> "View_FlowDirection" (fun () -> FlowDirection.MatchParent)
    let Height = Attributes.createDefinition<float> "View_Height" (fun () -> -1.)
    let HorizontalLayoutAlignment = Attributes.createDefinition<LayoutAlignment> "View_HorizontalLayountAlignment" (fun () -> LayoutAlignment.Start)
    let IsEnabled = Attributes.createDefinition<bool> "View_IsEnabled" (fun () -> true)
    let Margin = Attributes.createDefinition<Thickness> "View_Margin" (fun () -> Thickness.Zero)
    let MaximumHeight = Attributes.createDefinition<float> "View_MaximumHeight" (fun () -> -1.)
    let MaximumWidth = Attributes.createDefinition<float> "View_MaximumWidth" (fun () -> -1.)
    let MinimumHeight = Attributes.createDefinition<float> "View_MinimumHeight" (fun () -> -1.)
    let MinimumWidth = Attributes.createDefinition<float> "View_MinimumWidth" (fun () -> -1.)
    let Opacity = Attributes.createDefinition<float> "View_Opacity" (fun () -> 1.)
    let Semantics = Attributes.createDefinition<Semantics> "View_Semantics" (fun () -> null)
    let VerticalLayoutAlignment = Attributes.createDefinition<LayoutAlignment> "View_VerticalLayoutAlignment" (fun () -> LayoutAlignment.Fill)
    let Visibility = Attributes.createDefinition<Visibility> "View_Visibility" (fun () -> Visibility.Visible)
    let Width = Attributes.createDefinition<float> "View_Width" (fun () -> -1.)

module Transform =
    let AnchorX = Attributes.createDefinition<float> "Transform_AnchorX" (fun () -> 0.5)
    let AnchorY = Attributes.createDefinition<float> "Transform_AnchorY" (fun () -> 0.5)
    let Rotation = Attributes.createDefinition<float> "Transform_Rotation" (fun () -> 0.)
    let RotationX = Attributes.createDefinition<float> "Transform_RotationX" (fun () -> 0.)
    let RotationY = Attributes.createDefinition<float> "Transform_RotationY" (fun () -> 0.)
    let Scale = Attributes.createDefinition<float> "Transform_Scale" (fun () -> 1.)
    let ScaleX = Attributes.createDefinition<float> "Transform_ScaleX" (fun () -> 1.)
    let ScaleY = Attributes.createDefinition<float> "Transform_ScaleY" (fun () -> 1.)
    let TranslationX = Attributes.createDefinition<float> "Transform_TranslationX" (fun () -> 0.)
    let TranslationY = Attributes.createDefinition<float> "Transform_TranslationY" (fun () -> 0.)

module Layout =
    let Padding = Attributes.createDefinition<Thickness> "Layout_Padding" (fun () -> Thickness.Zero)

module SafeAreaView =
    let IgnoreSafeArea = Attributes.createDefinition<bool> "SafeAreaView_IgnoreSafeArea" (fun () -> false)

module Label =
    let LineBreakMode = Attributes.createDefinition<LineBreakMode> "Label_LineBreakMode" (fun () -> LineBreakMode.WordWrap)
    let LineHeight = Attributes.createDefinition<float> "Label_LineHeight" (fun () -> -1.)
    let MaxLines = Attributes.createDefinition<int> "Label_MaxLines" (fun () -> -1)
    let TextDecorations = Attributes.createDefinition<TextDecorations> "Label_TextDecorations" (fun () -> TextDecorations.None)

module TextAlignment =
    let HorizontalTextAlignment = Attributes.createDefinition<TextAlignment> "TextAlignment_HorizontalTextAlignment" (fun () -> TextAlignment.Start)
    let VerticalTextAlignment = Attributes.createDefinition<TextAlignment> "TextAlignment_VerticalTextAlignment" (fun () -> TextAlignment.Start)