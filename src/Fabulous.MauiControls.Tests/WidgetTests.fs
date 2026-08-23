namespace Fabulous.MauiControls.Tests

open System
open Fabulous
open Microsoft.Maui.ApplicationModel
open NUnit.Framework

open Fabulous.Maui

open type Fabulous.Maui.View

[<TestFixture>]
type WidgetTests() =
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

                ContentPage(Label("Hello"))
                    .automationId("verificationCode")
                    .onMounted("verificationCodeMounted")
                    .onUnmounted("verificationCodeUnmounted")
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
