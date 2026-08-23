namespace Fabulous.MauiControls.Tests

open System
open System.Collections.ObjectModel
open Fabulous
open Microsoft.Maui.ApplicationModel
open Microsoft.Maui.Controls
open NUnit.Framework

open Fabulous.Maui

open type Fabulous.Maui.View

type CollectionItem = { Name: string }

[<TestFixture>]
type WidgetTests() =
    let createNode (target: BindableObject) =
        let treeContext: ViewTreeContext =
            { CanReuseView = MauiViewHelpers.canReuseView
              GetViewNode = ViewNode.get
              Logger = ProgramDefaults.defaultLogger()
              Dispatch = ignore
              GetComponent = Component.get
              SetComponent = Component.set
              SyncAction = MainThread.BeginInvokeOnMainThread }

        let envContext = new EnvironmentContext(treeContext.Logger)
        let node = new ViewNode(None, envContext, treeContext, WeakReference(target))
        treeContext, node

    [<Test>]
    member _.``Immutable collection updates reuse the item template``() =
        let collectionView = Microsoft.Maui.Controls.CollectionView()
        let treeContext, node = createNode collectionView

        let view items =
            (View.CollectionView (items) (fun item -> Label(string item))).Compile()

        let mutable previousWidget = view [ 1 ]
        Reconciler.update treeContext.CanReuseView ValueNone previousWidget node
        let itemTemplate = collectionView.ItemTemplate

        for items in [ [ 1; 2 ]; [ 2 ]; [ 2; 3 ]; [ 3 ] ] do
            let currentWidget = view items
            Reconciler.update treeContext.CanReuseView (ValueSome previousWidget) currentWidget node
            Assert.That(collectionView.ItemTemplate, Is.SameAs(itemTemplate))
            previousWidget <- currentWidget

    [<Test>]
    member _.``Grouped CollectionView keeps multiple selections from different groups``() =
        let first = { Name = "First" }
        let second = { Name = "Second" }
        let third = { Name = "Third" }
        let firstGroup = ObservableCollection([ first; second ])
        let secondGroup = ObservableCollection([ third ])

        let collectionView =
            Microsoft.Maui.Controls.CollectionView(SelectionMode = SelectionMode.Multiple)

        let treeContext, node = createNode collectionView

        let view (groups: ObservableCollection<CollectionItem> list) =
            (View.GroupedCollectionView
                groups
                (fun (_: ObservableCollection<CollectionItem>) -> Label("Group"))
                (fun (item: CollectionItem) -> Label(item.Name))
                (fun (_: ObservableCollection<CollectionItem>) -> Label("Footer")))
                .selectionMode(SelectionMode.Multiple)
                .Compile()

        let previousWidget = view [ firstGroup; secondGroup ]
        Reconciler.update treeContext.CanReuseView ValueNone previousWidget node
        collectionView.SelectedItems.Add(first)
        collectionView.SelectedItems.Add(third)

        let currentWidget =
            view [ firstGroup; secondGroup; ObservableCollection([ { Name = "Fourth" } ]) ]

        Reconciler.update treeContext.CanReuseView (ValueSome previousWidget) currentWidget node

        Assert.That(collectionView.SelectedItems, Has.Count.EqualTo(2))
        Assert.That(collectionView.SelectedItems, Does.Contain(first))
        Assert.That(collectionView.SelectedItems, Does.Contain(third))

    [<Test>]
    member _.``Changing pages in a NavigationPage will trigger Mounted and Unmounted messages``() =
        let dispatchedMsgs = ResizeArray<string>()
        let dispatch msg = dispatchedMsgs.Add(unbox<string> msg)

        let oldWidget =
            NavigationPage() {
                ContentPage(Label("Hello")).automationId("onboarding")

                ContentPage(Label("Hello")).automationId("howMuch")

                ContentPage(Label("Hello")).automationId("repaymentDate")

                ContentPage(Label("Hello")).automationId("yourDetails")
            }

        let newWidget =
            NavigationPage() {
                ContentPage(Label("Hello")).automationId("onboarding")

                ContentPage(Label("Hello")).automationId("howMuch")

                ContentPage(Label("Hello")).automationId("repaymentDate")

                ContentPage(Label("Hello")).automationId("verificationCode").onMounted("verificationCodeMounted").onUnmounted("verificationCodeUnmounted")
            }

        let newWidget2 =
            NavigationPage() {
                ContentPage(Label("Hello")).automationId("onboarding")

                ContentPage(Label("Hello")).automationId("howMuch")

                ContentPage(Label("Hello")).automationId("repaymentDate")

                ContentPage(Label("Hello")).automationId("yourAddress")
            }

        let treeContext: ViewTreeContext =
            { CanReuseView = MauiViewHelpers.canReuseView
              GetViewNode = ViewNode.get
              Logger = ProgramDefaults.defaultLogger()
              Dispatch = dispatch
              GetComponent = Component.get
              SetComponent = Component.set
              SyncAction = MainThread.BeginInvokeOnMainThread }

        let navPage = FabNavigationPage()
        let weakRef = WeakReference(navPage)
        let envContext = new EnvironmentContext(treeContext.Logger)

        let node = new ViewNode(None, envContext, treeContext, weakRef)

        Reconciler.update treeContext.CanReuseView ValueNone (oldWidget.Compile()) node
        Reconciler.update treeContext.CanReuseView (ValueSome(oldWidget.Compile())) (newWidget.Compile()) node
        Reconciler.update treeContext.CanReuseView (ValueSome(newWidget.Compile())) (newWidget2.Compile()) node

        Assert.AreEqual("yourAddress", navPage.PagesSync[3].AutomationId)
        Assert.AreEqual(2, dispatchedMsgs.Count)
