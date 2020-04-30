namespace Fabulous.XamarinForms.Tests.ViewUpdaters

open Fabulous
open System.Collections.Generic
open Fabulous.XamarinForms
open NUnit.Framework
open FsUnit

// 1 & 1' means its the same ViewElement (same property values), except it's not the same .NET reference
// Tx & Ty means its 2 different ViewElement types that can't be reused between themselves (e.g. Label vs Button)
// 1k/Txk means its a ViewElement with a key value 
module UpdateCollectionGenericTests =    
    type Operation =
        | Move of prevIndex: int * child: ViewElement
        | Create of newChild: ViewElement
        | Update of prevIndex: int * prevChild: ViewElement * newChild: ViewElement
        | Remove of prevChild: ViewElement
        | Clear
    
    /// Call updateCollectionGenericInternal and accumulate all requested operations based on their index of effect
    let private testUpdateCollectionGeneric (previousCollection: ViewElement list voption) (newCollection: ViewElement list voption) =
        let operations = List<int * Operation>()
        
        let mockMove i child =
            let prevIndex = previousCollection.Value |> List.findIndex (fun c -> c = child)
            if(i<>prevIndex) then 
             operations.Add(i, Move (prevIndex, child))
        
        let mockCreate i viewElement =
            operations.Add(i, Create viewElement);
            
        let mockUpdate i previousChild newChild =
            let prevIndex = previousCollection.Value |> List.findIndex (fun c -> c = previousChild)
            operations.Add(i, Update (prevIndex, previousChild, newChild))
            
        let mockRemove i unused=
            let mutable offset = 0
            for el in unused do
             operations.Add(i + offset, Remove el)
             offset<-offset+1
            
        let mockClear () =
            operations.Add(0, Clear)
       
        do updateCollectionGenericInternal
               (previousCollection |> ValueOption.map List.toArray)
               (newCollection |> ValueOption.map List.toArray)
               ViewHelpers.getKey
               ViewHelpers.canReuseView
               mockMove
               mockCreate
               mockUpdate
               mockRemove
               mockClear

        operations
        |> Seq.sortBy fst
        |> Seq.map snd
        |> Seq.toArray
    
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
            [| Create (current.[0]) |]
    
    /// Keeping the exact same state (same instance) should do nothing
    [<Test>]
    let ``Given previous state = 1 / current state = 1 (same reference), updateCollectionGeneric should do nothing``() =
        // To keep the reference the same between 2 states, we use dependsOn
        let label = dependsOn () (fun _ _ -> View.Label())
        let previous = [ label ]
        let current = [ label ]
        
        let res= testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        res
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
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal
            [| Update (0, previous.[0], current.[0])
               Remove previous.[1]
               Remove previous.[2] |]
    
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
              Create current.[1] ]
    
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
               Create current.[2] |]
    
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
               Remove previous.[3] |]
    
    /// Replacing an element with an element of another type should create the new control in place of the old one
    [<Test>]
    let ``Given previous state = Tx / current state = Ty, updateCollectionGeneric should replace Tx with Create[Ty]``() =        
        let previous =
            [ View.Label() ]
        let current =
            [ View.Button() ]
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal
            [| Create current.[0] |]

    // Only keyed
    // Empty -> 1k = Create[1k]
    // 1k -> Empty = Remove[1k]
    // 1k -> 1k = Nothing
    // 1k -> 1k' = Update[1k -> 1k']
    // 1k -> 2k = Update[1k -> 2k]
    // 1k-2k-3k -> 1k'-3k' = Update[1k -> 1k' | 3k -> 3k'] + Remove[2k]
    // 1k-2k-3k -> 3k'-1k' = Update[3k -> 3k' | 1k -> 1k'] + Remove[2k]
    // 1k-2k-3k -> 3k'-4k-1k' = Update[3k -> 3k' | 2k -> 4k | 1k -> 1k']
    // 1k-2k-3k-4k -> 2k'-1k-4k'-3k' = Update[2k -> 2k' | 4k -> 4k' | 3k -> 3k'] --- 1k is the same instance
    // Txk -> Tyk (same key) = Create[Tyk]
    // Txk -> Tyk (different key) = Create[Tyk]
        
    /// Adding a keyed element to an empty list should create the associated control
    [<Test>]
    let ``Given previous state = Empty / current state = 1k, updateCollectionGeneric should Create[1k]``() =
        let previous = []
        let current = [ View.Label(key = "KeyA") ]
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal
            [| Create current.[0] |]
        
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
               Remove previous.[1] |]
        
    /// Reordering keyed elements should reuse the correct controls
    [<Test>]
    let ``Given previous state = 1k-2k-3k / current state = 3k'-1k', updateCollectionGeneric should Update[3k -> 3k' | 1k -> 1k'] + Remove[2k]``() =
        let previous =
            [ View.Label(key = "KeyA")
              View.Label(key = "KeyB")
              View.Label(key = "KeyC") ]
        let current =
            [ 
              View.Label(key = "KeyC")
              View.Label(key = "KeyA")
            ]
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal
            [| Update (2, previous.[2], current.[0])
               Update (0, previous.[0], current.[1])
               Remove previous.[1] |]
       
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
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal
            [| Update (2, previous.[2], current.[0])
               Update (1, previous.[1], current.[1])
               Update (0, previous.[0], current.[2]) |]
            
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
               Move (0, current.[1])
               Update (3, previous.[3], current.[2])
               Update (2, previous.[2], current.[3]) |]
    
    /// Replacing an element with one from another type, even with the same key, should create the new control
    /// in place of the old one
    [<Test>]
    let ``Given previous state = Txk / current state = Tyk (same key), updateCollectionGeneric should replace Txk with Create[Tyk]``() =        
        let previous =
            [ View.Label(key = "KeyA") ]
        let current =
            [ View.Button(key = "KeyA") ]
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal
            [| Create current.[0] |]
    
    /// Replacing a keyed element with one of another type and another key, should create the new control
    /// in place of the old one
    [<Test>]
    let ``Given previous state = Txk / current state = Tyk (different keys), updateCollectionGeneric should replace Txk with Create[Tyk]``() =        
        let previous =
            [ View.Label(key = "KeyA") ]
        let current =
            [ View.Button(key = "KeyB") ]
        
        testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        |> should equal
            [| Create current.[0] |]
    
    // Mixed
    // 1k -> 2 = Update[1k -> 2]
    // 1k-2 -> 1k'-3 = Update[1k -> 1k' | 2 -> 3]
    // 1-2k -> 2k' = Remove[1] + Update[2k -> 2k']
    // 1-2k-3-4-5 -> 4-2k'-5' = Update[2k -> 2k' | 1 -> 5'] + Remove[3 | 5] --- 4 is the same instance so it can be reused like a keyed element
    
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
        
        let res= testUpdateCollectionGeneric (ValueSome previous) (ValueSome current)
        res|> should equal
            [| Update (1, previous.[1], current.[0])
               Remove previous.[0] |]
    
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
            [| Move (3, current.[0])
               Update (0, previous.[0], current.[1])
               Update (1, previous.[1], current.[2])
               Remove previous.[2]
               Remove previous.[4] |]