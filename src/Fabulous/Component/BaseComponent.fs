namespace Fabulous

open System

[<AllowNullLiteral>]
type IBaseComponent =
    inherit IDisposable
    
module BaseComponent =
    // TODO: This is a big code smell. We should not do this but I can't think of a better way to do it right now.
    // The implementation of this method is set by the consuming project: Fabulous.XamarinForms, Fabulous.Maui, Fabulous.Avalonia
    let mutable setAttachedComponent: obj -> IBaseComponent -> unit =
        fun _ _ -> failwith "Please call Component.SetComponentFunctions() before using Component"

    let mutable getAttachedComponent: obj -> IBaseComponent =
        fun _ -> failwith "Please call Component.SetComponentFunctions() before using Component"

    let setComponentFunctions (get: obj -> IBaseComponent, set: obj -> IBaseComponent -> unit) =
        getAttachedComponent <- get
        setAttachedComponent <- set
        
[<AbstractClass>]
type BaseComponent(treeContext: ViewTreeContext, environmentContext: EnvironmentContext, context: ComponentContext) =
    let mutable _context = context
    
    member this.TreeContext = treeContext
    
    member this.EnvironmentContext = environmentContext
    
    member this.Context
        with get () = _context
        and set value = _context <- value
        
    interface IDisposable with
        member this.Dispose() =
            (this.Context :> IDisposable).Dispose()
            (this.EnvironmentContext :> IDisposable).Dispose()