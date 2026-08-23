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
    member _.``NavigationStack supports multiple instances of the same page type``() =
        let stack =
            NavigationStack.create(Route.create "details-1" "details")
            |> NavigationStack.push(Route.create "details-2" "details")

        Assert.That(stack.Routes |> List.map _.Id, Is.EqualTo([ "details-1"; "details-2" ]))

    [<Test>]
    member _.``NavigationStack push pop replace and deep link semantics are deterministic``() =
        let root = Route.create "home" "home"

        let stack =
            NavigationStack.create(root)
            |> NavigationStack.push(Route.create "list" "list")
            |> NavigationStack.replaceTop(Route.create "details" "details")

        Assert.That(stack.Routes |> List.map _.Id, Is.EqualTo([ "home"; "details" ]))
        Assert.That(stack |> NavigationStack.pop |> NavigationStack.current, Is.EqualTo(root))
        Assert.That(NavigationStack.create(root) |> NavigationStack.pop |> NavigationStack.current, Is.EqualTo(root))

        let deepLink =
            stack
            |> NavigationStack.replacePath [ Route.create "home-link" "home"; Route.create "details-link" "details" ]

        Assert.That(deepLink.Routes |> List.map _.Id, Is.EqualTo([ "home-link"; "details-link" ]))

    [<Test>]
    member _.``NavigationStack updates route state by instance identity``() =
        let stack =
            NavigationStack.create(Route.create "counter-1" 0)
            |> NavigationStack.push(Route.create "counter-2" 10)

        let updated = stack |> NavigationStack.tryUpdate "counter-1" ((+) 1) |> Option.get

        Assert.That(updated.Routes |> List.map _.Value, Is.EqualTo([ 1; 10 ]))
        Assert.That(stack |> NavigationStack.tryUpdate "missing" ((+) 1), Is.EqualTo(None))

    [<Test>]
    member _.``NavigationStack rejects empty paths and duplicate route identities``() =
        Assert.Throws<ArgumentException>(fun () -> NavigationStack.ofRoutes [] |> ignore)
        |> ignore

        Assert.Throws<ArgumentException>(fun () ->
            NavigationStack.ofRoutes [ Route.create "same" 1; Route.create "same" 2 ]
            |> ignore)
        |> ignore

    [<Test>]
    member _.``View map composes a child page inside NavigationPage``() =
        let childPage: WidgetBuilder<string, IFabContentPage> = ContentPage(Label("Child"))

        let navigationPage = NavigationPage() { View.map Some childPage }

        Assert.DoesNotThrow(fun () -> navigationPage.Compile() |> ignore)

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
