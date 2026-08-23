---
description: Learn how to break down a big app into several smaller programs with View.map
---

# Splitting into independent MVU states

Explicitly listing out all the possible states of an app is the main strength of MVU. But as your app grows and gets more features, this strength can become its greatest weakness resulting in a giant single file where everything is mixed together and difficult to maintain.

Take for example a simple app where users create their account by going through several pages: Personal details -> Create password -> etc.

Typically, we would start by putting every single data into the App.Model. This would force us to also handle all the messages, updates, and views in the same file.

{% code title="App.fs" %}
```fsharp
type Model =
    { CurrentPage: int
      FirstName: string
      LastName: string
      EmailAddress: string
      Password: string
      ConfirmPassword: string
      ... }
       
type Msg =
    | FirstNameChanged of string
    | LastNameChanged of string
    | EmailAddressChanged of string
    | PasswordChanged of string
    | ConfirmPasswordChanged of string
    | ...
    
let update msg model =
    match msg with
    | FirstNameChanged newValue -> { model with FirstName = newValue }
    | ...
    
let view model =
    NavigationPage() {
        ContentPage("Form1", ...)
        
        if model.CurrentPage >= 2 then
            ContentPage("Form2", ...)
        
        if model.CurrentPage >= 3 then
            ContentPage("Form3", ...)
            
        ...
    }
    
let program = Program.stateful init update view
```
{% endcode %}

While this is perfectly fine for small apps with few features, typical apps have way more features and it can quickly become unyielding.

### Decomposing a big app with View.map

To avoid having everything together in a single Model and Msg type, we can decompose the code into several MVU states with independent Model, Msg, init, update and view functions.

In our example, we can extract most of the code into separate page files, making it much more easier to reason about and maintain.

{% code title="Form1.fs" %}
```fsharp
module Form1 =
    type Model =
        { FirstName: string
          LastName: string
          EmailAddress: string }
          
    type Msg =
        | FirstNameChanged of string
        | LastNameChanged of string
        | EmailAddressChanged of string
        
    let init () = ...
    
    let update msg model = ...
    
    let view model =
        ContentPage("Form1",
            VStack() {
                Entry(model.FirstName, FirstNameChanged)
                Entry(model.LastName, LastNameChanged)
                Entry(model.EmailAddress, EmailAddressChanged)
            }
        )
```
{% endcode %}

{% code title="Form2.fs" %}
```fsharp
module Form2 =
    type Model =
        { Password: string
          ConfirmPassword: string }
    
    type Msg =
        | PasswordChanged of string
        | ConfirmPasswordChanged of string
        
    let init () = ...
    let update msg model = ...
    
    let view model =
        ContentPage("Form2",
            VStack() {
                Entry(model.Password, PasswordChanged)
                Entry(model.ConfirmPassword, ConfirmPasswordChanged)
            }
        )
```
{% endcode %}

But we are now facing a challenge. How do we combine them together?

We could first create a "super" model holding both Form1 and Form2 models.

But when we call the view functions of the forms, we are facing a compilation error:

{% code title="App.fs" %}
```fsharp
type Model =
    { Form1Model: Form1.Model
      Form2Model: Form2.Model }

let view model =
    NavigationPage() {
        Form1.view model.Form1Model
        Form2.view model.Form2Model // ERROR: Expected type WidgetBuilder<Form1.Msg, IFabContentPage>, but got WidgetBuilder<Form2.Msg, IFabContentPage>
    }
```
{% endcode %}

Like you can see above, with different Msg types, Fabulous doesn't know how to handle them at the same time, so it will prevent the app to compile.

We need to convert those Msg types into a common one, by using the integrated Fabulous function: View.map.

```fsharp
val View.map :
  ('oldMsg -> 'newMsg) -> WidgetBuilder<'oldMsg, 'marker> -> WidgetBuilder<'newMsg, 'marker>
```

View.map takes as a first parameter a function converting a message from the child to the parent, and as a second parameter the child widget itself.

In our example, we would need to convert Form1.Msg and Form2.Msg into a common App.Msg type.

{% code title="App.fs" %}
```fsharp
type Msg =
    | Form1Msg of Form1.Msg
    | Form2Msg of Form2.Msg
```
{% endcode %}

Thanks to the functional approach of F#, writing a function converting Form1.Msg to App.Msg is as simple as just using the discriminated value "Form1Msg".

```fsharp
View.map Form1Msg (Form1.view model.Form1Model)
```

Using this View.map function will change the widget Msg type to the common one, which will allow the app to compile.

{% code title="App.fs" %}
```fsharp
type Model =
    { Form1Model: Form1.Model
      Form2Model: Form2.Model }
      
type Msg =
    | Form1Msg of Form1.Msg
    | Form2Msg of Form2.Msg

let view model =
    NavigationPage() {
        View.map Form1Msg (Form1.view model.Form1Model)
        View.map Form2Msg (Form2.view model.Form2Model) // OK
    }
```
{% endcode %}

Now, that we managed to compose the forms' view functions into the app view function, let's see how to implement init and update.

### Calling init at the right time

