namespace Elmish.XamarinForms.DynamicViews

#nowarn "67" // cast always holds

open System
open System.Diagnostics

/// A description of a visual element
[<AllowNullLiteral>]
type XamlElement(targetType: Type, create: (unit -> obj), apply: (XamlElement option -> XamlElement -> obj -> unit), attribs: Map<string, obj>) = 

    /// Get the type created by the visual element
    member x.TargetType = targetType

    /// Get the attributes of the visual element
    [<DebuggerBrowsable(DebuggerBrowsableState.RootHidden)>]
    member x.Attributes = attribs

    /// Apply the description to a visual element
    member x.Apply (target: obj) = apply None x target

    /// Apply a different description to a similar visual element
    [<DebuggerBrowsable(DebuggerBrowsableState.Never)>]
    member x.ApplyMethod = apply

    /// Incrementally apply a description to a visual element
    member x.ApplyIncremental(prev: XamlElement, target: obj) = apply (Some prev) x target

    /// Apply a different description to a similar visual element
    [<DebuggerBrowsable(DebuggerBrowsableState.Never)>]
    member x.CreateMethod = create

    /// Produce a new visual element with an adjusted attribute
    member x.WithAttribute(name: string, value: obj) = XamlElement(targetType, create, apply, x.Attributes.Add(name, value))

    /// Produce a visual element from a visual element for a different type
    member x.Inherit(newTargetType, newCreate, newApply, newAttribs) = 
        let combinedAttribs = Map.ofArray(Array.append(Map.toArray attribs) newAttribs)
        XamlElement(newTargetType, newCreate, (fun prevOpt source target -> apply prevOpt source target; newApply prevOpt source target), combinedAttribs)

    /// Produce a new visual element with an adjusted attribute
