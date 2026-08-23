namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.ScalarAttributeDefinitions
open Microsoft.Maui.Controls
open System
open System.IO
open Microsoft.Maui

[<RequireQualifiedAccess>]
type ImageSourceValue =
    | Source of source: IImageSource
    | File of file: string
    | Uri of uri: Uri
    | Stream of stream: Stream

[<Struct>]
type ValueEventData<'data, 'eventArgs> =
    { Value: 'data
      Event: 'eventArgs -> MsgValue }

module ValueEventData =
    let create (value: 'data) (event: 'eventArgs -> 'msg) =
        { Value = value
          Event = event >> box >> MsgValue }

/// Maui.Controls specific attributes that can be encoded as 8 bytes
module SmallScalars =
    module LayoutOptions =
        let inline encode (v: LayoutOptions) : uint64 =
            let alignment = uint64 v.Alignment

            let expands: uint64 = if v.Expands then 1UL else 0UL

            (alignment <<< 32) ||| expands

        let inline decode (encoded: uint64) : LayoutOptions =
            let alignment =
                enum<LayoutAlignment>(int((encoded &&& 0xFFFFFFFF00000000UL) >>> 32))

            let expands = (encoded &&& 0x00000000FFFFFFFFUL) = 1UL

            LayoutOptions(alignment, expands)

[<Extension>]
type SmallScalarExtensions() =
    [<Extension>]
    static member inline WithValue(this: SmallScalarAttributeDefinition<Microsoft.Maui.Graphics.Color>, value) =
        this.WithValue(value, (fun c -> c.ToUint() |> uint64))

    [<Extension>]
    static member inline WithValue(this: SmallScalarAttributeDefinition<LayoutOptions>, value) =
        this.WithValue(value, SmallScalars.LayoutOptions.encode)

module Attributes =
    /// Define an attribute for a BindableProperty
    let inline defineBindable<'modelType, 'valueType>
        (bindableProperty: BindableProperty)
        ([<InlineIfLambda>] convertValue: 'modelType -> 'valueType)
        ([<InlineIfLambda>] compare: 'modelType -> 'modelType -> ScalarAttributeComparison)
        =
        Attributes.defineScalar<'modelType, 'valueType> bindableProperty.PropertyName convertValue compare (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(bindableProperty)
            | ValueSome v -> target.SetValue(bindableProperty, v))

    /// Define an attribute for a BindableProperty supporting equality comparison
    let inline defineBindableWithEquality<'T when 'T: equality> (bindableProperty: BindableProperty) =
        Attributes.defineSimpleScalarWithEquality<'T> bindableProperty.PropertyName (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(bindableProperty)
            | ValueSome v -> target.SetValue(bindableProperty, v))

    /// Define an attribute that can fit into 8 bytes encoded as uint64 (such as float or bool) for a BindableProperty
    let inline defineSmallBindable<'T> (bindableProperty: BindableProperty) ([<InlineIfLambda>] decode: uint64 -> 'T) =
        Attributes.defineSmallScalar<'T> bindableProperty.PropertyName decode (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(bindableProperty)
            | ValueSome v -> target.SetValue(bindableProperty, v))

    /// Define a float attribute for a BindableProperty and encode it as a small scalar (8 bytes)
    let inline defineBindableFloat (bindableProperty: BindableProperty) =
        defineSmallBindable bindableProperty SmallScalars.Float.decode

    /// Define a boolean attribute for a BindableProperty and encode it as a small scalar (8 bytes)
    let inline defineBindableBool (bindableProperty: BindableProperty) =
        defineSmallBindable bindableProperty SmallScalars.Bool.decode

    /// Define an int attribute for a BindableProperty and encode it as a small scalar (8 bytes)
    let inline defineBindableInt (bindableProperty: BindableProperty) =
        defineSmallBindable bindableProperty SmallScalars.Int.decode

    /// Define a Color attribute for a BindableProperty and encode it as a small scalar (8 bytes)
    let inline defineBindableColor (bindableProperty: BindableProperty) : SmallScalarAttributeDefinition<Microsoft.Maui.Graphics.Color> =
        Attributes.defineSmallScalar bindableProperty.PropertyName (fun c -> Microsoft.Maui.Graphics.Color.FromUint(uint c)) (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(bindableProperty)
            | ValueSome v -> target.SetValue(bindableProperty, v))

    /// Define an enum attribute for a BindableProperty and encode it as a small scalar (8 bytes)
    let inline defineBindableEnum< ^T when ^T: enum<int>> (bindableProperty: BindableProperty) : SmallScalarAttributeDefinition< ^T > =
        Attributes.defineEnum< ^T> bindableProperty.PropertyName (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(bindableProperty)
            | ValueSome v -> target.SetValue(bindableProperty, v))

    /// Performance optimization: avoid allocating a new ImageSource instance on each update
    /// we store the user value (eg. string, Uri, Stream) and convert it to an ImageSource only when needed
    let inline defineBindableImageSource (bindableProperty: BindableProperty) =
        Attributes.defineScalar<ImageSourceValue, ImageSourceValue>
            bindableProperty.PropertyName
            id
            ScalarAttributeComparers.equalityCompare
            (fun _ newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(bindableProperty)
                | ValueSome v ->
                    let value =
                        match v with
                        | ImageSourceValue.Source source -> source
                        | ImageSourceValue.File file -> ImageSource.FromFile file
                        | ImageSourceValue.Uri uri -> ImageSource.FromUri uri
                        | ImageSourceValue.Stream stream -> ImageSource.FromStream(fun () -> stream)

                    target.SetValue(bindableProperty, value))

    /// Define an attribute storing a Widget for a bindable property
    let inline defineBindableWidget (bindableProperty: BindableProperty) =
        Attributes.definePropertyWidget
            bindableProperty.PropertyName
            (fun target -> (target :?> BindableObject).GetValue(bindableProperty))
            (fun target value ->
                let bindableObject = target :?> BindableObject

                if value = null then
                    bindableObject.ClearValue(bindableProperty)
                else
                    bindableObject.SetValue(bindableProperty, value))

    /// Update both a property and its related event.
    /// This definition makes sure that the event is only raised when the property is changed by the user,
    /// and not when the property is set by the code
    let defineBindableWithEvent<'data, 'args>
        name
        (bindableProperty: BindableProperty)
        (getEvent: obj -> IEvent<EventHandler<'args>, 'args>)
        : SimpleScalarAttributeDefinition<ValueEventData<'data, 'args>> =

        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(
                ScalarAttributeComparers.noCompare,
                (fun oldValueOpt (newValueOpt: ValueEventData<'data, 'args> voption) node ->
                    let target = node.Target :?> BindableObject

                    match newValueOpt with
                    | ValueNone ->
                        // The attribute is no longer applied, so we clean up the event
                        match node.TryGetHandler(name) with
                        | ValueNone -> ()
                        | ValueSome handler -> handler.Dispose()

                        // Only clear the property if a value was set before
                        match oldValueOpt with
                        | ValueNone -> ()
                        | ValueSome _ -> target.ClearValue(bindableProperty)

                    | ValueSome curr ->
                        // Clean up the old event handler if any
                        match node.TryGetHandler(name) with
                        | ValueNone -> ()
                        | ValueSome handler -> handler.Dispose()

                        // Set the new value
                        target.SetValue(bindableProperty, curr.Value)

                        // Set the new event handler
                        let event = getEvent target

                        let handler =
                            event.Subscribe(fun args ->
                                let (MsgValue r) = curr.Event args
                                Dispatcher.dispatch node r)

                        node.SetHandler(name, handler))
            )
            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = name }
