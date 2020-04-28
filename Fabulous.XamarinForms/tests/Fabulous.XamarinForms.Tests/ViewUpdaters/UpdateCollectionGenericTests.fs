namespace Fabulous.XamarinForms.Tests.ViewUpdaters

open Fabulous
open System.Collections.Generic
open Fabulous.XamarinForms
open NUnit.Framework
open FsUnit

// 1 & 1' means its the same ViewElement (same property values), except it's not the same .NET reference
// X & Y means its 2 different ViewElement types that can't be reused between themselves (e.g. Label vs Button)  
module UpdateCollectionGenericTests =
    let (-->) previous current = previous, current
    let (?->) previous current = (ValueSome previous), current
    
    type Operation =
        | Create of ViewElement
        | Update of previous: ViewElement * current: ViewElement
        | Remove of ViewElement
        | Attach of previous: ViewElement voption * current: ViewElement
    
    let private testUpdateCollectionGeneric previousCollection newCollection =
        let operations = List<Operation>()
        
        let mockCreate viewElement =
            operations.Add(Create viewElement); viewElement.ToString() :> obj
            
        let mockUpdate previousViewElement currentViewElement target =
            // When updating, the target control should always be in sync with the previous ViewElement
            target |> should equal (previousViewElement.ToString() :> obj)
            operations.Add(Update (previousViewElement, currentViewElement))
            
        let mockAttach previousViewElement currentViewElement _ =
            operations.Add(Attach (previousViewElement, currentViewElement))
           
        let targetCollection = System.Collections.Generic.List<obj>() :> IList<obj>
        for prevElement in previousCollection do
            targetCollection.Add(prevElement.ToString() :> obj)
       
        do updateCollectionGeneric
               (ValueSome (Array.ofList previousCollection))
               (ValueSome (Array.ofList newCollection))
               targetCollection
               mockCreate
               mockAttach
               ViewHelpers.canReuseView
               ViewHelpers.getKey
               mockUpdate
                
        if previousCollection.Length > targetCollection.Count then
            for i = targetCollection.Count to previousCollection.Length - 1 do
                operations.Add(Remove previousCollection.[i])

        operations |> Seq.toList  
    
    [<Test>]
    let ``Given previous state = Empty / current state = Empty, updateCollectionGeneric should do nothing``() =
        let previous = []
        let current = []
        
        testUpdateCollectionGeneric previous current
        |> should equivalent []
    
    [<Test>]
    let ``Given previous state = Empty / current state = 1, updateCollectionGeneric should Create[1]``() =
        let previous = []
        let current = [ View.Label() ]
        
        testUpdateCollectionGeneric previous current
        |> should equivalent
            [ Create current.[0]
              Attach (ValueNone --> current.[0]) ]
    
    [<Test>]
    let ``Given previous state = 1 / current state = 1, updateCollectionGeneric should do nothing``() =
        // To keep the reference the same between 2 states, we use dependsOn
        let label = dependsOn () (fun _ _ -> View.Label())
        let previous = [ label ]
        let current = [ label ]
        
        testUpdateCollectionGeneric previous current
        |> should equivalent
            [
                // TODO: This should be empty. It is an issue in the algorithm. We shouldn't run attach if the reference is the same. Needs to be fixed.
                Attach (previous.[0] ?-> current.[0])
            ]
    
    [<Test>]
    let ``Given previous state = 1 / current state = 1', updateCollectionGeneric should Update[1 -> 1']``() =
        let previous = [ View.Label() ]
        let current = [ View.Label() ]
        
        testUpdateCollectionGeneric previous current
        |> should equivalent
            [ Update (previous.[0] --> current.[0])
              Attach (previous.[0] ?-> current.[0]) ]
    
    [<Test>]
    let ``Given previous state = 1 / current state = 2, updateCollectionGeneric should Update[1 -> 2]``() =
        let previous = [ View.Label(text = "A") ]
        let current = [ View.Label(text = "B") ]
        
        testUpdateCollectionGeneric previous current
        |> should equivalent
            [ Update (previous.[0] --> current.[0])
              Attach (previous.[0] ?-> current.[0]) ]
    
    [<Test>]
    let ``Given previous state = 1 / current state = Empty, updateCollectionGeneric should Remove[1]``() =
        let previous = [ View.Label() ]
        let current = []
        
        testUpdateCollectionGeneric previous current
        |> should equivalent
            [ Remove previous.[0] ]
    
    [<Test>]
    let ``Given previous state = 1 / current state = 1'-2, updateCollectionGeneric should Update[1 -> 1'] + Create[2]``() =
        let previous =
            [ View.Label(text = "A") ]
        let current =
            [ View.Label(text = "A")
              View.Label(text = "B") ]
        
        testUpdateCollectionGeneric previous current
        |> should equivalent
            [ Update (previous.[0] --> current.[0])
              Attach (previous.[0] ?-> current.[0])
              Create current.[1]
              Attach (ValueNone --> current.[1]) ]
    
    [<Test>]
    let ``Given previous state = 1-2 / current state = 3-1'-2', updateCollectionGeneric should Update[1 -> 3 | 2 -> 1'] + Create[2']``() =        
        let previous =
            [ View.Label(text = "A")
              View.Label(text = "B") ]
        let current =
            [ View.Label(text = "C")
              View.Label(text = "A")
              View.Label(text = "B") ]
        
        testUpdateCollectionGeneric previous current
        |> should equivalent
            [ Update (previous.[0] --> current.[0])
              Attach (previous.[0] ?-> current.[0])
              Update (previous.[1] --> current.[1])
              Attach (previous.[1] ?-> current.[1])
              Create current.[2]
              Attach (ValueNone --> current.[2]) ]
    
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
        
        testUpdateCollectionGeneric previous current
        |> should equivalent
            [ Update (previous.[0] --> current.[0])
              Attach (previous.[0] ?-> current.[0])
              Update (previous.[1] --> current.[1])
              Attach (previous.[1] ?-> current.[1])
              Update (previous.[2] --> current.[2])
              Attach (previous.[2] ?-> current.[2])
              Remove previous.[3] ]
    
    [<Test>]
    let ``Given previous state = X / current state = Y, updateCollectionGeneric should replace X with Create[Y]``() =        
        let previous =
            [ View.Label() ]
        let current =
            [ View.Button() ]
        
        testUpdateCollectionGeneric previous current
        |> should equivalent
            [ Create current.[0]
              Attach (ValueNone --> current.[0]) ]
