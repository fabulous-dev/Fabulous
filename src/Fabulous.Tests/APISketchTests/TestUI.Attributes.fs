namespace Fabulous.Tests.APISketchTests

module TestUI_Attributes =

    open System
    open Fabulous
    open Fabulous.ScalarAttributeDefinitions
    open Platform

    module Attributes =

        let definePressable name : ScalarAttributeDefinition<obj, obj> =
            let key =
                ScalarAttributeDefinition.CreateAttributeData<obj, obj>(
                    (fun x -> x),
                    ScalarAttributeComparers.noCompare,
                    (fun _ newValueOpt node ->

                        let btn = node.Target :?> IButton

                        match node.TryGetHandler<int>(name) with
                        | ValueNone -> ()
                        | ValueSome handlerId -> btn.RemovePressListener handlerId

                        match newValueOpt with
                        | ValueNone -> node.SetHandler(name, ValueNone)

                        | ValueSome msg ->
                            let handler () = Dispatcher.dispatch node msg

                            let handlerId = btn.AddPressListener handler
                            node.SetHandler<int>(name, ValueSome handlerId))
                )
                |> AttributeDefinitionStore.registerScalar

            { Key = key; Name = name }




        // --------------- Actual Properties ---------------
        //    open Fabulous.Attributes

        module Text =
            let Record =
                Attributes.defineBool "Record" TestUI_ViewUpdaters.updateRecord

            let Text =
                Attributes.defineSimpleScalarWithEquality<string> "Text" TestUI_ViewUpdaters.updateText


        module TextStyle =
            let TextColor =
                Attributes.defineSimpleScalarWithEquality<string> "TextColor" TestUI_ViewUpdaters.updateTextColor

        module Container =
            let Children =
                Attributes.defineListWidgetCollection
                    "Container_Children"
                    TestUI_ViewNode.ViewNode.getViewNode
                    (fun target -> (target :?> IContainer).Children :> System.Collections.Generic.IList<_>)

        module Button =
            let Pressed = definePressable "Button_Pressed"


        module Automation =
            let AutomationId =
                Attributes.defineSimpleScalarWithEquality<string> "AutomationId" TestUI_ViewUpdaters.updateAutomationId

        module NumericBag =
            let InlineValueOne =
                Attributes.defineSmallScalar<uint64> "InlineValueOne" id TestUI_ViewUpdaters.updateNumericValueOne

            let InlineValueTwo =
                Attributes.defineSmallScalar<uint64> "InlineValueTwo" id TestUI_ViewUpdaters.updateNumericValueTwo

            let InlineValueThree =
                Attributes.defineSmallScalar<float>
                    "InlineValueThree"
                    BitConverter.UInt64BitsToDouble
                    TestUI_ViewUpdaters.updateNumericValueThree


            let BoxedValueOne =
                Attributes.defineSimpleScalarWithEquality<uint64> "BoxedValueOne" TestUI_ViewUpdaters.updateNumericValueOne

            let BoxedValueTwo =
                Attributes.defineSimpleScalarWithEquality<uint64> "BoxedValueTwo" TestUI_ViewUpdaters.updateNumericValueTwo

            let BoxedValueThree =
                Attributes.defineSimpleScalarWithEquality<float> "BoxedValueThree" TestUI_ViewUpdaters.updateNumericValueThree
