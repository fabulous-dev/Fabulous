namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.ScalarAttributeDefinitions
open Xamarin.Forms
open System

[<Struct>]
type AppThemeValues<'T> = { Light: 'T; Dark: 'T voption }

module AppTheme =
    let inline create<'T> (light: 'T) (dark: 'T option) =
        { Light = light
          Dark =
            match dark with
            | None -> ValueNone
            | Some v -> ValueSome v }

module ColorPair =
    let inline create (light: FabColor) (dark: FabColor option) : struct (FabColor * FabColor) =
        struct (light,
                match dark with
                | None -> light
                | Some v -> v)

[<Struct>]
type ValueEventData<'data, 'eventArgs> =
    { Value: 'data
      Event: 'eventArgs -> obj }

module ValueEventData =
    let create (value: 'data) (event: 'eventArgs -> obj) = { Value = value; Event = event }

/// Xamarin Forms specific attributes that can be encoded as 8 bytes
module SmallScalars =
    module ColorPair =
        let inline encode (v: struct (FabColor * FabColor)) : uint64 =
            let struct (a, b) = v

            ((a |> SmallScalars.FabColor.encode) <<< 32)
            ||| (b |> SmallScalars.FabColor.encode |> uint64)

        let inline decode (encoded: uint64) : struct (FabColor * FabColor) =
            let a =
                ((encoded &&& 0xFFFFFFFF00000000UL) >>> 32)
                |> SmallScalars.FabColor.decode

            let b =
                (encoded &&& 0x00000000FFFFFFFFUL)
                |> SmallScalars.FabColor.decode

            (a, b)


    module LayoutOptions =
        let inline encode (v: LayoutOptions) : uint64 =
            let alignment = uint64 v.Alignment

            let expands: uint64 =
                if v.Expands then 1UL else 0UL

            (alignment <<< 32) ||| expands

        let inline decode (encoded: uint64) : LayoutOptions =
            let alignment =
                enum<LayoutAlignment>(int((encoded &&& 0xFFFFFFFF00000000UL) >>> 32))

            let expands =
                (encoded &&& 0x00000000FFFFFFFFUL) = 1UL

            LayoutOptions(alignment, expands)

open SmallScalars

[<Extension>]
type SmallScalarExtensions() =

    [<Extension>]
    static member inline ToXFColor(this: FabColor) : Color =
        Color.FromRgba(int this.R, int this.G, int this.B, int this.A)

    [<Extension>]
    static member inline ToFabColor(this: Color) : FabColor =
        let a = int(uint8(this.A * 255.0)) <<< 24
        let r = int(uint8(this.R * 255.0)) <<< 16
        let g = int(uint8(this.G * 255.0)) <<< 8
        let b = int(uint8(this.B * 255.0))
        FabColor.fromHex(a ||| r ||| g ||| b)

    [<Extension>]
    static member inline WithValue(this: SmallScalarAttributeDefinition<LayoutOptions>, value) =
        this.WithValue(value, SmallScalars.LayoutOptions.encode)

    [<Extension>]
    static member inline WithValue(this: SmallScalarAttributeDefinition<struct (FabColor * FabColor)>, value) =
        this.WithValue(value, ColorPair.encode)

module Attributes =
    /// Define an attribute for a BindableProperty
    let inline defineBindable<'modelType, 'valueType>
        (bindableProperty: BindableProperty)
        ([<InlineIfLambda>] convertValue: 'modelType -> 'valueType)
        ([<InlineIfLambda>] compare: 'modelType -> 'modelType -> ScalarAttributeComparison)
        =
        Attributes.defineScalar<'modelType, 'valueType>
            bindableProperty.PropertyName
            convertValue
            compare
            (fun _ newValueOpt node ->
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

    /// Define a Color attribute for a BindableProperty and encode it as a small scalar (8 bytes).
    /// Note that the input type is System.Drawing.Color because it is just 4 bytes
    /// But it converts back to Xamarin.Forms.Color when a value is applied
    /// Note if you want to use Xamarin.Forms.Color directly you can do that with "defineBindable".
    /// However, XF.Color will be boxed and thus slower.
    let inline defineBindableColor (bindableProperty: BindableProperty) : SmallScalarAttributeDefinition<FabColor> =
        Attributes.defineSmallScalar<FabColor>
            bindableProperty.PropertyName
            SmallScalars.FabColor.decode
            (fun _ newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(bindableProperty)
                | ValueSome v -> target.SetValue(bindableProperty, v.ToXFColor()))

    /// Define an enum attribute for a BindableProperty and encode it as a small scalar (8 bytes)
    let inline defineBindableEnum< ^T when ^T: enum<int>>
        (bindableProperty: BindableProperty)
        : SmallScalarAttributeDefinition< ^T > =
        Attributes.defineEnum< ^T> bindableProperty.PropertyName (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(bindableProperty)
            | ValueSome v -> target.SetValue(bindableProperty, v))

    /// Define an attribute that supports values for both Light and Dark themes
    let inline defineBindableAppTheme<'T when 'T: equality> (bindableProperty: BindableProperty) =
        Attributes.defineSimpleScalarWithEquality<AppThemeValues<'T>>
            bindableProperty.PropertyName
            (fun _ newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(bindableProperty)
                | ValueSome { Light = light; Dark = ValueNone } -> target.SetValue(bindableProperty, light)
                | ValueSome { Light = light; Dark = ValueSome dark } ->
                    target.SetOnAppTheme(bindableProperty, light, dark))

    /// Define a Color attribute that supports values for both Light and Dark themes
    /// Note that we use System.Drawing.Color here because we can encode two into 8 bytes
    /// Thus we can avoid heap allocations
    let inline defineBindableAppThemeColor (bindableProperty: BindableProperty) =
        Attributes.defineSmallScalar<struct (FabColor * FabColor)>
            bindableProperty.PropertyName
            ColorPair.decode
            (fun _ newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(bindableProperty)
                | ValueSome (light, dark) -> target.SetOnAppTheme(bindableProperty, light.ToXFColor(), dark.ToXFColor()))

    /// Define an attribute storing a Widget for a bindable property
    let inline defineBindableWidget (bindableProperty: BindableProperty) =
        Attributes.definePropertyWidget
            bindableProperty.PropertyName
            (fun target ->
                let childTarget =
                    (target :?> BindableObject)
                        .GetValue(bindableProperty)

                ViewNode.get childTarget)
            (fun target value ->
                let bindableObject =
                    target :?> BindableObject

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
                    let event = getEvent target

                    match newValueOpt with
                    | ValueNone ->
                        // The attribute is no longer applied, so we clean up the event
                        match node.TryGetHandler(name) with
                        | ValueNone -> ()
                        | ValueSome handler -> event.RemoveHandler(handler)

                        // Only clear the property if a value was set before
                        match oldValueOpt with
                        | ValueNone -> ()
                        | ValueSome _ -> target.ClearValue(bindableProperty)

                    | ValueSome curr ->
                        // Clean up the old event handler if any
                        match node.TryGetHandler(name) with
                        | ValueNone -> ()
                        | ValueSome handler -> event.RemoveHandler(handler)

                        // Set the new value
                        target.SetValue(bindableProperty, curr.Value)

                        // Set the new event handler
                        let handler =
                            EventHandler<'args> (fun _ args ->
                                let r = curr.Event args
                                Dispatcher.dispatch node r)

                        node.SetHandler(name, ValueSome handler)
                        event.AddHandler(handler))
            )
            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = name }
