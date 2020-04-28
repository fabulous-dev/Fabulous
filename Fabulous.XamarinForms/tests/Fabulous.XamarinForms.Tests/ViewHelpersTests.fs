// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.XamarinForms.Tests

open System.Collections.Generic
open Fabulous
open NUnit.Framework
open FsUnit
open Fabulous.XamarinForms

module ViewHelpersTests =

    [<Test>]
    let ``Given no element with an automation id, tryFindViewElement should return no element``() =
        View.NavigationPage(pages=[
            View.ContentPage(content=
                View.Grid(children=[
                    View.Label(text="Text")
                    View.StackLayout(children=[
                        View.Button(text="Button text")
                        View.Slider()
                    ])
                    View.Image()
                ])
            )
        ])
        |> tryFindViewElement "AutomationIdTest"
        |> should equal None

    [<Test>]
    let ``Given no element with a matching automation id, tryFindViewElement should return no element``() =
        View.NavigationPage(automationId="NavigationPage", pages=[
            View.ContentPage(automationId="ContentPageId", content=
                View.Grid(automationId="GridId", children=[
                    View.Label(automationId="LabelId", text="Text")
                    View.StackLayout(automationId="StackLayoutId", children=[
                        View.Button(automationId="ButtonId", text="Button text")
                        View.Slider(automationId="SliderId")
                    ])
                    View.Image(automationId="ImageId")
                ])
            )
        ])
        |> tryFindViewElement "AutomationIdTest"
        |> should equal None

    [<Test>]
    let ``Given an element with a matching automation id, tryFindViewElement should return the element`` () =
        let automationId = "ContentPageTest"
        let element = View.ContentPage(automationId=automationId)

        element
        |> tryFindViewElement automationId
        |> should equal (Some element)

    [<Test>]
    let ``Given an element with a matching automation id inside a NavigationPage, tryFindViewElement should return the element`` () =
        let automationId = "ContentPageTest"
        let element = View.ContentPage(automationId=automationId)

        View.NavigationPage(pages=[
            View.ContentPage(automationId="WrongPage1")
            element
            View.ContentPage(automationId="WrongPage2")
        ])
        |> tryFindViewElement automationId
        |> should equal (Some element)

    [<Test>]
    let ``Given an element with a matching automation id inside a ContentControl, tryFindViewElement should return the element`` () =
        let automationId = "LabelTest"
        let element = View.Label(automationId=automationId)

        View.ContentPage(content=
            element
        )
        |> tryFindViewElement automationId
        |> should equal (Some element)

    [<Test>]
    let ``Given an element with a matching automation id inside a layout, tryFindViewElement should return the element`` () =
        let automationId = "LabelTest"
        let element = View.Label(automationId=automationId)

        View.Grid(children=[
            View.Label(automationId="WrongLabel1")
            element
            View.Label(automationId="WrongLabel1")
        ])
        |> tryFindViewElement automationId
        |> should equal (Some element)

    [<Test>]
    let ``Given a complex view hierarchy, tryFindViewElement should return the first matching element`` () =
        let automationId = "ButtonId"
        let button = View.Button(automationId=automationId, text="Button text")

        View.NavigationPage(automationId="NavigationPage", pages=[
            View.ContentPage(automationId="ContentPage1Id", content=
                View.Grid(automationId="Grid1Id", children=[
                    View.Label(automationId="Label1Id", text="Text")
                    View.StackLayout(automationId="StackLayout1Id", children=[
                        button
                        View.Slider(automationId="Slider1Id")
                    ])
                    View.Image(automationId="Image1Id")
                ])
            )
            View.ContentPage(automationId="ContentPage2Id", content=
                View.Grid(automationId="Grid2Id", children=[
                    View.Label(automationId="Label2Id", text="Text")
                    View.StackLayout(automationId="StackLayout2Id", children=[
                        View.Button(automationId=automationId, text="Button text")
                        View.Slider(automationId="Slider2Id")
                    ])
                    View.Image(automationId="Image2Id")
                ])
            )
        ])
        |> tryFindViewElement automationId
        |> should equal (Some button)

    [<Test>]
    let ``Given an element with a matching automation id, findViewElement should return the element`` () =
        let automationId = "LabelTest"
        let element = View.Label(automationId=automationId)

        View.ContentPage(content=
            element
        )
        |> findViewElement automationId
        |> should equal element

    [<Test>]
    let ``Given no element with a matching automation id, findViewElement should throw an exception`` () =
        (fun() ->
            View.ContentPage(content=
                View.Label(automationId="LabelId")
            )
            |> findViewElement "LabelTest"
            |> ignore)
        |> should throw typeof<System.Exception>
        
    [<Test>]
    let ``Given a complex layout, we should not get errors when there are no keyed controls`` () =
        
        let previous =
            [|
                View.Label(text = "Label 1")
                View.Label(text = "Label 2")
            |]

        let current = 
            [|
                View.Label(text = "Label 1")
                View.Label(text = "Label 2")
            |]

        let mutable mockUpdateCallCount = 0
        let mockUpdate _ _  _ =
            mockUpdateCallCount <- mockUpdateCallCount + 1

        let mockAttach  _ _ _ =()
        let mockCanReuse _ _ = false
        let mockGetKey = ViewHelpers.getKey
        let mutable createCount = 0
        let mockCreate _ =  
            createCount <- createCount + 1
           
        let initial = System.Collections.Generic.List<unit>() :> IList<unit>
       
        do updateCollectionGeneric (ValueSome previous) (ValueSome current)  initial mockCreate mockAttach mockCanReuse mockGetKey mockUpdate 

        mockUpdateCallCount |> should equal 0
        createCount |> should equal 2
        
    [<Test>]
    let ``Given a complex layout with keyed controls , we should create only not keyed controls`` () =
        
        let previous =
            [|
                View.Label(key="Key_1",text = "Label 1")
                View.Label(text = "Label 2")
            |]

        let current = 
            [|
                View.Entry(text = "Entry 3")
                View.Label(key="Key_1",text = "Label 1")
                View.Label(text = "Label 2")
            |]

        let mutable mockUpdateCallCount = 0
        let mockUpdate _ _  _ =
            mockUpdateCallCount <- mockUpdateCallCount + 1

        let mockAttach  _ _ _ =()
        let mockCanReuse _ _ = false
        let mockGetKey = ViewHelpers.getKey
        let initial = System.Collections.Generic.List<unit>() :> IList<unit>
        initial.Add ()
        initial.Add ()
        let mutable createCount = 0
        let mockCreate _ =
            initial.Add (())
            createCount <- createCount + 1
           
        
       
        do updateCollectionGeneric (ValueSome previous) (ValueSome current)  initial mockCreate mockAttach mockCanReuse mockGetKey mockUpdate 

        createCount |> should equal 2
        
        
    [<Test>]
    let ``Adding new control at the end of list invokes create`` () =
        
        let previous =
            [|
                View.Label(text = "Label 1")
                View.Entry(text = "Label 2")
            |]

        let current = 
            [|
                
                View.Label(text = "Label 1")
                View.Entry(text = "Label 2")
                View.Grid()
            |]

        let mutable mockUpdateCallCount = 0
        let mockUpdate _ _  _ =
            mockUpdateCallCount <- mockUpdateCallCount + 1

        let mockAttach  _ _ _ =()
        let mockCanReuse _ _ = false
        let mockGetKey = ViewHelpers.getKey
        let initial = System.Collections.Generic.List<unit>() :> IList<unit>
        initial.Add ()
        initial.Add ()
        let mutable createCount = 0
        let mockCreate _ =
            initial.Add (())
            createCount <- createCount + 1
           
        
       
        do updateCollectionGeneric (ValueSome previous) (ValueSome current)  initial mockCreate mockAttach mockCanReuse mockGetKey mockUpdate 

        createCount |> should equal 3
        
        
    [<Test>]
    let ``Removing  control from the start breaks all`` () =
        
        let previous =
            [|
                View.Grid() 
                View.Label(text = "Label 1")
                View.Label(text = "Label 2")
            |]

        let current = 
            [|
                View.Label(text = "Label 1")
                View.Label(text = "Label 2")
               
            |]

        let mutable mockUpdateCallCount = 0
        let mockUpdate _ _  _ =
            mockUpdateCallCount <- mockUpdateCallCount + 1

        let mockAttach  _ _ _ =()
        let mockCanReuse _ _ = false
        let mockGetKey = ViewHelpers.getKey
        let initial = System.Collections.Generic.List<ViewElement>() :> IList<ViewElement>
        for v in previous do 
          initial.Add v
        let mutable createCount = 0
        let mockCreate v =
            
            createCount <- createCount + 1
            v
                
        do updateCollectionGeneric (ValueSome previous) (ValueSome current)  initial mockCreate mockAttach mockCanReuse mockGetKey mockUpdate 

        createCount|>should equal 2 

    [<Test>]
    let ``Removing  control from the end looks ok `` () =
        
        let previous =
            [|
               
                View.Label(text = "Label 1")
                View.Entry(text = "Label 2")
                View.Grid() 
            |]

        let current = 
            [|
                View.Label(text = "Label 1")
                View.Entry(text = "Label 2")
                
               
            |]

        let mutable mockUpdateCallCount = 0
        let mockUpdate _ _  _ =
            mockUpdateCallCount <- mockUpdateCallCount + 1

        let mockAttach  _ _ _ =()
        let mockCanReuse _ _ = false
        let mockGetKey = ViewHelpers.getKey
        let initial = System.Collections.Generic.List<ViewElement>() :> IList<ViewElement>
        let mutable createCount = 0
        let mockCreate v =
            createCount <- createCount + 1
            v
           
        
       
        do updateCollectionGeneric (ValueSome previous) (ValueSome current)  initial mockCreate mockAttach mockCanReuse mockGetKey mockUpdate 

        createCount|>should equal 2
        
    [<Test>]
    let ``Moving control with key to the end should be ok `` () =
        
        let previous =
            [|
               
                View.Grid(key ="Key") 
                View.Label(text = "Label 1")
                View.Entry(text = "Label 2")
            |]

        let current = 
            [|
                View.Label(text = "Label 1")
                View.Entry(text = "Label 2")
                View.Grid(key = "Key") 
               
            |]

        let mutable mockUpdateCallCount = 0
        let mockUpdate _ _  _ =
            mockUpdateCallCount <- mockUpdateCallCount + 1

        let mockAttach  _ _ _ =()
        let mockCanReuse _ _ = false
        let mockGetKey = ViewHelpers.getKey
        let initial = System.Collections.Generic.List<ViewElement>() :> IList<ViewElement>
        for v in previous do
            initial.Add v
        let mutable createCount = 0
        let mockCreate v =
            createCount <- createCount + 1
            v
            
        do updateCollectionGeneric (ValueSome previous) (ValueSome current)  initial mockCreate mockAttach mockCanReuse mockGetKey mockUpdate 

        createCount|>should equal 2
    
        
        
        
