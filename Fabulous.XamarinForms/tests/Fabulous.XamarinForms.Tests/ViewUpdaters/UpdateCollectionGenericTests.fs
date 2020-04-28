namespace Fabulous.XamarinForms.Tests.ViewUpdaters

open Fabulous
open System.Collections.Generic
open Fabulous.XamarinForms
open NUnit.Framework
open FsUnit

module UpdateCollectionGenericTests =
    type Result =
        { CreateCount: int
          UpdateCount: int
          AttachCount: int
          TargetCollectionCount: int }
    
    let internal testUpdateCollectionGeneric previousCollection newCollection =
        let mutable createCount = 0
        let mutable updateCount = 0
        let mutable attachCount = 0
        
        let mockCreate viewElement = createCount <- createCount + 1; viewElement.ToString() :> obj
        let mockUpdate _ _  _ = updateCount <- updateCount + 1
        let mockAttach  _ _ _ = attachCount <- attachCount + 1
        let mockCanReuse = ViewHelpers.canReuseView
           
        let targetCollection = System.Collections.Generic.List<obj>() :> IList<obj>
        for prevElement in previousCollection do
            targetCollection.Add(prevElement.ToString() :> obj)
       
        do updateCollectionGeneric
               (ValueSome (Array.ofList previousCollection))
               (ValueSome (Array.ofList newCollection))
               targetCollection
               mockCreate
               mockAttach
               mockCanReuse
               mockUpdate 

        { CreateCount = createCount
          UpdateCount = updateCount
          AttachCount = attachCount
          TargetCollectionCount = targetCollection.Count }
        
    // Use cases without key.
    // 1 & 1" means its the same ViewElement (same property values), except it's not the same .NET reference
    // L1 & B1 means its 2 different ViewElement types that can't be reused between themselves (e.g. Label vs Button)    
    
    // Empty -> Empty = Nothing
    // Empty -> 1 = Create (1)
    // 1 -> 1 = Nothing
    // 1 -> 1" = Update (1 -> 1")
    // 1 -> 2 = Update (1 -> 2)
    // 1 -> Empty = Remove (1)
    // 1 -> 1"-2 = Update (1 -> 1") + Create (2)
    // 1-2 -> 3-1"-2" = Update (1 -> 3) + Create (1" | 2")
    // 1-2-3-4 -> 1"-3"-4" = Update (1 -> 1" | 2 -> 3" | 3 -> 4") + Remove (4)
    // L1 -> B1 = Replace (L1 -> B1)
    
    [<Test>]
    let ``Given previous state = Empty / current state = Empty, updateCollectionGeneric should do nothing``() =
        let previous = []
        let current = []
        
        testUpdateCollectionGeneric previous current
        |> should equal
            { CreateCount = 0
              UpdateCount = 0
              AttachCount = 0
              TargetCollectionCount = 0 }
    
    [<Test>]
    let ``Given previous state = Empty / current state = 1, updateCollectionGeneric should Create[1]``() =
        let previous = []
        let current = [ View.Label() ]
        
        testUpdateCollectionGeneric previous current
        |> should equal
            { CreateCount = 1
              UpdateCount = 0
              AttachCount = 1
              TargetCollectionCount = 1 }
    
    [<Test>]
    let ``Given previous state = 1 / current state = 1, updateCollectionGeneric should do nothing``() =
        // To keep the reference the same between 2 states, we use dependsOn
        let label = dependsOn () (fun _ _ -> View.Label())
        let previous = [ label ]
        let current = [ label ]
        
        testUpdateCollectionGeneric previous current
        |> should equal
            { CreateCount = 0
              UpdateCount = 0
              AttachCount = 1 // TODO: It should be 0 instead of 1. This is an issue in the algorithm. It shouldn't run attach if the reference is the same. Need to be fixed.
              TargetCollectionCount = 1 }
    
    [<Test>]
    let ``Given previous state = 1 / current state = 1", updateCollectionGeneric should Update[1 -> 1"]``() =
        let previous = [ View.Label() ]
        let current = [ View.Label() ]
        
        testUpdateCollectionGeneric previous current
        |> should equal
            { CreateCount = 0
              UpdateCount = 1
              AttachCount = 1
              TargetCollectionCount = 1 }
    
    [<Test>]
    let ``Given previous state = 1 / current state = 2, updateCollectionGeneric should Update[1 -> 2]``() =
        let previous = [ View.Label(text = "A") ]
        let current = [ View.Label(text = "B") ]
        
        testUpdateCollectionGeneric previous current
        |> should equal
            { CreateCount = 0
              UpdateCount = 1
              AttachCount = 1
              TargetCollectionCount = 1 }
    
    [<Test>]
    let ``Given previous state = 1 / current state = Empty, updateCollectionGeneric should Remove[1]``() =
        let previous = [ View.Label() ]
        let current = []
        
        testUpdateCollectionGeneric previous current
        |> should equal
            { CreateCount = 0
              UpdateCount = 0
              AttachCount = 0
              TargetCollectionCount = 0 }
    
    [<Test>]
    let ``Given previous state = 1 / current state = 1"-2, updateCollectionGeneric should Update[1 -> 1"] + Create[2]``() =
        let previous =
            [ View.Label(text = "A") ]
        let current =
            [ View.Label(text = "A")
              View.Label(text = "B") ]
        
        testUpdateCollectionGeneric previous current
        |> should equal
            { CreateCount = 1
              UpdateCount = 1
              AttachCount = 2
              TargetCollectionCount = 2 }
    
    [<Test>]
    let ``Given previous state = 1-2 / current state = 3-1"-2", updateCollectionGeneric should Update[1 -> 3 | 2 -> 1"] + Create[2"]``() =        
        let previous =
            [ View.Label(text = "A")
              View.Label(text = "B") ]
        let current =
            [ View.Label(text = "C")
              View.Label(text = "A")
              View.Label(text = "B") ]
        
        testUpdateCollectionGeneric previous current
        |> should equal
            { CreateCount = 1
              UpdateCount = 2
              AttachCount = 3
              TargetCollectionCount = 3 }
    
    [<Test>]
    let ``Given previous state = 1-2-3-4 / current state = 1"-3"-4", updateCollectionGeneric should Update[1 -> 1" | 2 -> 3" | 3 -> 4"] + Remove[4]``() =        
        let previous =
            [ View.Label(text = "A")
              View.Label(text = "B")
              View.Label(text = "C")
              View.Label(text = "D") ]
        let current =
            [ View.Label(text = "A")
              View.Label(text = "C")
              View.Label(text = "D") ]
        
        testUpdateCollectionGeneric previous current
        |> should equal
            { CreateCount = 0
              UpdateCount = 3
              AttachCount = 3
              TargetCollectionCount = 3 }
    
    [<Test>]
    let ``Given previous state = L1 / current state = B1, updateCollectionGeneric should Replace[L1 -> B1]``() =        
        let previous =
            [ View.Label() ]
        let current =
            [ View.Button() ]
        
        testUpdateCollectionGeneric previous current
        |> should equal
            { CreateCount = 1
              UpdateCount = 0
              AttachCount = 1
              TargetCollectionCount = 1 }
            
        

