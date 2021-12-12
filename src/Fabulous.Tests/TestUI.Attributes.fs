module Tests.TestUI_Attributes

open Fabulous
open Tests.Platform

module Attributes =

    let definePressable name =
        let key = AttributeDefinitionStore.getNextKey()

        let definition: ScalarAttributeDefinition<obj, obj> =
            {
                Key = key
                Name = name
                Convert = id
                Compare = ScalarAttributeComparers.noCompare
                UpdateTarget =
                    fun (newValueOpt, context, target) ->

                        let viewNode =
                            context.ViewTreeContext.GetViewNode(target)

                        let btn = target :?> IButton

                        match viewNode.TryGetHandler<int>(key) with
                        | ValueNone -> ()
                        | ValueSome handlerId -> btn.RemovePressListener handlerId

                        match newValueOpt with
                        | ValueNone -> viewNode.SetHandler(key, ValueNone)

                        | ValueSome msg ->
                            let handler () =
                                Attributes.dispatchMsgOnViewNode viewNode msg

                            let handlerId = btn.AddPressListener handler
                            viewNode.SetHandler<int>(key, ValueSome handlerId)
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
            Attributes.defineWidgetCollection "Container_Children" (fun target -> (target :?> IContainer).Children)


    module Button =
        let Pressed = definePressable "Button_Pressed"


    module Automation =
        let AutomationId =
            Attributes.define<string> "AutomationId" TestUI_ViewUpdaters.updateAutomationId
