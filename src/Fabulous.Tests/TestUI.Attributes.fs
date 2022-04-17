module Tests.TestUI_Attributes

open Fabulous
open Tests.Platform

module Attributes =

    let definePressable name =
        let key = AttributeDefinitionStore.getNextKey()

        let definition: ScalarAttributeDefinition<obj, obj, obj> =
            { Key = key
              Name = name
              Convert = id
              ConvertValue = id
              Compare = ScalarAttributeComparers.noCompare
              UpdateNode =
                  fun _ newValueOpt node ->

                      let btn = node.Target :?> IButton

                      match node.TryGetHandler<int>(key) with
                      | ValueNone -> ()
                      | ValueSome handlerId -> btn.RemovePressListener handlerId

                      match newValueOpt with
                      | ValueNone -> node.SetHandler(key, ValueNone)

                      | ValueSome msg ->
                          let handler () = Dispatcher.dispatch node msg

                          let handlerId = btn.AddPressListener handler
                          node.SetHandler<int>(key, ValueSome handlerId) }

        AttributeDefinitionStore.set key (definition.ToAttributeDefinition())

        definition

    // --------------- Actual Properties ---------------
    //    open Fabulous.Attributes

    module Text =
        let Record =
            Attributes.define<bool> "Text" TestUI_ViewUpdaters.updateRecord

        let Text =
            Attributes.define<string> "Text" TestUI_ViewUpdaters.updateText


    module TextStyle =
        let TextColor =
            Attributes.define<string> "TextColor" TestUI_ViewUpdaters.updateTextColor

    module Container =
        let Children =
            Attributes.defineWidgetCollection
                "Container_Children"
                TestUI_ViewNode.ViewNode.getViewNode
                (fun target -> (target :?> IContainer).Children :> System.Collections.Generic.IList<_>)

    module Button =
        let Pressed = definePressable "Button_Pressed"


    module Automation =
        let AutomationId =
            Attributes.define<string> "AutomationId" TestUI_ViewUpdaters.updateAutomationId

    module NumericBag =
        let InlineValueOne =
            Attributes.defineSmallScalarWithConverter<uint64, uint64>
                "InlineValueOne"
                id
                id
                TestUI_ViewUpdaters.updateNumericValueOne

        let InlineValueTwo =
            Attributes.defineSmallScalarWithConverter<uint64, uint64>
                "InlineValueTwo"
                id
                id
                TestUI_ViewUpdaters.updateNumericValueTwo
        
        let InlineValueThree =
            Attributes.defineSmallScalarWithConverter<uint64, uint64>
                "InlineValueThree"
                id
                id
                TestUI_ViewUpdaters.updateNumericValueThree
                
                
        let BoxedValueOne =
            Attributes.define<uint64> "BoxedValueOne" TestUI_ViewUpdaters.updateNumericValueOne
            
        let BoxedValueTwo =
            Attributes.define<uint64> "BoxedValueTwo" TestUI_ViewUpdaters.updateNumericValueTwo
        
        let BoxedValueThree =
            Attributes.define<uint64> "BoxedValueThree" TestUI_ViewUpdaters.updateNumericValueThree
