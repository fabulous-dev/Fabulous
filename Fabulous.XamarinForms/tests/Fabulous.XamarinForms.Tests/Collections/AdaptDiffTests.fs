namespace Fabulous.XamarinForms.Tests.Collections

//open Fabulous
//open Fabulous.XamarinForms
//open Fabulous.XamarinForms.Collections
//open NUnit.Framework
//open FsUnit

//module AdaptDiffTests =
//    [<Test>]
//    let ``Test Reduce``() =
//        let previous =
//            [ View.Button(key = "Button0_0")
//              View.Button(key = "Button0_1")
//              View.Button(key = "Button0_2")
//              View.Button(key = "Button1_0")
//              View.Button(key = "Button1_1")
//              View.Button(key = "Button1_2")
//              View.Button(key = "Button2_0")
//              View.Button(key = "Button2_1")
//              View.Button(key = "Button2_2") ]
            
//        let current =
//            [ View.Button(key = "Button0_0")
//              View.Button(key = "Button0_1")
//              View.Button(key = "Button0_2")
//              View.Button(key = "Button1_0")
//              View.Image(key = "Image1_1")
//              View.Button(key = "Button1_2")
//              View.Button(key = "Button2_0")
//              View.Button(key = "Button2_1")
//              View.Button(key = "Button2_2") ]
            
//        let diffResult = DiffResult<ViewElement>.Operations [
//            Update (0, previous.[0], current.[0])
//            Update (1, previous.[1], current.[1])
//            Update (2, previous.[2], current.[2])
//            Update (3, previous.[3], current.[3])
//            Insert (4, current.[4])
//            Update (5, previous.[5], current.[5])
//            Update (6, previous.[6], current.[6])
//            Update (7, previous.[7], current.[7])
//            Update (8, previous.[8], current.[8])
//            Delete 4
//        ]
        
//        Collections.adaptDiffForObservableCollection previous.Length diffResult
//        |> should equal (DiffResult<ViewElement>.Operations [
//            Update (0, previous.[0], current.[0])
//            Update (1, previous.[1], current.[1])
//            Update (2, previous.[2], current.[2])
//            Update (3, previous.[3], current.[3])
//            Insert (4, current.[4])
//            MoveAndUpdate (6, previous.[5], 5, current.[5])
//            MoveAndUpdate (7, previous.[6], 6,current.[6])
//            MoveAndUpdate (8, previous.[7], 7, current.[7])
//            MoveAndUpdate (9, previous.[8], 8, current.[8])
//            Delete 9
//        ])
            
//    [<Test>]
//    let ``Test Reduce 2``() =
//        let previous =
//            [ View.Button(key = "Button0_0")
//              View.Button(key = "Button0_1")
//              View.Button(key = "Button0_2")
//              View.Button(key = "Button1_0")
//              View.Image(key = "Image1_1") ]
            
//        let current =
//            [ View.Label(key = "Button0_0")
//              View.Button(key = "Button0_1")
//              View.Image(key = "Button0_2") ]
        
//        let diffResult = DiffResult<ViewElement>.Operations [
//            Insert (0, current.[0])
//            Update (1, previous.[1], current.[1])
//            MoveAndUpdate (4, previous.[4], 2, current.[2])
//            Delete 0
//            Delete 2
//            Delete 3
//        ]
        
//        Collections.adaptDiffForObservableCollection previous.Length diffResult
//        |> should equal (DiffResult<ViewElement>.Operations [
//            Insert (0, current.[0])
//            MoveAndUpdate (2, previous.[1], 1, current.[1])
//            MoveAndUpdate (5, previous.[4], 2, current.[2])
//            Delete 3
//            Delete 3
//            Delete 3
//        ])
            
//    [<Test>]
//    let ``Test Reduce 3``() =
//        let previous =
//            [ View.Label(key = "0")
//              View.Label()
//              View.Button()
//              View.Button(key = "2")
//              View.Label()
//              View.Label(key = "3")
//              View.Label()
//              View.Button()
//              View.Button()
//              View.Button()
//              View.Button() ]
            
//        let current =
//            [ View.Button(key = "0")
//              View.Label() ]
        
//        let diffResult = DiffResult<ViewElement>.Operations [
//            MoveAndUpdate (2, previous.[2], 0, current.[0])
//            MoveAndUpdate (0, previous.[0], 1, current.[1])
//            Delete 1
//            Delete 3
//            Delete 4
//            Delete 5
//            Delete 6
//            Delete 7
//            Delete 8
//            Delete 9
//            Delete 10
//        ]
        
//        Collections.adaptDiffForObservableCollection previous.Length diffResult
//        |> should equal (DiffResult<ViewElement>.Operations [
//            MoveAndUpdate (2, previous.[2], 0, current.[0])
//            Update (1, previous.[0], current.[1])
//            Delete 2
//            Delete 2
//            Delete 2
//            Delete 2
//            Delete 2
//            Delete 2
//            Delete 2
//            Delete 2
//            Delete 2
//        ])
        
        
        
