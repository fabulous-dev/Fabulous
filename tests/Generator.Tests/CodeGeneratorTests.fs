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
        func data w |> ignore
        let actual = w.ToString().Replace("\r\n", "\n")
        actual |> should equal expected

    let testGenerateNamespace = testFunc generateNamespace
    let testGenerateAttributes = testFunc generateAttributes
    let testGenerateProto = testFunc generateProto
    let testGenerateBuildFunction = testFunc generateBuildFunction
    let testGenerateCreateFunction = testFunc generateCreateFunction
    let testGenerateUpdateFunction = testFunc generateUpdateFunction
    let testGenerateConstruct = testFunc generateConstruct
    let testGenerateBuilders = testFunc generateBuilders
    let testGenerateViewers = testFunc generateViewers
    let testGenerateConstructors = testFunc generateConstructors
    let testGenerateViewExtensions = testFunc generateViewExtensions

    [<Test>]
    let ``testGenerateNamespace should generate the namespace``() =
        testGenerateNamespace
            "Fabulous.DynamicViews"
            """
// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.DynamicViews

#nowarn "59" // cast always holds
#nowarn "66" // cast always holds
#nowarn "67" // cast always holds

"""

    [<Test>]
    let ``generateAttributes should generate the attributes``() =
        testGenerateAttributes
            [| "Property1"
               "Property2"
               "ElementCreated" |]
            """
module ViewAttributes =
    let Property1AttribKey : AttributeKey<_> = AttributeKey<_>("Property1")
    let Property2AttribKey : AttributeKey<_> = AttributeKey<_>("Property2")
    let ElementCreatedAttribKey : AttributeKey<(obj -> unit)> = AttributeKey<(obj -> unit)>("ElementCreated")

"""

    [<Test>]
    let ``generateProto should generate the Proto properties``() =
        testGenerateProto
            [| "Type1"
               "Type2" |]
            """
type ViewProto() =
    static member val ProtoType1 : ViewElement option = None with get, set
    static member val ProtoType2 : ViewElement option = None with get, set

"""

    [<Test>]
    let ``generateBuildFunction should generate a function for a control with no base control and no members``() =
        testGenerateBuildFunction
            { Name = "View"
              BaseName = None
              Members = [| |] }
            """
    /// Builds the attributes for a View in the view
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
    static member inline BuildButton(attribCount: int) = 
        let attribBuilder = ViewBuilders.BuildView(attribCount)
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
    static member inline BuildButton(attribCount: int,
                                     ?text: string) = 

        let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = new AttributesBuilder(attribCount)
        match text with None -> () | Some v -> attribBuilder.Add(ViewAttributes.TextAttribKey, (v)) 
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
    static member inline BuildButton(attribCount: int,
                                     ?id: string) = 
        let attribBuilder = ViewBuilders.BuildView(attribCount, ?id=id)
        attribBuilder

"""

    [<Test>]
    let ``generateBuildFunction should generate a function for a control with multiple immediate members and inherited members``() =
        testGenerateBuildFunction
            { Name = "Slider"
              BaseName = Some "View"
              Members =
                [| { Name = "minimumMaximum"; UniqueName = "MinimumMaximum"; InputType = "float * float"; ConvToModel = ""; IsInherited = false } 
                   { Name = "value"; UniqueName = "Value"; InputType = "double"; ConvToModel = ""; IsInherited = false } 
                   { Name = "valueChanged"; UniqueName = "ValueChanged"; InputType = "Xamarin.Forms.ValueChangedEventArgs -> unit"; ConvToModel = "(fun f -> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>(fun _sender args -> f args))"; IsInherited = false } 
                   { Name = "horizontalOptions"; UniqueName = "HorizontalOptions"; InputType = "Xamarin.Forms.LayoutOptions"; ConvToModel = ""; IsInherited = true } 
                   { Name = "verticalOptions"; UniqueName = "VerticalOptions"; InputType = "Xamarin.Forms.LayoutOptions"; ConvToModel = ""; IsInherited = true } 
                   { Name = "margin"; UniqueName = "Margin"; InputType = "obj"; ConvToModel = ""; IsInherited = true } |] }
            """
    /// Builds the attributes for a Slider in the view
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

        let attribBuilder = ViewBuilders.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin)
        match minimumMaximum with None -> () | Some v -> attribBuilder.Add(ViewAttributes.MinimumMaximumAttribKey, (v)) 
        match value with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ValueAttribKey, (v)) 
        match valueChanged with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ValueChangedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>(fun _sender args -> f args))(v)) 
        attribBuilder

"""

    [<Test>]
    let ``generateCreateFunction should generate a create function with a custom constructor``() =
        testGenerateCreateFunction
            { Name = "ListView"
              FullName = "Xamarin.Forms.ListView"
              HasCustomConstructor = true
              TypeToInstantiate = "Fabulous.DynamicViews.CustomListView"
              Parameters = [||] }
            """
    static member val CreateFuncListView : (unit -> Xamarin.Forms.ListView) = (fun () -> ViewBuilders.CreateListView()) with get, set

    static member CreateListView () : Xamarin.Forms.ListView =
        failwith "can't create Xamarin.Forms.ListView"

"""

    [<Test>]
    let ``generateCreateFunction should generate a create function with no parameter``() =
        testGenerateCreateFunction
            { Name = "ListView"
              FullName = "Xamarin.Forms.ListView"
              HasCustomConstructor = false
              TypeToInstantiate = "Fabulous.DynamicViews.CustomListView"
              Parameters = [||] }
            """
    static member val CreateFuncListView : (unit -> Xamarin.Forms.ListView) = (fun () -> ViewBuilders.CreateListView()) with get, set

    static member CreateListView () : Xamarin.Forms.ListView =
        upcast (new Fabulous.DynamicViews.CustomListView())

"""

    // TODO : The related part makes little sense and it was really used, it would fail to compile. We need to investigate this.    
    [<Test>]
    let ``generateCreateFunction should generate a create function with parameters``() =
        testGenerateCreateFunction
            { Name = "ListView"
              FullName = "Xamarin.Forms.ListView"
              HasCustomConstructor = false
              TypeToInstantiate = "Fabulous.DynamicViews.CustomListView"
              Parameters = [| "parameter1"; "parameter2" |] }
            """
    static member val CreateFuncListView : (unit -> Xamarin.Forms.ListView) = (fun () -> ViewBuilders.CreateListView()) with get, set

    static member CreateListView () : Xamarin.Forms.ListView =
        match parameter1, parameter2 with
        | Some parameter1, Some parameter2 ->
            upcast (new Fabulous.DynamicViews.CustomListView(parameter1, parameter2))
        | _ -> upcast (new Fabulous.DynamicViews.CustomListView())

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
    static member val UpdateFuncIGestureRecognizer =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.IGestureRecognizer) -> ViewBuilders.UpdateIGestureRecognizer (prevOpt, curr, target)) 

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
    static member val UpdateFuncTemplatedView =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.TemplatedView) -> ViewBuilders.UpdateTemplatedView (prevOpt, curr, target)) 

    static member UpdateTemplatedView (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.TemplatedView) = 
        // update the inherited Layout element
        let baseElement = (if ViewProto.ProtoLayout.IsNone then ViewProto.ProtoLayout <- Some (ViewBuilders.ConstructLayout())); ViewProto.ProtoLayout.Value
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
              ImmediateMembers =
                [| // Parameter
                   { Name = "Parameter"; UniqueName = "ListViewParameter"; ModelType = "bool"; DefaultValue = "false"; ConvToValue = ""; UpdateCode = ""; ElementTypeFullName = None; IsParameter = true; BoundType = None; Attached = [| |] }
                   // Collection property (no attached property - no UpdateCode - no ConvToValue)
                   { Name = "Collection"; UniqueName = "ListViewCollection"; ModelType = "bool list"; DefaultValue = "[]"; ConvToValue = ""; UpdateCode = ""; ElementTypeFullName = Some "bool"; IsParameter = false; BoundType = None; Attached = [| |] }
                   // Member with a known type (no UpdateCode - no ConvToValue)
                   { Name = "Content"; UniqueName = "ListViewContent"; ModelType = "Xamarin.Forms.View"; DefaultValue = "null"; ConvToValue = ""; UpdateCode = ""; ElementTypeFullName = None; IsParameter = false; BoundType = Some { Name = "View"; FullName = "Xamarin.Forms.View" }; Attached = [| |] }
                   // Event (no UpdateCode - no ConvToValue)
                   { Name = "Event"; UniqueName = "ListViewEvent"; ModelType = "System.EventHandler"; DefaultValue = ""; ConvToValue = ""; UpdateCode = ""; ElementTypeFullName = None; IsParameter = false; BoundType = Some { Name = "System.EventHandler"; FullName = "System.EventHandler" }; Attached = [| |] }
                   // Event with one generic type (no UpdateCode - no ConvToValue)
                   { Name = "ItemSelected"; UniqueName = "ListViewItemSelected"; ModelType = "System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>"; DefaultValue = ""; ConvToValue = ""; UpdateCode = ""; ElementTypeFullName = None; IsParameter = false; BoundType = Some { Name = "System.EventHandler`1"; FullName = "System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>" }; Attached = [| |] }
                   // Member with custom UpdateCode
                   { Name = "Items"; UniqueName = "ListViewItems"; ModelType = "seq<ViewElement>"; DefaultValue = ""; ConvToValue = ""; UpdateCode = "updateListViewItems"; ElementTypeFullName = Some "ViewElement"; IsParameter = false; BoundType = Some { Name = "seq<ViewElement>"; FullName = "seq<Fabulous.DynamicView.ViewElement>" }; Attached = [| |] }
                   // Member with custom ConvToValue
                   { Name = "MemberConvToValue"; UniqueName = "ListViewMemberConvToValue"; ModelType = "string"; DefaultValue = "false"; ConvToValue = "bool"; UpdateCode = ""; ElementTypeFullName = None; IsParameter = false; BoundType = Some { Name = "string"; FullName = "System.String" }; Attached = [| |] }
                   // Member (no UpdateCode - no ConvToValue)
                   { Name = "Member"; UniqueName = "ListViewMember"; ModelType = "bool"; DefaultValue = "false"; ConvToValue = ""; UpdateCode = ""; ElementTypeFullName = None; IsParameter = false; BoundType = Some { Name = "bool"; FullName = "System.Boolean" }; Attached = [| |] } |]
              KnownTypes = [| "Xamarin.Forms.View" |] }
            """
    static member val UpdateFuncListView =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ListView) -> ViewBuilders.UpdateListView (prevOpt, curr, target)) 

    static member UpdateListView (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.ListView) = 
        // update the inherited View element
        let baseElement = (if ViewProto.ProtoView.IsNone then ViewProto.ProtoView <- Some (ViewBuilders.ConstructView())); ViewProto.ProtoView.Value
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
            if kvp.Key = ViewAttributes.ListViewParameterAttribKey.KeyValue then 
                currListViewParameterOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = ViewAttributes.ListViewCollectionAttribKey.KeyValue then 
                currListViewCollectionOpt <- ValueSome (kvp.Value :?> bool list)
            if kvp.Key = ViewAttributes.ListViewContentAttribKey.KeyValue then 
                currListViewContentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.View)
            if kvp.Key = ViewAttributes.ListViewEventAttribKey.KeyValue then 
                currListViewEventOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            if kvp.Key = ViewAttributes.ListViewItemSelectedAttribKey.KeyValue then 
                currListViewItemSelectedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>)
            if kvp.Key = ViewAttributes.ListViewItemsAttribKey.KeyValue then 
                currListViewItemsOpt <- ValueSome (kvp.Value :?> seq<ViewElement>)
            if kvp.Key = ViewAttributes.ListViewMemberConvToValueAttribKey.KeyValue then 
                currListViewMemberConvToValueOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = ViewAttributes.ListViewMemberAttribKey.KeyValue then 
                currListViewMemberOpt <- ValueSome (kvp.Value :?> bool)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.ListViewParameterAttribKey.KeyValue then 
                    prevListViewParameterOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = ViewAttributes.ListViewCollectionAttribKey.KeyValue then 
                    prevListViewCollectionOpt <- ValueSome (kvp.Value :?> bool list)
                if kvp.Key = ViewAttributes.ListViewContentAttribKey.KeyValue then 
                    prevListViewContentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.View)
                if kvp.Key = ViewAttributes.ListViewEventAttribKey.KeyValue then 
                    prevListViewEventOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                if kvp.Key = ViewAttributes.ListViewItemSelectedAttribKey.KeyValue then 
                    prevListViewItemSelectedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>)
                if kvp.Key = ViewAttributes.ListViewItemsAttribKey.KeyValue then 
                    prevListViewItemsOpt <- ValueSome (kvp.Value :?> seq<ViewElement>)
                if kvp.Key = ViewAttributes.ListViewMemberConvToValueAttribKey.KeyValue then 
                    prevListViewMemberConvToValueOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = ViewAttributes.ListViewMemberAttribKey.KeyValue then 
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
    let ``generateConstruct should generate a construct function for a type with no member``() =
        testGenerateConstruct
            { Name = "View"
              FullName = "Xamarin.Forms.View"
              Members = [| |]}
            """
    static member inline ConstructView() = 

        let attribBuilder = ViewBuilders.BuildView(0)

        ViewElement.Create<Xamarin.Forms.View>(ViewBuilders.CreateFuncView, ViewBuilders.UpdateFuncView, attribBuilder)

"""

    [<Test>]
    let ``generateConstruct should generate a construct function for a type with members``() =
        testGenerateConstruct
            { Name = "Button"
              FullName = "Xamarin.Forms.Button"
              Members =
                [| { LowerShortName = "text"; InputType = "string" }
                   { LowerShortName = "canExecute"; InputType = "bool" }
                   { LowerShortName = "created"; InputType = "" }
                   { LowerShortName = "ref"; InputType = "" } |] }
            """
    static member inline ConstructButton(?text: string,
                                         ?canExecute: bool,
                                         ?created: (Xamarin.Forms.Button -> unit),
                                         ?ref: ViewRef<Xamarin.Forms.Button>) = 

        let attribBuilder = ViewBuilders.BuildButton(0,
                               ?text=text,
                               ?canExecute=canExecute,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Button> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Button>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.Button>(ViewBuilders.CreateFuncButton, ViewBuilders.UpdateFuncButton, attribBuilder)

"""

    [<Test>]
    let ``generateBuilders should generate all builder parts in a specific order``() =
        let buildData : Fabulous.Generator.CodeGeneratorModels.BuildData = 
            { Name = "Button"
              BaseName = Some "View"
              Members =
                [| { Name = "text"; UniqueName = "Text"; InputType = "string"; ConvToModel = ""; IsInherited = false } |] }

        let createData : Fabulous.Generator.CodeGeneratorModels.CreateData =
            { Name = "Button"
              FullName = "Xamarin.Forms.Button"
              HasCustomConstructor = false
              TypeToInstantiate = "Xamarin.Forms.Button"
              Parameters = [||] }

        let updateData : Fabulous.Generator.CodeGeneratorModels.UpdateData =
            { Name = "Button"
              FullName = "Xamarin.Forms.Button"
              BaseName = Some "View"
              ImmediateMembers =
                [| { Name = "Text"
                     UniqueName = "Text"
                     ModelType = "string"
                     DefaultValue = "null"
                     ConvToValue = ""
                     UpdateCode = ""
                     ElementTypeFullName = None
                     IsParameter = false
                     BoundType = None
                     Attached = [||] } |]
              KnownTypes = [| |] }

        let constructData : Fabulous.Generator.CodeGeneratorModels.ConstructData =
            { Name = "Button"
              FullName = "Xamarin.Forms.Button"
              Members =
                [| { LowerShortName = "text"
                     InputType = "string" } |] }

        let buttonBuilderData : Fabulous.Generator.CodeGeneratorModels.BuilderData =
            { Build = buildData
              Create = createData
              Update = updateData
              Construct = constructData }

        testGenerateBuilders
            [| buttonBuilderData |]
            """
type ViewBuilders() =
    /// Builds the attributes for a Button in the view
    static member inline BuildButton(attribCount: int,
                                     ?text: string) = 

        let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildView(attribCount)
        match text with None -> () | Some v -> attribBuilder.Add(ViewAttributes.TextAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncButton : (unit -> Xamarin.Forms.Button) = (fun () -> ViewBuilders.CreateButton()) with get, set

    static member CreateButton () : Xamarin.Forms.Button =
        upcast (new Xamarin.Forms.Button())

    static member val UpdateFuncButton =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Button) -> ViewBuilders.UpdateButton (prevOpt, curr, target)) 

    static member UpdateButton (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Button) = 
        // update the inherited View element
        let baseElement = (if ViewProto.ProtoView.IsNone then ViewProto.ProtoView <- Some (ViewBuilders.ConstructView())); ViewProto.ProtoView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevTextOpt = ValueNone
        let mutable currTextOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.TextAttribKey.KeyValue then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.TextAttribKey.KeyValue then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
        match prevTextOpt, currTextOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Text <-  currValue
        | ValueSome _, ValueNone -> target.Text <- null
        | ValueNone, ValueNone -> ()

    static member inline ConstructButton(?text: string) = 

        let attribBuilder = ViewBuilders.BuildButton(0,
                               ?text=text)

        ViewElement.Create<Xamarin.Forms.Button>(ViewBuilders.CreateFuncButton, ViewBuilders.UpdateFuncButton, attribBuilder)

"""

    [<Test>]
    let ``generateViewers should generate helpers to help extract data from ViewElement``() =
        testGenerateViewers
            [| { Name = "Button"
                 FullName = "Xamarin.Forms.Button"
                 BaseName = None
                 Members =
                    [| { Name = "Text"
                         UniqueName = "ButtonText" }
                       { Name = "Command"
                         UniqueName = "ButtonCommand" }
                       { Name = "Ref"
                         UniqueName = "Ref" }
                       { Name = "Created"
                         UniqueName = "Created" } |] }
               { Name = "Label"
                 FullName = "Xamarin.Forms.Label"
                 BaseName = Some "Element"
                 Members =
                    [| { Name = "Text"
                         UniqueName = "LabelText" } |] } |]
            """
/// Viewer that allows to read the properties of a ViewElement representing a Button
type ButtonViewer(element: ViewElement) =
    do if not ((typeof<Xamarin.Forms.Button>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.Button' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the Text property
    member this.Text = element.GetAttributeKeyed(ViewAttributes.ButtonTextAttribKey)
    /// Get the value of the Command property
    member this.Command = element.GetAttributeKeyed(ViewAttributes.ButtonCommandAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a Label
type LabelViewer(element: ViewElement) =
    inherit ElementViewer(element)
    do if not ((typeof<Xamarin.Forms.Label>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.Label' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the Text property
    member this.Text = element.GetAttributeKeyed(ViewAttributes.LabelTextAttribKey)

"""

    [<Test>]
    let ``generateConstructors should generate constructors``() =
        testGenerateConstructors
            [| { Name = "Button"
                 FullName = "Xamarin.Forms.Button"
                 Members =
                    [| { LowerShortName = "text"
                         InputType = "string" }
                       { LowerShortName = "command"
                         InputType = "unit -> unit" }
                       { LowerShortName = "ref"
                         InputType = "" }
                       { LowerShortName = "created"
                         InputType = "" } |] }
               { Name = "Label"
                 FullName = "Xamarin.Forms.Label"
                 Members =
                    [| { LowerShortName = "text"
                         InputType = "string" } |] } |]
            """
type View() =
    /// Describes a Button in the view
    static member inline Button(?text: string,
                                ?command: unit -> unit,
                                ?ref: ViewRef<Xamarin.Forms.Button>,
                                ?created: (Xamarin.Forms.Button -> unit)) =

        ViewBuilders.ConstructButton(?text=text,
                               ?command=command,
                               ?ref=ref,
                               ?created=created)

    /// Describes a Label in the view
    static member inline Label(?text: string) =

        ViewBuilders.ConstructLabel(?text=text)


"""

    [<Test>]
    let ``generateViewExtensions should generate helpers``() =
        testGenerateViewExtensions
            [| { LowerShortName = "created";  LowerUniqueName = "created"; UniqueName = "Created"; InputType = "Xamarin.Forms.Slider -> unit"; ConvToModel = "" }
               { LowerShortName = "ref";  LowerUniqueName = "ref"; UniqueName = "Ref"; InputType = "ViewRef<Xamarin.Forms.Slider>"; ConvToModel = "" }
               { LowerShortName = "minimumMaximum";  LowerUniqueName = "minimumMaximum"; UniqueName = "MinimumMaximum"; InputType = "float * float"; ConvToModel = "" }
               { LowerShortName = "valueChanged";  LowerUniqueName = "sliderValueChanged"; UniqueName = "SliderValueChanged"; InputType = "Xamarin.Forms.ValueChangedEventArgs -> unit"; ConvToModel = "(fun f -> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>(fun _sender args -> f args))" } |]
            """
[<AutoOpen>]
module ViewElementExtensions = 

    type ViewElement with

        /// Adjusts the MinimumMaximum property in the visual element
        member x.MinimumMaximum(value: float * float) = x.WithAttribute(ViewAttributes.MinimumMaximumAttribKey, (value))

        /// Adjusts the SliderValueChanged property in the visual element
        member x.SliderValueChanged(value: Xamarin.Forms.ValueChangedEventArgs -> unit) = x.WithAttribute(ViewAttributes.SliderValueChangedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>(fun _sender args -> f args))(value))

        member x.With(?minimumMaximum: float * float, ?sliderValueChanged: Xamarin.Forms.ValueChangedEventArgs -> unit) =
            let x = match minimumMaximum with None -> x | Some opt -> x.MinimumMaximum(opt)
            let x = match sliderValueChanged with None -> x | Some opt -> x.SliderValueChanged(opt)
            x

    /// Adjusts the MinimumMaximum property in the visual element
    let minimumMaximum (value: float * float) (x: ViewElement) = x.MinimumMaximum(value)
    /// Adjusts the SliderValueChanged property in the visual element
    let sliderValueChanged (value: Xamarin.Forms.ValueChangedEventArgs -> unit) (x: ViewElement) = x.SliderValueChanged(value)
"""
