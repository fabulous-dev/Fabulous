namespace Fabulous.XamarinForms.Generator

open Fabulous.CodeGen.Binder.Models
open Fabulous.CodeGen.Generator

module XFPreparer =
    /// Some types have specific constraints that can't be easily declared in the json file.
    /// So we override some output here
    let prepareData (boundModel: BoundModel) =
        let preparedData = Preparer.prepareData boundModel
        { preparedData with
            Viewers = preparedData.Viewers
                      |> Array.map (fun d ->
                          match d.Name with
                          | "MultiPageOfT" -> { d with ViewerName = "MultiPageOfTViewer<'T when 'T :> Xamarin.Forms.Page>" }
                          | "CarouselPage" -> { d with InheritedViewerName = Some "MultiPageOfTViewer<Xamarin.Forms.ContentPage>" }
                          | _ -> d
                      ) }
