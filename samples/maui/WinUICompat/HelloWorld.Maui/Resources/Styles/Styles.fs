namespace HelloWorld

(*
NOTE ABOUT THIS FILE:
   Maui looks up styles XAML files by path (eg. Resources/Styles/XXX.xaml) but once the app is compiled,
   the styles are stored using resource ids (HelloWorld.Resources.Styles.XXX.xaml) so Maui uses XamlResourceId
   to be able to find the styles.
   
   In C#, the XAML files are compiled and the XamlResourceId are generated automatically.
   But not in F#.
   
   To be able to use styles in F#, you need to do the following:
   - Set the XAML file as "EmbeddedResource"
   - Add a class name inside the XAML (<ResourceDictionary x:Class="HelloWorld.XXX">)
   - Create a new type in this file:
        - Must have the same name as previous step (XXX)
        - Inherit from ResourceDictionary
        - Call `do base.LoadFromXaml(typeof<XXX>) |> ignore`
    - Register the XAML file and this type by adding a XamlResourceId attribute below
        - ResourceId must follow format: Namespace.Folder.SubFolder.FileName.Extension (HelloWorld.Resources.Styles.XXX.xaml)
        - FilePath must be the path to the XAML file (Resources/Styles/XXX.xaml)
        - Type must be the type of the class defined we defined above (typeof<XXX>)
*)   

open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Xaml

type Colors() =
    inherit ResourceDictionary()
    do base.LoadFromXaml(typeof<Colors>) |> ignore
    
type Styles() =
    inherit ResourceDictionary()
    do base.LoadFromXaml(typeof<Styles>) |> ignore

[<XamlResourceId("HelloWorld.Resources.Styles.Colors.xaml", "Resources/Styles/Colors.xaml", typeof<Colors>)>]
[<XamlResourceId("HelloWorld.Resources.Styles.Styles.xaml", "Resources/Styles/Styles.xaml", typeof<Styles>)>]
do ()

