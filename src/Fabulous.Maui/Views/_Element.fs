namespace Fabulous.Maui

open Microsoft.Maui

type FabElement(handler) =
    inherit NodeWithHandler(handler)
    
    interface IElement with
        member this.Handler
            with get () = this.Handler
            and set value = this.Handler <- value
            
        member this.Parent = this.Parent