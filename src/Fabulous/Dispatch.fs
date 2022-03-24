namespace Fabulous

module Dispatcher =
    /// Retrieve the MapMsg function to apply before a dispatch by going up the ViewNode tree
    let private getMapMsgFor (node: IViewNode) : obj -> obj =
        let mutable currentNode = ValueSome node
        let mutable mapMsg = id

        while currentNode.IsSome do
            mapMsg <-
                match AttributeHelpers.tryFindScalarAttribute MapMsg.MapMsg currentNode.Value.Widget with
                | ValueNone -> mapMsg
                | ValueSome fn -> mapMsg >> fn
                
            currentNode <- currentNode.Value.Parent

        mapMsg
        
    /// Dispatch a msg for the current ViewNode
    let dispatch (node: IViewNode) msg =
        let mapMsg = getMapMsgFor node
        let mappedMsg = mapMsg msg
        node.TreeContext.Dispatch(mappedMsg)
    
    /// Trigger an event for the root and all descendants declaring the given event definition
    let dispatchEventForAllChildren (node: IViewNode) (rootWidget: Widget) (definition: ScalarAttributeDefinition<obj, obj, obj>) =
        let rec dispatchAndVisitChildren dispatch mapMsg widget =
            // Check if the current widget has a MapMsg function and apply it
            let currentMapMsg =
                match AttributeHelpers.tryFindScalarAttribute MapMsg.MapMsg widget with
                | ValueNone -> mapMsg
                | ValueSome fn -> fn >> mapMsg
            
            match AttributeHelpers.tryFindScalarAttribute definition widget with
            | ValueNone -> ()
            | ValueSome msg -> dispatch (currentMapMsg msg)
            
            match widget.WidgetAttributes with
            | ValueNone -> ()
            | ValueSome widgetAttrs ->
                for childAttr in widgetAttrs do
                    dispatchAndVisitChildren dispatch mapMsg childAttr.Value
                    
            match widget.WidgetCollectionAttributes with
            | ValueNone -> ()
            | ValueSome widgetCollAttrs ->
                for widgetCollAttr in widgetCollAttrs do
                    let struct (_, widgets) = widgetCollAttr.Value
                    for childWidget in widgets do
                        dispatchAndVisitChildren dispatch currentMapMsg childWidget
        
        dispatchAndVisitChildren node.TreeContext.Dispatch (getMapMsgFor node) rootWidget