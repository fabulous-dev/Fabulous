namespace AllControls.WindowsWPFClassic

open System
open System.IO
open System.Reflection
open System.Windows
open System.Windows.Controls
open System.Windows.Markup

open Xamarin.Forms
open Xamarin.Forms.Platform.WPF

type MainWindow() as this = 
    inherit FormsApplicationPage()
    //let xaml = Assembly.GetExecutingAssembly().GetManifestResourceStream("AllControls.WindowsWPFClassic.MainWindow.xaml")  // XAML - MUST be Embedded Resource 
    //let mySr = new StreamReader(xaml) 
    do this.Content <- Grid() //XamlReader.Load(mySr.BaseStream):?> Window  // Load XAML

    //let mySr = new StreamReader(Assembly.Load("MyUserControl").GetManifestResourceStream("ShowImage.xaml"))   // XAML - MUST be Embedded Resource  
    //do this.Content <- XamlReader.Load(mySr.BaseStream):?> UserControl  // Load XAML
    //let resourceLocater = new Uri("/AllControls.WindowsWPFClassic;component/mainwindow.xaml", System.UriKind.Relative)
    //do System.Windows.Application.LoadComponent(this, resourceLocater)
    //do Forms.Init()


//type App() as this =
//   inherit Application()
   //do this.StartupUri <- new System.Uri("MainWindow.xaml", System.UriKind.Relative);

module Main = 
    [<EntryPoint>]
    [<STAThread>]
    let main(_args) =

        let app = new System.Windows.Application()
        Forms.Init()
        //let xaml = Assembly.GetExecutingAssembly().GetManifestResourceStream("AllControls.WindowsWPFClassic.MainWindow.xaml")  // XAML - MUST be Embedded Resource 
        //let mySr = new StreamReader(xaml) 
        //let window : Window = XamlReader.Load(mySr.BaseStream):?> Window  // Load XAML
        let window = MainWindow() 
        window.LoadApplication(new AllControls.App())

        // Find ShowImage and setup parameter WindowMain <- this
        // let ShowImage : MyUserControl.ShowImage = this?ShowImage 
        app.Run(window)
