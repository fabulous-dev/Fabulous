module Tests.TestUI_Attributes

open Fabulous
open Tests.Platform

module Attributes =

    let definePressable name =
        let key = AttributeDefinitionStore.getNextKey()

        let definition: ScalarAttributeDefinition<_, _> =
            {
                Key = key
                Name = name
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
                                (viewNodeData.ViewNode :> IViewNode)
                                    .Context.Dispatch(msg)

                            let handlerId = btn.AddPressListener handler
                            viewNodeData.SetHandler<int>(key, ValueSome handlerId)
            }

        AttributeDefinitionStore.set key definition
        definition

    // --------------- Actual Properties ---------------
    //    open Fabulous.Attributes

    module Text =
        let Text =
            Attributes.define<string> "Text" TestUI_ViewUpdaters.updateText

    module TextStyle =
        let TextColor =
            Attributes.define<string> "TextColor" TestUI_ViewUpdaters.updateTextColor

    module Container =
        let Children =
            Attributes.defineWidgetCollection
                TestUI_ViewNode.ViewNode.getViewNode
                "Container_Children"
                (fun target -> (target :?> IContainer).Children)


    module Button =
        let Pressed = definePressable "Button_Pressed"


    module Automation =
        let AutomationId =
            Attributes.define<string> "AutomationId" TestUI_ViewUpdaters.updateAutomationId
