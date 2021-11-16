module Fabulous.Tests.TestUI_Attributes

open Fabulous
open Test.Platform

module Attributes =

    let definePressable name =
        let key = AttributeDefinitionStore.getNextKey()

        let definition: ScalarAttributeDefinition<_, _> =
            {
                Key = key
                Name = name
                DefaultWith = fun () -> null
                Convert = id
                Compare = ScalarAttributeComparers.noCompare
                UpdateTarget =
                    fun (newValueOpt, target) ->

                        let viewNodeData =
                            (target :?> TestViewElement)
                                .PropertyBag.Item TestUI_ViewNode.ViewNode.ViewNodeProperty
                            :?> TestUI_ViewNode.ViewNodeData

                        let btn = target :?> IButton

                        match viewNodeData.TryGetHandler<int>(key) with
                        | None -> ()
                        | Some handlerId -> btn.RemovePressListener handlerId

                        match newValueOpt with
                        | ValueNone -> viewNodeData.SetHandler(key, ValueNone)

                        | ValueSome msg ->
                            let handler () =
                                viewNodeData.ViewNode.Context.Dispatch msg

                            let handlerId = btn.AddPressListener handler
                            viewNodeData.SetHandler<int>(key, ValueSome handlerId)
            }

        AttributeDefinitionStore.set key definition
        definition
    
    // --------------- Actual Properties ---------------
    //    open Fabulous.Attributes

    module Text =
        let Text =
            Attributes.define<string> "Text" (fun () -> "") TestUI_ViewUpdaters.updateText

    module TextStyle =
        let TextColor =
            Attributes.define<string> "TextColor" (fun () -> "") TestUI_ViewUpdaters.updateTextColor

    module Container =
        let Children =
            Attributes.defineWithComparer<Widget []>
                "Children"
                (justValue [||])
                //                (Seq.map(fun w -> w.Compile()) >> Seq.toArray)
                Attributes.AttributeComparers.alwaysDifferent

    module Button =
        let Pressed = definePressable "Button_Pressed"


    module Automation =
        let AutomationId =
            Attributes.define<string> "AutomationId" (fun () -> "") TestUI_ViewUpdaters.updateAutomationId