[<AutoOpen>]
module XamlElementExtensions = 

    type XamlElement with
        /// Create the UI element from the view description
        member x.Create() : obj =
            let target = x.CreateMethod()
            x.Apply(target)
            target

        /// Create a Xamarin.Forms.Element from the view description
        member x.CreateAsElement() : Xamarin.Forms.Element = (x.Create() :?> Xamarin.Forms.Element)

        /// Create a Xamarin.Forms.VisualElement from the view description
        member x.CreateAsVisualElement() : Xamarin.Forms.VisualElement = (x.Create() :?> Xamarin.Forms.VisualElement)

        /// Create a Xamarin.Forms.View from the view description
        member x.CreateAsView() : Xamarin.Forms.View = (x.Create() :?> Xamarin.Forms.View)

        /// Create a Xamarin.Forms.BoxView from the view description
        member x.CreateAsBoxView() : Xamarin.Forms.BoxView = (x.Create() :?> Xamarin.Forms.BoxView)

        /// Create a Xamarin.Forms.Button from the view description
        member x.CreateAsButton() : Xamarin.Forms.Button = (x.Create() :?> Xamarin.Forms.Button)

        /// Create a Xamarin.Forms.ContentView from the view description
        member x.CreateAsContentView() : Xamarin.Forms.ContentView = (x.Create() :?> Xamarin.Forms.ContentView)

        /// Create a Xamarin.Forms.TemplatedView from the view description
        member x.CreateAsTemplatedView() : Xamarin.Forms.TemplatedView = (x.Create() :?> Xamarin.Forms.TemplatedView)

        /// Create a Xamarin.Forms.DatePicker from the view description
        member x.CreateAsDatePicker() : Xamarin.Forms.DatePicker = (x.Create() :?> Xamarin.Forms.DatePicker)

        /// Create a Xamarin.Forms.Frame from the view description
        member x.CreateAsFrame() : Xamarin.Forms.Frame = (x.Create() :?> Xamarin.Forms.Frame)

        /// Create a Xamarin.Forms.Image from the view description
        member x.CreateAsImage() : Xamarin.Forms.Image = (x.Create() :?> Xamarin.Forms.Image)

        /// Create a Xamarin.Forms.InputView from the view description
        member x.CreateAsInputView() : Xamarin.Forms.InputView = (x.Create() :?> Xamarin.Forms.InputView)

        /// Create a Xamarin.Forms.Editor from the view description
        member x.CreateAsEditor() : Xamarin.Forms.Editor = (x.Create() :?> Xamarin.Forms.Editor)

        /// Create a Xamarin.Forms.Entry from the view description
        member x.CreateAsEntry() : Xamarin.Forms.Entry = (x.Create() :?> Xamarin.Forms.Entry)

        /// Create a Xamarin.Forms.Label from the view description
        member x.CreateAsLabel() : Xamarin.Forms.Label = (x.Create() :?> Xamarin.Forms.Label)

        /// Create a Xamarin.Forms.Layout from the view description
        member x.CreateAsLayout() : Xamarin.Forms.Layout = (x.Create() :?> Xamarin.Forms.Layout)

        /// Create a Xamarin.Forms.StackLayout from the view description
        member x.CreateAsStackLayout() : Xamarin.Forms.StackLayout = (x.Create() :?> Xamarin.Forms.StackLayout)

        /// Create a Xamarin.Forms.TimePicker from the view description
        member x.CreateAsTimePicker() : Xamarin.Forms.TimePicker = (x.Create() :?> Xamarin.Forms.TimePicker)

        /// Create a Xamarin.Forms.WebView from the view description
        member x.CreateAsWebView() : Xamarin.Forms.WebView = (x.Create() :?> Xamarin.Forms.WebView)

        /// Create a Xamarin.Forms.Page from the view description
        member x.CreateAsPage() : Xamarin.Forms.Page = (x.Create() :?> Xamarin.Forms.Page)

        /// Create a Xamarin.Forms.CarouselPage from the view description
        member x.CreateAsCarouselPage() : Xamarin.Forms.CarouselPage = (x.Create() :?> Xamarin.Forms.CarouselPage)

        /// Create a Xamarin.Forms.ContentPage from the view description
        member x.CreateAsContentPage() : Xamarin.Forms.ContentPage = (x.Create() :?> Xamarin.Forms.ContentPage)

        /// Create a Xamarin.Forms.MasterDetailPage from the view description
        member x.CreateAsMasterDetailPage() : Xamarin.Forms.MasterDetailPage = (x.Create() :?> Xamarin.Forms.MasterDetailPage)

        /// Create a Xamarin.Forms.TabbedPage from the view description
        member x.CreateAsTabbedPage() : Xamarin.Forms.TabbedPage = (x.Create() :?> Xamarin.Forms.TabbedPage)

        /// Create a Xamarin.Forms.Cell from the view description
        member x.CreateAsCell() : Xamarin.Forms.Cell = (x.Create() :?> Xamarin.Forms.Cell)

        /// Create a Xamarin.Forms.TextCell from the view description
        member x.CreateAsTextCell() : Xamarin.Forms.TextCell = (x.Create() :?> Xamarin.Forms.TextCell)

        /// Create a Xamarin.Forms.ImageCell from the view description
        member x.CreateAsImageCell() : Xamarin.Forms.ImageCell = (x.Create() :?> Xamarin.Forms.ImageCell)

        /// Create a Xamarin.Forms.ViewCell from the view description
        member x.CreateAsViewCell() : Xamarin.Forms.ViewCell = (x.Create() :?> Xamarin.Forms.ViewCell)

        /// Create a Xamarin.Forms.ListView from the view description
        member x.CreateAsListView() : Xamarin.Forms.ListView = (x.Create() :?> Xamarin.Forms.ListView)

        /// Get the BackgroundColor property in the visual element
        member x.BackgroundColor = match x.Attributes.TryFind("BackgroundColor") with Some v -> unbox<Xamarin.Forms.Color>(v) | None -> Xamarin.Forms.Color.Default

        /// Get the IsVisible property in the visual element
        member x.IsVisible = match x.Attributes.TryFind("IsVisible") with Some v -> unbox<bool>(v) | None -> true

        /// Get the Opacity property in the visual element
        member x.Opacity = match x.Attributes.TryFind("Opacity") with Some v -> unbox<double>(v) | None -> 1.0

        /// Get the WidthRequest property in the visual element
        member x.WidthRequest = match x.Attributes.TryFind("WidthRequest") with Some v -> unbox<double>(v) | None -> -1.0

        /// Get the HeightRequest property in the visual element
        member x.HeightRequest = match x.Attributes.TryFind("HeightRequest") with Some v -> unbox<double>(v) | None -> -1.0

        /// Get the IsEnabled property in the visual element
        member x.IsEnabled = match x.Attributes.TryFind("IsEnabled") with Some v -> unbox<bool>(v) | None -> true

        /// Get the HorizontalOptions property in the visual element
        member x.HorizontalOptions = match x.Attributes.TryFind("HorizontalOptions") with Some v -> unbox<Xamarin.Forms.LayoutOptions>(v) | None -> Unchecked.defaultof<Xamarin.Forms.LayoutOptions>

        /// Get the VerticalOptions property in the visual element
        member x.VerticalOptions = match x.Attributes.TryFind("VerticalOptions") with Some v -> unbox<Xamarin.Forms.LayoutOptions>(v) | None -> Unchecked.defaultof<Xamarin.Forms.LayoutOptions>

        /// Get the Margin property in the visual element
        member x.Margin = match x.Attributes.TryFind("Margin") with Some v -> unbox<Xamarin.Forms.Thickness>(v) | None -> Unchecked.defaultof<Xamarin.Forms.Thickness>

        /// Get the Color property in the visual element
        member x.Color = match x.Attributes.TryFind("Color") with Some v -> unbox<Xamarin.Forms.Color>(v) | None -> Xamarin.Forms.Color.Default

        /// Get the Text property in the visual element
        member x.Text = match x.Attributes.TryFind("Text") with Some v -> unbox<string>(v) | None -> null

        /// Get the Command property in the visual element
        member x.Command = match x.Attributes.TryFind("Command") with Some v -> unbox<System.Windows.Input.ICommand>(v) | None -> null

        /// Get the CommandParameter property in the visual element
        member x.CommandParameter = match x.Attributes.TryFind("CommandParameter") with Some v -> unbox<System.Object>(v) | None -> null

        /// Get the ContentLayout property in the visual element
        member x.ContentLayout = match x.Attributes.TryFind("ContentLayout") with Some v -> unbox<Xamarin.Forms.Button.ButtonContentLayout>(v) | None -> null

        /// Get the FontSize property in the visual element
        member x.FontSize = match x.Attributes.TryFind("FontSize") with Some v -> unbox<double>(v) | None -> -1.0

        /// Get the FontFamily property in the visual element
        member x.FontFamily = match x.Attributes.TryFind("FontFamily") with Some v -> unbox<string>(v) | None -> null

        /// Get the FontAttributes property in the visual element
        member x.FontAttributes = match x.Attributes.TryFind("FontAttributes") with Some v -> unbox<Xamarin.Forms.FontAttributes>(v) | None -> Xamarin.Forms.FontAttributes.None

        /// Get the BorderWidth property in the visual element
        member x.BorderWidth = match x.Attributes.TryFind("BorderWidth") with Some v -> unbox<double>(v) | None -> -1.0

        /// Get the BorderColor property in the visual element
        member x.BorderColor = match x.Attributes.TryFind("BorderColor") with Some v -> unbox<Xamarin.Forms.Color>(v) | None -> Xamarin.Forms.Color.Default

        /// Get the Content property in the visual element
        member x.Content = match x.Attributes.TryFind("Content") with Some v -> unbox<XamlElement>(v) | None -> null

        /// Get the Date property in the visual element
        member x.Date = match x.Attributes.TryFind("Date") with Some v -> unbox<System.DateTime>(v) | None -> Unchecked.defaultof<System.DateTime>

        /// Get the Format property in the visual element
        member x.Format = match x.Attributes.TryFind("Format") with Some v -> unbox<string>(v) | None -> "d"

        /// Get the MinimumDate property in the visual element
        member x.MinimumDate = match x.Attributes.TryFind("MinimumDate") with Some v -> unbox<System.DateTime>(v) | None -> new System.DateTime(1900, 1, 1)

        /// Get the MaximumDate property in the visual element
        member x.MaximumDate = match x.Attributes.TryFind("MaximumDate") with Some v -> unbox<System.DateTime>(v) | None -> new System.DateTime(2100, 12, 31)

        /// Get the OutlineColor property in the visual element
        member x.OutlineColor = match x.Attributes.TryFind("OutlineColor") with Some v -> unbox<Xamarin.Forms.Color>(v) | None -> Xamarin.Forms.Color.Default

        /// Get the CornerRadius property in the visual element
        member x.CornerRadius = match x.Attributes.TryFind("CornerRadius") with Some v -> unbox<single>(v) | None -> -1.0f

        /// Get the HasShadow property in the visual element
        member x.HasShadow = match x.Attributes.TryFind("HasShadow") with Some v -> unbox<bool>(v) | None -> true

        /// Get the ImageSource property in the visual element
        member x.ImageSource = match x.Attributes.TryFind("ImageSource") with Some v -> unbox<Xamarin.Forms.ImageSource>(v) | None -> null

        /// Get the Aspect property in the visual element
        member x.Aspect = match x.Attributes.TryFind("Aspect") with Some v -> unbox<Xamarin.Forms.Aspect>(v) | None -> Xamarin.Forms.Aspect.AspectFit

        /// Get the IsOpaque property in the visual element
        member x.IsOpaque = match x.Attributes.TryFind("IsOpaque") with Some v -> unbox<bool>(v) | None -> true

        /// Get the Keyboard property in the visual element
        member x.Keyboard = match x.Attributes.TryFind("Keyboard") with Some v -> unbox<Xamarin.Forms.Keyboard>(v) | None -> Xamarin.Forms.Keyboard.Default

        /// Get the TextColor property in the visual element
        member x.TextColor = match x.Attributes.TryFind("TextColor") with Some v -> unbox<Xamarin.Forms.Color>(v) | None -> Xamarin.Forms.Color.Default

        /// Get the Placeholder property in the visual element
        member x.Placeholder = match x.Attributes.TryFind("Placeholder") with Some v -> unbox<string>(v) | None -> null

        /// Get the HorizontalTextAlignment property in the visual element
        member x.HorizontalTextAlignment = match x.Attributes.TryFind("HorizontalTextAlignment") with Some v -> unbox<Xamarin.Forms.TextAlignment>(v) | None -> Xamarin.Forms.TextAlignment.Start

        /// Get the PlaceholderColor property in the visual element
        member x.PlaceholderColor = match x.Attributes.TryFind("PlaceholderColor") with Some v -> unbox<Xamarin.Forms.Color>(v) | None -> Xamarin.Forms.Color.Default

        /// Get the IsPassword property in the visual element
        member x.IsPassword = match x.Attributes.TryFind("IsPassword") with Some v -> unbox<bool>(v) | None -> false

        /// Get the VerticalTextAlignment property in the visual element
        member x.VerticalTextAlignment = match x.Attributes.TryFind("VerticalTextAlignment") with Some v -> unbox<Xamarin.Forms.TextAlignment>(v) | None -> Xamarin.Forms.TextAlignment.Start

        /// Get the IsClippedToBounds property in the visual element
        member x.IsClippedToBounds = match x.Attributes.TryFind("IsClippedToBounds") with Some v -> unbox<bool>(v) | None -> false

        /// Get the Padding property in the visual element
        member x.Padding = match x.Attributes.TryFind("Padding") with Some v -> unbox<Xamarin.Forms.Thickness>(v) | None -> Unchecked.defaultof<Xamarin.Forms.Thickness>

        /// Get the Children property in the visual element
        member x.Children = match x.Attributes.TryFind("Children") with Some v -> unbox<System.Collections.Generic.IList<XamlElement>>(v) | None -> null

        /// Get the Orientation property in the visual element
        member x.Orientation = match x.Attributes.TryFind("Orientation") with Some v -> unbox<Xamarin.Forms.StackOrientation>(v) | None -> Xamarin.Forms.StackOrientation.Vertical

        /// Get the Spacing property in the visual element
        member x.Spacing = match x.Attributes.TryFind("Spacing") with Some v -> unbox<double>(v) | None -> 6.0

        /// Get the Time property in the visual element
        member x.Time = match x.Attributes.TryFind("Time") with Some v -> unbox<System.TimeSpan>(v) | None -> new System.TimeSpan()

        /// Get the WebSource property in the visual element
        member x.WebSource = match x.Attributes.TryFind("WebSource") with Some v -> unbox<Xamarin.Forms.WebViewSource>(v) | None -> null

        /// Get the Title property in the visual element
        member x.Title = match x.Attributes.TryFind("Title") with Some v -> unbox<string>(v) | None -> ""

        /// Get the ItemsSource property in the visual element
        member x.ItemsSource = match x.Attributes.TryFind("ItemsSource") with Some v -> unbox<System.Collections.IEnumerable>(v) | None -> null

        /// Get the ItemTemplate property in the visual element
        member x.ItemTemplate = match x.Attributes.TryFind("ItemTemplate") with Some v -> unbox<Xamarin.Forms.DataTemplate>(v) | None -> null

        /// Get the SelectedItem property in the visual element
        member x.SelectedItem = match x.Attributes.TryFind("SelectedItem") with Some v -> unbox<System.Object>(v) | None -> null

        /// Get the CurrentPage property in the visual element
        member x.CurrentPage = match x.Attributes.TryFind("CurrentPage") with Some v -> unbox<XamlElement>(v) | None -> null

        /// Get the Master property in the visual element
        member x.Master = match x.Attributes.TryFind("Master") with Some v -> unbox<XamlElement>(v) | None -> null

        /// Get the Detail property in the visual element
        member x.Detail = match x.Attributes.TryFind("Detail") with Some v -> unbox<XamlElement>(v) | None -> null

        /// Get the Height property in the visual element
        member x.Height = match x.Attributes.TryFind("Height") with Some v -> unbox<double>(v) | None -> -1.0

        /// Get the TextDetail property in the visual element
        member x.TextDetail = match x.Attributes.TryFind("TextDetail") with Some v -> unbox<string>(v) | None -> null

        /// Get the TextDetailColor property in the visual element
        member x.TextDetailColor = match x.Attributes.TryFind("TextDetailColor") with Some v -> unbox<Xamarin.Forms.Color>(v) | None -> Xamarin.Forms.Color.Default

        /// Get the View property in the visual element
        member x.View = match x.Attributes.TryFind("View") with Some v -> unbox<XamlElement>(v) | None -> null

        /// Get the SeparatorVisibility property in the visual element
        member x.SeparatorVisibility = match x.Attributes.TryFind("SeparatorVisibility") with Some v -> unbox<Xamarin.Forms.SeparatorVisibility>(v) | None -> Xamarin.Forms.SeparatorVisibility.Default

        /// Get the SeparatorColor property in the visual element
        member x.SeparatorColor = match x.Attributes.TryFind("SeparatorColor") with Some v -> unbox<Xamarin.Forms.Color>(v) | None -> Xamarin.Forms.Color.Default

        /// Get the HasUnevenRows property in the visual element
        member x.HasUnevenRows = match x.Attributes.TryFind("HasUnevenRows") with Some v -> unbox<bool>(v) | None -> false

        /// Get the RowHeight property in the visual element
        member x.RowHeight = match x.Attributes.TryFind("RowHeight") with Some v -> unbox<int>(v) | None -> -1

        /// Try to get the BackgroundColor property in the visual element
        member x.TryBackgroundColor = match x.Attributes.TryFind("BackgroundColor") with Some v -> Some(unbox<Xamarin.Forms.Color>(v)) | None -> None

        /// Try to get the IsVisible property in the visual element
        member x.TryIsVisible = match x.Attributes.TryFind("IsVisible") with Some v -> Some(unbox<bool>(v)) | None -> None

        /// Try to get the Opacity property in the visual element
        member x.TryOpacity = match x.Attributes.TryFind("Opacity") with Some v -> Some(unbox<double>(v)) | None -> None

        /// Try to get the WidthRequest property in the visual element
        member x.TryWidthRequest = match x.Attributes.TryFind("WidthRequest") with Some v -> Some(unbox<double>(v)) | None -> None

        /// Try to get the HeightRequest property in the visual element
        member x.TryHeightRequest = match x.Attributes.TryFind("HeightRequest") with Some v -> Some(unbox<double>(v)) | None -> None

        /// Try to get the IsEnabled property in the visual element
        member x.TryIsEnabled = match x.Attributes.TryFind("IsEnabled") with Some v -> Some(unbox<bool>(v)) | None -> None

        /// Try to get the HorizontalOptions property in the visual element
        member x.TryHorizontalOptions = match x.Attributes.TryFind("HorizontalOptions") with Some v -> Some(unbox<Xamarin.Forms.LayoutOptions>(v)) | None -> None

        /// Try to get the VerticalOptions property in the visual element
        member x.TryVerticalOptions = match x.Attributes.TryFind("VerticalOptions") with Some v -> Some(unbox<Xamarin.Forms.LayoutOptions>(v)) | None -> None

        /// Try to get the Margin property in the visual element
        member x.TryMargin = match x.Attributes.TryFind("Margin") with Some v -> Some(unbox<Xamarin.Forms.Thickness>(v)) | None -> None

        /// Try to get the Color property in the visual element
        member x.TryColor = match x.Attributes.TryFind("Color") with Some v -> Some(unbox<Xamarin.Forms.Color>(v)) | None -> None

        /// Try to get the Text property in the visual element
        member x.TryText = match x.Attributes.TryFind("Text") with Some v -> Some(unbox<string>(v)) | None -> None

        /// Try to get the Command property in the visual element
        member x.TryCommand = match x.Attributes.TryFind("Command") with Some v -> Some(unbox<System.Windows.Input.ICommand>(v)) | None -> None

        /// Try to get the CommandParameter property in the visual element
        member x.TryCommandParameter = match x.Attributes.TryFind("CommandParameter") with Some v -> Some(unbox<System.Object>(v)) | None -> None

        /// Try to get the ContentLayout property in the visual element
        member x.TryContentLayout = match x.Attributes.TryFind("ContentLayout") with Some v -> Some(unbox<Xamarin.Forms.Button.ButtonContentLayout>(v)) | None -> None

        /// Try to get the FontSize property in the visual element
        member x.TryFontSize = match x.Attributes.TryFind("FontSize") with Some v -> Some(unbox<double>(v)) | None -> None

        /// Try to get the FontFamily property in the visual element
        member x.TryFontFamily = match x.Attributes.TryFind("FontFamily") with Some v -> Some(unbox<string>(v)) | None -> None

        /// Try to get the FontAttributes property in the visual element
        member x.TryFontAttributes = match x.Attributes.TryFind("FontAttributes") with Some v -> Some(unbox<Xamarin.Forms.FontAttributes>(v)) | None -> None

        /// Try to get the BorderWidth property in the visual element
        member x.TryBorderWidth = match x.Attributes.TryFind("BorderWidth") with Some v -> Some(unbox<double>(v)) | None -> None

        /// Try to get the BorderColor property in the visual element
        member x.TryBorderColor = match x.Attributes.TryFind("BorderColor") with Some v -> Some(unbox<Xamarin.Forms.Color>(v)) | None -> None

        /// Try to get the Content property in the visual element
        member x.TryContent = match x.Attributes.TryFind("Content") with Some v -> Some(unbox<XamlElement>(v)) | None -> None

        /// Try to get the Date property in the visual element
        member x.TryDate = match x.Attributes.TryFind("Date") with Some v -> Some(unbox<System.DateTime>(v)) | None -> None

        /// Try to get the Format property in the visual element
        member x.TryFormat = match x.Attributes.TryFind("Format") with Some v -> Some(unbox<string>(v)) | None -> None

        /// Try to get the MinimumDate property in the visual element
        member x.TryMinimumDate = match x.Attributes.TryFind("MinimumDate") with Some v -> Some(unbox<System.DateTime>(v)) | None -> None

        /// Try to get the MaximumDate property in the visual element
        member x.TryMaximumDate = match x.Attributes.TryFind("MaximumDate") with Some v -> Some(unbox<System.DateTime>(v)) | None -> None

        /// Try to get the OutlineColor property in the visual element
        member x.TryOutlineColor = match x.Attributes.TryFind("OutlineColor") with Some v -> Some(unbox<Xamarin.Forms.Color>(v)) | None -> None

        /// Try to get the CornerRadius property in the visual element
        member x.TryCornerRadius = match x.Attributes.TryFind("CornerRadius") with Some v -> Some(unbox<single>(v)) | None -> None

        /// Try to get the HasShadow property in the visual element
        member x.TryHasShadow = match x.Attributes.TryFind("HasShadow") with Some v -> Some(unbox<bool>(v)) | None -> None

        /// Try to get the ImageSource property in the visual element
        member x.TryImageSource = match x.Attributes.TryFind("ImageSource") with Some v -> Some(unbox<Xamarin.Forms.ImageSource>(v)) | None -> None

        /// Try to get the Aspect property in the visual element
        member x.TryAspect = match x.Attributes.TryFind("Aspect") with Some v -> Some(unbox<Xamarin.Forms.Aspect>(v)) | None -> None

        /// Try to get the IsOpaque property in the visual element
        member x.TryIsOpaque = match x.Attributes.TryFind("IsOpaque") with Some v -> Some(unbox<bool>(v)) | None -> None

        /// Try to get the Keyboard property in the visual element
        member x.TryKeyboard = match x.Attributes.TryFind("Keyboard") with Some v -> Some(unbox<Xamarin.Forms.Keyboard>(v)) | None -> None

        /// Try to get the TextColor property in the visual element
        member x.TryTextColor = match x.Attributes.TryFind("TextColor") with Some v -> Some(unbox<Xamarin.Forms.Color>(v)) | None -> None

        /// Try to get the Placeholder property in the visual element
        member x.TryPlaceholder = match x.Attributes.TryFind("Placeholder") with Some v -> Some(unbox<string>(v)) | None -> None

        /// Try to get the HorizontalTextAlignment property in the visual element
        member x.TryHorizontalTextAlignment = match x.Attributes.TryFind("HorizontalTextAlignment") with Some v -> Some(unbox<Xamarin.Forms.TextAlignment>(v)) | None -> None

        /// Try to get the PlaceholderColor property in the visual element
        member x.TryPlaceholderColor = match x.Attributes.TryFind("PlaceholderColor") with Some v -> Some(unbox<Xamarin.Forms.Color>(v)) | None -> None

        /// Try to get the IsPassword property in the visual element
        member x.TryIsPassword = match x.Attributes.TryFind("IsPassword") with Some v -> Some(unbox<bool>(v)) | None -> None

        /// Try to get the VerticalTextAlignment property in the visual element
        member x.TryVerticalTextAlignment = match x.Attributes.TryFind("VerticalTextAlignment") with Some v -> Some(unbox<Xamarin.Forms.TextAlignment>(v)) | None -> None

        /// Try to get the IsClippedToBounds property in the visual element
        member x.TryIsClippedToBounds = match x.Attributes.TryFind("IsClippedToBounds") with Some v -> Some(unbox<bool>(v)) | None -> None

        /// Try to get the Padding property in the visual element
        member x.TryPadding = match x.Attributes.TryFind("Padding") with Some v -> Some(unbox<Xamarin.Forms.Thickness>(v)) | None -> None

        /// Try to get the Children property in the visual element
        member x.TryChildren = match x.Attributes.TryFind("Children") with Some v -> Some(unbox<System.Collections.Generic.IList<XamlElement>>(v)) | None -> None

        /// Try to get the Orientation property in the visual element
        member x.TryOrientation = match x.Attributes.TryFind("Orientation") with Some v -> Some(unbox<Xamarin.Forms.StackOrientation>(v)) | None -> None

        /// Try to get the Spacing property in the visual element
        member x.TrySpacing = match x.Attributes.TryFind("Spacing") with Some v -> Some(unbox<double>(v)) | None -> None

        /// Try to get the Time property in the visual element
        member x.TryTime = match x.Attributes.TryFind("Time") with Some v -> Some(unbox<System.TimeSpan>(v)) | None -> None

        /// Try to get the WebSource property in the visual element
        member x.TryWebSource = match x.Attributes.TryFind("WebSource") with Some v -> Some(unbox<Xamarin.Forms.WebViewSource>(v)) | None -> None

        /// Try to get the Title property in the visual element
        member x.TryTitle = match x.Attributes.TryFind("Title") with Some v -> Some(unbox<string>(v)) | None -> None

        /// Try to get the ItemsSource property in the visual element
        member x.TryItemsSource = match x.Attributes.TryFind("ItemsSource") with Some v -> Some(unbox<System.Collections.IEnumerable>(v)) | None -> None

        /// Try to get the ItemTemplate property in the visual element
        member x.TryItemTemplate = match x.Attributes.TryFind("ItemTemplate") with Some v -> Some(unbox<Xamarin.Forms.DataTemplate>(v)) | None -> None

        /// Try to get the SelectedItem property in the visual element
        member x.TrySelectedItem = match x.Attributes.TryFind("SelectedItem") with Some v -> Some(unbox<System.Object>(v)) | None -> None

        /// Try to get the CurrentPage property in the visual element
        member x.TryCurrentPage = match x.Attributes.TryFind("CurrentPage") with Some v -> Some(unbox<XamlElement>(v)) | None -> None

        /// Try to get the Master property in the visual element
        member x.TryMaster = match x.Attributes.TryFind("Master") with Some v -> Some(unbox<XamlElement>(v)) | None -> None

        /// Try to get the Detail property in the visual element
        member x.TryDetail = match x.Attributes.TryFind("Detail") with Some v -> Some(unbox<XamlElement>(v)) | None -> None

        /// Try to get the Height property in the visual element
        member x.TryHeight = match x.Attributes.TryFind("Height") with Some v -> Some(unbox<double>(v)) | None -> None

        /// Try to get the TextDetail property in the visual element
        member x.TryTextDetail = match x.Attributes.TryFind("TextDetail") with Some v -> Some(unbox<string>(v)) | None -> None

        /// Try to get the TextDetailColor property in the visual element
        member x.TryTextDetailColor = match x.Attributes.TryFind("TextDetailColor") with Some v -> Some(unbox<Xamarin.Forms.Color>(v)) | None -> None

        /// Try to get the View property in the visual element
        member x.TryView = match x.Attributes.TryFind("View") with Some v -> Some(unbox<XamlElement>(v)) | None -> None

        /// Try to get the SeparatorVisibility property in the visual element
        member x.TrySeparatorVisibility = match x.Attributes.TryFind("SeparatorVisibility") with Some v -> Some(unbox<Xamarin.Forms.SeparatorVisibility>(v)) | None -> None

        /// Try to get the SeparatorColor property in the visual element
        member x.TrySeparatorColor = match x.Attributes.TryFind("SeparatorColor") with Some v -> Some(unbox<Xamarin.Forms.Color>(v)) | None -> None

        /// Try to get the HasUnevenRows property in the visual element
        member x.TryHasUnevenRows = match x.Attributes.TryFind("HasUnevenRows") with Some v -> Some(unbox<bool>(v)) | None -> None

        /// Try to get the RowHeight property in the visual element
        member x.TryRowHeight = match x.Attributes.TryFind("RowHeight") with Some v -> Some(unbox<int>(v)) | None -> None

        /// Adjusts the BackgroundColor property in the visual element
        member x.WithBackgroundColor(value: Xamarin.Forms.Color) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("BackgroundColor", box value))

        /// Adjusts the IsVisible property in the visual element
        member x.WithIsVisible(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("IsVisible", box value))

        /// Adjusts the Opacity property in the visual element
        member x.WithOpacity(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("Opacity", box value))

        /// Adjusts the WidthRequest property in the visual element
        member x.WithWidthRequest(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("WidthRequest", box value))

        /// Adjusts the HeightRequest property in the visual element
        member x.WithHeightRequest(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("HeightRequest", box value))

        /// Adjusts the IsEnabled property in the visual element
        member x.WithIsEnabled(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("IsEnabled", box value))

        /// Adjusts the HorizontalOptions property in the visual element
        member x.WithHorizontalOptions(value: Xamarin.Forms.LayoutOptions) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("HorizontalOptions", box value))

        /// Adjusts the VerticalOptions property in the visual element
        member x.WithVerticalOptions(value: Xamarin.Forms.LayoutOptions) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("VerticalOptions", box value))

        /// Adjusts the Margin property in the visual element
        member x.WithMargin(value: Xamarin.Forms.Thickness) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("Margin", box value))

        /// Adjusts the Color property in the visual element
        member x.WithColor(value: Xamarin.Forms.Color) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("Color", box value))

        /// Adjusts the Text property in the visual element
        member x.WithText(value: string) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("Text", box value))

        /// Adjusts the Command property in the visual element
        member x.WithCommand(value: System.Windows.Input.ICommand) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("Command", box value))

        /// Adjusts the CommandParameter property in the visual element
        member x.WithCommandParameter(value: System.Object) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("CommandParameter", box value))

        /// Adjusts the ContentLayout property in the visual element
        member x.WithContentLayout(value: Xamarin.Forms.Button.ButtonContentLayout) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("ContentLayout", box value))

        /// Adjusts the FontSize property in the visual element
        member x.WithFontSize(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("FontSize", box value))

        /// Adjusts the FontFamily property in the visual element
        member x.WithFontFamily(value: string) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("FontFamily", box value))

        /// Adjusts the FontAttributes property in the visual element
        member x.WithFontAttributes(value: Xamarin.Forms.FontAttributes) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("FontAttributes", box value))

        /// Adjusts the BorderWidth property in the visual element
        member x.WithBorderWidth(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("BorderWidth", box value))

        /// Adjusts the BorderColor property in the visual element
        member x.WithBorderColor(value: Xamarin.Forms.Color) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("BorderColor", box value))

        /// Adjusts the Content property in the visual element
        member x.WithContent(value: XamlElement) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("Content", box value))

        /// Adjusts the Date property in the visual element
        member x.WithDate(value: System.DateTime) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("Date", box value))

        /// Adjusts the Format property in the visual element
        member x.WithFormat(value: string) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("Format", box value))

        /// Adjusts the MinimumDate property in the visual element
        member x.WithMinimumDate(value: System.DateTime) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("MinimumDate", box value))

        /// Adjusts the MaximumDate property in the visual element
        member x.WithMaximumDate(value: System.DateTime) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("MaximumDate", box value))

        /// Adjusts the OutlineColor property in the visual element
        member x.WithOutlineColor(value: Xamarin.Forms.Color) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("OutlineColor", box value))

        /// Adjusts the CornerRadius property in the visual element
        member x.WithCornerRadius(value: single) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("CornerRadius", box value))

        /// Adjusts the HasShadow property in the visual element
        member x.WithHasShadow(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("HasShadow", box value))

        /// Adjusts the ImageSource property in the visual element
        member x.WithImageSource(value: Xamarin.Forms.ImageSource) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("ImageSource", box value))

        /// Adjusts the Aspect property in the visual element
        member x.WithAspect(value: Xamarin.Forms.Aspect) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("Aspect", box value))

        /// Adjusts the IsOpaque property in the visual element
        member x.WithIsOpaque(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("IsOpaque", box value))

        /// Adjusts the Keyboard property in the visual element
        member x.WithKeyboard(value: Xamarin.Forms.Keyboard) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("Keyboard", box value))

        /// Adjusts the TextColor property in the visual element
        member x.WithTextColor(value: Xamarin.Forms.Color) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("TextColor", box value))

        /// Adjusts the Placeholder property in the visual element
        member x.WithPlaceholder(value: string) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("Placeholder", box value))

        /// Adjusts the HorizontalTextAlignment property in the visual element
        member x.WithHorizontalTextAlignment(value: Xamarin.Forms.TextAlignment) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("HorizontalTextAlignment", box value))

        /// Adjusts the PlaceholderColor property in the visual element
        member x.WithPlaceholderColor(value: Xamarin.Forms.Color) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("PlaceholderColor", box value))

        /// Adjusts the IsPassword property in the visual element
        member x.WithIsPassword(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("IsPassword", box value))

        /// Adjusts the VerticalTextAlignment property in the visual element
        member x.WithVerticalTextAlignment(value: Xamarin.Forms.TextAlignment) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("VerticalTextAlignment", box value))

        /// Adjusts the IsClippedToBounds property in the visual element
        member x.WithIsClippedToBounds(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("IsClippedToBounds", box value))

        /// Adjusts the Padding property in the visual element
        member x.WithPadding(value: Xamarin.Forms.Thickness) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("Padding", box value))

        /// Adjusts the Children property in the visual element
        member x.WithChildren(value: System.Collections.Generic.IList<XamlElement>) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("Children", box value))

        /// Adjusts the Orientation property in the visual element
        member x.WithOrientation(value: Xamarin.Forms.StackOrientation) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("Orientation", box value))

        /// Adjusts the Spacing property in the visual element
        member x.WithSpacing(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("Spacing", box value))

        /// Adjusts the Time property in the visual element
        member x.WithTime(value: System.TimeSpan) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("Time", box value))

        /// Adjusts the WebSource property in the visual element
        member x.WithWebSource(value: Xamarin.Forms.WebViewSource) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("WebSource", box value))

        /// Adjusts the Title property in the visual element
        member x.WithTitle(value: string) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("Title", box value))

        /// Adjusts the ItemsSource property in the visual element
        member x.WithItemsSource(value: System.Collections.IEnumerable) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("ItemsSource", box value))

        /// Adjusts the ItemTemplate property in the visual element
        member x.WithItemTemplate(value: Xamarin.Forms.DataTemplate) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("ItemTemplate", box value))

        /// Adjusts the SelectedItem property in the visual element
        member x.WithSelectedItem(value: System.Object) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("SelectedItem", box value))

        /// Adjusts the CurrentPage property in the visual element
        member x.WithCurrentPage(value: XamlElement) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("CurrentPage", box value))

        /// Adjusts the Master property in the visual element
        member x.WithMaster(value: XamlElement) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("Master", box value))

        /// Adjusts the Detail property in the visual element
        member x.WithDetail(value: XamlElement) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("Detail", box value))

        /// Adjusts the Height property in the visual element
        member x.WithHeight(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("Height", box value))

        /// Adjusts the TextDetail property in the visual element
        member x.WithTextDetail(value: string) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("TextDetail", box value))

        /// Adjusts the TextDetailColor property in the visual element
        member x.WithTextDetailColor(value: Xamarin.Forms.Color) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("TextDetailColor", box value))

        /// Adjusts the View property in the visual element
        member x.WithView(value: XamlElement) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("View", box value))

        /// Adjusts the SeparatorVisibility property in the visual element
        member x.WithSeparatorVisibility(value: Xamarin.Forms.SeparatorVisibility) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("SeparatorVisibility", box value))

        /// Adjusts the SeparatorColor property in the visual element
        member x.WithSeparatorColor(value: Xamarin.Forms.Color) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("SeparatorColor", box value))

        /// Adjusts the HasUnevenRows property in the visual element
        member x.WithHasUnevenRows(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("HasUnevenRows", box value))

        /// Adjusts the RowHeight property in the visual element
        member x.WithRowHeight(value: int) = XamlElement(x.TargetType, x.CreateMethod, x.ApplyMethod, x.Attributes.Add("RowHeight", box value))


    /// Adjusts the BackgroundColor property in the visual element
    let withBackgroundColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.WithBackgroundColor(value)

    /// Adjusts the BackgroundColor property in the visual element
    let backgroundColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.WithBackgroundColor(value)

    /// Adjusts the IsVisible property in the visual element
    let withIsVisible (value: bool) (x: XamlElement) = x.WithIsVisible(value)

    /// Adjusts the IsVisible property in the visual element
    let isVisible (value: bool) (x: XamlElement) = x.WithIsVisible(value)

    /// Adjusts the Opacity property in the visual element
    let withOpacity (value: double) (x: XamlElement) = x.WithOpacity(value)

    /// Adjusts the Opacity property in the visual element
    let opacity (value: double) (x: XamlElement) = x.WithOpacity(value)

    /// Adjusts the WidthRequest property in the visual element
    let withWidthRequest (value: double) (x: XamlElement) = x.WithWidthRequest(value)

    /// Adjusts the WidthRequest property in the visual element
    let widthRequest (value: double) (x: XamlElement) = x.WithWidthRequest(value)

    /// Adjusts the HeightRequest property in the visual element
    let withHeightRequest (value: double) (x: XamlElement) = x.WithHeightRequest(value)

    /// Adjusts the HeightRequest property in the visual element
    let heightRequest (value: double) (x: XamlElement) = x.WithHeightRequest(value)

    /// Adjusts the IsEnabled property in the visual element
    let withIsEnabled (value: bool) (x: XamlElement) = x.WithIsEnabled(value)

    /// Adjusts the IsEnabled property in the visual element
    let isEnabled (value: bool) (x: XamlElement) = x.WithIsEnabled(value)

    /// Adjusts the HorizontalOptions property in the visual element
    let withHorizontalOptions (value: Xamarin.Forms.LayoutOptions) (x: XamlElement) = x.WithHorizontalOptions(value)

    /// Adjusts the HorizontalOptions property in the visual element
    let horizontalOptions (value: Xamarin.Forms.LayoutOptions) (x: XamlElement) = x.WithHorizontalOptions(value)

    /// Adjusts the VerticalOptions property in the visual element
    let withVerticalOptions (value: Xamarin.Forms.LayoutOptions) (x: XamlElement) = x.WithVerticalOptions(value)

    /// Adjusts the VerticalOptions property in the visual element
    let verticalOptions (value: Xamarin.Forms.LayoutOptions) (x: XamlElement) = x.WithVerticalOptions(value)

    /// Adjusts the Margin property in the visual element
    let withMargin (value: Xamarin.Forms.Thickness) (x: XamlElement) = x.WithMargin(value)

    /// Adjusts the Margin property in the visual element
    let margin (value: Xamarin.Forms.Thickness) (x: XamlElement) = x.WithMargin(value)

    /// Adjusts the Color property in the visual element
    let withColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.WithColor(value)

    /// Adjusts the Color property in the visual element
    let color (value: Xamarin.Forms.Color) (x: XamlElement) = x.WithColor(value)

    /// Adjusts the Text property in the visual element
    let withText (value: string) (x: XamlElement) = x.WithText(value)

    /// Adjusts the Text property in the visual element
    let text (value: string) (x: XamlElement) = x.WithText(value)

    /// Adjusts the Command property in the visual element
    let withCommand (value: System.Windows.Input.ICommand) (x: XamlElement) = x.WithCommand(value)

    /// Adjusts the Command property in the visual element
    let command (value: System.Windows.Input.ICommand) (x: XamlElement) = x.WithCommand(value)

    /// Adjusts the CommandParameter property in the visual element
    let withCommandParameter (value: System.Object) (x: XamlElement) = x.WithCommandParameter(value)

    /// Adjusts the CommandParameter property in the visual element
    let commandParameter (value: System.Object) (x: XamlElement) = x.WithCommandParameter(value)

    /// Adjusts the ContentLayout property in the visual element
    let withContentLayout (value: Xamarin.Forms.Button.ButtonContentLayout) (x: XamlElement) = x.WithContentLayout(value)

    /// Adjusts the ContentLayout property in the visual element
    let contentLayout (value: Xamarin.Forms.Button.ButtonContentLayout) (x: XamlElement) = x.WithContentLayout(value)

    /// Adjusts the FontSize property in the visual element
    let withFontSize (value: double) (x: XamlElement) = x.WithFontSize(value)

    /// Adjusts the FontSize property in the visual element
    let fontSize (value: double) (x: XamlElement) = x.WithFontSize(value)

    /// Adjusts the FontFamily property in the visual element
    let withFontFamily (value: string) (x: XamlElement) = x.WithFontFamily(value)

    /// Adjusts the FontFamily property in the visual element
    let fontFamily (value: string) (x: XamlElement) = x.WithFontFamily(value)

    /// Adjusts the FontAttributes property in the visual element
    let withFontAttributes (value: Xamarin.Forms.FontAttributes) (x: XamlElement) = x.WithFontAttributes(value)

    /// Adjusts the FontAttributes property in the visual element
    let fontAttributes (value: Xamarin.Forms.FontAttributes) (x: XamlElement) = x.WithFontAttributes(value)

    /// Adjusts the BorderWidth property in the visual element
    let withBorderWidth (value: double) (x: XamlElement) = x.WithBorderWidth(value)

    /// Adjusts the BorderWidth property in the visual element
    let borderWidth (value: double) (x: XamlElement) = x.WithBorderWidth(value)

    /// Adjusts the BorderColor property in the visual element
    let withBorderColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.WithBorderColor(value)

    /// Adjusts the BorderColor property in the visual element
    let borderColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.WithBorderColor(value)

    /// Adjusts the Content property in the visual element
    let withContent (value: XamlElement) (x: XamlElement) = x.WithContent(value)

    /// Adjusts the Content property in the visual element
    let content (value: XamlElement) (x: XamlElement) = x.WithContent(value)

    /// Adjusts the Date property in the visual element
    let withDate (value: System.DateTime) (x: XamlElement) = x.WithDate(value)

    /// Adjusts the Date property in the visual element
    let date (value: System.DateTime) (x: XamlElement) = x.WithDate(value)

    /// Adjusts the Format property in the visual element
    let withFormat (value: string) (x: XamlElement) = x.WithFormat(value)

    /// Adjusts the Format property in the visual element
    let format (value: string) (x: XamlElement) = x.WithFormat(value)

    /// Adjusts the MinimumDate property in the visual element
    let withMinimumDate (value: System.DateTime) (x: XamlElement) = x.WithMinimumDate(value)

    /// Adjusts the MinimumDate property in the visual element
    let minimumDate (value: System.DateTime) (x: XamlElement) = x.WithMinimumDate(value)

    /// Adjusts the MaximumDate property in the visual element
    let withMaximumDate (value: System.DateTime) (x: XamlElement) = x.WithMaximumDate(value)

    /// Adjusts the MaximumDate property in the visual element
    let maximumDate (value: System.DateTime) (x: XamlElement) = x.WithMaximumDate(value)

    /// Adjusts the OutlineColor property in the visual element
    let withOutlineColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.WithOutlineColor(value)

    /// Adjusts the OutlineColor property in the visual element
    let outlineColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.WithOutlineColor(value)

    /// Adjusts the CornerRadius property in the visual element
    let withCornerRadius (value: single) (x: XamlElement) = x.WithCornerRadius(value)

    /// Adjusts the CornerRadius property in the visual element
    let cornerRadius (value: single) (x: XamlElement) = x.WithCornerRadius(value)

    /// Adjusts the HasShadow property in the visual element
    let withHasShadow (value: bool) (x: XamlElement) = x.WithHasShadow(value)

    /// Adjusts the HasShadow property in the visual element
    let hasShadow (value: bool) (x: XamlElement) = x.WithHasShadow(value)

    /// Adjusts the ImageSource property in the visual element
    let withImageSource (value: Xamarin.Forms.ImageSource) (x: XamlElement) = x.WithImageSource(value)

    /// Adjusts the ImageSource property in the visual element
    let imageSource (value: Xamarin.Forms.ImageSource) (x: XamlElement) = x.WithImageSource(value)

    /// Adjusts the Aspect property in the visual element
    let withAspect (value: Xamarin.Forms.Aspect) (x: XamlElement) = x.WithAspect(value)

    /// Adjusts the Aspect property in the visual element
    let aspect (value: Xamarin.Forms.Aspect) (x: XamlElement) = x.WithAspect(value)

    /// Adjusts the IsOpaque property in the visual element
    let withIsOpaque (value: bool) (x: XamlElement) = x.WithIsOpaque(value)

    /// Adjusts the IsOpaque property in the visual element
    let isOpaque (value: bool) (x: XamlElement) = x.WithIsOpaque(value)

    /// Adjusts the Keyboard property in the visual element
    let withKeyboard (value: Xamarin.Forms.Keyboard) (x: XamlElement) = x.WithKeyboard(value)

    /// Adjusts the Keyboard property in the visual element
    let keyboard (value: Xamarin.Forms.Keyboard) (x: XamlElement) = x.WithKeyboard(value)

    /// Adjusts the TextColor property in the visual element
    let withTextColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.WithTextColor(value)

    /// Adjusts the TextColor property in the visual element
    let textColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.WithTextColor(value)

    /// Adjusts the Placeholder property in the visual element
    let withPlaceholder (value: string) (x: XamlElement) = x.WithPlaceholder(value)

    /// Adjusts the Placeholder property in the visual element
    let placeholder (value: string) (x: XamlElement) = x.WithPlaceholder(value)

    /// Adjusts the HorizontalTextAlignment property in the visual element
    let withHorizontalTextAlignment (value: Xamarin.Forms.TextAlignment) (x: XamlElement) = x.WithHorizontalTextAlignment(value)

    /// Adjusts the HorizontalTextAlignment property in the visual element
    let horizontalTextAlignment (value: Xamarin.Forms.TextAlignment) (x: XamlElement) = x.WithHorizontalTextAlignment(value)

    /// Adjusts the PlaceholderColor property in the visual element
    let withPlaceholderColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.WithPlaceholderColor(value)

    /// Adjusts the PlaceholderColor property in the visual element
    let placeholderColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.WithPlaceholderColor(value)

    /// Adjusts the IsPassword property in the visual element
    let withIsPassword (value: bool) (x: XamlElement) = x.WithIsPassword(value)

    /// Adjusts the IsPassword property in the visual element
    let isPassword (value: bool) (x: XamlElement) = x.WithIsPassword(value)

    /// Adjusts the VerticalTextAlignment property in the visual element
    let withVerticalTextAlignment (value: Xamarin.Forms.TextAlignment) (x: XamlElement) = x.WithVerticalTextAlignment(value)

    /// Adjusts the VerticalTextAlignment property in the visual element
    let verticalTextAlignment (value: Xamarin.Forms.TextAlignment) (x: XamlElement) = x.WithVerticalTextAlignment(value)

    /// Adjusts the IsClippedToBounds property in the visual element
    let withIsClippedToBounds (value: bool) (x: XamlElement) = x.WithIsClippedToBounds(value)

    /// Adjusts the IsClippedToBounds property in the visual element
    let isClippedToBounds (value: bool) (x: XamlElement) = x.WithIsClippedToBounds(value)

    /// Adjusts the Padding property in the visual element
    let withPadding (value: Xamarin.Forms.Thickness) (x: XamlElement) = x.WithPadding(value)

    /// Adjusts the Padding property in the visual element
    let padding (value: Xamarin.Forms.Thickness) (x: XamlElement) = x.WithPadding(value)

    /// Adjusts the Children property in the visual element
    let withChildren (value: System.Collections.Generic.IList<XamlElement>) (x: XamlElement) = x.WithChildren(value)

    /// Adjusts the Children property in the visual element
    let children (value: System.Collections.Generic.IList<XamlElement>) (x: XamlElement) = x.WithChildren(value)

    /// Adjusts the Orientation property in the visual element
    let withOrientation (value: Xamarin.Forms.StackOrientation) (x: XamlElement) = x.WithOrientation(value)

    /// Adjusts the Orientation property in the visual element
    let orientation (value: Xamarin.Forms.StackOrientation) (x: XamlElement) = x.WithOrientation(value)

    /// Adjusts the Spacing property in the visual element
    let withSpacing (value: double) (x: XamlElement) = x.WithSpacing(value)

    /// Adjusts the Spacing property in the visual element
    let spacing (value: double) (x: XamlElement) = x.WithSpacing(value)

    /// Adjusts the Time property in the visual element
    let withTime (value: System.TimeSpan) (x: XamlElement) = x.WithTime(value)

    /// Adjusts the Time property in the visual element
    let time (value: System.TimeSpan) (x: XamlElement) = x.WithTime(value)

    /// Adjusts the WebSource property in the visual element
    let withWebSource (value: Xamarin.Forms.WebViewSource) (x: XamlElement) = x.WithWebSource(value)

    /// Adjusts the WebSource property in the visual element
    let webSource (value: Xamarin.Forms.WebViewSource) (x: XamlElement) = x.WithWebSource(value)

    /// Adjusts the Title property in the visual element
    let withTitle (value: string) (x: XamlElement) = x.WithTitle(value)

    /// Adjusts the Title property in the visual element
    let title (value: string) (x: XamlElement) = x.WithTitle(value)

    /// Adjusts the ItemsSource property in the visual element
    let withItemsSource (value: System.Collections.IEnumerable) (x: XamlElement) = x.WithItemsSource(value)

    /// Adjusts the ItemsSource property in the visual element
    let itemsSource (value: System.Collections.IEnumerable) (x: XamlElement) = x.WithItemsSource(value)

    /// Adjusts the ItemTemplate property in the visual element
    let withItemTemplate (value: Xamarin.Forms.DataTemplate) (x: XamlElement) = x.WithItemTemplate(value)

    /// Adjusts the ItemTemplate property in the visual element
    let itemTemplate (value: Xamarin.Forms.DataTemplate) (x: XamlElement) = x.WithItemTemplate(value)

    /// Adjusts the SelectedItem property in the visual element
    let withSelectedItem (value: System.Object) (x: XamlElement) = x.WithSelectedItem(value)

    /// Adjusts the SelectedItem property in the visual element
    let selectedItem (value: System.Object) (x: XamlElement) = x.WithSelectedItem(value)

    /// Adjusts the CurrentPage property in the visual element
    let withCurrentPage (value: XamlElement) (x: XamlElement) = x.WithCurrentPage(value)

    /// Adjusts the CurrentPage property in the visual element
    let currentPage (value: XamlElement) (x: XamlElement) = x.WithCurrentPage(value)

    /// Adjusts the Master property in the visual element
    let withMaster (value: XamlElement) (x: XamlElement) = x.WithMaster(value)

    /// Adjusts the Master property in the visual element
    let master (value: XamlElement) (x: XamlElement) = x.WithMaster(value)

    /// Adjusts the Detail property in the visual element
    let withDetail (value: XamlElement) (x: XamlElement) = x.WithDetail(value)

    /// Adjusts the Detail property in the visual element
    let detail (value: XamlElement) (x: XamlElement) = x.WithDetail(value)

    /// Adjusts the Height property in the visual element
    let withHeight (value: double) (x: XamlElement) = x.WithHeight(value)

    /// Adjusts the Height property in the visual element
    let height (value: double) (x: XamlElement) = x.WithHeight(value)

    /// Adjusts the TextDetail property in the visual element
    let withTextDetail (value: string) (x: XamlElement) = x.WithTextDetail(value)

    /// Adjusts the TextDetail property in the visual element
    let textDetail (value: string) (x: XamlElement) = x.WithTextDetail(value)

    /// Adjusts the TextDetailColor property in the visual element
    let withTextDetailColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.WithTextDetailColor(value)

    /// Adjusts the TextDetailColor property in the visual element
    let textDetailColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.WithTextDetailColor(value)

    /// Adjusts the View property in the visual element
    let withView (value: XamlElement) (x: XamlElement) = x.WithView(value)

    /// Adjusts the View property in the visual element
    let view (value: XamlElement) (x: XamlElement) = x.WithView(value)

    /// Adjusts the SeparatorVisibility property in the visual element
    let withSeparatorVisibility (value: Xamarin.Forms.SeparatorVisibility) (x: XamlElement) = x.WithSeparatorVisibility(value)

    /// Adjusts the SeparatorVisibility property in the visual element
    let separatorVisibility (value: Xamarin.Forms.SeparatorVisibility) (x: XamlElement) = x.WithSeparatorVisibility(value)

    /// Adjusts the SeparatorColor property in the visual element
    let withSeparatorColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.WithSeparatorColor(value)

    /// Adjusts the SeparatorColor property in the visual element
    let separatorColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.WithSeparatorColor(value)

    /// Adjusts the HasUnevenRows property in the visual element
    let withHasUnevenRows (value: bool) (x: XamlElement) = x.WithHasUnevenRows(value)

    /// Adjusts the HasUnevenRows property in the visual element
    let hasUnevenRows (value: bool) (x: XamlElement) = x.WithHasUnevenRows(value)

    /// Adjusts the RowHeight property in the visual element
    let withRowHeight (value: int) (x: XamlElement) = x.WithRowHeight(value)

    /// Adjusts the RowHeight property in the visual element
    let rowHeight (value: int) (x: XamlElement) = x.WithRowHeight(value)

