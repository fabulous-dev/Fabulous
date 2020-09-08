// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms
open System
open System.Collections.Generic
open System.Collections.ObjectModel
open System.ComponentModel

/////////////////
/// DataTemplate
/////////////////

[<AllowNullLiteral>]
type IViewElementHolder =
    inherit INotifyPropertyChanged
    abstract ViewElement : ViewElement

[<AllowNullLiteral>]
type ViewElementHolder(viewElement: ViewElement) =
    let ev = new Event<_,_>()
    let mutable data = viewElement

    interface IViewElementHolder with
        member x.ViewElement = data
        [<CLIEvent>] member x.PropertyChanged = ev.Publish

    member x.ViewElement
        with get() = data
        and set(value) =
            data <- value
            ev.Trigger(x, PropertyChangedEventArgs "ViewElement")

[<AllowNullLiteral>]
type ViewElementHolderGroup(shortName: string, viewElement: ViewElement, items: ViewElement[]) =
    inherit ObservableCollection<ViewElementHolder>(Seq.map ViewElementHolder items)

    let ev = new Event<_,_>()
    let mutable shortNameData = shortName
    let mutable data = viewElement

    interface IViewElementHolder with
        member x.ViewElement = data
        [<CLIEvent>] member x.PropertyChanged = ev.Publish

    member x.ViewElement
        with get() = data
        and set(value) =
            data <- value
            ev.Trigger(x, PropertyChangedEventArgs "ViewElement")

    member x.ShortName
        with get() = shortNameData
        and set(value) =
            shortNameData <- value
            ev.Trigger(x, PropertyChangedEventArgs "ShortName")

    member __.Items = items

module BindableHelpers =
    let private setRef (viewElement: ViewElement) (target: obj) =
        match viewElement.TryGetAttributeKeyed(ViewElement.RefAttribKey) with
        | ValueSome f -> f.Set (box target)
        | ValueNone -> ()

    let private unsetRef (viewElement: ViewElement) =
        match viewElement.TryGetAttributeKeyed(ViewElement.RefAttribKey) with
        | ValueSome f -> f.Unset ()
        | ValueNone -> ()

    let createOnBindingContextChanged (bindableObject: BindableObject) =
        let mutable holderOpt : IViewElementHolder voption = ValueNone
        let mutable prevModelOpt : ViewElement voption = ValueNone

        let onDataPropertyChanged = PropertyChangedEventHandler(fun _ args ->
            match args.PropertyName, holderOpt, prevModelOpt with
            | "ViewElement", ValueSome holder, ValueSome prevModel ->
                unsetRef prevModel
                holder.ViewElement.UpdateIncremental (prevModel, bindableObject)
                setRef holder.ViewElement bindableObject
                prevModelOpt <- ValueSome holder.ViewElement
            | _ -> ()
        )

        let onBindingContextChanged () =
            match holderOpt with
            | ValueNone -> ()
            | ValueSome prevHolder ->
                prevHolder.PropertyChanged.RemoveHandler onDataPropertyChanged
                unsetRef prevHolder.ViewElement

            match bindableObject.BindingContext with
            | :? IViewElementHolder as newHolder ->
                newHolder.PropertyChanged.AddHandler onDataPropertyChanged
                newHolder.ViewElement.UpdateInherited(prevModelOpt, newHolder.ViewElement, bindableObject)
                setRef newHolder.ViewElement bindableObject
                holderOpt <- ValueSome newHolder
                prevModelOpt <- ValueSome newHolder.ViewElement
            | _ ->
                // Only remove the previous holder reference since we don't need it anymore
                // prevModelOpt on the other hand needs to be kept, since Xamarin.Forms will first
                // set BindingContext to null before setting a new item
                holderOpt <- ValueNone

        onBindingContextChanged

type ViewElementDataTemplate(``type``) =
    inherit DataTemplate(fun () ->
        let bindableObject = (Activator.CreateInstance ``type``) :?> BindableObject
        let onBindingContextChanged = BindableHelpers.createOnBindingContextChanged bindableObject
        bindableObject.BindingContextChanged.Add (fun _ -> onBindingContextChanged ())
        bindableObject :> obj
    )

