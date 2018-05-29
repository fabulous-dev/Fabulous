namespace rec Elmish.XamarinForms.DynamicViews 

#nowarn "67" // cast always holds

[<AutoOpen>]
module XamlElementExtensions = 

    type XamlElement with

        /// Create a Xamarin.Forms.Element from the view description
        member internal x.CreateAsElement() : Xamarin.Forms.Element =
            match x.Create() with
            | :? Xamarin.Forms.Element as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.Element' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.VisualElement from the view description
        member internal x.CreateAsVisualElement() : Xamarin.Forms.VisualElement =
            match x.Create() with
            | :? Xamarin.Forms.VisualElement as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.VisualElement' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.View from the view description
        member internal x.CreateAsView() : Xamarin.Forms.View =
            match x.Create() with
            | :? Xamarin.Forms.View as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.View' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.IGestureRecognizer from the view description
        member internal x.CreateAsIGestureRecognizer() : Xamarin.Forms.IGestureRecognizer =
            match x.Create() with
            | :? Xamarin.Forms.IGestureRecognizer as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.IGestureRecognizer' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.PanGestureRecognizer from the view description
        member internal x.CreateAsPanGestureRecognizer() : Xamarin.Forms.PanGestureRecognizer =
            match x.Create() with
            | :? Xamarin.Forms.PanGestureRecognizer as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.PanGestureRecognizer' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.TapGestureRecognizer from the view description
        member internal x.CreateAsTapGestureRecognizer() : Xamarin.Forms.TapGestureRecognizer =
            match x.Create() with
            | :? Xamarin.Forms.TapGestureRecognizer as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.TapGestureRecognizer' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.ClickGestureRecognizer from the view description
        member internal x.CreateAsClickGestureRecognizer() : Xamarin.Forms.ClickGestureRecognizer =
            match x.Create() with
            | :? Xamarin.Forms.ClickGestureRecognizer as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.ClickGestureRecognizer' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.PinchGestureRecognizer from the view description
        member internal x.CreateAsPinchGestureRecognizer() : Xamarin.Forms.PinchGestureRecognizer =
            match x.Create() with
            | :? Xamarin.Forms.PinchGestureRecognizer as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.PinchGestureRecognizer' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.ActivityIndicator from the view description
        member internal x.CreateAsActivityIndicator() : Xamarin.Forms.ActivityIndicator =
            match x.Create() with
            | :? Xamarin.Forms.ActivityIndicator as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.ActivityIndicator' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.BoxView from the view description
        member internal x.CreateAsBoxView() : Xamarin.Forms.BoxView =
            match x.Create() with
            | :? Xamarin.Forms.BoxView as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.BoxView' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.ProgressBar from the view description
        member internal x.CreateAsProgressBar() : Xamarin.Forms.ProgressBar =
            match x.Create() with
            | :? Xamarin.Forms.ProgressBar as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.ProgressBar' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.ScrollView from the view description
        member internal x.CreateAsScrollView() : Xamarin.Forms.ScrollView =
            match x.Create() with
            | :? Xamarin.Forms.ScrollView as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.ScrollView' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.SearchBar from the view description
        member internal x.CreateAsSearchBar() : Xamarin.Forms.SearchBar =
            match x.Create() with
            | :? Xamarin.Forms.SearchBar as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.SearchBar' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Button from the view description
        member internal x.CreateAsButton() : Xamarin.Forms.Button =
            match x.Create() with
            | :? Xamarin.Forms.Button as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.Button' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Slider from the view description
        member internal x.CreateAsSlider() : Xamarin.Forms.Slider =
            match x.Create() with
            | :? Xamarin.Forms.Slider as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.Slider' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Stepper from the view description
        member internal x.CreateAsStepper() : Xamarin.Forms.Stepper =
            match x.Create() with
            | :? Xamarin.Forms.Stepper as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.Stepper' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Switch from the view description
        member internal x.CreateAsSwitch() : Xamarin.Forms.Switch =
            match x.Create() with
            | :? Xamarin.Forms.Switch as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.Switch' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.SwitchCell from the view description
        member internal x.CreateAsSwitchCell() : Xamarin.Forms.SwitchCell =
            match x.Create() with
            | :? Xamarin.Forms.SwitchCell as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.SwitchCell' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.TableView from the view description
        member internal x.CreateAsTableView() : Xamarin.Forms.TableView =
            match x.Create() with
            | :? Xamarin.Forms.TableView as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.TableView' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Grid from the view description
        member internal x.CreateAsGrid() : Xamarin.Forms.Grid =
            match x.Create() with
            | :? Xamarin.Forms.Grid as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.Grid' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.AbsoluteLayout from the view description
        member internal x.CreateAsAbsoluteLayout() : Xamarin.Forms.AbsoluteLayout =
            match x.Create() with
            | :? Xamarin.Forms.AbsoluteLayout as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.AbsoluteLayout' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.RelativeLayout from the view description
        member internal x.CreateAsRelativeLayout() : Xamarin.Forms.RelativeLayout =
            match x.Create() with
            | :? Xamarin.Forms.RelativeLayout as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.RelativeLayout' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.RowDefinition from the view description
        member internal x.CreateAsRowDefinition() : Xamarin.Forms.RowDefinition =
            match x.Create() with
            | :? Xamarin.Forms.RowDefinition as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.RowDefinition' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.ColumnDefinition from the view description
        member internal x.CreateAsColumnDefinition() : Xamarin.Forms.ColumnDefinition =
            match x.Create() with
            | :? Xamarin.Forms.ColumnDefinition as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.ColumnDefinition' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.ContentView from the view description
        member internal x.CreateAsContentView() : Xamarin.Forms.ContentView =
            match x.Create() with
            | :? Xamarin.Forms.ContentView as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.ContentView' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.TemplatedView from the view description
        member internal x.CreateAsTemplatedView() : Xamarin.Forms.TemplatedView =
            match x.Create() with
            | :? Xamarin.Forms.TemplatedView as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.TemplatedView' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.DatePicker from the view description
        member internal x.CreateAsDatePicker() : Xamarin.Forms.DatePicker =
            match x.Create() with
            | :? Xamarin.Forms.DatePicker as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.DatePicker' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Picker from the view description
        member internal x.CreateAsPicker() : Xamarin.Forms.Picker =
            match x.Create() with
            | :? Xamarin.Forms.Picker as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.Picker' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Frame from the view description
        member internal x.CreateAsFrame() : Xamarin.Forms.Frame =
            match x.Create() with
            | :? Xamarin.Forms.Frame as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.Frame' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Image from the view description
        member internal x.CreateAsImage() : Xamarin.Forms.Image =
            match x.Create() with
            | :? Xamarin.Forms.Image as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.Image' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.InputView from the view description
        member internal x.CreateAsInputView() : Xamarin.Forms.InputView =
            match x.Create() with
            | :? Xamarin.Forms.InputView as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.InputView' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Editor from the view description
        member internal x.CreateAsEditor() : Xamarin.Forms.Editor =
            match x.Create() with
            | :? Xamarin.Forms.Editor as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.Editor' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Entry from the view description
        member internal x.CreateAsEntry() : Xamarin.Forms.Entry =
            match x.Create() with
            | :? Xamarin.Forms.Entry as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.Entry' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.EntryCell from the view description
        member internal x.CreateAsEntryCell() : Xamarin.Forms.EntryCell =
            match x.Create() with
            | :? Xamarin.Forms.EntryCell as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.EntryCell' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Label from the view description
        member internal x.CreateAsLabel() : Xamarin.Forms.Label =
            match x.Create() with
            | :? Xamarin.Forms.Label as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.Label' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Layout from the view description
        member internal x.CreateAsLayout() : Xamarin.Forms.Layout =
            match x.Create() with
            | :? Xamarin.Forms.Layout as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.Layout' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.StackLayout from the view description
        member internal x.CreateAsStackLayout() : Xamarin.Forms.StackLayout =
            match x.Create() with
            | :? Xamarin.Forms.StackLayout as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.StackLayout' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Span from the view description
        member internal x.CreateAsSpan() : Xamarin.Forms.Span =
            match x.Create() with
            | :? Xamarin.Forms.Span as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.Span' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.TimePicker from the view description
        member internal x.CreateAsTimePicker() : Xamarin.Forms.TimePicker =
            match x.Create() with
            | :? Xamarin.Forms.TimePicker as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.TimePicker' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.WebView from the view description
        member internal x.CreateAsWebView() : Xamarin.Forms.WebView =
            match x.Create() with
            | :? Xamarin.Forms.WebView as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.WebView' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Page from the view description
        member internal x.CreateAsPage() : Xamarin.Forms.Page =
            match x.Create() with
            | :? Xamarin.Forms.Page as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.Page' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.CarouselPage from the view description
        member internal x.CreateAsCarouselPage() : Xamarin.Forms.CarouselPage =
            match x.Create() with
            | :? Xamarin.Forms.CarouselPage as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.CarouselPage' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.NavigationPage from the view description
        member internal x.CreateAsNavigationPage() : Xamarin.Forms.NavigationPage =
            match x.Create() with
            | :? Xamarin.Forms.NavigationPage as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.NavigationPage' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.TabbedPage from the view description
        member internal x.CreateAsTabbedPage() : Xamarin.Forms.TabbedPage =
            match x.Create() with
            | :? Xamarin.Forms.TabbedPage as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.TabbedPage' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.ContentPage from the view description
        member internal x.CreateAsContentPage() : Xamarin.Forms.ContentPage =
            match x.Create() with
            | :? Xamarin.Forms.ContentPage as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.ContentPage' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.MasterDetailPage from the view description
        member internal x.CreateAsMasterDetailPage() : Xamarin.Forms.MasterDetailPage =
            match x.Create() with
            | :? Xamarin.Forms.MasterDetailPage as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.MasterDetailPage' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.Cell from the view description
        member internal x.CreateAsCell() : Xamarin.Forms.Cell =
            match x.Create() with
            | :? Xamarin.Forms.Cell as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.Cell' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.TextCell from the view description
        member internal x.CreateAsTextCell() : Xamarin.Forms.TextCell =
            match x.Create() with
            | :? Xamarin.Forms.TextCell as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.TextCell' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.ImageCell from the view description
        member internal x.CreateAsImageCell() : Xamarin.Forms.ImageCell =
            match x.Create() with
            | :? Xamarin.Forms.ImageCell as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.ImageCell' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.ViewCell from the view description
        member internal x.CreateAsViewCell() : Xamarin.Forms.ViewCell =
            match x.Create() with
            | :? Xamarin.Forms.ViewCell as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.ViewCell' but got a '%s')" (obj.GetType().ToString()) 

        /// Create a Xamarin.Forms.ListView from the view description
        member internal x.CreateAsListView() : Xamarin.Forms.ListView =
            match x.Create() with
            | :? Xamarin.Forms.ListView as res -> res
            | obj -> failwithf "Incorrect element type in view (expected a 'Xamarin.Forms.ListView' but got a '%s')" (obj.GetType().ToString()) 


        /// Try to get the ClassId property in the visual element
        member internal x.TryClassId = match x.Attributes.TryFind("ClassId") with Some v -> ValueSome(unbox<string>(v)) | None -> ValueNone

        /// Try to get the StyleId property in the visual element
        member internal x.TryStyleId = match x.Attributes.TryFind("StyleId") with Some v -> ValueSome(unbox<string>(v)) | None -> ValueNone

        /// Try to get the AnchorX property in the visual element
        member internal x.TryAnchorX = match x.Attributes.TryFind("AnchorX") with Some v -> ValueSome(unbox<double>(v)) | None -> ValueNone

        /// Try to get the AnchorY property in the visual element
        member internal x.TryAnchorY = match x.Attributes.TryFind("AnchorY") with Some v -> ValueSome(unbox<double>(v)) | None -> ValueNone

        /// Try to get the BackgroundColor property in the visual element
        member internal x.TryBackgroundColor = match x.Attributes.TryFind("BackgroundColor") with Some v -> ValueSome(unbox<Xamarin.Forms.Color>(v)) | None -> ValueNone

        /// Try to get the HeightRequest property in the visual element
        member internal x.TryHeightRequest = match x.Attributes.TryFind("HeightRequest") with Some v -> ValueSome(unbox<double>(v)) | None -> ValueNone

        /// Try to get the InputTransparent property in the visual element
        member internal x.TryInputTransparent = match x.Attributes.TryFind("InputTransparent") with Some v -> ValueSome(unbox<bool>(v)) | None -> ValueNone

        /// Try to get the IsEnabled property in the visual element
        member internal x.TryIsEnabled = match x.Attributes.TryFind("IsEnabled") with Some v -> ValueSome(unbox<bool>(v)) | None -> ValueNone

        /// Try to get the IsVisible property in the visual element
        member internal x.TryIsVisible = match x.Attributes.TryFind("IsVisible") with Some v -> ValueSome(unbox<bool>(v)) | None -> ValueNone

        /// Try to get the MinimumHeightRequest property in the visual element
        member internal x.TryMinimumHeightRequest = match x.Attributes.TryFind("MinimumHeightRequest") with Some v -> ValueSome(unbox<double>(v)) | None -> ValueNone

        /// Try to get the MinimumWidthRequest property in the visual element
        member internal x.TryMinimumWidthRequest = match x.Attributes.TryFind("MinimumWidthRequest") with Some v -> ValueSome(unbox<double>(v)) | None -> ValueNone

        /// Try to get the Opacity property in the visual element
        member internal x.TryOpacity = match x.Attributes.TryFind("Opacity") with Some v -> ValueSome(unbox<double>(v)) | None -> ValueNone

        /// Try to get the Rotation property in the visual element
        member internal x.TryRotation = match x.Attributes.TryFind("Rotation") with Some v -> ValueSome(unbox<double>(v)) | None -> ValueNone

        /// Try to get the RotationX property in the visual element
        member internal x.TryRotationX = match x.Attributes.TryFind("RotationX") with Some v -> ValueSome(unbox<double>(v)) | None -> ValueNone

        /// Try to get the RotationY property in the visual element
        member internal x.TryRotationY = match x.Attributes.TryFind("RotationY") with Some v -> ValueSome(unbox<double>(v)) | None -> ValueNone

        /// Try to get the Scale property in the visual element
        member internal x.TryScale = match x.Attributes.TryFind("Scale") with Some v -> ValueSome(unbox<double>(v)) | None -> ValueNone

        /// Try to get the Style property in the visual element
        member internal x.TryStyle = match x.Attributes.TryFind("Style") with Some v -> ValueSome(unbox<Xamarin.Forms.Style>(v)) | None -> ValueNone

        /// Try to get the TranslationX property in the visual element
        member internal x.TryTranslationX = match x.Attributes.TryFind("TranslationX") with Some v -> ValueSome(unbox<double>(v)) | None -> ValueNone

        /// Try to get the TranslationY property in the visual element
        member internal x.TryTranslationY = match x.Attributes.TryFind("TranslationY") with Some v -> ValueSome(unbox<double>(v)) | None -> ValueNone

        /// Try to get the WidthRequest property in the visual element
        member internal x.TryWidthRequest = match x.Attributes.TryFind("WidthRequest") with Some v -> ValueSome(unbox<double>(v)) | None -> ValueNone

        /// Try to get the HorizontalOptions property in the visual element
        member internal x.TryHorizontalOptions = match x.Attributes.TryFind("HorizontalOptions") with Some v -> ValueSome(unbox<Xamarin.Forms.LayoutOptions>(v)) | None -> ValueNone

        /// Try to get the VerticalOptions property in the visual element
        member internal x.TryVerticalOptions = match x.Attributes.TryFind("VerticalOptions") with Some v -> ValueSome(unbox<Xamarin.Forms.LayoutOptions>(v)) | None -> ValueNone

        /// Try to get the Margin property in the visual element
        member internal x.TryMargin = match x.Attributes.TryFind("Margin") with Some v -> ValueSome(unbox<Xamarin.Forms.Thickness>(v)) | None -> ValueNone

        /// Try to get the GestureRecognizers property in the visual element
        member internal x.TryGestureRecognizers = match x.Attributes.TryFind("GestureRecognizers") with Some v -> ValueSome(unbox<XamlElement[]>(v)) | None -> ValueNone

        /// Try to get the TouchPoints property in the visual element
        member internal x.TryTouchPoints = match x.Attributes.TryFind("TouchPoints") with Some v -> ValueSome(unbox<int>(v)) | None -> ValueNone

        /// Try to get the PanUpdated property in the visual element
        member internal x.TryPanUpdated = match x.Attributes.TryFind("PanUpdated") with Some v -> ValueSome(unbox<System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>>(v)) | None -> ValueNone

        /// Try to get the Command property in the visual element
        member internal x.TryCommand = match x.Attributes.TryFind("Command") with Some v -> ValueSome(unbox<System.Windows.Input.ICommand>(v)) | None -> ValueNone

        /// Try to get the NumberOfTapsRequired property in the visual element
        member internal x.TryNumberOfTapsRequired = match x.Attributes.TryFind("NumberOfTapsRequired") with Some v -> ValueSome(unbox<int>(v)) | None -> ValueNone

        /// Try to get the NumberOfClicksRequired property in the visual element
        member internal x.TryNumberOfClicksRequired = match x.Attributes.TryFind("NumberOfClicksRequired") with Some v -> ValueSome(unbox<int>(v)) | None -> ValueNone

        /// Try to get the Buttons property in the visual element
        member internal x.TryButtons = match x.Attributes.TryFind("Buttons") with Some v -> ValueSome(unbox<Xamarin.Forms.ButtonsMask>(v)) | None -> ValueNone

        /// Try to get the IsPinching property in the visual element
        member internal x.TryIsPinching = match x.Attributes.TryFind("IsPinching") with Some v -> ValueSome(unbox<bool>(v)) | None -> ValueNone

        /// Try to get the PinchUpdated property in the visual element
        member internal x.TryPinchUpdated = match x.Attributes.TryFind("PinchUpdated") with Some v -> ValueSome(unbox<System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>>(v)) | None -> ValueNone

        /// Try to get the Color property in the visual element
        member internal x.TryColor = match x.Attributes.TryFind("Color") with Some v -> ValueSome(unbox<Xamarin.Forms.Color>(v)) | None -> ValueNone

        /// Try to get the IsRunning property in the visual element
        member internal x.TryIsRunning = match x.Attributes.TryFind("IsRunning") with Some v -> ValueSome(unbox<bool>(v)) | None -> ValueNone

        /// Try to get the Progress property in the visual element
        member internal x.TryProgress = match x.Attributes.TryFind("Progress") with Some v -> ValueSome(unbox<double>(v)) | None -> ValueNone

        /// Try to get the Content property in the visual element
        member internal x.TryContent = match x.Attributes.TryFind("Content") with Some v -> ValueSome(unbox<XamlElement>(v)) | None -> ValueNone

        /// Try to get the ScrollOrientation property in the visual element
        member internal x.TryScrollOrientation = match x.Attributes.TryFind("ScrollOrientation") with Some v -> ValueSome(unbox<Xamarin.Forms.ScrollOrientation>(v)) | None -> ValueNone

        /// Try to get the CancelButtonColor property in the visual element
        member internal x.TryCancelButtonColor = match x.Attributes.TryFind("CancelButtonColor") with Some v -> ValueSome(unbox<Xamarin.Forms.Color>(v)) | None -> ValueNone

        /// Try to get the FontFamily property in the visual element
        member internal x.TryFontFamily = match x.Attributes.TryFind("FontFamily") with Some v -> ValueSome(unbox<string>(v)) | None -> ValueNone

        /// Try to get the FontAttributes property in the visual element
        member internal x.TryFontAttributes = match x.Attributes.TryFind("FontAttributes") with Some v -> ValueSome(unbox<Xamarin.Forms.FontAttributes>(v)) | None -> ValueNone

        /// Try to get the FontSize property in the visual element
        member internal x.TryFontSize = match x.Attributes.TryFind("FontSize") with Some v -> ValueSome(unbox<double>(v)) | None -> ValueNone

        /// Try to get the HorizontalTextAlignment property in the visual element
        member internal x.TryHorizontalTextAlignment = match x.Attributes.TryFind("HorizontalTextAlignment") with Some v -> ValueSome(unbox<Xamarin.Forms.TextAlignment>(v)) | None -> ValueNone

        /// Try to get the Placeholder property in the visual element
        member internal x.TryPlaceholder = match x.Attributes.TryFind("Placeholder") with Some v -> ValueSome(unbox<string>(v)) | None -> ValueNone

        /// Try to get the PlaceholderColor property in the visual element
        member internal x.TryPlaceholderColor = match x.Attributes.TryFind("PlaceholderColor") with Some v -> ValueSome(unbox<Xamarin.Forms.Color>(v)) | None -> ValueNone

        /// Try to get the SearchBarCommand property in the visual element
        member internal x.TrySearchBarCommand = match x.Attributes.TryFind("SearchBarCommand") with Some v -> ValueSome(unbox<unit -> unit>(v)) | None -> ValueNone

        /// Try to get the SearchBarCanExecute property in the visual element
        member internal x.TrySearchBarCanExecute = match x.Attributes.TryFind("SearchBarCanExecute") with Some v -> ValueSome(unbox<bool>(v)) | None -> ValueNone

        /// Try to get the Text property in the visual element
        member internal x.TryText = match x.Attributes.TryFind("Text") with Some v -> ValueSome(unbox<string>(v)) | None -> ValueNone

        /// Try to get the TextColor property in the visual element
        member internal x.TryTextColor = match x.Attributes.TryFind("TextColor") with Some v -> ValueSome(unbox<Xamarin.Forms.Color>(v)) | None -> ValueNone

        /// Try to get the ButtonCommand property in the visual element
        member internal x.TryButtonCommand = match x.Attributes.TryFind("ButtonCommand") with Some v -> ValueSome(unbox<unit -> unit>(v)) | None -> ValueNone

        /// Try to get the ButtonCanExecute property in the visual element
        member internal x.TryButtonCanExecute = match x.Attributes.TryFind("ButtonCanExecute") with Some v -> ValueSome(unbox<bool>(v)) | None -> ValueNone

        /// Try to get the BorderColor property in the visual element
        member internal x.TryBorderColor = match x.Attributes.TryFind("BorderColor") with Some v -> ValueSome(unbox<Xamarin.Forms.Color>(v)) | None -> ValueNone

        /// Try to get the BorderWidth property in the visual element
        member internal x.TryBorderWidth = match x.Attributes.TryFind("BorderWidth") with Some v -> ValueSome(unbox<double>(v)) | None -> ValueNone

        /// Try to get the CommandParameter property in the visual element
        member internal x.TryCommandParameter = match x.Attributes.TryFind("CommandParameter") with Some v -> ValueSome(unbox<System.Object>(v)) | None -> ValueNone

        /// Try to get the ContentLayout property in the visual element
        member internal x.TryContentLayout = match x.Attributes.TryFind("ContentLayout") with Some v -> ValueSome(unbox<Xamarin.Forms.Button.ButtonContentLayout>(v)) | None -> ValueNone

        /// Try to get the ButtonImageSource property in the visual element
        member internal x.TryButtonImageSource = match x.Attributes.TryFind("ButtonImageSource") with Some v -> ValueSome(unbox<string>(v)) | None -> ValueNone

        /// Try to get the Minimum property in the visual element
        member internal x.TryMinimum = match x.Attributes.TryFind("Minimum") with Some v -> ValueSome(unbox<double>(v)) | None -> ValueNone

        /// Try to get the Maximum property in the visual element
        member internal x.TryMaximum = match x.Attributes.TryFind("Maximum") with Some v -> ValueSome(unbox<double>(v)) | None -> ValueNone

        /// Try to get the Value property in the visual element
        member internal x.TryValue = match x.Attributes.TryFind("Value") with Some v -> ValueSome(unbox<double>(v)) | None -> ValueNone

        /// Try to get the ValueChanged property in the visual element
        member internal x.TryValueChanged = match x.Attributes.TryFind("ValueChanged") with Some v -> ValueSome(unbox<System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>>(v)) | None -> ValueNone

        /// Try to get the Increment property in the visual element
        member internal x.TryIncrement = match x.Attributes.TryFind("Increment") with Some v -> ValueSome(unbox<double>(v)) | None -> ValueNone

        /// Try to get the IsToggled property in the visual element
        member internal x.TryIsToggled = match x.Attributes.TryFind("IsToggled") with Some v -> ValueSome(unbox<bool>(v)) | None -> ValueNone

        /// Try to get the Toggled property in the visual element
        member internal x.TryToggled = match x.Attributes.TryFind("Toggled") with Some v -> ValueSome(unbox<System.EventHandler<Xamarin.Forms.ToggledEventArgs>>(v)) | None -> ValueNone

        /// Try to get the On property in the visual element
        member internal x.TryOn = match x.Attributes.TryFind("On") with Some v -> ValueSome(unbox<bool>(v)) | None -> ValueNone

        /// Try to get the OnChanged property in the visual element
        member internal x.TryOnChanged = match x.Attributes.TryFind("OnChanged") with Some v -> ValueSome(unbox<System.EventHandler<Xamarin.Forms.ToggledEventArgs>>(v)) | None -> ValueNone

        /// Try to get the Intent property in the visual element
        member internal x.TryIntent = match x.Attributes.TryFind("Intent") with Some v -> ValueSome(unbox<Xamarin.Forms.TableIntent>(v)) | None -> ValueNone

        /// Try to get the HasUnevenRows property in the visual element
        member internal x.TryHasUnevenRows = match x.Attributes.TryFind("HasUnevenRows") with Some v -> ValueSome(unbox<bool>(v)) | None -> ValueNone

        /// Try to get the RowHeight property in the visual element
        member internal x.TryRowHeight = match x.Attributes.TryFind("RowHeight") with Some v -> ValueSome(unbox<int>(v)) | None -> ValueNone

        /// Try to get the TableRoot property in the visual element
        member internal x.TryTableRoot = match x.Attributes.TryFind("TableRoot") with Some v -> ValueSome(unbox<(string * XamlElement[])[]>(v)) | None -> ValueNone

        /// Try to get the GridRowDefinitions property in the visual element
        member internal x.TryGridRowDefinitions = match x.Attributes.TryFind("GridRowDefinitions") with Some v -> ValueSome(unbox<XamlElement[]>(v)) | None -> ValueNone

        /// Try to get the GridColumnDefinitions property in the visual element
        member internal x.TryGridColumnDefinitions = match x.Attributes.TryFind("GridColumnDefinitions") with Some v -> ValueSome(unbox<XamlElement[]>(v)) | None -> ValueNone

        /// Try to get the RowSpacing property in the visual element
        member internal x.TryRowSpacing = match x.Attributes.TryFind("RowSpacing") with Some v -> ValueSome(unbox<double>(v)) | None -> ValueNone

        /// Try to get the ColumnSpacing property in the visual element
        member internal x.TryColumnSpacing = match x.Attributes.TryFind("ColumnSpacing") with Some v -> ValueSome(unbox<double>(v)) | None -> ValueNone

        /// Try to get the Children property in the visual element
        member internal x.TryChildren = match x.Attributes.TryFind("Children") with Some v -> ValueSome(unbox<XamlElement[]>(v)) | None -> ValueNone

        /// Try to get the GridRow property in the visual element
        member internal x.TryGridRow = match x.Attributes.TryFind("GridRow") with Some v -> ValueSome(unbox<int>(v)) | None -> ValueNone

        /// Try to get the GridRowSpan property in the visual element
        member internal x.TryGridRowSpan = match x.Attributes.TryFind("GridRowSpan") with Some v -> ValueSome(unbox<int>(v)) | None -> ValueNone

        /// Try to get the GridColumn property in the visual element
        member internal x.TryGridColumn = match x.Attributes.TryFind("GridColumn") with Some v -> ValueSome(unbox<int>(v)) | None -> ValueNone

        /// Try to get the GridColumnSpan property in the visual element
        member internal x.TryGridColumnSpan = match x.Attributes.TryFind("GridColumnSpan") with Some v -> ValueSome(unbox<int>(v)) | None -> ValueNone

        /// Try to get the LayoutBounds property in the visual element
        member internal x.TryLayoutBounds = match x.Attributes.TryFind("LayoutBounds") with Some v -> ValueSome(unbox<Xamarin.Forms.Rectangle>(v)) | None -> ValueNone

        /// Try to get the LayoutFlags property in the visual element
        member internal x.TryLayoutFlags = match x.Attributes.TryFind("LayoutFlags") with Some v -> ValueSome(unbox<Xamarin.Forms.AbsoluteLayoutFlags>(v)) | None -> ValueNone

        /// Try to get the BoundsConstraint property in the visual element
        member internal x.TryBoundsConstraint = match x.Attributes.TryFind("BoundsConstraint") with Some v -> ValueSome(unbox<Xamarin.Forms.BoundsConstraint>(v)) | None -> ValueNone

        /// Try to get the HeightConstraint property in the visual element
        member internal x.TryHeightConstraint = match x.Attributes.TryFind("HeightConstraint") with Some v -> ValueSome(unbox<Xamarin.Forms.Constraint>(v)) | None -> ValueNone

        /// Try to get the WidthConstraint property in the visual element
        member internal x.TryWidthConstraint = match x.Attributes.TryFind("WidthConstraint") with Some v -> ValueSome(unbox<Xamarin.Forms.Constraint>(v)) | None -> ValueNone

        /// Try to get the XConstraint property in the visual element
        member internal x.TryXConstraint = match x.Attributes.TryFind("XConstraint") with Some v -> ValueSome(unbox<Xamarin.Forms.Constraint>(v)) | None -> ValueNone

        /// Try to get the YConstraint property in the visual element
        member internal x.TryYConstraint = match x.Attributes.TryFind("YConstraint") with Some v -> ValueSome(unbox<Xamarin.Forms.Constraint>(v)) | None -> ValueNone

        /// Try to get the RowDefinitionHeight property in the visual element
        member internal x.TryRowDefinitionHeight = match x.Attributes.TryFind("RowDefinitionHeight") with Some v -> ValueSome(unbox<Xamarin.Forms.GridLength>(v)) | None -> ValueNone

        /// Try to get the ColumnDefinitionWidth property in the visual element
        member internal x.TryColumnDefinitionWidth = match x.Attributes.TryFind("ColumnDefinitionWidth") with Some v -> ValueSome(unbox<Xamarin.Forms.GridLength>(v)) | None -> ValueNone

        /// Try to get the Date property in the visual element
        member internal x.TryDate = match x.Attributes.TryFind("Date") with Some v -> ValueSome(unbox<System.DateTime>(v)) | None -> ValueNone

        /// Try to get the Format property in the visual element
        member internal x.TryFormat = match x.Attributes.TryFind("Format") with Some v -> ValueSome(unbox<string>(v)) | None -> ValueNone

        /// Try to get the MinimumDate property in the visual element
        member internal x.TryMinimumDate = match x.Attributes.TryFind("MinimumDate") with Some v -> ValueSome(unbox<System.DateTime>(v)) | None -> ValueNone

        /// Try to get the MaximumDate property in the visual element
        member internal x.TryMaximumDate = match x.Attributes.TryFind("MaximumDate") with Some v -> ValueSome(unbox<System.DateTime>(v)) | None -> ValueNone

        /// Try to get the DateSelected property in the visual element
        member internal x.TryDateSelected = match x.Attributes.TryFind("DateSelected") with Some v -> ValueSome(unbox<System.EventHandler<Xamarin.Forms.DateChangedEventArgs>>(v)) | None -> ValueNone

        /// Try to get the PickerItemsSource property in the visual element
        member internal x.TryPickerItemsSource = match x.Attributes.TryFind("PickerItemsSource") with Some v -> ValueSome(unbox<System.Collections.IList>(v)) | None -> ValueNone

        /// Try to get the SelectedIndex property in the visual element
        member internal x.TrySelectedIndex = match x.Attributes.TryFind("SelectedIndex") with Some v -> ValueSome(unbox<int>(v)) | None -> ValueNone

        /// Try to get the Title property in the visual element
        member internal x.TryTitle = match x.Attributes.TryFind("Title") with Some v -> ValueSome(unbox<string>(v)) | None -> ValueNone

        /// Try to get the SelectedIndexChanged property in the visual element
        member internal x.TrySelectedIndexChanged = match x.Attributes.TryFind("SelectedIndexChanged") with Some v -> ValueSome(unbox<System.EventHandler>(v)) | None -> ValueNone

        /// Try to get the OutlineColor property in the visual element
        member internal x.TryOutlineColor = match x.Attributes.TryFind("OutlineColor") with Some v -> ValueSome(unbox<Xamarin.Forms.Color>(v)) | None -> ValueNone

        /// Try to get the FrameCornerRadius property in the visual element
        member internal x.TryFrameCornerRadius = match x.Attributes.TryFind("FrameCornerRadius") with Some v -> ValueSome(unbox<single>(v)) | None -> ValueNone

        /// Try to get the HasShadow property in the visual element
        member internal x.TryHasShadow = match x.Attributes.TryFind("HasShadow") with Some v -> ValueSome(unbox<bool>(v)) | None -> ValueNone

        /// Try to get the ImageSource property in the visual element
        member internal x.TryImageSource = match x.Attributes.TryFind("ImageSource") with Some v -> ValueSome(unbox<string>(v)) | None -> ValueNone

        /// Try to get the Aspect property in the visual element
        member internal x.TryAspect = match x.Attributes.TryFind("Aspect") with Some v -> ValueSome(unbox<Xamarin.Forms.Aspect>(v)) | None -> ValueNone

        /// Try to get the IsOpaque property in the visual element
        member internal x.TryIsOpaque = match x.Attributes.TryFind("IsOpaque") with Some v -> ValueSome(unbox<bool>(v)) | None -> ValueNone

        /// Try to get the Keyboard property in the visual element
        member internal x.TryKeyboard = match x.Attributes.TryFind("Keyboard") with Some v -> ValueSome(unbox<Xamarin.Forms.Keyboard>(v)) | None -> ValueNone

        /// Try to get the EditorCompleted property in the visual element
        member internal x.TryEditorCompleted = match x.Attributes.TryFind("EditorCompleted") with Some v -> ValueSome(unbox<System.EventHandler>(v)) | None -> ValueNone

        /// Try to get the TextChanged property in the visual element
        member internal x.TryTextChanged = match x.Attributes.TryFind("TextChanged") with Some v -> ValueSome(unbox<System.EventHandler<Xamarin.Forms.TextChangedEventArgs>>(v)) | None -> ValueNone

        /// Try to get the IsPassword property in the visual element
        member internal x.TryIsPassword = match x.Attributes.TryFind("IsPassword") with Some v -> ValueSome(unbox<bool>(v)) | None -> ValueNone

        /// Try to get the EntryCompleted property in the visual element
        member internal x.TryEntryCompleted = match x.Attributes.TryFind("EntryCompleted") with Some v -> ValueSome(unbox<System.EventHandler>(v)) | None -> ValueNone

        /// Try to get the Label property in the visual element
        member internal x.TryLabel = match x.Attributes.TryFind("Label") with Some v -> ValueSome(unbox<string>(v)) | None -> ValueNone

        /// Try to get the VerticalTextAlignment property in the visual element
        member internal x.TryVerticalTextAlignment = match x.Attributes.TryFind("VerticalTextAlignment") with Some v -> ValueSome(unbox<Xamarin.Forms.TextAlignment>(v)) | None -> ValueNone

        /// Try to get the IsClippedToBounds property in the visual element
        member internal x.TryIsClippedToBounds = match x.Attributes.TryFind("IsClippedToBounds") with Some v -> ValueSome(unbox<bool>(v)) | None -> ValueNone

        /// Try to get the Padding property in the visual element
        member internal x.TryPadding = match x.Attributes.TryFind("Padding") with Some v -> ValueSome(unbox<Xamarin.Forms.Thickness>(v)) | None -> ValueNone

        /// Try to get the StackOrientation property in the visual element
        member internal x.TryStackOrientation = match x.Attributes.TryFind("StackOrientation") with Some v -> ValueSome(unbox<Xamarin.Forms.StackOrientation>(v)) | None -> ValueNone

        /// Try to get the Spacing property in the visual element
        member internal x.TrySpacing = match x.Attributes.TryFind("Spacing") with Some v -> ValueSome(unbox<double>(v)) | None -> ValueNone

        /// Try to get the ForegroundColor property in the visual element
        member internal x.TryForegroundColor = match x.Attributes.TryFind("ForegroundColor") with Some v -> ValueSome(unbox<Xamarin.Forms.Color>(v)) | None -> ValueNone

        /// Try to get the PropertyChanged property in the visual element
        member internal x.TryPropertyChanged = match x.Attributes.TryFind("PropertyChanged") with Some v -> ValueSome(unbox<System.ComponentModel.PropertyChangedEventHandler>(v)) | None -> ValueNone

        /// Try to get the Time property in the visual element
        member internal x.TryTime = match x.Attributes.TryFind("Time") with Some v -> ValueSome(unbox<System.TimeSpan>(v)) | None -> ValueNone

        /// Try to get the WebSource property in the visual element
        member internal x.TryWebSource = match x.Attributes.TryFind("WebSource") with Some v -> ValueSome(unbox<Xamarin.Forms.WebViewSource>(v)) | None -> ValueNone

        /// Try to get the Navigated property in the visual element
        member internal x.TryNavigated = match x.Attributes.TryFind("Navigated") with Some v -> ValueSome(unbox<System.EventHandler<Xamarin.Forms.WebNavigatedEventArgs>>(v)) | None -> ValueNone

        /// Try to get the Navigating property in the visual element
        member internal x.TryNavigating = match x.Attributes.TryFind("Navigating") with Some v -> ValueSome(unbox<System.EventHandler<Xamarin.Forms.WebNavigatingEventArgs>>(v)) | None -> ValueNone

        /// Try to get the UseSafeArea property in the visual element
        member internal x.TryUseSafeArea = match x.Attributes.TryFind("UseSafeArea") with Some v -> ValueSome(unbox<bool>(v)) | None -> ValueNone

        /// Try to get the CarouselPage_SelectedItem property in the visual element
        member internal x.TryCarouselPage_SelectedItem = match x.Attributes.TryFind("CarouselPage_SelectedItem") with Some v -> ValueSome(unbox<System.Object>(v)) | None -> ValueNone

        /// Try to get the CurrentPage property in the visual element
        member internal x.TryCurrentPage = match x.Attributes.TryFind("CurrentPage") with Some v -> ValueSome(unbox<XamlElement>(v)) | None -> ValueNone

        /// Try to get the CurrentPageChanged property in the visual element
        member internal x.TryCurrentPageChanged = match x.Attributes.TryFind("CurrentPageChanged") with Some v -> ValueSome(unbox<System.EventHandler>(v)) | None -> ValueNone

        /// Try to get the NavigationPagePages property in the visual element
        member internal x.TryNavigationPagePages = match x.Attributes.TryFind("NavigationPagePages") with Some v -> ValueSome(unbox<XamlElement[]>(v)) | None -> ValueNone

        /// Try to get the BackButtonTitle property in the visual element
        member internal x.TryBackButtonTitle = match x.Attributes.TryFind("BackButtonTitle") with Some v -> ValueSome(unbox<string>(v)) | None -> ValueNone

        /// Try to get the HasBackButton property in the visual element
        member internal x.TryHasBackButton = match x.Attributes.TryFind("HasBackButton") with Some v -> ValueSome(unbox<bool>(v)) | None -> ValueNone

        /// Try to get the HasNavigationBar property in the visual element
        member internal x.TryHasNavigationBar = match x.Attributes.TryFind("HasNavigationBar") with Some v -> ValueSome(unbox<bool>(v)) | None -> ValueNone

        /// Try to get the TitleIcon property in the visual element
        member internal x.TryTitleIcon = match x.Attributes.TryFind("TitleIcon") with Some v -> ValueSome(unbox<string>(v)) | None -> ValueNone

        /// Try to get the BarBackgroundColor property in the visual element
        member internal x.TryBarBackgroundColor = match x.Attributes.TryFind("BarBackgroundColor") with Some v -> ValueSome(unbox<Xamarin.Forms.Color>(v)) | None -> ValueNone

        /// Try to get the BarTextColor property in the visual element
        member internal x.TryBarTextColor = match x.Attributes.TryFind("BarTextColor") with Some v -> ValueSome(unbox<Xamarin.Forms.Color>(v)) | None -> ValueNone

        /// Try to get the Popped property in the visual element
        member internal x.TryPopped = match x.Attributes.TryFind("Popped") with Some v -> ValueSome(unbox<System.EventHandler<Xamarin.Forms.NavigationEventArgs>>(v)) | None -> ValueNone

        /// Try to get the PoppedToRoot property in the visual element
        member internal x.TryPoppedToRoot = match x.Attributes.TryFind("PoppedToRoot") with Some v -> ValueSome(unbox<System.EventHandler<Xamarin.Forms.NavigationEventArgs>>(v)) | None -> ValueNone

        /// Try to get the Pushed property in the visual element
        member internal x.TryPushed = match x.Attributes.TryFind("Pushed") with Some v -> ValueSome(unbox<System.EventHandler<Xamarin.Forms.NavigationEventArgs>>(v)) | None -> ValueNone

        /// Try to get the OnSizeAllocatedCallback property in the visual element
        member internal x.TryOnSizeAllocatedCallback = match x.Attributes.TryFind("OnSizeAllocatedCallback") with Some v -> ValueSome(unbox<FSharp.Control.Handler<(double * double)>>(v)) | None -> ValueNone

        /// Try to get the Master property in the visual element
        member internal x.TryMaster = match x.Attributes.TryFind("Master") with Some v -> ValueSome(unbox<XamlElement>(v)) | None -> ValueNone

        /// Try to get the Detail property in the visual element
        member internal x.TryDetail = match x.Attributes.TryFind("Detail") with Some v -> ValueSome(unbox<XamlElement>(v)) | None -> ValueNone

        /// Try to get the IsGestureEnabled property in the visual element
        member internal x.TryIsGestureEnabled = match x.Attributes.TryFind("IsGestureEnabled") with Some v -> ValueSome(unbox<bool>(v)) | None -> ValueNone

        /// Try to get the IsPresented property in the visual element
        member internal x.TryIsPresented = match x.Attributes.TryFind("IsPresented") with Some v -> ValueSome(unbox<bool>(v)) | None -> ValueNone

        /// Try to get the MasterBehavior property in the visual element
        member internal x.TryMasterBehavior = match x.Attributes.TryFind("MasterBehavior") with Some v -> ValueSome(unbox<Xamarin.Forms.MasterBehavior>(v)) | None -> ValueNone

        /// Try to get the IsPresentedChanged property in the visual element
        member internal x.TryIsPresentedChanged = match x.Attributes.TryFind("IsPresentedChanged") with Some v -> ValueSome(unbox<System.EventHandler>(v)) | None -> ValueNone

        /// Try to get the Height property in the visual element
        member internal x.TryHeight = match x.Attributes.TryFind("Height") with Some v -> ValueSome(unbox<double>(v)) | None -> ValueNone

        /// Try to get the TextDetail property in the visual element
        member internal x.TryTextDetail = match x.Attributes.TryFind("TextDetail") with Some v -> ValueSome(unbox<string>(v)) | None -> ValueNone

        /// Try to get the TextDetailColor property in the visual element
        member internal x.TryTextDetailColor = match x.Attributes.TryFind("TextDetailColor") with Some v -> ValueSome(unbox<Xamarin.Forms.Color>(v)) | None -> ValueNone

        /// Try to get the TextCellCommand property in the visual element
        member internal x.TryTextCellCommand = match x.Attributes.TryFind("TextCellCommand") with Some v -> ValueSome(unbox<unit -> unit>(v)) | None -> ValueNone

        /// Try to get the TextCellCanExecute property in the visual element
        member internal x.TryTextCellCanExecute = match x.Attributes.TryFind("TextCellCanExecute") with Some v -> ValueSome(unbox<bool>(v)) | None -> ValueNone

        /// Try to get the View property in the visual element
        member internal x.TryView = match x.Attributes.TryFind("View") with Some v -> ValueSome(unbox<XamlElement>(v)) | None -> ValueNone

        /// Try to get the ListViewItems property in the visual element
        member internal x.TryListViewItems = match x.Attributes.TryFind("ListViewItems") with Some v -> ValueSome(unbox<seq<XamlElement>>(v)) | None -> ValueNone

        /// Try to get the Footer property in the visual element
        member internal x.TryFooter = match x.Attributes.TryFind("Footer") with Some v -> ValueSome(unbox<System.Object>(v)) | None -> ValueNone

        /// Try to get the Header property in the visual element
        member internal x.TryHeader = match x.Attributes.TryFind("Header") with Some v -> ValueSome(unbox<System.Object>(v)) | None -> ValueNone

        /// Try to get the HeaderTemplate property in the visual element
        member internal x.TryHeaderTemplate = match x.Attributes.TryFind("HeaderTemplate") with Some v -> ValueSome(unbox<Xamarin.Forms.DataTemplate>(v)) | None -> ValueNone

        /// Try to get the IsGroupingEnabled property in the visual element
        member internal x.TryIsGroupingEnabled = match x.Attributes.TryFind("IsGroupingEnabled") with Some v -> ValueSome(unbox<bool>(v)) | None -> ValueNone

        /// Try to get the IsPullToRefreshEnabled property in the visual element
        member internal x.TryIsPullToRefreshEnabled = match x.Attributes.TryFind("IsPullToRefreshEnabled") with Some v -> ValueSome(unbox<bool>(v)) | None -> ValueNone

        /// Try to get the IsRefreshing property in the visual element
        member internal x.TryIsRefreshing = match x.Attributes.TryFind("IsRefreshing") with Some v -> ValueSome(unbox<bool>(v)) | None -> ValueNone

        /// Try to get the RefreshCommand property in the visual element
        member internal x.TryRefreshCommand = match x.Attributes.TryFind("RefreshCommand") with Some v -> ValueSome(unbox<System.Windows.Input.ICommand>(v)) | None -> ValueNone

        /// Try to get the ListView_SelectedItem property in the visual element
        member internal x.TryListView_SelectedItem = match x.Attributes.TryFind("ListView_SelectedItem") with Some v -> ValueSome(unbox<int option>(v)) | None -> ValueNone

        /// Try to get the SeparatorVisibility property in the visual element
        member internal x.TrySeparatorVisibility = match x.Attributes.TryFind("SeparatorVisibility") with Some v -> ValueSome(unbox<Xamarin.Forms.SeparatorVisibility>(v)) | None -> ValueNone

        /// Try to get the SeparatorColor property in the visual element
        member internal x.TrySeparatorColor = match x.Attributes.TryFind("SeparatorColor") with Some v -> ValueSome(unbox<Xamarin.Forms.Color>(v)) | None -> ValueNone

        /// Try to get the ListView_ItemAppearing property in the visual element
        member internal x.TryListView_ItemAppearing = match x.Attributes.TryFind("ListView_ItemAppearing") with Some v -> ValueSome(unbox<System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>>(v)) | None -> ValueNone

        /// Try to get the ListView_ItemDisappearing property in the visual element
        member internal x.TryListView_ItemDisappearing = match x.Attributes.TryFind("ListView_ItemDisappearing") with Some v -> ValueSome(unbox<System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>>(v)) | None -> ValueNone

        /// Try to get the ListView_ItemSelected property in the visual element
        member internal x.TryListView_ItemSelected = match x.Attributes.TryFind("ListView_ItemSelected") with Some v -> ValueSome(unbox<System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>>(v)) | None -> ValueNone

        /// Try to get the ListView_ItemTapped property in the visual element
        member internal x.TryListView_ItemTapped = match x.Attributes.TryFind("ListView_ItemTapped") with Some v -> ValueSome(unbox<System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>>(v)) | None -> ValueNone

        /// Try to get the Refreshing property in the visual element
        member internal x.TryRefreshing = match x.Attributes.TryFind("Refreshing") with Some v -> ValueSome(unbox<System.EventHandler>(v)) | None -> ValueNone

        /// Try to get the GroupListViewItemsSource property in the visual element
        member internal x.TryGroupListViewItemsSource = match x.Attributes.TryFind("GroupListViewItemsSource") with Some v -> ValueSome(unbox<(XamlElement * XamlElement[])[]>(v)) | None -> ValueNone

        /// Try to get the ListViewGrouped_SelectedItem property in the visual element
        member internal x.TryListViewGrouped_SelectedItem = match x.Attributes.TryFind("ListViewGrouped_SelectedItem") with Some v -> ValueSome(unbox<(int * int) option>(v)) | None -> ValueNone

        /// Try to get the ListViewGrouped_ItemAppearing property in the visual element
        member internal x.TryListViewGrouped_ItemAppearing = match x.Attributes.TryFind("ListViewGrouped_ItemAppearing") with Some v -> ValueSome(unbox<System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>>(v)) | None -> ValueNone

        /// Try to get the ListViewGrouped_ItemDisappearing property in the visual element
        member internal x.TryListViewGrouped_ItemDisappearing = match x.Attributes.TryFind("ListViewGrouped_ItemDisappearing") with Some v -> ValueSome(unbox<System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>>(v)) | None -> ValueNone

        /// Try to get the ListViewGrouped_ItemSelected property in the visual element
        member internal x.TryListViewGrouped_ItemSelected = match x.Attributes.TryFind("ListViewGrouped_ItemSelected") with Some v -> ValueSome(unbox<System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>>(v)) | None -> ValueNone

        /// Try to get the ListViewGrouped_ItemTapped property in the visual element
        member internal x.TryListViewGrouped_ItemTapped = match x.Attributes.TryFind("ListViewGrouped_ItemTapped") with Some v -> ValueSome(unbox<System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>>(v)) | None -> ValueNone

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

        /// Adjusts the NavigationPagePages property in the visual element
        member x.NavigationPagePages(value: XamlElement list) = x.WithAttribute("NavigationPagePages", box (Array.ofList(value)))

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

        /// Adjusts the SeparatorVisibility property in the visual element
        member x.SeparatorVisibility(value: Xamarin.Forms.SeparatorVisibility) = x.WithAttribute("SeparatorVisibility", box ((value)))

        /// Adjusts the SeparatorColor property in the visual element
        member x.SeparatorColor(value: Xamarin.Forms.Color) = x.WithAttribute("SeparatorColor", box ((value)))

        /// Adjusts the ListView_ItemAppearing property in the visual element
        member x.ListView_ItemAppearing(value: int -> unit) = x.WithAttribute("ListView_ItemAppearing", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(value)))

        /// Adjusts the ListView_ItemDisappearing property in the visual element
        member x.ListView_ItemDisappearing(value: int -> unit) = x.WithAttribute("ListView_ItemDisappearing", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(value)))

        /// Adjusts the ListView_ItemSelected property in the visual element
        member x.ListView_ItemSelected(value: int option -> unit) = x.WithAttribute("ListView_ItemSelected", box ((fun f -> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args -> f (tryFindListViewItem sender args.SelectedItem)))(value)))

        /// Adjusts the ListView_ItemTapped property in the visual element
        member x.ListView_ItemTapped(value: int -> unit) = x.WithAttribute("ListView_ItemTapped", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(value)))

        /// Adjusts the Refreshing property in the visual element
        member x.Refreshing(value: unit -> unit) = x.WithAttribute("Refreshing", box ((fun f -> System.EventHandler(fun sender args -> f ()))(value)))

        /// Adjusts the GroupListViewItemsSource property in the visual element
        member x.GroupListViewItemsSource(value: (XamlElement * XamlElement list) list) = x.WithAttribute("GroupListViewItemsSource", box ((fun es -> es |> Array.ofList |> Array.map (fun (e,l) -> (e, Array.ofList l)))(value)))

        /// Adjusts the ListViewGrouped_SelectedItem property in the visual element
        member x.ListViewGrouped_SelectedItem(value: (int * int) option) = x.WithAttribute("ListViewGrouped_SelectedItem", box ((value)))

        /// Adjusts the ListViewGrouped_ItemAppearing property in the visual element
        member x.ListViewGrouped_ItemAppearing(value: int * int -> unit) = x.WithAttribute("ListViewGrouped_ItemAppearing", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(value)))

        /// Adjusts the ListViewGrouped_ItemDisappearing property in the visual element
        member x.ListViewGrouped_ItemDisappearing(value: int * int -> unit) = x.WithAttribute("ListViewGrouped_ItemDisappearing", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(value)))

        /// Adjusts the ListViewGrouped_ItemSelected property in the visual element
        member x.ListViewGrouped_ItemSelected(value: (int * int) option -> unit) = x.WithAttribute("ListViewGrouped_ItemSelected", box ((fun f -> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.SelectedItem)))(value)))

        /// Adjusts the ListViewGrouped_ItemTapped property in the visual element
        member x.ListViewGrouped_ItemTapped(value: int * int -> unit) = x.WithAttribute("ListViewGrouped_ItemTapped", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(value)))


    /// Adjusts the ClassId property in the visual element
    let classId (value: string) (x: XamlElement) = x.ClassId(value)

    /// Adjusts the StyleId property in the visual element
    let styleId (value: string) (x: XamlElement) = x.StyleId(value)

    /// Adjusts the AnchorX property in the visual element
    let anchorX (value: double) (x: XamlElement) = x.AnchorX(value)

    /// Adjusts the AnchorY property in the visual element
    let anchorY (value: double) (x: XamlElement) = x.AnchorY(value)

    /// Adjusts the BackgroundColor property in the visual element
    let backgroundColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.BackgroundColor(value)

    /// Adjusts the HeightRequest property in the visual element
    let heightRequest (value: double) (x: XamlElement) = x.HeightRequest(value)

    /// Adjusts the InputTransparent property in the visual element
    let inputTransparent (value: bool) (x: XamlElement) = x.InputTransparent(value)

    /// Adjusts the IsEnabled property in the visual element
    let isEnabled (value: bool) (x: XamlElement) = x.IsEnabled(value)

    /// Adjusts the IsVisible property in the visual element
    let isVisible (value: bool) (x: XamlElement) = x.IsVisible(value)

    /// Adjusts the MinimumHeightRequest property in the visual element
    let minimumHeightRequest (value: double) (x: XamlElement) = x.MinimumHeightRequest(value)

    /// Adjusts the MinimumWidthRequest property in the visual element
    let minimumWidthRequest (value: double) (x: XamlElement) = x.MinimumWidthRequest(value)

    /// Adjusts the Opacity property in the visual element
    let opacity (value: double) (x: XamlElement) = x.Opacity(value)

    /// Adjusts the Rotation property in the visual element
    let rotation (value: double) (x: XamlElement) = x.Rotation(value)

    /// Adjusts the RotationX property in the visual element
    let rotationX (value: double) (x: XamlElement) = x.RotationX(value)

    /// Adjusts the RotationY property in the visual element
    let rotationY (value: double) (x: XamlElement) = x.RotationY(value)

    /// Adjusts the Scale property in the visual element
    let scale (value: double) (x: XamlElement) = x.Scale(value)

    /// Adjusts the Style property in the visual element
    let style (value: Xamarin.Forms.Style) (x: XamlElement) = x.Style(value)

    /// Adjusts the TranslationX property in the visual element
    let translationX (value: double) (x: XamlElement) = x.TranslationX(value)

    /// Adjusts the TranslationY property in the visual element
    let translationY (value: double) (x: XamlElement) = x.TranslationY(value)

    /// Adjusts the WidthRequest property in the visual element
    let widthRequest (value: double) (x: XamlElement) = x.WidthRequest(value)

    /// Adjusts the HorizontalOptions property in the visual element
    let horizontalOptions (value: Xamarin.Forms.LayoutOptions) (x: XamlElement) = x.HorizontalOptions(value)

    /// Adjusts the VerticalOptions property in the visual element
    let verticalOptions (value: Xamarin.Forms.LayoutOptions) (x: XamlElement) = x.VerticalOptions(value)

    /// Adjusts the Margin property in the visual element
    let margin (value: obj) (x: XamlElement) = x.Margin(value)

    /// Adjusts the GestureRecognizers property in the visual element
    let gestureRecognizers (value: XamlElement list) (x: XamlElement) = x.GestureRecognizers(value)

    /// Adjusts the TouchPoints property in the visual element
    let touchPoints (value: int) (x: XamlElement) = x.TouchPoints(value)

    /// Adjusts the PanUpdated property in the visual element
    let panUpdated (value: Xamarin.Forms.PanUpdatedEventArgs -> unit) (x: XamlElement) = x.PanUpdated(value)

    /// Adjusts the Command property in the visual element
    let command (value: unit -> unit) (x: XamlElement) = x.Command(value)

    /// Adjusts the NumberOfTapsRequired property in the visual element
    let numberOfTapsRequired (value: int) (x: XamlElement) = x.NumberOfTapsRequired(value)

    /// Adjusts the NumberOfClicksRequired property in the visual element
    let numberOfClicksRequired (value: int) (x: XamlElement) = x.NumberOfClicksRequired(value)

    /// Adjusts the Buttons property in the visual element
    let buttons (value: Xamarin.Forms.ButtonsMask) (x: XamlElement) = x.Buttons(value)

    /// Adjusts the IsPinching property in the visual element
    let isPinching (value: bool) (x: XamlElement) = x.IsPinching(value)

    /// Adjusts the PinchUpdated property in the visual element
    let pinchUpdated (value: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit) (x: XamlElement) = x.PinchUpdated(value)

    /// Adjusts the Color property in the visual element
    let color (value: Xamarin.Forms.Color) (x: XamlElement) = x.Color(value)

    /// Adjusts the IsRunning property in the visual element
    let isRunning (value: bool) (x: XamlElement) = x.IsRunning(value)

    /// Adjusts the Progress property in the visual element
    let progress (value: double) (x: XamlElement) = x.Progress(value)

    /// Adjusts the Content property in the visual element
    let content (value: XamlElement) (x: XamlElement) = x.Content(value)

    /// Adjusts the ScrollOrientation property in the visual element
    let scrollOrientation (value: Xamarin.Forms.ScrollOrientation) (x: XamlElement) = x.ScrollOrientation(value)

    /// Adjusts the CancelButtonColor property in the visual element
    let cancelButtonColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.CancelButtonColor(value)

    /// Adjusts the FontFamily property in the visual element
    let fontFamily (value: string) (x: XamlElement) = x.FontFamily(value)

    /// Adjusts the FontAttributes property in the visual element
    let fontAttributes (value: Xamarin.Forms.FontAttributes) (x: XamlElement) = x.FontAttributes(value)

    /// Adjusts the FontSize property in the visual element
    let fontSize (value: obj) (x: XamlElement) = x.FontSize(value)

    /// Adjusts the HorizontalTextAlignment property in the visual element
    let horizontalTextAlignment (value: Xamarin.Forms.TextAlignment) (x: XamlElement) = x.HorizontalTextAlignment(value)

    /// Adjusts the Placeholder property in the visual element
    let placeholder (value: string) (x: XamlElement) = x.Placeholder(value)

    /// Adjusts the PlaceholderColor property in the visual element
    let placeholderColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.PlaceholderColor(value)

    /// Adjusts the SearchBarCommand property in the visual element
    let searchBarCommand (value: unit -> unit) (x: XamlElement) = x.SearchBarCommand(value)

    /// Adjusts the SearchBarCanExecute property in the visual element
    let searchBarCanExecute (value: bool) (x: XamlElement) = x.SearchBarCanExecute(value)

    /// Adjusts the Text property in the visual element
    let text (value: string) (x: XamlElement) = x.Text(value)

    /// Adjusts the TextColor property in the visual element
    let textColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.TextColor(value)

    /// Adjusts the ButtonCommand property in the visual element
    let buttonCommand (value: unit -> unit) (x: XamlElement) = x.ButtonCommand(value)

    /// Adjusts the ButtonCanExecute property in the visual element
    let buttonCanExecute (value: bool) (x: XamlElement) = x.ButtonCanExecute(value)

    /// Adjusts the BorderColor property in the visual element
    let borderColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.BorderColor(value)

    /// Adjusts the BorderWidth property in the visual element
    let borderWidth (value: double) (x: XamlElement) = x.BorderWidth(value)

    /// Adjusts the CommandParameter property in the visual element
    let commandParameter (value: System.Object) (x: XamlElement) = x.CommandParameter(value)

    /// Adjusts the ContentLayout property in the visual element
    let contentLayout (value: Xamarin.Forms.Button.ButtonContentLayout) (x: XamlElement) = x.ContentLayout(value)

    /// Adjusts the ButtonImageSource property in the visual element
    let buttonImageSource (value: string) (x: XamlElement) = x.ButtonImageSource(value)

    /// Adjusts the Minimum property in the visual element
    let minimum (value: double) (x: XamlElement) = x.Minimum(value)

    /// Adjusts the Maximum property in the visual element
    let maximum (value: double) (x: XamlElement) = x.Maximum(value)

    /// Adjusts the Value property in the visual element
    let value (value: double) (x: XamlElement) = x.Value(value)

    /// Adjusts the ValueChanged property in the visual element
    let valueChanged (value: Xamarin.Forms.ValueChangedEventArgs -> unit) (x: XamlElement) = x.ValueChanged(value)

    /// Adjusts the Increment property in the visual element
    let increment (value: double) (x: XamlElement) = x.Increment(value)

    /// Adjusts the IsToggled property in the visual element
    let isToggled (value: bool) (x: XamlElement) = x.IsToggled(value)

    /// Adjusts the Toggled property in the visual element
    let toggled (value: Xamarin.Forms.ToggledEventArgs -> unit) (x: XamlElement) = x.Toggled(value)

    /// Adjusts the On property in the visual element
    let on (value: bool) (x: XamlElement) = x.On(value)

    /// Adjusts the OnChanged property in the visual element
    let onChanged (value: Xamarin.Forms.ToggledEventArgs -> unit) (x: XamlElement) = x.OnChanged(value)

    /// Adjusts the Intent property in the visual element
    let intent (value: Xamarin.Forms.TableIntent) (x: XamlElement) = x.Intent(value)

    /// Adjusts the HasUnevenRows property in the visual element
    let hasUnevenRows (value: bool) (x: XamlElement) = x.HasUnevenRows(value)

    /// Adjusts the RowHeight property in the visual element
    let rowHeight (value: int) (x: XamlElement) = x.RowHeight(value)

    /// Adjusts the TableRoot property in the visual element
    let tableRoot (value: (string * XamlElement list) list) (x: XamlElement) = x.TableRoot(value)

    /// Adjusts the GridRowDefinitions property in the visual element
    let gridRowDefinitions (value: obj list) (x: XamlElement) = x.GridRowDefinitions(value)

    /// Adjusts the GridColumnDefinitions property in the visual element
    let gridColumnDefinitions (value: obj list) (x: XamlElement) = x.GridColumnDefinitions(value)

    /// Adjusts the RowSpacing property in the visual element
    let rowSpacing (value: double) (x: XamlElement) = x.RowSpacing(value)

    /// Adjusts the ColumnSpacing property in the visual element
    let columnSpacing (value: double) (x: XamlElement) = x.ColumnSpacing(value)

    /// Adjusts the Children property in the visual element
    let children (value: XamlElement list) (x: XamlElement) = x.Children(value)

    /// Adjusts the GridRow property in the visual element
    let gridRow (value: int) (x: XamlElement) = x.GridRow(value)

    /// Adjusts the GridRowSpan property in the visual element
    let gridRowSpan (value: int) (x: XamlElement) = x.GridRowSpan(value)

    /// Adjusts the GridColumn property in the visual element
    let gridColumn (value: int) (x: XamlElement) = x.GridColumn(value)

    /// Adjusts the GridColumnSpan property in the visual element
    let gridColumnSpan (value: int) (x: XamlElement) = x.GridColumnSpan(value)

    /// Adjusts the LayoutBounds property in the visual element
    let layoutBounds (value: Xamarin.Forms.Rectangle) (x: XamlElement) = x.LayoutBounds(value)

    /// Adjusts the LayoutFlags property in the visual element
    let layoutFlags (value: Xamarin.Forms.AbsoluteLayoutFlags) (x: XamlElement) = x.LayoutFlags(value)

    /// Adjusts the BoundsConstraint property in the visual element
    let boundsConstraint (value: Xamarin.Forms.BoundsConstraint) (x: XamlElement) = x.BoundsConstraint(value)

    /// Adjusts the HeightConstraint property in the visual element
    let heightConstraint (value: Xamarin.Forms.Constraint) (x: XamlElement) = x.HeightConstraint(value)

    /// Adjusts the WidthConstraint property in the visual element
    let widthConstraint (value: Xamarin.Forms.Constraint) (x: XamlElement) = x.WidthConstraint(value)

    /// Adjusts the XConstraint property in the visual element
    let xConstraint (value: Xamarin.Forms.Constraint) (x: XamlElement) = x.XConstraint(value)

    /// Adjusts the YConstraint property in the visual element
    let yConstraint (value: Xamarin.Forms.Constraint) (x: XamlElement) = x.YConstraint(value)

    /// Adjusts the RowDefinitionHeight property in the visual element
    let rowDefinitionHeight (value: obj) (x: XamlElement) = x.RowDefinitionHeight(value)

    /// Adjusts the ColumnDefinitionWidth property in the visual element
    let columnDefinitionWidth (value: obj) (x: XamlElement) = x.ColumnDefinitionWidth(value)

    /// Adjusts the Date property in the visual element
    let date (value: System.DateTime) (x: XamlElement) = x.Date(value)

    /// Adjusts the Format property in the visual element
    let format (value: string) (x: XamlElement) = x.Format(value)

    /// Adjusts the MinimumDate property in the visual element
    let minimumDate (value: System.DateTime) (x: XamlElement) = x.MinimumDate(value)

    /// Adjusts the MaximumDate property in the visual element
    let maximumDate (value: System.DateTime) (x: XamlElement) = x.MaximumDate(value)

    /// Adjusts the DateSelected property in the visual element
    let dateSelected (value: Xamarin.Forms.DateChangedEventArgs -> unit) (x: XamlElement) = x.DateSelected(value)

    /// Adjusts the PickerItemsSource property in the visual element
    let pickerItemsSource (value: seq<'T>) (x: XamlElement) = x.PickerItemsSource(value)

    /// Adjusts the SelectedIndex property in the visual element
    let selectedIndex (value: int) (x: XamlElement) = x.SelectedIndex(value)

    /// Adjusts the Title property in the visual element
    let title (value: string) (x: XamlElement) = x.Title(value)

    /// Adjusts the SelectedIndexChanged property in the visual element
    let selectedIndexChanged (value: (int * 'T option) -> unit) (x: XamlElement) = x.SelectedIndexChanged(value)

    /// Adjusts the OutlineColor property in the visual element
    let outlineColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.OutlineColor(value)

    /// Adjusts the FrameCornerRadius property in the visual element
    let frameCornerRadius (value: single) (x: XamlElement) = x.FrameCornerRadius(value)

    /// Adjusts the HasShadow property in the visual element
    let hasShadow (value: bool) (x: XamlElement) = x.HasShadow(value)

    /// Adjusts the ImageSource property in the visual element
    let imageSource (value: string) (x: XamlElement) = x.ImageSource(value)

    /// Adjusts the Aspect property in the visual element
    let aspect (value: Xamarin.Forms.Aspect) (x: XamlElement) = x.Aspect(value)

    /// Adjusts the IsOpaque property in the visual element
    let isOpaque (value: bool) (x: XamlElement) = x.IsOpaque(value)

    /// Adjusts the Keyboard property in the visual element
    let keyboard (value: Xamarin.Forms.Keyboard) (x: XamlElement) = x.Keyboard(value)

    /// Adjusts the EditorCompleted property in the visual element
    let editorCompleted (value: string -> unit) (x: XamlElement) = x.EditorCompleted(value)

    /// Adjusts the TextChanged property in the visual element
    let textChanged (value: Xamarin.Forms.TextChangedEventArgs -> unit) (x: XamlElement) = x.TextChanged(value)

    /// Adjusts the IsPassword property in the visual element
    let isPassword (value: bool) (x: XamlElement) = x.IsPassword(value)

    /// Adjusts the EntryCompleted property in the visual element
    let entryCompleted (value: string -> unit) (x: XamlElement) = x.EntryCompleted(value)

    /// Adjusts the Label property in the visual element
    let label (value: string) (x: XamlElement) = x.Label(value)

    /// Adjusts the VerticalTextAlignment property in the visual element
    let verticalTextAlignment (value: Xamarin.Forms.TextAlignment) (x: XamlElement) = x.VerticalTextAlignment(value)

    /// Adjusts the IsClippedToBounds property in the visual element
    let isClippedToBounds (value: bool) (x: XamlElement) = x.IsClippedToBounds(value)

    /// Adjusts the Padding property in the visual element
    let padding (value: obj) (x: XamlElement) = x.Padding(value)

    /// Adjusts the StackOrientation property in the visual element
    let stackOrientation (value: Xamarin.Forms.StackOrientation) (x: XamlElement) = x.StackOrientation(value)

    /// Adjusts the Spacing property in the visual element
    let spacing (value: double) (x: XamlElement) = x.Spacing(value)

    /// Adjusts the ForegroundColor property in the visual element
    let foregroundColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.ForegroundColor(value)

    /// Adjusts the PropertyChanged property in the visual element
    let propertyChanged (value: System.ComponentModel.PropertyChangedEventArgs -> unit) (x: XamlElement) = x.PropertyChanged(value)

    /// Adjusts the Time property in the visual element
    let time (value: System.TimeSpan) (x: XamlElement) = x.Time(value)

    /// Adjusts the WebSource property in the visual element
    let webSource (value: Xamarin.Forms.WebViewSource) (x: XamlElement) = x.WebSource(value)

    /// Adjusts the Navigated property in the visual element
    let navigated (value: Xamarin.Forms.WebNavigatedEventArgs -> unit) (x: XamlElement) = x.Navigated(value)

    /// Adjusts the Navigating property in the visual element
    let navigating (value: Xamarin.Forms.WebNavigatingEventArgs -> unit) (x: XamlElement) = x.Navigating(value)

    /// Adjusts the UseSafeArea property in the visual element
    let useSafeArea (value: bool) (x: XamlElement) = x.UseSafeArea(value)

    /// Adjusts the CarouselPage_SelectedItem property in the visual element
    let carouselPage_SelectedItem (value: System.Object) (x: XamlElement) = x.CarouselPage_SelectedItem(value)

    /// Adjusts the CurrentPage property in the visual element
    let currentPage (value: XamlElement) (x: XamlElement) = x.CurrentPage(value)

    /// Adjusts the CurrentPageChanged property in the visual element
    let currentPageChanged (value: 'T option -> unit) (x: XamlElement) = x.CurrentPageChanged(value)

    /// Adjusts the NavigationPagePages property in the visual element
    let navigationPagePages (value: XamlElement list) (x: XamlElement) = x.NavigationPagePages(value)

    /// Adjusts the BackButtonTitle property in the visual element
    let backButtonTitle (value: string) (x: XamlElement) = x.BackButtonTitle(value)

    /// Adjusts the HasBackButton property in the visual element
    let hasBackButton (value: bool) (x: XamlElement) = x.HasBackButton(value)

    /// Adjusts the HasNavigationBar property in the visual element
    let hasNavigationBar (value: bool) (x: XamlElement) = x.HasNavigationBar(value)

    /// Adjusts the TitleIcon property in the visual element
    let titleIcon (value: string) (x: XamlElement) = x.TitleIcon(value)

    /// Adjusts the BarBackgroundColor property in the visual element
    let barBackgroundColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.BarBackgroundColor(value)

    /// Adjusts the BarTextColor property in the visual element
    let barTextColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.BarTextColor(value)

    /// Adjusts the Popped property in the visual element
    let popped (value: Xamarin.Forms.NavigationEventArgs -> unit) (x: XamlElement) = x.Popped(value)

    /// Adjusts the PoppedToRoot property in the visual element
    let poppedToRoot (value: Xamarin.Forms.NavigationEventArgs -> unit) (x: XamlElement) = x.PoppedToRoot(value)

    /// Adjusts the Pushed property in the visual element
    let pushed (value: Xamarin.Forms.NavigationEventArgs -> unit) (x: XamlElement) = x.Pushed(value)

    /// Adjusts the OnSizeAllocatedCallback property in the visual element
    let onSizeAllocatedCallback (value: (double * double) -> unit) (x: XamlElement) = x.OnSizeAllocatedCallback(value)

    /// Adjusts the Master property in the visual element
    let master (value: XamlElement) (x: XamlElement) = x.Master(value)

    /// Adjusts the Detail property in the visual element
    let detail (value: XamlElement) (x: XamlElement) = x.Detail(value)

    /// Adjusts the IsGestureEnabled property in the visual element
    let isGestureEnabled (value: bool) (x: XamlElement) = x.IsGestureEnabled(value)

    /// Adjusts the IsPresented property in the visual element
    let isPresented (value: bool) (x: XamlElement) = x.IsPresented(value)

    /// Adjusts the MasterBehavior property in the visual element
    let masterBehavior (value: Xamarin.Forms.MasterBehavior) (x: XamlElement) = x.MasterBehavior(value)

    /// Adjusts the IsPresentedChanged property in the visual element
    let isPresentedChanged (value: bool -> unit) (x: XamlElement) = x.IsPresentedChanged(value)

    /// Adjusts the Height property in the visual element
    let height (value: double) (x: XamlElement) = x.Height(value)

    /// Adjusts the TextDetail property in the visual element
    let textDetail (value: string) (x: XamlElement) = x.TextDetail(value)

    /// Adjusts the TextDetailColor property in the visual element
    let textDetailColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.TextDetailColor(value)

    /// Adjusts the TextCellCommand property in the visual element
    let textCellCommand (value: unit -> unit) (x: XamlElement) = x.TextCellCommand(value)

    /// Adjusts the TextCellCanExecute property in the visual element
    let textCellCanExecute (value: bool) (x: XamlElement) = x.TextCellCanExecute(value)

    /// Adjusts the View property in the visual element
    let view (value: XamlElement) (x: XamlElement) = x.View(value)

    /// Adjusts the ListViewItems property in the visual element
    let listViewItems (value: seq<XamlElement>) (x: XamlElement) = x.ListViewItems(value)

    /// Adjusts the Footer property in the visual element
    let footer (value: System.Object) (x: XamlElement) = x.Footer(value)

    /// Adjusts the Header property in the visual element
    let header (value: System.Object) (x: XamlElement) = x.Header(value)

    /// Adjusts the HeaderTemplate property in the visual element
    let headerTemplate (value: Xamarin.Forms.DataTemplate) (x: XamlElement) = x.HeaderTemplate(value)

    /// Adjusts the IsGroupingEnabled property in the visual element
    let isGroupingEnabled (value: bool) (x: XamlElement) = x.IsGroupingEnabled(value)

    /// Adjusts the IsPullToRefreshEnabled property in the visual element
    let isPullToRefreshEnabled (value: bool) (x: XamlElement) = x.IsPullToRefreshEnabled(value)

    /// Adjusts the IsRefreshing property in the visual element
    let isRefreshing (value: bool) (x: XamlElement) = x.IsRefreshing(value)

    /// Adjusts the RefreshCommand property in the visual element
    let refreshCommand (value: unit -> unit) (x: XamlElement) = x.RefreshCommand(value)

    /// Adjusts the ListView_SelectedItem property in the visual element
    let listView_SelectedItem (value: int option) (x: XamlElement) = x.ListView_SelectedItem(value)

    /// Adjusts the SeparatorVisibility property in the visual element
    let separatorVisibility (value: Xamarin.Forms.SeparatorVisibility) (x: XamlElement) = x.SeparatorVisibility(value)

    /// Adjusts the SeparatorColor property in the visual element
    let separatorColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.SeparatorColor(value)

    /// Adjusts the ListView_ItemAppearing property in the visual element
    let listView_ItemAppearing (value: int -> unit) (x: XamlElement) = x.ListView_ItemAppearing(value)

    /// Adjusts the ListView_ItemDisappearing property in the visual element
    let listView_ItemDisappearing (value: int -> unit) (x: XamlElement) = x.ListView_ItemDisappearing(value)

    /// Adjusts the ListView_ItemSelected property in the visual element
    let listView_ItemSelected (value: int option -> unit) (x: XamlElement) = x.ListView_ItemSelected(value)

    /// Adjusts the ListView_ItemTapped property in the visual element
    let listView_ItemTapped (value: int -> unit) (x: XamlElement) = x.ListView_ItemTapped(value)

    /// Adjusts the Refreshing property in the visual element
    let refreshing (value: unit -> unit) (x: XamlElement) = x.Refreshing(value)

    /// Adjusts the GroupListViewItemsSource property in the visual element
    let groupListViewItemsSource (value: (XamlElement * XamlElement list) list) (x: XamlElement) = x.GroupListViewItemsSource(value)

    /// Adjusts the ListViewGrouped_SelectedItem property in the visual element
    let listViewGrouped_SelectedItem (value: (int * int) option) (x: XamlElement) = x.ListViewGrouped_SelectedItem(value)

    /// Adjusts the ListViewGrouped_ItemAppearing property in the visual element
    let listViewGrouped_ItemAppearing (value: int * int -> unit) (x: XamlElement) = x.ListViewGrouped_ItemAppearing(value)

    /// Adjusts the ListViewGrouped_ItemDisappearing property in the visual element
    let listViewGrouped_ItemDisappearing (value: int * int -> unit) (x: XamlElement) = x.ListViewGrouped_ItemDisappearing(value)

    /// Adjusts the ListViewGrouped_ItemSelected property in the visual element
    let listViewGrouped_ItemSelected (value: (int * int) option -> unit) (x: XamlElement) = x.ListViewGrouped_ItemSelected(value)

    /// Adjusts the ListViewGrouped_ItemTapped property in the visual element
    let listViewGrouped_ItemTapped (value: int * int -> unit) (x: XamlElement) = x.ListViewGrouped_ItemTapped(value)

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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryClassId
            let valueOpt = source.TryClassId
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Element::ClassId "); target.ClassId <-  value
            | ValueSome _, ValueNone -> target.ClassId <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryStyleId
            let valueOpt = source.TryStyleId
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Element::StyleId "); target.StyleId <-  value
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryAnchorX
            let valueOpt = source.TryAnchorX
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::AnchorX "); target.AnchorX <-  value
            | ValueSome _, ValueNone -> target.AnchorX <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryAnchorY
            let valueOpt = source.TryAnchorY
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::AnchorY "); target.AnchorY <-  value
            | ValueSome _, ValueNone -> target.AnchorY <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::BackgroundColor "); target.BackgroundColor <-  value
            | ValueSome _, ValueNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryHeightRequest
            let valueOpt = source.TryHeightRequest
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::HeightRequest "); target.HeightRequest <-  value
            | ValueSome _, ValueNone -> target.HeightRequest <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryInputTransparent
            let valueOpt = source.TryInputTransparent
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::InputTransparent "); target.InputTransparent <-  value
            | ValueSome _, ValueNone -> target.InputTransparent <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::IsEnabled "); target.IsEnabled <-  value
            | ValueSome _, ValueNone -> target.IsEnabled <- true
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryIsVisible
            let valueOpt = source.TryIsVisible
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::IsVisible "); target.IsVisible <-  value
            | ValueSome _, ValueNone -> target.IsVisible <- true
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryMinimumHeightRequest
            let valueOpt = source.TryMinimumHeightRequest
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::MinimumHeightRequest "); target.MinimumHeightRequest <-  value
            | ValueSome _, ValueNone -> target.MinimumHeightRequest <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryMinimumWidthRequest
            let valueOpt = source.TryMinimumWidthRequest
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::MinimumWidthRequest "); target.MinimumWidthRequest <-  value
            | ValueSome _, ValueNone -> target.MinimumWidthRequest <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryOpacity
            let valueOpt = source.TryOpacity
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::Opacity "); target.Opacity <-  value
            | ValueSome _, ValueNone -> target.Opacity <- 1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryRotation
            let valueOpt = source.TryRotation
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::Rotation "); target.Rotation <-  value
            | ValueSome _, ValueNone -> target.Rotation <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryRotationX
            let valueOpt = source.TryRotationX
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::RotationX "); target.RotationX <-  value
            | ValueSome _, ValueNone -> target.RotationX <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryRotationY
            let valueOpt = source.TryRotationY
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::RotationY "); target.RotationY <-  value
            | ValueSome _, ValueNone -> target.RotationY <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryScale
            let valueOpt = source.TryScale
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::Scale "); target.Scale <-  value
            | ValueSome _, ValueNone -> target.Scale <- 1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryStyle
            let valueOpt = source.TryStyle
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::Style "); target.Style <-  value
            | ValueSome _, ValueNone -> target.Style <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryTranslationX
            let valueOpt = source.TryTranslationX
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::TranslationX "); target.TranslationX <-  value
            | ValueSome _, ValueNone -> target.TranslationX <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryTranslationY
            let valueOpt = source.TryTranslationY
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::TranslationY "); target.TranslationY <-  value
            | ValueSome _, ValueNone -> target.TranslationY <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryWidthRequest
            let valueOpt = source.TryWidthRequest
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting VisualElement::WidthRequest "); target.WidthRequest <-  value
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryHorizontalOptions
            let valueOpt = source.TryHorizontalOptions
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting View::HorizontalOptions "); target.HorizontalOptions <-  value
            | ValueSome _, ValueNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryVerticalOptions
            let valueOpt = source.TryVerticalOptions
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting View::VerticalOptions "); target.VerticalOptions <-  value
            | ValueSome _, ValueNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryMargin
            let valueOpt = source.TryMargin
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting View::Margin "); target.Margin <-  value
            | ValueSome _, ValueNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | ValueNone, ValueNone -> ()
            let prevCollOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGestureRecognizers
            let collOpt = source.TryGestureRecognizers
            updateIList prevCollOpt collOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.CreateAsIGestureRecognizer())
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryTouchPoints
            let valueOpt = source.TryTouchPoints
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting PanGestureRecognizer::TouchPoints "); target.TouchPoints <-  value
            | ValueSome _, ValueNone -> target.TouchPoints <- 1
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryPanUpdated
            match prevValueOpt, source.TryPanUpdated with
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryCommand
            let valueOpt = source.TryCommand
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting TapGestureRecognizer::Command "); target.Command <-  value
            | ValueSome _, ValueNone -> target.Command <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryNumberOfTapsRequired
            let valueOpt = source.TryNumberOfTapsRequired
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting TapGestureRecognizer::NumberOfTapsRequired "); target.NumberOfTapsRequired <-  value
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryCommand
            let valueOpt = source.TryCommand
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ClickGestureRecognizer::Command "); target.Command <-  value
            | ValueSome _, ValueNone -> target.Command <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryNumberOfClicksRequired
            let valueOpt = source.TryNumberOfClicksRequired
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ClickGestureRecognizer::NumberOfClicksRequired "); target.NumberOfClicksRequired <-  value
            | ValueSome _, ValueNone -> target.NumberOfClicksRequired <- 1
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryButtons
            let valueOpt = source.TryButtons
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ClickGestureRecognizer::Buttons "); target.Buttons <-  value
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryIsPinching
            let valueOpt = source.TryIsPinching
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting PinchGestureRecognizer::IsPinching "); target.IsPinching <-  value
            | ValueSome _, ValueNone -> target.IsPinching <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryPinchUpdated
            match prevValueOpt, source.TryPinchUpdated with
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryColor
            let valueOpt = source.TryColor
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ActivityIndicator::Color "); target.Color <-  value
            | ValueSome _, ValueNone -> target.Color <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryIsRunning
            let valueOpt = source.TryIsRunning
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ActivityIndicator::IsRunning "); target.IsRunning <-  value
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryColor
            let valueOpt = source.TryColor
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting BoxView::Color "); target.Color <-  value
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryProgress
            let valueOpt = source.TryProgress
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ProgressBar::Progress "); target.Progress <-  value
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
            let prevChildOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryContent
            match prevChildOpt, source.TryContent with
            // For structured objects, dependsOn on reference equality
            | ValueSome prevChild, ValueSome newChild when identical prevChild newChild -> ()
            | ValueSome prevChild, ValueSome newChild when canReuseChild prevChild newChild ->
                newChild.UpdateIncremental(prevChild, target.Content)
            | ValueSome _, ValueSome newChild
            | ValueNone, ValueSome newChild ->
                target.Content <- newChild.CreateAsView()
            | ValueSome _, ValueNone ->
                target.Content <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryScrollOrientation
            let valueOpt = source.TryScrollOrientation
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ScrollView::Orientation "); target.Orientation <-  value
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryCancelButtonColor
            let valueOpt = source.TryCancelButtonColor
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::CancelButtonColor "); target.CancelButtonColor <-  value
            | ValueSome _, ValueNone -> target.CancelButtonColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryFontFamily
            let valueOpt = source.TryFontFamily
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::FontFamily "); target.FontFamily <-  value
            | ValueSome _, ValueNone -> target.FontFamily <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryFontAttributes
            let valueOpt = source.TryFontAttributes
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::FontAttributes "); target.FontAttributes <-  value
            | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryFontSize
            let valueOpt = source.TryFontSize
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::FontSize "); target.FontSize <-  value
            | ValueSome _, ValueNone -> target.FontSize <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryHorizontalTextAlignment
            let valueOpt = source.TryHorizontalTextAlignment
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::HorizontalTextAlignment "); target.HorizontalTextAlignment <-  value
            | ValueSome _, ValueNone -> target.HorizontalTextAlignment <- Xamarin.Forms.TextAlignment.Start
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryPlaceholder
            let valueOpt = source.TryPlaceholder
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::Placeholder "); target.Placeholder <-  value
            | ValueSome _, ValueNone -> target.Placeholder <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryPlaceholderColor
            let valueOpt = source.TryPlaceholderColor
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::PlaceholderColor "); target.PlaceholderColor <-  value
            | ValueSome _, ValueNone -> target.PlaceholderColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TrySearchBarCommand
            let valueOpt = source.TrySearchBarCommand
            (fun _ _ _ -> ()) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TrySearchBarCanExecute
            let valueOpt = source.TrySearchBarCanExecute
            updateCommand (match prevOpt with ValueNone -> ValueNone | ValueSome prev -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::Command "); prev.TrySearchBarCommand) prevValueOpt source.TrySearchBarCommand valueOpt (fun cmd -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::Command "); target.SearchCommand <- cmd) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryText
            let valueOpt = source.TryText
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::Text "); target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryTextColor
            let valueOpt = source.TryTextColor
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting SearchBar::TextColor "); target.TextColor <-  value
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryText
            let valueOpt = source.TryText
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Button::Text "); target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryButtonCommand
            let valueOpt = source.TryButtonCommand
            (fun _ _ _ -> ()) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryButtonCanExecute
            let valueOpt = source.TryButtonCanExecute
            updateCommand (match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryButtonCommand) prevValueOpt source.TryButtonCommand valueOpt (fun cmd -> System.Diagnostics.Debug.WriteLine("Setting Button::Command "); target.Command <- cmd) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryBorderColor
            let valueOpt = source.TryBorderColor
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Button::BorderColor "); target.BorderColor <-  value
            | ValueSome _, ValueNone -> target.BorderColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryBorderWidth
            let valueOpt = source.TryBorderWidth
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Button::BorderWidth "); target.BorderWidth <-  value
            | ValueSome _, ValueNone -> target.BorderWidth <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryCommandParameter
            let valueOpt = source.TryCommandParameter
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Button::CommandParameter "); target.CommandParameter <-  value
            | ValueSome _, ValueNone -> target.CommandParameter <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryContentLayout
            let valueOpt = source.TryContentLayout
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Button::ContentLayout "); target.ContentLayout <-  value
            | ValueSome _, ValueNone -> target.ContentLayout <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryFontFamily
            let valueOpt = source.TryFontFamily
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Button::FontFamily "); target.FontFamily <-  value
            | ValueSome _, ValueNone -> target.FontFamily <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryFontAttributes
            let valueOpt = source.TryFontAttributes
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Button::FontAttributes "); target.FontAttributes <-  value
            | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryFontSize
            let valueOpt = source.TryFontSize
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Button::FontSize "); target.FontSize <-  value
            | ValueSome _, ValueNone -> target.FontSize <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryButtonImageSource
            let valueOpt = source.TryButtonImageSource
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Button::Image "); target.Image <- makeFileImageSource  value
            | ValueSome _, ValueNone -> target.Image <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryTextColor
            let valueOpt = source.TryTextColor
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Button::TextColor "); target.TextColor <-  value
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryMinimum
            let valueOpt = source.TryMinimum
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::Minimum "); target.Minimum <-  value
            | ValueSome _, ValueNone -> target.Minimum <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryMaximum
            let valueOpt = source.TryMaximum
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::Maximum "); target.Maximum <-  value
            | ValueSome _, ValueNone -> target.Maximum <- 1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryValue
            let valueOpt = source.TryValue
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Slider::Value "); target.Value <-  value
            | ValueSome _, ValueNone -> target.Value <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryValueChanged
            match prevValueOpt, source.TryValueChanged with
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryMinimum
            let valueOpt = source.TryMinimum
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::Minimum "); target.Minimum <-  value
            | ValueSome _, ValueNone -> target.Minimum <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryMaximum
            let valueOpt = source.TryMaximum
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::Maximum "); target.Maximum <-  value
            | ValueSome _, ValueNone -> target.Maximum <- 1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryValue
            let valueOpt = source.TryValue
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::Value "); target.Value <-  value
            | ValueSome _, ValueNone -> target.Value <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryIncrement
            let valueOpt = source.TryIncrement
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Stepper::Increment "); target.Increment <-  value
            | ValueSome _, ValueNone -> target.Increment <- 1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryValueChanged
            match prevValueOpt, source.TryValueChanged with
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryIsToggled
            let valueOpt = source.TryIsToggled
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Switch::IsToggled "); target.IsToggled <-  value
            | ValueSome _, ValueNone -> target.IsToggled <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryToggled
            match prevValueOpt, source.TryToggled with
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryOn
            let valueOpt = source.TryOn
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting SwitchCell::On "); target.On <-  value
            | ValueSome _, ValueNone -> target.On <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryText
            let valueOpt = source.TryText
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting SwitchCell::Text "); target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryOnChanged
            match prevValueOpt, source.TryOnChanged with
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryIntent
            let valueOpt = source.TryIntent
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::Intent "); target.Intent <-  value
            | ValueSome _, ValueNone -> target.Intent <- Unchecked.defaultof<Xamarin.Forms.TableIntent>
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryHasUnevenRows
            let valueOpt = source.TryHasUnevenRows
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::HasUnevenRows "); target.HasUnevenRows <-  value
            | ValueSome _, ValueNone -> target.HasUnevenRows <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryRowHeight
            let valueOpt = source.TryRowHeight
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting TableView::RowHeight "); target.RowHeight <-  value
            | ValueSome _, ValueNone -> target.RowHeight <- -1
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryTableRoot
            let valueOpt = source.TryTableRoot
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
            let prevCollOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGridRowDefinitions
            let collOpt = source.TryGridRowDefinitions
            updateIList prevCollOpt collOpt target.RowDefinitions
                (fun (x:XamlElement) -> x.CreateAsRowDefinition())
                (fun _ _ _ -> ())
                canReuseChild
                updateChild
            let prevCollOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGridColumnDefinitions
            let collOpt = source.TryGridColumnDefinitions
            updateIList prevCollOpt collOpt target.ColumnDefinitions
                (fun (x:XamlElement) -> x.CreateAsColumnDefinition())
                (fun _ _ _ -> ())
                canReuseChild
                updateChild
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryRowSpacing
            let valueOpt = source.TryRowSpacing
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::RowSpacing "); target.RowSpacing <-  value
            | ValueSome _, ValueNone -> target.RowSpacing <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryColumnSpacing
            let valueOpt = source.TryColumnSpacing
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Grid::ColumnSpacing "); target.ColumnSpacing <-  value
            | ValueSome _, ValueNone -> target.ColumnSpacing <- 0.0
            | ValueNone, ValueNone -> ()
            let prevCollOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryChildren
            let collOpt = source.TryChildren
            updateIList prevCollOpt collOpt target.Children
                (fun (x:XamlElement) -> x.CreateAsView())
                (fun prevChildOpt newChild targetChild -> 
                    // Adjust the attached properties
                    match (match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGridRow), newChild.TryGridRow with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.Grid.SetRow(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.Grid.SetRow(targetChild, 0) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    match (match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGridRowSpan), newChild.TryGridRowSpan with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.Grid.SetRowSpan(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.Grid.SetRowSpan(targetChild, 0) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    match (match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGridColumn), newChild.TryGridColumn with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.Grid.SetColumn(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.Grid.SetColumn(targetChild, 0) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    match (match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGridColumnSpan), newChild.TryGridColumnSpan with
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
            let prevCollOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryChildren
            let collOpt = source.TryChildren
            updateIList prevCollOpt collOpt target.Children
                (fun (x:XamlElement) -> x.CreateAsView())
                (fun prevChildOpt newChild targetChild -> 
                    // Adjust the attached properties
                    match (match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryLayoutBounds), newChild.TryLayoutBounds with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.AbsoluteLayout.SetLayoutBounds(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.AbsoluteLayout.SetLayoutBounds(targetChild, Xamarin.Forms.Rectangle.Zero) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    match (match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryLayoutFlags), newChild.TryLayoutFlags with
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
            let prevCollOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryChildren
            let collOpt = source.TryChildren
            updateIList prevCollOpt collOpt target.Children
                (fun (x:XamlElement) -> x.CreateAsView())
                (fun prevChildOpt newChild targetChild -> 
                    // Adjust the attached properties
                    match (match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryBoundsConstraint), newChild.TryBoundsConstraint with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.RelativeLayout.SetBoundsConstraint(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetBoundsConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    match (match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryHeightConstraint), newChild.TryHeightConstraint with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.RelativeLayout.SetHeightConstraint(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetHeightConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    match (match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryWidthConstraint), newChild.TryWidthConstraint with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.RelativeLayout.SetWidthConstraint(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetWidthConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    match (match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryXConstraint), newChild.TryXConstraint with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.RelativeLayout.SetXConstraint(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetXConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    match (match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryYConstraint), newChild.TryYConstraint with
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryRowDefinitionHeight
            let valueOpt = source.TryRowDefinitionHeight
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting RowDefinition::Height "); target.Height <-  value
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryColumnDefinitionWidth
            let valueOpt = source.TryColumnDefinitionWidth
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ColumnDefinition::Width "); target.Width <-  value
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
            let prevChildOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryContent
            match prevChildOpt, source.TryContent with
            // For structured objects, dependsOn on reference equality
            | ValueSome prevChild, ValueSome newChild when identical prevChild newChild -> ()
            | ValueSome prevChild, ValueSome newChild when canReuseChild prevChild newChild ->
                newChild.UpdateIncremental(prevChild, target.Content)
            | ValueSome _, ValueSome newChild
            | ValueNone, ValueSome newChild ->
                target.Content <- newChild.CreateAsView()
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryDate
            let valueOpt = source.TryDate
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::Date "); target.Date <-  value
            | ValueSome _, ValueNone -> target.Date <- Unchecked.defaultof<System.DateTime>
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryFormat
            let valueOpt = source.TryFormat
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::Format "); target.Format <-  value
            | ValueSome _, ValueNone -> target.Format <- "d"
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryMinimumDate
            let valueOpt = source.TryMinimumDate
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::MinimumDate "); target.MinimumDate <-  value
            | ValueSome _, ValueNone -> target.MinimumDate <- new System.DateTime(1900, 1, 1)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryMaximumDate
            let valueOpt = source.TryMaximumDate
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting DatePicker::MaximumDate "); target.MaximumDate <-  value
            | ValueSome _, ValueNone -> target.MaximumDate <- new System.DateTime(2100, 12, 31)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryDateSelected
            match prevValueOpt, source.TryDateSelected with
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryPickerItemsSource
            let valueOpt = source.TryPickerItemsSource
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::ItemsSource "); target.ItemsSource <-  value
            | ValueSome _, ValueNone -> target.ItemsSource <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TrySelectedIndex
            let valueOpt = source.TrySelectedIndex
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::SelectedIndex "); target.SelectedIndex <-  value
            | ValueSome _, ValueNone -> target.SelectedIndex <- 0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryTitle
            let valueOpt = source.TryTitle
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::Title "); target.Title <-  value
            | ValueSome _, ValueNone -> target.Title <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryTextColor
            let valueOpt = source.TryTextColor
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Picker::TextColor "); target.TextColor <-  value
            | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TrySelectedIndexChanged
            match prevValueOpt, source.TrySelectedIndexChanged with
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryOutlineColor
            let valueOpt = source.TryOutlineColor
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::OutlineColor "); target.OutlineColor <-  value
            | ValueSome _, ValueNone -> target.OutlineColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryFrameCornerRadius
            let valueOpt = source.TryFrameCornerRadius
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::CornerRadius "); target.CornerRadius <-  value
            | ValueSome _, ValueNone -> target.CornerRadius <- -1.0f
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryHasShadow
            let valueOpt = source.TryHasShadow
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Frame::HasShadow "); target.HasShadow <-  value
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryImageSource
            let valueOpt = source.TryImageSource
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Image::Source "); target.Source <- makeImageSource  value
            | ValueSome _, ValueNone -> target.Source <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryAspect
            let valueOpt = source.TryAspect
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Image::Aspect "); target.Aspect <-  value
            | ValueSome _, ValueNone -> target.Aspect <- Xamarin.Forms.Aspect.AspectFit
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryIsOpaque
            let valueOpt = source.TryIsOpaque
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Image::IsOpaque "); target.IsOpaque <-  value
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryKeyboard
            let valueOpt = source.TryKeyboard
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting InputView::Keyboard "); target.Keyboard <-  value
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryText
            let valueOpt = source.TryText
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::Text "); target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryFontSize
            let valueOpt = source.TryFontSize
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::FontSize "); target.FontSize <-  value
            | ValueSome _, ValueNone -> target.FontSize <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryFontFamily
            let valueOpt = source.TryFontFamily
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::FontFamily "); target.FontFamily <-  value
            | ValueSome _, ValueNone -> target.FontFamily <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryFontAttributes
            let valueOpt = source.TryFontAttributes
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::FontAttributes "); target.FontAttributes <-  value
            | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryTextColor
            let valueOpt = source.TryTextColor
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Editor::TextColor "); target.TextColor <-  value
            | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryEditorCompleted
            match prevValueOpt, source.TryEditorCompleted with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.Completed.RemoveHandler(prevValue); target.Completed.AddHandler(value)
            | ValueNone, ValueSome value -> target.Completed.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.Completed.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryTextChanged
            match prevValueOpt, source.TryTextChanged with
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryText
            let valueOpt = source.TryText
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::Text "); target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryPlaceholder
            let valueOpt = source.TryPlaceholder
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::Placeholder "); target.Placeholder <-  value
            | ValueSome _, ValueNone -> target.Placeholder <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryHorizontalTextAlignment
            let valueOpt = source.TryHorizontalTextAlignment
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::HorizontalTextAlignment "); target.HorizontalTextAlignment <-  value
            | ValueSome _, ValueNone -> target.HorizontalTextAlignment <- Xamarin.Forms.TextAlignment.Start
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryFontSize
            let valueOpt = source.TryFontSize
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::FontSize "); target.FontSize <-  value
            | ValueSome _, ValueNone -> target.FontSize <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryFontFamily
            let valueOpt = source.TryFontFamily
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::FontFamily "); target.FontFamily <-  value
            | ValueSome _, ValueNone -> target.FontFamily <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryFontAttributes
            let valueOpt = source.TryFontAttributes
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::FontAttributes "); target.FontAttributes <-  value
            | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryTextColor
            let valueOpt = source.TryTextColor
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::TextColor "); target.TextColor <-  value
            | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryPlaceholderColor
            let valueOpt = source.TryPlaceholderColor
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::PlaceholderColor "); target.PlaceholderColor <-  value
            | ValueSome _, ValueNone -> target.PlaceholderColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryIsPassword
            let valueOpt = source.TryIsPassword
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Entry::IsPassword "); target.IsPassword <-  value
            | ValueSome _, ValueNone -> target.IsPassword <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryEntryCompleted
            match prevValueOpt, source.TryEntryCompleted with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.Completed.RemoveHandler(prevValue); target.Completed.AddHandler(value)
            | ValueNone, ValueSome value -> target.Completed.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.Completed.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryTextChanged
            match prevValueOpt, source.TryTextChanged with
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryLabel
            let valueOpt = source.TryLabel
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting EntryCell::Label "); target.Label <-  value
            | ValueSome _, ValueNone -> target.Label <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryText
            let valueOpt = source.TryText
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting EntryCell::Text "); target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryKeyboard
            let valueOpt = source.TryKeyboard
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting EntryCell::Keyboard "); target.Keyboard <-  value
            | ValueSome _, ValueNone -> target.Keyboard <- Xamarin.Forms.Keyboard.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryPlaceholder
            let valueOpt = source.TryPlaceholder
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting EntryCell::Placeholder "); target.Placeholder <-  value
            | ValueSome _, ValueNone -> target.Placeholder <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryHorizontalTextAlignment
            let valueOpt = source.TryHorizontalTextAlignment
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting EntryCell::HorizontalTextAlignment "); target.HorizontalTextAlignment <-  value
            | ValueSome _, ValueNone -> target.HorizontalTextAlignment <- Xamarin.Forms.TextAlignment.Start
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryEntryCompleted
            match prevValueOpt, source.TryEntryCompleted with
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryText
            let valueOpt = source.TryText
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Label::Text "); target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryHorizontalTextAlignment
            let valueOpt = source.TryHorizontalTextAlignment
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Label::HorizontalTextAlignment "); target.HorizontalTextAlignment <-  value
            | ValueSome _, ValueNone -> target.HorizontalTextAlignment <- Xamarin.Forms.TextAlignment.Start
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryVerticalTextAlignment
            let valueOpt = source.TryVerticalTextAlignment
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Label::VerticalTextAlignment "); target.VerticalTextAlignment <-  value
            | ValueSome _, ValueNone -> target.VerticalTextAlignment <- Xamarin.Forms.TextAlignment.Start
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryFontSize
            let valueOpt = source.TryFontSize
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Label::FontSize "); target.FontSize <-  value
            | ValueSome _, ValueNone -> target.FontSize <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryFontFamily
            let valueOpt = source.TryFontFamily
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Label::FontFamily "); target.FontFamily <-  value
            | ValueSome _, ValueNone -> target.FontFamily <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryFontAttributes
            let valueOpt = source.TryFontAttributes
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Label::FontAttributes "); target.FontAttributes <-  value
            | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryTextColor
            let valueOpt = source.TryTextColor
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Label::TextColor "); target.TextColor <-  value
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryIsClippedToBounds
            let valueOpt = source.TryIsClippedToBounds
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Layout::IsClippedToBounds "); target.IsClippedToBounds <-  value
            | ValueSome _, ValueNone -> target.IsClippedToBounds <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryPadding
            let valueOpt = source.TryPadding
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Layout::Padding "); target.Padding <-  value
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
            let prevCollOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryChildren
            let collOpt = source.TryChildren
            updateIList prevCollOpt collOpt target.Children
                (fun (x:XamlElement) -> x.CreateAsView())
                (fun _ _ _ -> ())
                canReuseChild
                updateChild
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryStackOrientation
            let valueOpt = source.TryStackOrientation
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::Orientation "); target.Orientation <-  value
            | ValueSome _, ValueNone -> target.Orientation <- Xamarin.Forms.StackOrientation.Vertical
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TrySpacing
            let valueOpt = source.TrySpacing
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting StackLayout::Spacing "); target.Spacing <-  value
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryFontFamily
            let valueOpt = source.TryFontFamily
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Span::FontFamily "); target.FontFamily <-  value
            | ValueSome _, ValueNone -> target.FontFamily <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryFontAttributes
            let valueOpt = source.TryFontAttributes
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Span::FontAttributes "); target.FontAttributes <-  value
            | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryFontSize
            let valueOpt = source.TryFontSize
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Span::FontSize "); target.FontSize <-  value
            | ValueSome _, ValueNone -> target.FontSize <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryBackgroundColor
            let valueOpt = source.TryBackgroundColor
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Span::BackgroundColor "); target.BackgroundColor <-  value
            | ValueSome _, ValueNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryForegroundColor
            let valueOpt = source.TryForegroundColor
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Span::ForegroundColor "); target.ForegroundColor <-  value
            | ValueSome _, ValueNone -> target.ForegroundColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryText
            let valueOpt = source.TryText
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Span::Text "); target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryPropertyChanged
            match prevValueOpt, source.TryPropertyChanged with
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryTime
            let valueOpt = source.TryTime
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::Time "); target.Time <-  value
            | ValueSome _, ValueNone -> target.Time <- new System.TimeSpan()
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryFormat
            let valueOpt = source.TryFormat
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::Format "); target.Format <-  value
            | ValueSome _, ValueNone -> target.Format <- "t"
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryTextColor
            let valueOpt = source.TryTextColor
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting TimePicker::TextColor "); target.TextColor <-  value
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryWebSource
            let valueOpt = source.TryWebSource
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting WebView::Source "); target.Source <-  value
            | ValueSome _, ValueNone -> target.Source <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryNavigated
            match prevValueOpt, source.TryNavigated with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.Navigated.RemoveHandler(prevValue); target.Navigated.AddHandler(value)
            | ValueNone, ValueSome value -> target.Navigated.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.Navigated.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryNavigating
            match prevValueOpt, source.TryNavigating with
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryTitle
            let valueOpt = source.TryTitle
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Page::Title "); target.Title <-  value
            | ValueSome _, ValueNone -> target.Title <- ""
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryPadding
            let valueOpt = source.TryPadding
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Page::Padding "); target.Padding <-  value
            | ValueSome _, ValueNone -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryUseSafeArea
            let valueOpt = source.TryUseSafeArea
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
            let prevCollOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryChildren
            let collOpt = source.TryChildren
            updateIList prevCollOpt collOpt target.Children
                (fun (x:XamlElement) -> x.CreateAsContentPage())
                (fun _ _ _ -> ())
                canReuseChild
                updateChild
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryCarouselPage_SelectedItem
            let valueOpt = source.TryCarouselPage_SelectedItem
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting CarouselPage::SelectedItem "); target.SelectedItem <-  value
            | ValueSome _, ValueNone -> target.SelectedItem <- null
            | ValueNone, ValueNone -> ()
            let prevChildOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryCurrentPage
            match prevChildOpt, source.TryCurrentPage with
            // For structured objects, dependsOn on reference equality
            | ValueSome prevChild, ValueSome newChild when identical prevChild newChild -> ()
            | ValueSome prevChild, ValueSome newChild when canReuseChild prevChild newChild ->
                newChild.UpdateIncremental(prevChild, target.CurrentPage)
            | ValueSome _, ValueSome newChild
            | ValueNone, ValueSome newChild ->
                target.CurrentPage <- newChild.CreateAsContentPage()
            | ValueSome _, ValueNone ->
                target.CurrentPage <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryCurrentPageChanged
            match prevValueOpt, source.TryCurrentPageChanged with
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
            match pages with None -> () | Some v -> yield ("NavigationPagePages", box (Array.ofList(v))) 
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryNavigationPagePages
            let valueOpt = source.TryNavigationPagePages
            updateNavigationPages prevValueOpt valueOpt target
                (fun prevChildOpt newChild targetChild -> 
                    // Adjust the attached properties
                    match (match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryBackButtonTitle), newChild.TryBackButtonTitle with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.NavigationPage.SetBackButtonTitle(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.NavigationPage.SetBackButtonTitle(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    match (match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryHasBackButton), newChild.TryHasBackButton with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.NavigationPage.SetHasBackButton(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.NavigationPage.SetHasBackButton(targetChild, true) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    match (match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryHasNavigationBar), newChild.TryHasNavigationBar with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.NavigationPage.SetHasNavigationBar(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.NavigationPage.SetHasNavigationBar(targetChild, true) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    match (match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryTitleIcon), newChild.TryTitleIcon with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.NavigationPage.SetTitleIcon(targetChild, makeFileImageSource value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.NavigationPage.SetTitleIcon(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    ())
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryBarBackgroundColor
            let valueOpt = source.TryBarBackgroundColor
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting NavigationPage::BarBackgroundColor "); target.BarBackgroundColor <-  value
            | ValueSome _, ValueNone -> target.BarBackgroundColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryBarTextColor
            let valueOpt = source.TryBarTextColor
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting NavigationPage::BarTextColor "); target.BarTextColor <-  value
            | ValueSome _, ValueNone -> target.BarTextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryPopped
            match prevValueOpt, source.TryPopped with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.Popped.RemoveHandler(prevValue); target.Popped.AddHandler(value)
            | ValueNone, ValueSome value -> target.Popped.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.Popped.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryPoppedToRoot
            match prevValueOpt, source.TryPoppedToRoot with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.PoppedToRoot.RemoveHandler(prevValue); target.PoppedToRoot.AddHandler(value)
            | ValueNone, ValueSome value -> target.PoppedToRoot.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.PoppedToRoot.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryPushed
            match prevValueOpt, source.TryPushed with
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
            let prevCollOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryChildren
            let collOpt = source.TryChildren
            updateIList prevCollOpt collOpt target.Children
                (fun (x:XamlElement) -> x.CreateAsPage())
                (fun _ _ _ -> ())
                canReuseChild
                updateChild
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryBarBackgroundColor
            let valueOpt = source.TryBarBackgroundColor
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting TabbedPage::BarBackgroundColor "); target.BarBackgroundColor <-  value
            | ValueSome _, ValueNone -> target.BarBackgroundColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryBarTextColor
            let valueOpt = source.TryBarTextColor
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting TabbedPage::BarTextColor "); target.BarTextColor <-  value
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
            let prevChildOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryContent
            match prevChildOpt, source.TryContent with
            // For structured objects, dependsOn on reference equality
            | ValueSome prevChild, ValueSome newChild when identical prevChild newChild -> ()
            | ValueSome prevChild, ValueSome newChild when canReuseChild prevChild newChild ->
                newChild.UpdateIncremental(prevChild, target.Content)
            | ValueSome _, ValueSome newChild
            | ValueNone, ValueSome newChild ->
                target.Content <- newChild.CreateAsView()
            | ValueSome _, ValueNone ->
                target.Content <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryOnSizeAllocatedCallback
            let valueOpt = source.TryOnSizeAllocatedCallback
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
            let prevChildOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryMaster
            match prevChildOpt, source.TryMaster with
            // For structured objects, dependsOn on reference equality
            | ValueSome prevChild, ValueSome newChild when identical prevChild newChild -> ()
            | ValueSome prevChild, ValueSome newChild when canReuseChild prevChild newChild ->
                newChild.UpdateIncremental(prevChild, target.Master)
            | ValueSome _, ValueSome newChild
            | ValueNone, ValueSome newChild ->
                target.Master <- newChild.CreateAsPage()
            | ValueSome _, ValueNone ->
                target.Master <- null
            | ValueNone, ValueNone -> ()
            let prevChildOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryDetail
            match prevChildOpt, source.TryDetail with
            // For structured objects, dependsOn on reference equality
            | ValueSome prevChild, ValueSome newChild when identical prevChild newChild -> ()
            | ValueSome prevChild, ValueSome newChild when canReuseChild prevChild newChild ->
                newChild.UpdateIncremental(prevChild, target.Detail)
            | ValueSome _, ValueSome newChild
            | ValueNone, ValueSome newChild ->
                target.Detail <- newChild.CreateAsPage()
            | ValueSome _, ValueNone ->
                target.Detail <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryIsGestureEnabled
            let valueOpt = source.TryIsGestureEnabled
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::IsGestureEnabled "); target.IsGestureEnabled <-  value
            | ValueSome _, ValueNone -> target.IsGestureEnabled <- true
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryIsPresented
            let valueOpt = source.TryIsPresented
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::IsPresented "); target.IsPresented <-  value
            | ValueSome _, ValueNone -> target.IsPresented <- true
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryMasterBehavior
            let valueOpt = source.TryMasterBehavior
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting MasterDetailPage::MasterBehavior "); target.MasterBehavior <-  value
            | ValueSome _, ValueNone -> target.MasterBehavior <- Xamarin.Forms.MasterBehavior.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryIsPresentedChanged
            match prevValueOpt, source.TryIsPresentedChanged with
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryHeight
            let valueOpt = source.TryHeight
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Cell::Height "); target.Height <-  value
            | ValueSome _, ValueNone -> target.Height <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryIsEnabled
            let valueOpt = source.TryIsEnabled
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting Cell::IsEnabled "); target.IsEnabled <-  value
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryText
            let valueOpt = source.TryText
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting TextCell::Text "); target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryTextDetail
            let valueOpt = source.TryTextDetail
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting TextCell::Detail "); target.Detail <-  value
            | ValueSome _, ValueNone -> target.Detail <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryTextColor
            let valueOpt = source.TryTextColor
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting TextCell::TextColor "); target.TextColor <-  value
            | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryTextDetailColor
            let valueOpt = source.TryTextDetailColor
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting TextCell::DetailColor "); target.DetailColor <-  value
            | ValueSome _, ValueNone -> target.DetailColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryTextCellCommand
            let valueOpt = source.TryTextCellCommand
            (fun _ _ _ -> ()) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryTextCellCanExecute
            let valueOpt = source.TryTextCellCanExecute
            updateCommand (match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryTextCellCommand) prevValueOpt source.TryTextCellCommand valueOpt (fun cmd -> System.Diagnostics.Debug.WriteLine("Setting TextCell::Command "); target.Command <- cmd) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryCommandParameter
            let valueOpt = source.TryCommandParameter
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting TextCell::CommandParameter "); target.CommandParameter <-  value
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryImageSource
            let valueOpt = source.TryImageSource
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ImageCell::ImageSource "); target.ImageSource <- makeImageSource  value
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
            let prevChildOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryView
            match prevChildOpt, source.TryView with
            // For structured objects, dependsOn on reference equality
            | ValueSome prevChild, ValueSome newChild when identical prevChild newChild -> ()
            | ValueSome prevChild, ValueSome newChild when canReuseChild prevChild newChild ->
                newChild.UpdateIncremental(prevChild, target.View)
            | ValueSome _, ValueSome newChild
            | ValueNone, ValueSome newChild ->
                target.View <- newChild.CreateAsView()
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
            match separatorVisibility with None -> () | Some v -> yield ("SeparatorVisibility", box ((v))) 
            match separatorColor with None -> () | Some v -> yield ("SeparatorColor", box ((v))) 
            match itemAppearing with None -> () | Some v -> yield ("ListView_ItemAppearing", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(v))) 
            match itemDisappearing with None -> () | Some v -> yield ("ListView_ItemDisappearing", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(v))) 
            match itemSelected with None -> () | Some v -> yield ("ListView_ItemSelected", box ((fun f -> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args -> f (tryFindListViewItem sender args.SelectedItem)))(v))) 
            match itemTapped with None -> () | Some v -> yield ("ListView_ItemTapped", box ((fun f -> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(v))) 
            match refreshing with None -> () | Some v -> yield ("Refreshing", box ((fun f -> System.EventHandler(fun sender args -> f ()))(v))) 
          |]

        let create () =
            box (new Elmish.XamarinForms.DynamicViews.CustomListView())
        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.ListView)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryListViewItems
            let valueOpt = source.TryListViewItems
            updateListViewItems prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryFooter
            let valueOpt = source.TryFooter
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::Footer "); target.Footer <-  value
            | ValueSome _, ValueNone -> target.Footer <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryHasUnevenRows
            let valueOpt = source.TryHasUnevenRows
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::HasUnevenRows "); target.HasUnevenRows <-  value
            | ValueSome _, ValueNone -> target.HasUnevenRows <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryHeader
            let valueOpt = source.TryHeader
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::Header "); target.Header <-  value
            | ValueSome _, ValueNone -> target.Header <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryHeaderTemplate
            let valueOpt = source.TryHeaderTemplate
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::HeaderTemplate "); target.HeaderTemplate <-  value
            | ValueSome _, ValueNone -> target.HeaderTemplate <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryIsGroupingEnabled
            let valueOpt = source.TryIsGroupingEnabled
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::IsGroupingEnabled "); target.IsGroupingEnabled <-  value
            | ValueSome _, ValueNone -> target.IsGroupingEnabled <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryIsPullToRefreshEnabled
            let valueOpt = source.TryIsPullToRefreshEnabled
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::IsPullToRefreshEnabled "); target.IsPullToRefreshEnabled <-  value
            | ValueSome _, ValueNone -> target.IsPullToRefreshEnabled <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryIsRefreshing
            let valueOpt = source.TryIsRefreshing
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::IsRefreshing "); target.IsRefreshing <-  value
            | ValueSome _, ValueNone -> target.IsRefreshing <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryRefreshCommand
            let valueOpt = source.TryRefreshCommand
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::RefreshCommand "); target.RefreshCommand <-  value
            | ValueSome _, ValueNone -> target.RefreshCommand <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryRowHeight
            let valueOpt = source.TryRowHeight
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::RowHeight "); target.RowHeight <-  value
            | ValueSome _, ValueNone -> target.RowHeight <- -1
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryListView_SelectedItem
            let valueOpt = source.TryListView_SelectedItem
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::SelectedItem "); target.SelectedItem <- (function None -> null | Some i -> let items = target.ItemsSource :?> System.Collections.Generic.IList<ListElementData<XamlElement>> in if i >= 0 && i < items.Count then items.[i] else null)  value
            | ValueSome _, ValueNone -> target.SelectedItem <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TrySeparatorVisibility
            let valueOpt = source.TrySeparatorVisibility
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::SeparatorVisibility "); target.SeparatorVisibility <-  value
            | ValueSome _, ValueNone -> target.SeparatorVisibility <- Xamarin.Forms.SeparatorVisibility.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TrySeparatorColor
            let valueOpt = source.TrySeparatorColor
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ListView::SeparatorColor "); target.SeparatorColor <-  value
            | ValueSome _, ValueNone -> target.SeparatorColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryListView_ItemAppearing
            match prevValueOpt, source.TryListView_ItemAppearing with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ItemAppearing.RemoveHandler(prevValue); target.ItemAppearing.AddHandler(value)
            | ValueNone, ValueSome value -> target.ItemAppearing.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ItemAppearing.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryListView_ItemDisappearing
            match prevValueOpt, source.TryListView_ItemDisappearing with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ItemDisappearing.RemoveHandler(prevValue); target.ItemDisappearing.AddHandler(value)
            | ValueNone, ValueSome value -> target.ItemDisappearing.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ItemDisappearing.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryListView_ItemSelected
            match prevValueOpt, source.TryListView_ItemSelected with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ItemSelected.RemoveHandler(prevValue); target.ItemSelected.AddHandler(value)
            | ValueNone, ValueSome value -> target.ItemSelected.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ItemSelected.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryListView_ItemTapped
            match prevValueOpt, source.TryListView_ItemTapped with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ItemTapped.RemoveHandler(prevValue); target.ItemTapped.AddHandler(value)
            | ValueNone, ValueSome value -> target.ItemTapped.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ItemTapped.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryRefreshing
            match prevValueOpt, source.TryRefreshing with
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
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGroupListViewItemsSource
            let valueOpt = source.TryGroupListViewItemsSource
            updateListViewGroupedItems prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryFooter
            let valueOpt = source.TryFooter
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::Footer "); target.Footer <-  value
            | ValueSome _, ValueNone -> target.Footer <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryHasUnevenRows
            let valueOpt = source.TryHasUnevenRows
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::HasUnevenRows "); target.HasUnevenRows <-  value
            | ValueSome _, ValueNone -> target.HasUnevenRows <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryHeader
            let valueOpt = source.TryHeader
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::Header "); target.Header <-  value
            | ValueSome _, ValueNone -> target.Header <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryIsGroupingEnabled
            let valueOpt = source.TryIsGroupingEnabled
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::IsGroupingEnabled "); target.IsGroupingEnabled <-  value
            | ValueSome _, ValueNone -> target.IsGroupingEnabled <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryIsPullToRefreshEnabled
            let valueOpt = source.TryIsPullToRefreshEnabled
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::IsPullToRefreshEnabled "); target.IsPullToRefreshEnabled <-  value
            | ValueSome _, ValueNone -> target.IsPullToRefreshEnabled <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryIsRefreshing
            let valueOpt = source.TryIsRefreshing
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::IsRefreshing "); target.IsRefreshing <-  value
            | ValueSome _, ValueNone -> target.IsRefreshing <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryRefreshCommand
            let valueOpt = source.TryRefreshCommand
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::RefreshCommand "); target.RefreshCommand <-  value
            | ValueSome _, ValueNone -> target.RefreshCommand <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryRowHeight
            let valueOpt = source.TryRowHeight
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::RowHeight "); target.RowHeight <-  value
            | ValueSome _, ValueNone -> target.RowHeight <- -1
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryListViewGrouped_SelectedItem
            let valueOpt = source.TryListViewGrouped_SelectedItem
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::SelectedItem "); target.SelectedItem <- (function None -> null | Some (i,j) -> let items = target.ItemsSource :?> System.Collections.Generic.IList<ListGroupData<XamlElement>> in (if i >= 0 && i < items.Count then (let items2 = items.[i] in if j >= 0 && j < items2.Count then items2.[j] else null) else null))  value
            | ValueSome _, ValueNone -> target.SelectedItem <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TrySeparatorVisibility
            let valueOpt = source.TrySeparatorVisibility
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::SeparatorVisibility "); target.SeparatorVisibility <-  value
            | ValueSome _, ValueNone -> target.SeparatorVisibility <- Xamarin.Forms.SeparatorVisibility.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TrySeparatorColor
            let valueOpt = source.TrySeparatorColor
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine("Setting ListViewGrouped::SeparatorColor "); target.SeparatorColor <-  value
            | ValueSome _, ValueNone -> target.SeparatorColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryListViewGrouped_ItemAppearing
            match prevValueOpt, source.TryListViewGrouped_ItemAppearing with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ItemAppearing.RemoveHandler(prevValue); target.ItemAppearing.AddHandler(value)
            | ValueNone, ValueSome value -> target.ItemAppearing.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ItemAppearing.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryListViewGrouped_ItemDisappearing
            match prevValueOpt, source.TryListViewGrouped_ItemDisappearing with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ItemDisappearing.RemoveHandler(prevValue); target.ItemDisappearing.AddHandler(value)
            | ValueNone, ValueSome value -> target.ItemDisappearing.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ItemDisappearing.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryListViewGrouped_ItemSelected
            match prevValueOpt, source.TryListViewGrouped_ItemSelected with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ItemSelected.RemoveHandler(prevValue); target.ItemSelected.AddHandler(value)
            | ValueNone, ValueSome value -> target.ItemSelected.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ItemSelected.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryListViewGrouped_ItemTapped
            match prevValueOpt, source.TryListViewGrouped_ItemTapped with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ItemTapped.RemoveHandler(prevValue); target.ItemTapped.AddHandler(value)
            | ValueNone, ValueSome value -> target.ItemTapped.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ItemTapped.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryRefreshing
            match prevValueOpt, source.TryRefreshing with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.Refreshing.RemoveHandler(prevValue); target.Refreshing.AddHandler(value)
            | ValueNone, ValueSome value -> target.Refreshing.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.Refreshing.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
        new XamlElement(typeof<Xamarin.Forms.ListView>, create, update, attribs)
