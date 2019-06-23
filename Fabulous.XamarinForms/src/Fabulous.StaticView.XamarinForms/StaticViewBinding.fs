// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.StaticView
  
type internal Getter<'model> = 
    'model -> obj

type internal Setter<'model, 'msg> = 
    (*Value*)obj -> 'model -> 'msg

type internal Execute<'model, 'msg> = 
    (*CommandParameter*)obj -> 'model -> 'msg

type internal CanExecute<'model> = 
    (*CommandParameter*)obj -> 'model -> bool

type internal ValidSetter<'model,'msg> = 
    (*Value*)obj -> 'model -> Result<'msg,string>

type ViewBinding<'model, 'msg> = 
    string * ViewVariable<'model, 'msg>

and ViewBindings<'model, 'msg> = 
    ViewBinding<'model, 'msg> list

and ViewVariable<'model,'msg> =
    // representation is internal
    internal
    | Bind of Getter<'model>
    | BindOneWayToSource of Setter<'model,'msg>
    | BindTwoWay of Getter<'model> * Setter<'model,'msg>
    | BindTwoWayValidation of Getter<'model> * ValidSetter<'model,'msg>
    | BindCmd of Execute<'model,'msg> * CanExecute<'model>
    | BindSubModel of ViewSubModel<'model,'msg> 
    | BindMap of Getter<'model> * (obj (* '_a *) -> obj (* '_b *) )

and ViewSubModel<'model,'msg> = 
    // representation is internal
    internal
    | ViewSubModel of (obj -> unit) * string * ('model -> obj (* '_model *)) * (obj (* '_msg *) -> 'msg) * ViewBindings<obj (* '_model *),obj (* '_msg *) >
    member x.Name = (let (ViewSubModel(_, nm, _, _, _)) = x in nm)

[<RequireQualifiedAccess>]
module Binding =

    // Maps a set of view bindings to its parent view bindings
    let private boxVariable (variable: ViewVariable<'model,'msg>) : ViewVariable<obj,obj> =
        match variable with
        | Bind getter -> Bind (unbox >> getter)
        | BindOneWayToSource setter -> BindOneWayToSource (fun v m -> setter v (unbox m) |> box)
        | BindTwoWay (getter,setter) -> BindTwoWay (unbox >> getter, fun v m -> setter v (unbox m) |> box)
        | BindTwoWayValidation (getter,setter) -> BindTwoWayValidation (unbox >> getter, fun v m -> setter v (unbox m) |> Result.map box)
        | BindCmd (exec, canExec) -> BindCmd ((fun p m -> exec p (unbox m) |> box), (fun p m -> canExec p (unbox m)))
        | BindSubModel (ViewSubModel (page, name,getter,toMsg,bindings)) -> BindSubModel (ViewSubModel (page, name, unbox >> getter, toMsg >> box, bindings))
        | BindMap (getter,mapper) -> BindMap (unbox >> getter, mapper)

    let private boxBindings (viewBindings: ViewBindings<'model,'msg>) : ViewBindings<obj,obj> =
        viewBindings |> List.map (fun (n,v) -> n, boxVariable v)

    // Helper functions that clean up binding creation

    ///<summary>Model to view binding (i.e. BindingMode.OneWay)</summary>
    ///<param name="getter">Gets value from the model</param>
    ///<param name="name">Binding name</param>
    let oneWay (getter: 'model -> 'a) name : ViewBinding<'model,'msg> = 
        name, Bind (getter >> box)
    
    ///<summary>Both model to view and view to model (i.e. BindingMode.TwoWay)</summary>
    ///<param name="getter">Gets value from the model</param>
    ///<param name="setter">Setter function, returns a message to dispatch, typically to set the value in the model</param>
    ///<param name="name">Binding name</param>
    let twoWay (getter: 'model -> 'a) (setter: 'a -> 'msg) name : ViewBinding<'model,'msg> = 
        name, BindTwoWay (getter >> box, fun v _m -> setter (unbox v))
    
    ///<summary>View to model binding (i.e. BindingMode.OneWayToSource)</summary>
    ///<param name="setter">Setter function, returns a message to dispatch, typically to set the value in the model</param>
    ///<param name="name">Binding name</param>
    let oneWayFromView (setter: 'a -> 'msg) name : ViewBinding<'model,'msg> = 
        name, BindOneWayToSource (fun v _m -> setter (unbox v))
    
    ///<summary>Both model to view and view to model (i.e. BindingMode.TwoWay) with INotifyDataErrorInfo implementation)</summary>
    ///<param name="getter">Gets value from the model</param>
    ///<param name="setter">Validation function, returns a Result with the command to dispatch or an error string</param>
    ///<param name="name">Binding name</param>
    let twoWayValidation (getter: 'model -> 'a) (setter: 'a -> Result<'msg,string>) name : ViewBinding<'model,'msg> = 
        name, BindTwoWayValidation (getter >> box, fun v _m -> setter (unbox v))
        
    ///<summary>Command binding</summary>
    ///<param name="msg">A message to dispatch</param>
    ///<param name="name">Binding name</param>
    let msg msgToSend name : ViewBinding<'model,'msg> = 
        name, BindCmd ((fun _ _ -> msgToSend), (fun _ _ -> true))

    ///<summary>Command binding</summary>
    ///<param name="msgf">A function to create a message to dispatch</param>
    ///<param name="name">Binding name</param>
    let msgWithParam msgf name : ViewBinding<'model,'msg> = 
        name, BindCmd ((fun param _ -> msgf param), (fun _ _ -> true))

    ///<summary>Conditional command binding</summary>
    ///<param name="msgf">A function to create a message to dispatch</param>
    ///<param name="canExec">CanExecute function, returns a bool</param>
    ///<param name="name">Binding name</param>
    let msgIf msgToSend canExec name : ViewBinding<'model,'msg> = 
        name, BindCmd ((fun _ _ -> msgToSend), (fun _ m -> canExec m))
        
    ///<summary>Conditional command binding</summary>
    ///<param name="msg">Returns a message to dispatch</param>
    ///<param name="canExec">CanExecute function, returns a bool</param>
    ///<param name="name">Binding name</param>
    let msgWithParamIf msgf canExec name : ViewBinding<'model,'msg> = 
        name, BindCmd ((fun param _ -> msgf param), canExec)

    ///<summary>Sub-view binding</summary>
    ///<param name="initf">Initializes the sub-model</param>
    ///<param name="getter">Gets the sub-model from the base model</param>
    ///<param name="viewBinding">Set of view bindings for the sub-view</param>
    ///<param name="toMsg">Maps sub-messages to the base message type</param>
    ///<param name="name">Binding name</param>
    let subView init (getter: 'model -> '_model) (toMsg: '_msg -> 'msg) (viewBindings: ViewBindings<'_model,'_msg>)  name : ViewBinding<'model,'msg> = 
        name, BindSubModel (ViewSubModel (init, name, getter >> box, unbox >> toMsg, viewBindings |> boxBindings))
        
    ///<summary>One-way binding that applies a map when passing data to the view.
    /// Should be used for data that a view needs wrapped in some view-specific type. 
    /// For example when graphing a series, the data can be stored as a plain array in the model, 
    /// and then mapped to a SeriesCollection for the view.</summary>
    ///<param name="getter">Gets the value from the model</param>
    ///<param name="mapper">Maps the value for consumption by the view</param>
    ///<param name="name">Binding name</param>
    let oneWayMap (getter: 'model -> 'a) (mapper: 'a -> 'b) name : ViewBinding<'model,'msg> =
        name, BindMap (getter >> box, unbox >> mapper >> box)