type Xaml() =

    /// Describes a Element in the view
    static member Element() = 
        let attribs = [| 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.Element"

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            ()
        new XamlElement(typeof<Xamarin.Forms.Element>, create, apply, Map.ofArray attribs)

    /// Describes a VisualElement in the view
    static member VisualElement(?backgroundColor: Xamarin.Forms.Color, ?isVisible: bool, ?opacity: double, ?widthRequest: double, ?heightRequest: double, ?isEnabled: bool) = 
        let attribs = [| 
            match backgroundColor with | None -> () | Some v -> yield ("BackgroundColor", box v) 
            match isVisible with | None -> () | Some v -> yield ("IsVisible", box v) 
            match opacity with | None -> () | Some v -> yield ("Opacity", box v) 
            match widthRequest with | None -> () | Some v -> yield ("WidthRequest", box v) 
            match heightRequest with | None -> () | Some v -> yield ("HeightRequest", box v) 
            match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box v) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.VisualElement"

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.VisualElement)
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryBackgroundColor
            match prevValueOpt, source.TryBackgroundColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.BackgroundColor <- value
            | Some _, None -> target.BackgroundColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsVisible
            match prevValueOpt, source.TryIsVisible with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsVisible <- value
            | Some _, None -> target.IsVisible <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryOpacity
            match prevValueOpt, source.TryOpacity with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Opacity <- value
            | Some _, None -> target.Opacity <- 1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryWidthRequest
            match prevValueOpt, source.TryWidthRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.WidthRequest <- value
            | Some _, None -> target.WidthRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHeightRequest
            match prevValueOpt, source.TryHeightRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HeightRequest <- value
            | Some _, None -> target.HeightRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsEnabled
            match prevValueOpt, source.TryIsEnabled with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsEnabled <- value
            | Some _, None -> target.IsEnabled <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
        new XamlElement(typeof<Xamarin.Forms.VisualElement>, create, apply, Map.ofArray attribs)

    /// Describes a View in the view
    static member View(?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: Xamarin.Forms.Thickness, ?backgroundColor: Xamarin.Forms.Color, ?isVisible: bool, ?opacity: double, ?widthRequest: double, ?heightRequest: double, ?isEnabled: bool) = 
        let attribs = [| 
            match horizontalOptions with | None -> () | Some v -> yield ("HorizontalOptions", box v) 
            match verticalOptions with | None -> () | Some v -> yield ("VerticalOptions", box v) 
            match margin with | None -> () | Some v -> yield ("Margin", box v) 
            match backgroundColor with | None -> () | Some v -> yield ("BackgroundColor", box v) 
            match isVisible with | None -> () | Some v -> yield ("IsVisible", box v) 
            match opacity with | None -> () | Some v -> yield ("Opacity", box v) 
            match widthRequest with | None -> () | Some v -> yield ("WidthRequest", box v) 
            match heightRequest with | None -> () | Some v -> yield ("HeightRequest", box v) 
            match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box v) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.View"

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.View)
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHorizontalOptions
            match prevValueOpt, source.TryHorizontalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HorizontalOptions <- value
            | Some _, None -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryVerticalOptions
            match prevValueOpt, source.TryVerticalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.VerticalOptions <- value
            | Some _, None -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryMargin
            match prevValueOpt, source.TryMargin with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Margin <- value
            | Some _, None -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryBackgroundColor
            match prevValueOpt, source.TryBackgroundColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.BackgroundColor <- value
            | Some _, None -> target.BackgroundColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsVisible
            match prevValueOpt, source.TryIsVisible with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsVisible <- value
            | Some _, None -> target.IsVisible <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryOpacity
            match prevValueOpt, source.TryOpacity with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Opacity <- value
            | Some _, None -> target.Opacity <- 1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryWidthRequest
            match prevValueOpt, source.TryWidthRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.WidthRequest <- value
            | Some _, None -> target.WidthRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHeightRequest
            match prevValueOpt, source.TryHeightRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HeightRequest <- value
            | Some _, None -> target.HeightRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsEnabled
            match prevValueOpt, source.TryIsEnabled with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsEnabled <- value
            | Some _, None -> target.IsEnabled <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
        new XamlElement(typeof<Xamarin.Forms.View>, create, apply, Map.ofArray attribs)

    /// Describes a BoxView in the view
    static member BoxView(?color: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: Xamarin.Forms.Thickness, ?backgroundColor: Xamarin.Forms.Color, ?isVisible: bool, ?opacity: double, ?widthRequest: double, ?heightRequest: double, ?isEnabled: bool) = 
        let attribs = [| 
            match color with | None -> () | Some v -> yield ("Color", box v) 
            match horizontalOptions with | None -> () | Some v -> yield ("HorizontalOptions", box v) 
            match verticalOptions with | None -> () | Some v -> yield ("VerticalOptions", box v) 
            match margin with | None -> () | Some v -> yield ("Margin", box v) 
            match backgroundColor with | None -> () | Some v -> yield ("BackgroundColor", box v) 
            match isVisible with | None -> () | Some v -> yield ("IsVisible", box v) 
            match opacity with | None -> () | Some v -> yield ("Opacity", box v) 
            match widthRequest with | None -> () | Some v -> yield ("WidthRequest", box v) 
            match heightRequest with | None -> () | Some v -> yield ("HeightRequest", box v) 
            match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box v) 
          |]

        let create () =
            box (new Xamarin.Forms.BoxView())

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.BoxView)
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryColor
            match prevValueOpt, source.TryColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Color <- value
            | Some _, None -> target.Color <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHorizontalOptions
            match prevValueOpt, source.TryHorizontalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HorizontalOptions <- value
            | Some _, None -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryVerticalOptions
            match prevValueOpt, source.TryVerticalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.VerticalOptions <- value
            | Some _, None -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryMargin
            match prevValueOpt, source.TryMargin with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Margin <- value
            | Some _, None -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryBackgroundColor
            match prevValueOpt, source.TryBackgroundColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.BackgroundColor <- value
            | Some _, None -> target.BackgroundColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsVisible
            match prevValueOpt, source.TryIsVisible with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsVisible <- value
            | Some _, None -> target.IsVisible <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryOpacity
            match prevValueOpt, source.TryOpacity with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Opacity <- value
            | Some _, None -> target.Opacity <- 1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryWidthRequest
            match prevValueOpt, source.TryWidthRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.WidthRequest <- value
            | Some _, None -> target.WidthRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHeightRequest
            match prevValueOpt, source.TryHeightRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HeightRequest <- value
            | Some _, None -> target.HeightRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsEnabled
            match prevValueOpt, source.TryIsEnabled with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsEnabled <- value
            | Some _, None -> target.IsEnabled <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
        new XamlElement(typeof<Xamarin.Forms.BoxView>, create, apply, Map.ofArray attribs)

    /// Describes a Button in the view
    static member Button(?text: string, ?command: System.Windows.Input.ICommand, ?commandParameter: System.Object, ?contentLayout: Xamarin.Forms.Button.ButtonContentLayout, ?fontSize: double, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?borderWidth: double, ?borderColor: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: Xamarin.Forms.Thickness, ?backgroundColor: Xamarin.Forms.Color, ?isVisible: bool, ?opacity: double, ?widthRequest: double, ?heightRequest: double, ?isEnabled: bool) = 
        let attribs = [| 
            match text with | None -> () | Some v -> yield ("Text", box v) 
            match command with | None -> () | Some v -> yield ("Command", box v) 
            match commandParameter with | None -> () | Some v -> yield ("CommandParameter", box v) 
            match contentLayout with | None -> () | Some v -> yield ("ContentLayout", box v) 
            match fontSize with | None -> () | Some v -> yield ("FontSize", box v) 
            match fontFamily with | None -> () | Some v -> yield ("FontFamily", box v) 
            match fontAttributes with | None -> () | Some v -> yield ("FontAttributes", box v) 
            match borderWidth with | None -> () | Some v -> yield ("BorderWidth", box v) 
            match borderColor with | None -> () | Some v -> yield ("BorderColor", box v) 
            match horizontalOptions with | None -> () | Some v -> yield ("HorizontalOptions", box v) 
            match verticalOptions with | None -> () | Some v -> yield ("VerticalOptions", box v) 
            match margin with | None -> () | Some v -> yield ("Margin", box v) 
            match backgroundColor with | None -> () | Some v -> yield ("BackgroundColor", box v) 
            match isVisible with | None -> () | Some v -> yield ("IsVisible", box v) 
            match opacity with | None -> () | Some v -> yield ("Opacity", box v) 
            match widthRequest with | None -> () | Some v -> yield ("WidthRequest", box v) 
            match heightRequest with | None -> () | Some v -> yield ("HeightRequest", box v) 
            match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box v) 
          |]

        let create () =
            box (new Xamarin.Forms.Button())

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.Button)
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryText
            match prevValueOpt, source.TryText with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Text <- value
            | Some _, None -> target.Text <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryCommand
            match prevValueOpt, source.TryCommand with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Command <- value
            | Some _, None -> target.Command <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryCommandParameter
            match prevValueOpt, source.TryCommandParameter with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.CommandParameter <- value
            | Some _, None -> target.CommandParameter <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryContentLayout
            match prevValueOpt, source.TryContentLayout with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.ContentLayout <- value
            | Some _, None -> target.ContentLayout <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryFontSize
            match prevValueOpt, source.TryFontSize with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.FontSize <- value
            | Some _, None -> target.FontSize <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryFontFamily
            match prevValueOpt, source.TryFontFamily with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.FontFamily <- value
            | Some _, None -> target.FontFamily <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryFontAttributes
            match prevValueOpt, source.TryFontAttributes with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.FontAttributes <- value
            | Some _, None -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryBorderWidth
            match prevValueOpt, source.TryBorderWidth with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.BorderWidth <- value
            | Some _, None -> target.BorderWidth <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryBorderColor
            match prevValueOpt, source.TryBorderColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.BorderColor <- value
            | Some _, None -> target.BorderColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHorizontalOptions
            match prevValueOpt, source.TryHorizontalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HorizontalOptions <- value
            | Some _, None -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryVerticalOptions
            match prevValueOpt, source.TryVerticalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.VerticalOptions <- value
            | Some _, None -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryMargin
            match prevValueOpt, source.TryMargin with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Margin <- value
            | Some _, None -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryBackgroundColor
            match prevValueOpt, source.TryBackgroundColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.BackgroundColor <- value
            | Some _, None -> target.BackgroundColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsVisible
            match prevValueOpt, source.TryIsVisible with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsVisible <- value
            | Some _, None -> target.IsVisible <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryOpacity
            match prevValueOpt, source.TryOpacity with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Opacity <- value
            | Some _, None -> target.Opacity <- 1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryWidthRequest
            match prevValueOpt, source.TryWidthRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.WidthRequest <- value
            | Some _, None -> target.WidthRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHeightRequest
            match prevValueOpt, source.TryHeightRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HeightRequest <- value
            | Some _, None -> target.HeightRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsEnabled
            match prevValueOpt, source.TryIsEnabled with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsEnabled <- value
            | Some _, None -> target.IsEnabled <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
        new XamlElement(typeof<Xamarin.Forms.Button>, create, apply, Map.ofArray attribs)

    /// Describes a ContentView in the view
    static member ContentView(?content: XamlElement, ?isClippedToBounds: bool, ?padding: Xamarin.Forms.Thickness, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: Xamarin.Forms.Thickness, ?backgroundColor: Xamarin.Forms.Color, ?isVisible: bool, ?opacity: double, ?widthRequest: double, ?heightRequest: double, ?isEnabled: bool) = 
        let attribs = [| 
            match content with | None -> () | Some v -> yield ("Content", box v) 
            match isClippedToBounds with | None -> () | Some v -> yield ("IsClippedToBounds", box v) 
            match padding with | None -> () | Some v -> yield ("Padding", box v) 
            match horizontalOptions with | None -> () | Some v -> yield ("HorizontalOptions", box v) 
            match verticalOptions with | None -> () | Some v -> yield ("VerticalOptions", box v) 
            match margin with | None -> () | Some v -> yield ("Margin", box v) 
            match backgroundColor with | None -> () | Some v -> yield ("BackgroundColor", box v) 
            match isVisible with | None -> () | Some v -> yield ("IsVisible", box v) 
            match opacity with | None -> () | Some v -> yield ("Opacity", box v) 
            match widthRequest with | None -> () | Some v -> yield ("WidthRequest", box v) 
            match heightRequest with | None -> () | Some v -> yield ("HeightRequest", box v) 
            match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box v) 
          |]

        let create () =
            box (new Xamarin.Forms.ContentView())

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.ContentView)
            let prevChildOpt = match prevOpt with None -> None | Some prev -> prev.TryContent
            match prevChildOpt, source.TryContent with
            // For structured objects, the only caching is based on reference equality
            | Some prevChild, Some newChild when obj.ReferenceEquals(prevChild, newChild) -> ()
            | Some prevChild, Some newChild ->
                newChild.ApplyIncremental(prevChild, target.Content)
            | None, Some newChild ->
                target.Content <- newChild.CreateAsView()
            | _, None ->
                target.Content <- null;
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsClippedToBounds
            match prevValueOpt, source.TryIsClippedToBounds with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsClippedToBounds <- value
            | Some _, None -> target.IsClippedToBounds <- false // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryPadding
            match prevValueOpt, source.TryPadding with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Padding <- value
            | Some _, None -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHorizontalOptions
            match prevValueOpt, source.TryHorizontalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HorizontalOptions <- value
            | Some _, None -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryVerticalOptions
            match prevValueOpt, source.TryVerticalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.VerticalOptions <- value
            | Some _, None -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryMargin
            match prevValueOpt, source.TryMargin with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Margin <- value
            | Some _, None -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryBackgroundColor
            match prevValueOpt, source.TryBackgroundColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.BackgroundColor <- value
            | Some _, None -> target.BackgroundColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsVisible
            match prevValueOpt, source.TryIsVisible with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsVisible <- value
            | Some _, None -> target.IsVisible <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryOpacity
            match prevValueOpt, source.TryOpacity with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Opacity <- value
            | Some _, None -> target.Opacity <- 1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryWidthRequest
            match prevValueOpt, source.TryWidthRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.WidthRequest <- value
            | Some _, None -> target.WidthRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHeightRequest
            match prevValueOpt, source.TryHeightRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HeightRequest <- value
            | Some _, None -> target.HeightRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsEnabled
            match prevValueOpt, source.TryIsEnabled with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsEnabled <- value
            | Some _, None -> target.IsEnabled <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
        new XamlElement(typeof<Xamarin.Forms.ContentView>, create, apply, Map.ofArray attribs)

    /// Describes a TemplatedView in the view
    static member TemplatedView(?isClippedToBounds: bool, ?padding: Xamarin.Forms.Thickness, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: Xamarin.Forms.Thickness, ?backgroundColor: Xamarin.Forms.Color, ?isVisible: bool, ?opacity: double, ?widthRequest: double, ?heightRequest: double, ?isEnabled: bool) = 
        let attribs = [| 
            match isClippedToBounds with | None -> () | Some v -> yield ("IsClippedToBounds", box v) 
            match padding with | None -> () | Some v -> yield ("Padding", box v) 
            match horizontalOptions with | None -> () | Some v -> yield ("HorizontalOptions", box v) 
            match verticalOptions with | None -> () | Some v -> yield ("VerticalOptions", box v) 
            match margin with | None -> () | Some v -> yield ("Margin", box v) 
            match backgroundColor with | None -> () | Some v -> yield ("BackgroundColor", box v) 
            match isVisible with | None -> () | Some v -> yield ("IsVisible", box v) 
            match opacity with | None -> () | Some v -> yield ("Opacity", box v) 
            match widthRequest with | None -> () | Some v -> yield ("WidthRequest", box v) 
            match heightRequest with | None -> () | Some v -> yield ("HeightRequest", box v) 
            match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box v) 
          |]

        let create () =
            box (new Xamarin.Forms.TemplatedView())

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.TemplatedView)
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsClippedToBounds
            match prevValueOpt, source.TryIsClippedToBounds with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsClippedToBounds <- value
            | Some _, None -> target.IsClippedToBounds <- false // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryPadding
            match prevValueOpt, source.TryPadding with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Padding <- value
            | Some _, None -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHorizontalOptions
            match prevValueOpt, source.TryHorizontalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HorizontalOptions <- value
            | Some _, None -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryVerticalOptions
            match prevValueOpt, source.TryVerticalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.VerticalOptions <- value
            | Some _, None -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryMargin
            match prevValueOpt, source.TryMargin with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Margin <- value
            | Some _, None -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryBackgroundColor
            match prevValueOpt, source.TryBackgroundColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.BackgroundColor <- value
            | Some _, None -> target.BackgroundColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsVisible
            match prevValueOpt, source.TryIsVisible with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsVisible <- value
            | Some _, None -> target.IsVisible <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryOpacity
            match prevValueOpt, source.TryOpacity with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Opacity <- value
            | Some _, None -> target.Opacity <- 1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryWidthRequest
            match prevValueOpt, source.TryWidthRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.WidthRequest <- value
            | Some _, None -> target.WidthRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHeightRequest
            match prevValueOpt, source.TryHeightRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HeightRequest <- value
            | Some _, None -> target.HeightRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsEnabled
            match prevValueOpt, source.TryIsEnabled with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsEnabled <- value
            | Some _, None -> target.IsEnabled <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
        new XamlElement(typeof<Xamarin.Forms.TemplatedView>, create, apply, Map.ofArray attribs)

    /// Describes a DatePicker in the view
    static member DatePicker(?date: System.DateTime, ?format: string, ?minimumDate: System.DateTime, ?maximumDate: System.DateTime, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: Xamarin.Forms.Thickness, ?backgroundColor: Xamarin.Forms.Color, ?isVisible: bool, ?opacity: double, ?widthRequest: double, ?heightRequest: double, ?isEnabled: bool) = 
        let attribs = [| 
            match date with | None -> () | Some v -> yield ("Date", box v) 
            match format with | None -> () | Some v -> yield ("Format", box v) 
            match minimumDate with | None -> () | Some v -> yield ("MinimumDate", box v) 
            match maximumDate with | None -> () | Some v -> yield ("MaximumDate", box v) 
            match horizontalOptions with | None -> () | Some v -> yield ("HorizontalOptions", box v) 
            match verticalOptions with | None -> () | Some v -> yield ("VerticalOptions", box v) 
            match margin with | None -> () | Some v -> yield ("Margin", box v) 
            match backgroundColor with | None -> () | Some v -> yield ("BackgroundColor", box v) 
            match isVisible with | None -> () | Some v -> yield ("IsVisible", box v) 
            match opacity with | None -> () | Some v -> yield ("Opacity", box v) 
            match widthRequest with | None -> () | Some v -> yield ("WidthRequest", box v) 
            match heightRequest with | None -> () | Some v -> yield ("HeightRequest", box v) 
            match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box v) 
          |]

        let create () =
            box (new Xamarin.Forms.DatePicker())

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.DatePicker)
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryDate
            match prevValueOpt, source.TryDate with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Date <- value
            | Some _, None -> target.Date <- Unchecked.defaultof<System.DateTime> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryFormat
            match prevValueOpt, source.TryFormat with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Format <- value
            | Some _, None -> target.Format <- "d" // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryMinimumDate
            match prevValueOpt, source.TryMinimumDate with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.MinimumDate <- value
            | Some _, None -> target.MinimumDate <- new System.DateTime(1900, 1, 1) // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryMaximumDate
            match prevValueOpt, source.TryMaximumDate with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.MaximumDate <- value
            | Some _, None -> target.MaximumDate <- new System.DateTime(2100, 12, 31) // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHorizontalOptions
            match prevValueOpt, source.TryHorizontalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HorizontalOptions <- value
            | Some _, None -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryVerticalOptions
            match prevValueOpt, source.TryVerticalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.VerticalOptions <- value
            | Some _, None -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryMargin
            match prevValueOpt, source.TryMargin with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Margin <- value
            | Some _, None -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryBackgroundColor
            match prevValueOpt, source.TryBackgroundColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.BackgroundColor <- value
            | Some _, None -> target.BackgroundColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsVisible
            match prevValueOpt, source.TryIsVisible with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsVisible <- value
            | Some _, None -> target.IsVisible <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryOpacity
            match prevValueOpt, source.TryOpacity with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Opacity <- value
            | Some _, None -> target.Opacity <- 1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryWidthRequest
            match prevValueOpt, source.TryWidthRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.WidthRequest <- value
            | Some _, None -> target.WidthRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHeightRequest
            match prevValueOpt, source.TryHeightRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HeightRequest <- value
            | Some _, None -> target.HeightRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsEnabled
            match prevValueOpt, source.TryIsEnabled with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsEnabled <- value
            | Some _, None -> target.IsEnabled <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
        new XamlElement(typeof<Xamarin.Forms.DatePicker>, create, apply, Map.ofArray attribs)

    /// Describes a Frame in the view
    static member Frame(?outlineColor: Xamarin.Forms.Color, ?cornerRadius: single, ?hasShadow: bool, ?content: XamlElement, ?isClippedToBounds: bool, ?padding: Xamarin.Forms.Thickness, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: Xamarin.Forms.Thickness, ?backgroundColor: Xamarin.Forms.Color, ?isVisible: bool, ?opacity: double, ?widthRequest: double, ?heightRequest: double, ?isEnabled: bool) = 
        let attribs = [| 
            match outlineColor with | None -> () | Some v -> yield ("OutlineColor", box v) 
            match cornerRadius with | None -> () | Some v -> yield ("CornerRadius", box v) 
            match hasShadow with | None -> () | Some v -> yield ("HasShadow", box v) 
            match content with | None -> () | Some v -> yield ("Content", box v) 
            match isClippedToBounds with | None -> () | Some v -> yield ("IsClippedToBounds", box v) 
            match padding with | None -> () | Some v -> yield ("Padding", box v) 
            match horizontalOptions with | None -> () | Some v -> yield ("HorizontalOptions", box v) 
            match verticalOptions with | None -> () | Some v -> yield ("VerticalOptions", box v) 
            match margin with | None -> () | Some v -> yield ("Margin", box v) 
            match backgroundColor with | None -> () | Some v -> yield ("BackgroundColor", box v) 
            match isVisible with | None -> () | Some v -> yield ("IsVisible", box v) 
            match opacity with | None -> () | Some v -> yield ("Opacity", box v) 
            match widthRequest with | None -> () | Some v -> yield ("WidthRequest", box v) 
            match heightRequest with | None -> () | Some v -> yield ("HeightRequest", box v) 
            match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box v) 
          |]

        let create () =
            box (new Xamarin.Forms.Frame())

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.Frame)
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryOutlineColor
            match prevValueOpt, source.TryOutlineColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.OutlineColor <- value
            | Some _, None -> target.OutlineColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryCornerRadius
            match prevValueOpt, source.TryCornerRadius with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.CornerRadius <- value
            | Some _, None -> target.CornerRadius <- -1.0f // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHasShadow
            match prevValueOpt, source.TryHasShadow with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HasShadow <- value
            | Some _, None -> target.HasShadow <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevChildOpt = match prevOpt with None -> None | Some prev -> prev.TryContent
            match prevChildOpt, source.TryContent with
            // For structured objects, the only caching is based on reference equality
            | Some prevChild, Some newChild when obj.ReferenceEquals(prevChild, newChild) -> ()
            | Some prevChild, Some newChild ->
                newChild.ApplyIncremental(prevChild, target.Content)
            | None, Some newChild ->
                target.Content <- newChild.CreateAsView()
            | _, None ->
                target.Content <- null;
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsClippedToBounds
            match prevValueOpt, source.TryIsClippedToBounds with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsClippedToBounds <- value
            | Some _, None -> target.IsClippedToBounds <- false // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryPadding
            match prevValueOpt, source.TryPadding with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Padding <- value
            | Some _, None -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHorizontalOptions
            match prevValueOpt, source.TryHorizontalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HorizontalOptions <- value
            | Some _, None -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryVerticalOptions
            match prevValueOpt, source.TryVerticalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.VerticalOptions <- value
            | Some _, None -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryMargin
            match prevValueOpt, source.TryMargin with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Margin <- value
            | Some _, None -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryBackgroundColor
            match prevValueOpt, source.TryBackgroundColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.BackgroundColor <- value
            | Some _, None -> target.BackgroundColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsVisible
            match prevValueOpt, source.TryIsVisible with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsVisible <- value
            | Some _, None -> target.IsVisible <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryOpacity
            match prevValueOpt, source.TryOpacity with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Opacity <- value
            | Some _, None -> target.Opacity <- 1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryWidthRequest
            match prevValueOpt, source.TryWidthRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.WidthRequest <- value
            | Some _, None -> target.WidthRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHeightRequest
            match prevValueOpt, source.TryHeightRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HeightRequest <- value
            | Some _, None -> target.HeightRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsEnabled
            match prevValueOpt, source.TryIsEnabled with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsEnabled <- value
            | Some _, None -> target.IsEnabled <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
        new XamlElement(typeof<Xamarin.Forms.Frame>, create, apply, Map.ofArray attribs)

    /// Describes a Image in the view
    static member Image(?imageSource: Xamarin.Forms.ImageSource, ?aspect: Xamarin.Forms.Aspect, ?isOpaque: bool, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: Xamarin.Forms.Thickness, ?backgroundColor: Xamarin.Forms.Color, ?isVisible: bool, ?opacity: double, ?widthRequest: double, ?heightRequest: double, ?isEnabled: bool) = 
        let attribs = [| 
            match imageSource with | None -> () | Some v -> yield ("ImageSource", box v) 
            match aspect with | None -> () | Some v -> yield ("Aspect", box v) 
            match isOpaque with | None -> () | Some v -> yield ("IsOpaque", box v) 
            match horizontalOptions with | None -> () | Some v -> yield ("HorizontalOptions", box v) 
            match verticalOptions with | None -> () | Some v -> yield ("VerticalOptions", box v) 
            match margin with | None -> () | Some v -> yield ("Margin", box v) 
            match backgroundColor with | None -> () | Some v -> yield ("BackgroundColor", box v) 
            match isVisible with | None -> () | Some v -> yield ("IsVisible", box v) 
            match opacity with | None -> () | Some v -> yield ("Opacity", box v) 
            match widthRequest with | None -> () | Some v -> yield ("WidthRequest", box v) 
            match heightRequest with | None -> () | Some v -> yield ("HeightRequest", box v) 
            match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box v) 
          |]

        let create () =
            box (new Xamarin.Forms.Image())

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.Image)
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryImageSource
            match prevValueOpt, source.TryImageSource with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Source <- value
            | Some _, None -> target.Source <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryAspect
            match prevValueOpt, source.TryAspect with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Aspect <- value
            | Some _, None -> target.Aspect <- Xamarin.Forms.Aspect.AspectFit // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsOpaque
            match prevValueOpt, source.TryIsOpaque with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsOpaque <- value
            | Some _, None -> target.IsOpaque <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHorizontalOptions
            match prevValueOpt, source.TryHorizontalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HorizontalOptions <- value
            | Some _, None -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryVerticalOptions
            match prevValueOpt, source.TryVerticalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.VerticalOptions <- value
            | Some _, None -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryMargin
            match prevValueOpt, source.TryMargin with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Margin <- value
            | Some _, None -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryBackgroundColor
            match prevValueOpt, source.TryBackgroundColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.BackgroundColor <- value
            | Some _, None -> target.BackgroundColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsVisible
            match prevValueOpt, source.TryIsVisible with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsVisible <- value
            | Some _, None -> target.IsVisible <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryOpacity
            match prevValueOpt, source.TryOpacity with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Opacity <- value
            | Some _, None -> target.Opacity <- 1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryWidthRequest
            match prevValueOpt, source.TryWidthRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.WidthRequest <- value
            | Some _, None -> target.WidthRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHeightRequest
            match prevValueOpt, source.TryHeightRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HeightRequest <- value
            | Some _, None -> target.HeightRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsEnabled
            match prevValueOpt, source.TryIsEnabled with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsEnabled <- value
            | Some _, None -> target.IsEnabled <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
        new XamlElement(typeof<Xamarin.Forms.Image>, create, apply, Map.ofArray attribs)

    /// Describes a InputView in the view
    static member InputView(?keyboard: Xamarin.Forms.Keyboard, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: Xamarin.Forms.Thickness, ?backgroundColor: Xamarin.Forms.Color, ?isVisible: bool, ?opacity: double, ?widthRequest: double, ?heightRequest: double, ?isEnabled: bool) = 
        let attribs = [| 
            match keyboard with | None -> () | Some v -> yield ("Keyboard", box v) 
            match horizontalOptions with | None -> () | Some v -> yield ("HorizontalOptions", box v) 
            match verticalOptions with | None -> () | Some v -> yield ("VerticalOptions", box v) 
            match margin with | None -> () | Some v -> yield ("Margin", box v) 
            match backgroundColor with | None -> () | Some v -> yield ("BackgroundColor", box v) 
            match isVisible with | None -> () | Some v -> yield ("IsVisible", box v) 
            match opacity with | None -> () | Some v -> yield ("Opacity", box v) 
            match widthRequest with | None -> () | Some v -> yield ("WidthRequest", box v) 
            match heightRequest with | None -> () | Some v -> yield ("HeightRequest", box v) 
            match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box v) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.InputView"

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.InputView)
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryKeyboard
            match prevValueOpt, source.TryKeyboard with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Keyboard <- value
            | Some _, None -> target.Keyboard <- Xamarin.Forms.Keyboard.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHorizontalOptions
            match prevValueOpt, source.TryHorizontalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HorizontalOptions <- value
            | Some _, None -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryVerticalOptions
            match prevValueOpt, source.TryVerticalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.VerticalOptions <- value
            | Some _, None -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryMargin
            match prevValueOpt, source.TryMargin with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Margin <- value
            | Some _, None -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryBackgroundColor
            match prevValueOpt, source.TryBackgroundColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.BackgroundColor <- value
            | Some _, None -> target.BackgroundColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsVisible
            match prevValueOpt, source.TryIsVisible with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsVisible <- value
            | Some _, None -> target.IsVisible <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryOpacity
            match prevValueOpt, source.TryOpacity with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Opacity <- value
            | Some _, None -> target.Opacity <- 1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryWidthRequest
            match prevValueOpt, source.TryWidthRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.WidthRequest <- value
            | Some _, None -> target.WidthRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHeightRequest
            match prevValueOpt, source.TryHeightRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HeightRequest <- value
            | Some _, None -> target.HeightRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsEnabled
            match prevValueOpt, source.TryIsEnabled with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsEnabled <- value
            | Some _, None -> target.IsEnabled <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
        new XamlElement(typeof<Xamarin.Forms.InputView>, create, apply, Map.ofArray attribs)

    /// Describes a Editor in the view
    static member Editor(?text: string, ?fontSize: double, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?textColor: Xamarin.Forms.Color, ?keyboard: Xamarin.Forms.Keyboard, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: Xamarin.Forms.Thickness, ?backgroundColor: Xamarin.Forms.Color, ?isVisible: bool, ?opacity: double, ?widthRequest: double, ?heightRequest: double, ?isEnabled: bool) = 
        let attribs = [| 
            match text with | None -> () | Some v -> yield ("Text", box v) 
            match fontSize with | None -> () | Some v -> yield ("FontSize", box v) 
            match fontFamily with | None -> () | Some v -> yield ("FontFamily", box v) 
            match fontAttributes with | None -> () | Some v -> yield ("FontAttributes", box v) 
            match textColor with | None -> () | Some v -> yield ("TextColor", box v) 
            match keyboard with | None -> () | Some v -> yield ("Keyboard", box v) 
            match horizontalOptions with | None -> () | Some v -> yield ("HorizontalOptions", box v) 
            match verticalOptions with | None -> () | Some v -> yield ("VerticalOptions", box v) 
            match margin with | None -> () | Some v -> yield ("Margin", box v) 
            match backgroundColor with | None -> () | Some v -> yield ("BackgroundColor", box v) 
            match isVisible with | None -> () | Some v -> yield ("IsVisible", box v) 
            match opacity with | None -> () | Some v -> yield ("Opacity", box v) 
            match widthRequest with | None -> () | Some v -> yield ("WidthRequest", box v) 
            match heightRequest with | None -> () | Some v -> yield ("HeightRequest", box v) 
            match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box v) 
          |]

        let create () =
            box (new Xamarin.Forms.Editor())

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.Editor)
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryText
            match prevValueOpt, source.TryText with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Text <- value
            | Some _, None -> target.Text <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryFontSize
            match prevValueOpt, source.TryFontSize with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.FontSize <- value
            | Some _, None -> target.FontSize <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryFontFamily
            match prevValueOpt, source.TryFontFamily with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.FontFamily <- value
            | Some _, None -> target.FontFamily <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryFontAttributes
            match prevValueOpt, source.TryFontAttributes with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.FontAttributes <- value
            | Some _, None -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryTextColor
            match prevValueOpt, source.TryTextColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.TextColor <- value
            | Some _, None -> target.TextColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryKeyboard
            match prevValueOpt, source.TryKeyboard with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Keyboard <- value
            | Some _, None -> target.Keyboard <- Xamarin.Forms.Keyboard.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHorizontalOptions
            match prevValueOpt, source.TryHorizontalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HorizontalOptions <- value
            | Some _, None -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryVerticalOptions
            match prevValueOpt, source.TryVerticalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.VerticalOptions <- value
            | Some _, None -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryMargin
            match prevValueOpt, source.TryMargin with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Margin <- value
            | Some _, None -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryBackgroundColor
            match prevValueOpt, source.TryBackgroundColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.BackgroundColor <- value
            | Some _, None -> target.BackgroundColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsVisible
            match prevValueOpt, source.TryIsVisible with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsVisible <- value
            | Some _, None -> target.IsVisible <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryOpacity
            match prevValueOpt, source.TryOpacity with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Opacity <- value
            | Some _, None -> target.Opacity <- 1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryWidthRequest
            match prevValueOpt, source.TryWidthRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.WidthRequest <- value
            | Some _, None -> target.WidthRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHeightRequest
            match prevValueOpt, source.TryHeightRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HeightRequest <- value
            | Some _, None -> target.HeightRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsEnabled
            match prevValueOpt, source.TryIsEnabled with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsEnabled <- value
            | Some _, None -> target.IsEnabled <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
        new XamlElement(typeof<Xamarin.Forms.Editor>, create, apply, Map.ofArray attribs)

    /// Describes a Entry in the view
    static member Entry(?text: string, ?placeholder: string, ?horizontalTextAlignment: Xamarin.Forms.TextAlignment, ?fontSize: double, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?textColor: Xamarin.Forms.Color, ?placeholderColor: Xamarin.Forms.Color, ?isPassword: bool, ?keyboard: Xamarin.Forms.Keyboard, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: Xamarin.Forms.Thickness, ?backgroundColor: Xamarin.Forms.Color, ?isVisible: bool, ?opacity: double, ?widthRequest: double, ?heightRequest: double, ?isEnabled: bool) = 
        let attribs = [| 
            match text with | None -> () | Some v -> yield ("Text", box v) 
            match placeholder with | None -> () | Some v -> yield ("Placeholder", box v) 
            match horizontalTextAlignment with | None -> () | Some v -> yield ("HorizontalTextAlignment", box v) 
            match fontSize with | None -> () | Some v -> yield ("FontSize", box v) 
            match fontFamily with | None -> () | Some v -> yield ("FontFamily", box v) 
            match fontAttributes with | None -> () | Some v -> yield ("FontAttributes", box v) 
            match textColor with | None -> () | Some v -> yield ("TextColor", box v) 
            match placeholderColor with | None -> () | Some v -> yield ("PlaceholderColor", box v) 
            match isPassword with | None -> () | Some v -> yield ("IsPassword", box v) 
            match keyboard with | None -> () | Some v -> yield ("Keyboard", box v) 
            match horizontalOptions with | None -> () | Some v -> yield ("HorizontalOptions", box v) 
            match verticalOptions with | None -> () | Some v -> yield ("VerticalOptions", box v) 
            match margin with | None -> () | Some v -> yield ("Margin", box v) 
            match backgroundColor with | None -> () | Some v -> yield ("BackgroundColor", box v) 
            match isVisible with | None -> () | Some v -> yield ("IsVisible", box v) 
            match opacity with | None -> () | Some v -> yield ("Opacity", box v) 
            match widthRequest with | None -> () | Some v -> yield ("WidthRequest", box v) 
            match heightRequest with | None -> () | Some v -> yield ("HeightRequest", box v) 
            match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box v) 
          |]

        let create () =
            box (new Xamarin.Forms.Entry())

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.Entry)
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryText
            match prevValueOpt, source.TryText with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Text <- value
            | Some _, None -> target.Text <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryPlaceholder
            match prevValueOpt, source.TryPlaceholder with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Placeholder <- value
            | Some _, None -> target.Placeholder <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHorizontalTextAlignment
            match prevValueOpt, source.TryHorizontalTextAlignment with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HorizontalTextAlignment <- value
            | Some _, None -> target.HorizontalTextAlignment <- Xamarin.Forms.TextAlignment.Start // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryFontSize
            match prevValueOpt, source.TryFontSize with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.FontSize <- value
            | Some _, None -> target.FontSize <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryFontFamily
            match prevValueOpt, source.TryFontFamily with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.FontFamily <- value
            | Some _, None -> target.FontFamily <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryFontAttributes
            match prevValueOpt, source.TryFontAttributes with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.FontAttributes <- value
            | Some _, None -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryTextColor
            match prevValueOpt, source.TryTextColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.TextColor <- value
            | Some _, None -> target.TextColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryPlaceholderColor
            match prevValueOpt, source.TryPlaceholderColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.PlaceholderColor <- value
            | Some _, None -> target.PlaceholderColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsPassword
            match prevValueOpt, source.TryIsPassword with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsPassword <- value
            | Some _, None -> target.IsPassword <- false // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryKeyboard
            match prevValueOpt, source.TryKeyboard with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Keyboard <- value
            | Some _, None -> target.Keyboard <- Xamarin.Forms.Keyboard.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHorizontalOptions
            match prevValueOpt, source.TryHorizontalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HorizontalOptions <- value
            | Some _, None -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryVerticalOptions
            match prevValueOpt, source.TryVerticalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.VerticalOptions <- value
            | Some _, None -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryMargin
            match prevValueOpt, source.TryMargin with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Margin <- value
            | Some _, None -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryBackgroundColor
            match prevValueOpt, source.TryBackgroundColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.BackgroundColor <- value
            | Some _, None -> target.BackgroundColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsVisible
            match prevValueOpt, source.TryIsVisible with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsVisible <- value
            | Some _, None -> target.IsVisible <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryOpacity
            match prevValueOpt, source.TryOpacity with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Opacity <- value
            | Some _, None -> target.Opacity <- 1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryWidthRequest
            match prevValueOpt, source.TryWidthRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.WidthRequest <- value
            | Some _, None -> target.WidthRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHeightRequest
            match prevValueOpt, source.TryHeightRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HeightRequest <- value
            | Some _, None -> target.HeightRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsEnabled
            match prevValueOpt, source.TryIsEnabled with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsEnabled <- value
            | Some _, None -> target.IsEnabled <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
        new XamlElement(typeof<Xamarin.Forms.Entry>, create, apply, Map.ofArray attribs)

    /// Describes a Label in the view
    static member Label(?text: string, ?horizontalTextAlignment: Xamarin.Forms.TextAlignment, ?verticalTextAlignment: Xamarin.Forms.TextAlignment, ?fontSize: double, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?textColor: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: Xamarin.Forms.Thickness, ?backgroundColor: Xamarin.Forms.Color, ?isVisible: bool, ?opacity: double, ?widthRequest: double, ?heightRequest: double, ?isEnabled: bool) = 
        let attribs = [| 
            match text with | None -> () | Some v -> yield ("Text", box v) 
            match horizontalTextAlignment with | None -> () | Some v -> yield ("HorizontalTextAlignment", box v) 
            match verticalTextAlignment with | None -> () | Some v -> yield ("VerticalTextAlignment", box v) 
            match fontSize with | None -> () | Some v -> yield ("FontSize", box v) 
            match fontFamily with | None -> () | Some v -> yield ("FontFamily", box v) 
            match fontAttributes with | None -> () | Some v -> yield ("FontAttributes", box v) 
            match textColor with | None -> () | Some v -> yield ("TextColor", box v) 
            match horizontalOptions with | None -> () | Some v -> yield ("HorizontalOptions", box v) 
            match verticalOptions with | None -> () | Some v -> yield ("VerticalOptions", box v) 
            match margin with | None -> () | Some v -> yield ("Margin", box v) 
            match backgroundColor with | None -> () | Some v -> yield ("BackgroundColor", box v) 
            match isVisible with | None -> () | Some v -> yield ("IsVisible", box v) 
            match opacity with | None -> () | Some v -> yield ("Opacity", box v) 
            match widthRequest with | None -> () | Some v -> yield ("WidthRequest", box v) 
            match heightRequest with | None -> () | Some v -> yield ("HeightRequest", box v) 
            match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box v) 
          |]

        let create () =
            box (new Xamarin.Forms.Label())

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.Label)
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryText
            match prevValueOpt, source.TryText with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Text <- value
            | Some _, None -> target.Text <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHorizontalTextAlignment
            match prevValueOpt, source.TryHorizontalTextAlignment with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HorizontalTextAlignment <- value
            | Some _, None -> target.HorizontalTextAlignment <- Xamarin.Forms.TextAlignment.Start // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryVerticalTextAlignment
            match prevValueOpt, source.TryVerticalTextAlignment with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.VerticalTextAlignment <- value
            | Some _, None -> target.VerticalTextAlignment <- Xamarin.Forms.TextAlignment.Start // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryFontSize
            match prevValueOpt, source.TryFontSize with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.FontSize <- value
            | Some _, None -> target.FontSize <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryFontFamily
            match prevValueOpt, source.TryFontFamily with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.FontFamily <- value
            | Some _, None -> target.FontFamily <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryFontAttributes
            match prevValueOpt, source.TryFontAttributes with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.FontAttributes <- value
            | Some _, None -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryTextColor
            match prevValueOpt, source.TryTextColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.TextColor <- value
            | Some _, None -> target.TextColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHorizontalOptions
            match prevValueOpt, source.TryHorizontalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HorizontalOptions <- value
            | Some _, None -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryVerticalOptions
            match prevValueOpt, source.TryVerticalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.VerticalOptions <- value
            | Some _, None -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryMargin
            match prevValueOpt, source.TryMargin with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Margin <- value
            | Some _, None -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryBackgroundColor
            match prevValueOpt, source.TryBackgroundColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.BackgroundColor <- value
            | Some _, None -> target.BackgroundColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsVisible
            match prevValueOpt, source.TryIsVisible with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsVisible <- value
            | Some _, None -> target.IsVisible <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryOpacity
            match prevValueOpt, source.TryOpacity with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Opacity <- value
            | Some _, None -> target.Opacity <- 1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryWidthRequest
            match prevValueOpt, source.TryWidthRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.WidthRequest <- value
            | Some _, None -> target.WidthRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHeightRequest
            match prevValueOpt, source.TryHeightRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HeightRequest <- value
            | Some _, None -> target.HeightRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsEnabled
            match prevValueOpt, source.TryIsEnabled with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsEnabled <- value
            | Some _, None -> target.IsEnabled <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
        new XamlElement(typeof<Xamarin.Forms.Label>, create, apply, Map.ofArray attribs)

    /// Describes a Layout in the view
    static member Layout(?isClippedToBounds: bool, ?padding: Xamarin.Forms.Thickness, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: Xamarin.Forms.Thickness, ?backgroundColor: Xamarin.Forms.Color, ?isVisible: bool, ?opacity: double, ?widthRequest: double, ?heightRequest: double, ?isEnabled: bool) = 
        let attribs = [| 
            match isClippedToBounds with | None -> () | Some v -> yield ("IsClippedToBounds", box v) 
            match padding with | None -> () | Some v -> yield ("Padding", box v) 
            match horizontalOptions with | None -> () | Some v -> yield ("HorizontalOptions", box v) 
            match verticalOptions with | None -> () | Some v -> yield ("VerticalOptions", box v) 
            match margin with | None -> () | Some v -> yield ("Margin", box v) 
            match backgroundColor with | None -> () | Some v -> yield ("BackgroundColor", box v) 
            match isVisible with | None -> () | Some v -> yield ("IsVisible", box v) 
            match opacity with | None -> () | Some v -> yield ("Opacity", box v) 
            match widthRequest with | None -> () | Some v -> yield ("WidthRequest", box v) 
            match heightRequest with | None -> () | Some v -> yield ("HeightRequest", box v) 
            match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box v) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.Layout"

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.Layout)
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsClippedToBounds
            match prevValueOpt, source.TryIsClippedToBounds with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsClippedToBounds <- value
            | Some _, None -> target.IsClippedToBounds <- false // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryPadding
            match prevValueOpt, source.TryPadding with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Padding <- value
            | Some _, None -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHorizontalOptions
            match prevValueOpt, source.TryHorizontalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HorizontalOptions <- value
            | Some _, None -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryVerticalOptions
            match prevValueOpt, source.TryVerticalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.VerticalOptions <- value
            | Some _, None -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryMargin
            match prevValueOpt, source.TryMargin with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Margin <- value
            | Some _, None -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryBackgroundColor
            match prevValueOpt, source.TryBackgroundColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.BackgroundColor <- value
            | Some _, None -> target.BackgroundColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsVisible
            match prevValueOpt, source.TryIsVisible with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsVisible <- value
            | Some _, None -> target.IsVisible <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryOpacity
            match prevValueOpt, source.TryOpacity with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Opacity <- value
            | Some _, None -> target.Opacity <- 1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryWidthRequest
            match prevValueOpt, source.TryWidthRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.WidthRequest <- value
            | Some _, None -> target.WidthRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHeightRequest
            match prevValueOpt, source.TryHeightRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HeightRequest <- value
            | Some _, None -> target.HeightRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsEnabled
            match prevValueOpt, source.TryIsEnabled with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsEnabled <- value
            | Some _, None -> target.IsEnabled <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
        new XamlElement(typeof<Xamarin.Forms.Layout>, create, apply, Map.ofArray attribs)

    /// Describes a StackLayout in the view
    static member StackLayout(?children: System.Collections.Generic.IList<XamlElement>, ?orientation: Xamarin.Forms.StackOrientation, ?spacing: double, ?isClippedToBounds: bool, ?padding: Xamarin.Forms.Thickness, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: Xamarin.Forms.Thickness, ?backgroundColor: Xamarin.Forms.Color, ?isVisible: bool, ?opacity: double, ?widthRequest: double, ?heightRequest: double, ?isEnabled: bool) = 
        let attribs = [| 
            match children with | None -> () | Some v -> yield ("Children", box v) 
            match orientation with | None -> () | Some v -> yield ("Orientation", box v) 
            match spacing with | None -> () | Some v -> yield ("Spacing", box v) 
            match isClippedToBounds with | None -> () | Some v -> yield ("IsClippedToBounds", box v) 
            match padding with | None -> () | Some v -> yield ("Padding", box v) 
            match horizontalOptions with | None -> () | Some v -> yield ("HorizontalOptions", box v) 
            match verticalOptions with | None -> () | Some v -> yield ("VerticalOptions", box v) 
            match margin with | None -> () | Some v -> yield ("Margin", box v) 
            match backgroundColor with | None -> () | Some v -> yield ("BackgroundColor", box v) 
            match isVisible with | None -> () | Some v -> yield ("IsVisible", box v) 
            match opacity with | None -> () | Some v -> yield ("Opacity", box v) 
            match widthRequest with | None -> () | Some v -> yield ("WidthRequest", box v) 
            match heightRequest with | None -> () | Some v -> yield ("HeightRequest", box v) 
            match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box v) 
          |]

        let create () =
            box (new Xamarin.Forms.StackLayout())

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.StackLayout)
            if (source.Children = null || source.Children.Count = 0) then
                match target.Children with
                | null -> ()
                | children -> children.Clear() 
            else
                // Remove the excess children
                while (target.Children.Count > source.Children.Count) do
                    target.Children.RemoveAt(target.Children.Count - 1)

                // Count the existing children
                let n = target.Children.Count;

                // Adjust the existing children and create the new children
                for i in 0 .. source.Children.Count-1 do
                    let newChild = source.Children.[i]
                    let prevChildOpt = match prevOpt with None -> None | Some prev -> match prev.TryChildren with None -> None | Some coll when i < coll.Count && i < n -> Some coll.[i] | _ -> None
                    let targetChild = 
                        if (match prevChildOpt with None -> true | Some prevChild -> not (obj.ReferenceEquals(prevChild, newChild))) then
                            let mustCreate = (i >= n || match prevChildOpt with None -> true | Some prevChild -> newChild.TargetType <> prevChild.TargetType)
                            if mustCreate then
                                let targetChild = newChild.CreateAsView()
                                if i >= n then
                                    target.Children.Insert(i, targetChild)
                                else
                                    target.Children.[i] <- targetChild
                                targetChild
                            else
                                let targetChild = target.Children.[i]
                                newChild.ApplyIncremental(prevChildOpt.Value, targetChild)
                                targetChild
                        else
                            target.Children.[i]
                    // note, setting attached properties should go here
                    ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryOrientation
            match prevValueOpt, source.TryOrientation with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Orientation <- value
            | Some _, None -> target.Orientation <- Xamarin.Forms.StackOrientation.Vertical // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TrySpacing
            match prevValueOpt, source.TrySpacing with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Spacing <- value
            | Some _, None -> target.Spacing <- 6.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsClippedToBounds
            match prevValueOpt, source.TryIsClippedToBounds with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsClippedToBounds <- value
            | Some _, None -> target.IsClippedToBounds <- false // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryPadding
            match prevValueOpt, source.TryPadding with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Padding <- value
            | Some _, None -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHorizontalOptions
            match prevValueOpt, source.TryHorizontalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HorizontalOptions <- value
            | Some _, None -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryVerticalOptions
            match prevValueOpt, source.TryVerticalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.VerticalOptions <- value
            | Some _, None -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryMargin
            match prevValueOpt, source.TryMargin with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Margin <- value
            | Some _, None -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryBackgroundColor
            match prevValueOpt, source.TryBackgroundColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.BackgroundColor <- value
            | Some _, None -> target.BackgroundColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsVisible
            match prevValueOpt, source.TryIsVisible with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsVisible <- value
            | Some _, None -> target.IsVisible <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryOpacity
            match prevValueOpt, source.TryOpacity with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Opacity <- value
            | Some _, None -> target.Opacity <- 1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryWidthRequest
            match prevValueOpt, source.TryWidthRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.WidthRequest <- value
            | Some _, None -> target.WidthRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHeightRequest
            match prevValueOpt, source.TryHeightRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HeightRequest <- value
            | Some _, None -> target.HeightRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsEnabled
            match prevValueOpt, source.TryIsEnabled with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsEnabled <- value
            | Some _, None -> target.IsEnabled <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
        new XamlElement(typeof<Xamarin.Forms.StackLayout>, create, apply, Map.ofArray attribs)

    /// Describes a TimePicker in the view
    static member TimePicker(?time: System.TimeSpan, ?format: string, ?textColor: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: Xamarin.Forms.Thickness, ?backgroundColor: Xamarin.Forms.Color, ?isVisible: bool, ?opacity: double, ?widthRequest: double, ?heightRequest: double, ?isEnabled: bool) = 
        let attribs = [| 
            match time with | None -> () | Some v -> yield ("Time", box v) 
            match format with | None -> () | Some v -> yield ("Format", box v) 
            match textColor with | None -> () | Some v -> yield ("TextColor", box v) 
            match horizontalOptions with | None -> () | Some v -> yield ("HorizontalOptions", box v) 
            match verticalOptions with | None -> () | Some v -> yield ("VerticalOptions", box v) 
            match margin with | None -> () | Some v -> yield ("Margin", box v) 
            match backgroundColor with | None -> () | Some v -> yield ("BackgroundColor", box v) 
            match isVisible with | None -> () | Some v -> yield ("IsVisible", box v) 
            match opacity with | None -> () | Some v -> yield ("Opacity", box v) 
            match widthRequest with | None -> () | Some v -> yield ("WidthRequest", box v) 
            match heightRequest with | None -> () | Some v -> yield ("HeightRequest", box v) 
            match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box v) 
          |]

        let create () =
            box (new Xamarin.Forms.TimePicker())

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.TimePicker)
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryTime
            match prevValueOpt, source.TryTime with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Time <- value
            | Some _, None -> target.Time <- new System.TimeSpan() // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryFormat
            match prevValueOpt, source.TryFormat with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Format <- value
            | Some _, None -> target.Format <- "t" // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryTextColor
            match prevValueOpt, source.TryTextColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.TextColor <- value
            | Some _, None -> target.TextColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHorizontalOptions
            match prevValueOpt, source.TryHorizontalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HorizontalOptions <- value
            | Some _, None -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryVerticalOptions
            match prevValueOpt, source.TryVerticalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.VerticalOptions <- value
            | Some _, None -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryMargin
            match prevValueOpt, source.TryMargin with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Margin <- value
            | Some _, None -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryBackgroundColor
            match prevValueOpt, source.TryBackgroundColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.BackgroundColor <- value
            | Some _, None -> target.BackgroundColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsVisible
            match prevValueOpt, source.TryIsVisible with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsVisible <- value
            | Some _, None -> target.IsVisible <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryOpacity
            match prevValueOpt, source.TryOpacity with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Opacity <- value
            | Some _, None -> target.Opacity <- 1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryWidthRequest
            match prevValueOpt, source.TryWidthRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.WidthRequest <- value
            | Some _, None -> target.WidthRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHeightRequest
            match prevValueOpt, source.TryHeightRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HeightRequest <- value
            | Some _, None -> target.HeightRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsEnabled
            match prevValueOpt, source.TryIsEnabled with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsEnabled <- value
            | Some _, None -> target.IsEnabled <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
        new XamlElement(typeof<Xamarin.Forms.TimePicker>, create, apply, Map.ofArray attribs)

    /// Describes a WebView in the view
    static member WebView(?webSource: Xamarin.Forms.WebViewSource, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: Xamarin.Forms.Thickness, ?backgroundColor: Xamarin.Forms.Color, ?isVisible: bool, ?opacity: double, ?widthRequest: double, ?heightRequest: double, ?isEnabled: bool) = 
        let attribs = [| 
            match webSource with | None -> () | Some v -> yield ("WebSource", box v) 
            match horizontalOptions with | None -> () | Some v -> yield ("HorizontalOptions", box v) 
            match verticalOptions with | None -> () | Some v -> yield ("VerticalOptions", box v) 
            match margin with | None -> () | Some v -> yield ("Margin", box v) 
            match backgroundColor with | None -> () | Some v -> yield ("BackgroundColor", box v) 
            match isVisible with | None -> () | Some v -> yield ("IsVisible", box v) 
            match opacity with | None -> () | Some v -> yield ("Opacity", box v) 
            match widthRequest with | None -> () | Some v -> yield ("WidthRequest", box v) 
            match heightRequest with | None -> () | Some v -> yield ("HeightRequest", box v) 
            match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box v) 
          |]

        let create () =
            box (new Xamarin.Forms.WebView())

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.WebView)
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryWebSource
            match prevValueOpt, source.TryWebSource with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Source <- value
            | Some _, None -> target.Source <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHorizontalOptions
            match prevValueOpt, source.TryHorizontalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HorizontalOptions <- value
            | Some _, None -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryVerticalOptions
            match prevValueOpt, source.TryVerticalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.VerticalOptions <- value
            | Some _, None -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryMargin
            match prevValueOpt, source.TryMargin with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Margin <- value
            | Some _, None -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryBackgroundColor
            match prevValueOpt, source.TryBackgroundColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.BackgroundColor <- value
            | Some _, None -> target.BackgroundColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsVisible
            match prevValueOpt, source.TryIsVisible with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsVisible <- value
            | Some _, None -> target.IsVisible <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryOpacity
            match prevValueOpt, source.TryOpacity with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Opacity <- value
            | Some _, None -> target.Opacity <- 1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryWidthRequest
            match prevValueOpt, source.TryWidthRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.WidthRequest <- value
            | Some _, None -> target.WidthRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHeightRequest
            match prevValueOpt, source.TryHeightRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HeightRequest <- value
            | Some _, None -> target.HeightRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsEnabled
            match prevValueOpt, source.TryIsEnabled with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsEnabled <- value
            | Some _, None -> target.IsEnabled <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
        new XamlElement(typeof<Xamarin.Forms.WebView>, create, apply, Map.ofArray attribs)

    /// Describes a Page in the view
    static member Page(?title: string, ?padding: Xamarin.Forms.Thickness, ?backgroundColor: Xamarin.Forms.Color, ?isVisible: bool, ?opacity: double, ?widthRequest: double, ?heightRequest: double, ?isEnabled: bool) = 
        let attribs = [| 
            match title with | None -> () | Some v -> yield ("Title", box v) 
            match padding with | None -> () | Some v -> yield ("Padding", box v) 
            match backgroundColor with | None -> () | Some v -> yield ("BackgroundColor", box v) 
            match isVisible with | None -> () | Some v -> yield ("IsVisible", box v) 
            match opacity with | None -> () | Some v -> yield ("Opacity", box v) 
            match widthRequest with | None -> () | Some v -> yield ("WidthRequest", box v) 
            match heightRequest with | None -> () | Some v -> yield ("HeightRequest", box v) 
            match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box v) 
          |]

        let create () =
            box (new Xamarin.Forms.Page())

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.Page)
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryTitle
            match prevValueOpt, source.TryTitle with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Title <- value
            | Some _, None -> target.Title <- "" // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryPadding
            match prevValueOpt, source.TryPadding with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Padding <- value
            | Some _, None -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryBackgroundColor
            match prevValueOpt, source.TryBackgroundColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.BackgroundColor <- value
            | Some _, None -> target.BackgroundColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsVisible
            match prevValueOpt, source.TryIsVisible with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsVisible <- value
            | Some _, None -> target.IsVisible <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryOpacity
            match prevValueOpt, source.TryOpacity with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Opacity <- value
            | Some _, None -> target.Opacity <- 1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryWidthRequest
            match prevValueOpt, source.TryWidthRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.WidthRequest <- value
            | Some _, None -> target.WidthRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHeightRequest
            match prevValueOpt, source.TryHeightRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HeightRequest <- value
            | Some _, None -> target.HeightRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsEnabled
            match prevValueOpt, source.TryIsEnabled with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsEnabled <- value
            | Some _, None -> target.IsEnabled <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
        new XamlElement(typeof<Xamarin.Forms.Page>, create, apply, Map.ofArray attribs)

    /// Describes a CarouselPage in the view
    static member CarouselPage(?itemsSource: System.Collections.IEnumerable, ?itemTemplate: Xamarin.Forms.DataTemplate, ?selectedItem: System.Object, ?currentPage: XamlElement, ?title: string, ?padding: Xamarin.Forms.Thickness, ?backgroundColor: Xamarin.Forms.Color, ?isVisible: bool, ?opacity: double, ?widthRequest: double, ?heightRequest: double, ?isEnabled: bool) = 
        let attribs = [| 
            match itemsSource with | None -> () | Some v -> yield ("ItemsSource", box v) 
            match itemTemplate with | None -> () | Some v -> yield ("ItemTemplate", box v) 
            match selectedItem with | None -> () | Some v -> yield ("SelectedItem", box v) 
            match currentPage with | None -> () | Some v -> yield ("CurrentPage", box v) 
            match title with | None -> () | Some v -> yield ("Title", box v) 
            match padding with | None -> () | Some v -> yield ("Padding", box v) 
            match backgroundColor with | None -> () | Some v -> yield ("BackgroundColor", box v) 
            match isVisible with | None -> () | Some v -> yield ("IsVisible", box v) 
            match opacity with | None -> () | Some v -> yield ("Opacity", box v) 
            match widthRequest with | None -> () | Some v -> yield ("WidthRequest", box v) 
            match heightRequest with | None -> () | Some v -> yield ("HeightRequest", box v) 
            match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box v) 
          |]

        let create () =
            box (new Xamarin.Forms.CarouselPage())

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.CarouselPage)
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryItemsSource
            match prevValueOpt, source.TryItemsSource with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.ItemsSource <- value
            | Some _, None -> target.ItemsSource <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryItemTemplate
            match prevValueOpt, source.TryItemTemplate with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.ItemTemplate <- value
            | Some _, None -> target.ItemTemplate <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TrySelectedItem
            match prevValueOpt, source.TrySelectedItem with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.SelectedItem <- value
            | Some _, None -> target.SelectedItem <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevChildOpt = match prevOpt with None -> None | Some prev -> prev.TryCurrentPage
            match prevChildOpt, source.TryCurrentPage with
            // For structured objects, the only caching is based on reference equality
            | Some prevChild, Some newChild when obj.ReferenceEquals(prevChild, newChild) -> ()
            | Some prevChild, Some newChild ->
                newChild.ApplyIncremental(prevChild, target.CurrentPage)
            | None, Some newChild ->
                target.CurrentPage <- newChild.CreateAsContentPage()
            | _, None ->
                target.CurrentPage <- null;
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryTitle
            match prevValueOpt, source.TryTitle with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Title <- value
            | Some _, None -> target.Title <- "" // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryPadding
            match prevValueOpt, source.TryPadding with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Padding <- value
            | Some _, None -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryBackgroundColor
            match prevValueOpt, source.TryBackgroundColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.BackgroundColor <- value
            | Some _, None -> target.BackgroundColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsVisible
            match prevValueOpt, source.TryIsVisible with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsVisible <- value
            | Some _, None -> target.IsVisible <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryOpacity
            match prevValueOpt, source.TryOpacity with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Opacity <- value
            | Some _, None -> target.Opacity <- 1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryWidthRequest
            match prevValueOpt, source.TryWidthRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.WidthRequest <- value
            | Some _, None -> target.WidthRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHeightRequest
            match prevValueOpt, source.TryHeightRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HeightRequest <- value
            | Some _, None -> target.HeightRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsEnabled
            match prevValueOpt, source.TryIsEnabled with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsEnabled <- value
            | Some _, None -> target.IsEnabled <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
        new XamlElement(typeof<Xamarin.Forms.CarouselPage>, create, apply, Map.ofArray attribs)

    /// Describes a ContentPage in the view
    static member ContentPage(?content: XamlElement, ?title: string, ?padding: Xamarin.Forms.Thickness, ?backgroundColor: Xamarin.Forms.Color, ?isVisible: bool, ?opacity: double, ?widthRequest: double, ?heightRequest: double, ?isEnabled: bool) = 
        let attribs = [| 
            match content with | None -> () | Some v -> yield ("Content", box v) 
            match title with | None -> () | Some v -> yield ("Title", box v) 
            match padding with | None -> () | Some v -> yield ("Padding", box v) 
            match backgroundColor with | None -> () | Some v -> yield ("BackgroundColor", box v) 
            match isVisible with | None -> () | Some v -> yield ("IsVisible", box v) 
            match opacity with | None -> () | Some v -> yield ("Opacity", box v) 
            match widthRequest with | None -> () | Some v -> yield ("WidthRequest", box v) 
            match heightRequest with | None -> () | Some v -> yield ("HeightRequest", box v) 
            match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box v) 
          |]

        let create () =
            box (new Xamarin.Forms.ContentPage())

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.ContentPage)
            let prevChildOpt = match prevOpt with None -> None | Some prev -> prev.TryContent
            match prevChildOpt, source.TryContent with
            // For structured objects, the only caching is based on reference equality
            | Some prevChild, Some newChild when obj.ReferenceEquals(prevChild, newChild) -> ()
            | Some prevChild, Some newChild ->
                newChild.ApplyIncremental(prevChild, target.Content)
            | None, Some newChild ->
                target.Content <- newChild.CreateAsView()
            | _, None ->
                target.Content <- null;
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryTitle
            match prevValueOpt, source.TryTitle with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Title <- value
            | Some _, None -> target.Title <- "" // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryPadding
            match prevValueOpt, source.TryPadding with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Padding <- value
            | Some _, None -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryBackgroundColor
            match prevValueOpt, source.TryBackgroundColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.BackgroundColor <- value
            | Some _, None -> target.BackgroundColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsVisible
            match prevValueOpt, source.TryIsVisible with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsVisible <- value
            | Some _, None -> target.IsVisible <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryOpacity
            match prevValueOpt, source.TryOpacity with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Opacity <- value
            | Some _, None -> target.Opacity <- 1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryWidthRequest
            match prevValueOpt, source.TryWidthRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.WidthRequest <- value
            | Some _, None -> target.WidthRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHeightRequest
            match prevValueOpt, source.TryHeightRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HeightRequest <- value
            | Some _, None -> target.HeightRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsEnabled
            match prevValueOpt, source.TryIsEnabled with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsEnabled <- value
            | Some _, None -> target.IsEnabled <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
        new XamlElement(typeof<Xamarin.Forms.ContentPage>, create, apply, Map.ofArray attribs)

    /// Describes a MasterDetailPage in the view
    static member MasterDetailPage(?master: XamlElement, ?detail: XamlElement, ?title: string, ?padding: Xamarin.Forms.Thickness, ?backgroundColor: Xamarin.Forms.Color, ?isVisible: bool, ?opacity: double, ?widthRequest: double, ?heightRequest: double, ?isEnabled: bool) = 
        let attribs = [| 
            match master with | None -> () | Some v -> yield ("Master", box v) 
            match detail with | None -> () | Some v -> yield ("Detail", box v) 
            match title with | None -> () | Some v -> yield ("Title", box v) 
            match padding with | None -> () | Some v -> yield ("Padding", box v) 
            match backgroundColor with | None -> () | Some v -> yield ("BackgroundColor", box v) 
            match isVisible with | None -> () | Some v -> yield ("IsVisible", box v) 
            match opacity with | None -> () | Some v -> yield ("Opacity", box v) 
            match widthRequest with | None -> () | Some v -> yield ("WidthRequest", box v) 
            match heightRequest with | None -> () | Some v -> yield ("HeightRequest", box v) 
            match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box v) 
          |]

        let create () =
            box (new Xamarin.Forms.MasterDetailPage())

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.MasterDetailPage)
            let prevChildOpt = match prevOpt with None -> None | Some prev -> prev.TryMaster
            match prevChildOpt, source.TryMaster with
            // For structured objects, the only caching is based on reference equality
            | Some prevChild, Some newChild when obj.ReferenceEquals(prevChild, newChild) -> ()
            | Some prevChild, Some newChild ->
                newChild.ApplyIncremental(prevChild, target.Master)
            | None, Some newChild ->
                target.Master <- newChild.CreateAsPage()
            | _, None ->
                target.Master <- null;
            let prevChildOpt = match prevOpt with None -> None | Some prev -> prev.TryDetail
            match prevChildOpt, source.TryDetail with
            // For structured objects, the only caching is based on reference equality
            | Some prevChild, Some newChild when obj.ReferenceEquals(prevChild, newChild) -> ()
            | Some prevChild, Some newChild ->
                newChild.ApplyIncremental(prevChild, target.Detail)
            | None, Some newChild ->
                target.Detail <- newChild.CreateAsPage()
            | _, None ->
                target.Detail <- null;
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryTitle
            match prevValueOpt, source.TryTitle with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Title <- value
            | Some _, None -> target.Title <- "" // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryPadding
            match prevValueOpt, source.TryPadding with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Padding <- value
            | Some _, None -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryBackgroundColor
            match prevValueOpt, source.TryBackgroundColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.BackgroundColor <- value
            | Some _, None -> target.BackgroundColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsVisible
            match prevValueOpt, source.TryIsVisible with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsVisible <- value
            | Some _, None -> target.IsVisible <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryOpacity
            match prevValueOpt, source.TryOpacity with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Opacity <- value
            | Some _, None -> target.Opacity <- 1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryWidthRequest
            match prevValueOpt, source.TryWidthRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.WidthRequest <- value
            | Some _, None -> target.WidthRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHeightRequest
            match prevValueOpt, source.TryHeightRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HeightRequest <- value
            | Some _, None -> target.HeightRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsEnabled
            match prevValueOpt, source.TryIsEnabled with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsEnabled <- value
            | Some _, None -> target.IsEnabled <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
        new XamlElement(typeof<Xamarin.Forms.MasterDetailPage>, create, apply, Map.ofArray attribs)

    /// Describes a TabbedPage in the view
    static member TabbedPage(?itemsSource: System.Collections.IEnumerable, ?itemTemplate: Xamarin.Forms.DataTemplate, ?selectedItem: System.Object, ?title: string, ?padding: Xamarin.Forms.Thickness, ?backgroundColor: Xamarin.Forms.Color, ?isVisible: bool, ?opacity: double, ?widthRequest: double, ?heightRequest: double, ?isEnabled: bool) = 
        let attribs = [| 
            match itemsSource with | None -> () | Some v -> yield ("ItemsSource", box v) 
            match itemTemplate with | None -> () | Some v -> yield ("ItemTemplate", box v) 
            match selectedItem with | None -> () | Some v -> yield ("SelectedItem", box v) 
            match title with | None -> () | Some v -> yield ("Title", box v) 
            match padding with | None -> () | Some v -> yield ("Padding", box v) 
            match backgroundColor with | None -> () | Some v -> yield ("BackgroundColor", box v) 
            match isVisible with | None -> () | Some v -> yield ("IsVisible", box v) 
            match opacity with | None -> () | Some v -> yield ("Opacity", box v) 
            match widthRequest with | None -> () | Some v -> yield ("WidthRequest", box v) 
            match heightRequest with | None -> () | Some v -> yield ("HeightRequest", box v) 
            match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box v) 
          |]

        let create () =
            box (new Xamarin.Forms.TabbedPage())

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.TabbedPage)
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryItemsSource
            match prevValueOpt, source.TryItemsSource with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.ItemsSource <- value
            | Some _, None -> target.ItemsSource <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryItemTemplate
            match prevValueOpt, source.TryItemTemplate with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.ItemTemplate <- value
            | Some _, None -> target.ItemTemplate <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TrySelectedItem
            match prevValueOpt, source.TrySelectedItem with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.SelectedItem <- value
            | Some _, None -> target.SelectedItem <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryTitle
            match prevValueOpt, source.TryTitle with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Title <- value
            | Some _, None -> target.Title <- "" // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryPadding
            match prevValueOpt, source.TryPadding with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Padding <- value
            | Some _, None -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryBackgroundColor
            match prevValueOpt, source.TryBackgroundColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.BackgroundColor <- value
            | Some _, None -> target.BackgroundColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsVisible
            match prevValueOpt, source.TryIsVisible with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsVisible <- value
            | Some _, None -> target.IsVisible <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryOpacity
            match prevValueOpt, source.TryOpacity with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Opacity <- value
            | Some _, None -> target.Opacity <- 1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryWidthRequest
            match prevValueOpt, source.TryWidthRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.WidthRequest <- value
            | Some _, None -> target.WidthRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHeightRequest
            match prevValueOpt, source.TryHeightRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HeightRequest <- value
            | Some _, None -> target.HeightRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsEnabled
            match prevValueOpt, source.TryIsEnabled with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsEnabled <- value
            | Some _, None -> target.IsEnabled <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
        new XamlElement(typeof<Xamarin.Forms.TabbedPage>, create, apply, Map.ofArray attribs)

    /// Describes a Cell in the view
    static member Cell(?height: double, ?isEnabled: bool) = 
        let attribs = [| 
            match height with | None -> () | Some v -> yield ("Height", box v) 
            match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box v) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.Cell"

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.Cell)
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHeight
            match prevValueOpt, source.TryHeight with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Height <- value
            | Some _, None -> target.Height <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsEnabled
            match prevValueOpt, source.TryIsEnabled with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsEnabled <- value
            | Some _, None -> target.IsEnabled <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
        new XamlElement(typeof<Xamarin.Forms.Cell>, create, apply, Map.ofArray attribs)

    /// Describes a TextCell in the view
    static member TextCell(?text: string, ?textDetail: string, ?textColor: Xamarin.Forms.Color, ?textDetailColor: Xamarin.Forms.Color, ?command: System.Windows.Input.ICommand, ?commandParameter: System.Object, ?height: double, ?isEnabled: bool) = 
        let attribs = [| 
            match text with | None -> () | Some v -> yield ("Text", box v) 
            match textDetail with | None -> () | Some v -> yield ("TextDetail", box v) 
            match textColor with | None -> () | Some v -> yield ("TextColor", box v) 
            match textDetailColor with | None -> () | Some v -> yield ("TextDetailColor", box v) 
            match command with | None -> () | Some v -> yield ("Command", box v) 
            match commandParameter with | None -> () | Some v -> yield ("CommandParameter", box v) 
            match height with | None -> () | Some v -> yield ("Height", box v) 
            match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box v) 
          |]

        let create () =
            box (new Xamarin.Forms.TextCell())

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.TextCell)
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryText
            match prevValueOpt, source.TryText with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Text <- value
            | Some _, None -> target.Text <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryTextDetail
            match prevValueOpt, source.TryTextDetail with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Detail <- value
            | Some _, None -> target.Detail <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryTextColor
            match prevValueOpt, source.TryTextColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.TextColor <- value
            | Some _, None -> target.TextColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryTextDetailColor
            match prevValueOpt, source.TryTextDetailColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.DetailColor <- value
            | Some _, None -> target.DetailColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryCommand
            match prevValueOpt, source.TryCommand with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Command <- value
            | Some _, None -> target.Command <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryCommandParameter
            match prevValueOpt, source.TryCommandParameter with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.CommandParameter <- value
            | Some _, None -> target.CommandParameter <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHeight
            match prevValueOpt, source.TryHeight with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Height <- value
            | Some _, None -> target.Height <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsEnabled
            match prevValueOpt, source.TryIsEnabled with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsEnabled <- value
            | Some _, None -> target.IsEnabled <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
        new XamlElement(typeof<Xamarin.Forms.TextCell>, create, apply, Map.ofArray attribs)

    /// Describes a ImageCell in the view
    static member ImageCell(?imageSource: Xamarin.Forms.ImageSource, ?text: string, ?textDetail: string, ?textColor: Xamarin.Forms.Color, ?textDetailColor: Xamarin.Forms.Color, ?command: System.Windows.Input.ICommand, ?commandParameter: System.Object, ?height: double, ?isEnabled: bool) = 
        let attribs = [| 
            match imageSource with | None -> () | Some v -> yield ("ImageSource", box v) 
            match text with | None -> () | Some v -> yield ("Text", box v) 
            match textDetail with | None -> () | Some v -> yield ("TextDetail", box v) 
            match textColor with | None -> () | Some v -> yield ("TextColor", box v) 
            match textDetailColor with | None -> () | Some v -> yield ("TextDetailColor", box v) 
            match command with | None -> () | Some v -> yield ("Command", box v) 
            match commandParameter with | None -> () | Some v -> yield ("CommandParameter", box v) 
            match height with | None -> () | Some v -> yield ("Height", box v) 
            match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box v) 
          |]

        let create () =
            box (new Xamarin.Forms.ImageCell())

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.ImageCell)
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryImageSource
            match prevValueOpt, source.TryImageSource with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.ImageSource <- value
            | Some _, None -> target.ImageSource <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryText
            match prevValueOpt, source.TryText with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Text <- value
            | Some _, None -> target.Text <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryTextDetail
            match prevValueOpt, source.TryTextDetail with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Detail <- value
            | Some _, None -> target.Detail <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryTextColor
            match prevValueOpt, source.TryTextColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.TextColor <- value
            | Some _, None -> target.TextColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryTextDetailColor
            match prevValueOpt, source.TryTextDetailColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.DetailColor <- value
            | Some _, None -> target.DetailColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryCommand
            match prevValueOpt, source.TryCommand with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Command <- value
            | Some _, None -> target.Command <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryCommandParameter
            match prevValueOpt, source.TryCommandParameter with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.CommandParameter <- value
            | Some _, None -> target.CommandParameter <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHeight
            match prevValueOpt, source.TryHeight with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Height <- value
            | Some _, None -> target.Height <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsEnabled
            match prevValueOpt, source.TryIsEnabled with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsEnabled <- value
            | Some _, None -> target.IsEnabled <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
        new XamlElement(typeof<Xamarin.Forms.ImageCell>, create, apply, Map.ofArray attribs)

    /// Describes a ViewCell in the view
    static member ViewCell(?view: XamlElement, ?height: double, ?isEnabled: bool) = 
        let attribs = [| 
            match view with | None -> () | Some v -> yield ("View", box v) 
            match height with | None -> () | Some v -> yield ("Height", box v) 
            match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box v) 
          |]

        let create () =
            box (new Xamarin.Forms.ViewCell())

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.ViewCell)
            let prevChildOpt = match prevOpt with None -> None | Some prev -> prev.TryView
            match prevChildOpt, source.TryView with
            // For structured objects, the only caching is based on reference equality
            | Some prevChild, Some newChild when obj.ReferenceEquals(prevChild, newChild) -> ()
            | Some prevChild, Some newChild ->
                newChild.ApplyIncremental(prevChild, target.View)
            | None, Some newChild ->
                target.View <- newChild.CreateAsView()
            | _, None ->
                target.View <- null;
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHeight
            match prevValueOpt, source.TryHeight with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Height <- value
            | Some _, None -> target.Height <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsEnabled
            match prevValueOpt, source.TryIsEnabled with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsEnabled <- value
            | Some _, None -> target.IsEnabled <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
        new XamlElement(typeof<Xamarin.Forms.ViewCell>, create, apply, Map.ofArray attribs)

    /// Describes a ListView in the view
    static member ListView(?itemsSource: System.Collections.IEnumerable, ?itemTemplate: Xamarin.Forms.DataTemplate, ?selectedItem: System.Object, ?separatorVisibility: Xamarin.Forms.SeparatorVisibility, ?separatorColor: Xamarin.Forms.Color, ?hasUnevenRows: bool, ?rowHeight: int, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: Xamarin.Forms.Thickness, ?backgroundColor: Xamarin.Forms.Color, ?isVisible: bool, ?opacity: double, ?widthRequest: double, ?heightRequest: double, ?isEnabled: bool) = 
        let attribs = [| 
            match itemsSource with | None -> () | Some v -> yield ("ItemsSource", box v) 
            match itemTemplate with | None -> () | Some v -> yield ("ItemTemplate", box v) 
            match selectedItem with | None -> () | Some v -> yield ("SelectedItem", box v) 
            match separatorVisibility with | None -> () | Some v -> yield ("SeparatorVisibility", box v) 
            match separatorColor with | None -> () | Some v -> yield ("SeparatorColor", box v) 
            match hasUnevenRows with | None -> () | Some v -> yield ("HasUnevenRows", box v) 
            match rowHeight with | None -> () | Some v -> yield ("RowHeight", box v) 
            match horizontalOptions with | None -> () | Some v -> yield ("HorizontalOptions", box v) 
            match verticalOptions with | None -> () | Some v -> yield ("VerticalOptions", box v) 
            match margin with | None -> () | Some v -> yield ("Margin", box v) 
            match backgroundColor with | None -> () | Some v -> yield ("BackgroundColor", box v) 
            match isVisible with | None -> () | Some v -> yield ("IsVisible", box v) 
            match opacity with | None -> () | Some v -> yield ("Opacity", box v) 
            match widthRequest with | None -> () | Some v -> yield ("WidthRequest", box v) 
            match heightRequest with | None -> () | Some v -> yield ("HeightRequest", box v) 
            match isEnabled with | None -> () | Some v -> yield ("IsEnabled", box v) 
          |]

        let create () =
            box (new Xamarin.Forms.ListView())

        let apply (prevOpt: XamlElement option) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.ListView)
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryItemsSource
            match prevValueOpt, source.TryItemsSource with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.ItemsSource <- value
            | Some _, None -> target.ItemsSource <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryItemTemplate
            match prevValueOpt, source.TryItemTemplate with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.ItemTemplate <- value
            | Some _, None -> target.ItemTemplate <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TrySelectedItem
            match prevValueOpt, source.TrySelectedItem with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.SelectedItem <- value
            | Some _, None -> target.SelectedItem <- null // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TrySeparatorVisibility
            match prevValueOpt, source.TrySeparatorVisibility with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.SeparatorVisibility <- value
            | Some _, None -> target.SeparatorVisibility <- Xamarin.Forms.SeparatorVisibility.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TrySeparatorColor
            match prevValueOpt, source.TrySeparatorColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.SeparatorColor <- value
            | Some _, None -> target.SeparatorColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHasUnevenRows
            match prevValueOpt, source.TryHasUnevenRows with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HasUnevenRows <- value
            | Some _, None -> target.HasUnevenRows <- false // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryRowHeight
            match prevValueOpt, source.TryRowHeight with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.RowHeight <- value
            | Some _, None -> target.RowHeight <- -1 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHorizontalOptions
            match prevValueOpt, source.TryHorizontalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HorizontalOptions <- value
            | Some _, None -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryVerticalOptions
            match prevValueOpt, source.TryVerticalOptions with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.VerticalOptions <- value
            | Some _, None -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryMargin
            match prevValueOpt, source.TryMargin with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Margin <- value
            | Some _, None -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness> // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryBackgroundColor
            match prevValueOpt, source.TryBackgroundColor with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.BackgroundColor <- value
            | Some _, None -> target.BackgroundColor <- Xamarin.Forms.Color.Default // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsVisible
            match prevValueOpt, source.TryIsVisible with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsVisible <- value
            | Some _, None -> target.IsVisible <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryOpacity
            match prevValueOpt, source.TryOpacity with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.Opacity <- value
            | Some _, None -> target.Opacity <- 1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryWidthRequest
            match prevValueOpt, source.TryWidthRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.WidthRequest <- value
            | Some _, None -> target.WidthRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryHeightRequest
            match prevValueOpt, source.TryHeightRequest with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.HeightRequest <- value
            | Some _, None -> target.HeightRequest <- -1.0 // TODO: not always perfect, should set back to original default?
            | None, None -> ()
            let prevValueOpt = match prevOpt with None -> None | Some prev -> prev.TryIsEnabled
            match prevValueOpt, source.TryIsEnabled with
            | Some prevValue, Some value when prevValue = value-> ()
            | _, Some value -> target.IsEnabled <- value
            | Some _, None -> target.IsEnabled <- true // TODO: not always perfect, should set back to original default?
            | None, None -> ()
        new XamlElement(typeof<Xamarin.Forms.ListView>, create, apply, Map.ofArray attribs)
