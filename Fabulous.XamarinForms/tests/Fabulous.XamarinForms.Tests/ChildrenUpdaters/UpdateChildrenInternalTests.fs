namespace Fabulous.XamarinForms.Tests.ChildrenUpdaters

open Fabulous
open System.Collections.Generic
open Fabulous.XamarinForms
open NUnit.Framework
open FsUnit

// 1 & 1' means its the same ViewElement (same property values), except it's not the same .NET reference
// Tx & Ty means its 2 different ViewElement types that can't be reused between themselves (e.g. Label vs Button)
// 1k/Txk means its a ViewElement with a key value 
module UpdateChildrenInternalTests =    
    type Operation =
        | Clear
        | Create of index: int * newChild: ViewElement
        | Update of index: int * prevChild: ViewElement * newChild: ViewElement
        | Move of prevIndex: int * newIndex: int
        | Remove of index: int
    
    /// Call updateCollectionGenericInternal and accumulate all requested operations based on their index of effect
    let private testUpdateCollectionGeneric (previousCollection: ViewElement list voption) (newCollection: ViewElement list voption) =
        let operations = List<Operation>()
        
        let mockClear () =
            operations.Add(Clear)
        
        let mockCreate index child =
            operations.Add(Create (index, child))
            
        let mockUpdate index previousChild newChild =
            operations.Add(Update (index, previousChild, newChild))
            
        let mockMove prevIndex newIndex =
            operations.Add(Move (prevIndex, newIndex))
            
        let mockRemove index =
            operations.Add(Remove index)
       
        do ChildrenUpdaters.updateChildrenInternal
               (previousCollection |> ValueOption.map List.toArray)
               (newCollection |> ValueOption.map List.toArray)
               ViewHelpers.tryGetKey
               ViewHelpers.canReuseView
               mockClear
               mockCreate
               mockUpdate
               mockMove
               mockRemove

        operations
        |> Seq.toArray
    
    /// Going from an undefined state to another undefined state should do nothing
    [<Test>]
    let ``Given previous state = None / current state = None, updateCollectionGeneric should do nothing``() =        
        testUpdateCollectionGeneric ValueNone ValueNone
        |> should equal [| |]
    
    /// Not defining a previously existing list clears all previous controls
    [<Test>]
    let ``Given previous state = 1-2-3 / current state = None, updateCollectionGeneric should Clear``() =
        let previous =
            [ View.Label()
              View.Label()
              View.Label() ]
        
        testUpdateCollectionGeneric (ValueSome previous) ValueNone
        |> should equal [| Clear |]
    
    /// A non-changing empty list should do nothing
    [<Test>]
    let ``Given previous state = Empty / current state = Empty, updateCollectionGeneric should do nothing``() =
        let previous = []
        let current = []
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal [||]
    
    /// Adding a new element to an empty list should create the associated control
    [<Test>]
    let ``Given previous state = Empty / current state = 1, updateCollectionGeneric should Create[1]``() =
        let previous = []
        let current = [ View.Label() ]
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal
            [| Create (0, current.[0]) |]
    
    /// Keeping the exact same state (same instance) should do nothing
    [<Test>]
    let ``Given previous state = 1 / current state = 1 (same reference), updateCollectionGeneric should do nothing``() =
        // To keep the reference the same between 2 states, we use dependsOn
        let label = dependsOn () (fun _ _ -> View.Label())
        let previous = [ label ]
        let current = [ label ]
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal [||]
    
    /// Keeping the same state (not same instance) should update the existing control nonetheless
    [<Test>]
    let ``Given previous state = 1 / current state = 1', updateCollectionGeneric should Update[1 -> 1']``() =
        let previous = [ View.Label() ]
        let current = [ View.Label() ]
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal
            [| Update (0, previous.[0], current.[0]) |]
    
    /// Replacing an element by another one (same control type) should update the existing control
    [<Test>]
    let ``Given previous state = 1 / current state = 2, updateCollectionGeneric should Update[1 -> 2]``() =
        let previous = [ View.Label(text = "A") ]
        let current = [ View.Label(text = "B") ]
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal
            [| Update (0, previous.[0], current.[0]) |]
    
    /// Emptying a list should clear all controls
    [<Test>]
    let ``Given previous state = 1-2-3 / current state = Empty, updateCollectionGeneric should Clear``() =
        let previous =
            [ View.Label()
              View.Label()
              View.Label() ]
        let current =
            []
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal [| Clear |]
    
    /// Keeping elements at the start (not same instance) and removing elements at the end should update the remaining
    /// controls and remove the others
    [<Test>]
    let ``Given previous state = 1-2-3 / current state = 1', updateCollectionGeneric should Update[1 -> 1'] + Remove[2 | 3]``() =
        let previous =
            [ View.Label(text = "A")
              View.Label(text = "B")
              View.Label(text = "C") ]
        let current =
            [ View.Label(text = "A") ]
        
        let res = testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        res|> should equal
            [| Update (0, previous.[0], current.[0])
               Remove 1
               Remove 1 |]
    
    /// Keeping elements at the start (not same instance) and adding elements at the end should update the existing
    /// controls and add the others at the end
    [<Test>]
    let ``Given previous state = 1 / current state = 1'-2, updateCollectionGeneric should Update[1 -> 1'] + Create[2]``() =
        let previous =
            [ View.Label(text = "A") ]
        let current =
            [ View.Label(text = "A")
              View.Label(text = "B") ]
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal
            [ Update (0, previous.[0], current.[0])
              Create (1, current.[1]) ]
    
    /// Adding a new element at the start and keeping the existing elements after (not same instances) should reuse
    /// the existing controls based on their position and create the missing ones
    [<Test>]
    let ``Given previous state = 1-2 / current state = 3-1'-2', updateCollectionGeneric should Update[1 -> 3 | 2 -> 1'] + Create[2']``() =        
        let previous =
            [ View.Label(text = "A")
              View.Label(text = "B") ]
        let current =
            [ View.Label(text = "C")
              View.Label(text = "A")
              View.Label(text = "B") ]
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal
            [| Update (0, previous.[0], current.[0])
               Update (1, previous.[1], current.[1])
               Create (2, current.[2]) |]
    
    /// Removing elements in the middle of others (not the same instances) should reuse the existing controls based
    /// on their position and remove the superfluous ones 
    [<Test>]
    let ``Given previous state = 1-2-3-4 / current state = 1'-3'-4', updateCollectionGeneric should Update[1 -> 1' | 2 -> 3' | 3 -> 4'] + Remove[4]``() =        
        let previous =
            [ View.Label(text = "A")
              View.Label(text = "B")
              View.Label(text = "C")
              View.Label(text = "D") ]
        let current =
            [ View.Label(text = "A")
              View.Label(text = "C")
              View.Label(text = "D") ]
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal
            [| Update (0, previous.[0], current.[0])
               Update (1, previous.[1], current.[1])
               Update (2, previous.[2], current.[2])
               Remove 3 |]
    
    /// Replacing an element with an element of another type should create the new control in place of the old one
    [<Test>]
    let ``Given previous state = Tx / current state = Ty, updateCollectionGeneric should Create[Ty] + Remove[Tx]``() =        
        let previous =
            [ View.Label() ]
        let current =
            [ View.Button() ]
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal
            [| Create (0, current.[0])
               Remove 1 |]
        
    /// Adding a keyed element to an empty list should create the associated control
    [<Test>]
    let ``Given previous state = Empty / current state = 1k, updateCollectionGeneric should Create[1k]``() =
        let previous = []
        let current = [ View.Label(key = "KeyA") ]
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal
            [| Create (0, current.[0]) |]
        
    /// Emptying a list containing keyed elements should clear the list
    [<Test>]
    let ``Given previous state = 1k-2k-3k / current state = Empty, updateCollectionGeneric should Clear``() =
        let previous =
            [ View.Label(key = "KeyA")
              View.Label(key = "KeyB")
              View.Label(key = "KeyC") ]
        let current =
            []
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal [| Clear |]
        
    /// Keeping the exact same state (keyed + same instance) should do nothing
    [<Test>]
    let ``Given previous state = 1k / current state = 1k (same reference), updateCollectionGeneric should do nothing``() =
        let label = dependsOn () (fun _ _ -> View.Label(key = "KeyA"))
        let previous = [ label ]
        let current = [ label ]
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal [||]
        
    /// Keeping the same state (keyed + not same instance) should update the existing control nonetheless
    [<Test>]
    let ``Given previous state = 1k / current state = 1k', updateCollectionGeneric should Update[1k -> 1k']``() =
        let previous = [ View.Label(key = "KeyA") ]
        let current = [ View.Label(key = "KeyA") ]
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal
            [| Update (0, previous.[0], current.[0]) |]
            
    /// Replacing a keyed element by another one (not same key + same control type) should update the existing control
    [<Test>]
    let ``Given previous state = 1k / current state = 2k, updateCollectionGeneric should Update[1k -> 2k]``() =
        let previous = [ View.Label(key = "KeyA") ]
        let current = [ View.Label(key = "KeyB") ]
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal
            [| Update (0, previous.[0], current.[0]) |]
        
    /// Removing elements in the middle of others (not the same instances) should reuse the existing controls based
    /// on their keys and remove the superfluous ones 
    [<Test>]
    let ``Given previous state = 1k-2k-3k / current state = 1k'-3k', updateCollectionGeneric should Update[1k -> 1k' | 3k -> 3k'] + Remove[2k]``() =
        let previous =
            [ View.Label(key = "KeyA")
              View.Label(key = "KeyB")
              View.Label(key = "KeyC") ]
        let current =
            [ View.Label(key = "KeyA")
              View.Label(key = "KeyC") ]
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal
            [| Update (0, previous.[0], current.[0])
               Update (2, previous.[2], current.[1])
               Move (2, 1)
               Remove 2 |]
        
    /// Reordering keyed elements should reuse the correct controls
    [<Test>]
    let ``Given previous state = 1k-2k-3k / current state = 3k'-1k', updateCollectionGeneric should Update[3k -> 3k' | 1k -> 1k'] + Remove[2k]``() =
        let previous =
            [ View.Label(key = "KeyA")
              View.Label(key = "KeyB")
              View.Label(key = "KeyC") ]
        let current =
            [ View.Label(key = "KeyC")
              View.Label(key = "KeyA") ]
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal
            [| Update (2, previous.[2], current.[0])
               Move (2, 0)
               Update (1, previous.[0], current.[1])
               Remove 2 |]
       
    /// New keyed elements should reuse discarded elements even though the keys are not matching,
    /// independently of their position 
    [<Test>]
    let ``Given previous state = 1k-2k-3k / current state = 3k'-4k-1k', updateCollectionGeneric should Update[3k -> 3k' | 2k -> 4k | 1k -> 1k']``() =
        let previous =
            [ View.Label(key = "KeyA")
              View.Label(key = "KeyB")
              View.Label(key = "KeyC") ]
        let current =
            [ View.Label(key = "KeyC")
              View.Label(key = "KeyD")
              View.Label(key = "KeyA") ]
        
        let res = testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        res |> should equal
            [| Update (2, previous.[2], current.[0])
               Move (2, 0)
               Update (2, previous.[1], current.[1])
               Move (2, 1)
               Update (2, previous.[0], current.[2]) |]
            
    /// Complex use cases with reordering and remove/add of keyed elements should reuse controls efficiently
    [<Test>]
    let ``Given previous state = 1k-2k-3k-4k / current state = 2k'-1k-4k'-3k', updateCollectionGeneric should Update[2k -> 2k'] + Move[1k] + Update[ 4k -> 4k' | 3k -> 3k']``() =
        let labelA = dependsOn () (fun _ _ -> View.Label(key = "KeyA"))
        let previous =
            [ labelA
              View.Label(key = "KeyB")
              View.Label(key = "KeyC")
              View.Label(key = "KeyD") ]
        let current =
            [ View.Label(key = "KeyB")
              labelA
              View.Label(key = "KeyD")
              View.Label(key = "KeyC") ]
        
        let res= testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        res |> should equal
            [| Update (1, previous.[1], current.[0])
               Move (1, 0)                                     
               Update (3, previous.[3], current.[2])
               Move (3, 2)
               Update (3, previous.[2], current.[3]) |]
    
    /// Replacing an element with one from another type, even with the same key, should create the new control
    /// in place of the old one
    [<Test>]
    let ``Given previous state = Txk / current state = Tyk (same key), updateCollectionGeneric should Create[Tyk] + Remove[Txk]``() =        
        let previous =
            [ View.Label(key = "KeyA") ]
        let current =
            [ View.Button(key = "KeyA") ]
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal
            [| Create (0, current.[0])
               Remove 1 |]
    
    /// Replacing a keyed element with one of another type and another key, should create the new control
    /// in place of the old one
    [<Test>]
    let ``Given previous state = Txk / current state = Tyk (different keys), updateCollectionGeneric should Create[Tyk] + Remove[Txk]``() =        
        let previous =
            [ View.Label(key = "KeyA") ]
        let current =
            [ View.Button(key = "KeyB") ]
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal
            [| Create (0, current.[0])
               Remove 1 |]
    
    /// Replacing a keyed element with a non-keyed one should reuse the discarded element
    [<Test>]
    let ``Given previous state = 1k / current state = 2, updateCollectionGeneric should Update[1k -> 2]``() =        
        let previous =
            [ View.Label(key = "KeyA") ]
        let current =
            [ View.Label() ]
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal
            [| Update (0, previous.[0], current.[0]) |]
    
    /// Replacing a non-keyed element with another when a keyed element is present should reuse the discarded element
    [<Test>]
    let ``Given previous state = 1k-2 / current state = 1k'-3, updateCollectionGeneric should Update[1k -> 1k' | 2 -> 3]``() =        
        let previous =
            [ View.Label(key = "KeyA")
              View.Label(text = "B") ]
        let current =
            [ View.Label(key = "KeyA")
              View.Label(text = "C") ]
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal
            [| Update (0, previous.[0], current.[0])
               Update (1, previous.[1], current.[1]) |]
    
    /// Removing an element at the start of a list with keyed elements present should reuse the correct controls
    [<Test>]
    let ``Given previous state = 1-2k / current state = 2k', updateCollectionGeneric should Update[2k -> 2k'] + Remove[1]``() =        
        let previous =
            [ View.Label(text = "A")
              View.Label(key = "KeyB") ]
        let current =
            [ View.Label(key = "KeyB") ]
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal
            [| Update (1, previous.[1], current.[0])
               Move (1, 0)                                         
               Remove 1 |]
    
    /// Complex use cases with reordering and remove/add of mixed elements should reuse controls efficiently
    [<Test>]
    let ``Given previous state = 1-2k-3-4-5 / current state = 4-5'-2k' (4 is same ref), updateCollectionGeneric should Move[4] + Update[2k -> 2k' | 1 -> 5'] + Remove[3 | 5]``() =
        let labelD = dependsOn () (fun _ _ -> View.Label("D"))
        let previous =
            [ View.Label(text = "A")
              View.Label(key = "KeyB")
              View.Label(text = "C")
              labelD
              View.Label(text = "E") ]
        let current =
            [ labelD
              View.Label(text = "E")
              View.Label(key = "KeyB") ]
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal
            [| Move (3, 0)
               Update (1, previous.[0], current.[1])
               Update (2, previous.[1], current.[2])
               Remove 3
               Remove 3 |]
            
    open Xamarin.Forms
           
    [<Test>]
    let ``Test CounterApp``() =
        let previous =
            [
              View.Label(automationId="CountLabel", text="0", horizontalOptions=LayoutOptions.Center, width=200.0, horizontalTextAlignment=TextAlignment.Center)
              View.Button(automationId="IncrementButton", text="Increment", command= (fun () -> ()))
              View.Button(automationId="DecrementButton", text="Decrement", command= (fun () -> ())) 
              View.StackLayout(padding = Thickness 20.0, orientation=StackOrientation.Horizontal, horizontalOptions=LayoutOptions.Center, children = [ ])
              View.Slider(automationId="StepSlider", minimumMaximum=(0.0, 10.0), value=1., valueChanged=(fun args -> ()))
              View.Label(automationId="StepSizeLabel", text="Step size: 1", horizontalOptions=LayoutOptions.Center)
              View.Button(text="Reset", horizontalOptions=LayoutOptions.Center, command=(fun () -> ()), commandCanExecute = false)
            ]
        let current =
            [
              View.Label(automationId="CountLabel", text="1", horizontalOptions=LayoutOptions.Center, width=200.0, horizontalTextAlignment=TextAlignment.Center)
              View.Button(automationId="IncrementButton", text="Increment", command= (fun () -> ()))
              View.Button(automationId="DecrementButton", text="Decrement", command= (fun () -> ())) 
              View.StackLayout(padding = Thickness 20.0, orientation=StackOrientation.Horizontal, horizontalOptions=LayoutOptions.Center, children = [ ])
              View.Slider(automationId="StepSlider", minimumMaximum=(0.0, 10.0), value=1., valueChanged=(fun args -> ()))
              View.Label(automationId="StepSizeLabel", text="Step size: 1", horizontalOptions=LayoutOptions.Center)
              View.Button(text="Reset", horizontalOptions=LayoutOptions.Center, command=(fun () -> ()), commandCanExecute = true)
            ]
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal
            [| Update (0, previous.[0], current.[0])
               Update (1, previous.[1], current.[1])
               Update (2, previous.[2], current.[2])
               Update (3, previous.[3], current.[3])
               Update (4, previous.[4], current.[4])
               Update (5, previous.[5], current.[5])
               Update (6, previous.[6], current.[6]) |]
            
    [<Test>]
    let ``Test TicTacToe``() =
        let previous =
            [ View.BoxView(Color.Black).Row(1).ColumnSpan(5)
              View.BoxView(Color.Black).Row(3).ColumnSpan(5)
              View.BoxView(Color.Black).Column(1).RowSpan(5)
              View.BoxView(Color.Black).Column(3).RowSpan(5)
              View.Button(
                command=(fun () -> ()),
                backgroundColor=Color.LightBlue
              ).Row(0).Column(0)
              View.Button(
                command=(fun () -> ()),
                backgroundColor=Color.LightBlue
              ).Row(0).Column(1) ]
            
        let current =
            [ View.BoxView(Color.Black).Row(1).ColumnSpan(5)
              View.BoxView(Color.Black).Row(3).ColumnSpan(5)
              View.BoxView(Color.Black).Column(1).RowSpan(5)
              View.BoxView(Color.Black).Column(3).RowSpan(5)
              View.Image(
                source=ImagePath "X",
                margin=Thickness(10.0), horizontalOptions=LayoutOptions.Center,
                verticalOptions=LayoutOptions.Center
              ).Row(0).Column(0)
              View.Button(
                command=(fun () -> ()),
                backgroundColor=Color.LightBlue
              ).Row(0).Column(1) ]
        
        let res = testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        res
        |> should equal
            [| Update (0, previous.[0], current.[0])
               Update (1, previous.[1], current.[1])
               Update (2, previous.[2], current.[2])
               Update (3, previous.[3], current.[3])
               Create (4, current.[4])
               Update (5, previous.[4], current.[5])
               Remove 6 |]