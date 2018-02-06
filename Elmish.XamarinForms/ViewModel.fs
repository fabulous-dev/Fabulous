namespace Elmish.XamarinForms.ViewModel

open System
open System.Collections.Generic
open System.ComponentModel
open Xamarin.Forms
open Elmish.XamarinForms

type internal PropertyBinding<'model,'msg> =
    | Get of Getter<'model>
    | GetSet of Getter<'model> * Setter<'model,'msg>
    | GetSetValidate of Getter<'model> * ValidSetter<'model,'msg>
    | Cmd of Xamarin.Forms.Command
    | Model of ViewModel<'model,'msg>
    | Map of Getter<'model> * (obj -> obj)

and ViewModel<'model, 'msg>(m:'model, dispatch, propMap: ViewBindings<'model,'msg>) as self =
//#if DynamicObject
    inherit System.Dynamic.DynamicObject()
//#endif

    let props = new Dictionary<string, PropertyBinding<'model,'msg>>()

    // Store all errors
    let errors = new Dictionary<string, string list>()
    let errorsChanged = new DelegateEvent<System.EventHandler<DataErrorsChangedEventArgs>>()

    // Current model
    let mutable model : 'model = m

    // For INotifyPropertyChanged
    let propertyChanged = Event<PropertyChangedEventHandler, PropertyChangedEventArgs> ()
    let notifyPropertyChanged name = 
        let key = "Item[" + name + "]"
        //log (sprintf "notifyPropertyChanged %s" key)
        propertyChanged.Trigger(self, PropertyChangedEventArgs key)

    let notify (p : string list) =
        console.log (sprintf "notify %A" p)
        p |> List.iter notifyPropertyChanged
        let raiseCanExecuteChanged accessor =
            match accessor with
            | Cmd c -> Device.BeginInvokeOnMainThread(fun () -> c.ChangeCanExecute ())
            | _ -> ()
        props |> List.ofSeq |> List.iter (fun kvp -> raiseCanExecuteChanged kvp.Value)
    

    let toCommand (exec, canExec) =
        let execute = Action (fun p -> exec p model |> dispatch)
        let canExecute = fun p -> canExec p model
        Xamarin.Forms.Command (execute, canExecute)

    let toSubView propMap = ViewModel<_,_>(model, dispatch, propMap)

    let convert ps = 
        ps |> List.map (fun (name, binding) ->
            match binding with
            | Bind getter -> name, Get getter
            | BindTwoWay (getter,setter) -> name, GetSet (getter,setter)
            | BindTwoWayValidation (getter,setter) -> name, GetSetValidate (getter,setter)
            | BindCmd (exec,canExec) -> name, Cmd (toCommand (exec,canExec))
            | BindModel (_, propMap) -> name, Model (toSubView propMap)
            | BindMap (getter,mapper) -> name, Map (getter,mapper)
        )

    do propMap |> convert |> List.iter props.Add

    interface INotifyPropertyChanged with
        [<CLIEvent>]
        member __.PropertyChanged = propertyChanged.Publish
        
    // Notification of validation errors
    interface INotifyDataErrorInfo with
        [<CLIEvent>]
        member __.ErrorsChanged = errorsChanged.Publish
        member __.HasErrors = errors.Count > 0
        member __.GetErrors propName = 
            console.log (sprintf "Getting errors for %s" propName)
            match errors.TryGetValue propName with
            | true, errs -> errs
            | false, _ -> []
            :> System.Collections.IEnumerable

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

    member __.Item 
        with get (name : string) : obj =
            //console.console.log (sprintf "Get item %s" name)
            if props.ContainsKey name then
                match props.[name] with 
                | Get getter 
                | GetSetValidate (getter,_) 
                | GetSet (getter,_) -> getter model
                | Cmd c -> box c
                | Model m -> box m
                | Map (getter,mapper) -> getter model |> mapper
            else 
                invalidOp (sprintf "Prop Binding Not Set: %s" name)

        and set (name : string) (value : obj) : unit =
            //console.log (sprintf "Set item %s" name)
            if props.ContainsKey name then
                match props.[name] with 
                | GetSet (_, setter) -> setter value model |> dispatch
                | GetSetValidate (_,setter) -> 
                    let errorsChanged() = errorsChanged.Trigger([| box self; box (DataErrorsChangedEventArgs(name)) |])
                    try 
                        match setter value model with
                        | Choice1Of2 msg -> 
                            if errors.Remove(name) then errorsChanged()
                            dispatch msg 
                        | Choice2Of2 err ->
                            match errors.TryGetValue name with
                            | true, errs -> errors.[name] <- err :: errs
                            | false, _ -> errors.Add(name, [err])
                            errorsChanged()
                    with _err -> ()
                | _ -> invalidOp "Unable to set read-only member"
            else 
                invalidOp (sprintf "Prop Binding Not Set: %s" name)


    override this.TryGetMember (binder, r) = 
        console.log (sprintf "TryGetMember %s" binder.Name)
        if props.ContainsKey binder.Name then
            let v = this.[binder.Name] 
            r <- v
            true
        else false

    override this.TrySetMember (binder, value) =
        console.log (sprintf "TrySetMember %s" binder.Name)
        if props.ContainsKey binder.Name then
            this.[binder.Name] <- value
        false