[<AutoOpen>]
module XamlCreateExtensions = 

    /// Specifies a BoxView in the view description, initially with default attributes
    let boxView = Xaml.BoxView()

    /// Specifies a Button in the view description, initially with default attributes
    let button = Xaml.Button()

    /// Specifies a ContentView in the view description, initially with default attributes
    let contentView = Xaml.ContentView()

    /// Specifies a TemplatedView in the view description, initially with default attributes
    let templatedView = Xaml.TemplatedView()

    /// Specifies a DatePicker in the view description, initially with default attributes
    let datePicker = Xaml.DatePicker()

    /// Specifies a Frame in the view description, initially with default attributes
    let frame = Xaml.Frame()

    /// Specifies a Image in the view description, initially with default attributes
    let image = Xaml.Image()

    /// Specifies a Editor in the view description, initially with default attributes
    let editor = Xaml.Editor()

    /// Specifies a Entry in the view description, initially with default attributes
    let entry = Xaml.Entry()

    /// Specifies a Label in the view description, initially with default attributes
    let label = Xaml.Label()

    /// Specifies a StackLayout in the view description, initially with default attributes
    let stackLayout = Xaml.StackLayout()

    /// Specifies a TimePicker in the view description, initially with default attributes
    let timePicker = Xaml.TimePicker()

    /// Specifies a WebView in the view description, initially with default attributes
    let webView = Xaml.WebView()

    /// Specifies a Page in the view description, initially with default attributes
    let page = Xaml.Page()

    /// Specifies a CarouselPage in the view description, initially with default attributes
    let carouselPage = Xaml.CarouselPage()

    /// Specifies a ContentPage in the view description, initially with default attributes
    let contentPage = Xaml.ContentPage()

    /// Specifies a MasterDetailPage in the view description, initially with default attributes
    let masterDetailPage = Xaml.MasterDetailPage()

    /// Specifies a TabbedPage in the view description, initially with default attributes
    let tabbedPage = Xaml.TabbedPage()

    /// Specifies a TextCell in the view description, initially with default attributes
    let textCell = Xaml.TextCell()

    /// Specifies a ImageCell in the view description, initially with default attributes
    let imageCell = Xaml.ImageCell()

    /// Specifies a ViewCell in the view description, initially with default attributes
    let viewCell = Xaml.ViewCell()

    /// Specifies a ListView in the view description, initially with default attributes
    let listView = Xaml.ListView()
