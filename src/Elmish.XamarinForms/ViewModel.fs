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

and internal ViewModel<'model, 'msg>(m:'model, dispatch, propMap: ViewBindings<'model,'msg>, debug:bool) as self =
#if DynamicObject
    inherit System.Dynamic.DynamicObject()
#endif

    let log msg = if debug then console.log msg
    
    let props = new Dictionary<string, PropertyBinding<'model,'msg>>()

#if ErrorsChanged
    // Store all errors
    let errors = new Dictionary<string, string list>()
    let errorsChanged = new DelegateEvent<System.EventHandler<DataErrorsChangedEventArgs>>()
#endif

    // Current model
    let mutable model : 'model = m

    // For INotifyPropertyChanged
    let propertyChanged = Event<PropertyChangedEventHandler, PropertyChangedEventArgs> ()
    let notifyPropertyChanged name = 
        let key = "Item[" + name + "]"
        //log (sprintf "Notify %s" key)
        propertyChanged.Trigger(self, ComponentModel.PropertyChangedEventArgs key)

    let notify (p : string list) =
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

    let toSubView propMap = ViewModel<_,_>(model, dispatch, propMap, debug)

    let rec convert = 
        List.map (fun (name, binding) ->
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
        
#if ErrorsChanged
    // Notification of validation errors - supported by WPF
    // TODO: check out if Xamarin.Forms supports the same
    interface INotifyDataErrorInfo with
        [<CLIEvent>]
        member __.ErrorsChanged = errorsChanged.Publish
        member __.HasErrors = errors.Count > 0
        member __.GetErrors propName = 
            log (sprintf "Getting errors for %s" propName)
            match errors.TryGetValue propName with
            | true, errs -> errs
            | false, _ -> []
            :> System.Collections.IEnumerable
#endif    

    member __.UpdateModel other =
        //log (sprintf "UpdateModel %A" (props.Keys |> Seq.toArray))
        let propDiff name =
            function
            | Get getter | GetSet (getter, _) ->
                if getter model <> getter other then Some name else None
            | _ -> None

        let diffs = 
            props
            |> Seq.choose (fun kvp -> propDiff kvp.Key kvp.Value)
            |> Seq.toList
        
        model <- other
        notify diffs

    member __.Item 
        with get (name : string) =
            //log (sprintf "Get item %s" name)
            if props.ContainsKey name then
                match props.[name] with 
                | Get getter 
                | GetSet (getter,_)
                | GetSetValidate (getter,_) -> getter model
                | Cmd c -> unbox c
                | Model m -> unbox m
                | Map (getter,mapper) -> getter model |> mapper
            else 
                invalidOp <| sprintf "Prop Binding Not Set: %s" name
        and set (name : string) (value : obj) =
            //log (sprintf "Set item %s" name)
            if props.ContainsKey name then
                match props.[name] with 
                | GetSet (_, setter) -> setter value model |> dispatch
                | GetSetValidate (_,setter) -> 
#if ErrorsChanged
                    let errorsChanged() = errorsChanged.Trigger([| unbox this; unbox <| DataErrorsChangedEventArgs(binder.Name) |])
                    try 
                        match setter value model with
                        | Ok msg -> 
                            if errors.Remove(binder.Name) then errorsChanged()
                            dispatch msg 
                        | Error err ->
                            match errors.TryGetValue binder.Name with
                            | true, errs -> errors.[binder.Name] <- err :: errs
                            | false, _ -> errors.Add(binder.Name, [err])
                            errorsChanged()
                    with _err -> ()
#else
                    match setter value model with
                    | Ok msg -> 
                        dispatch msg 
                    | Error err ->
                        failwith err
#endif
                | _ -> invalidOp "Unable to set read-only member"
            else 
                invalidOp <| sprintf "Prop Binding Not Set: %s" name


#if DynamicObject
    // DynamicObject overrides - supported by WPF
    // TODO: check out if Xamarin.Forms supports the same

    override this.TryGetMember (binder, r) = 
        log (sprintf "TryGetMember %s" binder.Name)
        if props.ContainsKey binder.Name then
            let v = this.[binder.Name] 
            r <- v
            true
        else false

    override __.TrySetMember (binder, value) =
        log (sprintf "TrySetMember %s" binder.Name)
        if props.ContainsKey binder.Name then
            this.[binder.Name] <- value
        false
#endif        