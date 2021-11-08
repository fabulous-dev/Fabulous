namespace Fabulous.XamarinForms

open Fabulous

type ViewNode(key, attributes, context: ViewTreeContext) =
    static member ViewNodeProperty = Xamarin.Forms.BindableProperty.Create("ViewNode", typeof<ViewNode>, typeof<Xamarin.Forms.View>, null)

    member _.Context = context

    interface IViewNode with
        member _.ApplyDiff(diffs) = UpdateResult.Done
        member _.Attributes = attributes
        member _.Origin = key