type ViewElementDataTemplateSelector() =
    inherit DataTemplateSelector()
    let cache = Dictionary<Type, ViewElementDataTemplate>()
    override this.OnSelectTemplate(item, _) =
        let holder = item :?> IViewElementHolder
        let targetType = holder.ViewElement.TargetType

        match cache.TryGetValue targetType with
        | false, _ ->
            let template = ViewElementDataTemplate(targetType)
            cache.[targetType] <- template
            template :> DataTemplate
        | true, template ->
            template :> DataTemplate

type DirectViewElementDataTemplate(viewElement: ViewElement) =
    inherit DataTemplate(Func<obj>(viewElement.Create))

/////////////////
/// Cells
/////////////////

type CustomEntryCell() as self =
    inherit EntryCell()
    let textChanged = Event<EventHandler<TextChangedEventArgs>, TextChangedEventArgs>()
    let mutable oldTextValue = ""

    do self.PropertyChanging.Add(
        fun args ->
            if args.PropertyName = "Text" then
                oldTextValue <- self.Text)

    do self.PropertyChanged.Add(
        fun args ->
            if args.PropertyName = "Text" then
                textChanged.Trigger(self, TextChangedEventArgs(oldTextValue, self.Text)))

    [<CLIEvent>] member __.TextChanged = textChanged.Publish

/////////////////
/// Collections
/////////////////

type CustomListView() =
    inherit ListView(ItemTemplate = ViewElementDataTemplateSelector())

type CustomGroupListView() =
    inherit ListView(IsGroupingEnabled = true, ItemTemplate = ViewElementDataTemplateSelector(), GroupHeaderTemplate = ViewElementDataTemplateSelector())

type CustomCollectionView() =
    inherit CollectionView(ItemTemplate = ViewElementDataTemplateSelector())

type CustomCarouselView() =
    inherit CarouselView(ItemTemplate = ViewElementDataTemplateSelector())

/////////////////
/// Controls
/////////////////

/// A name holder for effects that don't require to create a cross-platform type to use them
type CustomEffect() =
    inherit BindableObject()
    member val Name = "" with get, set

/// A custom SearchHandler which exposes the overridable methods OnQueryChanged, OnQueryConfirmed and OnItemSelected as events
type CustomSearchHandler() =
    inherit SearchHandler(ItemTemplate = ViewElementDataTemplateSelector())

    let queryChanged = Event<EventHandler<string * string>, _>()
    let queryConfirmed = Event<EventHandler, _>()
    let itemSelected = Event<EventHandler<obj>, _>()

    [<CLIEvent>] member __.QueryChanged = queryChanged.Publish
    [<CLIEvent>] member __.QueryConfirmed = queryConfirmed.Publish
    [<CLIEvent>] member __.ItemSelected = itemSelected.Publish

    override this.OnQueryChanged(oldValue, newValue) = queryChanged.Trigger(this, (oldValue, newValue))
    override this.OnQueryConfirmed() = queryConfirmed.Trigger(this, null)
    override this.OnItemSelected(item) = itemSelected.Trigger(this, item)

/// A custom TimePicker which exposes a TimeChanged event to notify when the user has selected a new time from the picker
type CustomTimePicker() =
    inherit TimePicker()

    let timeChanged = Event<EventHandler<TimeSpan>, _>()

    [<CLIEvent>] member __.TimeChanged = timeChanged.Publish

    override this.OnPropertyChanged(propertyName) =
        base.OnPropertyChanged(propertyName)
        if propertyName = "Time" then
            timeChanged.Trigger(this, this.Time)

/// Itemslayout for CarouselView
type VerticalLinearItemsLayout() =
    inherit LinearItemsLayout(ItemsLayoutOrientation.Vertical)

type HorizontalLinearItemsLayout() =
    inherit LinearItemsLayout(ItemsLayoutOrientation.Horizontal)

type CarouselVerticalItemsLayout() =
    inherit LinearItemsLayout(ItemsLayoutOrientation.Vertical, SnapPointsType = SnapPointsType.MandatorySingle, SnapPointsAlignment = SnapPointsAlignment.Center)

/////////////////
/// Pages
/////////////////

/// The underlying page type for the ContentPage view element
type CustomContentPage() as self =
    inherit ContentPage()
    do Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(self, true)

    let sizeAllocated = Event<EventHandler<double * double>, _>()

    [<CLIEvent>] member __.SizeAllocated = sizeAllocated.Publish

    override this.OnSizeAllocated(width, height) =
        base.OnSizeAllocated(width, height)
        sizeAllocated.Trigger(this, (width, height))