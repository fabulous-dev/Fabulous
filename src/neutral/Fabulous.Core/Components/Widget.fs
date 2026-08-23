namespace Fabulous

open System

module Component' =
    let Data =
        Attributes.defineSimpleScalar<ComponentData> "Component_Data" ScalarAttributeComparers.noCompare (fun _ _ _ -> ())

    let WidgetKey =
        let key = WidgetDefinitionStore.getNextKey()

        let definition =
            { Key = key
              Name = "Component"
              TargetType = typeof<Component>
              CreateView =
                fun (widget, envContext, treeContext, _) ->
                    match widget.ScalarAttributes with
                    | [||] -> failwith "Component widget must have a body"
                    | attrs ->
                        let data =
                            let scalarAttrsOpt =
                                attrs |> Array.tryFind(fun scalarAttr -> scalarAttr.Key = Data.Key)

                            match scalarAttrsOpt with
                            | Some attr -> attr.Value :?> ComponentData
                            | None -> failwith "Component widget must have a body"

                        let envContext = new EnvironmentContext(treeContext.Logger, envContext)
                        let context = new ComponentContext()
                        let comp = new Component(Data.Key, envContext, treeContext, context, data.Body)
                        let struct (node, view) = comp.CreateView(ValueSome widget)

                        treeContext.SetComponent comp view

                        struct (node, view)
              AttachView =
                fun (widget, envContext, treeContext, _, view) ->
                    match widget.ScalarAttributes with
                    | [||] -> failwith "Component widget must have a body"
                    | attrs ->
                        let data =
                            let scalarAttrsOpt =
                                attrs |> Array.tryFind(fun scalarAttr -> scalarAttr.Key = Data.Key)

                            match scalarAttrsOpt with
                            | Some attr -> attr.Value :?> ComponentData
                            | None -> failwith "Component widget must have a body"

                        let envContext = new EnvironmentContext(treeContext.Logger, envContext)
                        let context = new ComponentContext()
                        let comp = new Component(Data.Key, envContext, treeContext, context, data.Body)
                        let node = comp.AttachView(widget, view)

                        treeContext.SetComponent comp view

                        node }

        WidgetDefinitionStore.set key definition
        key

    let canReuseComponent (prev: Widget) (curr: Widget) =
        let prevData =
            match prev.ScalarAttributes with
            | [||] -> failwith "Component widget must have a body"
            | attrs ->
                let scalarAttrsOpt =
                    attrs |> Array.tryFind(fun scalarAttr -> scalarAttr.Key = Data.Key)

                match scalarAttrsOpt with
                | None -> failwithf "Component widget must have a body"
                | Some value -> value.Value :?> ComponentData

        let currData =
            match curr.ScalarAttributes with
            | [||] -> failwith "Component widget must have a body"
            | attrs ->
                let scalarAttrsOpt =
                    attrs |> Array.tryFind(fun scalarAttr -> scalarAttr.Key = Data.Key)

                match scalarAttrsOpt with
                | None -> failwithf "Component widget must have a body"
                | Some value -> value.Value :?> ComponentData

        // NOTE: Somehow using = here crashes the app and prevents debugging...
        Object.Equals(prevData.Key, currData.Key)
