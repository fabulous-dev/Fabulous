namespace Elmish.XamarinForms

open System
open System.Collections.Generic
open System.ComponentModel
open Xamarin.Forms
open Elmish.XamarinForms

/// The internal representation of a binding in the ViewModel
type internal PropertyBinding<'model, 'msg> =
    | Get of Getter<'model>
    | Set of Setter<'model, 'msg>
    | GetSet of Getter<'model> * Setter<'model, 'msg>
    | GetSetValidate of Getter<'model> * ValidSetter<'model, 'msg>
    | Cmd of Xamarin.Forms.Command
    | Model of ViewModel<'model, 'msg>
    | Map of Getter<'model> * (obj -> obj)

and ViewModel<'model, 'msg>(m: 'model, dispatch, propMap: ViewBindings<'model, 'msg>) as self =
    inherit System.Dynamic.DynamicObject()

    let props = new Dictionary<string, PropertyBinding<'model, 'msg>>()

    // Store all errors
    let errors = new Dictionary<string, string list>()
    let errorsChanged = new DelegateEvent<System.EventHandler<DataErrorsChangedEventArgs>>()

    // Current model
    let mutable model : 'model = m

    // For INotifyPropertyChanged
    let propertyChanged = Event<PropertyChangedEventHandler, PropertyChangedEventArgs> ()
    let notifyPropertyChanged name = 
        console.log (sprintf "notifyPropertyChanged %s" name)
        let key = "Item[" + name + "]"
        propertyChanged.Trigger(self, PropertyChangedEventArgs key)

    /// Convert a list of property changes
    let notify (p : string list) =
        p |> List.iter notifyPropertyChanged
        let raiseCanExecuteChanged accessor =
            match accessor with
            | Cmd c -> Device.BeginInvokeOnMainThread(fun () -> c.ChangeCanExecute ())
            | _ -> ()
        props |> List.ofSeq |> List.iter (fun kvp -> raiseCanExecuteChanged kvp.Value)    

    /// Convert a command to a XF command
    let toCommand name (exec, canExec) =
        let execute = 
            Action<obj> (fun cmdParameter -> 
                console.log (sprintf "view: execute cmd %s" name)
                let msgFromCmd = 
                   try exec cmdParameter model 
                   with exn -> 
                       console.log (sprintf "view: execute cmd %s raised exception:\n%s" name (exn.ToString()))
                       reraise()
                dispatch msgFromCmd)

        let canExecute = 
            Func<obj, bool>(fun cmdParameter -> 
                console.log (sprintf "view: checking if cmd %s can execute" name)
                canExec cmdParameter model)
        Xamarin.Forms.Command (execute, canExecute)

    /// Convert a sub-model
    let toSubView propMap = ViewModel<_, _>(model, dispatch, propMap)

    /// Convert sub-models on receipt of initial bindings
    let convert (name, binding) =
        match binding with
        | Bind getter -> name, Get getter
        | BindOneWayFromView setter -> name, Set setter
        | BindTwoWay (getter, setter) -> name, GetSet (getter, setter)
        | BindTwoWayValidation (getter, setter) -> name, GetSetValidate (getter, setter)
        | BindCmd (exec, canExec) -> name, Cmd (toCommand name (exec, canExec))
        | BindModel (_, propMap) -> name, Model (toSubView propMap)
        | BindMap (getter, mapper) -> name, Map (getter, mapper)

    do propMap |> List.map convert |> List.iter props.Add

    // Notifies the view of property changes 
    interface INotifyPropertyChanged with
        [<CLIEvent>]
        member __.PropertyChanged = propertyChanged.Publish
        
    // Notifies the view of validation errors
    interface INotifyDataErrorInfo with
        [<CLIEvent>]
        member __.ErrorsChanged = errorsChanged.Publish
        member __.HasErrors = errors.Count > 0
        member __.GetErrors propName = 
            console.log (sprintf "Getting errors for %s" propName)
            let results = 
                match errors.TryGetValue propName with
                | true, errs -> errs
                | false, _ -> []
            results :> System.Collections.IEnumerable

    /// Used internally to update the model. Only properties that have changed are updated.
    member __.UpdateModel other =
        //console.log (sprintf "UpdateModel %A" (props.Keys |> Seq.toArray))
        let propDiff name prop =
            match prop with
            | Get getter 
            | GetSet (getter, _) 
            | GetSetValidate (getter, _) 
            | Map (getter, _) ->
                if getter model <> getter other then Some name else None
            | _ -> None

        let diffs = 
            props
            |> Seq.choose (fun kvp -> propDiff kvp.Key kvp.Value)
            |> Seq.toList
        
        model <- other
        notify diffs

    /// Used by the view to get and set values
    member __.Item 

        with get (name : string) : obj =

            if props.ContainsKey name then

                let value = 
                    match props.[name] with 
                    | Get getter 
                    | GetSetValidate (getter, _) 
                    | GetSet (getter, _) -> getter model
                    | Cmd c -> box c
                    | Model m -> box m
                    | Map (getter, mapper) -> getter model |> mapper
                    | Set setter -> invalidOp (sprintf "Prop Binding Not Settable: %s" name)

                console.log (sprintf "view: got %s = %A" name value)
                value

            else 
                console.log (sprintf "view: failed to get property %s" name)
                invalidOp (sprintf "Prop Binding Not Set: %s" name)

        and set (name : string) (value : obj) : unit =
            console.log (sprintf "view: set %s to %A" name value)

            if props.ContainsKey name then

                match props.[name] with 
                | Set setter
                | GetSet (_, setter) -> setter value model |> dispatch
                | GetSetValidate (_, setter) -> 
                    let errorsChanged() = errorsChanged.Trigger([| box self; box (DataErrorsChangedEventArgs(name)) |])

                    let resultOfSetting = 
                        try setter value model 
                        with exn -> Error (exn.ToString())

                    match resultOfSetting with
                    | Ok msg -> 
                        if errors.Remove(name) then errorsChanged()
                        dispatch msg 
                    | Error err ->
                        match errors.TryGetValue name with
                        | true, errs -> errors.[name] <- err :: errs
                        | false, _ -> errors.Add(name, [err])
                        errorsChanged()
                | _ -> 
                   console.log (sprintf "view: failed to set read-only property %s" name)
                   invalidOp "Unable to set read-only member"
            else 
                console.log (sprintf "view: failed to set unbound property %s" name)
                invalidOp (sprintf "Prop Binding Not Set: %s" name)


    /// Used by the view to try to get values 
    override this.TryGetMember (binder, result) = 
        console.log (sprintf "view: TryGetMember %s" binder.Name)
        if props.ContainsKey binder.Name then
            let v = this.[binder.Name] 
            result <- v
            true
        else false

    /// Used by the view to try to set values 
    override this.TrySetMember (binder, value) =
        console.log (sprintf "view: TrySetMember %s" binder.Name)
        if props.ContainsKey binder.Name then
            this.[binder.Name] <- value
        false