Since in our example, our users are going through a journey composed of several pages to create an account, we need to model this journey. This will allow us to track where the users are right now and also avoid us to instantiate the pages they haven't reached yet.

We can do that with a simple discriminated union.

{% code title="App.fs" %}
```fsharp
type JourneyStep =
    | StepForm1
    | StepForm2
    
// We add this new DU into the model
type Model =
    { JourneyStep: JourneyStep
      Form1Model: Form1.Model
      Form2Model: Form2.Model option } 
```
{% endcode %}

You might have noticed Form2Model is marked as Option. We changed it because we don't want to initialize its state when the users haven't reach this step yet.

The App's init function is now very simple to write:

{% code title="App.fs" %}
```fsharp
let init () =
    { JourneyStep = StepForm1 // At the start, users are on the first step
      Form1Model = Form1.init() // We simply call the Form1 init function to initialize it
      Form2Model = None } // And we put the other steps to None
```
{% endcode %}

Here we initialized the Form1.Model, but how do we initialize the other models later on?

For that, we need to know when to initialize them. For example, when clicking a button. We add a new message in App.Model and handle it inside the update function.

{% code title="App.fs" %}
```fsharp
type Msg =
    | NextStep of JourneyStep
    
let update msg model =
    match msg with
    | NextStep step ->
        let newModel =
            match step with
            | StepForm1 ->
                { model with
                    Form1Model = Form1.init()
                    Form2Model = None } // If we are back on Form1 means Form2 is no longer available
                    
            | StepForm2 -> { model with Form2Model = Some(Form2.init()) }
            
        { newModel with JourneyStep = step }
```
{% endcode %}

### Calling update at the right time

Now that we have both the view and init functions in place, we are just missing the update function.

This is straightforward as we simply need to pass the messages from the App to the corresponding form.

{% code title="App.fs" %}
```fsharp
let update msg model =
    | Form1Msg f1 -> { model with Form1Model = Form1.update f1 model.Form1Model }
    | Form2Msg f2 -> { model with Form2Model = Form2.update f2 model.Form2Model.Value }
```
{% endcode %}

You might notice we are using ".Value" here on an Option type. While this is not a good practice (because it could result in a crash if value is None), we can assume we won't ever receive messages from Form2 when this one is not loaded.

If you wish to have a safer code, you could handle the error case (None) by either ignoring the message for Form2 or tracking it in another way (logging, analytics, etc).

### Final result

Voilà! We now have all the pieces to compose the full app together from independent pages.

{% code title="Form1.fs" %}
```fsharp
module Form1 =
    type Model =
        { FirstName: string
          LastName: string
          EmailAddress: string }
          
    type Msg =
        | FirstNameChanged of string
        | LastNameChanged of string
        | EmailAddressChanged of string
        
    let init () = ...
    
    let update msg model = ...
    
    let view model =
        ContentPage("Form1",
            VStack() {
                Entry(model.FirstName, FirstNameChanged)
                Entry(model.LastName, LastNameChanged)
                Entry(model.EmailAddress, EmailAddressChanged)
            }
        )
```
{% endcode %}

{% code title="Form2.fs" %}
```fsharp
module Form2 =
    type Model =
        { Password: string
          ConfirmPassword: string }
    
    type Msg =
        | PasswordChanged of string
        | ConfirmPasswordChanged of string
        
    let init () = ...
    let update msg model = ...
    
    let view model =
        ContentPage("Form2",
            VStack() {
                Entry(model.Password, PasswordChanged)
                Entry(model.ConfirmPassword, ConfirmPasswordChanged)
            }
        )
```
{% endcode %}

{% code title="App.fs" %}
```fsharp
module App =
    type JourneyStep =
        | StepForm1
        | StepForm2
    
    type Model =
        { JourneyStep: JourneyStep
          Form1Model: Form1.Model
          Form2Model: Form2.Model option }
          
    type Msg =
        | NextStep of JourneyStep
        | Form1Msg of Form1.Msg
        | Form2Msg of Form2.Msg
        
    let init () =
        { JourneyStep = StepForm1
          Form1Model = Form1.init()
          Form2Model = None }
          
    let update msg model =
        match msg with
        | NextStep step ->
            let newModel =
                match step with
                | StepForm1 -> { model with Form1Model = Form1.init() }
                | StepForm2 -> { model with Form2Model = Some(Form2.init() }
                
            { newModel with JourneyStep = step }
            
        | Form1Msg f1 -> { model with Form1Model = Form1.update f1 model.Form1Model }
        | Form2Msg f2 -> { model with Form2Model = Some(Form2.update f2 model.Form2Model.Value) }
        
    let view model =
        NavigationPage() {
            View.map Form1Msg (Form1.view model.Form1Model)
            
            if model.JourneyStep = StepForm2 then
                View.map Form2Msg (Form2.view model.Form2Model)
        }
        
    let program = Program.stateful init update view
```
{% endcode %}

To learn more about splitting independent MVU states, read [The Elmish Book - Splitting Programs](https://zaid-ajaj.github.io/the-elmish-book/#/chapters/scaling/splitting-programs).
