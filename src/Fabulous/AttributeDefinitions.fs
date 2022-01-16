namespace Fabulous

open Fabulous


/// Attribute definition for scalar properties
type ScalarAttributeDefinition<'inputType, 'modelType, 'valueType> =
    { Key: AttributeKey
      Name: string
      Convert: 'inputType -> 'modelType
      ConvertValue: 'modelType -> 'valueType
      Compare: 'modelType * 'modelType -> ScalarAttributeComparison
      UpdateNode: 'valueType voption * IViewNode -> unit }

    member x.WithValue(value) : ScalarAttribute =
        { Key = x.Key
#if DEBUG
          DebugName = x.Name
#endif
          Value = x.Convert(value) }

    interface IScalarAttributeDefinition with
        member x.Key = x.Key

        member x.CompareBoxed(a, b) =
            x.Compare(unbox<'modelType> a, unbox<'modelType> b)

        member x.UpdateNode(newValueOpt, node) =
            let newValueOpt =
                match newValueOpt with
                | ValueNone -> ValueNone
                | ValueSome v -> ValueSome(x.ConvertValue(unbox<'modelType> v))

            x.UpdateNode(newValueOpt, node)

/// Attribute definition for widget properties
type WidgetAttributeDefinition =
    { Key: AttributeKey
      Name: string
      ApplyDiff: WidgetDiff * IViewNode -> unit
      UpdateNode: Widget voption * IViewNode -> unit }

    member x.WithValue(value: Widget) : WidgetAttribute =
        { Key = x.Key
#if DEBUG
          DebugName = x.Name
#endif
          Value = value }

    interface IAttributeDefinition with
        member x.Key = x.Key

        member x.UpdateNode(newValueOpt, node) =
            let newValueOpt =
                match newValueOpt with
                | ValueNone -> ValueNone
                | ValueSome v -> ValueSome(unbox<Widget> v)

            x.UpdateNode(newValueOpt, node)

/// Attribute definition for collection properties
type WidgetCollectionAttributeDefinition =
    { Key: AttributeKey
      Name: string
      ApplyDiff: ArraySlice<WidgetCollectionItemChange> * IViewNode -> unit
      UpdateNode: ArraySlice<Widget> voption * IViewNode -> unit }

    member x.WithValue(value: ArraySlice<Widget>) : WidgetCollectionAttribute =
        { Key = x.Key
#if DEBUG
          DebugName = x.Name
#endif
          Value = value }

    interface IAttributeDefinition with
        member x.Key = x.Key

        member x.UpdateNode(newValueOpt, node) =
            let newValueOpt =
                match newValueOpt with
                | ValueNone -> ValueNone
                | ValueSome v -> ValueSome(unbox<ArraySlice<Widget>> v)

            x.UpdateNode(newValueOpt, node)
