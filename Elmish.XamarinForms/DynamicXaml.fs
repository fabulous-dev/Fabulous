namespace rec Elmish.XamarinForms.DynamicViews

#nowarn "67" // cast always holds

    /// Produce a new visual element with an adjusted attribute
[<AutoOpen>]
module XamlElementExtensions = 

    type XamlElement with

        /// Create a Xamarin.Forms.Element from the view description
        member x.CreateAsElement() : Xamarin.Forms.Element =
            match x.Create() with
            | :? Xamarin.Forms.Element as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.Element' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.VisualElement from the view description
        member x.CreateAsVisualElement() : Xamarin.Forms.VisualElement =
            match x.Create() with
            | :? Xamarin.Forms.VisualElement as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.VisualElement' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.View from the view description
        member x.CreateAsView() : Xamarin.Forms.View =
            match x.Create() with
            | :? Xamarin.Forms.View as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.View' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.IGestureRecognizer from the view description
        member x.CreateAsIGestureRecognizer() : Xamarin.Forms.IGestureRecognizer =
            match x.Create() with
            | :? Xamarin.Forms.IGestureRecognizer as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.IGestureRecognizer' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.PanGestureRecognizer from the view description
        member x.CreateAsPanGestureRecognizer() : Xamarin.Forms.PanGestureRecognizer =
            match x.Create() with
            | :? Xamarin.Forms.PanGestureRecognizer as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.PanGestureRecognizer' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.TapGestureRecognizer from the view description
        member x.CreateAsTapGestureRecognizer() : Xamarin.Forms.TapGestureRecognizer =
            match x.Create() with
            | :? Xamarin.Forms.TapGestureRecognizer as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.TapGestureRecognizer' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.ClickGestureRecognizer from the view description
        member x.CreateAsClickGestureRecognizer() : Xamarin.Forms.ClickGestureRecognizer =
            match x.Create() with
            | :? Xamarin.Forms.ClickGestureRecognizer as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.ClickGestureRecognizer' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.PinchGestureRecognizer from the view description
        member x.CreateAsPinchGestureRecognizer() : Xamarin.Forms.PinchGestureRecognizer =
            match x.Create() with
            | :? Xamarin.Forms.PinchGestureRecognizer as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.PinchGestureRecognizer' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.ActivityIndicator from the view description
        member x.CreateAsActivityIndicator() : Xamarin.Forms.ActivityIndicator =
            match x.Create() with
            | :? Xamarin.Forms.ActivityIndicator as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.ActivityIndicator' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.BoxView from the view description
        member x.CreateAsBoxView() : Xamarin.Forms.BoxView =
            match x.Create() with
            | :? Xamarin.Forms.BoxView as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.BoxView' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.ProgressBar from the view description
        member x.CreateAsProgressBar() : Xamarin.Forms.ProgressBar =
            match x.Create() with
            | :? Xamarin.Forms.ProgressBar as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.ProgressBar' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.ScrollView from the view description
        member x.CreateAsScrollView() : Xamarin.Forms.ScrollView =
            match x.Create() with
            | :? Xamarin.Forms.ScrollView as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.ScrollView' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.SearchBar from the view description
        member x.CreateAsSearchBar() : Xamarin.Forms.SearchBar =
            match x.Create() with
            | :? Xamarin.Forms.SearchBar as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.SearchBar' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Button from the view description
        member x.CreateAsButton() : Xamarin.Forms.Button =
            match x.Create() with
            | :? Xamarin.Forms.Button as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.Button' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Slider from the view description
        member x.CreateAsSlider() : Xamarin.Forms.Slider =
            match x.Create() with
            | :? Xamarin.Forms.Slider as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.Slider' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Stepper from the view description
        member x.CreateAsStepper() : Xamarin.Forms.Stepper =
            match x.Create() with
            | :? Xamarin.Forms.Stepper as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.Stepper' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Switch from the view description
        member x.CreateAsSwitch() : Xamarin.Forms.Switch =
            match x.Create() with
            | :? Xamarin.Forms.Switch as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.Switch' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.SwitchCell from the view description
        member x.CreateAsSwitchCell() : Xamarin.Forms.SwitchCell =
            match x.Create() with
            | :? Xamarin.Forms.SwitchCell as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.SwitchCell' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.TableView from the view description
        member x.CreateAsTableView() : Xamarin.Forms.TableView =
            match x.Create() with
            | :? Xamarin.Forms.TableView as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.TableView' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Grid from the view description
        member x.CreateAsGrid() : Xamarin.Forms.Grid =
            match x.Create() with
            | :? Xamarin.Forms.Grid as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.Grid' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.AbsoluteLayout from the view description
        member x.CreateAsAbsoluteLayout() : Xamarin.Forms.AbsoluteLayout =
            match x.Create() with
            | :? Xamarin.Forms.AbsoluteLayout as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.AbsoluteLayout' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.RelativeLayout from the view description
        member x.CreateAsRelativeLayout() : Xamarin.Forms.RelativeLayout =
            match x.Create() with
            | :? Xamarin.Forms.RelativeLayout as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.RelativeLayout' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.RowDefinition from the view description
        member x.CreateAsRowDefinition() : Xamarin.Forms.RowDefinition =
            match x.Create() with
            | :? Xamarin.Forms.RowDefinition as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.RowDefinition' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.ColumnDefinition from the view description
        member x.CreateAsColumnDefinition() : Xamarin.Forms.ColumnDefinition =
            match x.Create() with
            | :? Xamarin.Forms.ColumnDefinition as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.ColumnDefinition' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.ContentView from the view description
        member x.CreateAsContentView() : Xamarin.Forms.ContentView =
            match x.Create() with
            | :? Xamarin.Forms.ContentView as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.ContentView' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.TemplatedView from the view description
        member x.CreateAsTemplatedView() : Xamarin.Forms.TemplatedView =
            match x.Create() with
            | :? Xamarin.Forms.TemplatedView as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.TemplatedView' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.DatePicker from the view description
        member x.CreateAsDatePicker() : Xamarin.Forms.DatePicker =
            match x.Create() with
            | :? Xamarin.Forms.DatePicker as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.DatePicker' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Picker from the view description
        member x.CreateAsPicker() : Xamarin.Forms.Picker =
            match x.Create() with
            | :? Xamarin.Forms.Picker as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.Picker' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Frame from the view description
        member x.CreateAsFrame() : Xamarin.Forms.Frame =
            match x.Create() with
            | :? Xamarin.Forms.Frame as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.Frame' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Image from the view description
        member x.CreateAsImage() : Xamarin.Forms.Image =
            match x.Create() with
            | :? Xamarin.Forms.Image as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.Image' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.InputView from the view description
        member x.CreateAsInputView() : Xamarin.Forms.InputView =
            match x.Create() with
            | :? Xamarin.Forms.InputView as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.InputView' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Editor from the view description
        member x.CreateAsEditor() : Xamarin.Forms.Editor =
            match x.Create() with
            | :? Xamarin.Forms.Editor as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.Editor' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Entry from the view description
        member x.CreateAsEntry() : Xamarin.Forms.Entry =
            match x.Create() with
            | :? Xamarin.Forms.Entry as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.Entry' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.EntryCell from the view description
        member x.CreateAsEntryCell() : Xamarin.Forms.EntryCell =
            match x.Create() with
            | :? Xamarin.Forms.EntryCell as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.EntryCell' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Label from the view description
        member x.CreateAsLabel() : Xamarin.Forms.Label =
            match x.Create() with
            | :? Xamarin.Forms.Label as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.Label' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Layout from the view description
        member x.CreateAsLayout() : Xamarin.Forms.Layout =
            match x.Create() with
            | :? Xamarin.Forms.Layout as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.Layout' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.StackLayout from the view description
        member x.CreateAsStackLayout() : Xamarin.Forms.StackLayout =
            match x.Create() with
            | :? Xamarin.Forms.StackLayout as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.StackLayout' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Span from the view description
        member x.CreateAsSpan() : Xamarin.Forms.Span =
            match x.Create() with
            | :? Xamarin.Forms.Span as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.Span' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.TimePicker from the view description
        member x.CreateAsTimePicker() : Xamarin.Forms.TimePicker =
            match x.Create() with
            | :? Xamarin.Forms.TimePicker as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.TimePicker' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.WebView from the view description
        member x.CreateAsWebView() : Xamarin.Forms.WebView =
            match x.Create() with
            | :? Xamarin.Forms.WebView as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.WebView' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Page from the view description
        member x.CreateAsPage() : Xamarin.Forms.Page =
            match x.Create() with
            | :? Xamarin.Forms.Page as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.Page' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.CarouselPage from the view description
        member x.CreateAsCarouselPage() : Xamarin.Forms.CarouselPage =
            match x.Create() with
            | :? Xamarin.Forms.CarouselPage as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.CarouselPage' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.NavigationPage from the view description
        member x.CreateAsNavigationPage() : Xamarin.Forms.NavigationPage =
            match x.Create() with
            | :? Xamarin.Forms.NavigationPage as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.NavigationPage' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.TabbedPage from the view description
        member x.CreateAsTabbedPage() : Xamarin.Forms.TabbedPage =
            match x.Create() with
            | :? Xamarin.Forms.TabbedPage as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.TabbedPage' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.ContentPage from the view description
        member x.CreateAsContentPage() : Xamarin.Forms.ContentPage =
            match x.Create() with
            | :? Xamarin.Forms.ContentPage as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.ContentPage' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.MasterDetailPage from the view description
        member x.CreateAsMasterDetailPage() : Xamarin.Forms.MasterDetailPage =
            match x.Create() with
            | :? Xamarin.Forms.MasterDetailPage as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.MasterDetailPage' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Cell from the view description
        member x.CreateAsCell() : Xamarin.Forms.Cell =
            match x.Create() with
            | :? Xamarin.Forms.Cell as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.Cell' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.TextCell from the view description
        member x.CreateAsTextCell() : Xamarin.Forms.TextCell =
            match x.Create() with
            | :? Xamarin.Forms.TextCell as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.TextCell' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.ImageCell from the view description
        member x.CreateAsImageCell() : Xamarin.Forms.ImageCell =
            match x.Create() with
            | :? Xamarin.Forms.ImageCell as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.ImageCell' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.ViewCell from the view description
        member x.CreateAsViewCell() : Xamarin.Forms.ViewCell =
            match x.Create() with
            | :? Xamarin.Forms.ViewCell as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.ViewCell' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.ListView from the view description
        member x.CreateAsListView() : Xamarin.Forms.ListView =
            match x.Create() with
            | :? Xamarin.Forms.ListView as res -> res
            | obj -> failwithf "Incorrect element type in view, expected a 'Xamarin.Forms.ListView' but got a '%s')" (obj.GetType().ToString()) 


        /// Try to get the ClassId property in the visual element
        member x.TryClassId = match x.Attributes.TryFind("ClassId") with Some v -> USome(unbox<string>(v)) | None -> UNone

        /// Try to get the StyleId property in the visual element
        member x.TryStyleId = match x.Attributes.TryFind("StyleId") with Some v -> USome(unbox<string>(v)) | None -> UNone

        /// Try to get the AnchorX property in the visual element
        member x.TryAnchorX = match x.Attributes.TryFind("AnchorX") with Some v -> USome(unbox<double>(v)) | None -> UNone

        /// Try to get the AnchorY property in the visual element
        member x.TryAnchorY = match x.Attributes.TryFind("AnchorY") with Some v -> USome(unbox<double>(v)) | None -> UNone

        /// Try to get the BackgroundColor property in the visual element
        member x.TryBackgroundColor = match x.Attributes.TryFind("BackgroundColor") with Some v -> USome(unbox<Xamarin.Forms.Color>(v)) | None -> UNone

        /// Try to get the HeightRequest property in the visual element
        member x.TryHeightRequest = match x.Attributes.TryFind("HeightRequest") with Some v -> USome(unbox<double>(v)) | None -> UNone

        /// Try to get the InputTransparent property in the visual element
        member x.TryInputTransparent = match x.Attributes.TryFind("InputTransparent") with Some v -> USome(unbox<bool>(v)) | None -> UNone

        /// Try to get the IsEnabled property in the visual element
        member x.TryIsEnabled = match x.Attributes.TryFind("IsEnabled") with Some v -> USome(unbox<bool>(v)) | None -> UNone

        /// Try to get the IsVisible property in the visual element
        member x.TryIsVisible = match x.Attributes.TryFind("IsVisible") with Some v -> USome(unbox<bool>(v)) | None -> UNone

        /// Try to get the MinimumHeightRequest property in the visual element
        member x.TryMinimumHeightRequest = match x.Attributes.TryFind("MinimumHeightRequest") with Some v -> USome(unbox<double>(v)) | None -> UNone

        /// Try to get the MinimumWidthRequest property in the visual element
        member x.TryMinimumWidthRequest = match x.Attributes.TryFind("MinimumWidthRequest") with Some v -> USome(unbox<double>(v)) | None -> UNone

        /// Try to get the Opacity property in the visual element
        member x.TryOpacity = match x.Attributes.TryFind("Opacity") with Some v -> USome(unbox<double>(v)) | None -> UNone

        /// Try to get the Rotation property in the visual element
        member x.TryRotation = match x.Attributes.TryFind("Rotation") with Some v -> USome(unbox<double>(v)) | None -> UNone

        /// Try to get the RotationX property in the visual element
        member x.TryRotationX = match x.Attributes.TryFind("RotationX") with Some v -> USome(unbox<double>(v)) | None -> UNone

        /// Try to get the RotationY property in the visual element
        member x.TryRotationY = match x.Attributes.TryFind("RotationY") with Some v -> USome(unbox<double>(v)) | None -> UNone

        /// Try to get the Scale property in the visual element
        member x.TryScale = match x.Attributes.TryFind("Scale") with Some v -> USome(unbox<double>(v)) | None -> UNone

        /// Try to get the Style property in the visual element
        member x.TryStyle = match x.Attributes.TryFind("Style") with Some v -> USome(unbox<Xamarin.Forms.Style>(v)) | None -> UNone

        /// Try to get the TranslationX property in the visual element
        member x.TryTranslationX = match x.Attributes.TryFind("TranslationX") with Some v -> USome(unbox<double>(v)) | None -> UNone

        /// Try to get the TranslationY property in the visual element
        member x.TryTranslationY = match x.Attributes.TryFind("TranslationY") with Some v -> USome(unbox<double>(v)) | None -> UNone

        /// Try to get the WidthRequest property in the visual element
        member x.TryWidthRequest = match x.Attributes.TryFind("WidthRequest") with Some v -> USome(unbox<double>(v)) | None -> UNone

        /// Try to get the HorizontalOptions property in the visual element
        member x.TryHorizontalOptions = match x.Attributes.TryFind("HorizontalOptions") with Some v -> USome(unbox<Xamarin.Forms.LayoutOptions>(v)) | None -> UNone

        /// Try to get the VerticalOptions property in the visual element
        member x.TryVerticalOptions = match x.Attributes.TryFind("VerticalOptions") with Some v -> USome(unbox<Xamarin.Forms.LayoutOptions>(v)) | None -> UNone

        /// Try to get the Margin property in the visual element
        member x.TryMargin = match x.Attributes.TryFind("Margin") with Some v -> USome(unbox<Xamarin.Forms.Thickness>(v)) | None -> UNone

        /// Try to get the GestureRecognizers property in the visual element
        member x.TryGestureRecognizers = match x.Attributes.TryFind("GestureRecognizers") with Some v -> USome(unbox<XamlElement[]>(v)) | None -> UNone

        /// Try to get the TouchPoints property in the visual element
        member x.TryTouchPoints = match x.Attributes.TryFind("TouchPoints") with Some v -> USome(unbox<int>(v)) | None -> UNone

        /// Try to get the PanUpdated property in the visual element
        member x.TryPanUpdated = match x.Attributes.TryFind("PanUpdated") with Some v -> USome(unbox<System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>>(v)) | None -> UNone

        /// Try to get the Command property in the visual element
        member x.TryCommand = match x.Attributes.TryFind("Command") with Some v -> USome(unbox<System.Windows.Input.ICommand>(v)) | None -> UNone

        /// Try to get the NumberOfTapsRequired property in the visual element
        member x.TryNumberOfTapsRequired = match x.Attributes.TryFind("NumberOfTapsRequired") with Some v -> USome(unbox<int>(v)) | None -> UNone

        /// Try to get the NumberOfClicksRequired property in the visual element
        member x.TryNumberOfClicksRequired = match x.Attributes.TryFind("NumberOfClicksRequired") with Some v -> USome(unbox<int>(v)) | None -> UNone

        /// Try to get the Buttons property in the visual element
        member x.TryButtons = match x.Attributes.TryFind("Buttons") with Some v -> USome(unbox<Xamarin.Forms.ButtonsMask>(v)) | None -> UNone

        /// Try to get the IsPinching property in the visual element
        member x.TryIsPinching = match x.Attributes.TryFind("IsPinching") with Some v -> USome(unbox<bool>(v)) | None -> UNone

        /// Try to get the PinchUpdated property in the visual element
        member x.TryPinchUpdated = match x.Attributes.TryFind("PinchUpdated") with Some v -> USome(unbox<System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>>(v)) | None -> UNone

        /// Try to get the Color property in the visual element
        member x.TryColor = match x.Attributes.TryFind("Color") with Some v -> USome(unbox<Xamarin.Forms.Color>(v)) | None -> UNone

        /// Try to get the IsRunning property in the visual element
        member x.TryIsRunning = match x.Attributes.TryFind("IsRunning") with Some v -> USome(unbox<bool>(v)) | None -> UNone

        /// Try to get the Progress property in the visual element
        member x.TryProgress = match x.Attributes.TryFind("Progress") with Some v -> USome(unbox<double>(v)) | None -> UNone

        /// Try to get the Content property in the visual element
        member x.TryContent = match x.Attributes.TryFind("Content") with Some v -> USome(unbox<XamlElement>(v)) | None -> UNone

        /// Try to get the ScrollOrientation property in the visual element
        member x.TryScrollOrientation = match x.Attributes.TryFind("ScrollOrientation") with Some v -> USome(unbox<Xamarin.Forms.ScrollOrientation>(v)) | None -> UNone

        /// Try to get the CancelButtonColor property in the visual element
        member x.TryCancelButtonColor = match x.Attributes.TryFind("CancelButtonColor") with Some v -> USome(unbox<Xamarin.Forms.Color>(v)) | None -> UNone

        /// Try to get the FontFamily property in the visual element
        member x.TryFontFamily = match x.Attributes.TryFind("FontFamily") with Some v -> USome(unbox<string>(v)) | None -> UNone

        /// Try to get the FontAttributes property in the visual element
        member x.TryFontAttributes = match x.Attributes.TryFind("FontAttributes") with Some v -> USome(unbox<Xamarin.Forms.FontAttributes>(v)) | None -> UNone

        /// Try to get the FontSize property in the visual element
        member x.TryFontSize = match x.Attributes.TryFind("FontSize") with Some v -> USome(unbox<double>(v)) | None -> UNone

        /// Try to get the HorizontalTextAlignment property in the visual element
        member x.TryHorizontalTextAlignment = match x.Attributes.TryFind("HorizontalTextAlignment") with Some v -> USome(unbox<Xamarin.Forms.TextAlignment>(v)) | None -> UNone

        /// Try to get the Placeholder property in the visual element
        member x.TryPlaceholder = match x.Attributes.TryFind("Placeholder") with Some v -> USome(unbox<string>(v)) | None -> UNone

        /// Try to get the PlaceholderColor property in the visual element
        member x.TryPlaceholderColor = match x.Attributes.TryFind("PlaceholderColor") with Some v -> USome(unbox<Xamarin.Forms.Color>(v)) | None -> UNone

        /// Try to get the SearchBarCommand property in the visual element
        member x.TrySearchBarCommand = match x.Attributes.TryFind("SearchBarCommand") with Some v -> USome(unbox<unit -> unit>(v)) | None -> UNone

        /// Try to get the SearchBarCanExecute property in the visual element
        member x.TrySearchBarCanExecute = match x.Attributes.TryFind("SearchBarCanExecute") with Some v -> USome(unbox<bool>(v)) | None -> UNone

        /// Try to get the Text property in the visual element
        member x.TryText = match x.Attributes.TryFind("Text") with Some v -> USome(unbox<string>(v)) | None -> UNone

        /// Try to get the TextColor property in the visual element
        member x.TryTextColor = match x.Attributes.TryFind("TextColor") with Some v -> USome(unbox<Xamarin.Forms.Color>(v)) | None -> UNone

        /// Try to get the ButtonCommand property in the visual element
        member x.TryButtonCommand = match x.Attributes.TryFind("ButtonCommand") with Some v -> USome(unbox<unit -> unit>(v)) | None -> UNone

        /// Try to get the ButtonCanExecute property in the visual element
        member x.TryButtonCanExecute = match x.Attributes.TryFind("ButtonCanExecute") with Some v -> USome(unbox<bool>(v)) | None -> UNone

        /// Try to get the BorderColor property in the visual element
        member x.TryBorderColor = match x.Attributes.TryFind("BorderColor") with Some v -> USome(unbox<Xamarin.Forms.Color>(v)) | None -> UNone

        /// Try to get the BorderWidth property in the visual element
        member x.TryBorderWidth = match x.Attributes.TryFind("BorderWidth") with Some v -> USome(unbox<double>(v)) | None -> UNone

        /// Try to get the CommandParameter property in the visual element
        member x.TryCommandParameter = match x.Attributes.TryFind("CommandParameter") with Some v -> USome(unbox<System.Object>(v)) | None -> UNone

        /// Try to get the ContentLayout property in the visual element
        member x.TryContentLayout = match x.Attributes.TryFind("ContentLayout") with Some v -> USome(unbox<Xamarin.Forms.Button.ButtonContentLayout>(v)) | None -> UNone

        /// Try to get the ButtonImageSource property in the visual element
        member x.TryButtonImageSource = match x.Attributes.TryFind("ButtonImageSource") with Some v -> USome(unbox<string>(v)) | None -> UNone

        /// Try to get the Minimum property in the visual element
        member x.TryMinimum = match x.Attributes.TryFind("Minimum") with Some v -> USome(unbox<double>(v)) | None -> UNone

        /// Try to get the Maximum property in the visual element
        member x.TryMaximum = match x.Attributes.TryFind("Maximum") with Some v -> USome(unbox<double>(v)) | None -> UNone

        /// Try to get the Value property in the visual element
        member x.TryValue = match x.Attributes.TryFind("Value") with Some v -> USome(unbox<double>(v)) | None -> UNone

        /// Try to get the ValueChanged property in the visual element
        member x.TryValueChanged = match x.Attributes.TryFind("ValueChanged") with Some v -> USome(unbox<System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>>(v)) | None -> UNone

        /// Try to get the Increment property in the visual element
        member x.TryIncrement = match x.Attributes.TryFind("Increment") with Some v -> USome(unbox<double>(v)) | None -> UNone

        /// Try to get the IsToggled property in the visual element
        member x.TryIsToggled = match x.Attributes.TryFind("IsToggled") with Some v -> USome(unbox<bool>(v)) | None -> UNone

        /// Try to get the Toggled property in the visual element
        member x.TryToggled = match x.Attributes.TryFind("Toggled") with Some v -> USome(unbox<System.EventHandler<Xamarin.Forms.ToggledEventArgs>>(v)) | None -> UNone

        /// Try to get the On property in the visual element
        member x.TryOn = match x.Attributes.TryFind("On") with Some v -> USome(unbox<bool>(v)) | None -> UNone

        /// Try to get the OnChanged property in the visual element
        member x.TryOnChanged = match x.Attributes.TryFind("OnChanged") with Some v -> USome(unbox<System.EventHandler<Xamarin.Forms.ToggledEventArgs>>(v)) | None -> UNone

        /// Try to get the Intent property in the visual element
        member x.TryIntent = match x.Attributes.TryFind("Intent") with Some v -> USome(unbox<Xamarin.Forms.TableIntent>(v)) | None -> UNone

        /// Try to get the HasUnevenRows property in the visual element
        member x.TryHasUnevenRows = match x.Attributes.TryFind("HasUnevenRows") with Some v -> USome(unbox<bool>(v)) | None -> UNone

        /// Try to get the RowHeight property in the visual element
        member x.TryRowHeight = match x.Attributes.TryFind("RowHeight") with Some v -> USome(unbox<int>(v)) | None -> UNone

        /// Try to get the TableRoot property in the visual element
        member x.TryTableRoot = match x.Attributes.TryFind("TableRoot") with Some v -> USome(unbox<(string * XamlElement[])[]>(v)) | None -> UNone

        /// Try to get the GridRowDefinitions property in the visual element
        member x.TryGridRowDefinitions = match x.Attributes.TryFind("GridRowDefinitions") with Some v -> USome(unbox<XamlElement[]>(v)) | None -> UNone

        /// Try to get the GridColumnDefinitions property in the visual element
        member x.TryGridColumnDefinitions = match x.Attributes.TryFind("GridColumnDefinitions") with Some v -> USome(unbox<XamlElement[]>(v)) | None -> UNone

        /// Try to get the RowSpacing property in the visual element
        member x.TryRowSpacing = match x.Attributes.TryFind("RowSpacing") with Some v -> USome(unbox<double>(v)) | None -> UNone

        /// Try to get the ColumnSpacing property in the visual element
        member x.TryColumnSpacing = match x.Attributes.TryFind("ColumnSpacing") with Some v -> USome(unbox<double>(v)) | None -> UNone

        /// Try to get the Children property in the visual element
        member x.TryChildren = match x.Attributes.TryFind("Children") with Some v -> USome(unbox<XamlElement[]>(v)) | None -> UNone

        /// Try to get the GridRow property in the visual element
        member x.TryGridRow = match x.Attributes.TryFind("GridRow") with Some v -> USome(unbox<int>(v)) | None -> UNone

        /// Try to get the GridRowSpan property in the visual element
        member x.TryGridRowSpan = match x.Attributes.TryFind("GridRowSpan") with Some v -> USome(unbox<int>(v)) | None -> UNone

        /// Try to get the GridColumn property in the visual element
        member x.TryGridColumn = match x.Attributes.TryFind("GridColumn") with Some v -> USome(unbox<int>(v)) | None -> UNone

        /// Try to get the GridColumnSpan property in the visual element
        member x.TryGridColumnSpan = match x.Attributes.TryFind("GridColumnSpan") with Some v -> USome(unbox<int>(v)) | None -> UNone

        /// Try to get the LayoutBounds property in the visual element
        member x.TryLayoutBounds = match x.Attributes.TryFind("LayoutBounds") with Some v -> USome(unbox<Xamarin.Forms.Rectangle>(v)) | None -> UNone

        /// Try to get the LayoutFlags property in the visual element
        member x.TryLayoutFlags = match x.Attributes.TryFind("LayoutFlags") with Some v -> USome(unbox<Xamarin.Forms.AbsoluteLayoutFlags>(v)) | None -> UNone

        /// Try to get the BoundsConstraint property in the visual element
        member x.TryBoundsConstraint = match x.Attributes.TryFind("BoundsConstraint") with Some v -> USome(unbox<Xamarin.Forms.BoundsConstraint>(v)) | None -> UNone

        /// Try to get the HeightConstraint property in the visual element
        member x.TryHeightConstraint = match x.Attributes.TryFind("HeightConstraint") with Some v -> USome(unbox<Xamarin.Forms.Constraint>(v)) | None -> UNone

        /// Try to get the WidthConstraint property in the visual element
        member x.TryWidthConstraint = match x.Attributes.TryFind("WidthConstraint") with Some v -> USome(unbox<Xamarin.Forms.Constraint>(v)) | None -> UNone

        /// Try to get the XConstraint property in the visual element
        member x.TryXConstraint = match x.Attributes.TryFind("XConstraint") with Some v -> USome(unbox<Xamarin.Forms.Constraint>(v)) | None -> UNone

        /// Try to get the YConstraint property in the visual element
        member x.TryYConstraint = match x.Attributes.TryFind("YConstraint") with Some v -> USome(unbox<Xamarin.Forms.Constraint>(v)) | None -> UNone

        /// Try to get the RowDefinitionHeight property in the visual element
        member x.TryRowDefinitionHeight = match x.Attributes.TryFind("RowDefinitionHeight") with Some v -> USome(unbox<Xamarin.Forms.GridLength>(v)) | None -> UNone

        /// Try to get the ColumnDefinitionWidth property in the visual element
        member x.TryColumnDefinitionWidth = match x.Attributes.TryFind("ColumnDefinitionWidth") with Some v -> USome(unbox<Xamarin.Forms.GridLength>(v)) | None -> UNone

        /// Try to get the Date property in the visual element
        member x.TryDate = match x.Attributes.TryFind("Date") with Some v -> USome(unbox<System.DateTime>(v)) | None -> UNone

        /// Try to get the Format property in the visual element
        member x.TryFormat = match x.Attributes.TryFind("Format") with Some v -> USome(unbox<string>(v)) | None -> UNone

        /// Try to get the MinimumDate property in the visual element
        member x.TryMinimumDate = match x.Attributes.TryFind("MinimumDate") with Some v -> USome(unbox<System.DateTime>(v)) | None -> UNone

        /// Try to get the MaximumDate property in the visual element
        member x.TryMaximumDate = match x.Attributes.TryFind("MaximumDate") with Some v -> USome(unbox<System.DateTime>(v)) | None -> UNone

        /// Try to get the DateSelected property in the visual element
        member x.TryDateSelected = match x.Attributes.TryFind("DateSelected") with Some v -> USome(unbox<System.EventHandler<Xamarin.Forms.DateChangedEventArgs>>(v)) | None -> UNone

        /// Try to get the PickerItemsSource property in the visual element
        member x.TryPickerItemsSource = match x.Attributes.TryFind("PickerItemsSource") with Some v -> USome(unbox<System.Collections.IList>(v)) | None -> UNone

        /// Try to get the SelectedIndex property in the visual element
        member x.TrySelectedIndex = match x.Attributes.TryFind("SelectedIndex") with Some v -> USome(unbox<int>(v)) | None -> UNone

        /// Try to get the Title property in the visual element
        member x.TryTitle = match x.Attributes.TryFind("Title") with Some v -> USome(unbox<string>(v)) | None -> UNone

        /// Try to get the SelectedIndexChanged property in the visual element
        member x.TrySelectedIndexChanged = match x.Attributes.TryFind("SelectedIndexChanged") with Some v -> USome(unbox<System.EventHandler>(v)) | None -> UNone

        /// Try to get the OutlineColor property in the visual element
        member x.TryOutlineColor = match x.Attributes.TryFind("OutlineColor") with Some v -> USome(unbox<Xamarin.Forms.Color>(v)) | None -> UNone

        /// Try to get the FrameCornerRadius property in the visual element
        member x.TryFrameCornerRadius = match x.Attributes.TryFind("FrameCornerRadius") with Some v -> USome(unbox<single>(v)) | None -> UNone

        /// Try to get the HasShadow property in the visual element
        member x.TryHasShadow = match x.Attributes.TryFind("HasShadow") with Some v -> USome(unbox<bool>(v)) | None -> UNone

        /// Try to get the ImageSource property in the visual element
        member x.TryImageSource = match x.Attributes.TryFind("ImageSource") with Some v -> USome(unbox<string>(v)) | None -> UNone

        /// Try to get the Aspect property in the visual element
        member x.TryAspect = match x.Attributes.TryFind("Aspect") with Some v -> USome(unbox<Xamarin.Forms.Aspect>(v)) | None -> UNone

        /// Try to get the IsOpaque property in the visual element
        member x.TryIsOpaque = match x.Attributes.TryFind("IsOpaque") with Some v -> USome(unbox<bool>(v)) | None -> UNone

        /// Try to get the Keyboard property in the visual element
        member x.TryKeyboard = match x.Attributes.TryFind("Keyboard") with Some v -> USome(unbox<Xamarin.Forms.Keyboard>(v)) | None -> UNone

        /// Try to get the EditorCompleted property in the visual element
        member x.TryEditorCompleted = match x.Attributes.TryFind("EditorCompleted") with Some v -> USome(unbox<System.EventHandler>(v)) | None -> UNone

        /// Try to get the TextChanged property in the visual element
        member x.TryTextChanged = match x.Attributes.TryFind("TextChanged") with Some v -> USome(unbox<System.EventHandler<Xamarin.Forms.TextChangedEventArgs>>(v)) | None -> UNone

        /// Try to get the IsPassword property in the visual element
        member x.TryIsPassword = match x.Attributes.TryFind("IsPassword") with Some v -> USome(unbox<bool>(v)) | None -> UNone

        /// Try to get the EntryCompleted property in the visual element
        member x.TryEntryCompleted = match x.Attributes.TryFind("EntryCompleted") with Some v -> USome(unbox<System.EventHandler>(v)) | None -> UNone

        /// Try to get the Label property in the visual element
        member x.TryLabel = match x.Attributes.TryFind("Label") with Some v -> USome(unbox<string>(v)) | None -> UNone

        /// Try to get the VerticalTextAlignment property in the visual element
        member x.TryVerticalTextAlignment = match x.Attributes.TryFind("VerticalTextAlignment") with Some v -> USome(unbox<Xamarin.Forms.TextAlignment>(v)) | None -> UNone

        /// Try to get the IsClippedToBounds property in the visual element
        member x.TryIsClippedToBounds = match x.Attributes.TryFind("IsClippedToBounds") with Some v -> USome(unbox<bool>(v)) | None -> UNone

        /// Try to get the Padding property in the visual element
        member x.TryPadding = match x.Attributes.TryFind("Padding") with Some v -> USome(unbox<Xamarin.Forms.Thickness>(v)) | None -> UNone

        /// Try to get the StackOrientation property in the visual element
        member x.TryStackOrientation = match x.Attributes.TryFind("StackOrientation") with Some v -> USome(unbox<Xamarin.Forms.StackOrientation>(v)) | None -> UNone

        /// Try to get the Spacing property in the visual element
        member x.TrySpacing = match x.Attributes.TryFind("Spacing") with Some v -> USome(unbox<double>(v)) | None -> UNone

        /// Try to get the ForegroundColor property in the visual element
        member x.TryForegroundColor = match x.Attributes.TryFind("ForegroundColor") with Some v -> USome(unbox<Xamarin.Forms.Color>(v)) | None -> UNone

        /// Try to get the PropertyChanged property in the visual element
        member x.TryPropertyChanged = match x.Attributes.TryFind("PropertyChanged") with Some v -> USome(unbox<System.ComponentModel.PropertyChangedEventHandler>(v)) | None -> UNone

        /// Try to get the Time property in the visual element
        member x.TryTime = match x.Attributes.TryFind("Time") with Some v -> USome(unbox<System.TimeSpan>(v)) | None -> UNone

        /// Try to get the WebSource property in the visual element
        member x.TryWebSource = match x.Attributes.TryFind("WebSource") with Some v -> USome(unbox<Xamarin.Forms.WebViewSource>(v)) | None -> UNone

        /// Try to get the Navigated property in the visual element
        member x.TryNavigated = match x.Attributes.TryFind("Navigated") with Some v -> USome(unbox<System.EventHandler<Xamarin.Forms.WebNavigatedEventArgs>>(v)) | None -> UNone

        /// Try to get the Navigating property in the visual element
        member x.TryNavigating = match x.Attributes.TryFind("Navigating") with Some v -> USome(unbox<System.EventHandler<Xamarin.Forms.WebNavigatingEventArgs>>(v)) | None -> UNone

        /// Try to get the UseSafeArea property in the visual element
        member x.TryUseSafeArea = match x.Attributes.TryFind("UseSafeArea") with Some v -> USome(unbox<bool>(v)) | None -> UNone

        /// Try to get the ItemsSource property in the visual element
        member x.TryItemsSource = match x.Attributes.TryFind("ItemsSource") with Some v -> USome(unbox<System.Collections.Generic.IList<obj>>(v)) | None -> UNone

        /// Try to get the ItemTemplate property in the visual element
        member x.TryItemTemplate = match x.Attributes.TryFind("ItemTemplate") with Some v -> USome(unbox<Xamarin.Forms.DataTemplate>(v)) | None -> UNone

        /// Try to get the CarouselPage_SelectedItem property in the visual element
        member x.TryCarouselPage_SelectedItem = match x.Attributes.TryFind("CarouselPage_SelectedItem") with Some v -> USome(unbox<System.Object>(v)) | None -> UNone

        /// Try to get the CurrentPage property in the visual element
        member x.TryCurrentPage = match x.Attributes.TryFind("CurrentPage") with Some v -> USome(unbox<XamlElement>(v)) | None -> UNone

        /// Try to get the CurrentPageChanged property in the visual element
        member x.TryCurrentPageChanged = match x.Attributes.TryFind("CurrentPageChanged") with Some v -> USome(unbox<System.EventHandler>(v)) | None -> UNone

        /// Try to get the NavigationPagePages property in the visual element
        member x.TryNavigationPagePages = match x.Attributes.TryFind("NavigationPagePages") with Some v -> USome(unbox<XamlElement[]>(v)) | None -> UNone

        /// Try to get the BackButtonTitle property in the visual element
        member x.TryBackButtonTitle = match x.Attributes.TryFind("BackButtonTitle") with Some v -> USome(unbox<string>(v)) | None -> UNone

        /// Try to get the HasBackButton property in the visual element
        member x.TryHasBackButton = match x.Attributes.TryFind("HasBackButton") with Some v -> USome(unbox<bool>(v)) | None -> UNone

        /// Try to get the HasNavigationBar property in the visual element
        member x.TryHasNavigationBar = match x.Attributes.TryFind("HasNavigationBar") with Some v -> USome(unbox<bool>(v)) | None -> UNone

        /// Try to get the TitleIcon property in the visual element
        member x.TryTitleIcon = match x.Attributes.TryFind("TitleIcon") with Some v -> USome(unbox<string>(v)) | None -> UNone

        /// Try to get the BarBackgroundColor property in the visual element
        member x.TryBarBackgroundColor = match x.Attributes.TryFind("BarBackgroundColor") with Some v -> USome(unbox<Xamarin.Forms.Color>(v)) | None -> UNone

        /// Try to get the BarTextColor property in the visual element
        member x.TryBarTextColor = match x.Attributes.TryFind("BarTextColor") with Some v -> USome(unbox<Xamarin.Forms.Color>(v)) | None -> UNone

        /// Try to get the Popped property in the visual element
        member x.TryPopped = match x.Attributes.TryFind("Popped") with Some v -> USome(unbox<System.EventHandler<Xamarin.Forms.NavigationEventArgs>>(v)) | None -> UNone

        /// Try to get the PoppedToRoot property in the visual element
        member x.TryPoppedToRoot = match x.Attributes.TryFind("PoppedToRoot") with Some v -> USome(unbox<System.EventHandler<Xamarin.Forms.NavigationEventArgs>>(v)) | None -> UNone

        /// Try to get the Pushed property in the visual element
        member x.TryPushed = match x.Attributes.TryFind("Pushed") with Some v -> USome(unbox<System.EventHandler<Xamarin.Forms.NavigationEventArgs>>(v)) | None -> UNone

        /// Try to get the OnSizeAllocatedCallback property in the visual element
        member x.TryOnSizeAllocatedCallback = match x.Attributes.TryFind("OnSizeAllocatedCallback") with Some v -> USome(unbox<FSharp.Control.Handler<(double * double)>>(v)) | None -> UNone

        /// Try to get the Master property in the visual element
        member x.TryMaster = match x.Attributes.TryFind("Master") with Some v -> USome(unbox<XamlElement>(v)) | None -> UNone

        /// Try to get the Detail property in the visual element
        member x.TryDetail = match x.Attributes.TryFind("Detail") with Some v -> USome(unbox<XamlElement>(v)) | None -> UNone

        /// Try to get the IsGestureEnabled property in the visual element
        member x.TryIsGestureEnabled = match x.Attributes.TryFind("IsGestureEnabled") with Some v -> USome(unbox<bool>(v)) | None -> UNone

        /// Try to get the IsPresented property in the visual element
        member x.TryIsPresented = match x.Attributes.TryFind("IsPresented") with Some v -> USome(unbox<bool>(v)) | None -> UNone

        /// Try to get the MasterBehavior property in the visual element
        member x.TryMasterBehavior = match x.Attributes.TryFind("MasterBehavior") with Some v -> USome(unbox<Xamarin.Forms.MasterBehavior>(v)) | None -> UNone

        /// Try to get the IsPresentedChanged property in the visual element
        member x.TryIsPresentedChanged = match x.Attributes.TryFind("IsPresentedChanged") with Some v -> USome(unbox<System.EventHandler>(v)) | None -> UNone

        /// Try to get the Height property in the visual element
        member x.TryHeight = match x.Attributes.TryFind("Height") with Some v -> USome(unbox<double>(v)) | None -> UNone

        /// Try to get the TextDetail property in the visual element
        member x.TryTextDetail = match x.Attributes.TryFind("TextDetail") with Some v -> USome(unbox<string>(v)) | None -> UNone

        /// Try to get the TextDetailColor property in the visual element
        member x.TryTextDetailColor = match x.Attributes.TryFind("TextDetailColor") with Some v -> USome(unbox<Xamarin.Forms.Color>(v)) | None -> UNone

        /// Try to get the TextCellCommand property in the visual element
        member x.TryTextCellCommand = match x.Attributes.TryFind("TextCellCommand") with Some v -> USome(unbox<unit -> unit>(v)) | None -> UNone

        /// Try to get the TextCellCanExecute property in the visual element
        member x.TryTextCellCanExecute = match x.Attributes.TryFind("TextCellCanExecute") with Some v -> USome(unbox<bool>(v)) | None -> UNone

        /// Try to get the View property in the visual element
        member x.TryView = match x.Attributes.TryFind("View") with Some v -> USome(unbox<XamlElement>(v)) | None -> UNone

        /// Try to get the ListViewItems property in the visual element
        member x.TryListViewItems = match x.Attributes.TryFind("ListViewItems") with Some v -> USome(unbox<XamlElement[]>(v)) | None -> UNone

        /// Try to get the Footer property in the visual element
        member x.TryFooter = match x.Attributes.TryFind("Footer") with Some v -> USome(unbox<System.Object>(v)) | None -> UNone

        /// Try to get the Header property in the visual element
        member x.TryHeader = match x.Attributes.TryFind("Header") with Some v -> USome(unbox<System.Object>(v)) | None -> UNone

        /// Try to get the HeaderTemplate property in the visual element
        member x.TryHeaderTemplate = match x.Attributes.TryFind("HeaderTemplate") with Some v -> USome(unbox<Xamarin.Forms.DataTemplate>(v)) | None -> UNone

        /// Try to get the IsGroupingEnabled property in the visual element
        member x.TryIsGroupingEnabled = match x.Attributes.TryFind("IsGroupingEnabled") with Some v -> USome(unbox<bool>(v)) | None -> UNone

        /// Try to get the IsPullToRefreshEnabled property in the visual element
        member x.TryIsPullToRefreshEnabled = match x.Attributes.TryFind("IsPullToRefreshEnabled") with Some v -> USome(unbox<bool>(v)) | None -> UNone

        /// Try to get the IsRefreshing property in the visual element
        member x.TryIsRefreshing = match x.Attributes.TryFind("IsRefreshing") with Some v -> USome(unbox<bool>(v)) | None -> UNone

        /// Try to get the RefreshCommand property in the visual element
        member x.TryRefreshCommand = match x.Attributes.TryFind("RefreshCommand") with Some v -> USome(unbox<System.Windows.Input.ICommand>(v)) | None -> UNone

        /// Try to get the ListView_SelectedItem property in the visual element
        member x.TryListView_SelectedItem = match x.Attributes.TryFind("ListView_SelectedItem") with Some v -> USome(unbox<int option>(v)) | None -> UNone

        /// Try to get the SeparatorVisibility property in the visual element
        member x.TrySeparatorVisibility = match x.Attributes.TryFind("SeparatorVisibility") with Some v -> USome(unbox<Xamarin.Forms.SeparatorVisibility>(v)) | None -> UNone

        /// Try to get the SeparatorColor property in the visual element
        member x.TrySeparatorColor = match x.Attributes.TryFind("SeparatorColor") with Some v -> USome(unbox<Xamarin.Forms.Color>(v)) | None -> UNone

        /// Try to get the ItemAppearing property in the visual element
        member x.TryItemAppearing = match x.Attributes.TryFind("ItemAppearing") with Some v -> USome(unbox<System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>>(v)) | None -> UNone

        /// Try to get the ItemDisappearing property in the visual element
        member x.TryItemDisappearing = match x.Attributes.TryFind("ItemDisappearing") with Some v -> USome(unbox<System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>>(v)) | None -> UNone

        /// Try to get the ListView_ItemSelected property in the visual element
        member x.TryListView_ItemSelected = match x.Attributes.TryFind("ListView_ItemSelected") with Some v -> USome(unbox<System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>>(v)) | None -> UNone

        /// Try to get the ItemTapped property in the visual element
        member x.TryItemTapped = match x.Attributes.TryFind("ItemTapped") with Some v -> USome(unbox<System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>>(v)) | None -> UNone

        /// Try to get the Refreshing property in the visual element
        member x.TryRefreshing = match x.Attributes.TryFind("Refreshing") with Some v -> USome(unbox<System.EventHandler>(v)) | None -> UNone

        /// Try to get the GroupListViewItemsSource property in the visual element
        member x.TryGroupListViewItemsSource = match x.Attributes.TryFind("GroupListViewItemsSource") with Some v -> USome(unbox<(XamlElement * XamlElement[])[]>(v)) | None -> UNone

        /// Try to get the ListViewGrouped_SelectedItem property in the visual element
        member x.TryListViewGrouped_SelectedItem = match x.Attributes.TryFind("ListViewGrouped_SelectedItem") with Some v -> USome(unbox<(int * int) option>(v)) | None -> UNone

        /// Try to get the ListViewGrouped_ItemSelected property in the visual element
        member x.TryListViewGrouped_ItemSelected = match x.Attributes.TryFind("ListViewGrouped_ItemSelected") with Some v -> USome(unbox<System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>>(v)) | None -> UNone

        /// Adjusts the ClassId property in the visual element
        member x.ClassId(value: string) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("ClassId", box ((value))))

        /// Adjusts the StyleId property in the visual element
        member x.StyleId(value: string) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("StyleId", box ((value))))

        /// Adjusts the AnchorX property in the visual element
        member x.AnchorX(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("AnchorX", box ((value))))

        /// Adjusts the AnchorY property in the visual element
        member x.AnchorY(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("AnchorY", box ((value))))

        /// Adjusts the BackgroundColor property in the visual element
        member x.BackgroundColor(value: Xamarin.Forms.Color) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("BackgroundColor", box ((value))))

        /// Adjusts the HeightRequest property in the visual element
        member x.HeightRequest(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("HeightRequest", box ((value))))

        /// Adjusts the InputTransparent property in the visual element
        member x.InputTransparent(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("InputTransparent", box ((value))))

        /// Adjusts the IsEnabled property in the visual element
        member x.IsEnabled(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("IsEnabled", box ((value))))

        /// Adjusts the IsVisible property in the visual element
        member x.IsVisible(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("IsVisible", box ((value))))

        /// Adjusts the MinimumHeightRequest property in the visual element
        member x.MinimumHeightRequest(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("MinimumHeightRequest", box ((value))))

        /// Adjusts the MinimumWidthRequest property in the visual element
        member x.MinimumWidthRequest(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("MinimumWidthRequest", box ((value))))

        /// Adjusts the Opacity property in the visual element
        member x.Opacity(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Opacity", box ((value))))

        /// Adjusts the Rotation property in the visual element
        member x.Rotation(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Rotation", box ((value))))

        /// Adjusts the RotationX property in the visual element
        member x.RotationX(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("RotationX", box ((value))))

        /// Adjusts the RotationY property in the visual element
        member x.RotationY(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("RotationY", box ((value))))

        /// Adjusts the Scale property in the visual element
        member x.Scale(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Scale", box ((value))))

        /// Adjusts the Style property in the visual element
        member x.Style(value: Xamarin.Forms.Style) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Style", box ((value))))

        /// Adjusts the TranslationX property in the visual element
        member x.TranslationX(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("TranslationX", box ((value))))

        /// Adjusts the TranslationY property in the visual element
        member x.TranslationY(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("TranslationY", box ((value))))

        /// Adjusts the WidthRequest property in the visual element
        member x.WidthRequest(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("WidthRequest", box ((value))))

        /// Adjusts the HorizontalOptions property in the visual element
        member x.HorizontalOptions(value: Xamarin.Forms.LayoutOptions) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("HorizontalOptions", box ((value))))

        /// Adjusts the VerticalOptions property in the visual element
        member x.VerticalOptions(value: Xamarin.Forms.LayoutOptions) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("VerticalOptions", box ((value))))

        /// Adjusts the Margin property in the visual element
        member x.Margin(value: obj) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Margin", box (makeThickness(value))))

        /// Adjusts the GestureRecognizers property in the visual element
        member x.GestureRecognizers(value: XamlElement list) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("GestureRecognizers", box (Array.ofList(value))))

        /// Adjusts the TouchPoints property in the visual element
        member x.TouchPoints(value: int) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("TouchPoints", box ((value))))

        /// Adjusts the PanUpdated property in the visual element
        member x.PanUpdated(value: Xamarin.Forms.PanUpdatedEventArgs -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("PanUpdated", box ((fun f -> System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>(fun _sender args -> f args))(value))))

        /// Adjusts the Command property in the visual element
        member x.Command(value: unit -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Command", box (makeCommand(value))))

        /// Adjusts the NumberOfTapsRequired property in the visual element
        member x.NumberOfTapsRequired(value: int) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("NumberOfTapsRequired", box ((value))))

        /// Adjusts the NumberOfClicksRequired property in the visual element
        member x.NumberOfClicksRequired(value: int) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("NumberOfClicksRequired", box ((value))))

        /// Adjusts the Buttons property in the visual element
        member x.Buttons(value: Xamarin.Forms.ButtonsMask) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Buttons", box ((value))))

        /// Adjusts the IsPinching property in the visual element
        member x.IsPinching(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("IsPinching", box ((value))))

        /// Adjusts the PinchUpdated property in the visual element
        member x.PinchUpdated(value: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("PinchUpdated", box ((fun f -> System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>(fun _sender args -> f args))(value))))

        /// Adjusts the Color property in the visual element
        member x.Color(value: Xamarin.Forms.Color) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Color", box ((value))))

        /// Adjusts the IsRunning property in the visual element
        member x.IsRunning(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("IsRunning", box ((value))))

        /// Adjusts the Progress property in the visual element
        member x.Progress(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Progress", box ((value))))

        /// Adjusts the Content property in the visual element
        member x.Content(value: XamlElement) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Content", box ((value))))

        /// Adjusts the ScrollOrientation property in the visual element
        member x.ScrollOrientation(value: Xamarin.Forms.ScrollOrientation) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("ScrollOrientation", box ((value))))

        /// Adjusts the CancelButtonColor property in the visual element
        member x.CancelButtonColor(value: Xamarin.Forms.Color) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("CancelButtonColor", box ((value))))

        /// Adjusts the FontFamily property in the visual element
        member x.FontFamily(value: string) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("FontFamily", box ((value))))

        /// Adjusts the FontAttributes property in the visual element
        member x.FontAttributes(value: Xamarin.Forms.FontAttributes) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("FontAttributes", box ((value))))

        /// Adjusts the FontSize property in the visual element
        member x.FontSize(value: obj) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("FontSize", box (makeFontSize(value))))

        /// Adjusts the HorizontalTextAlignment property in the visual element
        member x.HorizontalTextAlignment(value: Xamarin.Forms.TextAlignment) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("HorizontalTextAlignment", box ((value))))

        /// Adjusts the Placeholder property in the visual element
        member x.Placeholder(value: string) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Placeholder", box ((value))))

        /// Adjusts the PlaceholderColor property in the visual element
        member x.PlaceholderColor(value: Xamarin.Forms.Color) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("PlaceholderColor", box ((value))))

        /// Adjusts the SearchBarCommand property in the visual element
        member x.SearchBarCommand(value: unit -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("SearchBarCommand", box ((value))))

        /// Adjusts the SearchBarCanExecute property in the visual element
        member x.SearchBarCanExecute(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("SearchBarCanExecute", box ((value))))

        /// Adjusts the Text property in the visual element
        member x.Text(value: string) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Text", box ((value))))

        /// Adjusts the TextColor property in the visual element
        member x.TextColor(value: Xamarin.Forms.Color) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("TextColor", box ((value))))

        /// Adjusts the ButtonCommand property in the visual element
        member x.ButtonCommand(value: unit -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("ButtonCommand", box ((value))))

        /// Adjusts the ButtonCanExecute property in the visual element
        member x.ButtonCanExecute(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("ButtonCanExecute", box ((value))))

        /// Adjusts the BorderColor property in the visual element
        member x.BorderColor(value: Xamarin.Forms.Color) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("BorderColor", box ((value))))

        /// Adjusts the BorderWidth property in the visual element
        member x.BorderWidth(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("BorderWidth", box ((value))))

        /// Adjusts the CommandParameter property in the visual element
        member x.CommandParameter(value: System.Object) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("CommandParameter", box ((value))))

        /// Adjusts the ContentLayout property in the visual element
        member x.ContentLayout(value: Xamarin.Forms.Button.ButtonContentLayout) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("ContentLayout", box ((value))))

        /// Adjusts the ButtonImageSource property in the visual element
        member x.ButtonImageSource(value: string) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("ButtonImageSource", box ((value))))

        /// Adjusts the Minimum property in the visual element
        member x.Minimum(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Minimum", box ((value))))

        /// Adjusts the Maximum property in the visual element
        member x.Maximum(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Maximum", box ((value))))

        /// Adjusts the Value property in the visual element
        member x.Value(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Value", box ((value))))

        /// Adjusts the ValueChanged property in the visual element
        member x.ValueChanged(value: Xamarin.Forms.ValueChangedEventArgs -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("ValueChanged", box ((fun f -> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>(fun _sender args -> f args))(value))))

        /// Adjusts the Increment property in the visual element
        member x.Increment(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Increment", box ((value))))

        /// Adjusts the IsToggled property in the visual element
        member x.IsToggled(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("IsToggled", box ((value))))

        /// Adjusts the Toggled property in the visual element
        member x.Toggled(value: Xamarin.Forms.ToggledEventArgs -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Toggled", box ((fun f -> System.EventHandler<Xamarin.Forms.ToggledEventArgs>(fun _sender args -> f args))(value))))

        /// Adjusts the On property in the visual element
        member x.On(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("On", box ((value))))

        /// Adjusts the OnChanged property in the visual element
        member x.OnChanged(value: Xamarin.Forms.ToggledEventArgs -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("OnChanged", box ((fun f -> System.EventHandler<Xamarin.Forms.ToggledEventArgs>(fun _sender args -> f args))(value))))

        /// Adjusts the Intent property in the visual element
        member x.Intent(value: Xamarin.Forms.TableIntent) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Intent", box ((value))))

        /// Adjusts the HasUnevenRows property in the visual element
        member x.HasUnevenRows(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("HasUnevenRows", box ((value))))

        /// Adjusts the RowHeight property in the visual element
        member x.RowHeight(value: int) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("RowHeight", box ((value))))

        /// Adjusts the TableRoot property in the visual element
        member x.TableRoot(value: (string * XamlElement list) list) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("TableRoot", box ((fun es -> es |> Array.ofList |> Array.map (fun (title, es) -> (title, Array.ofList es)))(value))))

        /// Adjusts the GridRowDefinitions property in the visual element
        member x.GridRowDefinitions(value: obj list) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("GridRowDefinitions", box ((fun es -> es |> Array.ofList |> Array.map (fun h -> Xaml.RowDefinition(height=h)))(value))))

        /// Adjusts the GridColumnDefinitions property in the visual element
        member x.GridColumnDefinitions(value: obj list) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("GridColumnDefinitions", box ((fun es -> es |> Array.ofList |> Array.map (fun h -> Xaml.ColumnDefinition(width=h)))(value))))

        /// Adjusts the RowSpacing property in the visual element
        member x.RowSpacing(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("RowSpacing", box ((value))))

        /// Adjusts the ColumnSpacing property in the visual element
        member x.ColumnSpacing(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("ColumnSpacing", box ((value))))

        /// Adjusts the Children property in the visual element
        member x.Children(value: XamlElement list) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Children", box (Array.ofList(value))))

        /// Adjusts the GridRow property in the visual element
        member x.GridRow(value: int) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("GridRow", box ((value))))

        /// Adjusts the GridRowSpan property in the visual element
        member x.GridRowSpan(value: int) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("GridRowSpan", box ((value))))

        /// Adjusts the GridColumn property in the visual element
        member x.GridColumn(value: int) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("GridColumn", box ((value))))

        /// Adjusts the GridColumnSpan property in the visual element
        member x.GridColumnSpan(value: int) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("GridColumnSpan", box ((value))))

        /// Adjusts the LayoutBounds property in the visual element
        member x.LayoutBounds(value: Xamarin.Forms.Rectangle) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("LayoutBounds", box ((value))))

        /// Adjusts the LayoutFlags property in the visual element
        member x.LayoutFlags(value: Xamarin.Forms.AbsoluteLayoutFlags) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("LayoutFlags", box ((value))))

        /// Adjusts the BoundsConstraint property in the visual element
        member x.BoundsConstraint(value: Xamarin.Forms.BoundsConstraint) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("BoundsConstraint", box ((value))))

        /// Adjusts the HeightConstraint property in the visual element
        member x.HeightConstraint(value: Xamarin.Forms.Constraint) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("HeightConstraint", box ((value))))

        /// Adjusts the WidthConstraint property in the visual element
        member x.WidthConstraint(value: Xamarin.Forms.Constraint) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("WidthConstraint", box ((value))))

        /// Adjusts the XConstraint property in the visual element
        member x.XConstraint(value: Xamarin.Forms.Constraint) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("XConstraint", box ((value))))

        /// Adjusts the YConstraint property in the visual element
        member x.YConstraint(value: Xamarin.Forms.Constraint) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("YConstraint", box ((value))))

        /// Adjusts the RowDefinitionHeight property in the visual element
        member x.RowDefinitionHeight(value: obj) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("RowDefinitionHeight", box (makeGridLength(value))))

        /// Adjusts the ColumnDefinitionWidth property in the visual element
        member x.ColumnDefinitionWidth(value: obj) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("ColumnDefinitionWidth", box (makeGridLength(value))))

        /// Adjusts the Date property in the visual element
        member x.Date(value: System.DateTime) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Date", box ((value))))

        /// Adjusts the Format property in the visual element
        member x.Format(value: string) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Format", box ((value))))

        /// Adjusts the MinimumDate property in the visual element
        member x.MinimumDate(value: System.DateTime) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("MinimumDate", box ((value))))

        /// Adjusts the MaximumDate property in the visual element
        member x.MaximumDate(value: System.DateTime) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("MaximumDate", box ((value))))

        /// Adjusts the DateSelected property in the visual element
        member x.DateSelected(value: Xamarin.Forms.DateChangedEventArgs -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("DateSelected", box ((fun f -> System.EventHandler<Xamarin.Forms.DateChangedEventArgs>(fun _sender args -> f args))(value))))

        /// Adjusts the PickerItemsSource property in the visual element
        member x.PickerItemsSource(value: 'T list) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("PickerItemsSource", box ((fun es -> es |> Array.ofList :> System.Collections.IList)(value))))

        /// Adjusts the SelectedIndex property in the visual element
        member x.SelectedIndex(value: int) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("SelectedIndex", box ((value))))

        /// Adjusts the Title property in the visual element
        member x.Title(value: string) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Title", box ((value))))

        /// Adjusts the SelectedIndexChanged property in the visual element
        member x.SelectedIndexChanged(value: (int * 'T option) -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("SelectedIndexChanged", box ((fun f -> System.EventHandler(fun sender args -> let picker = (sender :?> Xamarin.Forms.Picker) in f (picker.SelectedIndex, (picker.SelectedItem |> Option.ofObj |> Option.map unbox<'T>))))(value))))

        /// Adjusts the OutlineColor property in the visual element
        member x.OutlineColor(value: Xamarin.Forms.Color) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("OutlineColor", box ((value))))

        /// Adjusts the FrameCornerRadius property in the visual element
        member x.FrameCornerRadius(value: single) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("FrameCornerRadius", box ((value))))

        /// Adjusts the HasShadow property in the visual element
        member x.HasShadow(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("HasShadow", box ((value))))

        /// Adjusts the ImageSource property in the visual element
        member x.ImageSource(value: string) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("ImageSource", box ((value))))

        /// Adjusts the Aspect property in the visual element
        member x.Aspect(value: Xamarin.Forms.Aspect) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Aspect", box ((value))))

        /// Adjusts the IsOpaque property in the visual element
        member x.IsOpaque(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("IsOpaque", box ((value))))

        /// Adjusts the Keyboard property in the visual element
        member x.Keyboard(value: Xamarin.Forms.Keyboard) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Keyboard", box ((value))))

        /// Adjusts the EditorCompleted property in the visual element
        member x.EditorCompleted(value: string -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("EditorCompleted", box ((fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.Editor).Text))(value))))

        /// Adjusts the TextChanged property in the visual element
        member x.TextChanged(value: Xamarin.Forms.TextChangedEventArgs -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("TextChanged", box ((fun f -> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>(fun _sender args -> f args))(value))))

        /// Adjusts the IsPassword property in the visual element
        member x.IsPassword(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("IsPassword", box ((value))))

        /// Adjusts the EntryCompleted property in the visual element
        member x.EntryCompleted(value: string -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("EntryCompleted", box ((fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.Entry).Text))(value))))

        /// Adjusts the Label property in the visual element
        member x.Label(value: string) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Label", box ((value))))

        /// Adjusts the VerticalTextAlignment property in the visual element
        member x.VerticalTextAlignment(value: Xamarin.Forms.TextAlignment) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("VerticalTextAlignment", box ((value))))

        /// Adjusts the IsClippedToBounds property in the visual element
        member x.IsClippedToBounds(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("IsClippedToBounds", box ((value))))

        /// Adjusts the Padding property in the visual element
        member x.Padding(value: obj) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Padding", box (makeThickness(value))))

        /// Adjusts the StackOrientation property in the visual element
        member x.StackOrientation(value: Xamarin.Forms.StackOrientation) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("StackOrientation", box ((value))))

        /// Adjusts the Spacing property in the visual element
        member x.Spacing(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Spacing", box ((value))))

        /// Adjusts the ForegroundColor property in the visual element
        member x.ForegroundColor(value: Xamarin.Forms.Color) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("ForegroundColor", box ((value))))

        /// Adjusts the PropertyChanged property in the visual element
        member x.PropertyChanged(value: System.ComponentModel.PropertyChangedEventArgs -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("PropertyChanged", box ((fun f -> System.EventHandler<System.ComponentModel.PropertyChangedEventArgs>(fun _sender args -> f args))(value))))

        /// Adjusts the Time property in the visual element
        member x.Time(value: System.TimeSpan) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Time", box ((value))))

        /// Adjusts the WebSource property in the visual element
        member x.WebSource(value: Xamarin.Forms.WebViewSource) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("WebSource", box ((value))))

        /// Adjusts the Navigated property in the visual element
        member x.Navigated(value: Xamarin.Forms.WebNavigatedEventArgs -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Navigated", box ((fun f -> System.EventHandler<Xamarin.Forms.WebNavigatedEventArgs>(fun _sender args -> f args))(value))))

        /// Adjusts the Navigating property in the visual element
        member x.Navigating(value: Xamarin.Forms.WebNavigatingEventArgs -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Navigating", box ((fun f -> System.EventHandler<Xamarin.Forms.WebNavigatingEventArgs>(fun _sender args -> f args))(value))))

        /// Adjusts the UseSafeArea property in the visual element
        member x.UseSafeArea(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("UseSafeArea", box ((value))))

        /// Adjusts the ItemsSource property in the visual element
        member x.ItemsSource(value: 'T list) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("ItemsSource", box ((fun es -> es |> Array.ofList |> Array.map box :> System.Collections.Generic.IList<obj>)(value))))

        /// Adjusts the ItemTemplate property in the visual element
        member x.ItemTemplate(value: Xamarin.Forms.DataTemplate) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("ItemTemplate", box ((value))))

        /// Adjusts the CarouselPage_SelectedItem property in the visual element
        member x.CarouselPage_SelectedItem(value: System.Object) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("CarouselPage_SelectedItem", box ((value))))

        /// Adjusts the CurrentPage property in the visual element
        member x.CurrentPage(value: XamlElement) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("CurrentPage", box ((value))))

        /// Adjusts the CurrentPageChanged property in the visual element
        member x.CurrentPageChanged(value: 'T option -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("CurrentPageChanged", box ((fun f -> System.EventHandler(fun sender args -> f ((sender :?> Xamarin.Forms.CarouselPage).SelectedItem |> Option.ofObj |> Option.map unbox<'T>)))(value))))

        /// Adjusts the NavigationPagePages property in the visual element
        member x.NavigationPagePages(value: XamlElement list) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("NavigationPagePages", box (Array.ofList(value))))

        /// Adjusts the BackButtonTitle property in the visual element
        member x.BackButtonTitle(value: string) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("BackButtonTitle", box ((value))))

        /// Adjusts the HasBackButton property in the visual element
        member x.HasBackButton(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("HasBackButton", box ((value))))

        /// Adjusts the HasNavigationBar property in the visual element
        member x.HasNavigationBar(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("HasNavigationBar", box ((value))))

        /// Adjusts the TitleIcon property in the visual element
        member x.TitleIcon(value: string) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("TitleIcon", box ((value))))

        /// Adjusts the BarBackgroundColor property in the visual element
        member x.BarBackgroundColor(value: Xamarin.Forms.Color) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("BarBackgroundColor", box ((value))))

        /// Adjusts the BarTextColor property in the visual element
        member x.BarTextColor(value: Xamarin.Forms.Color) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("BarTextColor", box ((value))))

        /// Adjusts the Popped property in the visual element
        member x.Popped(value: Xamarin.Forms.NavigationEventArgs -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Popped", box ((fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(value))))

        /// Adjusts the PoppedToRoot property in the visual element
        member x.PoppedToRoot(value: Xamarin.Forms.NavigationEventArgs -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("PoppedToRoot", box ((fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(value))))

        /// Adjusts the Pushed property in the visual element
        member x.Pushed(value: Xamarin.Forms.NavigationEventArgs -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Pushed", box ((fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(value))))

        /// Adjusts the OnSizeAllocatedCallback property in the visual element
        member x.OnSizeAllocatedCallback(value: (double * double) -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("OnSizeAllocatedCallback", box ((fun f -> FSharp.Control.Handler<_>(fun _sender args -> f args))(value))))

        /// Adjusts the Master property in the visual element
        member x.Master(value: XamlElement) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Master", box ((value))))

        /// Adjusts the Detail property in the visual element
        member x.Detail(value: XamlElement) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Detail", box ((value))))

        /// Adjusts the IsGestureEnabled property in the visual element
        member x.IsGestureEnabled(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("IsGestureEnabled", box ((value))))

        /// Adjusts the IsPresented property in the visual element
        member x.IsPresented(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("IsPresented", box ((value))))

        /// Adjusts the MasterBehavior property in the visual element
        member x.MasterBehavior(value: Xamarin.Forms.MasterBehavior) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("MasterBehavior", box ((value))))

        /// Adjusts the IsPresentedChanged property in the visual element
        member x.IsPresentedChanged(value: bool -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("IsPresentedChanged", box ((fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.MasterDetailPage).IsPresented))(value))))

        /// Adjusts the Height property in the visual element
        member x.Height(value: double) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Height", box ((value))))

        /// Adjusts the TextDetail property in the visual element
        member x.TextDetail(value: string) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("TextDetail", box ((value))))

        /// Adjusts the TextDetailColor property in the visual element
        member x.TextDetailColor(value: Xamarin.Forms.Color) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("TextDetailColor", box ((value))))

        /// Adjusts the TextCellCommand property in the visual element
        member x.TextCellCommand(value: unit -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("TextCellCommand", box ((value))))

        /// Adjusts the TextCellCanExecute property in the visual element
        member x.TextCellCanExecute(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("TextCellCanExecute", box ((value))))

        /// Adjusts the View property in the visual element
        member x.View(value: XamlElement) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("View", box ((value))))

        /// Adjusts the ListViewItems property in the visual element
        member x.ListViewItems(value: XamlElement list) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("ListViewItems", box (Array.ofList(value))))

        /// Adjusts the Footer property in the visual element
        member x.Footer(value: System.Object) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Footer", box ((value))))

        /// Adjusts the Header property in the visual element
        member x.Header(value: System.Object) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Header", box ((value))))

        /// Adjusts the HeaderTemplate property in the visual element
        member x.HeaderTemplate(value: Xamarin.Forms.DataTemplate) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("HeaderTemplate", box ((value))))

        /// Adjusts the IsGroupingEnabled property in the visual element
        member x.IsGroupingEnabled(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("IsGroupingEnabled", box ((value))))

        /// Adjusts the IsPullToRefreshEnabled property in the visual element
        member x.IsPullToRefreshEnabled(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("IsPullToRefreshEnabled", box ((value))))

        /// Adjusts the IsRefreshing property in the visual element
        member x.IsRefreshing(value: bool) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("IsRefreshing", box ((value))))

        /// Adjusts the RefreshCommand property in the visual element
        member x.RefreshCommand(value: unit -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("RefreshCommand", box (makeCommand(value))))

        /// Adjusts the ListView_SelectedItem property in the visual element
        member x.ListView_SelectedItem(value: int option) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("ListView_SelectedItem", box ((value))))

        /// Adjusts the SeparatorVisibility property in the visual element
        member x.SeparatorVisibility(value: Xamarin.Forms.SeparatorVisibility) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("SeparatorVisibility", box ((value))))

        /// Adjusts the SeparatorColor property in the visual element
        member x.SeparatorColor(value: Xamarin.Forms.Color) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("SeparatorColor", box ((value))))

        /// Adjusts the ItemAppearing property in the visual element
        member x.ItemAppearing(value: Xamarin.Forms.ItemVisibilityEventArgs -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("ItemAppearing", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun _sender args -> f args))(value))))

        /// Adjusts the ItemDisappearing property in the visual element
        member x.ItemDisappearing(value: Xamarin.Forms.ItemVisibilityEventArgs -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("ItemDisappearing", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun _sender args -> f args))(value))))

        /// Adjusts the ListView_ItemSelected property in the visual element
        member x.ListView_ItemSelected(value: int option -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("ListView_ItemSelected", box ((fun f -> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args -> f (args.SelectedItem |> Option.ofObj |> Option.map unbox<ListElementData<XamlElement>> |> Option.bind (fun item -> let items = (sender :?> Xamarin.Forms.ListView).ItemsSource :?> System.Collections.Generic.IList<ListElementData<XamlElement>> in items |> Seq.tryFindIndex (fun item2 -> System.Object.ReferenceEquals(item.Key, item2.Key))))))(value))))

        /// Adjusts the ItemTapped property in the visual element
        member x.ItemTapped(value: Xamarin.Forms.ItemTappedEventArgs -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("ItemTapped", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun _sender args -> f args))(value))))

        /// Adjusts the Refreshing property in the visual element
        member x.Refreshing(value: unit -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("Refreshing", box ((fun f -> System.EventHandler(fun sender args -> f ()))(value))))

        /// Adjusts the GroupListViewItemsSource property in the visual element
        member x.GroupListViewItemsSource(value: (XamlElement * XamlElement list) list) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("GroupListViewItemsSource", box ((fun es -> es |> Array.ofList |> Array.map (fun (e,l) -> (e, Array.ofList l)))(value))))

        /// Adjusts the ListViewGrouped_SelectedItem property in the visual element
        member x.ListViewGrouped_SelectedItem(value: (int * int) option) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("ListViewGrouped_SelectedItem", box ((value))))

        /// Adjusts the ListViewGrouped_ItemSelected property in the visual element
        member x.ListViewGrouped_ItemSelected(value: (int * int) option -> unit) = XamlElement(x.TargetType, x.CreateMethod, x.UpdateMethod, x.Attributes.Add("ListViewGrouped_ItemSelected", box ((fun f -> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args -> f (args.SelectedItem |> Option.ofObj |> Option.map unbox<ListElementData<XamlElement>> |> Option.bind (fun item -> let items = (sender :?> Xamarin.Forms.ListView).ItemsSource :?> System.Collections.Generic.IList<ListGroupData<XamlElement>> in Seq.indexed items |> Seq.tryPick (fun (i,items2) -> Seq.indexed items2 |> Seq.tryPick (fun (j,item2) -> if System.Object.ReferenceEquals(item.Key, item2.Key) then Some (i,j) else None))))))(value))))


    /// Adjusts the ClassId property in the visual element
    let withClassId (value: string) (x: XamlElement) = x.ClassId(value)

    /// Adjusts the ClassId property in the visual element
    let classId (value: string) (x: XamlElement) = x.ClassId(value)

    /// Adjusts the StyleId property in the visual element
    let withStyleId (value: string) (x: XamlElement) = x.StyleId(value)

    /// Adjusts the StyleId property in the visual element
    let styleId (value: string) (x: XamlElement) = x.StyleId(value)

    /// Adjusts the AnchorX property in the visual element
    let withAnchorX (value: double) (x: XamlElement) = x.AnchorX(value)

    /// Adjusts the AnchorX property in the visual element
    let anchorX (value: double) (x: XamlElement) = x.AnchorX(value)

    /// Adjusts the AnchorY property in the visual element
    let withAnchorY (value: double) (x: XamlElement) = x.AnchorY(value)

    /// Adjusts the AnchorY property in the visual element
    let anchorY (value: double) (x: XamlElement) = x.AnchorY(value)

    /// Adjusts the BackgroundColor property in the visual element
    let withBackgroundColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.BackgroundColor(value)

    /// Adjusts the BackgroundColor property in the visual element
    let backgroundColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.BackgroundColor(value)

    /// Adjusts the HeightRequest property in the visual element
    let withHeightRequest (value: double) (x: XamlElement) = x.HeightRequest(value)

    /// Adjusts the HeightRequest property in the visual element
    let heightRequest (value: double) (x: XamlElement) = x.HeightRequest(value)

    /// Adjusts the InputTransparent property in the visual element
    let withInputTransparent (value: bool) (x: XamlElement) = x.InputTransparent(value)

    /// Adjusts the InputTransparent property in the visual element
    let inputTransparent (value: bool) (x: XamlElement) = x.InputTransparent(value)

    /// Adjusts the IsEnabled property in the visual element
    let withIsEnabled (value: bool) (x: XamlElement) = x.IsEnabled(value)

    /// Adjusts the IsEnabled property in the visual element
    let isEnabled (value: bool) (x: XamlElement) = x.IsEnabled(value)

    /// Adjusts the IsVisible property in the visual element
    let withIsVisible (value: bool) (x: XamlElement) = x.IsVisible(value)

    /// Adjusts the IsVisible property in the visual element
    let isVisible (value: bool) (x: XamlElement) = x.IsVisible(value)

    /// Adjusts the MinimumHeightRequest property in the visual element
    let withMinimumHeightRequest (value: double) (x: XamlElement) = x.MinimumHeightRequest(value)

    /// Adjusts the MinimumHeightRequest property in the visual element
    let minimumHeightRequest (value: double) (x: XamlElement) = x.MinimumHeightRequest(value)

    /// Adjusts the MinimumWidthRequest property in the visual element
    let withMinimumWidthRequest (value: double) (x: XamlElement) = x.MinimumWidthRequest(value)

    /// Adjusts the MinimumWidthRequest property in the visual element
    let minimumWidthRequest (value: double) (x: XamlElement) = x.MinimumWidthRequest(value)

    /// Adjusts the Opacity property in the visual element
    let withOpacity (value: double) (x: XamlElement) = x.Opacity(value)

    /// Adjusts the Opacity property in the visual element
    let opacity (value: double) (x: XamlElement) = x.Opacity(value)

    /// Adjusts the Rotation property in the visual element
    let withRotation (value: double) (x: XamlElement) = x.Rotation(value)

    /// Adjusts the Rotation property in the visual element
    let rotation (value: double) (x: XamlElement) = x.Rotation(value)

    /// Adjusts the RotationX property in the visual element
    let withRotationX (value: double) (x: XamlElement) = x.RotationX(value)

    /// Adjusts the RotationX property in the visual element
    let rotationX (value: double) (x: XamlElement) = x.RotationX(value)

    /// Adjusts the RotationY property in the visual element
    let withRotationY (value: double) (x: XamlElement) = x.RotationY(value)

    /// Adjusts the RotationY property in the visual element
    let rotationY (value: double) (x: XamlElement) = x.RotationY(value)

    /// Adjusts the Scale property in the visual element
    let withScale (value: double) (x: XamlElement) = x.Scale(value)

    /// Adjusts the Scale property in the visual element
    let scale (value: double) (x: XamlElement) = x.Scale(value)

    /// Adjusts the Style property in the visual element
    let withStyle (value: Xamarin.Forms.Style) (x: XamlElement) = x.Style(value)

    /// Adjusts the Style property in the visual element
    let style (value: Xamarin.Forms.Style) (x: XamlElement) = x.Style(value)

    /// Adjusts the TranslationX property in the visual element
    let withTranslationX (value: double) (x: XamlElement) = x.TranslationX(value)

    /// Adjusts the TranslationX property in the visual element
    let translationX (value: double) (x: XamlElement) = x.TranslationX(value)

    /// Adjusts the TranslationY property in the visual element
    let withTranslationY (value: double) (x: XamlElement) = x.TranslationY(value)

    /// Adjusts the TranslationY property in the visual element
    let translationY (value: double) (x: XamlElement) = x.TranslationY(value)

    /// Adjusts the WidthRequest property in the visual element
    let withWidthRequest (value: double) (x: XamlElement) = x.WidthRequest(value)

    /// Adjusts the WidthRequest property in the visual element
    let widthRequest (value: double) (x: XamlElement) = x.WidthRequest(value)

    /// Adjusts the HorizontalOptions property in the visual element
    let withHorizontalOptions (value: Xamarin.Forms.LayoutOptions) (x: XamlElement) = x.HorizontalOptions(value)

    /// Adjusts the HorizontalOptions property in the visual element
    let horizontalOptions (value: Xamarin.Forms.LayoutOptions) (x: XamlElement) = x.HorizontalOptions(value)

    /// Adjusts the VerticalOptions property in the visual element
    let withVerticalOptions (value: Xamarin.Forms.LayoutOptions) (x: XamlElement) = x.VerticalOptions(value)

    /// Adjusts the VerticalOptions property in the visual element
    let verticalOptions (value: Xamarin.Forms.LayoutOptions) (x: XamlElement) = x.VerticalOptions(value)

    /// Adjusts the Margin property in the visual element
    let withMargin (value: obj) (x: XamlElement) = x.Margin(value)

    /// Adjusts the Margin property in the visual element
    let margin (value: obj) (x: XamlElement) = x.Margin(value)

    /// Adjusts the GestureRecognizers property in the visual element
    let withGestureRecognizers (value: XamlElement list) (x: XamlElement) = x.GestureRecognizers(value)

    /// Adjusts the GestureRecognizers property in the visual element
    let gestureRecognizers (value: XamlElement list) (x: XamlElement) = x.GestureRecognizers(value)

    /// Adjusts the TouchPoints property in the visual element
    let withTouchPoints (value: int) (x: XamlElement) = x.TouchPoints(value)

    /// Adjusts the TouchPoints property in the visual element
    let touchPoints (value: int) (x: XamlElement) = x.TouchPoints(value)

    /// Adjusts the PanUpdated property in the visual element
    let withPanUpdated (value: Xamarin.Forms.PanUpdatedEventArgs -> unit) (x: XamlElement) = x.PanUpdated(value)

    /// Adjusts the PanUpdated property in the visual element
    let panUpdated (value: Xamarin.Forms.PanUpdatedEventArgs -> unit) (x: XamlElement) = x.PanUpdated(value)

    /// Adjusts the Command property in the visual element
    let withCommand (value: unit -> unit) (x: XamlElement) = x.Command(value)

    /// Adjusts the Command property in the visual element
    let command (value: unit -> unit) (x: XamlElement) = x.Command(value)

    /// Adjusts the NumberOfTapsRequired property in the visual element
    let withNumberOfTapsRequired (value: int) (x: XamlElement) = x.NumberOfTapsRequired(value)

    /// Adjusts the NumberOfTapsRequired property in the visual element
    let numberOfTapsRequired (value: int) (x: XamlElement) = x.NumberOfTapsRequired(value)

    /// Adjusts the NumberOfClicksRequired property in the visual element
    let withNumberOfClicksRequired (value: int) (x: XamlElement) = x.NumberOfClicksRequired(value)

    /// Adjusts the NumberOfClicksRequired property in the visual element
    let numberOfClicksRequired (value: int) (x: XamlElement) = x.NumberOfClicksRequired(value)

    /// Adjusts the Buttons property in the visual element
    let withButtons (value: Xamarin.Forms.ButtonsMask) (x: XamlElement) = x.Buttons(value)

    /// Adjusts the Buttons property in the visual element
    let buttons (value: Xamarin.Forms.ButtonsMask) (x: XamlElement) = x.Buttons(value)

    /// Adjusts the IsPinching property in the visual element
    let withIsPinching (value: bool) (x: XamlElement) = x.IsPinching(value)

    /// Adjusts the IsPinching property in the visual element
    let isPinching (value: bool) (x: XamlElement) = x.IsPinching(value)

    /// Adjusts the PinchUpdated property in the visual element
    let withPinchUpdated (value: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit) (x: XamlElement) = x.PinchUpdated(value)

    /// Adjusts the PinchUpdated property in the visual element
    let pinchUpdated (value: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit) (x: XamlElement) = x.PinchUpdated(value)

    /// Adjusts the Color property in the visual element
    let withColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.Color(value)

    /// Adjusts the Color property in the visual element
    let color (value: Xamarin.Forms.Color) (x: XamlElement) = x.Color(value)

    /// Adjusts the IsRunning property in the visual element
    let withIsRunning (value: bool) (x: XamlElement) = x.IsRunning(value)

    /// Adjusts the IsRunning property in the visual element
    let isRunning (value: bool) (x: XamlElement) = x.IsRunning(value)

    /// Adjusts the Progress property in the visual element
    let withProgress (value: double) (x: XamlElement) = x.Progress(value)

    /// Adjusts the Progress property in the visual element
    let progress (value: double) (x: XamlElement) = x.Progress(value)

    /// Adjusts the Content property in the visual element
    let withContent (value: XamlElement) (x: XamlElement) = x.Content(value)

    /// Adjusts the Content property in the visual element
    let content (value: XamlElement) (x: XamlElement) = x.Content(value)

    /// Adjusts the ScrollOrientation property in the visual element
    let withScrollOrientation (value: Xamarin.Forms.ScrollOrientation) (x: XamlElement) = x.ScrollOrientation(value)

    /// Adjusts the ScrollOrientation property in the visual element
    let scrollOrientation (value: Xamarin.Forms.ScrollOrientation) (x: XamlElement) = x.ScrollOrientation(value)

    /// Adjusts the CancelButtonColor property in the visual element
    let withCancelButtonColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.CancelButtonColor(value)

    /// Adjusts the CancelButtonColor property in the visual element
    let cancelButtonColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.CancelButtonColor(value)

    /// Adjusts the FontFamily property in the visual element
    let withFontFamily (value: string) (x: XamlElement) = x.FontFamily(value)

    /// Adjusts the FontFamily property in the visual element
    let fontFamily (value: string) (x: XamlElement) = x.FontFamily(value)

    /// Adjusts the FontAttributes property in the visual element
    let withFontAttributes (value: Xamarin.Forms.FontAttributes) (x: XamlElement) = x.FontAttributes(value)

    /// Adjusts the FontAttributes property in the visual element
    let fontAttributes (value: Xamarin.Forms.FontAttributes) (x: XamlElement) = x.FontAttributes(value)

    /// Adjusts the FontSize property in the visual element
    let withFontSize (value: obj) (x: XamlElement) = x.FontSize(value)

    /// Adjusts the FontSize property in the visual element
    let fontSize (value: obj) (x: XamlElement) = x.FontSize(value)

    /// Adjusts the HorizontalTextAlignment property in the visual element
    let withHorizontalTextAlignment (value: Xamarin.Forms.TextAlignment) (x: XamlElement) = x.HorizontalTextAlignment(value)

    /// Adjusts the HorizontalTextAlignment property in the visual element
    let horizontalTextAlignment (value: Xamarin.Forms.TextAlignment) (x: XamlElement) = x.HorizontalTextAlignment(value)

    /// Adjusts the Placeholder property in the visual element
    let withPlaceholder (value: string) (x: XamlElement) = x.Placeholder(value)

    /// Adjusts the Placeholder property in the visual element
    let placeholder (value: string) (x: XamlElement) = x.Placeholder(value)

    /// Adjusts the PlaceholderColor property in the visual element
    let withPlaceholderColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.PlaceholderColor(value)

    /// Adjusts the PlaceholderColor property in the visual element
    let placeholderColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.PlaceholderColor(value)

    /// Adjusts the SearchBarCommand property in the visual element
    let withSearchBarCommand (value: unit -> unit) (x: XamlElement) = x.SearchBarCommand(value)

    /// Adjusts the SearchBarCommand property in the visual element
    let searchBarCommand (value: unit -> unit) (x: XamlElement) = x.SearchBarCommand(value)

    /// Adjusts the SearchBarCanExecute property in the visual element
    let withSearchBarCanExecute (value: bool) (x: XamlElement) = x.SearchBarCanExecute(value)

    /// Adjusts the SearchBarCanExecute property in the visual element
    let searchBarCanExecute (value: bool) (x: XamlElement) = x.SearchBarCanExecute(value)

    /// Adjusts the Text property in the visual element
    let withText (value: string) (x: XamlElement) = x.Text(value)

    /// Adjusts the Text property in the visual element
    let text (value: string) (x: XamlElement) = x.Text(value)

    /// Adjusts the TextColor property in the visual element
    let withTextColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.TextColor(value)

    /// Adjusts the TextColor property in the visual element
    let textColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.TextColor(value)

    /// Adjusts the ButtonCommand property in the visual element
    let withButtonCommand (value: unit -> unit) (x: XamlElement) = x.ButtonCommand(value)

    /// Adjusts the ButtonCommand property in the visual element
    let buttonCommand (value: unit -> unit) (x: XamlElement) = x.ButtonCommand(value)

    /// Adjusts the ButtonCanExecute property in the visual element
    let withButtonCanExecute (value: bool) (x: XamlElement) = x.ButtonCanExecute(value)

    /// Adjusts the ButtonCanExecute property in the visual element
    let buttonCanExecute (value: bool) (x: XamlElement) = x.ButtonCanExecute(value)

    /// Adjusts the BorderColor property in the visual element
    let withBorderColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.BorderColor(value)

    /// Adjusts the BorderColor property in the visual element
    let borderColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.BorderColor(value)

    /// Adjusts the BorderWidth property in the visual element
    let withBorderWidth (value: double) (x: XamlElement) = x.BorderWidth(value)

    /// Adjusts the BorderWidth property in the visual element
    let borderWidth (value: double) (x: XamlElement) = x.BorderWidth(value)

    /// Adjusts the CommandParameter property in the visual element
    let withCommandParameter (value: System.Object) (x: XamlElement) = x.CommandParameter(value)

    /// Adjusts the CommandParameter property in the visual element
    let commandParameter (value: System.Object) (x: XamlElement) = x.CommandParameter(value)

    /// Adjusts the ContentLayout property in the visual element
    let withContentLayout (value: Xamarin.Forms.Button.ButtonContentLayout) (x: XamlElement) = x.ContentLayout(value)

    /// Adjusts the ContentLayout property in the visual element
    let contentLayout (value: Xamarin.Forms.Button.ButtonContentLayout) (x: XamlElement) = x.ContentLayout(value)

    /// Adjusts the ButtonImageSource property in the visual element
    let withButtonImageSource (value: string) (x: XamlElement) = x.ButtonImageSource(value)

    /// Adjusts the ButtonImageSource property in the visual element
    let buttonImageSource (value: string) (x: XamlElement) = x.ButtonImageSource(value)

    /// Adjusts the Minimum property in the visual element
    let withMinimum (value: double) (x: XamlElement) = x.Minimum(value)

    /// Adjusts the Minimum property in the visual element
    let minimum (value: double) (x: XamlElement) = x.Minimum(value)

    /// Adjusts the Maximum property in the visual element
    let withMaximum (value: double) (x: XamlElement) = x.Maximum(value)

    /// Adjusts the Maximum property in the visual element
    let maximum (value: double) (x: XamlElement) = x.Maximum(value)

    /// Adjusts the Value property in the visual element
    let withValue (value: double) (x: XamlElement) = x.Value(value)

    /// Adjusts the Value property in the visual element
    let value (value: double) (x: XamlElement) = x.Value(value)

    /// Adjusts the ValueChanged property in the visual element
    let withValueChanged (value: Xamarin.Forms.ValueChangedEventArgs -> unit) (x: XamlElement) = x.ValueChanged(value)

    /// Adjusts the ValueChanged property in the visual element
    let valueChanged (value: Xamarin.Forms.ValueChangedEventArgs -> unit) (x: XamlElement) = x.ValueChanged(value)

    /// Adjusts the Increment property in the visual element
    let withIncrement (value: double) (x: XamlElement) = x.Increment(value)

    /// Adjusts the Increment property in the visual element
    let increment (value: double) (x: XamlElement) = x.Increment(value)

    /// Adjusts the IsToggled property in the visual element
    let withIsToggled (value: bool) (x: XamlElement) = x.IsToggled(value)

    /// Adjusts the IsToggled property in the visual element
    let isToggled (value: bool) (x: XamlElement) = x.IsToggled(value)

    /// Adjusts the Toggled property in the visual element
    let withToggled (value: Xamarin.Forms.ToggledEventArgs -> unit) (x: XamlElement) = x.Toggled(value)

    /// Adjusts the Toggled property in the visual element
    let toggled (value: Xamarin.Forms.ToggledEventArgs -> unit) (x: XamlElement) = x.Toggled(value)

    /// Adjusts the On property in the visual element
    let withOn (value: bool) (x: XamlElement) = x.On(value)

    /// Adjusts the On property in the visual element
    let on (value: bool) (x: XamlElement) = x.On(value)

    /// Adjusts the OnChanged property in the visual element
    let withOnChanged (value: Xamarin.Forms.ToggledEventArgs -> unit) (x: XamlElement) = x.OnChanged(value)

    /// Adjusts the OnChanged property in the visual element
    let onChanged (value: Xamarin.Forms.ToggledEventArgs -> unit) (x: XamlElement) = x.OnChanged(value)

    /// Adjusts the Intent property in the visual element
    let withIntent (value: Xamarin.Forms.TableIntent) (x: XamlElement) = x.Intent(value)

    /// Adjusts the Intent property in the visual element
    let intent (value: Xamarin.Forms.TableIntent) (x: XamlElement) = x.Intent(value)

    /// Adjusts the HasUnevenRows property in the visual element
    let withHasUnevenRows (value: bool) (x: XamlElement) = x.HasUnevenRows(value)

    /// Adjusts the HasUnevenRows property in the visual element
    let hasUnevenRows (value: bool) (x: XamlElement) = x.HasUnevenRows(value)

    /// Adjusts the RowHeight property in the visual element
    let withRowHeight (value: int) (x: XamlElement) = x.RowHeight(value)

    /// Adjusts the RowHeight property in the visual element
    let rowHeight (value: int) (x: XamlElement) = x.RowHeight(value)

    /// Adjusts the TableRoot property in the visual element
    let withTableRoot (value: (string * XamlElement list) list) (x: XamlElement) = x.TableRoot(value)

    /// Adjusts the TableRoot property in the visual element
    let tableRoot (value: (string * XamlElement list) list) (x: XamlElement) = x.TableRoot(value)

    /// Adjusts the GridRowDefinitions property in the visual element
    let withGridRowDefinitions (value: obj list) (x: XamlElement) = x.GridRowDefinitions(value)

    /// Adjusts the GridRowDefinitions property in the visual element
    let gridRowDefinitions (value: obj list) (x: XamlElement) = x.GridRowDefinitions(value)

    /// Adjusts the GridColumnDefinitions property in the visual element
    let withGridColumnDefinitions (value: obj list) (x: XamlElement) = x.GridColumnDefinitions(value)

    /// Adjusts the GridColumnDefinitions property in the visual element
    let gridColumnDefinitions (value: obj list) (x: XamlElement) = x.GridColumnDefinitions(value)

    /// Adjusts the RowSpacing property in the visual element
    let withRowSpacing (value: double) (x: XamlElement) = x.RowSpacing(value)

    /// Adjusts the RowSpacing property in the visual element
    let rowSpacing (value: double) (x: XamlElement) = x.RowSpacing(value)

    /// Adjusts the ColumnSpacing property in the visual element
    let withColumnSpacing (value: double) (x: XamlElement) = x.ColumnSpacing(value)

    /// Adjusts the ColumnSpacing property in the visual element
    let columnSpacing (value: double) (x: XamlElement) = x.ColumnSpacing(value)

    /// Adjusts the Children property in the visual element
    let withChildren (value: XamlElement list) (x: XamlElement) = x.Children(value)

    /// Adjusts the Children property in the visual element
    let children (value: XamlElement list) (x: XamlElement) = x.Children(value)

    /// Adjusts the GridRow property in the visual element
    let withGridRow (value: int) (x: XamlElement) = x.GridRow(value)

    /// Adjusts the GridRow property in the visual element
    let gridRow (value: int) (x: XamlElement) = x.GridRow(value)

    /// Adjusts the GridRowSpan property in the visual element
    let withGridRowSpan (value: int) (x: XamlElement) = x.GridRowSpan(value)

    /// Adjusts the GridRowSpan property in the visual element
    let gridRowSpan (value: int) (x: XamlElement) = x.GridRowSpan(value)

    /// Adjusts the GridColumn property in the visual element
    let withGridColumn (value: int) (x: XamlElement) = x.GridColumn(value)

    /// Adjusts the GridColumn property in the visual element
    let gridColumn (value: int) (x: XamlElement) = x.GridColumn(value)

    /// Adjusts the GridColumnSpan property in the visual element
    let withGridColumnSpan (value: int) (x: XamlElement) = x.GridColumnSpan(value)

    /// Adjusts the GridColumnSpan property in the visual element
    let gridColumnSpan (value: int) (x: XamlElement) = x.GridColumnSpan(value)

    /// Adjusts the LayoutBounds property in the visual element
    let withLayoutBounds (value: Xamarin.Forms.Rectangle) (x: XamlElement) = x.LayoutBounds(value)

    /// Adjusts the LayoutBounds property in the visual element
    let layoutBounds (value: Xamarin.Forms.Rectangle) (x: XamlElement) = x.LayoutBounds(value)

    /// Adjusts the LayoutFlags property in the visual element
    let withLayoutFlags (value: Xamarin.Forms.AbsoluteLayoutFlags) (x: XamlElement) = x.LayoutFlags(value)

    /// Adjusts the LayoutFlags property in the visual element
    let layoutFlags (value: Xamarin.Forms.AbsoluteLayoutFlags) (x: XamlElement) = x.LayoutFlags(value)

    /// Adjusts the BoundsConstraint property in the visual element
    let withBoundsConstraint (value: Xamarin.Forms.BoundsConstraint) (x: XamlElement) = x.BoundsConstraint(value)

    /// Adjusts the BoundsConstraint property in the visual element
    let boundsConstraint (value: Xamarin.Forms.BoundsConstraint) (x: XamlElement) = x.BoundsConstraint(value)

    /// Adjusts the HeightConstraint property in the visual element
    let withHeightConstraint (value: Xamarin.Forms.Constraint) (x: XamlElement) = x.HeightConstraint(value)

    /// Adjusts the HeightConstraint property in the visual element
    let heightConstraint (value: Xamarin.Forms.Constraint) (x: XamlElement) = x.HeightConstraint(value)

    /// Adjusts the WidthConstraint property in the visual element
    let withWidthConstraint (value: Xamarin.Forms.Constraint) (x: XamlElement) = x.WidthConstraint(value)

    /// Adjusts the WidthConstraint property in the visual element
    let widthConstraint (value: Xamarin.Forms.Constraint) (x: XamlElement) = x.WidthConstraint(value)

    /// Adjusts the XConstraint property in the visual element
    let withXConstraint (value: Xamarin.Forms.Constraint) (x: XamlElement) = x.XConstraint(value)

    /// Adjusts the XConstraint property in the visual element
    let xConstraint (value: Xamarin.Forms.Constraint) (x: XamlElement) = x.XConstraint(value)

    /// Adjusts the YConstraint property in the visual element
    let withYConstraint (value: Xamarin.Forms.Constraint) (x: XamlElement) = x.YConstraint(value)

    /// Adjusts the YConstraint property in the visual element
    let yConstraint (value: Xamarin.Forms.Constraint) (x: XamlElement) = x.YConstraint(value)

    /// Adjusts the RowDefinitionHeight property in the visual element
    let withRowDefinitionHeight (value: obj) (x: XamlElement) = x.RowDefinitionHeight(value)

    /// Adjusts the RowDefinitionHeight property in the visual element
    let rowDefinitionHeight (value: obj) (x: XamlElement) = x.RowDefinitionHeight(value)

    /// Adjusts the ColumnDefinitionWidth property in the visual element
    let withColumnDefinitionWidth (value: obj) (x: XamlElement) = x.ColumnDefinitionWidth(value)

    /// Adjusts the ColumnDefinitionWidth property in the visual element
    let columnDefinitionWidth (value: obj) (x: XamlElement) = x.ColumnDefinitionWidth(value)

    /// Adjusts the Date property in the visual element
    let withDate (value: System.DateTime) (x: XamlElement) = x.Date(value)

    /// Adjusts the Date property in the visual element
    let date (value: System.DateTime) (x: XamlElement) = x.Date(value)

    /// Adjusts the Format property in the visual element
    let withFormat (value: string) (x: XamlElement) = x.Format(value)

    /// Adjusts the Format property in the visual element
    let format (value: string) (x: XamlElement) = x.Format(value)

    /// Adjusts the MinimumDate property in the visual element
    let withMinimumDate (value: System.DateTime) (x: XamlElement) = x.MinimumDate(value)

    /// Adjusts the MinimumDate property in the visual element
    let minimumDate (value: System.DateTime) (x: XamlElement) = x.MinimumDate(value)

    /// Adjusts the MaximumDate property in the visual element
    let withMaximumDate (value: System.DateTime) (x: XamlElement) = x.MaximumDate(value)

    /// Adjusts the MaximumDate property in the visual element
    let maximumDate (value: System.DateTime) (x: XamlElement) = x.MaximumDate(value)

    /// Adjusts the DateSelected property in the visual element
    let withDateSelected (value: Xamarin.Forms.DateChangedEventArgs -> unit) (x: XamlElement) = x.DateSelected(value)

    /// Adjusts the DateSelected property in the visual element
    let dateSelected (value: Xamarin.Forms.DateChangedEventArgs -> unit) (x: XamlElement) = x.DateSelected(value)

    /// Adjusts the PickerItemsSource property in the visual element
    let withPickerItemsSource (value: 'T list) (x: XamlElement) = x.PickerItemsSource(value)

    /// Adjusts the PickerItemsSource property in the visual element
    let pickerItemsSource (value: 'T list) (x: XamlElement) = x.PickerItemsSource(value)

    /// Adjusts the SelectedIndex property in the visual element
    let withSelectedIndex (value: int) (x: XamlElement) = x.SelectedIndex(value)

    /// Adjusts the SelectedIndex property in the visual element
    let selectedIndex (value: int) (x: XamlElement) = x.SelectedIndex(value)

    /// Adjusts the Title property in the visual element
    let withTitle (value: string) (x: XamlElement) = x.Title(value)

    /// Adjusts the Title property in the visual element
    let title (value: string) (x: XamlElement) = x.Title(value)

    /// Adjusts the SelectedIndexChanged property in the visual element
    let withSelectedIndexChanged (value: (int * 'T option) -> unit) (x: XamlElement) = x.SelectedIndexChanged(value)

    /// Adjusts the SelectedIndexChanged property in the visual element
    let selectedIndexChanged (value: (int * 'T option) -> unit) (x: XamlElement) = x.SelectedIndexChanged(value)

    /// Adjusts the OutlineColor property in the visual element
    let withOutlineColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.OutlineColor(value)

    /// Adjusts the OutlineColor property in the visual element
    let outlineColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.OutlineColor(value)

    /// Adjusts the FrameCornerRadius property in the visual element
    let withFrameCornerRadius (value: single) (x: XamlElement) = x.FrameCornerRadius(value)

    /// Adjusts the FrameCornerRadius property in the visual element
    let frameCornerRadius (value: single) (x: XamlElement) = x.FrameCornerRadius(value)

    /// Adjusts the HasShadow property in the visual element
    let withHasShadow (value: bool) (x: XamlElement) = x.HasShadow(value)

    /// Adjusts the HasShadow property in the visual element
    let hasShadow (value: bool) (x: XamlElement) = x.HasShadow(value)

    /// Adjusts the ImageSource property in the visual element
    let withImageSource (value: string) (x: XamlElement) = x.ImageSource(value)

    /// Adjusts the ImageSource property in the visual element
    let imageSource (value: string) (x: XamlElement) = x.ImageSource(value)

    /// Adjusts the Aspect property in the visual element
    let withAspect (value: Xamarin.Forms.Aspect) (x: XamlElement) = x.Aspect(value)

    /// Adjusts the Aspect property in the visual element
    let aspect (value: Xamarin.Forms.Aspect) (x: XamlElement) = x.Aspect(value)

    /// Adjusts the IsOpaque property in the visual element
    let withIsOpaque (value: bool) (x: XamlElement) = x.IsOpaque(value)

    /// Adjusts the IsOpaque property in the visual element
    let isOpaque (value: bool) (x: XamlElement) = x.IsOpaque(value)

    /// Adjusts the Keyboard property in the visual element
    let withKeyboard (value: Xamarin.Forms.Keyboard) (x: XamlElement) = x.Keyboard(value)

    /// Adjusts the Keyboard property in the visual element
    let keyboard (value: Xamarin.Forms.Keyboard) (x: XamlElement) = x.Keyboard(value)

    /// Adjusts the EditorCompleted property in the visual element
    let withEditorCompleted (value: string -> unit) (x: XamlElement) = x.EditorCompleted(value)

    /// Adjusts the EditorCompleted property in the visual element
    let editorCompleted (value: string -> unit) (x: XamlElement) = x.EditorCompleted(value)

    /// Adjusts the TextChanged property in the visual element
    let withTextChanged (value: Xamarin.Forms.TextChangedEventArgs -> unit) (x: XamlElement) = x.TextChanged(value)

    /// Adjusts the TextChanged property in the visual element
    let textChanged (value: Xamarin.Forms.TextChangedEventArgs -> unit) (x: XamlElement) = x.TextChanged(value)

    /// Adjusts the IsPassword property in the visual element
    let withIsPassword (value: bool) (x: XamlElement) = x.IsPassword(value)

    /// Adjusts the IsPassword property in the visual element
    let isPassword (value: bool) (x: XamlElement) = x.IsPassword(value)

    /// Adjusts the EntryCompleted property in the visual element
    let withEntryCompleted (value: string -> unit) (x: XamlElement) = x.EntryCompleted(value)

    /// Adjusts the EntryCompleted property in the visual element
    let entryCompleted (value: string -> unit) (x: XamlElement) = x.EntryCompleted(value)

    /// Adjusts the Label property in the visual element
    let withLabel (value: string) (x: XamlElement) = x.Label(value)

    /// Adjusts the Label property in the visual element
    let label (value: string) (x: XamlElement) = x.Label(value)

    /// Adjusts the VerticalTextAlignment property in the visual element
    let withVerticalTextAlignment (value: Xamarin.Forms.TextAlignment) (x: XamlElement) = x.VerticalTextAlignment(value)

    /// Adjusts the VerticalTextAlignment property in the visual element
    let verticalTextAlignment (value: Xamarin.Forms.TextAlignment) (x: XamlElement) = x.VerticalTextAlignment(value)

    /// Adjusts the IsClippedToBounds property in the visual element
    let withIsClippedToBounds (value: bool) (x: XamlElement) = x.IsClippedToBounds(value)

    /// Adjusts the IsClippedToBounds property in the visual element
    let isClippedToBounds (value: bool) (x: XamlElement) = x.IsClippedToBounds(value)

    /// Adjusts the Padding property in the visual element
    let withPadding (value: obj) (x: XamlElement) = x.Padding(value)

    /// Adjusts the Padding property in the visual element
    let padding (value: obj) (x: XamlElement) = x.Padding(value)

    /// Adjusts the StackOrientation property in the visual element
    let withStackOrientation (value: Xamarin.Forms.StackOrientation) (x: XamlElement) = x.StackOrientation(value)

    /// Adjusts the StackOrientation property in the visual element
    let stackOrientation (value: Xamarin.Forms.StackOrientation) (x: XamlElement) = x.StackOrientation(value)

    /// Adjusts the Spacing property in the visual element
    let withSpacing (value: double) (x: XamlElement) = x.Spacing(value)

    /// Adjusts the Spacing property in the visual element
    let spacing (value: double) (x: XamlElement) = x.Spacing(value)

    /// Adjusts the ForegroundColor property in the visual element
    let withForegroundColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.ForegroundColor(value)

    /// Adjusts the ForegroundColor property in the visual element
    let foregroundColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.ForegroundColor(value)

    /// Adjusts the PropertyChanged property in the visual element
    let withPropertyChanged (value: System.ComponentModel.PropertyChangedEventArgs -> unit) (x: XamlElement) = x.PropertyChanged(value)

    /// Adjusts the PropertyChanged property in the visual element
    let propertyChanged (value: System.ComponentModel.PropertyChangedEventArgs -> unit) (x: XamlElement) = x.PropertyChanged(value)

    /// Adjusts the Time property in the visual element
    let withTime (value: System.TimeSpan) (x: XamlElement) = x.Time(value)

    /// Adjusts the Time property in the visual element
    let time (value: System.TimeSpan) (x: XamlElement) = x.Time(value)

    /// Adjusts the WebSource property in the visual element
    let withWebSource (value: Xamarin.Forms.WebViewSource) (x: XamlElement) = x.WebSource(value)

    /// Adjusts the WebSource property in the visual element
    let webSource (value: Xamarin.Forms.WebViewSource) (x: XamlElement) = x.WebSource(value)

    /// Adjusts the Navigated property in the visual element
    let withNavigated (value: Xamarin.Forms.WebNavigatedEventArgs -> unit) (x: XamlElement) = x.Navigated(value)

    /// Adjusts the Navigated property in the visual element
    let navigated (value: Xamarin.Forms.WebNavigatedEventArgs -> unit) (x: XamlElement) = x.Navigated(value)

    /// Adjusts the Navigating property in the visual element
    let withNavigating (value: Xamarin.Forms.WebNavigatingEventArgs -> unit) (x: XamlElement) = x.Navigating(value)

    /// Adjusts the Navigating property in the visual element
    let navigating (value: Xamarin.Forms.WebNavigatingEventArgs -> unit) (x: XamlElement) = x.Navigating(value)

    /// Adjusts the UseSafeArea property in the visual element
    let withUseSafeArea (value: bool) (x: XamlElement) = x.UseSafeArea(value)

    /// Adjusts the UseSafeArea property in the visual element
    let useSafeArea (value: bool) (x: XamlElement) = x.UseSafeArea(value)

    /// Adjusts the ItemsSource property in the visual element
    let withItemsSource (value: 'T list) (x: XamlElement) = x.ItemsSource(value)

    /// Adjusts the ItemsSource property in the visual element
    let itemsSource (value: 'T list) (x: XamlElement) = x.ItemsSource(value)

    /// Adjusts the ItemTemplate property in the visual element
    let withItemTemplate (value: Xamarin.Forms.DataTemplate) (x: XamlElement) = x.ItemTemplate(value)

    /// Adjusts the ItemTemplate property in the visual element
    let itemTemplate (value: Xamarin.Forms.DataTemplate) (x: XamlElement) = x.ItemTemplate(value)

    /// Adjusts the CarouselPage_SelectedItem property in the visual element
    let withCarouselPage_SelectedItem (value: System.Object) (x: XamlElement) = x.CarouselPage_SelectedItem(value)

    /// Adjusts the CarouselPage_SelectedItem property in the visual element
    let carouselPage_SelectedItem (value: System.Object) (x: XamlElement) = x.CarouselPage_SelectedItem(value)

    /// Adjusts the CurrentPage property in the visual element
    let withCurrentPage (value: XamlElement) (x: XamlElement) = x.CurrentPage(value)

    /// Adjusts the CurrentPage property in the visual element
    let currentPage (value: XamlElement) (x: XamlElement) = x.CurrentPage(value)

    /// Adjusts the CurrentPageChanged property in the visual element
    let withCurrentPageChanged (value: 'T option -> unit) (x: XamlElement) = x.CurrentPageChanged(value)

    /// Adjusts the CurrentPageChanged property in the visual element
    let currentPageChanged (value: 'T option -> unit) (x: XamlElement) = x.CurrentPageChanged(value)

    /// Adjusts the NavigationPagePages property in the visual element
    let withNavigationPagePages (value: XamlElement list) (x: XamlElement) = x.NavigationPagePages(value)

    /// Adjusts the NavigationPagePages property in the visual element
    let navigationPagePages (value: XamlElement list) (x: XamlElement) = x.NavigationPagePages(value)

    /// Adjusts the BackButtonTitle property in the visual element
    let withBackButtonTitle (value: string) (x: XamlElement) = x.BackButtonTitle(value)

    /// Adjusts the BackButtonTitle property in the visual element
    let backButtonTitle (value: string) (x: XamlElement) = x.BackButtonTitle(value)

    /// Adjusts the HasBackButton property in the visual element
    let withHasBackButton (value: bool) (x: XamlElement) = x.HasBackButton(value)

    /// Adjusts the HasBackButton property in the visual element
    let hasBackButton (value: bool) (x: XamlElement) = x.HasBackButton(value)

    /// Adjusts the HasNavigationBar property in the visual element
    let withHasNavigationBar (value: bool) (x: XamlElement) = x.HasNavigationBar(value)

    /// Adjusts the HasNavigationBar property in the visual element
    let hasNavigationBar (value: bool) (x: XamlElement) = x.HasNavigationBar(value)

    /// Adjusts the TitleIcon property in the visual element
    let withTitleIcon (value: string) (x: XamlElement) = x.TitleIcon(value)

    /// Adjusts the TitleIcon property in the visual element
    let titleIcon (value: string) (x: XamlElement) = x.TitleIcon(value)

    /// Adjusts the BarBackgroundColor property in the visual element
    let withBarBackgroundColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.BarBackgroundColor(value)

    /// Adjusts the BarBackgroundColor property in the visual element
    let barBackgroundColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.BarBackgroundColor(value)

    /// Adjusts the BarTextColor property in the visual element
    let withBarTextColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.BarTextColor(value)

    /// Adjusts the BarTextColor property in the visual element
    let barTextColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.BarTextColor(value)

    /// Adjusts the Popped property in the visual element
    let withPopped (value: Xamarin.Forms.NavigationEventArgs -> unit) (x: XamlElement) = x.Popped(value)

    /// Adjusts the Popped property in the visual element
    let popped (value: Xamarin.Forms.NavigationEventArgs -> unit) (x: XamlElement) = x.Popped(value)

    /// Adjusts the PoppedToRoot property in the visual element
    let withPoppedToRoot (value: Xamarin.Forms.NavigationEventArgs -> unit) (x: XamlElement) = x.PoppedToRoot(value)

    /// Adjusts the PoppedToRoot property in the visual element
    let poppedToRoot (value: Xamarin.Forms.NavigationEventArgs -> unit) (x: XamlElement) = x.PoppedToRoot(value)

    /// Adjusts the Pushed property in the visual element
    let withPushed (value: Xamarin.Forms.NavigationEventArgs -> unit) (x: XamlElement) = x.Pushed(value)

    /// Adjusts the Pushed property in the visual element
    let pushed (value: Xamarin.Forms.NavigationEventArgs -> unit) (x: XamlElement) = x.Pushed(value)

    /// Adjusts the OnSizeAllocatedCallback property in the visual element
    let withOnSizeAllocatedCallback (value: (double * double) -> unit) (x: XamlElement) = x.OnSizeAllocatedCallback(value)

    /// Adjusts the OnSizeAllocatedCallback property in the visual element
    let onSizeAllocatedCallback (value: (double * double) -> unit) (x: XamlElement) = x.OnSizeAllocatedCallback(value)

    /// Adjusts the Master property in the visual element
    let withMaster (value: XamlElement) (x: XamlElement) = x.Master(value)

    /// Adjusts the Master property in the visual element
    let master (value: XamlElement) (x: XamlElement) = x.Master(value)

    /// Adjusts the Detail property in the visual element
    let withDetail (value: XamlElement) (x: XamlElement) = x.Detail(value)

    /// Adjusts the Detail property in the visual element
    let detail (value: XamlElement) (x: XamlElement) = x.Detail(value)

    /// Adjusts the IsGestureEnabled property in the visual element
    let withIsGestureEnabled (value: bool) (x: XamlElement) = x.IsGestureEnabled(value)

    /// Adjusts the IsGestureEnabled property in the visual element
    let isGestureEnabled (value: bool) (x: XamlElement) = x.IsGestureEnabled(value)

    /// Adjusts the IsPresented property in the visual element
    let withIsPresented (value: bool) (x: XamlElement) = x.IsPresented(value)

    /// Adjusts the IsPresented property in the visual element
    let isPresented (value: bool) (x: XamlElement) = x.IsPresented(value)

    /// Adjusts the MasterBehavior property in the visual element
    let withMasterBehavior (value: Xamarin.Forms.MasterBehavior) (x: XamlElement) = x.MasterBehavior(value)

    /// Adjusts the MasterBehavior property in the visual element
    let masterBehavior (value: Xamarin.Forms.MasterBehavior) (x: XamlElement) = x.MasterBehavior(value)

    /// Adjusts the IsPresentedChanged property in the visual element
    let withIsPresentedChanged (value: bool -> unit) (x: XamlElement) = x.IsPresentedChanged(value)

    /// Adjusts the IsPresentedChanged property in the visual element
    let isPresentedChanged (value: bool -> unit) (x: XamlElement) = x.IsPresentedChanged(value)

    /// Adjusts the Height property in the visual element
    let withHeight (value: double) (x: XamlElement) = x.Height(value)

    /// Adjusts the Height property in the visual element
    let height (value: double) (x: XamlElement) = x.Height(value)

    /// Adjusts the TextDetail property in the visual element
    let withTextDetail (value: string) (x: XamlElement) = x.TextDetail(value)

    /// Adjusts the TextDetail property in the visual element
    let textDetail (value: string) (x: XamlElement) = x.TextDetail(value)

    /// Adjusts the TextDetailColor property in the visual element
    let withTextDetailColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.TextDetailColor(value)

    /// Adjusts the TextDetailColor property in the visual element
    let textDetailColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.TextDetailColor(value)

    /// Adjusts the TextCellCommand property in the visual element
    let withTextCellCommand (value: unit -> unit) (x: XamlElement) = x.TextCellCommand(value)

    /// Adjusts the TextCellCommand property in the visual element
    let textCellCommand (value: unit -> unit) (x: XamlElement) = x.TextCellCommand(value)

    /// Adjusts the TextCellCanExecute property in the visual element
    let withTextCellCanExecute (value: bool) (x: XamlElement) = x.TextCellCanExecute(value)

    /// Adjusts the TextCellCanExecute property in the visual element
    let textCellCanExecute (value: bool) (x: XamlElement) = x.TextCellCanExecute(value)

    /// Adjusts the View property in the visual element
    let withView (value: XamlElement) (x: XamlElement) = x.View(value)

    /// Adjusts the View property in the visual element
    let view (value: XamlElement) (x: XamlElement) = x.View(value)

    /// Adjusts the ListViewItems property in the visual element
    let withListViewItems (value: XamlElement list) (x: XamlElement) = x.ListViewItems(value)

    /// Adjusts the ListViewItems property in the visual element
    let listViewItems (value: XamlElement list) (x: XamlElement) = x.ListViewItems(value)

    /// Adjusts the Footer property in the visual element
    let withFooter (value: System.Object) (x: XamlElement) = x.Footer(value)

    /// Adjusts the Footer property in the visual element
    let footer (value: System.Object) (x: XamlElement) = x.Footer(value)

    /// Adjusts the Header property in the visual element
    let withHeader (value: System.Object) (x: XamlElement) = x.Header(value)

    /// Adjusts the Header property in the visual element
    let header (value: System.Object) (x: XamlElement) = x.Header(value)

    /// Adjusts the HeaderTemplate property in the visual element
    let withHeaderTemplate (value: Xamarin.Forms.DataTemplate) (x: XamlElement) = x.HeaderTemplate(value)

    /// Adjusts the HeaderTemplate property in the visual element
    let headerTemplate (value: Xamarin.Forms.DataTemplate) (x: XamlElement) = x.HeaderTemplate(value)

    /// Adjusts the IsGroupingEnabled property in the visual element
    let withIsGroupingEnabled (value: bool) (x: XamlElement) = x.IsGroupingEnabled(value)

    /// Adjusts the IsGroupingEnabled property in the visual element
    let isGroupingEnabled (value: bool) (x: XamlElement) = x.IsGroupingEnabled(value)

    /// Adjusts the IsPullToRefreshEnabled property in the visual element
    let withIsPullToRefreshEnabled (value: bool) (x: XamlElement) = x.IsPullToRefreshEnabled(value)

    /// Adjusts the IsPullToRefreshEnabled property in the visual element
    let isPullToRefreshEnabled (value: bool) (x: XamlElement) = x.IsPullToRefreshEnabled(value)

    /// Adjusts the IsRefreshing property in the visual element
    let withIsRefreshing (value: bool) (x: XamlElement) = x.IsRefreshing(value)

    /// Adjusts the IsRefreshing property in the visual element
    let isRefreshing (value: bool) (x: XamlElement) = x.IsRefreshing(value)

    /// Adjusts the RefreshCommand property in the visual element
    let withRefreshCommand (value: unit -> unit) (x: XamlElement) = x.RefreshCommand(value)

    /// Adjusts the RefreshCommand property in the visual element
    let refreshCommand (value: unit -> unit) (x: XamlElement) = x.RefreshCommand(value)

    /// Adjusts the ListView_SelectedItem property in the visual element
    let withListView_SelectedItem (value: int option) (x: XamlElement) = x.ListView_SelectedItem(value)

    /// Adjusts the ListView_SelectedItem property in the visual element
    let listView_SelectedItem (value: int option) (x: XamlElement) = x.ListView_SelectedItem(value)

    /// Adjusts the SeparatorVisibility property in the visual element
    let withSeparatorVisibility (value: Xamarin.Forms.SeparatorVisibility) (x: XamlElement) = x.SeparatorVisibility(value)

    /// Adjusts the SeparatorVisibility property in the visual element
    let separatorVisibility (value: Xamarin.Forms.SeparatorVisibility) (x: XamlElement) = x.SeparatorVisibility(value)

    /// Adjusts the SeparatorColor property in the visual element
    let withSeparatorColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.SeparatorColor(value)

    /// Adjusts the SeparatorColor property in the visual element
    let separatorColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.SeparatorColor(value)

    /// Adjusts the ItemAppearing property in the visual element
    let withItemAppearing (value: Xamarin.Forms.ItemVisibilityEventArgs -> unit) (x: XamlElement) = x.ItemAppearing(value)

    /// Adjusts the ItemAppearing property in the visual element
    let itemAppearing (value: Xamarin.Forms.ItemVisibilityEventArgs -> unit) (x: XamlElement) = x.ItemAppearing(value)

    /// Adjusts the ItemDisappearing property in the visual element
    let withItemDisappearing (value: Xamarin.Forms.ItemVisibilityEventArgs -> unit) (x: XamlElement) = x.ItemDisappearing(value)

    /// Adjusts the ItemDisappearing property in the visual element
    let itemDisappearing (value: Xamarin.Forms.ItemVisibilityEventArgs -> unit) (x: XamlElement) = x.ItemDisappearing(value)

    /// Adjusts the ListView_ItemSelected property in the visual element
    let withListView_ItemSelected (value: int option -> unit) (x: XamlElement) = x.ListView_ItemSelected(value)

    /// Adjusts the ListView_ItemSelected property in the visual element
    let listView_ItemSelected (value: int option -> unit) (x: XamlElement) = x.ListView_ItemSelected(value)

    /// Adjusts the ItemTapped property in the visual element
    let withItemTapped (value: Xamarin.Forms.ItemTappedEventArgs -> unit) (x: XamlElement) = x.ItemTapped(value)

    /// Adjusts the ItemTapped property in the visual element
    let itemTapped (value: Xamarin.Forms.ItemTappedEventArgs -> unit) (x: XamlElement) = x.ItemTapped(value)

    /// Adjusts the Refreshing property in the visual element
    let withRefreshing (value: unit -> unit) (x: XamlElement) = x.Refreshing(value)

    /// Adjusts the Refreshing property in the visual element
    let refreshing (value: unit -> unit) (x: XamlElement) = x.Refreshing(value)

    /// Adjusts the GroupListViewItemsSource property in the visual element
    let withGroupListViewItemsSource (value: (XamlElement * XamlElement list) list) (x: XamlElement) = x.GroupListViewItemsSource(value)

    /// Adjusts the GroupListViewItemsSource property in the visual element
    let groupListViewItemsSource (value: (XamlElement * XamlElement list) list) (x: XamlElement) = x.GroupListViewItemsSource(value)

    /// Adjusts the ListViewGrouped_SelectedItem property in the visual element
    let withListViewGrouped_SelectedItem (value: (int * int) option) (x: XamlElement) = x.ListViewGrouped_SelectedItem(value)

    /// Adjusts the ListViewGrouped_SelectedItem property in the visual element
    let listViewGrouped_SelectedItem (value: (int * int) option) (x: XamlElement) = x.ListViewGrouped_SelectedItem(value)

    /// Adjusts the ListViewGrouped_ItemSelected property in the visual element
    let withListViewGrouped_ItemSelected (value: (int * int) option -> unit) (x: XamlElement) = x.ListViewGrouped_ItemSelected(value)

    /// Adjusts the ListViewGrouped_ItemSelected property in the visual element
    let listViewGrouped_ItemSelected (value: (int * int) option -> unit) (x: XamlElement) = x.ListViewGrouped_ItemSelected(value)

type Xaml() =

    /// Describes a Element in the view
    static member Element(?classId: string, ?styleId: string) = 
        let attribs = [| 
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.Element"

        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.Element)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Element::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Element::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Element>, create, update, Map.ofArray attribs)

    /// Describes a VisualElement in the view
    static member VisualElement(?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.VisualElement"

        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.VisualElement)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.VisualElement>, create, update, Map.ofArray attribs)

    /// Describes a View in the view
    static member View(?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.View"

        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.View)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting View::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting View::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting View::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting View::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting View::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting View::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting View::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting View::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting View::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting View::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting View::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting View::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting View::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting View::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting View::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting View::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting View::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting View::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting View::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting View::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting View::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting View::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting View::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.View>, create, update, Map.ofArray attribs)

    /// Describes a IGestureRecognizer in the view
    static member IGestureRecognizer() = 
        let attribs = [| 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.IGestureRecognizer"

        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            ()
        new XamlElement(typeof<Xamarin.Forms.IGestureRecognizer>, create, update, Map.ofArray attribs)

    /// Describes a PanGestureRecognizer in the view
    static member PanGestureRecognizer(?touchPoints: int, ?panUpdated: Xamarin.Forms.PanUpdatedEventArgs -> unit, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match touchPoints with None -> () | Some v -> yield ("TouchPoints", box ((v))) 
            match panUpdated with None -> () | Some v -> yield ("PanUpdated", box ((fun f -> System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>(fun _sender args -> f args))(v))) 
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.PanGestureRecognizer())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.PanGestureRecognizer)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTouchPoints
            let valueOpt = source.TryTouchPoints
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting PanGestureRecognizer::TouchPoints "); target.TouchPoints <-  value
            | USome _, UNone -> target.TouchPoints <- 1
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryPanUpdated
            match prevValueOpt, source.TryPanUpdated with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.PanUpdated.RemoveHandler(prevValue); target.PanUpdated.AddHandler(value)
            | UNone, USome value -> target.PanUpdated.AddHandler(value)
            | USome prevValue, UNone -> target.PanUpdated.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting PanGestureRecognizer::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting PanGestureRecognizer::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.PanGestureRecognizer>, create, update, Map.ofArray attribs)

    /// Describes a TapGestureRecognizer in the view
    static member TapGestureRecognizer(?command: unit -> unit, ?numberOfTapsRequired: int, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match command with None -> () | Some v -> yield ("Command", box (makeCommand(v))) 
            match numberOfTapsRequired with None -> () | Some v -> yield ("NumberOfTapsRequired", box ((v))) 
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.TapGestureRecognizer())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.TapGestureRecognizer)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryCommand
            let valueOpt = source.TryCommand
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TapGestureRecognizer::Command "); target.Command <-  value
            | USome _, UNone -> target.Command <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryNumberOfTapsRequired
            let valueOpt = source.TryNumberOfTapsRequired
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TapGestureRecognizer::NumberOfTapsRequired "); target.NumberOfTapsRequired <-  value
            | USome _, UNone -> target.NumberOfTapsRequired <- 1
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TapGestureRecognizer::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TapGestureRecognizer::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.TapGestureRecognizer>, create, update, Map.ofArray attribs)

    /// Describes a ClickGestureRecognizer in the view
    static member ClickGestureRecognizer(?command: unit -> unit, ?numberOfClicksRequired: int, ?buttons: Xamarin.Forms.ButtonsMask, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match command with None -> () | Some v -> yield ("Command", box (makeCommand(v))) 
            match numberOfClicksRequired with None -> () | Some v -> yield ("NumberOfClicksRequired", box ((v))) 
            match buttons with None -> () | Some v -> yield ("Buttons", box ((v))) 
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.ClickGestureRecognizer())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.ClickGestureRecognizer)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryCommand
            let valueOpt = source.TryCommand
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ClickGestureRecognizer::Command "); target.Command <-  value
            | USome _, UNone -> target.Command <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryNumberOfClicksRequired
            let valueOpt = source.TryNumberOfClicksRequired
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ClickGestureRecognizer::NumberOfClicksRequired "); target.NumberOfClicksRequired <-  value
            | USome _, UNone -> target.NumberOfClicksRequired <- 1
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryButtons
            let valueOpt = source.TryButtons
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ClickGestureRecognizer::Buttons "); target.Buttons <-  value
            | USome _, UNone -> target.Buttons <- Xamarin.Forms.ButtonsMask.Primary
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ClickGestureRecognizer::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ClickGestureRecognizer::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.ClickGestureRecognizer>, create, update, Map.ofArray attribs)

    /// Describes a PinchGestureRecognizer in the view
    static member PinchGestureRecognizer(?isPinching: bool, ?pinchUpdated: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match isPinching with None -> () | Some v -> yield ("IsPinching", box ((v))) 
            match pinchUpdated with None -> () | Some v -> yield ("PinchUpdated", box ((fun f -> System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>(fun _sender args -> f args))(v))) 
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.PinchGestureRecognizer())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.PinchGestureRecognizer)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsPinching
            let valueOpt = source.TryIsPinching
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting PinchGestureRecognizer::IsPinching "); target.IsPinching <-  value
            | USome _, UNone -> target.IsPinching <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryPinchUpdated
            match prevValueOpt, source.TryPinchUpdated with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.PinchUpdated.RemoveHandler(prevValue); target.PinchUpdated.AddHandler(value)
            | UNone, USome value -> target.PinchUpdated.AddHandler(value)
            | USome prevValue, UNone -> target.PinchUpdated.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting PinchGestureRecognizer::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting PinchGestureRecognizer::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.PinchGestureRecognizer>, create, update, Map.ofArray attribs)

    /// Describes a ActivityIndicator in the view
    static member ActivityIndicator(?color: Xamarin.Forms.Color, ?isRunning: bool, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match color with None -> () | Some v -> yield ("Color", box ((v))) 
            match isRunning with None -> () | Some v -> yield ("IsRunning", box ((v))) 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.ActivityIndicator())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.ActivityIndicator)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryColor
            let valueOpt = source.TryColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ActivityIndicator::Color "); target.Color <-  value
            | USome _, UNone -> target.Color <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsRunning
            let valueOpt = source.TryIsRunning
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ActivityIndicator::IsRunning "); target.IsRunning <-  value
            | USome _, UNone -> target.IsRunning <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ActivityIndicator::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ActivityIndicator::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ActivityIndicator::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ActivityIndicator::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ActivityIndicator::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ActivityIndicator::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ActivityIndicator::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ActivityIndicator::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ActivityIndicator::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ActivityIndicator::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ActivityIndicator::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ActivityIndicator::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ActivityIndicator::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ActivityIndicator::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ActivityIndicator::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ActivityIndicator::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ActivityIndicator::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ActivityIndicator::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ActivityIndicator::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ActivityIndicator::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ActivityIndicator::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ActivityIndicator::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ActivityIndicator::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.ActivityIndicator>, create, update, Map.ofArray attribs)

    /// Describes a BoxView in the view
    static member BoxView(?color: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match color with None -> () | Some v -> yield ("Color", box ((v))) 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.BoxView())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.BoxView)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryColor
            let valueOpt = source.TryColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting BoxView::Color "); target.Color <-  value
            | USome _, UNone -> target.Color <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting BoxView::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting BoxView::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting BoxView::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting BoxView::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting BoxView::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting BoxView::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting BoxView::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting BoxView::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting BoxView::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting BoxView::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting BoxView::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting BoxView::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting BoxView::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting BoxView::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting BoxView::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting BoxView::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting BoxView::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting BoxView::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting BoxView::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting BoxView::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting BoxView::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting BoxView::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting BoxView::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.BoxView>, create, update, Map.ofArray attribs)

    /// Describes a ProgressBar in the view
    static member ProgressBar(?progress: double, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match progress with None -> () | Some v -> yield ("Progress", box ((v))) 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.ProgressBar())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.ProgressBar)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryProgress
            let valueOpt = source.TryProgress
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ProgressBar::Progress "); target.Progress <-  value
            | USome _, UNone -> target.Progress <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ProgressBar::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ProgressBar::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ProgressBar::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ProgressBar::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ProgressBar::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ProgressBar::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ProgressBar::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ProgressBar::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ProgressBar::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ProgressBar::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ProgressBar::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ProgressBar::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ProgressBar::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ProgressBar::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ProgressBar::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ProgressBar::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ProgressBar::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ProgressBar::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ProgressBar::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ProgressBar::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ProgressBar::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ProgressBar::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ProgressBar::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.ProgressBar>, create, update, Map.ofArray attribs)

    /// Describes a ScrollView in the view
    static member ScrollView(?content: XamlElement, ?orientation: Xamarin.Forms.ScrollOrientation, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match content with None -> () | Some v -> yield ("Content", box ((v))) 
            match orientation with None -> () | Some v -> yield ("ScrollOrientation", box ((v))) 
            match isClippedToBounds with None -> () | Some v -> yield ("IsClippedToBounds", box ((v))) 
            match padding with None -> () | Some v -> yield ("Padding", box (makeThickness(v))) 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.ScrollView())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.ScrollView)
            let prevChildOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryContent
            match prevChildOpt, source.TryContent with
            // For structured objects, dependsOn on reference equality
            | USome prevChild, USome newChild when System.Object.ReferenceEquals(prevChild, newChild) -> ()
            | USome prevChild, USome newChild when prevChild.TargetType = newChild.TargetType ->
                newChild.UpdateIncremental(prevChild, target.Content)
            | USome _, USome newChild
            | UNone, USome newChild ->
                target.Content <- newChild.CreateAsView()
            | USome _, UNone ->
                target.Content <- null;
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScrollOrientation
            let valueOpt = source.TryScrollOrientation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ScrollView::Orientation "); target.Orientation <-  value
            | USome _, UNone -> target.Orientation <- Unchecked.defaultof<Xamarin.Forms.ScrollOrientation>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsClippedToBounds
            let valueOpt = source.TryIsClippedToBounds
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ScrollView::IsClippedToBounds "); target.IsClippedToBounds <-  value
            | USome _, UNone -> target.IsClippedToBounds <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryPadding
            let valueOpt = source.TryPadding
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ScrollView::Padding "); target.Padding <-  value
            | USome _, UNone -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ScrollView::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ScrollView::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ScrollView::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ScrollView::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ScrollView::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ScrollView::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ScrollView::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ScrollView::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ScrollView::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ScrollView::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ScrollView::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ScrollView::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ScrollView::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ScrollView::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ScrollView::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ScrollView::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ScrollView::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ScrollView::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ScrollView::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ScrollView::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ScrollView::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ScrollView::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ScrollView::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.ScrollView>, create, update, Map.ofArray attribs)

    /// Describes a SearchBar in the view
    static member SearchBar(?cancelButtonColor: Xamarin.Forms.Color, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?fontSize: obj, ?horizontalTextAlignment: Xamarin.Forms.TextAlignment, ?placeholder: string, ?placeholderColor: Xamarin.Forms.Color, ?searchCommand: unit -> unit, ?canExecute: bool, ?text: string, ?textColor: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
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
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.SearchBar())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.SearchBar)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryCancelButtonColor
            let valueOpt = source.TryCancelButtonColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::CancelButtonColor "); target.CancelButtonColor <-  value
            | USome _, UNone -> target.CancelButtonColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryFontFamily
            let valueOpt = source.TryFontFamily
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::FontFamily "); target.FontFamily <-  value
            | USome _, UNone -> target.FontFamily <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryFontAttributes
            let valueOpt = source.TryFontAttributes
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::FontAttributes "); target.FontAttributes <-  value
            | USome _, UNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryFontSize
            let valueOpt = source.TryFontSize
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::FontSize "); target.FontSize <-  value
            | USome _, UNone -> target.FontSize <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalTextAlignment
            let valueOpt = source.TryHorizontalTextAlignment
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::HorizontalTextAlignment "); target.HorizontalTextAlignment <-  value
            | USome _, UNone -> target.HorizontalTextAlignment <- Xamarin.Forms.TextAlignment.Start
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryPlaceholder
            let valueOpt = source.TryPlaceholder
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::Placeholder "); target.Placeholder <-  value
            | USome _, UNone -> target.Placeholder <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryPlaceholderColor
            let valueOpt = source.TryPlaceholderColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::PlaceholderColor "); target.PlaceholderColor <-  value
            | USome _, UNone -> target.PlaceholderColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TrySearchBarCommand
            let valueOpt = source.TrySearchBarCommand
            (fun _ _ _ -> ()) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TrySearchBarCanExecute
            let valueOpt = source.TrySearchBarCanExecute
            updateCommand (match prevOpt with UNone -> UNone | USome prev -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::Command "); prev.TrySearchBarCommand) prevValueOpt source.TrySearchBarCommand valueOpt (fun cmd -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::Command "); target.SearchCommand <- cmd) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryText
            let valueOpt = source.TryText
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::Text "); target.Text <-  value
            | USome _, UNone -> target.Text <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTextColor
            let valueOpt = source.TryTextColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::TextColor "); target.TextColor <-  value
            | USome _, UNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.SearchBar>, create, update, Map.ofArray attribs)

    /// Describes a Button in the view
    static member Button(?text: string, ?command: unit -> unit, ?canExecute: bool, ?borderColor: Xamarin.Forms.Color, ?borderWidth: double, ?commandParameter: System.Object, ?contentLayout: Xamarin.Forms.Button.ButtonContentLayout, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?fontSize: obj, ?image: string, ?textColor: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
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
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.Button())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.Button)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryText
            let valueOpt = source.TryText
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::Text "); target.Text <-  value
            | USome _, UNone -> target.Text <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryButtonCommand
            let valueOpt = source.TryButtonCommand
            (fun _ _ _ -> ()) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryButtonCanExecute
            let valueOpt = source.TryButtonCanExecute
            updateCommand (match prevOpt with UNone -> UNone | USome prev -> prev.TryButtonCommand) prevValueOpt source.TryButtonCommand valueOpt (fun cmd -> System.Diagnostics.Debug.WriteLine("Setting Button::Command "); target.Command <- cmd) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBorderColor
            let valueOpt = source.TryBorderColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::BorderColor "); target.BorderColor <-  value
            | USome _, UNone -> target.BorderColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBorderWidth
            let valueOpt = source.TryBorderWidth
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::BorderWidth "); target.BorderWidth <-  value
            | USome _, UNone -> target.BorderWidth <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryCommandParameter
            let valueOpt = source.TryCommandParameter
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::CommandParameter "); target.CommandParameter <-  value
            | USome _, UNone -> target.CommandParameter <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryContentLayout
            let valueOpt = source.TryContentLayout
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::ContentLayout "); target.ContentLayout <-  value
            | USome _, UNone -> target.ContentLayout <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryFontFamily
            let valueOpt = source.TryFontFamily
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::FontFamily "); target.FontFamily <-  value
            | USome _, UNone -> target.FontFamily <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryFontAttributes
            let valueOpt = source.TryFontAttributes
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::FontAttributes "); target.FontAttributes <-  value
            | USome _, UNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryFontSize
            let valueOpt = source.TryFontSize
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::FontSize "); target.FontSize <-  value
            | USome _, UNone -> target.FontSize <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryButtonImageSource
            let valueOpt = source.TryButtonImageSource
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::Image "); target.Image <- makeFileImageSource  value
            | USome _, UNone -> target.Image <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTextColor
            let valueOpt = source.TryTextColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::TextColor "); target.TextColor <-  value
            | USome _, UNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Button::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Button>, create, update, Map.ofArray attribs)

    /// Describes a Slider in the view
    static member Slider(?minimum: double, ?maximum: double, ?value: double, ?valueChanged: Xamarin.Forms.ValueChangedEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match minimum with None -> () | Some v -> yield ("Minimum", box ((v))) 
            match maximum with None -> () | Some v -> yield ("Maximum", box ((v))) 
            match value with None -> () | Some v -> yield ("Value", box ((v))) 
            match valueChanged with None -> () | Some v -> yield ("ValueChanged", box ((fun f -> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>(fun _sender args -> f args))(v))) 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.Slider())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.Slider)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimum
            let valueOpt = source.TryMinimum
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::Minimum "); target.Minimum <-  value
            | USome _, UNone -> target.Minimum <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMaximum
            let valueOpt = source.TryMaximum
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::Maximum "); target.Maximum <-  value
            | USome _, UNone -> target.Maximum <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryValue
            let valueOpt = source.TryValue
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::Value "); target.Value <-  value
            | USome _, UNone -> target.Value <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryValueChanged
            match prevValueOpt, source.TryValueChanged with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.ValueChanged.RemoveHandler(prevValue); target.ValueChanged.AddHandler(value)
            | UNone, USome value -> target.ValueChanged.AddHandler(value)
            | USome prevValue, UNone -> target.ValueChanged.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Slider>, create, update, Map.ofArray attribs)

    /// Describes a Stepper in the view
    static member Stepper(?minimum: double, ?maximum: double, ?value: double, ?increment: double, ?valueChanged: Xamarin.Forms.ValueChangedEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match minimum with None -> () | Some v -> yield ("Minimum", box ((v))) 
            match maximum with None -> () | Some v -> yield ("Maximum", box ((v))) 
            match value with None -> () | Some v -> yield ("Value", box ((v))) 
            match increment with None -> () | Some v -> yield ("Increment", box ((v))) 
            match valueChanged with None -> () | Some v -> yield ("ValueChanged", box ((fun f -> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>(fun _sender args -> f args))(v))) 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.Stepper())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.Stepper)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimum
            let valueOpt = source.TryMinimum
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::Minimum "); target.Minimum <-  value
            | USome _, UNone -> target.Minimum <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMaximum
            let valueOpt = source.TryMaximum
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::Maximum "); target.Maximum <-  value
            | USome _, UNone -> target.Maximum <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryValue
            let valueOpt = source.TryValue
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::Value "); target.Value <-  value
            | USome _, UNone -> target.Value <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIncrement
            let valueOpt = source.TryIncrement
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::Increment "); target.Increment <-  value
            | USome _, UNone -> target.Increment <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryValueChanged
            match prevValueOpt, source.TryValueChanged with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.ValueChanged.RemoveHandler(prevValue); target.ValueChanged.AddHandler(value)
            | UNone, USome value -> target.ValueChanged.AddHandler(value)
            | USome prevValue, UNone -> target.ValueChanged.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Stepper>, create, update, Map.ofArray attribs)

    /// Describes a Switch in the view
    static member Switch(?isToggled: bool, ?toggled: Xamarin.Forms.ToggledEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match isToggled with None -> () | Some v -> yield ("IsToggled", box ((v))) 
            match toggled with None -> () | Some v -> yield ("Toggled", box ((fun f -> System.EventHandler<Xamarin.Forms.ToggledEventArgs>(fun _sender args -> f args))(v))) 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.Switch())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.Switch)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsToggled
            let valueOpt = source.TryIsToggled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Switch::IsToggled "); target.IsToggled <-  value
            | USome _, UNone -> target.IsToggled <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryToggled
            match prevValueOpt, source.TryToggled with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.Toggled.RemoveHandler(prevValue); target.Toggled.AddHandler(value)
            | UNone, USome value -> target.Toggled.AddHandler(value)
            | USome prevValue, UNone -> target.Toggled.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Switch::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Switch::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Switch::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Switch::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Switch::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Switch::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Switch::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Switch::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Switch::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Switch::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Switch::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Switch::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Switch::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Switch::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Switch::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Switch::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Switch::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Switch::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Switch::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Switch::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Switch::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Switch::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Switch::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Switch>, create, update, Map.ofArray attribs)

    /// Describes a SwitchCell in the view
    static member SwitchCell(?on: bool, ?text: string, ?onChanged: Xamarin.Forms.ToggledEventArgs -> unit, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match on with None -> () | Some v -> yield ("On", box ((v))) 
            match text with None -> () | Some v -> yield ("Text", box ((v))) 
            match onChanged with None -> () | Some v -> yield ("OnChanged", box ((fun f -> System.EventHandler<Xamarin.Forms.ToggledEventArgs>(fun _sender args -> f args))(v))) 
            match height with None -> () | Some v -> yield ("Height", box ((v))) 
            match isEnabled with None -> () | Some v -> yield ("IsEnabled", box ((v))) 
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.SwitchCell())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.SwitchCell)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOn
            let valueOpt = source.TryOn
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SwitchCell::On "); target.On <-  value
            | USome _, UNone -> target.On <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryText
            let valueOpt = source.TryText
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SwitchCell::Text "); target.Text <-  value
            | USome _, UNone -> target.Text <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOnChanged
            match prevValueOpt, source.TryOnChanged with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.OnChanged.RemoveHandler(prevValue); target.OnChanged.AddHandler(value)
            | UNone, USome value -> target.OnChanged.AddHandler(value)
            | USome prevValue, UNone -> target.OnChanged.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeight
            let valueOpt = source.TryHeight
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SwitchCell::Height "); target.Height <-  value
            | USome _, UNone -> target.Height <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SwitchCell::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SwitchCell::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting SwitchCell::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.SwitchCell>, create, update, Map.ofArray attribs)

    /// Describes a TableView in the view
    static member TableView(?intent: Xamarin.Forms.TableIntent, ?hasUnevenRows: bool, ?rowHeight: int, ?items: (string * XamlElement list) list, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match intent with None -> () | Some v -> yield ("Intent", box ((v))) 
            match hasUnevenRows with None -> () | Some v -> yield ("HasUnevenRows", box ((v))) 
            match rowHeight with None -> () | Some v -> yield ("RowHeight", box ((v))) 
            match items with None -> () | Some v -> yield ("TableRoot", box ((fun es -> es |> Array.ofList |> Array.map (fun (title, es) -> (title, Array.ofList es)))(v))) 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.TableView())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.TableView)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIntent
            let valueOpt = source.TryIntent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::Intent "); target.Intent <-  value
            | USome _, UNone -> target.Intent <- Unchecked.defaultof<Xamarin.Forms.TableIntent>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHasUnevenRows
            let valueOpt = source.TryHasUnevenRows
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::HasUnevenRows "); target.HasUnevenRows <-  value
            | USome _, UNone -> target.HasUnevenRows <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRowHeight
            let valueOpt = source.TryRowHeight
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::RowHeight "); target.RowHeight <-  value
            | USome _, UNone -> target.RowHeight <- -1
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTableRoot
            let valueOpt = source.TryTableRoot
            updateTableViewItems prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.TableView>, create, update, Map.ofArray attribs)

    /// Describes a Grid in the view
    static member Grid(?rowdefs: obj list, ?coldefs: obj list, ?rowSpacing: double, ?columnSpacing: double, ?children: XamlElement list, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match rowdefs with None -> () | Some v -> yield ("GridRowDefinitions", box ((fun es -> es |> Array.ofList |> Array.map (fun h -> Xaml.RowDefinition(height=h)))(v))) 
            match coldefs with None -> () | Some v -> yield ("GridColumnDefinitions", box ((fun es -> es |> Array.ofList |> Array.map (fun h -> Xaml.ColumnDefinition(width=h)))(v))) 
            match rowSpacing with None -> () | Some v -> yield ("RowSpacing", box ((v))) 
            match columnSpacing with None -> () | Some v -> yield ("ColumnSpacing", box ((v))) 
            match children with None -> () | Some v -> yield ("Children", box (Array.ofList(v))) 
            match isClippedToBounds with None -> () | Some v -> yield ("IsClippedToBounds", box ((v))) 
            match padding with None -> () | Some v -> yield ("Padding", box (makeThickness(v))) 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.Grid())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.Grid)
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGridRowDefinitions
            let collOpt = source.TryGridRowDefinitions
            updateIList prevCollOpt collOpt target.RowDefinitions
                (fun (x:XamlElement) -> x.CreateAsRowDefinition())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGridColumnDefinitions
            let collOpt = source.TryGridColumnDefinitions
            updateIList prevCollOpt collOpt target.ColumnDefinitions
                (fun (x:XamlElement) -> x.CreateAsColumnDefinition())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRowSpacing
            let valueOpt = source.TryRowSpacing
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::RowSpacing "); target.RowSpacing <-  value
            | USome _, UNone -> target.RowSpacing <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryColumnSpacing
            let valueOpt = source.TryColumnSpacing
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::ColumnSpacing "); target.ColumnSpacing <-  value
            | USome _, UNone -> target.ColumnSpacing <- 0.0
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryChildren
            let collOpt = source.TryChildren
            updateIList prevCollOpt collOpt target.Children
                (fun (x:XamlElement) -> x.CreateAsView())
                (fun prevChildOpt newChild targetChild -> 
                    // Adjust the attached properties
                    match (match prevChildOpt with UNone -> UNone | USome prevChild -> prevChild.TryGridRow), newChild.TryGridRow with
                    | USome prev, USome v when prev = v -> ()
                    | prevOpt, USome value -> Xamarin.Forms.Grid.SetRow(targetChild, value)
                    | USome _, UNone -> Xamarin.Forms.Grid.SetRow(targetChild, 0) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    match (match prevChildOpt with UNone -> UNone | USome prevChild -> prevChild.TryGridRowSpan), newChild.TryGridRowSpan with
                    | USome prev, USome v when prev = v -> ()
                    | prevOpt, USome value -> Xamarin.Forms.Grid.SetRowSpan(targetChild, value)
                    | USome _, UNone -> Xamarin.Forms.Grid.SetRowSpan(targetChild, 0) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    match (match prevChildOpt with UNone -> UNone | USome prevChild -> prevChild.TryGridColumn), newChild.TryGridColumn with
                    | USome prev, USome v when prev = v -> ()
                    | prevOpt, USome value -> Xamarin.Forms.Grid.SetColumn(targetChild, value)
                    | USome _, UNone -> Xamarin.Forms.Grid.SetColumn(targetChild, 0) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    match (match prevChildOpt with UNone -> UNone | USome prevChild -> prevChild.TryGridColumnSpan), newChild.TryGridColumnSpan with
                    | USome prev, USome v when prev = v -> ()
                    | prevOpt, USome value -> Xamarin.Forms.Grid.SetColumnSpan(targetChild, value)
                    | USome _, UNone -> Xamarin.Forms.Grid.SetColumnSpan(targetChild, 0) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsClippedToBounds
            let valueOpt = source.TryIsClippedToBounds
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::IsClippedToBounds "); target.IsClippedToBounds <-  value
            | USome _, UNone -> target.IsClippedToBounds <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryPadding
            let valueOpt = source.TryPadding
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::Padding "); target.Padding <-  value
            | USome _, UNone -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Grid>, create, update, Map.ofArray attribs)

    /// Describes a AbsoluteLayout in the view
    static member AbsoluteLayout(?children: XamlElement list, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match children with None -> () | Some v -> yield ("Children", box (Array.ofList(v))) 
            match isClippedToBounds with None -> () | Some v -> yield ("IsClippedToBounds", box ((v))) 
            match padding with None -> () | Some v -> yield ("Padding", box (makeThickness(v))) 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.AbsoluteLayout())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.AbsoluteLayout)
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryChildren
            let collOpt = source.TryChildren
            updateIList prevCollOpt collOpt target.Children
                (fun (x:XamlElement) -> x.CreateAsView())
                (fun prevChildOpt newChild targetChild -> 
                    // Adjust the attached properties
                    match (match prevChildOpt with UNone -> UNone | USome prevChild -> prevChild.TryLayoutBounds), newChild.TryLayoutBounds with
                    | USome prev, USome v when prev = v -> ()
                    | prevOpt, USome value -> Xamarin.Forms.AbsoluteLayout.SetLayoutBounds(targetChild, value)
                    | USome _, UNone -> Xamarin.Forms.AbsoluteLayout.SetLayoutBounds(targetChild, Xamarin.Forms.Rectangle.Zero) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    match (match prevChildOpt with UNone -> UNone | USome prevChild -> prevChild.TryLayoutFlags), newChild.TryLayoutFlags with
                    | USome prev, USome v when prev = v -> ()
                    | prevOpt, USome value -> Xamarin.Forms.AbsoluteLayout.SetLayoutFlags(targetChild, value)
                    | USome _, UNone -> Xamarin.Forms.AbsoluteLayout.SetLayoutFlags(targetChild, Xamarin.Forms.AbsoluteLayoutFlags.None) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsClippedToBounds
            let valueOpt = source.TryIsClippedToBounds
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting AbsoluteLayout::IsClippedToBounds "); target.IsClippedToBounds <-  value
            | USome _, UNone -> target.IsClippedToBounds <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryPadding
            let valueOpt = source.TryPadding
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting AbsoluteLayout::Padding "); target.Padding <-  value
            | USome _, UNone -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting AbsoluteLayout::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting AbsoluteLayout::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting AbsoluteLayout::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting AbsoluteLayout::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting AbsoluteLayout::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting AbsoluteLayout::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting AbsoluteLayout::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting AbsoluteLayout::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting AbsoluteLayout::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting AbsoluteLayout::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting AbsoluteLayout::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting AbsoluteLayout::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting AbsoluteLayout::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting AbsoluteLayout::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting AbsoluteLayout::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting AbsoluteLayout::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting AbsoluteLayout::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting AbsoluteLayout::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting AbsoluteLayout::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting AbsoluteLayout::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting AbsoluteLayout::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting AbsoluteLayout::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting AbsoluteLayout::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.AbsoluteLayout>, create, update, Map.ofArray attribs)

    /// Describes a RelativeLayout in the view
    static member RelativeLayout(?children: XamlElement list, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match children with None -> () | Some v -> yield ("Children", box (Array.ofList(v))) 
            match isClippedToBounds with None -> () | Some v -> yield ("IsClippedToBounds", box ((v))) 
            match padding with None -> () | Some v -> yield ("Padding", box (makeThickness(v))) 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.RelativeLayout())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.RelativeLayout)
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryChildren
            let collOpt = source.TryChildren
            updateIList prevCollOpt collOpt target.Children
                (fun (x:XamlElement) -> x.CreateAsView())
                (fun prevChildOpt newChild targetChild -> 
                    // Adjust the attached properties
                    match (match prevChildOpt with UNone -> UNone | USome prevChild -> prevChild.TryBoundsConstraint), newChild.TryBoundsConstraint with
                    | USome prev, USome v when prev = v -> ()
                    | prevOpt, USome value -> Xamarin.Forms.RelativeLayout.SetBoundsConstraint(targetChild, value)
                    | USome _, UNone -> Xamarin.Forms.RelativeLayout.SetBoundsConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    match (match prevChildOpt with UNone -> UNone | USome prevChild -> prevChild.TryHeightConstraint), newChild.TryHeightConstraint with
                    | USome prev, USome v when prev = v -> ()
                    | prevOpt, USome value -> Xamarin.Forms.RelativeLayout.SetHeightConstraint(targetChild, value)
                    | USome _, UNone -> Xamarin.Forms.RelativeLayout.SetHeightConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    match (match prevChildOpt with UNone -> UNone | USome prevChild -> prevChild.TryWidthConstraint), newChild.TryWidthConstraint with
                    | USome prev, USome v when prev = v -> ()
                    | prevOpt, USome value -> Xamarin.Forms.RelativeLayout.SetWidthConstraint(targetChild, value)
                    | USome _, UNone -> Xamarin.Forms.RelativeLayout.SetWidthConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    match (match prevChildOpt with UNone -> UNone | USome prevChild -> prevChild.TryXConstraint), newChild.TryXConstraint with
                    | USome prev, USome v when prev = v -> ()
                    | prevOpt, USome value -> Xamarin.Forms.RelativeLayout.SetXConstraint(targetChild, value)
                    | USome _, UNone -> Xamarin.Forms.RelativeLayout.SetXConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    match (match prevChildOpt with UNone -> UNone | USome prevChild -> prevChild.TryYConstraint), newChild.TryYConstraint with
                    | USome prev, USome v when prev = v -> ()
                    | prevOpt, USome value -> Xamarin.Forms.RelativeLayout.SetYConstraint(targetChild, value)
                    | USome _, UNone -> Xamarin.Forms.RelativeLayout.SetYConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsClippedToBounds
            let valueOpt = source.TryIsClippedToBounds
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting RelativeLayout::IsClippedToBounds "); target.IsClippedToBounds <-  value
            | USome _, UNone -> target.IsClippedToBounds <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryPadding
            let valueOpt = source.TryPadding
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting RelativeLayout::Padding "); target.Padding <-  value
            | USome _, UNone -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting RelativeLayout::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting RelativeLayout::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting RelativeLayout::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting RelativeLayout::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting RelativeLayout::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting RelativeLayout::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting RelativeLayout::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting RelativeLayout::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting RelativeLayout::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting RelativeLayout::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting RelativeLayout::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting RelativeLayout::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting RelativeLayout::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting RelativeLayout::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting RelativeLayout::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting RelativeLayout::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting RelativeLayout::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting RelativeLayout::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting RelativeLayout::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting RelativeLayout::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting RelativeLayout::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting RelativeLayout::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting RelativeLayout::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.RelativeLayout>, create, update, Map.ofArray attribs)

    /// Describes a RowDefinition in the view
    static member RowDefinition(?height: obj) = 
        let attribs = [| 
            match height with None -> () | Some v -> yield ("RowDefinitionHeight", box (makeGridLength(v))) 
          |]

        let create () =
            box (new Xamarin.Forms.RowDefinition())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.RowDefinition)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRowDefinitionHeight
            let valueOpt = source.TryRowDefinitionHeight
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting RowDefinition::Height "); target.Height <-  value
            | USome _, UNone -> target.Height <- Xamarin.Forms.GridLength.Auto
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.RowDefinition>, create, update, Map.ofArray attribs)

    /// Describes a ColumnDefinition in the view
    static member ColumnDefinition(?width: obj) = 
        let attribs = [| 
            match width with None -> () | Some v -> yield ("ColumnDefinitionWidth", box (makeGridLength(v))) 
          |]

        let create () =
            box (new Xamarin.Forms.ColumnDefinition())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.ColumnDefinition)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryColumnDefinitionWidth
            let valueOpt = source.TryColumnDefinitionWidth
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ColumnDefinition::Width "); target.Width <-  value
            | USome _, UNone -> target.Width <- Xamarin.Forms.GridLength.Auto
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.ColumnDefinition>, create, update, Map.ofArray attribs)

    /// Describes a ContentView in the view
    static member ContentView(?content: XamlElement, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match content with None -> () | Some v -> yield ("Content", box ((v))) 
            match isClippedToBounds with None -> () | Some v -> yield ("IsClippedToBounds", box ((v))) 
            match padding with None -> () | Some v -> yield ("Padding", box (makeThickness(v))) 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.ContentView())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.ContentView)
            let prevChildOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryContent
            match prevChildOpt, source.TryContent with
            // For structured objects, dependsOn on reference equality
            | USome prevChild, USome newChild when System.Object.ReferenceEquals(prevChild, newChild) -> ()
            | USome prevChild, USome newChild when prevChild.TargetType = newChild.TargetType ->
                newChild.UpdateIncremental(prevChild, target.Content)
            | USome _, USome newChild
            | UNone, USome newChild ->
                target.Content <- newChild.CreateAsView()
            | USome _, UNone ->
                target.Content <- null;
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsClippedToBounds
            let valueOpt = source.TryIsClippedToBounds
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentView::IsClippedToBounds "); target.IsClippedToBounds <-  value
            | USome _, UNone -> target.IsClippedToBounds <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryPadding
            let valueOpt = source.TryPadding
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentView::Padding "); target.Padding <-  value
            | USome _, UNone -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentView::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentView::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentView::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentView::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentView::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentView::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentView::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentView::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentView::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentView::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentView::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentView::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentView::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentView::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentView::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentView::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentView::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentView::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentView::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentView::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentView::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentView::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentView::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.ContentView>, create, update, Map.ofArray attribs)

    /// Describes a TemplatedView in the view
    static member TemplatedView(?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match isClippedToBounds with None -> () | Some v -> yield ("IsClippedToBounds", box ((v))) 
            match padding with None -> () | Some v -> yield ("Padding", box (makeThickness(v))) 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.TemplatedView())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.TemplatedView)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsClippedToBounds
            let valueOpt = source.TryIsClippedToBounds
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TemplatedView::IsClippedToBounds "); target.IsClippedToBounds <-  value
            | USome _, UNone -> target.IsClippedToBounds <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryPadding
            let valueOpt = source.TryPadding
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TemplatedView::Padding "); target.Padding <-  value
            | USome _, UNone -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TemplatedView::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TemplatedView::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TemplatedView::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TemplatedView::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TemplatedView::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TemplatedView::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TemplatedView::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TemplatedView::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TemplatedView::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TemplatedView::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TemplatedView::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TemplatedView::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TemplatedView::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TemplatedView::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TemplatedView::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TemplatedView::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TemplatedView::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TemplatedView::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TemplatedView::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TemplatedView::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TemplatedView::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TemplatedView::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TemplatedView::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.TemplatedView>, create, update, Map.ofArray attribs)

    /// Describes a DatePicker in the view
    static member DatePicker(?date: System.DateTime, ?format: string, ?minimumDate: System.DateTime, ?maximumDate: System.DateTime, ?dateSelected: Xamarin.Forms.DateChangedEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match date with None -> () | Some v -> yield ("Date", box ((v))) 
            match format with None -> () | Some v -> yield ("Format", box ((v))) 
            match minimumDate with None -> () | Some v -> yield ("MinimumDate", box ((v))) 
            match maximumDate with None -> () | Some v -> yield ("MaximumDate", box ((v))) 
            match dateSelected with None -> () | Some v -> yield ("DateSelected", box ((fun f -> System.EventHandler<Xamarin.Forms.DateChangedEventArgs>(fun _sender args -> f args))(v))) 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.DatePicker())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.DatePicker)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryDate
            let valueOpt = source.TryDate
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::Date "); target.Date <-  value
            | USome _, UNone -> target.Date <- Unchecked.defaultof<System.DateTime>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryFormat
            let valueOpt = source.TryFormat
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::Format "); target.Format <-  value
            | USome _, UNone -> target.Format <- "d"
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumDate
            let valueOpt = source.TryMinimumDate
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::MinimumDate "); target.MinimumDate <-  value
            | USome _, UNone -> target.MinimumDate <- new System.DateTime(1900, 1, 1)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMaximumDate
            let valueOpt = source.TryMaximumDate
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::MaximumDate "); target.MaximumDate <-  value
            | USome _, UNone -> target.MaximumDate <- new System.DateTime(2100, 12, 31)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryDateSelected
            match prevValueOpt, source.TryDateSelected with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.DateSelected.RemoveHandler(prevValue); target.DateSelected.AddHandler(value)
            | UNone, USome value -> target.DateSelected.AddHandler(value)
            | USome prevValue, UNone -> target.DateSelected.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.DatePicker>, create, update, Map.ofArray attribs)

    /// Describes a Picker in the view
    static member Picker(?itemsSource: 'T list, ?selectedIndex: int, ?title: string, ?textColor: Xamarin.Forms.Color, ?selectedIndexChanged: (int * 'T option) -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match itemsSource with None -> () | Some v -> yield ("PickerItemsSource", box ((fun es -> es |> Array.ofList :> System.Collections.IList)(v))) 
            match selectedIndex with None -> () | Some v -> yield ("SelectedIndex", box ((v))) 
            match title with None -> () | Some v -> yield ("Title", box ((v))) 
            match textColor with None -> () | Some v -> yield ("TextColor", box ((v))) 
            match selectedIndexChanged with None -> () | Some v -> yield ("SelectedIndexChanged", box ((fun f -> System.EventHandler(fun sender args -> let picker = (sender :?> Xamarin.Forms.Picker) in f (picker.SelectedIndex, (picker.SelectedItem |> Option.ofObj |> Option.map unbox<'T>))))(v))) 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.Picker())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.Picker)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryPickerItemsSource
            let valueOpt = source.TryPickerItemsSource
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::ItemsSource "); target.ItemsSource <-  value
            | USome _, UNone -> target.ItemsSource <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TrySelectedIndex
            let valueOpt = source.TrySelectedIndex
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::SelectedIndex "); target.SelectedIndex <-  value
            | USome _, UNone -> target.SelectedIndex <- 0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTitle
            let valueOpt = source.TryTitle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::Title "); target.Title <-  value
            | USome _, UNone -> target.Title <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTextColor
            let valueOpt = source.TryTextColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::TextColor "); target.TextColor <-  value
            | USome _, UNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TrySelectedIndexChanged
            match prevValueOpt, source.TrySelectedIndexChanged with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.SelectedIndexChanged.RemoveHandler(prevValue); target.SelectedIndexChanged.AddHandler(value)
            | UNone, USome value -> target.SelectedIndexChanged.AddHandler(value)
            | USome prevValue, UNone -> target.SelectedIndexChanged.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Picker>, create, update, Map.ofArray attribs)

    /// Describes a Frame in the view
    static member Frame(?outlineColor: Xamarin.Forms.Color, ?cornerRadius: single, ?hasShadow: bool, ?content: XamlElement, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match outlineColor with None -> () | Some v -> yield ("OutlineColor", box ((v))) 
            match cornerRadius with None -> () | Some v -> yield ("FrameCornerRadius", box ((v))) 
            match hasShadow with None -> () | Some v -> yield ("HasShadow", box ((v))) 
            match content with None -> () | Some v -> yield ("Content", box ((v))) 
            match isClippedToBounds with None -> () | Some v -> yield ("IsClippedToBounds", box ((v))) 
            match padding with None -> () | Some v -> yield ("Padding", box (makeThickness(v))) 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.Frame())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.Frame)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOutlineColor
            let valueOpt = source.TryOutlineColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::OutlineColor "); target.OutlineColor <-  value
            | USome _, UNone -> target.OutlineColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryFrameCornerRadius
            let valueOpt = source.TryFrameCornerRadius
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::CornerRadius "); target.CornerRadius <-  value
            | USome _, UNone -> target.CornerRadius <- -1.0f
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHasShadow
            let valueOpt = source.TryHasShadow
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::HasShadow "); target.HasShadow <-  value
            | USome _, UNone -> target.HasShadow <- true
            | UNone, UNone -> ()
            let prevChildOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryContent
            match prevChildOpt, source.TryContent with
            // For structured objects, dependsOn on reference equality
            | USome prevChild, USome newChild when System.Object.ReferenceEquals(prevChild, newChild) -> ()
            | USome prevChild, USome newChild when prevChild.TargetType = newChild.TargetType ->
                newChild.UpdateIncremental(prevChild, target.Content)
            | USome _, USome newChild
            | UNone, USome newChild ->
                target.Content <- newChild.CreateAsView()
            | USome _, UNone ->
                target.Content <- null;
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsClippedToBounds
            let valueOpt = source.TryIsClippedToBounds
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::IsClippedToBounds "); target.IsClippedToBounds <-  value
            | USome _, UNone -> target.IsClippedToBounds <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryPadding
            let valueOpt = source.TryPadding
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::Padding "); target.Padding <-  value
            | USome _, UNone -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Frame>, create, update, Map.ofArray attribs)

    /// Describes a Image in the view
    static member Image(?source: string, ?aspect: Xamarin.Forms.Aspect, ?isOpaque: bool, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match source with None -> () | Some v -> yield ("ImageSource", box ((v))) 
            match aspect with None -> () | Some v -> yield ("Aspect", box ((v))) 
            match isOpaque with None -> () | Some v -> yield ("IsOpaque", box ((v))) 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.Image())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.Image)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryImageSource
            let valueOpt = source.TryImageSource
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Image::Source "); target.Source <- makeImageSource  value
            | USome _, UNone -> target.Source <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAspect
            let valueOpt = source.TryAspect
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Image::Aspect "); target.Aspect <-  value
            | USome _, UNone -> target.Aspect <- Xamarin.Forms.Aspect.AspectFit
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsOpaque
            let valueOpt = source.TryIsOpaque
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Image::IsOpaque "); target.IsOpaque <-  value
            | USome _, UNone -> target.IsOpaque <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Image::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Image::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Image::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Image::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Image::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Image::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Image::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Image::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Image::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Image::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Image::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Image::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Image::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Image::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Image::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Image::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Image::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Image::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Image::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Image::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Image::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Image::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Image::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Image>, create, update, Map.ofArray attribs)

    /// Describes a InputView in the view
    static member InputView(?keyboard: Xamarin.Forms.Keyboard, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match keyboard with None -> () | Some v -> yield ("Keyboard", box ((v))) 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.InputView"

        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.InputView)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryKeyboard
            let valueOpt = source.TryKeyboard
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting InputView::Keyboard "); target.Keyboard <-  value
            | USome _, UNone -> target.Keyboard <- Xamarin.Forms.Keyboard.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting InputView::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting InputView::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting InputView::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting InputView::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting InputView::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting InputView::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting InputView::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting InputView::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting InputView::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting InputView::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting InputView::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting InputView::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting InputView::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting InputView::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting InputView::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting InputView::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting InputView::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting InputView::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting InputView::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting InputView::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting InputView::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting InputView::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting InputView::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.InputView>, create, update, Map.ofArray attribs)

    /// Describes a Editor in the view
    static member Editor(?text: string, ?fontSize: obj, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?textColor: Xamarin.Forms.Color, ?completed: string -> unit, ?textChanged: Xamarin.Forms.TextChangedEventArgs -> unit, ?keyboard: Xamarin.Forms.Keyboard, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match text with None -> () | Some v -> yield ("Text", box ((v))) 
            match fontSize with None -> () | Some v -> yield ("FontSize", box (makeFontSize(v))) 
            match fontFamily with None -> () | Some v -> yield ("FontFamily", box ((v))) 
            match fontAttributes with None -> () | Some v -> yield ("FontAttributes", box ((v))) 
            match textColor with None -> () | Some v -> yield ("TextColor", box ((v))) 
            match completed with None -> () | Some v -> yield ("EditorCompleted", box ((fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.Editor).Text))(v))) 
            match textChanged with None -> () | Some v -> yield ("TextChanged", box ((fun f -> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>(fun _sender args -> f args))(v))) 
            match keyboard with None -> () | Some v -> yield ("Keyboard", box ((v))) 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.Editor())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.Editor)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryText
            let valueOpt = source.TryText
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::Text "); target.Text <-  value
            | USome _, UNone -> target.Text <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryFontSize
            let valueOpt = source.TryFontSize
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::FontSize "); target.FontSize <-  value
            | USome _, UNone -> target.FontSize <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryFontFamily
            let valueOpt = source.TryFontFamily
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::FontFamily "); target.FontFamily <-  value
            | USome _, UNone -> target.FontFamily <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryFontAttributes
            let valueOpt = source.TryFontAttributes
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::FontAttributes "); target.FontAttributes <-  value
            | USome _, UNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTextColor
            let valueOpt = source.TryTextColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::TextColor "); target.TextColor <-  value
            | USome _, UNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryEditorCompleted
            match prevValueOpt, source.TryEditorCompleted with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.Completed.RemoveHandler(prevValue); target.Completed.AddHandler(value)
            | UNone, USome value -> target.Completed.AddHandler(value)
            | USome prevValue, UNone -> target.Completed.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTextChanged
            match prevValueOpt, source.TryTextChanged with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.TextChanged.RemoveHandler(prevValue); target.TextChanged.AddHandler(value)
            | UNone, USome value -> target.TextChanged.AddHandler(value)
            | USome prevValue, UNone -> target.TextChanged.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryKeyboard
            let valueOpt = source.TryKeyboard
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::Keyboard "); target.Keyboard <-  value
            | USome _, UNone -> target.Keyboard <- Xamarin.Forms.Keyboard.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Editor>, create, update, Map.ofArray attribs)

    /// Describes a Entry in the view
    static member Entry(?text: string, ?placeholder: string, ?horizontalTextAlignment: Xamarin.Forms.TextAlignment, ?fontSize: obj, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?textColor: Xamarin.Forms.Color, ?placeholderColor: Xamarin.Forms.Color, ?isPassword: bool, ?completed: string -> unit, ?textChanged: Xamarin.Forms.TextChangedEventArgs -> unit, ?keyboard: Xamarin.Forms.Keyboard, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
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
            match keyboard with None -> () | Some v -> yield ("Keyboard", box ((v))) 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.Entry())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.Entry)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryText
            let valueOpt = source.TryText
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::Text "); target.Text <-  value
            | USome _, UNone -> target.Text <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryPlaceholder
            let valueOpt = source.TryPlaceholder
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::Placeholder "); target.Placeholder <-  value
            | USome _, UNone -> target.Placeholder <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalTextAlignment
            let valueOpt = source.TryHorizontalTextAlignment
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::HorizontalTextAlignment "); target.HorizontalTextAlignment <-  value
            | USome _, UNone -> target.HorizontalTextAlignment <- Xamarin.Forms.TextAlignment.Start
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryFontSize
            let valueOpt = source.TryFontSize
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::FontSize "); target.FontSize <-  value
            | USome _, UNone -> target.FontSize <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryFontFamily
            let valueOpt = source.TryFontFamily
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::FontFamily "); target.FontFamily <-  value
            | USome _, UNone -> target.FontFamily <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryFontAttributes
            let valueOpt = source.TryFontAttributes
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::FontAttributes "); target.FontAttributes <-  value
            | USome _, UNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTextColor
            let valueOpt = source.TryTextColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::TextColor "); target.TextColor <-  value
            | USome _, UNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryPlaceholderColor
            let valueOpt = source.TryPlaceholderColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::PlaceholderColor "); target.PlaceholderColor <-  value
            | USome _, UNone -> target.PlaceholderColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsPassword
            let valueOpt = source.TryIsPassword
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::IsPassword "); target.IsPassword <-  value
            | USome _, UNone -> target.IsPassword <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryEntryCompleted
            match prevValueOpt, source.TryEntryCompleted with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.Completed.RemoveHandler(prevValue); target.Completed.AddHandler(value)
            | UNone, USome value -> target.Completed.AddHandler(value)
            | USome prevValue, UNone -> target.Completed.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTextChanged
            match prevValueOpt, source.TryTextChanged with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.TextChanged.RemoveHandler(prevValue); target.TextChanged.AddHandler(value)
            | UNone, USome value -> target.TextChanged.AddHandler(value)
            | USome prevValue, UNone -> target.TextChanged.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryKeyboard
            let valueOpt = source.TryKeyboard
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::Keyboard "); target.Keyboard <-  value
            | USome _, UNone -> target.Keyboard <- Xamarin.Forms.Keyboard.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Entry>, create, update, Map.ofArray attribs)

    /// Describes a EntryCell in the view
    static member EntryCell(?label: string, ?text: string, ?keyboard: Xamarin.Forms.Keyboard, ?placeholder: string, ?horizontalTextAlignment: Xamarin.Forms.TextAlignment, ?completed: string -> unit, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match label with None -> () | Some v -> yield ("Label", box ((v))) 
            match text with None -> () | Some v -> yield ("Text", box ((v))) 
            match keyboard with None -> () | Some v -> yield ("Keyboard", box ((v))) 
            match placeholder with None -> () | Some v -> yield ("Placeholder", box ((v))) 
            match horizontalTextAlignment with None -> () | Some v -> yield ("HorizontalTextAlignment", box ((v))) 
            match completed with None -> () | Some v -> yield ("EntryCompleted", box ((fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.EntryCell).Text))(v))) 
            match height with None -> () | Some v -> yield ("Height", box ((v))) 
            match isEnabled with None -> () | Some v -> yield ("IsEnabled", box ((v))) 
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.EntryCell())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.EntryCell)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryLabel
            let valueOpt = source.TryLabel
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting EntryCell::Label "); target.Label <-  value
            | USome _, UNone -> target.Label <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryText
            let valueOpt = source.TryText
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting EntryCell::Text "); target.Text <-  value
            | USome _, UNone -> target.Text <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryKeyboard
            let valueOpt = source.TryKeyboard
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting EntryCell::Keyboard "); target.Keyboard <-  value
            | USome _, UNone -> target.Keyboard <- Xamarin.Forms.Keyboard.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryPlaceholder
            let valueOpt = source.TryPlaceholder
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting EntryCell::Placeholder "); target.Placeholder <-  value
            | USome _, UNone -> target.Placeholder <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalTextAlignment
            let valueOpt = source.TryHorizontalTextAlignment
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting EntryCell::HorizontalTextAlignment "); target.HorizontalTextAlignment <-  value
            | USome _, UNone -> target.HorizontalTextAlignment <- Xamarin.Forms.TextAlignment.Start
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryEntryCompleted
            match prevValueOpt, source.TryEntryCompleted with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.Completed.RemoveHandler(prevValue); target.Completed.AddHandler(value)
            | UNone, USome value -> target.Completed.AddHandler(value)
            | USome prevValue, UNone -> target.Completed.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeight
            let valueOpt = source.TryHeight
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting EntryCell::Height "); target.Height <-  value
            | USome _, UNone -> target.Height <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting EntryCell::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting EntryCell::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting EntryCell::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.EntryCell>, create, update, Map.ofArray attribs)

    /// Describes a Label in the view
    static member Label(?text: string, ?horizontalTextAlignment: Xamarin.Forms.TextAlignment, ?verticalTextAlignment: Xamarin.Forms.TextAlignment, ?fontSize: obj, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?textColor: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match text with None -> () | Some v -> yield ("Text", box ((v))) 
            match horizontalTextAlignment with None -> () | Some v -> yield ("HorizontalTextAlignment", box ((v))) 
            match verticalTextAlignment with None -> () | Some v -> yield ("VerticalTextAlignment", box ((v))) 
            match fontSize with None -> () | Some v -> yield ("FontSize", box (makeFontSize(v))) 
            match fontFamily with None -> () | Some v -> yield ("FontFamily", box ((v))) 
            match fontAttributes with None -> () | Some v -> yield ("FontAttributes", box ((v))) 
            match textColor with None -> () | Some v -> yield ("TextColor", box ((v))) 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.Label())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.Label)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryText
            let valueOpt = source.TryText
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::Text "); target.Text <-  value
            | USome _, UNone -> target.Text <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalTextAlignment
            let valueOpt = source.TryHorizontalTextAlignment
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::HorizontalTextAlignment "); target.HorizontalTextAlignment <-  value
            | USome _, UNone -> target.HorizontalTextAlignment <- Xamarin.Forms.TextAlignment.Start
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalTextAlignment
            let valueOpt = source.TryVerticalTextAlignment
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::VerticalTextAlignment "); target.VerticalTextAlignment <-  value
            | USome _, UNone -> target.VerticalTextAlignment <- Xamarin.Forms.TextAlignment.Start
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryFontSize
            let valueOpt = source.TryFontSize
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::FontSize "); target.FontSize <-  value
            | USome _, UNone -> target.FontSize <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryFontFamily
            let valueOpt = source.TryFontFamily
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::FontFamily "); target.FontFamily <-  value
            | USome _, UNone -> target.FontFamily <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryFontAttributes
            let valueOpt = source.TryFontAttributes
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::FontAttributes "); target.FontAttributes <-  value
            | USome _, UNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTextColor
            let valueOpt = source.TryTextColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::TextColor "); target.TextColor <-  value
            | USome _, UNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Label::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Label>, create, update, Map.ofArray attribs)

    /// Describes a Layout in the view
    static member Layout(?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match isClippedToBounds with None -> () | Some v -> yield ("IsClippedToBounds", box ((v))) 
            match padding with None -> () | Some v -> yield ("Padding", box (makeThickness(v))) 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.Layout"

        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.Layout)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsClippedToBounds
            let valueOpt = source.TryIsClippedToBounds
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Layout::IsClippedToBounds "); target.IsClippedToBounds <-  value
            | USome _, UNone -> target.IsClippedToBounds <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryPadding
            let valueOpt = source.TryPadding
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Layout::Padding "); target.Padding <-  value
            | USome _, UNone -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Layout::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Layout::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Layout::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Layout::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Layout::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Layout::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Layout::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Layout::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Layout::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Layout::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Layout::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Layout::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Layout::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Layout::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Layout::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Layout::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Layout::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Layout::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Layout::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Layout::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Layout::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Layout::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Layout::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Layout>, create, update, Map.ofArray attribs)

    /// Describes a StackLayout in the view
    static member StackLayout(?children: XamlElement list, ?orientation: Xamarin.Forms.StackOrientation, ?spacing: double, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match children with None -> () | Some v -> yield ("Children", box (Array.ofList(v))) 
            match orientation with None -> () | Some v -> yield ("StackOrientation", box ((v))) 
            match spacing with None -> () | Some v -> yield ("Spacing", box ((v))) 
            match isClippedToBounds with None -> () | Some v -> yield ("IsClippedToBounds", box ((v))) 
            match padding with None -> () | Some v -> yield ("Padding", box (makeThickness(v))) 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.StackLayout())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.StackLayout)
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryChildren
            let collOpt = source.TryChildren
            updateIList prevCollOpt collOpt target.Children
                (fun (x:XamlElement) -> x.CreateAsView())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStackOrientation
            let valueOpt = source.TryStackOrientation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::Orientation "); target.Orientation <-  value
            | USome _, UNone -> target.Orientation <- Xamarin.Forms.StackOrientation.Vertical
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TrySpacing
            let valueOpt = source.TrySpacing
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::Spacing "); target.Spacing <-  value
            | USome _, UNone -> target.Spacing <- 6.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsClippedToBounds
            let valueOpt = source.TryIsClippedToBounds
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::IsClippedToBounds "); target.IsClippedToBounds <-  value
            | USome _, UNone -> target.IsClippedToBounds <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryPadding
            let valueOpt = source.TryPadding
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::Padding "); target.Padding <-  value
            | USome _, UNone -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.StackLayout>, create, update, Map.ofArray attribs)

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
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.Span)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryFontFamily
            let valueOpt = source.TryFontFamily
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Span::FontFamily "); target.FontFamily <-  value
            | USome _, UNone -> target.FontFamily <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryFontAttributes
            let valueOpt = source.TryFontAttributes
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Span::FontAttributes "); target.FontAttributes <-  value
            | USome _, UNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryFontSize
            let valueOpt = source.TryFontSize
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Span::FontSize "); target.FontSize <-  value
            | USome _, UNone -> target.FontSize <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Span::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryForegroundColor
            let valueOpt = source.TryForegroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Span::ForegroundColor "); target.ForegroundColor <-  value
            | USome _, UNone -> target.ForegroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryText
            let valueOpt = source.TryText
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Span::Text "); target.Text <-  value
            | USome _, UNone -> target.Text <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryPropertyChanged
            match prevValueOpt, source.TryPropertyChanged with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.PropertyChanged.RemoveHandler(prevValue); target.PropertyChanged.AddHandler(value)
            | UNone, USome value -> target.PropertyChanged.AddHandler(value)
            | USome prevValue, UNone -> target.PropertyChanged.RemoveHandler(prevValue)
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Span>, create, update, Map.ofArray attribs)

    /// Describes a TimePicker in the view
    static member TimePicker(?time: System.TimeSpan, ?format: string, ?textColor: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match time with None -> () | Some v -> yield ("Time", box ((v))) 
            match format with None -> () | Some v -> yield ("Format", box ((v))) 
            match textColor with None -> () | Some v -> yield ("TextColor", box ((v))) 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.TimePicker())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.TimePicker)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTime
            let valueOpt = source.TryTime
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::Time "); target.Time <-  value
            | USome _, UNone -> target.Time <- new System.TimeSpan()
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryFormat
            let valueOpt = source.TryFormat
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::Format "); target.Format <-  value
            | USome _, UNone -> target.Format <- "t"
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTextColor
            let valueOpt = source.TryTextColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::TextColor "); target.TextColor <-  value
            | USome _, UNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.TimePicker>, create, update, Map.ofArray attribs)

    /// Describes a WebView in the view
    static member WebView(?source: Xamarin.Forms.WebViewSource, ?navigated: Xamarin.Forms.WebNavigatedEventArgs -> unit, ?navigating: Xamarin.Forms.WebNavigatingEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match source with None -> () | Some v -> yield ("WebSource", box ((v))) 
            match navigated with None -> () | Some v -> yield ("Navigated", box ((fun f -> System.EventHandler<Xamarin.Forms.WebNavigatedEventArgs>(fun _sender args -> f args))(v))) 
            match navigating with None -> () | Some v -> yield ("Navigating", box ((fun f -> System.EventHandler<Xamarin.Forms.WebNavigatingEventArgs>(fun _sender args -> f args))(v))) 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.WebView())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.WebView)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWebSource
            let valueOpt = source.TryWebSource
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting WebView::Source "); target.Source <-  value
            | USome _, UNone -> target.Source <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryNavigated
            match prevValueOpt, source.TryNavigated with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.Navigated.RemoveHandler(prevValue); target.Navigated.AddHandler(value)
            | UNone, USome value -> target.Navigated.AddHandler(value)
            | USome prevValue, UNone -> target.Navigated.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryNavigating
            match prevValueOpt, source.TryNavigating with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.Navigating.RemoveHandler(prevValue); target.Navigating.AddHandler(value)
            | UNone, USome value -> target.Navigating.AddHandler(value)
            | USome prevValue, UNone -> target.Navigating.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting WebView::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting WebView::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting WebView::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting WebView::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting WebView::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting WebView::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting WebView::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting WebView::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting WebView::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting WebView::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting WebView::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting WebView::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting WebView::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting WebView::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting WebView::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting WebView::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting WebView::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting WebView::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting WebView::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting WebView::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting WebView::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting WebView::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting WebView::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.WebView>, create, update, Map.ofArray attribs)

    /// Describes a Page in the view
    static member Page(?title: string, ?padding: obj, ?useSafeArea: bool, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match title with None -> () | Some v -> yield ("Title", box ((v))) 
            match padding with None -> () | Some v -> yield ("Padding", box (makeThickness(v))) 
            match useSafeArea with None -> () | Some v -> yield ("UseSafeArea", box ((v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.Page())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.Page)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTitle
            let valueOpt = source.TryTitle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Page::Title "); target.Title <-  value
            | USome _, UNone -> target.Title <- ""
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryPadding
            let valueOpt = source.TryPadding
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Page::Padding "); target.Padding <-  value
            | USome _, UNone -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryUseSafeArea
            let valueOpt = source.TryUseSafeArea
            (fun _ _ target -> Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea((target :> Xamarin.Forms.Page).On<Xamarin.Forms.PlatformConfiguration.iOS>(), true) |> ignore) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Page::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Page::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Page::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Page::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Page::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Page::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Page::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Page::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Page::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Page::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Page::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Page::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Page::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Page::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Page::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Page::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Page::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Page::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Page::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Page::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Page>, create, update, Map.ofArray attribs)

    /// Describes a CarouselPage in the view
    static member CarouselPage(?children: XamlElement list, ?itemsSource: 'T list, ?itemTemplate: Xamarin.Forms.DataTemplate, ?selectedItem: System.Object, ?currentPage: XamlElement, ?currentPageChanged: 'T option -> unit, ?title: string, ?padding: obj, ?useSafeArea: bool, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match children with None -> () | Some v -> yield ("Children", box (Array.ofList(v))) 
            match itemsSource with None -> () | Some v -> yield ("ItemsSource", box ((fun es -> es |> Array.ofList |> Array.map box :> System.Collections.Generic.IList<obj>)(v))) 
            match itemTemplate with None -> () | Some v -> yield ("ItemTemplate", box ((v))) 
            match selectedItem with None -> () | Some v -> yield ("CarouselPage_SelectedItem", box ((v))) 
            match currentPage with None -> () | Some v -> yield ("CurrentPage", box ((v))) 
            match currentPageChanged with None -> () | Some v -> yield ("CurrentPageChanged", box ((fun f -> System.EventHandler(fun sender args -> f ((sender :?> Xamarin.Forms.CarouselPage).SelectedItem |> Option.ofObj |> Option.map unbox<'T>)))(v))) 
            match title with None -> () | Some v -> yield ("Title", box ((v))) 
            match padding with None -> () | Some v -> yield ("Padding", box (makeThickness(v))) 
            match useSafeArea with None -> () | Some v -> yield ("UseSafeArea", box ((v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.CarouselPage())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.CarouselPage)
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryChildren
            let collOpt = source.TryChildren
            updateIList prevCollOpt collOpt target.Children
                (fun (x:XamlElement) -> x.CreateAsContentPage())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryItemsSource
            let valueOpt = source.TryItemsSource
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting CarouselPage::ItemsSource "); target.ItemsSource <-  value
            | USome _, UNone -> target.ItemsSource <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryItemTemplate
            let valueOpt = source.TryItemTemplate
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting CarouselPage::ItemTemplate "); target.ItemTemplate <-  value
            | USome _, UNone -> target.ItemTemplate <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryCarouselPage_SelectedItem
            let valueOpt = source.TryCarouselPage_SelectedItem
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting CarouselPage::SelectedItem "); target.SelectedItem <-  value
            | USome _, UNone -> target.SelectedItem <- null
            | UNone, UNone -> ()
            let prevChildOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryCurrentPage
            match prevChildOpt, source.TryCurrentPage with
            // For structured objects, dependsOn on reference equality
            | USome prevChild, USome newChild when System.Object.ReferenceEquals(prevChild, newChild) -> ()
            | USome prevChild, USome newChild when prevChild.TargetType = newChild.TargetType ->
                newChild.UpdateIncremental(prevChild, target.CurrentPage)
            | USome _, USome newChild
            | UNone, USome newChild ->
                target.CurrentPage <- newChild.CreateAsContentPage()
            | USome _, UNone ->
                target.CurrentPage <- null;
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryCurrentPageChanged
            match prevValueOpt, source.TryCurrentPageChanged with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.CurrentPageChanged.RemoveHandler(prevValue); target.CurrentPageChanged.AddHandler(value)
            | UNone, USome value -> target.CurrentPageChanged.AddHandler(value)
            | USome prevValue, UNone -> target.CurrentPageChanged.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTitle
            let valueOpt = source.TryTitle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting CarouselPage::Title "); target.Title <-  value
            | USome _, UNone -> target.Title <- ""
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryPadding
            let valueOpt = source.TryPadding
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting CarouselPage::Padding "); target.Padding <-  value
            | USome _, UNone -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryUseSafeArea
            let valueOpt = source.TryUseSafeArea
            (fun _ _ target -> Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea((target :> Xamarin.Forms.Page).On<Xamarin.Forms.PlatformConfiguration.iOS>(), true) |> ignore) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting CarouselPage::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting CarouselPage::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting CarouselPage::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting CarouselPage::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting CarouselPage::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting CarouselPage::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting CarouselPage::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting CarouselPage::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting CarouselPage::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting CarouselPage::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting CarouselPage::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting CarouselPage::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting CarouselPage::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting CarouselPage::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting CarouselPage::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting CarouselPage::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting CarouselPage::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting CarouselPage::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting CarouselPage::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting CarouselPage::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.CarouselPage>, create, update, Map.ofArray attribs)

    /// Describes a NavigationPage in the view
    static member NavigationPage(?pages: XamlElement list, ?barBackgroundColor: Xamarin.Forms.Color, ?barTextColor: Xamarin.Forms.Color, ?popped: Xamarin.Forms.NavigationEventArgs -> unit, ?poppedToRoot: Xamarin.Forms.NavigationEventArgs -> unit, ?pushed: Xamarin.Forms.NavigationEventArgs -> unit, ?title: string, ?padding: obj, ?useSafeArea: bool, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match pages with None -> () | Some v -> yield ("NavigationPagePages", box (Array.ofList(v))) 
            match barBackgroundColor with None -> () | Some v -> yield ("BarBackgroundColor", box ((v))) 
            match barTextColor with None -> () | Some v -> yield ("BarTextColor", box ((v))) 
            match popped with None -> () | Some v -> yield ("Popped", box ((fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(v))) 
            match poppedToRoot with None -> () | Some v -> yield ("PoppedToRoot", box ((fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(v))) 
            match pushed with None -> () | Some v -> yield ("Pushed", box ((fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(v))) 
            match title with None -> () | Some v -> yield ("Title", box ((v))) 
            match padding with None -> () | Some v -> yield ("Padding", box (makeThickness(v))) 
            match useSafeArea with None -> () | Some v -> yield ("UseSafeArea", box ((v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.NavigationPage())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.NavigationPage)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryNavigationPagePages
            let valueOpt = source.TryNavigationPagePages
            updateNavigationPages prevValueOpt valueOpt target
                (fun prevChildOpt newChild targetChild -> 
                    // Adjust the attached properties
                    match (match prevChildOpt with UNone -> UNone | USome prevChild -> prevChild.TryBackButtonTitle), newChild.TryBackButtonTitle with
                    | USome prev, USome v when prev = v -> ()
                    | prevOpt, USome value -> Xamarin.Forms.NavigationPage.SetBackButtonTitle(targetChild, value)
                    | USome _, UNone -> Xamarin.Forms.NavigationPage.SetBackButtonTitle(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    match (match prevChildOpt with UNone -> UNone | USome prevChild -> prevChild.TryHasBackButton), newChild.TryHasBackButton with
                    | USome prev, USome v when prev = v -> ()
                    | prevOpt, USome value -> Xamarin.Forms.NavigationPage.SetHasBackButton(targetChild, value)
                    | USome _, UNone -> Xamarin.Forms.NavigationPage.SetHasBackButton(targetChild, true) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    match (match prevChildOpt with UNone -> UNone | USome prevChild -> prevChild.TryHasNavigationBar), newChild.TryHasNavigationBar with
                    | USome prev, USome v when prev = v -> ()
                    | prevOpt, USome value -> Xamarin.Forms.NavigationPage.SetHasNavigationBar(targetChild, value)
                    | USome _, UNone -> Xamarin.Forms.NavigationPage.SetHasNavigationBar(targetChild, true) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    match (match prevChildOpt with UNone -> UNone | USome prevChild -> prevChild.TryTitleIcon), newChild.TryTitleIcon with
                    | USome prev, USome v when prev = v -> ()
                    | prevOpt, USome value -> Xamarin.Forms.NavigationPage.SetTitleIcon(targetChild, makeFileImageSource value)
                    | USome _, UNone -> Xamarin.Forms.NavigationPage.SetTitleIcon(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    ())
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBarBackgroundColor
            let valueOpt = source.TryBarBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting NavigationPage::BarBackgroundColor "); target.BarBackgroundColor <-  value
            | USome _, UNone -> target.BarBackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBarTextColor
            let valueOpt = source.TryBarTextColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting NavigationPage::BarTextColor "); target.BarTextColor <-  value
            | USome _, UNone -> target.BarTextColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryPopped
            match prevValueOpt, source.TryPopped with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.Popped.RemoveHandler(prevValue); target.Popped.AddHandler(value)
            | UNone, USome value -> target.Popped.AddHandler(value)
            | USome prevValue, UNone -> target.Popped.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryPoppedToRoot
            match prevValueOpt, source.TryPoppedToRoot with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.PoppedToRoot.RemoveHandler(prevValue); target.PoppedToRoot.AddHandler(value)
            | UNone, USome value -> target.PoppedToRoot.AddHandler(value)
            | USome prevValue, UNone -> target.PoppedToRoot.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryPushed
            match prevValueOpt, source.TryPushed with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.Pushed.RemoveHandler(prevValue); target.Pushed.AddHandler(value)
            | UNone, USome value -> target.Pushed.AddHandler(value)
            | USome prevValue, UNone -> target.Pushed.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTitle
            let valueOpt = source.TryTitle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting NavigationPage::Title "); target.Title <-  value
            | USome _, UNone -> target.Title <- ""
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryPadding
            let valueOpt = source.TryPadding
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting NavigationPage::Padding "); target.Padding <-  value
            | USome _, UNone -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryUseSafeArea
            let valueOpt = source.TryUseSafeArea
            (fun _ _ target -> Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea((target :> Xamarin.Forms.Page).On<Xamarin.Forms.PlatformConfiguration.iOS>(), true) |> ignore) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting NavigationPage::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting NavigationPage::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting NavigationPage::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting NavigationPage::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting NavigationPage::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting NavigationPage::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting NavigationPage::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting NavigationPage::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting NavigationPage::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting NavigationPage::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting NavigationPage::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting NavigationPage::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting NavigationPage::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting NavigationPage::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting NavigationPage::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting NavigationPage::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting NavigationPage::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting NavigationPage::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting NavigationPage::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting NavigationPage::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.NavigationPage>, create, update, Map.ofArray attribs)

    /// Describes a TabbedPage in the view
    static member TabbedPage(?children: XamlElement list, ?barBackgroundColor: Xamarin.Forms.Color, ?barTextColor: Xamarin.Forms.Color, ?title: string, ?padding: obj, ?useSafeArea: bool, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match children with None -> () | Some v -> yield ("Children", box (Array.ofList(v))) 
            match barBackgroundColor with None -> () | Some v -> yield ("BarBackgroundColor", box ((v))) 
            match barTextColor with None -> () | Some v -> yield ("BarTextColor", box ((v))) 
            match title with None -> () | Some v -> yield ("Title", box ((v))) 
            match padding with None -> () | Some v -> yield ("Padding", box (makeThickness(v))) 
            match useSafeArea with None -> () | Some v -> yield ("UseSafeArea", box ((v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.TabbedPage())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.TabbedPage)
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryChildren
            let collOpt = source.TryChildren
            updateIList prevCollOpt collOpt target.Children
                (fun (x:XamlElement) -> x.CreateAsPage())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBarBackgroundColor
            let valueOpt = source.TryBarBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TabbedPage::BarBackgroundColor "); target.BarBackgroundColor <-  value
            | USome _, UNone -> target.BarBackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBarTextColor
            let valueOpt = source.TryBarTextColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TabbedPage::BarTextColor "); target.BarTextColor <-  value
            | USome _, UNone -> target.BarTextColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTitle
            let valueOpt = source.TryTitle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TabbedPage::Title "); target.Title <-  value
            | USome _, UNone -> target.Title <- ""
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryPadding
            let valueOpt = source.TryPadding
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TabbedPage::Padding "); target.Padding <-  value
            | USome _, UNone -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryUseSafeArea
            let valueOpt = source.TryUseSafeArea
            (fun _ _ target -> Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea((target :> Xamarin.Forms.Page).On<Xamarin.Forms.PlatformConfiguration.iOS>(), true) |> ignore) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TabbedPage::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TabbedPage::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TabbedPage::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TabbedPage::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TabbedPage::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TabbedPage::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TabbedPage::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TabbedPage::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TabbedPage::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TabbedPage::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TabbedPage::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TabbedPage::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TabbedPage::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TabbedPage::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TabbedPage::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TabbedPage::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TabbedPage::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TabbedPage::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TabbedPage::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TabbedPage::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.TabbedPage>, create, update, Map.ofArray attribs)

    /// Describes a ContentPage in the view
    static member ContentPage(?content: XamlElement, ?onSizeAllocated: (double * double) -> unit, ?title: string, ?padding: obj, ?useSafeArea: bool, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match content with None -> () | Some v -> yield ("Content", box ((v))) 
            match onSizeAllocated with None -> () | Some v -> yield ("OnSizeAllocatedCallback", box ((fun f -> FSharp.Control.Handler<_>(fun _sender args -> f args))(v))) 
            match title with None -> () | Some v -> yield ("Title", box ((v))) 
            match padding with None -> () | Some v -> yield ("Padding", box (makeThickness(v))) 
            match useSafeArea with None -> () | Some v -> yield ("UseSafeArea", box ((v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Elmish.XamarinForms.DynamicViews.CustomContentPage())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.ContentPage)
            let prevChildOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryContent
            match prevChildOpt, source.TryContent with
            // For structured objects, dependsOn on reference equality
            | USome prevChild, USome newChild when System.Object.ReferenceEquals(prevChild, newChild) -> ()
            | USome prevChild, USome newChild when prevChild.TargetType = newChild.TargetType ->
                newChild.UpdateIncremental(prevChild, target.Content)
            | USome _, USome newChild
            | UNone, USome newChild ->
                target.Content <- newChild.CreateAsView()
            | USome _, UNone ->
                target.Content <- null;
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOnSizeAllocatedCallback
            let valueOpt = source.TryOnSizeAllocatedCallback
            updateOnSizeAllocated prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTitle
            let valueOpt = source.TryTitle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentPage::Title "); target.Title <-  value
            | USome _, UNone -> target.Title <- ""
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryPadding
            let valueOpt = source.TryPadding
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentPage::Padding "); target.Padding <-  value
            | USome _, UNone -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryUseSafeArea
            let valueOpt = source.TryUseSafeArea
            (fun _ _ target -> Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea((target :> Xamarin.Forms.Page).On<Xamarin.Forms.PlatformConfiguration.iOS>(), true) |> ignore) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentPage::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentPage::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentPage::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentPage::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentPage::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentPage::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentPage::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentPage::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentPage::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentPage::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentPage::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentPage::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentPage::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentPage::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentPage::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentPage::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentPage::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentPage::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentPage::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ContentPage::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.ContentPage>, create, update, Map.ofArray attribs)

    /// Describes a MasterDetailPage in the view
    static member MasterDetailPage(?master: XamlElement, ?detail: XamlElement, ?isGestureEnabled: bool, ?isPresented: bool, ?masterBehavior: Xamarin.Forms.MasterBehavior, ?isPresentedChanged: bool -> unit, ?title: string, ?padding: obj, ?useSafeArea: bool, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match master with None -> () | Some v -> yield ("Master", box ((v))) 
            match detail with None -> () | Some v -> yield ("Detail", box ((v))) 
            match isGestureEnabled with None -> () | Some v -> yield ("IsGestureEnabled", box ((v))) 
            match isPresented with None -> () | Some v -> yield ("IsPresented", box ((v))) 
            match masterBehavior with None -> () | Some v -> yield ("MasterBehavior", box ((v))) 
            match isPresentedChanged with None -> () | Some v -> yield ("IsPresentedChanged", box ((fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.MasterDetailPage).IsPresented))(v))) 
            match title with None -> () | Some v -> yield ("Title", box ((v))) 
            match padding with None -> () | Some v -> yield ("Padding", box (makeThickness(v))) 
            match useSafeArea with None -> () | Some v -> yield ("UseSafeArea", box ((v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.MasterDetailPage())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.MasterDetailPage)
            let prevChildOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMaster
            match prevChildOpt, source.TryMaster with
            // For structured objects, dependsOn on reference equality
            | USome prevChild, USome newChild when System.Object.ReferenceEquals(prevChild, newChild) -> ()
            | USome prevChild, USome newChild when prevChild.TargetType = newChild.TargetType ->
                newChild.UpdateIncremental(prevChild, target.Master)
            | USome _, USome newChild
            | UNone, USome newChild ->
                target.Master <- newChild.CreateAsPage()
            | USome _, UNone ->
                target.Master <- null;
            | UNone, UNone -> ()
            let prevChildOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryDetail
            match prevChildOpt, source.TryDetail with
            // For structured objects, dependsOn on reference equality
            | USome prevChild, USome newChild when System.Object.ReferenceEquals(prevChild, newChild) -> ()
            | USome prevChild, USome newChild when prevChild.TargetType = newChild.TargetType ->
                newChild.UpdateIncremental(prevChild, target.Detail)
            | USome _, USome newChild
            | UNone, USome newChild ->
                target.Detail <- newChild.CreateAsPage()
            | USome _, UNone ->
                target.Detail <- null;
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsGestureEnabled
            let valueOpt = source.TryIsGestureEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::IsGestureEnabled "); target.IsGestureEnabled <-  value
            | USome _, UNone -> target.IsGestureEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsPresented
            let valueOpt = source.TryIsPresented
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::IsPresented "); target.IsPresented <-  value
            | USome _, UNone -> target.IsPresented <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMasterBehavior
            let valueOpt = source.TryMasterBehavior
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::MasterBehavior "); target.MasterBehavior <-  value
            | USome _, UNone -> target.MasterBehavior <- Xamarin.Forms.MasterBehavior.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsPresentedChanged
            match prevValueOpt, source.TryIsPresentedChanged with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.IsPresentedChanged.RemoveHandler(prevValue); target.IsPresentedChanged.AddHandler(value)
            | UNone, USome value -> target.IsPresentedChanged.AddHandler(value)
            | USome prevValue, UNone -> target.IsPresentedChanged.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTitle
            let valueOpt = source.TryTitle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::Title "); target.Title <-  value
            | USome _, UNone -> target.Title <- ""
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryPadding
            let valueOpt = source.TryPadding
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::Padding "); target.Padding <-  value
            | USome _, UNone -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryUseSafeArea
            let valueOpt = source.TryUseSafeArea
            (fun _ _ target -> Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea((target :> Xamarin.Forms.Page).On<Xamarin.Forms.PlatformConfiguration.iOS>(), true) |> ignore) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.MasterDetailPage>, create, update, Map.ofArray attribs)

    /// Describes a Cell in the view
    static member Cell(?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match height with None -> () | Some v -> yield ("Height", box ((v))) 
            match isEnabled with None -> () | Some v -> yield ("IsEnabled", box ((v))) 
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.Cell"

        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.Cell)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeight
            let valueOpt = source.TryHeight
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Cell::Height "); target.Height <-  value
            | USome _, UNone -> target.Height <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Cell::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Cell::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting Cell::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.Cell>, create, update, Map.ofArray attribs)

    /// Describes a TextCell in the view
    static member TextCell(?text: string, ?detail: string, ?textColor: Xamarin.Forms.Color, ?detailColor: Xamarin.Forms.Color, ?command: unit -> unit, ?canExecute: bool, ?commandParameter: System.Object, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match text with None -> () | Some v -> yield ("Text", box ((v))) 
            match detail with None -> () | Some v -> yield ("TextDetail", box ((v))) 
            match textColor with None -> () | Some v -> yield ("TextColor", box ((v))) 
            match detailColor with None -> () | Some v -> yield ("TextDetailColor", box ((v))) 
            match command with None -> () | Some v -> yield ("TextCellCommand", box ((v))) 
            match canExecute with None -> () | Some v -> yield ("TextCellCanExecute", box ((v))) 
            match commandParameter with None -> () | Some v -> yield ("CommandParameter", box ((v))) 
            match height with None -> () | Some v -> yield ("Height", box ((v))) 
            match isEnabled with None -> () | Some v -> yield ("IsEnabled", box ((v))) 
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.TextCell())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.TextCell)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryText
            let valueOpt = source.TryText
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TextCell::Text "); target.Text <-  value
            | USome _, UNone -> target.Text <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTextDetail
            let valueOpt = source.TryTextDetail
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TextCell::Detail "); target.Detail <-  value
            | USome _, UNone -> target.Detail <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTextColor
            let valueOpt = source.TryTextColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TextCell::TextColor "); target.TextColor <-  value
            | USome _, UNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTextDetailColor
            let valueOpt = source.TryTextDetailColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TextCell::DetailColor "); target.DetailColor <-  value
            | USome _, UNone -> target.DetailColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTextCellCommand
            let valueOpt = source.TryTextCellCommand
            (fun _ _ _ -> ()) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTextCellCanExecute
            let valueOpt = source.TryTextCellCanExecute
            updateCommand (match prevOpt with UNone -> UNone | USome prev -> prev.TryTextCellCommand) prevValueOpt source.TryTextCellCommand valueOpt (fun cmd -> System.Diagnostics.Debug.WriteLine("Setting TextCell::Command "); target.Command <- cmd) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryCommandParameter
            let valueOpt = source.TryCommandParameter
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TextCell::CommandParameter "); target.CommandParameter <-  value
            | USome _, UNone -> target.CommandParameter <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeight
            let valueOpt = source.TryHeight
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TextCell::Height "); target.Height <-  value
            | USome _, UNone -> target.Height <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TextCell::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TextCell::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting TextCell::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.TextCell>, create, update, Map.ofArray attribs)

    /// Describes a ImageCell in the view
    static member ImageCell(?imageSource: string, ?text: string, ?detail: string, ?textColor: Xamarin.Forms.Color, ?detailColor: Xamarin.Forms.Color, ?command: unit -> unit, ?canExecute: bool, ?commandParameter: System.Object, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match imageSource with None -> () | Some v -> yield ("ImageSource", box ((v))) 
            match text with None -> () | Some v -> yield ("Text", box ((v))) 
            match detail with None -> () | Some v -> yield ("TextDetail", box ((v))) 
            match textColor with None -> () | Some v -> yield ("TextColor", box ((v))) 
            match detailColor with None -> () | Some v -> yield ("TextDetailColor", box ((v))) 
            match command with None -> () | Some v -> yield ("TextCellCommand", box ((v))) 
            match canExecute with None -> () | Some v -> yield ("TextCellCanExecute", box ((v))) 
            match commandParameter with None -> () | Some v -> yield ("CommandParameter", box ((v))) 
            match height with None -> () | Some v -> yield ("Height", box ((v))) 
            match isEnabled with None -> () | Some v -> yield ("IsEnabled", box ((v))) 
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.ImageCell())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.ImageCell)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryImageSource
            let valueOpt = source.TryImageSource
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ImageCell::ImageSource "); target.ImageSource <- makeImageSource  value
            | USome _, UNone -> target.ImageSource <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryText
            let valueOpt = source.TryText
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ImageCell::Text "); target.Text <-  value
            | USome _, UNone -> target.Text <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTextDetail
            let valueOpt = source.TryTextDetail
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ImageCell::Detail "); target.Detail <-  value
            | USome _, UNone -> target.Detail <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTextColor
            let valueOpt = source.TryTextColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ImageCell::TextColor "); target.TextColor <-  value
            | USome _, UNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTextDetailColor
            let valueOpt = source.TryTextDetailColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ImageCell::DetailColor "); target.DetailColor <-  value
            | USome _, UNone -> target.DetailColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTextCellCommand
            let valueOpt = source.TryTextCellCommand
            (fun _ _ _ -> ()) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTextCellCanExecute
            let valueOpt = source.TryTextCellCanExecute
            updateCommand (match prevOpt with UNone -> UNone | USome prev -> prev.TryTextCellCommand) prevValueOpt source.TryTextCellCommand valueOpt (fun cmd -> System.Diagnostics.Debug.WriteLine("Setting TextCell::Command "); target.Command <- cmd) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryCommandParameter
            let valueOpt = source.TryCommandParameter
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ImageCell::CommandParameter "); target.CommandParameter <-  value
            | USome _, UNone -> target.CommandParameter <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeight
            let valueOpt = source.TryHeight
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ImageCell::Height "); target.Height <-  value
            | USome _, UNone -> target.Height <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ImageCell::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ImageCell::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ImageCell::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.ImageCell>, create, update, Map.ofArray attribs)

    /// Describes a ViewCell in the view
    static member ViewCell(?view: XamlElement, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match view with None -> () | Some v -> yield ("View", box ((v))) 
            match height with None -> () | Some v -> yield ("Height", box ((v))) 
            match isEnabled with None -> () | Some v -> yield ("IsEnabled", box ((v))) 
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Xamarin.Forms.ViewCell())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.ViewCell)
            let prevChildOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryView
            match prevChildOpt, source.TryView with
            // For structured objects, dependsOn on reference equality
            | USome prevChild, USome newChild when System.Object.ReferenceEquals(prevChild, newChild) -> ()
            | USome prevChild, USome newChild when prevChild.TargetType = newChild.TargetType ->
                newChild.UpdateIncremental(prevChild, target.View)
            | USome _, USome newChild
            | UNone, USome newChild ->
                target.View <- newChild.CreateAsView()
            | USome _, UNone ->
                target.View <- null;
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeight
            let valueOpt = source.TryHeight
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ViewCell::Height "); target.Height <-  value
            | USome _, UNone -> target.Height <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ViewCell::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ViewCell::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ViewCell::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.ViewCell>, create, update, Map.ofArray attribs)

    /// Describes a ListView in the view
    static member ListView(?items: XamlElement list, ?footer: System.Object, ?hasUnevenRows: bool, ?header: System.Object, ?headerTemplate: Xamarin.Forms.DataTemplate, ?isGroupingEnabled: bool, ?isPullToRefreshEnabled: bool, ?isRefreshing: bool, ?refreshCommand: unit -> unit, ?rowHeight: int, ?selectedItem: int option, ?separatorVisibility: Xamarin.Forms.SeparatorVisibility, ?separatorColor: Xamarin.Forms.Color, ?itemAppearing: Xamarin.Forms.ItemVisibilityEventArgs -> unit, ?itemDisappearing: Xamarin.Forms.ItemVisibilityEventArgs -> unit, ?itemSelected: int option -> unit, ?itemTapped: Xamarin.Forms.ItemTappedEventArgs -> unit, ?refreshing: unit -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match items with None -> () | Some v -> yield ("ListViewItems", box (Array.ofList(v))) 
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
            match separatorVisibility with None -> () | Some v -> yield ("SeparatorVisibility", box ((v))) 
            match separatorColor with None -> () | Some v -> yield ("SeparatorColor", box ((v))) 
            match itemAppearing with None -> () | Some v -> yield ("ItemAppearing", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun _sender args -> f args))(v))) 
            match itemDisappearing with None -> () | Some v -> yield ("ItemDisappearing", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun _sender args -> f args))(v))) 
            match itemSelected with None -> () | Some v -> yield ("ListView_ItemSelected", box ((fun f -> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args -> f (args.SelectedItem |> Option.ofObj |> Option.map unbox<ListElementData<XamlElement>> |> Option.bind (fun item -> let items = (sender :?> Xamarin.Forms.ListView).ItemsSource :?> System.Collections.Generic.IList<ListElementData<XamlElement>> in items |> Seq.tryFindIndex (fun item2 -> System.Object.ReferenceEquals(item.Key, item2.Key))))))(v))) 
            match itemTapped with None -> () | Some v -> yield ("ItemTapped", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun _sender args -> f args))(v))) 
            match refreshing with None -> () | Some v -> yield ("Refreshing", box ((fun f -> System.EventHandler(fun sender args -> f ()))(v))) 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Elmish.XamarinForms.DynamicViews.CustomListView())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.ListView)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryListViewItems
            let valueOpt = source.TryListViewItems
            updateListViewItems prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryFooter
            let valueOpt = source.TryFooter
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::Footer "); target.Footer <-  value
            | USome _, UNone -> target.Footer <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHasUnevenRows
            let valueOpt = source.TryHasUnevenRows
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::HasUnevenRows "); target.HasUnevenRows <-  value
            | USome _, UNone -> target.HasUnevenRows <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeader
            let valueOpt = source.TryHeader
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::Header "); target.Header <-  value
            | USome _, UNone -> target.Header <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeaderTemplate
            let valueOpt = source.TryHeaderTemplate
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::HeaderTemplate "); target.HeaderTemplate <-  value
            | USome _, UNone -> target.HeaderTemplate <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsGroupingEnabled
            let valueOpt = source.TryIsGroupingEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::IsGroupingEnabled "); target.IsGroupingEnabled <-  value
            | USome _, UNone -> target.IsGroupingEnabled <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsPullToRefreshEnabled
            let valueOpt = source.TryIsPullToRefreshEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::IsPullToRefreshEnabled "); target.IsPullToRefreshEnabled <-  value
            | USome _, UNone -> target.IsPullToRefreshEnabled <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsRefreshing
            let valueOpt = source.TryIsRefreshing
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::IsRefreshing "); target.IsRefreshing <-  value
            | USome _, UNone -> target.IsRefreshing <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRefreshCommand
            let valueOpt = source.TryRefreshCommand
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::RefreshCommand "); target.RefreshCommand <-  value
            | USome _, UNone -> target.RefreshCommand <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRowHeight
            let valueOpt = source.TryRowHeight
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::RowHeight "); target.RowHeight <-  value
            | USome _, UNone -> target.RowHeight <- -1
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryListView_SelectedItem
            let valueOpt = source.TryListView_SelectedItem
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::SelectedItem "); target.SelectedItem <- (function None -> null | Some i -> let items = target.ItemsSource :?> System.Collections.Generic.IList<ListElementData<XamlElement>> in if i >= 0 && i < items.Count then items.[i] else null)  value
            | USome _, UNone -> target.SelectedItem <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TrySeparatorVisibility
            let valueOpt = source.TrySeparatorVisibility
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::SeparatorVisibility "); target.SeparatorVisibility <-  value
            | USome _, UNone -> target.SeparatorVisibility <- Xamarin.Forms.SeparatorVisibility.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TrySeparatorColor
            let valueOpt = source.TrySeparatorColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::SeparatorColor "); target.SeparatorColor <-  value
            | USome _, UNone -> target.SeparatorColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryItemAppearing
            match prevValueOpt, source.TryItemAppearing with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.ItemAppearing.RemoveHandler(prevValue); target.ItemAppearing.AddHandler(value)
            | UNone, USome value -> target.ItemAppearing.AddHandler(value)
            | USome prevValue, UNone -> target.ItemAppearing.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryItemDisappearing
            match prevValueOpt, source.TryItemDisappearing with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.ItemDisappearing.RemoveHandler(prevValue); target.ItemDisappearing.AddHandler(value)
            | UNone, USome value -> target.ItemDisappearing.AddHandler(value)
            | USome prevValue, UNone -> target.ItemDisappearing.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryListView_ItemSelected
            match prevValueOpt, source.TryListView_ItemSelected with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.ItemSelected.RemoveHandler(prevValue); target.ItemSelected.AddHandler(value)
            | UNone, USome value -> target.ItemSelected.AddHandler(value)
            | USome prevValue, UNone -> target.ItemSelected.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryItemTapped
            match prevValueOpt, source.TryItemTapped with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.ItemTapped.RemoveHandler(prevValue); target.ItemTapped.AddHandler(value)
            | UNone, USome value -> target.ItemTapped.AddHandler(value)
            | USome prevValue, UNone -> target.ItemTapped.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRefreshing
            match prevValueOpt, source.TryRefreshing with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.Refreshing.RemoveHandler(prevValue); target.Refreshing.AddHandler(value)
            | UNone, USome value -> target.Refreshing.AddHandler(value)
            | USome prevValue, UNone -> target.Refreshing.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.ListView>, create, update, Map.ofArray attribs)

    /// Describes a ListViewGrouped in the view
    static member ListViewGrouped(?items: (XamlElement * XamlElement list) list, ?footer: System.Object, ?hasUnevenRows: bool, ?header: System.Object, ?isGroupingEnabled: bool, ?isPullToRefreshEnabled: bool, ?isRefreshing: bool, ?refreshCommand: unit -> unit, ?rowHeight: int, ?selectedItem: (int * int) option, ?separatorVisibility: Xamarin.Forms.SeparatorVisibility, ?separatorColor: Xamarin.Forms.Color, ?itemAppearing: Xamarin.Forms.ItemVisibilityEventArgs -> unit, ?itemDisappearing: Xamarin.Forms.ItemVisibilityEventArgs -> unit, ?itemSelected: (int * int) option -> unit, ?itemTapped: Xamarin.Forms.ItemTappedEventArgs -> unit, ?refreshing: unit -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?classId: string, ?styleId: string) = 
        let attribs = [| 
            match items with None -> () | Some v -> yield ("GroupListViewItemsSource", box ((fun es -> es |> Array.ofList |> Array.map (fun (e,l) -> (e, Array.ofList l)))(v))) 
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
            match itemAppearing with None -> () | Some v -> yield ("ItemAppearing", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun _sender args -> f args))(v))) 
            match itemDisappearing with None -> () | Some v -> yield ("ItemDisappearing", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun _sender args -> f args))(v))) 
            match itemSelected with None -> () | Some v -> yield ("ListViewGrouped_ItemSelected", box ((fun f -> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args -> f (args.SelectedItem |> Option.ofObj |> Option.map unbox<ListElementData<XamlElement>> |> Option.bind (fun item -> let items = (sender :?> Xamarin.Forms.ListView).ItemsSource :?> System.Collections.Generic.IList<ListGroupData<XamlElement>> in Seq.indexed items |> Seq.tryPick (fun (i,items2) -> Seq.indexed items2 |> Seq.tryPick (fun (j,item2) -> if System.Object.ReferenceEquals(item.Key, item2.Key) then Some (i,j) else None))))))(v))) 
            match itemTapped with None -> () | Some v -> yield ("ItemTapped", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun _sender args -> f args))(v))) 
            match refreshing with None -> () | Some v -> yield ("Refreshing", box ((fun f -> System.EventHandler(fun sender args -> f ()))(v))) 
            match horizontalOptions with None -> () | Some v -> yield ("HorizontalOptions", box ((v))) 
            match verticalOptions with None -> () | Some v -> yield ("VerticalOptions", box ((v))) 
            match margin with None -> () | Some v -> yield ("Margin", box (makeThickness(v))) 
            match gestureRecognizers with None -> () | Some v -> yield ("GestureRecognizers", box (Array.ofList(v))) 
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
            match classId with None -> () | Some v -> yield ("ClassId", box ((v))) 
            match styleId with None -> () | Some v -> yield ("StyleId", box ((v))) 
          |]

        let create () =
            box (new Elmish.XamarinForms.DynamicViews.CustomGroupListView())
        let update (prevOpt: XamlElement uoption) (source: XamlElement) (target:obj) = 
            let target = (target :?> Xamarin.Forms.ListView)
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGroupListViewItemsSource
            let valueOpt = source.TryGroupListViewItemsSource
            updateListViewGroupedItems prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryFooter
            let valueOpt = source.TryFooter
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::Footer "); target.Footer <-  value
            | USome _, UNone -> target.Footer <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHasUnevenRows
            let valueOpt = source.TryHasUnevenRows
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::HasUnevenRows "); target.HasUnevenRows <-  value
            | USome _, UNone -> target.HasUnevenRows <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeader
            let valueOpt = source.TryHeader
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::Header "); target.Header <-  value
            | USome _, UNone -> target.Header <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsGroupingEnabled
            let valueOpt = source.TryIsGroupingEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::IsGroupingEnabled "); target.IsGroupingEnabled <-  value
            | USome _, UNone -> target.IsGroupingEnabled <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsPullToRefreshEnabled
            let valueOpt = source.TryIsPullToRefreshEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::IsPullToRefreshEnabled "); target.IsPullToRefreshEnabled <-  value
            | USome _, UNone -> target.IsPullToRefreshEnabled <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsRefreshing
            let valueOpt = source.TryIsRefreshing
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::IsRefreshing "); target.IsRefreshing <-  value
            | USome _, UNone -> target.IsRefreshing <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRefreshCommand
            let valueOpt = source.TryRefreshCommand
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::RefreshCommand "); target.RefreshCommand <-  value
            | USome _, UNone -> target.RefreshCommand <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRowHeight
            let valueOpt = source.TryRowHeight
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::RowHeight "); target.RowHeight <-  value
            | USome _, UNone -> target.RowHeight <- -1
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryListViewGrouped_SelectedItem
            let valueOpt = source.TryListViewGrouped_SelectedItem
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::SelectedItem "); target.SelectedItem <- (function None -> null | Some (i,j) -> let items = target.ItemsSource :?> System.Collections.Generic.IList<ListGroupData<XamlElement>> in (if i >= 0 && i < items.Count then (let items2 = items.[i] in if j >= 0 && j < items2.Count then items2.[j] else null) else null))  value
            | USome _, UNone -> target.SelectedItem <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TrySeparatorVisibility
            let valueOpt = source.TrySeparatorVisibility
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::SeparatorVisibility "); target.SeparatorVisibility <-  value
            | USome _, UNone -> target.SeparatorVisibility <- Xamarin.Forms.SeparatorVisibility.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TrySeparatorColor
            let valueOpt = source.TrySeparatorColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::SeparatorColor "); target.SeparatorColor <-  value
            | USome _, UNone -> target.SeparatorColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryItemAppearing
            match prevValueOpt, source.TryItemAppearing with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.ItemAppearing.RemoveHandler(prevValue); target.ItemAppearing.AddHandler(value)
            | UNone, USome value -> target.ItemAppearing.AddHandler(value)
            | USome prevValue, UNone -> target.ItemAppearing.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryItemDisappearing
            match prevValueOpt, source.TryItemDisappearing with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.ItemDisappearing.RemoveHandler(prevValue); target.ItemDisappearing.AddHandler(value)
            | UNone, USome value -> target.ItemDisappearing.AddHandler(value)
            | USome prevValue, UNone -> target.ItemDisappearing.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryListViewGrouped_ItemSelected
            match prevValueOpt, source.TryListViewGrouped_ItemSelected with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.ItemSelected.RemoveHandler(prevValue); target.ItemSelected.AddHandler(value)
            | UNone, USome value -> target.ItemSelected.AddHandler(value)
            | USome prevValue, UNone -> target.ItemSelected.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryItemTapped
            match prevValueOpt, source.TryItemTapped with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.ItemTapped.RemoveHandler(prevValue); target.ItemTapped.AddHandler(value)
            | UNone, USome value -> target.ItemTapped.AddHandler(value)
            | USome prevValue, UNone -> target.ItemTapped.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRefreshing
            match prevValueOpt, source.TryRefreshing with
            | USome prevValue, USome value when System.Object.ReferenceEquals(prevValue, value) -> ()
            | USome prevValue, USome value -> target.Refreshing.RemoveHandler(prevValue); target.Refreshing.AddHandler(value)
            | UNone, USome value -> target.Refreshing.AddHandler(value)
            | USome prevValue, UNone -> target.Refreshing.RemoveHandler(prevValue)
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::HorizontalOptions "); target.HorizontalOptions <-  value
            | USome _, UNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::VerticalOptions "); target.VerticalOptions <-  value
            | USome _, UNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::Margin "); target.Margin <-  value
            | USome _, UNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | UNone, UNone -> ()
            let prevCollOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
                (fun _ _ _ -> ())
                canReuseDefault
                updateDefault
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::AnchorX "); target.AnchorX <-  value
            | USome _, UNone -> target.AnchorX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::AnchorY "); target.AnchorY <-  value
            | USome _, UNone -> target.AnchorY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::BackgroundColor "); target.BackgroundColor <-  value
            | USome _, UNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::HeightRequest "); target.HeightRequest <-  value
            | USome _, UNone -> target.HeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::InputTransparent "); target.InputTransparent <-  value
            | USome _, UNone -> target.InputTransparent <- false
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::IsEnabled "); target.IsEnabled <-  value
            | USome _, UNone -> target.IsEnabled <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::IsVisible "); target.IsVisible <-  value
            | USome _, UNone -> target.IsVisible <- true
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | USome _, UNone -> target.MinimumHeightRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | USome _, UNone -> target.MinimumWidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::Opacity "); target.Opacity <-  value
            | USome _, UNone -> target.Opacity <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::Rotation "); target.Rotation <-  value
            | USome _, UNone -> target.Rotation <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::RotationX "); target.RotationX <-  value
            | USome _, UNone -> target.RotationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::RotationY "); target.RotationY <-  value
            | USome _, UNone -> target.RotationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::Scale "); target.Scale <-  value
            | USome _, UNone -> target.Scale <- 1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::Style "); target.Style <-  value
            | USome _, UNone -> target.Style <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::TranslationX "); target.TranslationX <-  value
            | USome _, UNone -> target.TranslationX <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::TranslationY "); target.TranslationY <-  value
            | USome _, UNone -> target.TranslationY <- 0.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::WidthRequest "); target.WidthRequest <-  value
            | USome _, UNone -> target.WidthRequest <- -1.0
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::ClassId "); target.ClassId <-  value
            | USome _, UNone -> target.ClassId <- null
            | UNone, UNone -> ()
            let prevValueOpt = match prevOpt with UNone -> UNone | USome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | USome prevValue, USome value when prevValue = value -> ()
            | prevOpt, USome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::StyleId "); target.StyleId <-  value
            | USome _, UNone -> target.StyleId <- null
            | UNone, UNone -> ()
        new XamlElement(typeof<Xamarin.Forms.ListView>, create, update, Map.ofArray attribs)
