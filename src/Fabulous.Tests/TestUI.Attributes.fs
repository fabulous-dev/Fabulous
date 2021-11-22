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

    /// Define a custom attribute storing a widget collection
    let defineWidgetCollectionWithConverter
        name
        (applyDiff: WidgetCollectionItemChange [] * obj -> unit)
        (updateTarget: Widget [] voption * obj -> unit)
        =
        let key = AttributeDefinitionStore.getNextKey()

        let definition: WidgetCollectionAttributeDefinition =
            {
                Key = key
                Name = name
                ApplyDiff = applyDiff
                UpdateTarget = updateTarget
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
            defineWidgetCollectionWithConverter
                "Container_Children"
                TestUI_ViewUpdaters.applyDiffContainerChildren
                TestUI_ViewUpdaters.updateContainerChildren

    module Button =
        let Pressed = definePressable "Button_Pressed"


    module Automation =
        let AutomationId =
            Attributes.define<string> "AutomationId" (fun () -> "") TestUI_ViewUpdaters.updateAutomationId
