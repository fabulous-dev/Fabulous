namespace rec Elmish.XamarinForms.DynamicViews 

#nowarn "67" // cast always holds

[<AutoOpen>]
module XamlElementExtensions = 

    type XamlElement with

        /// Adjusts the ClassId property in the visual element
        member x.ClassId(value: string) = x.WithAttribute("ClassId", box ((value)))

        /// Adjusts the StyleId property in the visual element
        member x.StyleId(value: string) = x.WithAttribute("StyleId", box ((value)))

        /// Adjusts the AnchorX property in the visual element
        member x.AnchorX(value: double) = x.WithAttribute("AnchorX", box ((value)))

        /// Adjusts the AnchorY property in the visual element
        member x.AnchorY(value: double) = x.WithAttribute("AnchorY", box ((value)))

        /// Adjusts the BackgroundColor property in the visual element
        member x.BackgroundColor(value: Xamarin.Forms.Color) = x.WithAttribute("BackgroundColor", box ((value)))

        /// Adjusts the HeightRequest property in the visual element
        member x.HeightRequest(value: double) = x.WithAttribute("HeightRequest", box ((value)))

        /// Adjusts the InputTransparent property in the visual element
        member x.InputTransparent(value: bool) = x.WithAttribute("InputTransparent", box ((value)))

        /// Adjusts the IsEnabled property in the visual element
        member x.IsEnabled(value: bool) = x.WithAttribute("IsEnabled", box ((value)))

        /// Adjusts the IsVisible property in the visual element
        member x.IsVisible(value: bool) = x.WithAttribute("IsVisible", box ((value)))

        /// Adjusts the MinimumHeightRequest property in the visual element
        member x.MinimumHeightRequest(value: double) = x.WithAttribute("MinimumHeightRequest", box ((value)))

        /// Adjusts the MinimumWidthRequest property in the visual element
        member x.MinimumWidthRequest(value: double) = x.WithAttribute("MinimumWidthRequest", box ((value)))

        /// Adjusts the Opacity property in the visual element
        member x.Opacity(value: double) = x.WithAttribute("Opacity", box ((value)))

        /// Adjusts the Rotation property in the visual element
        member x.Rotation(value: double) = x.WithAttribute("Rotation", box ((value)))

        /// Adjusts the RotationX property in the visual element
        member x.RotationX(value: double) = x.WithAttribute("RotationX", box ((value)))

        /// Adjusts the RotationY property in the visual element
        member x.RotationY(value: double) = x.WithAttribute("RotationY", box ((value)))

        /// Adjusts the Scale property in the visual element
        member x.Scale(value: double) = x.WithAttribute("Scale", box ((value)))

        /// Adjusts the Style property in the visual element
        member x.Style(value: Xamarin.Forms.Style) = x.WithAttribute("Style", box ((value)))

        /// Adjusts the TranslationX property in the visual element
        member x.TranslationX(value: double) = x.WithAttribute("TranslationX", box ((value)))

        /// Adjusts the TranslationY property in the visual element
        member x.TranslationY(value: double) = x.WithAttribute("TranslationY", box ((value)))

        /// Adjusts the WidthRequest property in the visual element
        member x.WidthRequest(value: double) = x.WithAttribute("WidthRequest", box ((value)))

        /// Adjusts the HorizontalOptions property in the visual element
        member x.HorizontalOptions(value: Xamarin.Forms.LayoutOptions) = x.WithAttribute("HorizontalOptions", box ((value)))

        /// Adjusts the VerticalOptions property in the visual element
        member x.VerticalOptions(value: Xamarin.Forms.LayoutOptions) = x.WithAttribute("VerticalOptions", box ((value)))

        /// Adjusts the Margin property in the visual element
        member x.Margin(value: obj) = x.WithAttribute("Margin", box (makeThickness(value)))

        /// Adjusts the GestureRecognizers property in the visual element
        member x.GestureRecognizers(value: XamlElement list) = x.WithAttribute("GestureRecognizers", box (Array.ofList(value)))

        /// Adjusts the TouchPoints property in the visual element
        member x.TouchPoints(value: int) = x.WithAttribute("TouchPoints", box ((value)))

        /// Adjusts the PanUpdated property in the visual element
        member x.PanUpdated(value: Xamarin.Forms.PanUpdatedEventArgs -> unit) = x.WithAttribute("PanUpdated", box ((fun f -> System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the Command property in the visual element
        member x.Command(value: unit -> unit) = x.WithAttribute("Command", box (makeCommand(value)))

        /// Adjusts the NumberOfTapsRequired property in the visual element
        member x.NumberOfTapsRequired(value: int) = x.WithAttribute("NumberOfTapsRequired", box ((value)))

        /// Adjusts the NumberOfClicksRequired property in the visual element
        member x.NumberOfClicksRequired(value: int) = x.WithAttribute("NumberOfClicksRequired", box ((value)))

        /// Adjusts the Buttons property in the visual element
        member x.Buttons(value: Xamarin.Forms.ButtonsMask) = x.WithAttribute("Buttons", box ((value)))

        /// Adjusts the IsPinching property in the visual element
        member x.IsPinching(value: bool) = x.WithAttribute("IsPinching", box ((value)))

        /// Adjusts the PinchUpdated property in the visual element
        member x.PinchUpdated(value: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit) = x.WithAttribute("PinchUpdated", box ((fun f -> System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the Color property in the visual element
        member x.Color(value: Xamarin.Forms.Color) = x.WithAttribute("Color", box ((value)))

        /// Adjusts the IsRunning property in the visual element
        member x.IsRunning(value: bool) = x.WithAttribute("IsRunning", box ((value)))

        /// Adjusts the Progress property in the visual element
        member x.Progress(value: double) = x.WithAttribute("Progress", box ((value)))

        /// Adjusts the Content property in the visual element
        member x.Content(value: XamlElement) = x.WithAttribute("Content", box ((value)))

        /// Adjusts the ScrollOrientation property in the visual element
        member x.ScrollOrientation(value: Xamarin.Forms.ScrollOrientation) = x.WithAttribute("ScrollOrientation", box ((value)))

        /// Adjusts the CancelButtonColor property in the visual element
        member x.CancelButtonColor(value: Xamarin.Forms.Color) = x.WithAttribute("CancelButtonColor", box ((value)))

        /// Adjusts the FontFamily property in the visual element
        member x.FontFamily(value: string) = x.WithAttribute("FontFamily", box ((value)))

        /// Adjusts the FontAttributes property in the visual element
        member x.FontAttributes(value: Xamarin.Forms.FontAttributes) = x.WithAttribute("FontAttributes", box ((value)))

        /// Adjusts the FontSize property in the visual element
        member x.FontSize(value: obj) = x.WithAttribute("FontSize", box (makeFontSize(value)))

        /// Adjusts the HorizontalTextAlignment property in the visual element
        member x.HorizontalTextAlignment(value: Xamarin.Forms.TextAlignment) = x.WithAttribute("HorizontalTextAlignment", box ((value)))

        /// Adjusts the Placeholder property in the visual element
        member x.Placeholder(value: string) = x.WithAttribute("Placeholder", box ((value)))

        /// Adjusts the PlaceholderColor property in the visual element
        member x.PlaceholderColor(value: Xamarin.Forms.Color) = x.WithAttribute("PlaceholderColor", box ((value)))

        /// Adjusts the SearchBarCommand property in the visual element
        member x.SearchBarCommand(value: unit -> unit) = x.WithAttribute("SearchBarCommand", box ((value)))

        /// Adjusts the SearchBarCanExecute property in the visual element
        member x.SearchBarCanExecute(value: bool) = x.WithAttribute("SearchBarCanExecute", box ((value)))

        /// Adjusts the Text property in the visual element
        member x.Text(value: string) = x.WithAttribute("Text", box ((value)))

        /// Adjusts the TextColor property in the visual element
        member x.TextColor(value: Xamarin.Forms.Color) = x.WithAttribute("TextColor", box ((value)))

        /// Adjusts the ButtonCommand property in the visual element
        member x.ButtonCommand(value: unit -> unit) = x.WithAttribute("ButtonCommand", box ((value)))

        /// Adjusts the ButtonCanExecute property in the visual element
        member x.ButtonCanExecute(value: bool) = x.WithAttribute("ButtonCanExecute", box ((value)))

        /// Adjusts the BorderColor property in the visual element
        member x.BorderColor(value: Xamarin.Forms.Color) = x.WithAttribute("BorderColor", box ((value)))

        /// Adjusts the BorderWidth property in the visual element
        member x.BorderWidth(value: double) = x.WithAttribute("BorderWidth", box ((value)))

        /// Adjusts the CommandParameter property in the visual element
        member x.CommandParameter(value: System.Object) = x.WithAttribute("CommandParameter", box ((value)))

        /// Adjusts the ContentLayout property in the visual element
        member x.ContentLayout(value: Xamarin.Forms.Button.ButtonContentLayout) = x.WithAttribute("ContentLayout", box ((value)))

        /// Adjusts the ButtonImageSource property in the visual element
        member x.ButtonImageSource(value: string) = x.WithAttribute("ButtonImageSource", box ((value)))

        /// Adjusts the Minimum property in the visual element
        member x.Minimum(value: double) = x.WithAttribute("Minimum", box ((value)))

        /// Adjusts the Maximum property in the visual element
        member x.Maximum(value: double) = x.WithAttribute("Maximum", box ((value)))

        /// Adjusts the Value property in the visual element
        member x.Value(value: double) = x.WithAttribute("Value", box ((value)))

        /// Adjusts the ValueChanged property in the visual element
        member x.ValueChanged(value: Xamarin.Forms.ValueChangedEventArgs -> unit) = x.WithAttribute("ValueChanged", box ((fun f -> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the Increment property in the visual element
        member x.Increment(value: double) = x.WithAttribute("Increment", box ((value)))

        /// Adjusts the IsToggled property in the visual element
        member x.IsToggled(value: bool) = x.WithAttribute("IsToggled", box ((value)))

        /// Adjusts the Toggled property in the visual element
        member x.Toggled(value: Xamarin.Forms.ToggledEventArgs -> unit) = x.WithAttribute("Toggled", box ((fun f -> System.EventHandler<Xamarin.Forms.ToggledEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the On property in the visual element
        member x.On(value: bool) = x.WithAttribute("On", box ((value)))

        /// Adjusts the OnChanged property in the visual element
        member x.OnChanged(value: Xamarin.Forms.ToggledEventArgs -> unit) = x.WithAttribute("OnChanged", box ((fun f -> System.EventHandler<Xamarin.Forms.ToggledEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the Intent property in the visual element
        member x.Intent(value: Xamarin.Forms.TableIntent) = x.WithAttribute("Intent", box ((value)))

        /// Adjusts the HasUnevenRows property in the visual element
        member x.HasUnevenRows(value: bool) = x.WithAttribute("HasUnevenRows", box ((value)))

        /// Adjusts the RowHeight property in the visual element
        member x.RowHeight(value: int) = x.WithAttribute("RowHeight", box ((value)))

        /// Adjusts the TableRoot property in the visual element
        member x.TableRoot(value: (string * XamlElement list) list) = x.WithAttribute("TableRoot", box ((fun es -> es |> Array.ofList |> Array.map (fun (title, es) -> (title, Array.ofList es)))(value)))

        /// Adjusts the GridRowDefinitions property in the visual element
        member x.GridRowDefinitions(value: obj list) = x.WithAttribute("GridRowDefinitions", box ((fun es -> es |> Array.ofList |> Array.map (fun h -> Xaml.RowDefinition(height=h)))(value)))

        /// Adjusts the GridColumnDefinitions property in the visual element
        member x.GridColumnDefinitions(value: obj list) = x.WithAttribute("GridColumnDefinitions", box ((fun es -> es |> Array.ofList |> Array.map (fun h -> Xaml.ColumnDefinition(width=h)))(value)))

        /// Adjusts the RowSpacing property in the visual element
        member x.RowSpacing(value: double) = x.WithAttribute("RowSpacing", box ((value)))

        /// Adjusts the ColumnSpacing property in the visual element
        member x.ColumnSpacing(value: double) = x.WithAttribute("ColumnSpacing", box ((value)))

        /// Adjusts the Children property in the visual element
        member x.Children(value: XamlElement list) = x.WithAttribute("Children", box (Array.ofList(value)))

        /// Adjusts the GridRow property in the visual element
        member x.GridRow(value: int) = x.WithAttribute("GridRow", box ((value)))

        /// Adjusts the GridRowSpan property in the visual element
        member x.GridRowSpan(value: int) = x.WithAttribute("GridRowSpan", box ((value)))

        /// Adjusts the GridColumn property in the visual element
        member x.GridColumn(value: int) = x.WithAttribute("GridColumn", box ((value)))

        /// Adjusts the GridColumnSpan property in the visual element
        member x.GridColumnSpan(value: int) = x.WithAttribute("GridColumnSpan", box ((value)))

        /// Adjusts the LayoutBounds property in the visual element
        member x.LayoutBounds(value: Xamarin.Forms.Rectangle) = x.WithAttribute("LayoutBounds", box ((value)))

        /// Adjusts the LayoutFlags property in the visual element
        member x.LayoutFlags(value: Xamarin.Forms.AbsoluteLayoutFlags) = x.WithAttribute("LayoutFlags", box ((value)))

        /// Adjusts the BoundsConstraint property in the visual element
        member x.BoundsConstraint(value: Xamarin.Forms.BoundsConstraint) = x.WithAttribute("BoundsConstraint", box ((value)))

        /// Adjusts the HeightConstraint property in the visual element
        member x.HeightConstraint(value: Xamarin.Forms.Constraint) = x.WithAttribute("HeightConstraint", box ((value)))

        /// Adjusts the WidthConstraint property in the visual element
        member x.WidthConstraint(value: Xamarin.Forms.Constraint) = x.WithAttribute("WidthConstraint", box ((value)))

        /// Adjusts the XConstraint property in the visual element
        member x.XConstraint(value: Xamarin.Forms.Constraint) = x.WithAttribute("XConstraint", box ((value)))

        /// Adjusts the YConstraint property in the visual element
        member x.YConstraint(value: Xamarin.Forms.Constraint) = x.WithAttribute("YConstraint", box ((value)))

        /// Adjusts the RowDefinitionHeight property in the visual element
        member x.RowDefinitionHeight(value: obj) = x.WithAttribute("RowDefinitionHeight", box (makeGridLength(value)))

        /// Adjusts the ColumnDefinitionWidth property in the visual element
        member x.ColumnDefinitionWidth(value: obj) = x.WithAttribute("ColumnDefinitionWidth", box (makeGridLength(value)))

        /// Adjusts the Date property in the visual element
        member x.Date(value: System.DateTime) = x.WithAttribute("Date", box ((value)))

        /// Adjusts the Format property in the visual element
        member x.Format(value: string) = x.WithAttribute("Format", box ((value)))

        /// Adjusts the MinimumDate property in the visual element
        member x.MinimumDate(value: System.DateTime) = x.WithAttribute("MinimumDate", box ((value)))

        /// Adjusts the MaximumDate property in the visual element
        member x.MaximumDate(value: System.DateTime) = x.WithAttribute("MaximumDate", box ((value)))

        /// Adjusts the DateSelected property in the visual element
        member x.DateSelected(value: Xamarin.Forms.DateChangedEventArgs -> unit) = x.WithAttribute("DateSelected", box ((fun f -> System.EventHandler<Xamarin.Forms.DateChangedEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the PickerItemsSource property in the visual element
        member x.PickerItemsSource(value: seq<'T>) = x.WithAttribute("PickerItemsSource", box (seqToIList(value)))

        /// Adjusts the SelectedIndex property in the visual element
        member x.SelectedIndex(value: int) = x.WithAttribute("SelectedIndex", box ((value)))

        /// Adjusts the Title property in the visual element
        member x.Title(value: string) = x.WithAttribute("Title", box ((value)))

        /// Adjusts the SelectedIndexChanged property in the visual element
        member x.SelectedIndexChanged(value: (int * 'T option) -> unit) = x.WithAttribute("SelectedIndexChanged", box ((fun f -> System.EventHandler(fun sender args -> let picker = (sender :?> Xamarin.Forms.Picker) in f (picker.SelectedIndex, (picker.SelectedItem |> Option.ofObj |> Option.map unbox<'T>))))(value)))

        /// Adjusts the OutlineColor property in the visual element
        member x.OutlineColor(value: Xamarin.Forms.Color) = x.WithAttribute("OutlineColor", box ((value)))

        /// Adjusts the FrameCornerRadius property in the visual element
        member x.FrameCornerRadius(value: single) = x.WithAttribute("FrameCornerRadius", box ((value)))

        /// Adjusts the HasShadow property in the visual element
        member x.HasShadow(value: bool) = x.WithAttribute("HasShadow", box ((value)))

        /// Adjusts the ImageSource property in the visual element
        member x.ImageSource(value: string) = x.WithAttribute("ImageSource", box ((value)))

        /// Adjusts the Aspect property in the visual element
        member x.Aspect(value: Xamarin.Forms.Aspect) = x.WithAttribute("Aspect", box ((value)))

        /// Adjusts the IsOpaque property in the visual element
        member x.IsOpaque(value: bool) = x.WithAttribute("IsOpaque", box ((value)))

        /// Adjusts the Keyboard property in the visual element
        member x.Keyboard(value: Xamarin.Forms.Keyboard) = x.WithAttribute("Keyboard", box ((value)))

        /// Adjusts the EditorCompleted property in the visual element
        member x.EditorCompleted(value: string -> unit) = x.WithAttribute("EditorCompleted", box ((fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.Editor).Text))(value)))

        /// Adjusts the TextChanged property in the visual element
        member x.TextChanged(value: Xamarin.Forms.TextChangedEventArgs -> unit) = x.WithAttribute("TextChanged", box ((fun f -> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the IsPassword property in the visual element
        member x.IsPassword(value: bool) = x.WithAttribute("IsPassword", box ((value)))

        /// Adjusts the EntryCompleted property in the visual element
        member x.EntryCompleted(value: string -> unit) = x.WithAttribute("EntryCompleted", box ((fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.Entry).Text))(value)))

        /// Adjusts the Label property in the visual element
        member x.Label(value: string) = x.WithAttribute("Label", box ((value)))

        /// Adjusts the VerticalTextAlignment property in the visual element
        member x.VerticalTextAlignment(value: Xamarin.Forms.TextAlignment) = x.WithAttribute("VerticalTextAlignment", box ((value)))

        /// Adjusts the IsClippedToBounds property in the visual element
        member x.IsClippedToBounds(value: bool) = x.WithAttribute("IsClippedToBounds", box ((value)))

        /// Adjusts the Padding property in the visual element
        member x.Padding(value: obj) = x.WithAttribute("Padding", box (makeThickness(value)))

        /// Adjusts the StackOrientation property in the visual element
        member x.StackOrientation(value: Xamarin.Forms.StackOrientation) = x.WithAttribute("StackOrientation", box ((value)))

        /// Adjusts the Spacing property in the visual element
        member x.Spacing(value: double) = x.WithAttribute("Spacing", box ((value)))

        /// Adjusts the ForegroundColor property in the visual element
        member x.ForegroundColor(value: Xamarin.Forms.Color) = x.WithAttribute("ForegroundColor", box ((value)))

        /// Adjusts the PropertyChanged property in the visual element
        member x.PropertyChanged(value: System.ComponentModel.PropertyChangedEventArgs -> unit) = x.WithAttribute("PropertyChanged", box ((fun f -> System.EventHandler<System.ComponentModel.PropertyChangedEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the Time property in the visual element
        member x.Time(value: System.TimeSpan) = x.WithAttribute("Time", box ((value)))

        /// Adjusts the WebSource property in the visual element
        member x.WebSource(value: Xamarin.Forms.WebViewSource) = x.WithAttribute("WebSource", box ((value)))

        /// Adjusts the Navigated property in the visual element
        member x.Navigated(value: Xamarin.Forms.WebNavigatedEventArgs -> unit) = x.WithAttribute("Navigated", box ((fun f -> System.EventHandler<Xamarin.Forms.WebNavigatedEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the Navigating property in the visual element
        member x.Navigating(value: Xamarin.Forms.WebNavigatingEventArgs -> unit) = x.WithAttribute("Navigating", box ((fun f -> System.EventHandler<Xamarin.Forms.WebNavigatingEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the UseSafeArea property in the visual element
        member x.UseSafeArea(value: bool) = x.WithAttribute("UseSafeArea", box ((value)))

        /// Adjusts the CarouselPage_SelectedItem property in the visual element
        member x.CarouselPage_SelectedItem(value: System.Object) = x.WithAttribute("CarouselPage_SelectedItem", box ((value)))

        /// Adjusts the CurrentPage property in the visual element
        member x.CurrentPage(value: XamlElement) = x.WithAttribute("CurrentPage", box ((value)))

        /// Adjusts the CurrentPageChanged property in the visual element
        member x.CurrentPageChanged(value: 'T option -> unit) = x.WithAttribute("CurrentPageChanged", box ((fun f -> System.EventHandler(fun sender args -> f ((sender :?> Xamarin.Forms.CarouselPage).SelectedItem |> Option.ofObj |> Option.map unbox<'T>)))(value)))

        /// Adjusts the Pages property in the visual element
        member x.Pages(value: XamlElement list) = x.WithAttribute("Pages", box (Array.ofList(value)))

        /// Adjusts the BackButtonTitle property in the visual element
        member x.BackButtonTitle(value: string) = x.WithAttribute("BackButtonTitle", box ((value)))

        /// Adjusts the HasBackButton property in the visual element
        member x.HasBackButton(value: bool) = x.WithAttribute("HasBackButton", box ((value)))

        /// Adjusts the HasNavigationBar property in the visual element
        member x.HasNavigationBar(value: bool) = x.WithAttribute("HasNavigationBar", box ((value)))

        /// Adjusts the TitleIcon property in the visual element
        member x.TitleIcon(value: string) = x.WithAttribute("TitleIcon", box ((value)))

        /// Adjusts the BarBackgroundColor property in the visual element
        member x.BarBackgroundColor(value: Xamarin.Forms.Color) = x.WithAttribute("BarBackgroundColor", box ((value)))

        /// Adjusts the BarTextColor property in the visual element
        member x.BarTextColor(value: Xamarin.Forms.Color) = x.WithAttribute("BarTextColor", box ((value)))

        /// Adjusts the Popped property in the visual element
        member x.Popped(value: Xamarin.Forms.NavigationEventArgs -> unit) = x.WithAttribute("Popped", box ((fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(value)))

        /// Adjusts the PoppedToRoot property in the visual element
        member x.PoppedToRoot(value: Xamarin.Forms.NavigationEventArgs -> unit) = x.WithAttribute("PoppedToRoot", box ((fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(value)))

        /// Adjusts the Pushed property in the visual element
        member x.Pushed(value: Xamarin.Forms.NavigationEventArgs -> unit) = x.WithAttribute("Pushed", box ((fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(value)))

        /// Adjusts the OnSizeAllocatedCallback property in the visual element
        member x.OnSizeAllocatedCallback(value: (double * double) -> unit) = x.WithAttribute("OnSizeAllocatedCallback", box ((fun f -> FSharp.Control.Handler<_>(fun _sender args -> f args))(value)))

        /// Adjusts the Master property in the visual element
        member x.Master(value: XamlElement) = x.WithAttribute("Master", box ((value)))

        /// Adjusts the Detail property in the visual element
        member x.Detail(value: XamlElement) = x.WithAttribute("Detail", box ((value)))

        /// Adjusts the IsGestureEnabled property in the visual element
        member x.IsGestureEnabled(value: bool) = x.WithAttribute("IsGestureEnabled", box ((value)))

        /// Adjusts the IsPresented property in the visual element
        member x.IsPresented(value: bool) = x.WithAttribute("IsPresented", box ((value)))

        /// Adjusts the MasterBehavior property in the visual element
        member x.MasterBehavior(value: Xamarin.Forms.MasterBehavior) = x.WithAttribute("MasterBehavior", box ((value)))

        /// Adjusts the IsPresentedChanged property in the visual element
        member x.IsPresentedChanged(value: bool -> unit) = x.WithAttribute("IsPresentedChanged", box ((fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.MasterDetailPage).IsPresented))(value)))

        /// Adjusts the Height property in the visual element
        member x.Height(value: double) = x.WithAttribute("Height", box ((value)))

        /// Adjusts the TextDetail property in the visual element
        member x.TextDetail(value: string) = x.WithAttribute("TextDetail", box ((value)))

        /// Adjusts the TextDetailColor property in the visual element
        member x.TextDetailColor(value: Xamarin.Forms.Color) = x.WithAttribute("TextDetailColor", box ((value)))

        /// Adjusts the TextCellCommand property in the visual element
        member x.TextCellCommand(value: unit -> unit) = x.WithAttribute("TextCellCommand", box ((value)))

        /// Adjusts the TextCellCanExecute property in the visual element
        member x.TextCellCanExecute(value: bool) = x.WithAttribute("TextCellCanExecute", box ((value)))

        /// Adjusts the View property in the visual element
        member x.View(value: XamlElement) = x.WithAttribute("View", box ((value)))

        /// Adjusts the ListViewItems property in the visual element
        member x.ListViewItems(value: seq<XamlElement>) = x.WithAttribute("ListViewItems", box ((value)))

        /// Adjusts the Footer property in the visual element
        member x.Footer(value: System.Object) = x.WithAttribute("Footer", box ((value)))

        /// Adjusts the Header property in the visual element
        member x.Header(value: System.Object) = x.WithAttribute("Header", box ((value)))

        /// Adjusts the HeaderTemplate property in the visual element
        member x.HeaderTemplate(value: Xamarin.Forms.DataTemplate) = x.WithAttribute("HeaderTemplate", box ((value)))

        /// Adjusts the IsGroupingEnabled property in the visual element
        member x.IsGroupingEnabled(value: bool) = x.WithAttribute("IsGroupingEnabled", box ((value)))

        /// Adjusts the IsPullToRefreshEnabled property in the visual element
        member x.IsPullToRefreshEnabled(value: bool) = x.WithAttribute("IsPullToRefreshEnabled", box ((value)))

        /// Adjusts the IsRefreshing property in the visual element
        member x.IsRefreshing(value: bool) = x.WithAttribute("IsRefreshing", box ((value)))

        /// Adjusts the RefreshCommand property in the visual element
        member x.RefreshCommand(value: unit -> unit) = x.WithAttribute("RefreshCommand", box (makeCommand(value)))

        /// Adjusts the ListView_SelectedItem property in the visual element
        member x.ListView_SelectedItem(value: int option) = x.WithAttribute("ListView_SelectedItem", box ((value)))

        /// Adjusts the ListView_SeparatorVisibility property in the visual element
        member x.ListView_SeparatorVisibility(value: Xamarin.Forms.SeparatorVisibility) = x.WithAttribute("ListView_SeparatorVisibility", box ((value)))

        /// Adjusts the ListView_SeparatorColor property in the visual element
        member x.ListView_SeparatorColor(value: Xamarin.Forms.Color) = x.WithAttribute("ListView_SeparatorColor", box ((value)))

        /// Adjusts the ListView_ItemAppearing property in the visual element
        member x.ListView_ItemAppearing(value: int -> unit) = x.WithAttribute("ListView_ItemAppearing", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(value)))

        /// Adjusts the ListView_ItemDisappearing property in the visual element
        member x.ListView_ItemDisappearing(value: int -> unit) = x.WithAttribute("ListView_ItemDisappearing", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(value)))

        /// Adjusts the ListView_ItemSelected property in the visual element
        member x.ListView_ItemSelected(value: int option -> unit) = x.WithAttribute("ListView_ItemSelected", box ((fun f -> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args -> f (tryFindListViewItem sender args.SelectedItem)))(value)))

        /// Adjusts the ListView_ItemTapped property in the visual element
        member x.ListView_ItemTapped(value: int -> unit) = x.WithAttribute("ListView_ItemTapped", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(value)))

        /// Adjusts the ListView_Refreshing property in the visual element
        member x.ListView_Refreshing(value: unit -> unit) = x.WithAttribute("ListView_Refreshing", box ((fun f -> System.EventHandler(fun sender args -> f ()))(value)))

        /// Adjusts the ListViewGrouped_ItemsSource property in the visual element
        member x.ListViewGrouped_ItemsSource(value: (XamlElement * XamlElement list) list) = x.WithAttribute("ListViewGrouped_ItemsSource", box ((fun es -> es |> Array.ofList |> Array.map (fun (e,l) -> (e, Array.ofList l)))(value)))

        /// Adjusts the ListViewGrouped_SelectedItem property in the visual element
        member x.ListViewGrouped_SelectedItem(value: (int * int) option) = x.WithAttribute("ListViewGrouped_SelectedItem", box ((value)))

        /// Adjusts the SeparatorVisibility property in the visual element
        member x.SeparatorVisibility(value: Xamarin.Forms.SeparatorVisibility) = x.WithAttribute("SeparatorVisibility", box ((value)))

        /// Adjusts the SeparatorColor property in the visual element
        member x.SeparatorColor(value: Xamarin.Forms.Color) = x.WithAttribute("SeparatorColor", box ((value)))

        /// Adjusts the ListViewGrouped_ItemAppearing property in the visual element
        member x.ListViewGrouped_ItemAppearing(value: int * int -> unit) = x.WithAttribute("ListViewGrouped_ItemAppearing", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(value)))

        /// Adjusts the ListViewGrouped_ItemDisappearing property in the visual element
        member x.ListViewGrouped_ItemDisappearing(value: int * int -> unit) = x.WithAttribute("ListViewGrouped_ItemDisappearing", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(value)))

        /// Adjusts the ListViewGrouped_ItemSelected property in the visual element
        member x.ListViewGrouped_ItemSelected(value: (int * int) option -> unit) = x.WithAttribute("ListViewGrouped_ItemSelected", box ((fun f -> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.SelectedItem)))(value)))

        /// Adjusts the ListViewGrouped_ItemTapped property in the visual element
        member x.ListViewGrouped_ItemTapped(value: int * int -> unit) = x.WithAttribute("ListViewGrouped_ItemTapped", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(value)))

        /// Adjusts the Refreshing property in the visual element
        member x.Refreshing(value: unit -> unit) = x.WithAttribute("Refreshing", box ((fun f -> System.EventHandler(fun sender args -> f ()))(value)))

type Xaml() =

    /// Describes a Element in the view
    static member internal Element(?classId: string, ?styleId: string) = 
        let attribs = [| 
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.Element"

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            let target = (targetObj :?> Xamarin.Forms.Element)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("ClassId")
            let valueOpt = source.TryGetAttribute<string>("ClassId")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.ClassId <-  value
            | ValueSome _, ValueNone -> target.ClassId <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("StyleId")
            let valueOpt = source.TryGetAttribute<string>("StyleId")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.StyleId <-  value
            | ValueSome _, ValueNone -> target.StyleId <- null
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Element>, create, update, attribs)

    /// Describes a VisualElement in the view
    static member internal VisualElement(?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.Element(?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match anchorX with None -> () | Some v -> yield ("AnchorX", box ((v))) 
            match anchorY with None -> () | Some v -> yield ("AnchorY", box ((v))) 
            match backgroundColor with None -> () | Some v -> yield ("BackgroundColor", box ((v))) 
            match heightRequest with None -> () | Some v -> yield ("HeightRequest", box ((v))) 
            match inputTransparent with None -> () | Some v -> yield ("InputTransparent", box ((v))) 
            match isEnabled with None -> () | Some v -> yield ("IsEnabled", box ((v))) 
            match isVisible with None -> () | Some v -> yield ("IsVisible", box ((v))) 
            match minimumHeightRequest with None -> () | Some v -> yield ("MinimumHeightRequest", box ((v))) 
            match minimumWidthRequest with None -> () | Some v -> yield ("MinimumWidthRequest", box ((v))) 
            match opacity with None -> () | Some v -> yield ("Opacity", box ((v))) 
            match rotation with None -> () | Some v -> yield ("Rotation", box ((v))) 
            match rotationX with None -> () | Some v -> yield ("RotationX", box ((v))) 
            match rotationY with None -> () | Some v -> yield ("RotationY", box ((v))) 
            match scale with None -> () | Some v -> yield ("Scale", box ((v))) 
            match style with None -> () | Some v -> yield ("Style", box ((v))) 
            match translationX with None -> () | Some v -> yield ("TranslationX", box ((v))) 
            match translationY with None -> () | Some v -> yield ("TranslationY", box ((v))) 
            match widthRequest with None -> () | Some v -> yield ("WidthRequest", box ((v))) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.VisualElement"

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.VisualElement)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("AnchorX")
            let valueOpt = source.TryGetAttribute<double>("AnchorX")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.AnchorX <-  value
            | ValueSome _, ValueNone -> target.AnchorX <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("AnchorY")
            let valueOpt = source.TryGetAttribute<double>("AnchorY")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.AnchorY <-  value
            | ValueSome _, ValueNone -> target.AnchorY <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Color>("BackgroundColor")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Color>("BackgroundColor")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.BackgroundColor <-  value
            | ValueSome _, ValueNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("HeightRequest")
            let valueOpt = source.TryGetAttribute<double>("HeightRequest")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.HeightRequest <-  value
            | ValueSome _, ValueNone -> target.HeightRequest <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<bool>("InputTransparent")
            let valueOpt = source.TryGetAttribute<bool>("InputTransparent")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.InputTransparent <-  value
            | ValueSome _, ValueNone -> target.InputTransparent <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<bool>("IsEnabled")
            let valueOpt = source.TryGetAttribute<bool>("IsEnabled")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsEnabled <-  value
            | ValueSome _, ValueNone -> target.IsEnabled <- true
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<bool>("IsVisible")
            let valueOpt = source.TryGetAttribute<bool>("IsVisible")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsVisible <-  value
            | ValueSome _, ValueNone -> target.IsVisible <- true
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("MinimumHeightRequest")
            let valueOpt = source.TryGetAttribute<double>("MinimumHeightRequest")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.MinimumHeightRequest <-  value
            | ValueSome _, ValueNone -> target.MinimumHeightRequest <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("MinimumWidthRequest")
            let valueOpt = source.TryGetAttribute<double>("MinimumWidthRequest")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.MinimumWidthRequest <-  value
            | ValueSome _, ValueNone -> target.MinimumWidthRequest <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("Opacity")
            let valueOpt = source.TryGetAttribute<double>("Opacity")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Opacity <-  value
            | ValueSome _, ValueNone -> target.Opacity <- 1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("Rotation")
            let valueOpt = source.TryGetAttribute<double>("Rotation")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Rotation <-  value
            | ValueSome _, ValueNone -> target.Rotation <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("RotationX")
            let valueOpt = source.TryGetAttribute<double>("RotationX")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.RotationX <-  value
            | ValueSome _, ValueNone -> target.RotationX <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("RotationY")
            let valueOpt = source.TryGetAttribute<double>("RotationY")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.RotationY <-  value
            | ValueSome _, ValueNone -> target.RotationY <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("Scale")
            let valueOpt = source.TryGetAttribute<double>("Scale")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Scale <-  value
            | ValueSome _, ValueNone -> target.Scale <- 1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Style>("Style")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Style>("Style")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Style <-  value
            | ValueSome _, ValueNone -> target.Style <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("TranslationX")
            let valueOpt = source.TryGetAttribute<double>("TranslationX")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.TranslationX <-  value
            | ValueSome _, ValueNone -> target.TranslationX <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("TranslationY")
            let valueOpt = source.TryGetAttribute<double>("TranslationY")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.TranslationY <-  value
            | ValueSome _, ValueNone -> target.TranslationY <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("WidthRequest")
            let valueOpt = source.TryGetAttribute<double>("WidthRequest")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.WidthRequest <-  value
            | ValueSome _, ValueNone -> target.WidthRequest <- -1.0
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.VisualElement>, create, update, attribs)

    /// Describes a View in the view
    static member internal View(?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.VisualElement(?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.View"

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.View)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.LayoutOptions>("HorizontalOptions")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.LayoutOptions>("HorizontalOptions")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.HorizontalOptions <-  value
            | ValueSome _, ValueNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.LayoutOptions>("VerticalOptions")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.LayoutOptions>("VerticalOptions")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.VerticalOptions <-  value
            | ValueSome _, ValueNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Thickness>("Margin")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Thickness>("Margin")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Margin <-  value
            | ValueSome _, ValueNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<XamlElement[]>("GestureRecognizers")
            let valueOpt = source.TryGetAttribute<XamlElement[]>("GestureRecognizers")
            updateIList prevValueOpt valueOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.Create() :?> Xamarin.Forms.IGestureRecognizer)
                (fun _ _ _ -> ())
                canReuseChild
                updateChild
        new XamlElement(typeof<Xamarin.Forms.View>, create, update, attribs)

    /// Describes a IGestureRecognizer in the view
    static member internal IGestureRecognizer() = 
        let attribs = [| 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.IGestureRecognizer"

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            ()
        new XamlElement(typeof<Xamarin.Forms.IGestureRecognizer>, create, update, attribs)

    /// Describes a PanGestureRecognizer in the view
    static member PanGestureRecognizer(?touchPoints: int, ?panUpdated: Xamarin.Forms.PanUpdatedEventArgs -> unit, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.Element(?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match touchPoints with None -> () | Some v -> yield ("TouchPoints", box ((v))) 
            match panUpdated with None -> () | Some v -> yield ("PanUpdated", box ((fun f -> System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>(fun _sender args -> f args))(v))) 
          |]

        let create () =
            box (new Xamarin.Forms.PanGestureRecognizer())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.PanGestureRecognizer)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<int>("TouchPoints")
            let valueOpt = source.TryGetAttribute<int>("TouchPoints")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.TouchPoints <-  value
            | ValueSome _, ValueNone -> target.TouchPoints <- 1
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>>("PanUpdated")
            let valueOpt = source.TryGetAttribute<System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>>("PanUpdated")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.PanUpdated.RemoveHandler(prevValue); target.PanUpdated.AddHandler(value)
            | ValueNone, ValueSome value -> target.PanUpdated.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.PanUpdated.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.PanGestureRecognizer>, create, update, attribs)

    /// Describes a TapGestureRecognizer in the view
    static member TapGestureRecognizer(?command: unit -> unit, ?numberOfTapsRequired: int, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.Element(?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match command with None -> () | Some v -> yield ("Command", box (makeCommand(v))) 
            match numberOfTapsRequired with None -> () | Some v -> yield ("NumberOfTapsRequired", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.TapGestureRecognizer())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.TapGestureRecognizer)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.Windows.Input.ICommand>("Command")
            let valueOpt = source.TryGetAttribute<System.Windows.Input.ICommand>("Command")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Command <-  value
            | ValueSome _, ValueNone -> target.Command <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<int>("NumberOfTapsRequired")
            let valueOpt = source.TryGetAttribute<int>("NumberOfTapsRequired")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.NumberOfTapsRequired <-  value
            | ValueSome _, ValueNone -> target.NumberOfTapsRequired <- 1
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.TapGestureRecognizer>, create, update, attribs)

    /// Describes a ClickGestureRecognizer in the view
    static member ClickGestureRecognizer(?command: unit -> unit, ?numberOfClicksRequired: int, ?buttons: Xamarin.Forms.ButtonsMask, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.Element(?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match command with None -> () | Some v -> yield ("Command", box (makeCommand(v))) 
            match numberOfClicksRequired with None -> () | Some v -> yield ("NumberOfClicksRequired", box ((v))) 
            match buttons with None -> () | Some v -> yield ("Buttons", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.ClickGestureRecognizer())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.ClickGestureRecognizer)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.Windows.Input.ICommand>("Command")
            let valueOpt = source.TryGetAttribute<System.Windows.Input.ICommand>("Command")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Command <-  value
            | ValueSome _, ValueNone -> target.Command <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<int>("NumberOfClicksRequired")
            let valueOpt = source.TryGetAttribute<int>("NumberOfClicksRequired")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.NumberOfClicksRequired <-  value
            | ValueSome _, ValueNone -> target.NumberOfClicksRequired <- 1
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.ButtonsMask>("Buttons")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.ButtonsMask>("Buttons")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Buttons <-  value
            | ValueSome _, ValueNone -> target.Buttons <- Xamarin.Forms.ButtonsMask.Primary
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.ClickGestureRecognizer>, create, update, attribs)

    /// Describes a PinchGestureRecognizer in the view
    static member PinchGestureRecognizer(?isPinching: bool, ?pinchUpdated: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.Element(?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match isPinching with None -> () | Some v -> yield ("IsPinching", box ((v))) 
            match pinchUpdated with None -> () | Some v -> yield ("PinchUpdated", box ((fun f -> System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>(fun _sender args -> f args))(v))) 
          |]

        let create () =
            box (new Xamarin.Forms.PinchGestureRecognizer())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.PinchGestureRecognizer)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<bool>("IsPinching")
            let valueOpt = source.TryGetAttribute<bool>("IsPinching")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsPinching <-  value
            | ValueSome _, ValueNone -> target.IsPinching <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>>("PinchUpdated")
            let valueOpt = source.TryGetAttribute<System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>>("PinchUpdated")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.PinchUpdated.RemoveHandler(prevValue); target.PinchUpdated.AddHandler(value)
            | ValueNone, ValueSome value -> target.PinchUpdated.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.PinchUpdated.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.PinchGestureRecognizer>, create, update, attribs)

    /// Describes a ActivityIndicator in the view
    static member ActivityIndicator(?color: Xamarin.Forms.Color, ?isRunning: bool, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match color with None -> () | Some v -> yield ("Color", box ((v))) 
            match isRunning with None -> () | Some v -> yield ("IsRunning", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.ActivityIndicator())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.ActivityIndicator)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Color>("Color")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Color>("Color")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Color <-  value
            | ValueSome _, ValueNone -> target.Color <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<bool>("IsRunning")
            let valueOpt = source.TryGetAttribute<bool>("IsRunning")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsRunning <-  value
            | ValueSome _, ValueNone -> target.IsRunning <- false
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.ActivityIndicator>, create, update, attribs)

    /// Describes a BoxView in the view
    static member BoxView(?color: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match color with None -> () | Some v -> yield ("Color", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.BoxView())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.BoxView)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Color>("Color")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Color>("Color")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Color <-  value
            | ValueSome _, ValueNone -> target.Color <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.BoxView>, create, update, attribs)

    /// Describes a ProgressBar in the view
    static member ProgressBar(?progress: double, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match progress with None -> () | Some v -> yield ("Progress", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.ProgressBar())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.ProgressBar)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("Progress")
            let valueOpt = source.TryGetAttribute<double>("Progress")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Progress <-  value
            | ValueSome _, ValueNone -> target.Progress <- 0.0
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.ProgressBar>, create, update, attribs)

    /// Describes a ScrollView in the view
    static member ScrollView(?content: XamlElement, ?orientation: Xamarin.Forms.ScrollOrientation, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.Layout(?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match content with None -> () | Some v -> yield ("Content", box ((v))) 
            match orientation with None -> () | Some v -> yield ("ScrollOrientation", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.ScrollView())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.ScrollView)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<XamlElement>("Content")
            let valueOpt = source.TryGetAttribute<XamlElement>("Content")
            match prevValueOpt, valueOpt with
            // For structured objects, dependsOn on reference equality
            | ValueSome prevChild, ValueSome newChild when identical prevChild newChild -> ()
            | ValueSome prevChild, ValueSome newChild when canReuseChild prevChild newChild ->
                newChild.UpdateIncremental(prevChild, target.Content)
            | _, ValueSome newChild ->
                target.Content <- (newChild.Create() :?> Xamarin.Forms.View)
            | ValueSome _, ValueNone ->
                target.Content <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.ScrollOrientation>("ScrollOrientation")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.ScrollOrientation>("ScrollOrientation")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Orientation <-  value
            | ValueSome _, ValueNone -> target.Orientation <- Unchecked.defaultof<Xamarin.Forms.ScrollOrientation>
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.ScrollView>, create, update, attribs)

    /// Describes a SearchBar in the view
    static member SearchBar(?cancelButtonColor: Xamarin.Forms.Color, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?fontSize: obj, ?horizontalTextAlignment: Xamarin.Forms.TextAlignment, ?placeholder: string, ?placeholderColor: Xamarin.Forms.Color, ?searchCommand: unit -> unit, ?canExecute: bool, ?text: string, ?textColor: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match cancelButtonColor with None -> () | Some v -> yield ("CancelButtonColor", box ((v))) 
            match fontFamily with None -> () | Some v -> yield ("FontFamily", box ((v))) 
            match fontAttributes with None -> () | Some v -> yield ("FontAttributes", box ((v))) 
            match fontSize with None -> () | Some v -> yield ("FontSize", box (makeFontSize(v))) 
            match horizontalTextAlignment with None -> () | Some v -> yield ("HorizontalTextAlignment", box ((v))) 
            match placeholder with None -> () | Some v -> yield ("Placeholder", box ((v))) 
            match placeholderColor with None -> () | Some v -> yield ("PlaceholderColor", box ((v))) 
            match searchCommand with None -> () | Some v -> yield ("SearchBarCommand", box ((v))) 
            match canExecute with None -> () | Some v -> yield ("SearchBarCanExecute", box ((v))) 
            match text with None -> () | Some v -> yield ("Text", box ((v))) 
            match textColor with None -> () | Some v -> yield ("TextColor", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.SearchBar())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.SearchBar)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Color>("CancelButtonColor")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Color>("CancelButtonColor")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.CancelButtonColor <-  value
            | ValueSome _, ValueNone -> target.CancelButtonColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("FontFamily")
            let valueOpt = source.TryGetAttribute<string>("FontFamily")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontFamily <-  value
            | ValueSome _, ValueNone -> target.FontFamily <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.FontAttributes>("FontAttributes")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.FontAttributes>("FontAttributes")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontAttributes <-  value
            | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("FontSize")
            let valueOpt = source.TryGetAttribute<double>("FontSize")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontSize <-  value
            | ValueSome _, ValueNone -> target.FontSize <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.TextAlignment>("HorizontalTextAlignment")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.TextAlignment>("HorizontalTextAlignment")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.HorizontalTextAlignment <-  value
            | ValueSome _, ValueNone -> target.HorizontalTextAlignment <- Xamarin.Forms.TextAlignment.Start
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("Placeholder")
            let valueOpt = source.TryGetAttribute<string>("Placeholder")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Placeholder <-  value
            | ValueSome _, ValueNone -> target.Placeholder <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Color>("PlaceholderColor")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Color>("PlaceholderColor")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.PlaceholderColor <-  value
            | ValueSome _, ValueNone -> target.PlaceholderColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<unit -> unit>("SearchBarCommand")
            let valueOpt = source.TryGetAttribute<unit -> unit>("SearchBarCommand")
            (fun _ _ _ -> ()) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<bool>("SearchBarCanExecute")
            let valueOpt = source.TryGetAttribute<bool>("SearchBarCanExecute")
            updateCommand (match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<_>("SearchBarCommand")) prevValueOpt (source.TryGetAttribute<_>("SearchBarCommand")) valueOpt (fun cmd -> target.SearchCommand <- cmd) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("Text")
            let valueOpt = source.TryGetAttribute<string>("Text")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Color>("TextColor")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Color>("TextColor")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.TextColor <-  value
            | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.SearchBar>, create, update, attribs)

    /// Describes a Button in the view
    static member Button(?text: string, ?command: unit -> unit, ?canExecute: bool, ?borderColor: Xamarin.Forms.Color, ?borderWidth: double, ?commandParameter: System.Object, ?contentLayout: Xamarin.Forms.Button.ButtonContentLayout, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?fontSize: obj, ?image: string, ?textColor: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match text with None -> () | Some v -> yield ("Text", box ((v))) 
            match command with None -> () | Some v -> yield ("ButtonCommand", box ((v))) 
            match canExecute with None -> () | Some v -> yield ("ButtonCanExecute", box ((v))) 
            match borderColor with None -> () | Some v -> yield ("BorderColor", box ((v))) 
            match borderWidth with None -> () | Some v -> yield ("BorderWidth", box ((v))) 
            match commandParameter with None -> () | Some v -> yield ("CommandParameter", box ((v))) 
            match contentLayout with None -> () | Some v -> yield ("ContentLayout", box ((v))) 
            match fontFamily with None -> () | Some v -> yield ("FontFamily", box ((v))) 
            match fontAttributes with None -> () | Some v -> yield ("FontAttributes", box ((v))) 
            match fontSize with None -> () | Some v -> yield ("FontSize", box (makeFontSize(v))) 
            match image with None -> () | Some v -> yield ("ButtonImageSource", box ((v))) 
            match textColor with None -> () | Some v -> yield ("TextColor", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.Button())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Button)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("Text")
            let valueOpt = source.TryGetAttribute<string>("Text")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<unit -> unit>("ButtonCommand")
            let valueOpt = source.TryGetAttribute<unit -> unit>("ButtonCommand")
            (fun _ _ _ -> ()) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<bool>("ButtonCanExecute")
            let valueOpt = source.TryGetAttribute<bool>("ButtonCanExecute")
            updateCommand (match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<_>("ButtonCommand")) prevValueOpt (source.TryGetAttribute<_>("ButtonCommand")) valueOpt (fun cmd -> target.Command <- cmd) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Color>("BorderColor")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Color>("BorderColor")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.BorderColor <-  value
            | ValueSome _, ValueNone -> target.BorderColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("BorderWidth")
            let valueOpt = source.TryGetAttribute<double>("BorderWidth")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.BorderWidth <-  value
            | ValueSome _, ValueNone -> target.BorderWidth <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.Object>("CommandParameter")
            let valueOpt = source.TryGetAttribute<System.Object>("CommandParameter")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.CommandParameter <-  value
            | ValueSome _, ValueNone -> target.CommandParameter <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Button.ButtonContentLayout>("ContentLayout")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Button.ButtonContentLayout>("ContentLayout")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.ContentLayout <-  value
            | ValueSome _, ValueNone -> target.ContentLayout <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("FontFamily")
            let valueOpt = source.TryGetAttribute<string>("FontFamily")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontFamily <-  value
            | ValueSome _, ValueNone -> target.FontFamily <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.FontAttributes>("FontAttributes")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.FontAttributes>("FontAttributes")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontAttributes <-  value
            | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("FontSize")
            let valueOpt = source.TryGetAttribute<double>("FontSize")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontSize <-  value
            | ValueSome _, ValueNone -> target.FontSize <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("ButtonImageSource")
            let valueOpt = source.TryGetAttribute<string>("ButtonImageSource")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Image <- makeFileImageSource  value
            | ValueSome _, ValueNone -> target.Image <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Color>("TextColor")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Color>("TextColor")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.TextColor <-  value
            | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Button>, create, update, attribs)

    /// Describes a Slider in the view
    static member Slider(?minimum: double, ?maximum: double, ?value: double, ?valueChanged: Xamarin.Forms.ValueChangedEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match minimum with None -> () | Some v -> yield ("Minimum", box ((v))) 
            match maximum with None -> () | Some v -> yield ("Maximum", box ((v))) 
            match value with None -> () | Some v -> yield ("Value", box ((v))) 
            match valueChanged with None -> () | Some v -> yield ("ValueChanged", box ((fun f -> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>(fun _sender args -> f args))(v))) 
          |]

        let create () =
            box (new Xamarin.Forms.Slider())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Slider)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("Minimum")
            let valueOpt = source.TryGetAttribute<double>("Minimum")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Minimum <-  value
            | ValueSome _, ValueNone -> target.Minimum <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("Maximum")
            let valueOpt = source.TryGetAttribute<double>("Maximum")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Maximum <-  value
            | ValueSome _, ValueNone -> target.Maximum <- 1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("Value")
            let valueOpt = source.TryGetAttribute<double>("Value")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Value <-  value
            | ValueSome _, ValueNone -> target.Value <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>>("ValueChanged")
            let valueOpt = source.TryGetAttribute<System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>>("ValueChanged")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ValueChanged.RemoveHandler(prevValue); target.ValueChanged.AddHandler(value)
            | ValueNone, ValueSome value -> target.ValueChanged.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ValueChanged.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Slider>, create, update, attribs)

    /// Describes a Stepper in the view
    static member Stepper(?minimum: double, ?maximum: double, ?value: double, ?increment: double, ?valueChanged: Xamarin.Forms.ValueChangedEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match minimum with None -> () | Some v -> yield ("Minimum", box ((v))) 
            match maximum with None -> () | Some v -> yield ("Maximum", box ((v))) 
            match value with None -> () | Some v -> yield ("Value", box ((v))) 
            match increment with None -> () | Some v -> yield ("Increment", box ((v))) 
            match valueChanged with None -> () | Some v -> yield ("ValueChanged", box ((fun f -> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>(fun _sender args -> f args))(v))) 
          |]

        let create () =
            box (new Xamarin.Forms.Stepper())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Stepper)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("Minimum")
            let valueOpt = source.TryGetAttribute<double>("Minimum")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Minimum <-  value
            | ValueSome _, ValueNone -> target.Minimum <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("Maximum")
            let valueOpt = source.TryGetAttribute<double>("Maximum")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Maximum <-  value
            | ValueSome _, ValueNone -> target.Maximum <- 1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("Value")
            let valueOpt = source.TryGetAttribute<double>("Value")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Value <-  value
            | ValueSome _, ValueNone -> target.Value <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("Increment")
            let valueOpt = source.TryGetAttribute<double>("Increment")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Increment <-  value
            | ValueSome _, ValueNone -> target.Increment <- 1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>>("ValueChanged")
            let valueOpt = source.TryGetAttribute<System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>>("ValueChanged")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ValueChanged.RemoveHandler(prevValue); target.ValueChanged.AddHandler(value)
            | ValueNone, ValueSome value -> target.ValueChanged.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ValueChanged.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Stepper>, create, update, attribs)

    /// Describes a Switch in the view
    static member Switch(?isToggled: bool, ?toggled: Xamarin.Forms.ToggledEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match isToggled with None -> () | Some v -> yield ("IsToggled", box ((v))) 
            match toggled with None -> () | Some v -> yield ("Toggled", box ((fun f -> System.EventHandler<Xamarin.Forms.ToggledEventArgs>(fun _sender args -> f args))(v))) 
          |]

        let create () =
            box (new Xamarin.Forms.Switch())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Switch)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<bool>("IsToggled")
            let valueOpt = source.TryGetAttribute<bool>("IsToggled")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsToggled <-  value
            | ValueSome _, ValueNone -> target.IsToggled <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler<Xamarin.Forms.ToggledEventArgs>>("Toggled")
            let valueOpt = source.TryGetAttribute<System.EventHandler<Xamarin.Forms.ToggledEventArgs>>("Toggled")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.Toggled.RemoveHandler(prevValue); target.Toggled.AddHandler(value)
            | ValueNone, ValueSome value -> target.Toggled.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.Toggled.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Switch>, create, update, attribs)

    /// Describes a SwitchCell in the view
    static member SwitchCell(?on: bool, ?text: string, ?onChanged: Xamarin.Forms.ToggledEventArgs -> unit, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.Cell(?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match on with None -> () | Some v -> yield ("On", box ((v))) 
            match text with None -> () | Some v -> yield ("Text", box ((v))) 
            match onChanged with None -> () | Some v -> yield ("OnChanged", box ((fun f -> System.EventHandler<Xamarin.Forms.ToggledEventArgs>(fun _sender args -> f args))(v))) 
          |]

        let create () =
            box (new Xamarin.Forms.SwitchCell())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.SwitchCell)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<bool>("On")
            let valueOpt = source.TryGetAttribute<bool>("On")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.On <-  value
            | ValueSome _, ValueNone -> target.On <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("Text")
            let valueOpt = source.TryGetAttribute<string>("Text")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler<Xamarin.Forms.ToggledEventArgs>>("OnChanged")
            let valueOpt = source.TryGetAttribute<System.EventHandler<Xamarin.Forms.ToggledEventArgs>>("OnChanged")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.OnChanged.RemoveHandler(prevValue); target.OnChanged.AddHandler(value)
            | ValueNone, ValueSome value -> target.OnChanged.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.OnChanged.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.SwitchCell>, create, update, attribs)

    /// Describes a TableView in the view
    static member TableView(?intent: Xamarin.Forms.TableIntent, ?hasUnevenRows: bool, ?rowHeight: int, ?items: (string * XamlElement list) list, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match intent with None -> () | Some v -> yield ("Intent", box ((v))) 
            match hasUnevenRows with None -> () | Some v -> yield ("HasUnevenRows", box ((v))) 
            match rowHeight with None -> () | Some v -> yield ("RowHeight", box ((v))) 
            match items with None -> () | Some v -> yield ("TableRoot", box ((fun es -> es |> Array.ofList |> Array.map (fun (title, es) -> (title, Array.ofList es)))(v))) 
          |]

        let create () =
            box (new Xamarin.Forms.TableView())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.TableView)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.TableIntent>("Intent")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.TableIntent>("Intent")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Intent <-  value
            | ValueSome _, ValueNone -> target.Intent <- Unchecked.defaultof<Xamarin.Forms.TableIntent>
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<bool>("HasUnevenRows")
            let valueOpt = source.TryGetAttribute<bool>("HasUnevenRows")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.HasUnevenRows <-  value
            | ValueSome _, ValueNone -> target.HasUnevenRows <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<int>("RowHeight")
            let valueOpt = source.TryGetAttribute<int>("RowHeight")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.RowHeight <-  value
            | ValueSome _, ValueNone -> target.RowHeight <- -1
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<(string * XamlElement[])[]>("TableRoot")
            let valueOpt = source.TryGetAttribute<(string * XamlElement[])[]>("TableRoot")
            updateTableViewItems prevValueOpt valueOpt target
        new XamlElement(typeof<Xamarin.Forms.TableView>, create, update, attribs)

    /// Describes a Grid in the view
    static member Grid(?rowdefs: obj list, ?coldefs: obj list, ?rowSpacing: double, ?columnSpacing: double, ?children: XamlElement list, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.Layout(?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match rowdefs with None -> () | Some v -> yield ("GridRowDefinitions", box ((fun es -> es |> Array.ofList |> Array.map (fun h -> Xaml.RowDefinition(height=h)))(v))) 
            match coldefs with None -> () | Some v -> yield ("GridColumnDefinitions", box ((fun es -> es |> Array.ofList |> Array.map (fun h -> Xaml.ColumnDefinition(width=h)))(v))) 
            match rowSpacing with None -> () | Some v -> yield ("RowSpacing", box ((v))) 
            match columnSpacing with None -> () | Some v -> yield ("ColumnSpacing", box ((v))) 
            match children with None -> () | Some v -> yield ("Children", box (Array.ofList(v))) 
          |]

        let create () =
            box (new Xamarin.Forms.Grid())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Grid)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<XamlElement[]>("GridRowDefinitions")
            let valueOpt = source.TryGetAttribute<XamlElement[]>("GridRowDefinitions")
            updateIList prevValueOpt valueOpt target.RowDefinitions
                (fun (x:XamlElement) -> x.Create() :?> Xamarin.Forms.RowDefinition)
                (fun _ _ _ -> ())
                canReuseChild
                updateChild
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<XamlElement[]>("GridColumnDefinitions")
            let valueOpt = source.TryGetAttribute<XamlElement[]>("GridColumnDefinitions")
            updateIList prevValueOpt valueOpt target.ColumnDefinitions
                (fun (x:XamlElement) -> x.Create() :?> Xamarin.Forms.ColumnDefinition)
                (fun _ _ _ -> ())
                canReuseChild
                updateChild
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("RowSpacing")
            let valueOpt = source.TryGetAttribute<double>("RowSpacing")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.RowSpacing <-  value
            | ValueSome _, ValueNone -> target.RowSpacing <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("ColumnSpacing")
            let valueOpt = source.TryGetAttribute<double>("ColumnSpacing")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.ColumnSpacing <-  value
            | ValueSome _, ValueNone -> target.ColumnSpacing <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<XamlElement[]>("Children")
            let valueOpt = source.TryGetAttribute<XamlElement[]>("Children")
            updateIList prevValueOpt valueOpt target.Children
                (fun (x:XamlElement) -> x.Create() :?> Xamarin.Forms.View)
                (fun prevChildOpt newChild targetChild -> 
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttribute<int>("GridRow")
                    let childValueOpt = newChild.TryGetAttribute<int>("GridRow")
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.Grid.SetRow(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.Grid.SetRow(targetChild, 0) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttribute<int>("GridRowSpan")
                    let childValueOpt = newChild.TryGetAttribute<int>("GridRowSpan")
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.Grid.SetRowSpan(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.Grid.SetRowSpan(targetChild, 0) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttribute<int>("GridColumn")
                    let childValueOpt = newChild.TryGetAttribute<int>("GridColumn")
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.Grid.SetColumn(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.Grid.SetColumn(targetChild, 0) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttribute<int>("GridColumnSpan")
                    let childValueOpt = newChild.TryGetAttribute<int>("GridColumnSpan")
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.Grid.SetColumnSpan(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.Grid.SetColumnSpan(targetChild, 0) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    ())
                canReuseChild
                updateChild
        new XamlElement(typeof<Xamarin.Forms.Grid>, create, update, attribs)

    /// Describes a AbsoluteLayout in the view
    static member AbsoluteLayout(?children: XamlElement list, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.Layout(?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match children with None -> () | Some v -> yield ("Children", box (Array.ofList(v))) 
          |]

        let create () =
            box (new Xamarin.Forms.AbsoluteLayout())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.AbsoluteLayout)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<XamlElement[]>("Children")
            let valueOpt = source.TryGetAttribute<XamlElement[]>("Children")
            updateIList prevValueOpt valueOpt target.Children
                (fun (x:XamlElement) -> x.Create() :?> Xamarin.Forms.View)
                (fun prevChildOpt newChild targetChild -> 
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttribute<Xamarin.Forms.Rectangle>("LayoutBounds")
                    let childValueOpt = newChild.TryGetAttribute<Xamarin.Forms.Rectangle>("LayoutBounds")
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.AbsoluteLayout.SetLayoutBounds(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.AbsoluteLayout.SetLayoutBounds(targetChild, Xamarin.Forms.Rectangle.Zero) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttribute<Xamarin.Forms.AbsoluteLayoutFlags>("LayoutFlags")
                    let childValueOpt = newChild.TryGetAttribute<Xamarin.Forms.AbsoluteLayoutFlags>("LayoutFlags")
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.AbsoluteLayout.SetLayoutFlags(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.AbsoluteLayout.SetLayoutFlags(targetChild, Xamarin.Forms.AbsoluteLayoutFlags.None) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    ())
                canReuseChild
                updateChild
        new XamlElement(typeof<Xamarin.Forms.AbsoluteLayout>, create, update, attribs)

    /// Describes a RelativeLayout in the view
    static member RelativeLayout(?children: XamlElement list, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.Layout(?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match children with None -> () | Some v -> yield ("Children", box (Array.ofList(v))) 
          |]

        let create () =
            box (new Xamarin.Forms.RelativeLayout())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.RelativeLayout)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<XamlElement[]>("Children")
            let valueOpt = source.TryGetAttribute<XamlElement[]>("Children")
            updateIList prevValueOpt valueOpt target.Children
                (fun (x:XamlElement) -> x.Create() :?> Xamarin.Forms.View)
                (fun prevChildOpt newChild targetChild -> 
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttribute<Xamarin.Forms.BoundsConstraint>("BoundsConstraint")
                    let childValueOpt = newChild.TryGetAttribute<Xamarin.Forms.BoundsConstraint>("BoundsConstraint")
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.RelativeLayout.SetBoundsConstraint(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetBoundsConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttribute<Xamarin.Forms.Constraint>("HeightConstraint")
                    let childValueOpt = newChild.TryGetAttribute<Xamarin.Forms.Constraint>("HeightConstraint")
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.RelativeLayout.SetHeightConstraint(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetHeightConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttribute<Xamarin.Forms.Constraint>("WidthConstraint")
                    let childValueOpt = newChild.TryGetAttribute<Xamarin.Forms.Constraint>("WidthConstraint")
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.RelativeLayout.SetWidthConstraint(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetWidthConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttribute<Xamarin.Forms.Constraint>("XConstraint")
                    let childValueOpt = newChild.TryGetAttribute<Xamarin.Forms.Constraint>("XConstraint")
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.RelativeLayout.SetXConstraint(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetXConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttribute<Xamarin.Forms.Constraint>("YConstraint")
                    let childValueOpt = newChild.TryGetAttribute<Xamarin.Forms.Constraint>("YConstraint")
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.RelativeLayout.SetYConstraint(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetYConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    ())
                canReuseChild
                updateChild
        new XamlElement(typeof<Xamarin.Forms.RelativeLayout>, create, update, attribs)

    /// Describes a RowDefinition in the view
    static member RowDefinition(?height: obj) = 
        let attribs = [| 
            match height with None -> () | Some v -> yield ("RowDefinitionHeight", box (makeGridLength(v))) 
          |]

        let create () =
            box (new Xamarin.Forms.RowDefinition())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            let target = (targetObj :?> Xamarin.Forms.RowDefinition)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.GridLength>("RowDefinitionHeight")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.GridLength>("RowDefinitionHeight")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Height <-  value
            | ValueSome _, ValueNone -> target.Height <- Xamarin.Forms.GridLength.Auto
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.RowDefinition>, create, update, attribs)

    /// Describes a ColumnDefinition in the view
    static member ColumnDefinition(?width: obj) = 
        let attribs = [| 
            match width with None -> () | Some v -> yield ("ColumnDefinitionWidth", box (makeGridLength(v))) 
          |]

        let create () =
            box (new Xamarin.Forms.ColumnDefinition())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            let target = (targetObj :?> Xamarin.Forms.ColumnDefinition)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.GridLength>("ColumnDefinitionWidth")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.GridLength>("ColumnDefinitionWidth")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Width <-  value
            | ValueSome _, ValueNone -> target.Width <- Xamarin.Forms.GridLength.Auto
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.ColumnDefinition>, create, update, attribs)

    /// Describes a ContentView in the view
    static member ContentView(?content: XamlElement, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.TemplatedView(?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match content with None -> () | Some v -> yield ("Content", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.ContentView())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.ContentView)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<XamlElement>("Content")
            let valueOpt = source.TryGetAttribute<XamlElement>("Content")
            match prevValueOpt, valueOpt with
            // For structured objects, dependsOn on reference equality
            | ValueSome prevChild, ValueSome newChild when identical prevChild newChild -> ()
            | ValueSome prevChild, ValueSome newChild when canReuseChild prevChild newChild ->
                newChild.UpdateIncremental(prevChild, target.Content)
            | _, ValueSome newChild ->
                target.Content <- (newChild.Create() :?> Xamarin.Forms.View)
            | ValueSome _, ValueNone ->
                target.Content <- null
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.ContentView>, create, update, attribs)

    /// Describes a TemplatedView in the view
    static member TemplatedView(?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.Layout(?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
          |]

        let create () =
            box (new Xamarin.Forms.TemplatedView())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            ()
        new XamlElement(typeof<Xamarin.Forms.TemplatedView>, create, update, attribs)

    /// Describes a DatePicker in the view
    static member DatePicker(?date: System.DateTime, ?format: string, ?minimumDate: System.DateTime, ?maximumDate: System.DateTime, ?dateSelected: Xamarin.Forms.DateChangedEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match date with None -> () | Some v -> yield ("Date", box ((v))) 
            match format with None -> () | Some v -> yield ("Format", box ((v))) 
            match minimumDate with None -> () | Some v -> yield ("MinimumDate", box ((v))) 
            match maximumDate with None -> () | Some v -> yield ("MaximumDate", box ((v))) 
            match dateSelected with None -> () | Some v -> yield ("DateSelected", box ((fun f -> System.EventHandler<Xamarin.Forms.DateChangedEventArgs>(fun _sender args -> f args))(v))) 
          |]

        let create () =
            box (new Xamarin.Forms.DatePicker())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.DatePicker)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.DateTime>("Date")
            let valueOpt = source.TryGetAttribute<System.DateTime>("Date")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Date <-  value
            | ValueSome _, ValueNone -> target.Date <- Unchecked.defaultof<System.DateTime>
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("Format")
            let valueOpt = source.TryGetAttribute<string>("Format")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Format <-  value
            | ValueSome _, ValueNone -> target.Format <- "d"
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.DateTime>("MinimumDate")
            let valueOpt = source.TryGetAttribute<System.DateTime>("MinimumDate")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.MinimumDate <-  value
            | ValueSome _, ValueNone -> target.MinimumDate <- new System.DateTime(1900, 1, 1)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.DateTime>("MaximumDate")
            let valueOpt = source.TryGetAttribute<System.DateTime>("MaximumDate")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.MaximumDate <-  value
            | ValueSome _, ValueNone -> target.MaximumDate <- new System.DateTime(2100, 12, 31)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler<Xamarin.Forms.DateChangedEventArgs>>("DateSelected")
            let valueOpt = source.TryGetAttribute<System.EventHandler<Xamarin.Forms.DateChangedEventArgs>>("DateSelected")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.DateSelected.RemoveHandler(prevValue); target.DateSelected.AddHandler(value)
            | ValueNone, ValueSome value -> target.DateSelected.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.DateSelected.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.DatePicker>, create, update, attribs)

    /// Describes a Picker in the view
    static member Picker(?itemsSource: seq<'T>, ?selectedIndex: int, ?title: string, ?textColor: Xamarin.Forms.Color, ?selectedIndexChanged: (int * 'T option) -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match itemsSource with None -> () | Some v -> yield ("PickerItemsSource", box (seqToIList(v))) 
            match selectedIndex with None -> () | Some v -> yield ("SelectedIndex", box ((v))) 
            match title with None -> () | Some v -> yield ("Title", box ((v))) 
            match textColor with None -> () | Some v -> yield ("TextColor", box ((v))) 
            match selectedIndexChanged with None -> () | Some v -> yield ("SelectedIndexChanged", box ((fun f -> System.EventHandler(fun sender args -> let picker = (sender :?> Xamarin.Forms.Picker) in f (picker.SelectedIndex, (picker.SelectedItem |> Option.ofObj |> Option.map unbox<'T>))))(v))) 
          |]

        let create () =
            box (new Xamarin.Forms.Picker())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Picker)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.Collections.IList>("PickerItemsSource")
            let valueOpt = source.TryGetAttribute<System.Collections.IList>("PickerItemsSource")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.ItemsSource <-  value
            | ValueSome _, ValueNone -> target.ItemsSource <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<int>("SelectedIndex")
            let valueOpt = source.TryGetAttribute<int>("SelectedIndex")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.SelectedIndex <-  value
            | ValueSome _, ValueNone -> target.SelectedIndex <- 0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("Title")
            let valueOpt = source.TryGetAttribute<string>("Title")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Title <-  value
            | ValueSome _, ValueNone -> target.Title <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Color>("TextColor")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Color>("TextColor")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.TextColor <-  value
            | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler>("SelectedIndexChanged")
            let valueOpt = source.TryGetAttribute<System.EventHandler>("SelectedIndexChanged")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.SelectedIndexChanged.RemoveHandler(prevValue); target.SelectedIndexChanged.AddHandler(value)
            | ValueNone, ValueSome value -> target.SelectedIndexChanged.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.SelectedIndexChanged.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Picker>, create, update, attribs)

    /// Describes a Frame in the view
    static member Frame(?outlineColor: Xamarin.Forms.Color, ?cornerRadius: single, ?hasShadow: bool, ?content: XamlElement, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.ContentView(?content=content, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match outlineColor with None -> () | Some v -> yield ("OutlineColor", box ((v))) 
            match cornerRadius with None -> () | Some v -> yield ("FrameCornerRadius", box ((v))) 
            match hasShadow with None -> () | Some v -> yield ("HasShadow", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.Frame())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Frame)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Color>("OutlineColor")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Color>("OutlineColor")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.OutlineColor <-  value
            | ValueSome _, ValueNone -> target.OutlineColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<single>("FrameCornerRadius")
            let valueOpt = source.TryGetAttribute<single>("FrameCornerRadius")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.CornerRadius <-  value
            | ValueSome _, ValueNone -> target.CornerRadius <- -1.0f
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<bool>("HasShadow")
            let valueOpt = source.TryGetAttribute<bool>("HasShadow")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.HasShadow <-  value
            | ValueSome _, ValueNone -> target.HasShadow <- true
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Frame>, create, update, attribs)

    /// Describes a Image in the view
    static member Image(?source: string, ?aspect: Xamarin.Forms.Aspect, ?isOpaque: bool, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match source with None -> () | Some v -> yield ("ImageSource", box ((v))) 
            match aspect with None -> () | Some v -> yield ("Aspect", box ((v))) 
            match isOpaque with None -> () | Some v -> yield ("IsOpaque", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.Image())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Image)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("ImageSource")
            let valueOpt = source.TryGetAttribute<string>("ImageSource")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Source <- makeImageSource  value
            | ValueSome _, ValueNone -> target.Source <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Aspect>("Aspect")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Aspect>("Aspect")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Aspect <-  value
            | ValueSome _, ValueNone -> target.Aspect <- Xamarin.Forms.Aspect.AspectFit
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<bool>("IsOpaque")
            let valueOpt = source.TryGetAttribute<bool>("IsOpaque")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsOpaque <-  value
            | ValueSome _, ValueNone -> target.IsOpaque <- true
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Image>, create, update, attribs)

    /// Describes a InputView in the view
    static member internal InputView(?keyboard: Xamarin.Forms.Keyboard, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match keyboard with None -> () | Some v -> yield ("Keyboard", box ((v))) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.InputView"

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.InputView)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Keyboard>("Keyboard")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Keyboard>("Keyboard")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Keyboard <-  value
            | ValueSome _, ValueNone -> target.Keyboard <- Xamarin.Forms.Keyboard.Default
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.InputView>, create, update, attribs)

    /// Describes a Editor in the view
    static member Editor(?text: string, ?fontSize: obj, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?textColor: Xamarin.Forms.Color, ?completed: string -> unit, ?textChanged: Xamarin.Forms.TextChangedEventArgs -> unit, ?keyboard: Xamarin.Forms.Keyboard, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.InputView(?keyboard=keyboard, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match text with None -> () | Some v -> yield ("Text", box ((v))) 
            match fontSize with None -> () | Some v -> yield ("FontSize", box (makeFontSize(v))) 
            match fontFamily with None -> () | Some v -> yield ("FontFamily", box ((v))) 
            match fontAttributes with None -> () | Some v -> yield ("FontAttributes", box ((v))) 
            match textColor with None -> () | Some v -> yield ("TextColor", box ((v))) 
            match completed with None -> () | Some v -> yield ("EditorCompleted", box ((fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.Editor).Text))(v))) 
            match textChanged with None -> () | Some v -> yield ("TextChanged", box ((fun f -> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>(fun _sender args -> f args))(v))) 
          |]

        let create () =
            box (new Xamarin.Forms.Editor())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Editor)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("Text")
            let valueOpt = source.TryGetAttribute<string>("Text")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("FontSize")
            let valueOpt = source.TryGetAttribute<double>("FontSize")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontSize <-  value
            | ValueSome _, ValueNone -> target.FontSize <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("FontFamily")
            let valueOpt = source.TryGetAttribute<string>("FontFamily")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontFamily <-  value
            | ValueSome _, ValueNone -> target.FontFamily <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.FontAttributes>("FontAttributes")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.FontAttributes>("FontAttributes")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontAttributes <-  value
            | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Color>("TextColor")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Color>("TextColor")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.TextColor <-  value
            | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler>("EditorCompleted")
            let valueOpt = source.TryGetAttribute<System.EventHandler>("EditorCompleted")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.Completed.RemoveHandler(prevValue); target.Completed.AddHandler(value)
            | ValueNone, ValueSome value -> target.Completed.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.Completed.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler<Xamarin.Forms.TextChangedEventArgs>>("TextChanged")
            let valueOpt = source.TryGetAttribute<System.EventHandler<Xamarin.Forms.TextChangedEventArgs>>("TextChanged")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.TextChanged.RemoveHandler(prevValue); target.TextChanged.AddHandler(value)
            | ValueNone, ValueSome value -> target.TextChanged.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.TextChanged.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Editor>, create, update, attribs)

    /// Describes a Entry in the view
    static member Entry(?text: string, ?placeholder: string, ?horizontalTextAlignment: Xamarin.Forms.TextAlignment, ?fontSize: obj, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?textColor: Xamarin.Forms.Color, ?placeholderColor: Xamarin.Forms.Color, ?isPassword: bool, ?completed: string -> unit, ?textChanged: Xamarin.Forms.TextChangedEventArgs -> unit, ?keyboard: Xamarin.Forms.Keyboard, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.InputView(?keyboard=keyboard, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match text with None -> () | Some v -> yield ("Text", box ((v))) 
            match placeholder with None -> () | Some v -> yield ("Placeholder", box ((v))) 
            match horizontalTextAlignment with None -> () | Some v -> yield ("HorizontalTextAlignment", box ((v))) 
            match fontSize with None -> () | Some v -> yield ("FontSize", box (makeFontSize(v))) 
            match fontFamily with None -> () | Some v -> yield ("FontFamily", box ((v))) 
            match fontAttributes with None -> () | Some v -> yield ("FontAttributes", box ((v))) 
            match textColor with None -> () | Some v -> yield ("TextColor", box ((v))) 
            match placeholderColor with None -> () | Some v -> yield ("PlaceholderColor", box ((v))) 
            match isPassword with None -> () | Some v -> yield ("IsPassword", box ((v))) 
            match completed with None -> () | Some v -> yield ("EntryCompleted", box ((fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.Entry).Text))(v))) 
            match textChanged with None -> () | Some v -> yield ("TextChanged", box ((fun f -> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>(fun _sender args -> f args))(v))) 
          |]

        let create () =
            box (new Xamarin.Forms.Entry())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Entry)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("Text")
            let valueOpt = source.TryGetAttribute<string>("Text")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("Placeholder")
            let valueOpt = source.TryGetAttribute<string>("Placeholder")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Placeholder <-  value
            | ValueSome _, ValueNone -> target.Placeholder <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.TextAlignment>("HorizontalTextAlignment")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.TextAlignment>("HorizontalTextAlignment")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.HorizontalTextAlignment <-  value
            | ValueSome _, ValueNone -> target.HorizontalTextAlignment <- Xamarin.Forms.TextAlignment.Start
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("FontSize")
            let valueOpt = source.TryGetAttribute<double>("FontSize")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontSize <-  value
            | ValueSome _, ValueNone -> target.FontSize <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("FontFamily")
            let valueOpt = source.TryGetAttribute<string>("FontFamily")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontFamily <-  value
            | ValueSome _, ValueNone -> target.FontFamily <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.FontAttributes>("FontAttributes")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.FontAttributes>("FontAttributes")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontAttributes <-  value
            | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Color>("TextColor")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Color>("TextColor")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.TextColor <-  value
            | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Color>("PlaceholderColor")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Color>("PlaceholderColor")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.PlaceholderColor <-  value
            | ValueSome _, ValueNone -> target.PlaceholderColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<bool>("IsPassword")
            let valueOpt = source.TryGetAttribute<bool>("IsPassword")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsPassword <-  value
            | ValueSome _, ValueNone -> target.IsPassword <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler>("EntryCompleted")
            let valueOpt = source.TryGetAttribute<System.EventHandler>("EntryCompleted")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.Completed.RemoveHandler(prevValue); target.Completed.AddHandler(value)
            | ValueNone, ValueSome value -> target.Completed.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.Completed.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler<Xamarin.Forms.TextChangedEventArgs>>("TextChanged")
            let valueOpt = source.TryGetAttribute<System.EventHandler<Xamarin.Forms.TextChangedEventArgs>>("TextChanged")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.TextChanged.RemoveHandler(prevValue); target.TextChanged.AddHandler(value)
            | ValueNone, ValueSome value -> target.TextChanged.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.TextChanged.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Entry>, create, update, attribs)

    /// Describes a EntryCell in the view
    static member EntryCell(?label: string, ?text: string, ?keyboard: Xamarin.Forms.Keyboard, ?placeholder: string, ?horizontalTextAlignment: Xamarin.Forms.TextAlignment, ?completed: string -> unit, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.Cell(?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match label with None -> () | Some v -> yield ("Label", box ((v))) 
            match text with None -> () | Some v -> yield ("Text", box ((v))) 
            match keyboard with None -> () | Some v -> yield ("Keyboard", box ((v))) 
            match placeholder with None -> () | Some v -> yield ("Placeholder", box ((v))) 
            match horizontalTextAlignment with None -> () | Some v -> yield ("HorizontalTextAlignment", box ((v))) 
            match completed with None -> () | Some v -> yield ("EntryCompleted", box ((fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.EntryCell).Text))(v))) 
          |]

        let create () =
            box (new Xamarin.Forms.EntryCell())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.EntryCell)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("Label")
            let valueOpt = source.TryGetAttribute<string>("Label")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Label <-  value
            | ValueSome _, ValueNone -> target.Label <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("Text")
            let valueOpt = source.TryGetAttribute<string>("Text")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Keyboard>("Keyboard")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Keyboard>("Keyboard")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Keyboard <-  value
            | ValueSome _, ValueNone -> target.Keyboard <- Xamarin.Forms.Keyboard.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("Placeholder")
            let valueOpt = source.TryGetAttribute<string>("Placeholder")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Placeholder <-  value
            | ValueSome _, ValueNone -> target.Placeholder <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.TextAlignment>("HorizontalTextAlignment")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.TextAlignment>("HorizontalTextAlignment")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.HorizontalTextAlignment <-  value
            | ValueSome _, ValueNone -> target.HorizontalTextAlignment <- Xamarin.Forms.TextAlignment.Start
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler>("EntryCompleted")
            let valueOpt = source.TryGetAttribute<System.EventHandler>("EntryCompleted")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.Completed.RemoveHandler(prevValue); target.Completed.AddHandler(value)
            | ValueNone, ValueSome value -> target.Completed.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.Completed.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.EntryCell>, create, update, attribs)

    /// Describes a Label in the view
    static member Label(?text: string, ?horizontalTextAlignment: Xamarin.Forms.TextAlignment, ?verticalTextAlignment: Xamarin.Forms.TextAlignment, ?fontSize: obj, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?textColor: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match text with None -> () | Some v -> yield ("Text", box ((v))) 
            match horizontalTextAlignment with None -> () | Some v -> yield ("HorizontalTextAlignment", box ((v))) 
            match verticalTextAlignment with None -> () | Some v -> yield ("VerticalTextAlignment", box ((v))) 
            match fontSize with None -> () | Some v -> yield ("FontSize", box (makeFontSize(v))) 
            match fontFamily with None -> () | Some v -> yield ("FontFamily", box ((v))) 
            match fontAttributes with None -> () | Some v -> yield ("FontAttributes", box ((v))) 
            match textColor with None -> () | Some v -> yield ("TextColor", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.Label())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Label)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("Text")
            let valueOpt = source.TryGetAttribute<string>("Text")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.TextAlignment>("HorizontalTextAlignment")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.TextAlignment>("HorizontalTextAlignment")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.HorizontalTextAlignment <-  value
            | ValueSome _, ValueNone -> target.HorizontalTextAlignment <- Xamarin.Forms.TextAlignment.Start
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.TextAlignment>("VerticalTextAlignment")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.TextAlignment>("VerticalTextAlignment")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.VerticalTextAlignment <-  value
            | ValueSome _, ValueNone -> target.VerticalTextAlignment <- Xamarin.Forms.TextAlignment.Start
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("FontSize")
            let valueOpt = source.TryGetAttribute<double>("FontSize")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontSize <-  value
            | ValueSome _, ValueNone -> target.FontSize <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("FontFamily")
            let valueOpt = source.TryGetAttribute<string>("FontFamily")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontFamily <-  value
            | ValueSome _, ValueNone -> target.FontFamily <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.FontAttributes>("FontAttributes")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.FontAttributes>("FontAttributes")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontAttributes <-  value
            | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Color>("TextColor")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Color>("TextColor")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.TextColor <-  value
            | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Label>, create, update, attribs)

    /// Describes a Layout in the view
    static member internal Layout(?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match isClippedToBounds with None -> () | Some v -> yield ("IsClippedToBounds", box ((v))) 
            match padding with None -> () | Some v -> yield ("Padding", box (makeThickness(v))) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.Layout"

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Layout)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<bool>("IsClippedToBounds")
            let valueOpt = source.TryGetAttribute<bool>("IsClippedToBounds")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsClippedToBounds <-  value
            | ValueSome _, ValueNone -> target.IsClippedToBounds <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Thickness>("Padding")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Thickness>("Padding")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Padding <-  value
            | ValueSome _, ValueNone -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Layout>, create, update, attribs)

    /// Describes a StackLayout in the view
    static member StackLayout(?children: XamlElement list, ?orientation: Xamarin.Forms.StackOrientation, ?spacing: double, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.Layout(?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match children with None -> () | Some v -> yield ("Children", box (Array.ofList(v))) 
            match orientation with None -> () | Some v -> yield ("StackOrientation", box ((v))) 
            match spacing with None -> () | Some v -> yield ("Spacing", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.StackLayout())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.StackLayout)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<XamlElement[]>("Children")
            let valueOpt = source.TryGetAttribute<XamlElement[]>("Children")
            updateIList prevValueOpt valueOpt target.Children
                (fun (x:XamlElement) -> x.Create() :?> Xamarin.Forms.View)
                (fun _ _ _ -> ())
                canReuseChild
                updateChild
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.StackOrientation>("StackOrientation")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.StackOrientation>("StackOrientation")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Orientation <-  value
            | ValueSome _, ValueNone -> target.Orientation <- Xamarin.Forms.StackOrientation.Vertical
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("Spacing")
            let valueOpt = source.TryGetAttribute<double>("Spacing")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Spacing <-  value
            | ValueSome _, ValueNone -> target.Spacing <- 6.0
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.StackLayout>, create, update, attribs)

    /// Describes a Span in the view
    static member Span(?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?fontSize: obj, ?backgroundColor: Xamarin.Forms.Color, ?foregroundColor: Xamarin.Forms.Color, ?text: string, ?propertyChanged: System.ComponentModel.PropertyChangedEventArgs -> unit) = 
        let attribs = [| 
            match fontFamily with None -> () | Some v -> yield ("FontFamily", box ((v))) 
            match fontAttributes with None -> () | Some v -> yield ("FontAttributes", box ((v))) 
            match fontSize with None -> () | Some v -> yield ("FontSize", box (makeFontSize(v))) 
            match backgroundColor with None -> () | Some v -> yield ("BackgroundColor", box ((v))) 
            match foregroundColor with None -> () | Some v -> yield ("ForegroundColor", box ((v))) 
            match text with None -> () | Some v -> yield ("Text", box ((v))) 
            match propertyChanged with None -> () | Some v -> yield ("PropertyChanged", box ((fun f -> System.EventHandler<System.ComponentModel.PropertyChangedEventArgs>(fun _sender args -> f args))(v))) 
          |]

        let create () =
            box (new Xamarin.Forms.Span())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            let target = (targetObj :?> Xamarin.Forms.Span)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("FontFamily")
            let valueOpt = source.TryGetAttribute<string>("FontFamily")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontFamily <-  value
            | ValueSome _, ValueNone -> target.FontFamily <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.FontAttributes>("FontAttributes")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.FontAttributes>("FontAttributes")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontAttributes <-  value
            | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("FontSize")
            let valueOpt = source.TryGetAttribute<double>("FontSize")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontSize <-  value
            | ValueSome _, ValueNone -> target.FontSize <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Color>("BackgroundColor")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Color>("BackgroundColor")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.BackgroundColor <-  value
            | ValueSome _, ValueNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Color>("ForegroundColor")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Color>("ForegroundColor")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.ForegroundColor <-  value
            | ValueSome _, ValueNone -> target.ForegroundColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("Text")
            let valueOpt = source.TryGetAttribute<string>("Text")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.ComponentModel.PropertyChangedEventHandler>("PropertyChanged")
            let valueOpt = source.TryGetAttribute<System.ComponentModel.PropertyChangedEventHandler>("PropertyChanged")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.PropertyChanged.RemoveHandler(prevValue); target.PropertyChanged.AddHandler(value)
            | ValueNone, ValueSome value -> target.PropertyChanged.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.PropertyChanged.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Span>, create, update, attribs)

    /// Describes a TimePicker in the view
    static member TimePicker(?time: System.TimeSpan, ?format: string, ?textColor: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match time with None -> () | Some v -> yield ("Time", box ((v))) 
            match format with None -> () | Some v -> yield ("Format", box ((v))) 
            match textColor with None -> () | Some v -> yield ("TextColor", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.TimePicker())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.TimePicker)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.TimeSpan>("Time")
            let valueOpt = source.TryGetAttribute<System.TimeSpan>("Time")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Time <-  value
            | ValueSome _, ValueNone -> target.Time <- new System.TimeSpan()
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("Format")
            let valueOpt = source.TryGetAttribute<string>("Format")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Format <-  value
            | ValueSome _, ValueNone -> target.Format <- "t"
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Color>("TextColor")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Color>("TextColor")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.TextColor <-  value
            | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.TimePicker>, create, update, attribs)

    /// Describes a WebView in the view
    static member WebView(?source: Xamarin.Forms.WebViewSource, ?navigated: Xamarin.Forms.WebNavigatedEventArgs -> unit, ?navigating: Xamarin.Forms.WebNavigatingEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match source with None -> () | Some v -> yield ("WebSource", box ((v))) 
            match navigated with None -> () | Some v -> yield ("Navigated", box ((fun f -> System.EventHandler<Xamarin.Forms.WebNavigatedEventArgs>(fun _sender args -> f args))(v))) 
            match navigating with None -> () | Some v -> yield ("Navigating", box ((fun f -> System.EventHandler<Xamarin.Forms.WebNavigatingEventArgs>(fun _sender args -> f args))(v))) 
          |]

        let create () =
            box (new Xamarin.Forms.WebView())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.WebView)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.WebViewSource>("WebSource")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.WebViewSource>("WebSource")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Source <-  value
            | ValueSome _, ValueNone -> target.Source <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler<Xamarin.Forms.WebNavigatedEventArgs>>("Navigated")
            let valueOpt = source.TryGetAttribute<System.EventHandler<Xamarin.Forms.WebNavigatedEventArgs>>("Navigated")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.Navigated.RemoveHandler(prevValue); target.Navigated.AddHandler(value)
            | ValueNone, ValueSome value -> target.Navigated.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.Navigated.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler<Xamarin.Forms.WebNavigatingEventArgs>>("Navigating")
            let valueOpt = source.TryGetAttribute<System.EventHandler<Xamarin.Forms.WebNavigatingEventArgs>>("Navigating")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.Navigating.RemoveHandler(prevValue); target.Navigating.AddHandler(value)
            | ValueNone, ValueSome value -> target.Navigating.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.Navigating.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.WebView>, create, update, attribs)

    /// Describes a Page in the view
    static member Page(?title: string, ?padding: obj, ?useSafeArea: bool, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.VisualElement(?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match title with None -> () | Some v -> yield ("Title", box ((v))) 
            match padding with None -> () | Some v -> yield ("Padding", box (makeThickness(v))) 
            match useSafeArea with None -> () | Some v -> yield ("UseSafeArea", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.Page())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Page)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("Title")
            let valueOpt = source.TryGetAttribute<string>("Title")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Title <-  value
            | ValueSome _, ValueNone -> target.Title <- ""
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Thickness>("Padding")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Thickness>("Padding")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Padding <-  value
            | ValueSome _, ValueNone -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<bool>("UseSafeArea")
            let valueOpt = source.TryGetAttribute<bool>("UseSafeArea")
            (fun _ _ target -> Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea((target :> Xamarin.Forms.Page).On<Xamarin.Forms.PlatformConfiguration.iOS>(), true) |> ignore) prevValueOpt valueOpt target
        new XamlElement(typeof<Xamarin.Forms.Page>, create, update, attribs)

    /// Describes a CarouselPage in the view
    static member CarouselPage(?children: XamlElement list, ?selectedItem: System.Object, ?currentPage: XamlElement, ?currentPageChanged: 'T option -> unit, ?title: string, ?padding: obj, ?useSafeArea: bool, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.Page(?title=title, ?padding=padding, ?useSafeArea=useSafeArea, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match children with None -> () | Some v -> yield ("Children", box (Array.ofList(v))) 
            match selectedItem with None -> () | Some v -> yield ("CarouselPage_SelectedItem", box ((v))) 
            match currentPage with None -> () | Some v -> yield ("CurrentPage", box ((v))) 
            match currentPageChanged with None -> () | Some v -> yield ("CurrentPageChanged", box ((fun f -> System.EventHandler(fun sender args -> f ((sender :?> Xamarin.Forms.CarouselPage).SelectedItem |> Option.ofObj |> Option.map unbox<'T>)))(v))) 
          |]

        let create () =
            box (new Xamarin.Forms.CarouselPage())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.CarouselPage)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<XamlElement[]>("Children")
            let valueOpt = source.TryGetAttribute<XamlElement[]>("Children")
            updateIList prevValueOpt valueOpt target.Children
                (fun (x:XamlElement) -> x.Create() :?> Xamarin.Forms.ContentPage)
                (fun _ _ _ -> ())
                canReuseChild
                updateChild
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.Object>("CarouselPage_SelectedItem")
            let valueOpt = source.TryGetAttribute<System.Object>("CarouselPage_SelectedItem")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.SelectedItem <-  value
            | ValueSome _, ValueNone -> target.SelectedItem <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<XamlElement>("CurrentPage")
            let valueOpt = source.TryGetAttribute<XamlElement>("CurrentPage")
            match prevValueOpt, valueOpt with
            // For structured objects, dependsOn on reference equality
            | ValueSome prevChild, ValueSome newChild when identical prevChild newChild -> ()
            | ValueSome prevChild, ValueSome newChild when canReuseChild prevChild newChild ->
                newChild.UpdateIncremental(prevChild, target.CurrentPage)
            | _, ValueSome newChild ->
                target.CurrentPage <- (newChild.Create() :?> Xamarin.Forms.ContentPage)
            | ValueSome _, ValueNone ->
                target.CurrentPage <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler>("CurrentPageChanged")
            let valueOpt = source.TryGetAttribute<System.EventHandler>("CurrentPageChanged")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.CurrentPageChanged.RemoveHandler(prevValue); target.CurrentPageChanged.AddHandler(value)
            | ValueNone, ValueSome value -> target.CurrentPageChanged.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.CurrentPageChanged.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.CarouselPage>, create, update, attribs)

    /// Describes a NavigationPage in the view
    static member NavigationPage(?pages: XamlElement list, ?barBackgroundColor: Xamarin.Forms.Color, ?barTextColor: Xamarin.Forms.Color, ?popped: Xamarin.Forms.NavigationEventArgs -> unit, ?poppedToRoot: Xamarin.Forms.NavigationEventArgs -> unit, ?pushed: Xamarin.Forms.NavigationEventArgs -> unit, ?title: string, ?padding: obj, ?useSafeArea: bool, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.Page(?title=title, ?padding=padding, ?useSafeArea=useSafeArea, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match pages with None -> () | Some v -> yield ("Pages", box (Array.ofList(v))) 
            match barBackgroundColor with None -> () | Some v -> yield ("BarBackgroundColor", box ((v))) 
            match barTextColor with None -> () | Some v -> yield ("BarTextColor", box ((v))) 
            match popped with None -> () | Some v -> yield ("Popped", box ((fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(v))) 
            match poppedToRoot with None -> () | Some v -> yield ("PoppedToRoot", box ((fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(v))) 
            match pushed with None -> () | Some v -> yield ("Pushed", box ((fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(v))) 
          |]

        let create () =
            box (new Xamarin.Forms.NavigationPage())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.NavigationPage)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<XamlElement[]>("Pages")
            let valueOpt = source.TryGetAttribute<XamlElement[]>("Pages")
            updateNavigationPages prevValueOpt valueOpt target
                (fun prevChildOpt newChild targetChild -> 
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttribute<string>("BackButtonTitle")
                    let childValueOpt = newChild.TryGetAttribute<string>("BackButtonTitle")
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.NavigationPage.SetBackButtonTitle(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.NavigationPage.SetBackButtonTitle(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttribute<bool>("HasBackButton")
                    let childValueOpt = newChild.TryGetAttribute<bool>("HasBackButton")
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.NavigationPage.SetHasBackButton(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.NavigationPage.SetHasBackButton(targetChild, true) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttribute<bool>("HasNavigationBar")
                    let childValueOpt = newChild.TryGetAttribute<bool>("HasNavigationBar")
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.NavigationPage.SetHasNavigationBar(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.NavigationPage.SetHasNavigationBar(targetChild, true) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttribute<string>("TitleIcon")
                    let childValueOpt = newChild.TryGetAttribute<string>("TitleIcon")
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.NavigationPage.SetTitleIcon(targetChild, makeFileImageSource value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.NavigationPage.SetTitleIcon(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    ())
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Color>("BarBackgroundColor")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Color>("BarBackgroundColor")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.BarBackgroundColor <-  value
            | ValueSome _, ValueNone -> target.BarBackgroundColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Color>("BarTextColor")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Color>("BarTextColor")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.BarTextColor <-  value
            | ValueSome _, ValueNone -> target.BarTextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler<Xamarin.Forms.NavigationEventArgs>>("Popped")
            let valueOpt = source.TryGetAttribute<System.EventHandler<Xamarin.Forms.NavigationEventArgs>>("Popped")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.Popped.RemoveHandler(prevValue); target.Popped.AddHandler(value)
            | ValueNone, ValueSome value -> target.Popped.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.Popped.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler<Xamarin.Forms.NavigationEventArgs>>("PoppedToRoot")
            let valueOpt = source.TryGetAttribute<System.EventHandler<Xamarin.Forms.NavigationEventArgs>>("PoppedToRoot")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.PoppedToRoot.RemoveHandler(prevValue); target.PoppedToRoot.AddHandler(value)
            | ValueNone, ValueSome value -> target.PoppedToRoot.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.PoppedToRoot.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler<Xamarin.Forms.NavigationEventArgs>>("Pushed")
            let valueOpt = source.TryGetAttribute<System.EventHandler<Xamarin.Forms.NavigationEventArgs>>("Pushed")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.Pushed.RemoveHandler(prevValue); target.Pushed.AddHandler(value)
            | ValueNone, ValueSome value -> target.Pushed.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.Pushed.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.NavigationPage>, create, update, attribs)

    /// Describes a TabbedPage in the view
    static member TabbedPage(?children: XamlElement list, ?barBackgroundColor: Xamarin.Forms.Color, ?barTextColor: Xamarin.Forms.Color, ?title: string, ?padding: obj, ?useSafeArea: bool, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.Page(?title=title, ?padding=padding, ?useSafeArea=useSafeArea, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match children with None -> () | Some v -> yield ("Children", box (Array.ofList(v))) 
            match barBackgroundColor with None -> () | Some v -> yield ("BarBackgroundColor", box ((v))) 
            match barTextColor with None -> () | Some v -> yield ("BarTextColor", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.TabbedPage())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.TabbedPage)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<XamlElement[]>("Children")
            let valueOpt = source.TryGetAttribute<XamlElement[]>("Children")
            updateIList prevValueOpt valueOpt target.Children
                (fun (x:XamlElement) -> x.Create() :?> Xamarin.Forms.Page)
                (fun _ _ _ -> ())
                canReuseChild
                updateChild
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Color>("BarBackgroundColor")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Color>("BarBackgroundColor")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.BarBackgroundColor <-  value
            | ValueSome _, ValueNone -> target.BarBackgroundColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Color>("BarTextColor")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Color>("BarTextColor")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.BarTextColor <-  value
            | ValueSome _, ValueNone -> target.BarTextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.TabbedPage>, create, update, attribs)

    /// Describes a ContentPage in the view
    static member ContentPage(?content: XamlElement, ?onSizeAllocated: (double * double) -> unit, ?title: string, ?padding: obj, ?useSafeArea: bool, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.Page(?title=title, ?padding=padding, ?useSafeArea=useSafeArea, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match content with None -> () | Some v -> yield ("Content", box ((v))) 
            match onSizeAllocated with None -> () | Some v -> yield ("OnSizeAllocatedCallback", box ((fun f -> FSharp.Control.Handler<_>(fun _sender args -> f args))(v))) 
          |]

        let create () =
            box (new Elmish.XamarinForms.DynamicViews.CustomContentPage())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.ContentPage)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<XamlElement>("Content")
            let valueOpt = source.TryGetAttribute<XamlElement>("Content")
            match prevValueOpt, valueOpt with
            // For structured objects, dependsOn on reference equality
            | ValueSome prevChild, ValueSome newChild when identical prevChild newChild -> ()
            | ValueSome prevChild, ValueSome newChild when canReuseChild prevChild newChild ->
                newChild.UpdateIncremental(prevChild, target.Content)
            | _, ValueSome newChild ->
                target.Content <- (newChild.Create() :?> Xamarin.Forms.View)
            | ValueSome _, ValueNone ->
                target.Content <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<FSharp.Control.Handler<(double * double)>>("OnSizeAllocatedCallback")
            let valueOpt = source.TryGetAttribute<FSharp.Control.Handler<(double * double)>>("OnSizeAllocatedCallback")
            updateOnSizeAllocated prevValueOpt valueOpt target
        new XamlElement(typeof<Xamarin.Forms.ContentPage>, create, update, attribs)

    /// Describes a MasterDetailPage in the view
    static member MasterDetailPage(?master: XamlElement, ?detail: XamlElement, ?isGestureEnabled: bool, ?isPresented: bool, ?masterBehavior: Xamarin.Forms.MasterBehavior, ?isPresentedChanged: bool -> unit, ?title: string, ?padding: obj, ?useSafeArea: bool, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.Page(?title=title, ?padding=padding, ?useSafeArea=useSafeArea, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match master with None -> () | Some v -> yield ("Master", box ((v))) 
            match detail with None -> () | Some v -> yield ("Detail", box ((v))) 
            match isGestureEnabled with None -> () | Some v -> yield ("IsGestureEnabled", box ((v))) 
            match isPresented with None -> () | Some v -> yield ("IsPresented", box ((v))) 
            match masterBehavior with None -> () | Some v -> yield ("MasterBehavior", box ((v))) 
            match isPresentedChanged with None -> () | Some v -> yield ("IsPresentedChanged", box ((fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.MasterDetailPage).IsPresented))(v))) 
          |]

        let create () =
            box (new Xamarin.Forms.MasterDetailPage())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.MasterDetailPage)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<XamlElement>("Master")
            let valueOpt = source.TryGetAttribute<XamlElement>("Master")
            match prevValueOpt, valueOpt with
            // For structured objects, dependsOn on reference equality
            | ValueSome prevChild, ValueSome newChild when identical prevChild newChild -> ()
            | ValueSome prevChild, ValueSome newChild when canReuseChild prevChild newChild ->
                newChild.UpdateIncremental(prevChild, target.Master)
            | _, ValueSome newChild ->
                target.Master <- (newChild.Create() :?> Xamarin.Forms.Page)
            | ValueSome _, ValueNone ->
                target.Master <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<XamlElement>("Detail")
            let valueOpt = source.TryGetAttribute<XamlElement>("Detail")
            match prevValueOpt, valueOpt with
            // For structured objects, dependsOn on reference equality
            | ValueSome prevChild, ValueSome newChild when identical prevChild newChild -> ()
            | ValueSome prevChild, ValueSome newChild when canReuseChild prevChild newChild ->
                newChild.UpdateIncremental(prevChild, target.Detail)
            | _, ValueSome newChild ->
                target.Detail <- (newChild.Create() :?> Xamarin.Forms.Page)
            | ValueSome _, ValueNone ->
                target.Detail <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<bool>("IsGestureEnabled")
            let valueOpt = source.TryGetAttribute<bool>("IsGestureEnabled")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsGestureEnabled <-  value
            | ValueSome _, ValueNone -> target.IsGestureEnabled <- true
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<bool>("IsPresented")
            let valueOpt = source.TryGetAttribute<bool>("IsPresented")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsPresented <-  value
            | ValueSome _, ValueNone -> target.IsPresented <- true
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.MasterBehavior>("MasterBehavior")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.MasterBehavior>("MasterBehavior")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.MasterBehavior <-  value
            | ValueSome _, ValueNone -> target.MasterBehavior <- Xamarin.Forms.MasterBehavior.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler>("IsPresentedChanged")
            let valueOpt = source.TryGetAttribute<System.EventHandler>("IsPresentedChanged")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.IsPresentedChanged.RemoveHandler(prevValue); target.IsPresentedChanged.AddHandler(value)
            | ValueNone, ValueSome value -> target.IsPresentedChanged.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.IsPresentedChanged.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.MasterDetailPage>, create, update, attribs)

    /// Describes a Cell in the view
    static member internal Cell(?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.Element(?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match height with None -> () | Some v -> yield ("Height", box ((v))) 
            match isEnabled with None -> () | Some v -> yield ("IsEnabled", box ((v))) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.Cell"

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Cell)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<double>("Height")
            let valueOpt = source.TryGetAttribute<double>("Height")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Height <-  value
            | ValueSome _, ValueNone -> target.Height <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<bool>("IsEnabled")
            let valueOpt = source.TryGetAttribute<bool>("IsEnabled")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsEnabled <-  value
            | ValueSome _, ValueNone -> target.IsEnabled <- true
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Cell>, create, update, attribs)

    /// Describes a TextCell in the view
    static member TextCell(?text: string, ?detail: string, ?textColor: Xamarin.Forms.Color, ?detailColor: Xamarin.Forms.Color, ?command: unit -> unit, ?canExecute: bool, ?commandParameter: System.Object, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.Cell(?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match text with None -> () | Some v -> yield ("Text", box ((v))) 
            match detail with None -> () | Some v -> yield ("TextDetail", box ((v))) 
            match textColor with None -> () | Some v -> yield ("TextColor", box ((v))) 
            match detailColor with None -> () | Some v -> yield ("TextDetailColor", box ((v))) 
            match command with None -> () | Some v -> yield ("TextCellCommand", box ((v))) 
            match canExecute with None -> () | Some v -> yield ("TextCellCanExecute", box ((v))) 
            match commandParameter with None -> () | Some v -> yield ("CommandParameter", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.TextCell())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.TextCell)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("Text")
            let valueOpt = source.TryGetAttribute<string>("Text")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("TextDetail")
            let valueOpt = source.TryGetAttribute<string>("TextDetail")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Detail <-  value
            | ValueSome _, ValueNone -> target.Detail <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Color>("TextColor")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Color>("TextColor")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.TextColor <-  value
            | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Color>("TextDetailColor")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Color>("TextDetailColor")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.DetailColor <-  value
            | ValueSome _, ValueNone -> target.DetailColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<unit -> unit>("TextCellCommand")
            let valueOpt = source.TryGetAttribute<unit -> unit>("TextCellCommand")
            (fun _ _ _ -> ()) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<bool>("TextCellCanExecute")
            let valueOpt = source.TryGetAttribute<bool>("TextCellCanExecute")
            updateCommand (match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<_>("TextCellCommand")) prevValueOpt (source.TryGetAttribute<_>("TextCellCommand")) valueOpt (fun cmd -> target.Command <- cmd) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.Object>("CommandParameter")
            let valueOpt = source.TryGetAttribute<System.Object>("CommandParameter")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.CommandParameter <-  value
            | ValueSome _, ValueNone -> target.CommandParameter <- null
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.TextCell>, create, update, attribs)

    /// Describes a ImageCell in the view
    static member ImageCell(?imageSource: string, ?text: string, ?detail: string, ?textColor: Xamarin.Forms.Color, ?detailColor: Xamarin.Forms.Color, ?command: unit -> unit, ?canExecute: bool, ?commandParameter: System.Object, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.TextCell(?text=text, ?detail=detail, ?textColor=textColor, ?detailColor=detailColor, ?command=command, ?canExecute=canExecute, ?commandParameter=commandParameter, ?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match imageSource with None -> () | Some v -> yield ("ImageSource", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.ImageCell())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.ImageCell)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<string>("ImageSource")
            let valueOpt = source.TryGetAttribute<string>("ImageSource")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.ImageSource <- makeImageSource  value
            | ValueSome _, ValueNone -> target.ImageSource <- null
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.ImageCell>, create, update, attribs)

    /// Describes a ViewCell in the view
    static member ViewCell(?view: XamlElement, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.Cell(?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match view with None -> () | Some v -> yield ("View", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.ViewCell())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.ViewCell)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<XamlElement>("View")
            let valueOpt = source.TryGetAttribute<XamlElement>("View")
            match prevValueOpt, valueOpt with
            // For structured objects, dependsOn on reference equality
            | ValueSome prevChild, ValueSome newChild when identical prevChild newChild -> ()
            | ValueSome prevChild, ValueSome newChild when canReuseChild prevChild newChild ->
                newChild.UpdateIncremental(prevChild, target.View)
            | _, ValueSome newChild ->
                target.View <- (newChild.Create() :?> Xamarin.Forms.View)
            | ValueSome _, ValueNone ->
                target.View <- null
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.ViewCell>, create, update, attribs)

    /// Describes a ListView in the view
    static member ListView(?items: seq<XamlElement>, ?footer: System.Object, ?hasUnevenRows: bool, ?header: System.Object, ?headerTemplate: Xamarin.Forms.DataTemplate, ?isGroupingEnabled: bool, ?isPullToRefreshEnabled: bool, ?isRefreshing: bool, ?refreshCommand: unit -> unit, ?rowHeight: int, ?selectedItem: int option, ?separatorVisibility: Xamarin.Forms.SeparatorVisibility, ?separatorColor: Xamarin.Forms.Color, ?itemAppearing: int -> unit, ?itemDisappearing: int -> unit, ?itemSelected: int option -> unit, ?itemTapped: int -> unit, ?refreshing: unit -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match items with None -> () | Some v -> yield ("ListViewItems", box ((v))) 
            match footer with None -> () | Some v -> yield ("Footer", box ((v))) 
            match hasUnevenRows with None -> () | Some v -> yield ("HasUnevenRows", box ((v))) 
            match header with None -> () | Some v -> yield ("Header", box ((v))) 
            match headerTemplate with None -> () | Some v -> yield ("HeaderTemplate", box ((v))) 
            match isGroupingEnabled with None -> () | Some v -> yield ("IsGroupingEnabled", box ((v))) 
            match isPullToRefreshEnabled with None -> () | Some v -> yield ("IsPullToRefreshEnabled", box ((v))) 
            match isRefreshing with None -> () | Some v -> yield ("IsRefreshing", box ((v))) 
            match refreshCommand with None -> () | Some v -> yield ("RefreshCommand", box (makeCommand(v))) 
            match rowHeight with None -> () | Some v -> yield ("RowHeight", box ((v))) 
            match selectedItem with None -> () | Some v -> yield ("ListView_SelectedItem", box ((v))) 
            match separatorVisibility with None -> () | Some v -> yield ("ListView_SeparatorVisibility", box ((v))) 
            match separatorColor with None -> () | Some v -> yield ("ListView_SeparatorColor", box ((v))) 
            match itemAppearing with None -> () | Some v -> yield ("ListView_ItemAppearing", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(v))) 
            match itemDisappearing with None -> () | Some v -> yield ("ListView_ItemDisappearing", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(v))) 
            match itemSelected with None -> () | Some v -> yield ("ListView_ItemSelected", box ((fun f -> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args -> f (tryFindListViewItem sender args.SelectedItem)))(v))) 
            match itemTapped with None -> () | Some v -> yield ("ListView_ItemTapped", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(v))) 
            match refreshing with None -> () | Some v -> yield ("ListView_Refreshing", box ((fun f -> System.EventHandler(fun sender args -> f ()))(v))) 
          |]

        let create () =
            box (new Elmish.XamarinForms.DynamicViews.CustomListView())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.ListView)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<seq<XamlElement>>("ListViewItems")
            let valueOpt = source.TryGetAttribute<seq<XamlElement>>("ListViewItems")
            updateListViewItems prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.Object>("Footer")
            let valueOpt = source.TryGetAttribute<System.Object>("Footer")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Footer <-  value
            | ValueSome _, ValueNone -> target.Footer <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<bool>("HasUnevenRows")
            let valueOpt = source.TryGetAttribute<bool>("HasUnevenRows")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.HasUnevenRows <-  value
            | ValueSome _, ValueNone -> target.HasUnevenRows <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.Object>("Header")
            let valueOpt = source.TryGetAttribute<System.Object>("Header")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Header <-  value
            | ValueSome _, ValueNone -> target.Header <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.DataTemplate>("HeaderTemplate")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.DataTemplate>("HeaderTemplate")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.HeaderTemplate <-  value
            | ValueSome _, ValueNone -> target.HeaderTemplate <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<bool>("IsGroupingEnabled")
            let valueOpt = source.TryGetAttribute<bool>("IsGroupingEnabled")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsGroupingEnabled <-  value
            | ValueSome _, ValueNone -> target.IsGroupingEnabled <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<bool>("IsPullToRefreshEnabled")
            let valueOpt = source.TryGetAttribute<bool>("IsPullToRefreshEnabled")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsPullToRefreshEnabled <-  value
            | ValueSome _, ValueNone -> target.IsPullToRefreshEnabled <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<bool>("IsRefreshing")
            let valueOpt = source.TryGetAttribute<bool>("IsRefreshing")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsRefreshing <-  value
            | ValueSome _, ValueNone -> target.IsRefreshing <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.Windows.Input.ICommand>("RefreshCommand")
            let valueOpt = source.TryGetAttribute<System.Windows.Input.ICommand>("RefreshCommand")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.RefreshCommand <-  value
            | ValueSome _, ValueNone -> target.RefreshCommand <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<int>("RowHeight")
            let valueOpt = source.TryGetAttribute<int>("RowHeight")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.RowHeight <-  value
            | ValueSome _, ValueNone -> target.RowHeight <- -1
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<int option>("ListView_SelectedItem")
            let valueOpt = source.TryGetAttribute<int option>("ListView_SelectedItem")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.SelectedItem <- (function None -> null | Some i -> let items = target.ItemsSource :?> System.Collections.Generic.IList<ListElementData<XamlElement>> in if i >= 0 && i < items.Count then items.[i] else null)  value
            | ValueSome _, ValueNone -> target.SelectedItem <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.SeparatorVisibility>("ListView_SeparatorVisibility")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.SeparatorVisibility>("ListView_SeparatorVisibility")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.SeparatorVisibility <-  value
            | ValueSome _, ValueNone -> target.SeparatorVisibility <- Xamarin.Forms.SeparatorVisibility.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Color>("ListView_SeparatorColor")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Color>("ListView_SeparatorColor")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.SeparatorColor <-  value
            | ValueSome _, ValueNone -> target.SeparatorColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>>("ListView_ItemAppearing")
            let valueOpt = source.TryGetAttribute<System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>>("ListView_ItemAppearing")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ItemAppearing.RemoveHandler(prevValue); target.ItemAppearing.AddHandler(value)
            | ValueNone, ValueSome value -> target.ItemAppearing.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ItemAppearing.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>>("ListView_ItemDisappearing")
            let valueOpt = source.TryGetAttribute<System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>>("ListView_ItemDisappearing")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ItemDisappearing.RemoveHandler(prevValue); target.ItemDisappearing.AddHandler(value)
            | ValueNone, ValueSome value -> target.ItemDisappearing.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ItemDisappearing.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>>("ListView_ItemSelected")
            let valueOpt = source.TryGetAttribute<System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>>("ListView_ItemSelected")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ItemSelected.RemoveHandler(prevValue); target.ItemSelected.AddHandler(value)
            | ValueNone, ValueSome value -> target.ItemSelected.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ItemSelected.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>>("ListView_ItemTapped")
            let valueOpt = source.TryGetAttribute<System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>>("ListView_ItemTapped")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ItemTapped.RemoveHandler(prevValue); target.ItemTapped.AddHandler(value)
            | ValueNone, ValueSome value -> target.ItemTapped.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ItemTapped.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler>("ListView_Refreshing")
            let valueOpt = source.TryGetAttribute<System.EventHandler>("ListView_Refreshing")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.Refreshing.RemoveHandler(prevValue); target.Refreshing.AddHandler(value)
            | ValueNone, ValueSome value -> target.Refreshing.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.Refreshing.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.ListView>, create, update, attribs)

    /// Describes a ListViewGrouped in the view
    static member ListViewGrouped(?items: (XamlElement * XamlElement list) list, ?footer: System.Object, ?hasUnevenRows: bool, ?header: System.Object, ?isGroupingEnabled: bool, ?isPullToRefreshEnabled: bool, ?isRefreshing: bool, ?refreshCommand: unit -> unit, ?rowHeight: int, ?selectedItem: (int * int) option, ?separatorVisibility: Xamarin.Forms.SeparatorVisibility, ?separatorColor: Xamarin.Forms.Color, ?itemAppearing: int * int -> unit, ?itemDisappearing: int * int -> unit, ?itemSelected: (int * int) option -> unit, ?itemTapped: int * int -> unit, ?refreshing: unit -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?classId=classId, ?styleId=styleId)
        let attribs = [| 
            yield! baseElement.AttributesArray
            match items with None -> () | Some v -> yield ("ListViewGrouped_ItemsSource", box ((fun es -> es |> Array.ofList |> Array.map (fun (e,l) -> (e, Array.ofList l)))(v))) 
            match footer with None -> () | Some v -> yield ("Footer", box ((v))) 
            match hasUnevenRows with None -> () | Some v -> yield ("HasUnevenRows", box ((v))) 
            match header with None -> () | Some v -> yield ("Header", box ((v))) 
            match isGroupingEnabled with None -> () | Some v -> yield ("IsGroupingEnabled", box ((v))) 
            match isPullToRefreshEnabled with None -> () | Some v -> yield ("IsPullToRefreshEnabled", box ((v))) 
            match isRefreshing with None -> () | Some v -> yield ("IsRefreshing", box ((v))) 
            match refreshCommand with None -> () | Some v -> yield ("RefreshCommand", box (makeCommand(v))) 
            match rowHeight with None -> () | Some v -> yield ("RowHeight", box ((v))) 
            match selectedItem with None -> () | Some v -> yield ("ListViewGrouped_SelectedItem", box ((v))) 
            match separatorVisibility with None -> () | Some v -> yield ("SeparatorVisibility", box ((v))) 
            match separatorColor with None -> () | Some v -> yield ("SeparatorColor", box ((v))) 
            match itemAppearing with None -> () | Some v -> yield ("ListViewGrouped_ItemAppearing", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(v))) 
            match itemDisappearing with None -> () | Some v -> yield ("ListViewGrouped_ItemDisappearing", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(v))) 
            match itemSelected with None -> () | Some v -> yield ("ListViewGrouped_ItemSelected", box ((fun f -> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.SelectedItem)))(v))) 
            match itemTapped with None -> () | Some v -> yield ("ListViewGrouped_ItemTapped", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(v))) 
            match refreshing with None -> () | Some v -> yield ("Refreshing", box ((fun f -> System.EventHandler(fun sender args -> f ()))(v))) 
          |]

        let create () =
            box (new Elmish.XamarinForms.DynamicViews.CustomGroupListView())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.ListView)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<(XamlElement * XamlElement[])[]>("ListViewGrouped_ItemsSource")
            let valueOpt = source.TryGetAttribute<(XamlElement * XamlElement[])[]>("ListViewGrouped_ItemsSource")
            updateListViewGroupedItems prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.Object>("Footer")
            let valueOpt = source.TryGetAttribute<System.Object>("Footer")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Footer <-  value
            | ValueSome _, ValueNone -> target.Footer <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<bool>("HasUnevenRows")
            let valueOpt = source.TryGetAttribute<bool>("HasUnevenRows")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.HasUnevenRows <-  value
            | ValueSome _, ValueNone -> target.HasUnevenRows <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.Object>("Header")
            let valueOpt = source.TryGetAttribute<System.Object>("Header")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Header <-  value
            | ValueSome _, ValueNone -> target.Header <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<bool>("IsGroupingEnabled")
            let valueOpt = source.TryGetAttribute<bool>("IsGroupingEnabled")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsGroupingEnabled <-  value
            | ValueSome _, ValueNone -> target.IsGroupingEnabled <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<bool>("IsPullToRefreshEnabled")
            let valueOpt = source.TryGetAttribute<bool>("IsPullToRefreshEnabled")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsPullToRefreshEnabled <-  value
            | ValueSome _, ValueNone -> target.IsPullToRefreshEnabled <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<bool>("IsRefreshing")
            let valueOpt = source.TryGetAttribute<bool>("IsRefreshing")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsRefreshing <-  value
            | ValueSome _, ValueNone -> target.IsRefreshing <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.Windows.Input.ICommand>("RefreshCommand")
            let valueOpt = source.TryGetAttribute<System.Windows.Input.ICommand>("RefreshCommand")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.RefreshCommand <-  value
            | ValueSome _, ValueNone -> target.RefreshCommand <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<int>("RowHeight")
            let valueOpt = source.TryGetAttribute<int>("RowHeight")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.RowHeight <-  value
            | ValueSome _, ValueNone -> target.RowHeight <- -1
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<(int * int) option>("ListViewGrouped_SelectedItem")
            let valueOpt = source.TryGetAttribute<(int * int) option>("ListViewGrouped_SelectedItem")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.SelectedItem <- (function None -> null | Some (i,j) -> let items = target.ItemsSource :?> System.Collections.Generic.IList<ListGroupData<XamlElement>> in (if i >= 0 && i < items.Count then (let items2 = items.[i] in if j >= 0 && j < items2.Count then items2.[j] else null) else null))  value
            | ValueSome _, ValueNone -> target.SelectedItem <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.SeparatorVisibility>("SeparatorVisibility")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.SeparatorVisibility>("SeparatorVisibility")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.SeparatorVisibility <-  value
            | ValueSome _, ValueNone -> target.SeparatorVisibility <- Xamarin.Forms.SeparatorVisibility.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<Xamarin.Forms.Color>("SeparatorColor")
            let valueOpt = source.TryGetAttribute<Xamarin.Forms.Color>("SeparatorColor")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.SeparatorColor <-  value
            | ValueSome _, ValueNone -> target.SeparatorColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>>("ListViewGrouped_ItemAppearing")
            let valueOpt = source.TryGetAttribute<System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>>("ListViewGrouped_ItemAppearing")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ItemAppearing.RemoveHandler(prevValue); target.ItemAppearing.AddHandler(value)
            | ValueNone, ValueSome value -> target.ItemAppearing.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ItemAppearing.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>>("ListViewGrouped_ItemDisappearing")
            let valueOpt = source.TryGetAttribute<System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>>("ListViewGrouped_ItemDisappearing")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ItemDisappearing.RemoveHandler(prevValue); target.ItemDisappearing.AddHandler(value)
            | ValueNone, ValueSome value -> target.ItemDisappearing.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ItemDisappearing.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>>("ListViewGrouped_ItemSelected")
            let valueOpt = source.TryGetAttribute<System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>>("ListViewGrouped_ItemSelected")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ItemSelected.RemoveHandler(prevValue); target.ItemSelected.AddHandler(value)
            | ValueNone, ValueSome value -> target.ItemSelected.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ItemSelected.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>>("ListViewGrouped_ItemTapped")
            let valueOpt = source.TryGetAttribute<System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>>("ListViewGrouped_ItemTapped")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ItemTapped.RemoveHandler(prevValue); target.ItemTapped.AddHandler(value)
            | ValueNone, ValueSome value -> target.ItemTapped.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ItemTapped.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttribute<System.EventHandler>("Refreshing")
            let valueOpt = source.TryGetAttribute<System.EventHandler>("Refreshing")
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.Refreshing.RemoveHandler(prevValue); target.Refreshing.AddHandler(value)
            | ValueNone, ValueSome value -> target.Refreshing.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.Refreshing.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.ListView>, create, update, attribs)