[<AutoOpen>]
module XamlCreateExtensions = 

    /// Specifies a PanGestureRecognizer in the view description, initially with default attributes
    let panGestureRecognizer = Xaml.PanGestureRecognizer()

    /// Specifies a TapGestureRecognizer in the view description, initially with default attributes
    let tapGestureRecognizer = Xaml.TapGestureRecognizer()

    /// Specifies a ClickGestureRecognizer in the view description, initially with default attributes
    let clickGestureRecognizer = Xaml.ClickGestureRecognizer()

    /// Specifies a PinchGestureRecognizer in the view description, initially with default attributes
    let pinchGestureRecognizer = Xaml.PinchGestureRecognizer()

    /// Specifies a ActivityIndicator in the view description, initially with default attributes
    let activityIndicator = Xaml.ActivityIndicator()

    /// Specifies a BoxView in the view description, initially with default attributes
    let boxView = Xaml.BoxView()

    /// Specifies a ProgressBar in the view description, initially with default attributes
    let progressBar = Xaml.ProgressBar()

    /// Specifies a ScrollView in the view description, initially with default attributes
    let scrollView = Xaml.ScrollView()

    /// Specifies a SearchBar in the view description, initially with default attributes
    let searchBar = Xaml.SearchBar()

    /// Specifies a Button in the view description, initially with default attributes
    let button = Xaml.Button()

    /// Specifies a Slider in the view description, initially with default attributes
    let slider = Xaml.Slider()

    /// Specifies a Stepper in the view description, initially with default attributes
    let stepper = Xaml.Stepper()

    /// Specifies a Switch in the view description, initially with default attributes
    let switch = Xaml.Switch()

    /// Specifies a SwitchCell in the view description, initially with default attributes
    let switchCell = Xaml.SwitchCell()

    /// Specifies a TableView in the view description, initially with default attributes
    let tableView = Xaml.TableView()

    /// Specifies a Grid in the view description, initially with default attributes
    let grid = Xaml.Grid()

    /// Specifies a AbsoluteLayout in the view description, initially with default attributes
    let absoluteLayout = Xaml.AbsoluteLayout()

    /// Specifies a RelativeLayout in the view description, initially with default attributes
    let relativeLayout = Xaml.RelativeLayout()

    /// Specifies a RowDefinition in the view description, initially with default attributes
    let rowDefinition = Xaml.RowDefinition()

    /// Specifies a ColumnDefinition in the view description, initially with default attributes
    let columnDefinition = Xaml.ColumnDefinition()

    /// Specifies a ContentView in the view description, initially with default attributes
    let contentView = Xaml.ContentView()

    /// Specifies a TemplatedView in the view description, initially with default attributes
    let templatedView = Xaml.TemplatedView()

    /// Specifies a DatePicker in the view description, initially with default attributes
    let datePicker = Xaml.DatePicker()

    /// Specifies a Picker in the view description, initially with default attributes
    let picker = Xaml.Picker()

    /// Specifies a Frame in the view description, initially with default attributes
    let frame = Xaml.Frame()

    /// Specifies a Image in the view description, initially with default attributes
    let image = Xaml.Image()

    /// Specifies a Editor in the view description, initially with default attributes
    let editor = Xaml.Editor()

    /// Specifies a Entry in the view description, initially with default attributes
    let entry = Xaml.Entry()

    /// Specifies a EntryCell in the view description, initially with default attributes
    let entryCell = Xaml.EntryCell()

    /// Specifies a Label in the view description, initially with default attributes
    let label = Xaml.Label()

    /// Specifies a StackLayout in the view description, initially with default attributes
    let stackLayout = Xaml.StackLayout()

    /// Specifies a Span in the view description, initially with default attributes
    let span = Xaml.Span()

    /// Specifies a TimePicker in the view description, initially with default attributes
    let timePicker = Xaml.TimePicker()

    /// Specifies a WebView in the view description, initially with default attributes
    let webView = Xaml.WebView()

    /// Specifies a Page in the view description, initially with default attributes
    let page = Xaml.Page()

    /// Specifies a CarouselPage in the view description, initially with default attributes
    let carouselPage = Xaml.CarouselPage()

    /// Specifies a NavigationPage in the view description, initially with default attributes
    let navigationPage = Xaml.NavigationPage()

    /// Specifies a TabbedPage in the view description, initially with default attributes
    let tabbedPage = Xaml.TabbedPage()

    /// Specifies a ContentPage in the view description, initially with default attributes
    let contentPage = Xaml.ContentPage()

    /// Specifies a MasterDetailPage in the view description, initially with default attributes
    let masterDetailPage = Xaml.MasterDetailPage()

    /// Specifies a TextCell in the view description, initially with default attributes
    let textCell = Xaml.TextCell()

    /// Specifies a ImageCell in the view description, initially with default attributes
    let imageCell = Xaml.ImageCell()

    /// Specifies a ViewCell in the view description, initially with default attributes
    let viewCell = Xaml.ViewCell()

    /// Specifies a ListView in the view description, initially with default attributes
    let listView = Xaml.ListView()

    /// Specifies a ListViewGrouped in the view description, initially with default attributes
    let listViewGrouped = Xaml.ListViewGrouped()
