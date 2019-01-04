// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Generator.Tests

open NUnit.Framework
open FsUnit
open Fabulous.Generator.CodeGenerator
open System.IO

module ``CodeGenerator Tests`` =
    let testFunc func data (expectedStr: string) =
        let expected = expectedStr.Replace("\r\n", "\n").Substring(1)
        use w = new StringWriter()
        func data w
        let actual = w.ToString()
        actual |> should equal expected

    let testGenerateNamespaceAndClass = testFunc generateNamespaceAndClass
    let testGenerateAttributes = testFunc generateAttributes
    let testGenerateBuildFunction = testFunc generateBuildFunction
    let testGenerateUpdateFunction = testFunc generateUpdateFunction
    let testGenerateConstructor = testFunc generateConstructor
    let testGenerateProto = testFunc generateProto
    let testGenerateViewExtensions = testFunc generateViewExtensions

    [<Test>]
    let ``generateNamespaceAndClass should generate the namespace and View type``() =
        testGenerateNamespaceAndClass
            "Fabulous.DynamicViews"
            """
// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.DynamicViews

#nowarn "59" // cast always holds
#nowarn "66" // cast always holds
#nowarn "67" // cast always holds

type View() =
"""

    [<Test>]
    let ``generateAttributes should generate the attributes``() =
        testGenerateAttributes
            [| "Property1"
               "Property2" |]
            """
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _Property1AttribKey : AttributeKey<_> = AttributeKey<_>("Property1")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _Property2AttribKey : AttributeKey<_> = AttributeKey<_>("Property2")
"""

    [<Test>]
    let ``generateBuildFunction should generate a function for a control with no base control and no members``() =
        testGenerateBuildFunction
            { Name = "View"
              BaseName = None
              Members = [| |] }
            """
    /// Builds the attributes for a View in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildView(attribCount: int) = 
        let attribBuilder = new AttributesBuilder(attribCount)
        attribBuilder
"""

    [<Test>]
    let ``generateBuildFunction should generate a function for a control with a base control but no members``() =
        testGenerateBuildFunction
            { Name = "Button"
              BaseName = Some "View"
              Members = [| |] }
            """
    /// Builds the attributes for a Button in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildButton(attribCount: int) = 
        let attribBuilder = View.BuildView(attribCount)
        attribBuilder
"""

    [<Test>]
    let ``generateBuildFunction should generate a function for a control with no base control and only one immediate member``() =
        testGenerateBuildFunction
            { Name = "Button"
              BaseName = None
              Members = [| { Name = "text"; UniqueName = "Text"; InputType = "string"; ConvToModel = ""; IsInherited = false } |] }
            """
    /// Builds the attributes for a Button in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildButton(attribCount: int,
                                     ?text: string) = 

        let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = new AttributesBuilder(attribCount)
        match text with None -> () | Some v -> attribBuilder.Add(View._TextAttribKey, (v)) 
        attribBuilder
"""

    [<Test>]
    let ``generateBuildFunction should generate a function for a control with a base control and only one inherited member``() =
        testGenerateBuildFunction
            { Name = "Button"
              BaseName = Some "View"
              Members = [| { Name = "id"; UniqueName = "Id"; InputType = "string"; ConvToModel = ""; IsInherited = true } |] }
            """
    /// Builds the attributes for a Button in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildButton(attribCount: int,
                                     ?id: string) = 
        let attribBuilder = View.BuildView(attribCount, ?id=id)
        attribBuilder
"""

    [<Test>]
    let ``generateBuildFunction should generate a function for a control with multiple immediate members and inherited members``() =
        testGenerateBuildFunction
            { Name = "Slider"
              BaseName = Some "View"
              Members = [|
                { Name = "minimumMaximum"; UniqueName = "MinimumMaximum"; InputType = "float * float"; ConvToModel = ""; IsInherited = false } 
                { Name = "value"; UniqueName = "Value"; InputType = "double"; ConvToModel = ""; IsInherited = false } 
                { Name = "valueChanged"; UniqueName = "ValueChanged"; InputType = "Xamarin.Forms.ValueChangedEventArgs -> unit"; ConvToModel = "(fun f -> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>(fun _sender args -> f args))"; IsInherited = false } 
                { Name = "horizontalOptions"; UniqueName = "HorizontalOptions"; InputType = "Xamarin.Forms.LayoutOptions"; ConvToModel = ""; IsInherited = true } 
                { Name = "verticalOptions"; UniqueName = "VerticalOptions"; InputType = "Xamarin.Forms.LayoutOptions"; ConvToModel = ""; IsInherited = true } 
                { Name = "margin"; UniqueName = "Margin"; InputType = "obj"; ConvToModel = ""; IsInherited = true } 
              |] }
            """
    /// Builds the attributes for a Slider in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildSlider(attribCount: int,
                                     ?minimumMaximum: float * float,
                                     ?value: double,
                                     ?valueChanged: Xamarin.Forms.ValueChangedEventArgs -> unit,
                                     ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                     ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                     ?margin: obj) = 

        let attribCount = match minimumMaximum with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match value with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match valueChanged with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin)
        match minimumMaximum with None -> () | Some v -> attribBuilder.Add(View._MinimumMaximumAttribKey, (v)) 
        match value with None -> () | Some v -> attribBuilder.Add(View._ValueAttribKey, (v)) 
        match valueChanged with None -> () | Some v -> attribBuilder.Add(View._ValueChangedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>(fun _sender args -> f args))(v)) 
        attribBuilder
"""

    [<Test>]
    let ``generateUpdateFunction should generate an update function for a type with no base type and no member``() =
        testGenerateUpdateFunction
            { Name = "IGestureRecognizer"
              FullName = "Xamarin.Forms.IGestureRecognizer"
              BaseName = None
              ImmediateMembers = [| |]
              KnownTypes = [| |] }
            """
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncIGestureRecognizer = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.IGestureRecognizer) -> View.UpdateIGestureRecognizer (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateIGestureRecognizer (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.IGestureRecognizer) = 
        ignore prevOpt
        ignore curr
        ignore target
"""

    [<Test>]
    let ``generateUpdateFunction should generate an update function for a type with a base type but no member``() =
        testGenerateUpdateFunction
            { Name = "TemplatedView"
              FullName = "Xamarin.Forms.TemplatedView"
              BaseName = Some "Layout"
              ImmediateMembers = [| |]
              KnownTypes = [| |] }
            """
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncTemplatedView = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.TemplatedView) -> View.UpdateTemplatedView (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateTemplatedView (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.TemplatedView) = 
        // update the inherited Layout element
        let baseElement = (if View.ProtoLayout.IsNone then View.ProtoLayout <- Some (View.Layout())); View.ProtoLayout.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        ignore prevOpt
        ignore curr
        ignore target
"""

    [<Test>]
    let ``generateUpdateFunction should generate an update function for a type with various members``() =
        testGenerateUpdateFunction
            { Name = "ListView"
              FullName = "Xamarin.Forms.ListView"
              BaseName = Some "View"
              ImmediateMembers = [|
                // Parameter
                { Name = "Parameter"; UniqueName = "ListViewParameter"; ModelType = "bool"; DefaultValue = "false"; ConvToValue = ""; UpdateCode = ""; ElementTypeFullName = None; IsParameter = true; BoundType = None; Attached = [| |] }
                // Collection property (no attached property - no UpdateCode - no ConvToValue)
                { Name = "Collection"; UniqueName = "ListViewCollection"; ModelType = "bool list"; DefaultValue = "[]"; ConvToValue = ""; UpdateCode = ""; ElementTypeFullName = Some "bool"; IsParameter = false; BoundType = None; Attached = [| |] }
                // Member with a known type (no UpdateCode - no ConvToValue)
                { Name = "Content"; UniqueName = "ListViewContent"; ModelType = "Xamarin.Forms.View"; DefaultValue = "null"; ConvToValue = ""; UpdateCode = ""; ElementTypeFullName = None; IsParameter = false; BoundType = Some ("View", "Xamarin.Forms.View"); Attached = [| |] }
                // Event (no UpdateCode - no ConvToValue)
                { Name = "Event"; UniqueName = "ListViewEvent"; ModelType = "System.EventHandler"; DefaultValue = ""; ConvToValue = ""; UpdateCode = ""; ElementTypeFullName = None; IsParameter = false; BoundType = Some ("System.EventHandler", "System.EventHandler"); Attached = [| |] }
                // Event with one generic type (no UpdateCode - no ConvToValue)
                { Name = "ItemSelected"; UniqueName = "ListViewItemSelected"; ModelType = "System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>"; DefaultValue = ""; ConvToValue = ""; UpdateCode = ""; ElementTypeFullName = None; IsParameter = false; BoundType = Some ("System.EventHandler`1", "System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>"); Attached = [| |] }
                // Member with custom UpdateCode
                { Name = "Items"; UniqueName = "ListViewItems"; ModelType = "seq<ViewElement>"; DefaultValue = ""; ConvToValue = ""; UpdateCode = "updateListViewItems"; ElementTypeFullName = Some "ViewElement"; IsParameter = false; BoundType = Some ("seq<ViewElement>", "seq<Fabulous.DynamicView.ViewElement>"); Attached = [| |] }
                // Member with custom ConvToValue
                { Name = "MemberConvToValue"; UniqueName = "ListViewMemberConvToValue"; ModelType = "string"; DefaultValue = "false"; ConvToValue = "bool"; UpdateCode = ""; ElementTypeFullName = None; IsParameter = false; BoundType = Some ("string", "System.String"); Attached = [| |] }
                // Member (no UpdateCode - no ConvToValue)
                { Name = "Member"; UniqueName = "ListViewMember"; ModelType = "bool"; DefaultValue = "false"; ConvToValue = ""; UpdateCode = ""; ElementTypeFullName = None; IsParameter = false; BoundType = Some ("bool", "System.Boolean"); Attached = [| |] }
              |]
              KnownTypes = [| "Xamarin.Forms.View" |] }
            """
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncListView = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ListView) -> View.UpdateListView (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateListView (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.ListView) = 
        // update the inherited View element
        let baseElement = (if View.ProtoView.IsNone then View.ProtoView <- Some (View.View())); View.ProtoView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevListViewParameterOpt = ValueNone
        let mutable currListViewParameterOpt = ValueNone
        let mutable prevListViewCollectionOpt = ValueNone
        let mutable currListViewCollectionOpt = ValueNone
        let mutable prevListViewContentOpt = ValueNone
        let mutable currListViewContentOpt = ValueNone
        let mutable prevListViewEventOpt = ValueNone
        let mutable currListViewEventOpt = ValueNone
        let mutable prevListViewItemSelectedOpt = ValueNone
        let mutable currListViewItemSelectedOpt = ValueNone
        let mutable prevListViewItemsOpt = ValueNone
        let mutable currListViewItemsOpt = ValueNone
        let mutable prevListViewMemberConvToValueOpt = ValueNone
        let mutable currListViewMemberConvToValueOpt = ValueNone
        let mutable prevListViewMemberOpt = ValueNone
        let mutable currListViewMemberOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._ListViewParameterAttribKey.KeyValue then 
                currListViewParameterOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._ListViewCollectionAttribKey.KeyValue then 
                currListViewCollectionOpt <- ValueSome (kvp.Value :?> bool list)
            if kvp.Key = View._ListViewContentAttribKey.KeyValue then 
                currListViewContentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.View)
            if kvp.Key = View._ListViewEventAttribKey.KeyValue then 
                currListViewEventOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            if kvp.Key = View._ListViewItemSelectedAttribKey.KeyValue then 
                currListViewItemSelectedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>)
            if kvp.Key = View._ListViewItemsAttribKey.KeyValue then 
                currListViewItemsOpt <- ValueSome (kvp.Value :?> seq<ViewElement>)
            if kvp.Key = View._ListViewMemberConvToValueAttribKey.KeyValue then 
                currListViewMemberConvToValueOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._ListViewMemberAttribKey.KeyValue then 
                currListViewMemberOpt <- ValueSome (kvp.Value :?> bool)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._ListViewParameterAttribKey.KeyValue then 
                    prevListViewParameterOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._ListViewCollectionAttribKey.KeyValue then 
                    prevListViewCollectionOpt <- ValueSome (kvp.Value :?> bool list)
                if kvp.Key = View._ListViewContentAttribKey.KeyValue then 
                    prevListViewContentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.View)
                if kvp.Key = View._ListViewEventAttribKey.KeyValue then 
                    prevListViewEventOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                if kvp.Key = View._ListViewItemSelectedAttribKey.KeyValue then 
                    prevListViewItemSelectedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>)
                if kvp.Key = View._ListViewItemsAttribKey.KeyValue then 
                    prevListViewItemsOpt <- ValueSome (kvp.Value :?> seq<ViewElement>)
                if kvp.Key = View._ListViewMemberConvToValueAttribKey.KeyValue then 
                    prevListViewMemberConvToValueOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._ListViewMemberAttribKey.KeyValue then 
                    prevListViewMemberOpt <- ValueSome (kvp.Value :?> bool)
        updateCollectionGeneric prevListViewCollectionOpt currListViewCollectionOpt target.Collection
            (fun (x:ViewElement) -> x.Create() :?> bool)
            (fun _ _ _ -> ())
            canReuseChild
            updateChild
        match prevListViewContentOpt, currListViewContentOpt with
        // For structured objects, dependsOn on reference equality
        | ValueSome prevValue, ValueSome newValue when identical prevValue newValue -> ()
        | ValueSome prevValue, ValueSome newValue when canReuseChild prevValue newValue ->
            newValue.UpdateIncremental(prevValue, target.Content)
        | _, ValueSome newValue ->
            target.Content <- (newValue.Create() :?> Xamarin.Forms.View)
        | ValueSome _, ValueNone ->
            target.Content <- null
        | ValueNone, ValueNone -> ()
        match prevListViewEventOpt, currListViewEventOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.Event.RemoveHandler(prevValue); target.Event.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.Event.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.Event.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()
        match prevListViewItemSelectedOpt, currListViewItemSelectedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.ItemSelected.RemoveHandler(prevValue); target.ItemSelected.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.ItemSelected.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.ItemSelected.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()
        updateListViewItems prevListViewItemsOpt currListViewItemsOpt target
        match prevListViewMemberConvToValueOpt, currListViewMemberConvToValueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.MemberConvToValue <- bool currValue
        | ValueSome _, ValueNone -> target.MemberConvToValue <- false
        | ValueNone, ValueNone -> ()
        match prevListViewMemberOpt, currListViewMemberOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Member <-  currValue
        | ValueSome _, ValueNone -> target.Member <- false
        | ValueNone, ValueNone -> ()
"""

    [<Test>]
    let ``generateConstructor should generate a constructor for a type with no member``() =
        testGenerateConstructor
            { Name = "View"
              FullName = "Xamarin.Forms.View"
              Members = [|
              |]}
            """
    /// Describes a View in the view
    static member inline View() = 

        let attribBuilder = View.BuildView(0)

        ViewElement.Create<Xamarin.Forms.View>(View.CreateFuncView, View.UpdateFuncView, attribBuilder)
"""

    [<Test>]
    let ``generateConstructor should generate a constructor for a type with members``() =
        testGenerateConstructor
            { Name = "Button"
              FullName = "Xamarin.Forms.Button"
              Members = [|
                "text", "string"
                "canExecute", "bool"
                "created", ""
                "ref", ""
              |]}
            """
    /// Describes a Button in the view
    static member inline Button(?text: string,
                                ?canExecute: bool,
                                ?created: (Xamarin.Forms.Button -> unit),
                                ?ref: ViewRef<Xamarin.Forms.Button>) = 

        let attribBuilder = View.BuildButton(0,
                               ?text=text,
                               ?canExecute=canExecute,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Button> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Button>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.Button>(View.CreateFuncButton, View.UpdateFuncButton, attribBuilder)
"""


    [<Test>]
    let ``generateProto should generate a static property``() =
        testGenerateProto
            "Button"
            """
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoButton : ViewElement option = None with get, set
"""

    [<Test>]
    let ``generateViewExtensions should generate helpers``() =
        testGenerateViewExtensions
            { Members = 
                [| { LowerShortName = "created";  LowerUniqueName = "created"; UniqueName = "Created"; InputType = "Xamarin.Forms.Slider -> unit"; ConvToModel = "" }
                   { LowerShortName = "ref";  LowerUniqueName = "ref"; UniqueName = "Ref"; InputType = "ViewRef<Xamarin.Forms.Slider>"; ConvToModel = "" }
                   { LowerShortName = "minimumMaximum";  LowerUniqueName = "minimumMaximum"; UniqueName = "MinimumMaximum"; InputType = "float * float"; ConvToModel = "" }
                   { LowerShortName = "valueChanged";  LowerUniqueName = "sliderValueChanged"; UniqueName = "SliderValueChanged"; InputType = "Xamarin.Forms.ValueChangedEventArgs -> unit"; ConvToModel = "(fun f -> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>(fun _sender args -> f args))" } |]}
            """
[<AutoOpen>]
module ViewElementExtensions = 

    type ViewElement with

        /// Adjusts the MinimumMaximum property in the visual element
        member x.MinimumMaximum(value: float * float) = x.WithAttribute(View._MinimumMaximumAttribKey, (value))

        /// Adjusts the SliderValueChanged property in the visual element
        member x.SliderValueChanged(value: Xamarin.Forms.ValueChangedEventArgs -> unit) = x.WithAttribute(View._SliderValueChangedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>(fun _sender args -> f args))(value))


    /// Adjusts the MinimumMaximum property in the visual element
    let minimumMaximum (value: float * float) (x: ViewElement) = x.MinimumMaximum(value)

    /// Adjusts the SliderValueChanged property in the visual element
    let sliderValueChanged (value: Xamarin.Forms.ValueChangedEventArgs -> unit) (x: ViewElement) = x.SliderValueChanged(value)
"""