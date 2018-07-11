Elmish.XamarinForms Guide
=======

{% include_relative contents.md %}

Live Update
------

There is an experimental LiveUpdate mechanism available.  The aim of this is primarily to enable modifying the `view` function in order
to see the effect of adjusting of visual options.

Some manual set-up is required.  The following assumes your app is called `SqueakyApp`:

1. Add a reference to nuget package `Elmish.XamarinForms.LiveUpdate` to all projects in your app. Do a clean build.

2. Add the code in the `#if` section below in `SqueakyApp\SqueakyApp\SqueayApp.fs`:

       type App () = 
	       inherit Application()
		   ....
           #if DEBUG
           do runner.EnableLiveUpdate ()
           #endif

3. In your core project directory (e.g. `SqueakyApp\SqueakyApp`), create `proj.args` containing the project options used to compile the core of your app. It should look something like [this](https://github.com/fsprojects/Elmish.XamarinForms/blob/f3a591bfe4a7a70059ec8d74a3843968b200b91b/Samples/CounterApp/CounterApp/out.args).

       dotnet build -v:n SqueayApp.fsproj > proj.args
       <manually edit `proj.args` to contain only the compilation arguments>

4. If running on Android, forward requests from localhost to the Android Debug Bridge:

       USB: 
           adb -d forward  tcp:9867 tcp:9867 
       EMULATOR: 
           adb -e forward  tcp:9867 tcp:9867 

5. Launch your app in Debug mode (you can use Release mode but must set Linking options to `None` rather than `SDK Assemblies`)

6. Run the following from your core project directory (e.g. `SqueakyApp\SqueakyApp`)
      
       Windows:

           %USERPROFILE%\.nuget\packages\Elmish.XamarinForms.LiveUpdate\0.13.0\tools\fscd.exe --watch --webhook:http://localhost:9867/update -- @proj.args
       
       Unix and OSX (untested):
       
           mono ~/.nuget/packages/Elmish.XamarinForms.LiveUpdate/0.13.0/tools/fscd.exe --watch --webhook:http://localhost:9867/update -- @proj.args

Now, whenever you save a file in your core project directory, the `fscd.exe` daemon will attempt to recompile your changed file and
send a representation of its contents to your app via a PUT request to the given webhook.  The app then deserializes this representation and
adds the declarations to an F# interpreter. This interpreter will make some reflective calls into the existing libraries on device.
   
To take effect, your code must have a single declaration in some module called `programLiveUpdate` or `program` taking no arguments.  For example:

```fsharp
module App = 
    ...
    let init() = ...
        
    let update model msg = ...
           
    let view model dispatch = ...
         
    let program = Program.mkProgram init update view
```

If a declaration like this is found the `program` object replaces the currently running Elmish program and the view is updated.
The model state of the app is re-initialized.

### Known limitations:

1. The F# interpreter used on-device has incompletnesses and behavioural differences:

   1. Object expressions may not be intepreted
   2. Implementations of ToString() and other overrides will be ignored
   3. Some other F# constructs are not supported (e.g. address-of operations)

   You can move generally move problematic constructs to a utility library, which will then be executed as compiled code.

2. Changes to the resources in a project (e.g. images) require a rebuild

3. Changes to Android and iOS require a rebuild

4. You may need to mock any platform-specific helpers you pass through, e.g.

       module App = 
           ...
           let init() = ...
           
           let update (helper1, helper2) model msg = ...
           
           let view model dispatch = ...

       #if DEBUG	       
       // The fake program, used when LiveUpdate is activated and a program change has been made
       module AppLiveUpdate = 
           open App

           let mockHelper1 () = ... 

           let mockHelper2 () = ... 

           let programLiveUpdate = Program.mkProgram init (update (mockHelper1, mockHelper2)) view
       #endif

       type App (helper1, helper2) = 
	       inherit Application()
		   ....

           // The real program, used when LiveUpdate is not activated or a program change has not been made
           let program = Program.mkProgram App.init (App.update (helper1, helper2)) App.view

6. There may be issues running on networks with network policy restrictions

### Troubleshooting

The LiveUpdate mechanism is very experimental.
- Debug output is printed to console by `fscd.exe`
- Debug output is printed to app-output by the on-device web server

Please contribute documentation, updates and fixes to make the experience simpler.

