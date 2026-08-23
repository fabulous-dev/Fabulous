namespace TestableApp

open System
open System.IO
open Avalonia.Controls
open Avalonia.Headless
open Avalonia.Headless.XUnit
open Avalonia.Input
open Fabulous
open Fabulous.Avalonia
open Xunit

open type Fabulous.Avalonia.View

module FabTests =
    let saveScreenshot (name: string) (window: Window) =
        match Environment.GetEnvironmentVariable("FABULOUS_SCREENSHOT_DIR") with
        | null
        | "" -> ()
        | directory ->
            Directory.CreateDirectory(directory) |> ignore

            use bitmap = window.CaptureRenderedFrame()
            Assert.NotNull(bitmap)

            use stream = File.Create(Path.Combine(directory, $"{name}.png"))
            bitmap.Save(stream)

    /// It takes the root of the widget tree and create the corresponding Avalonia node, and recursively creating all children nodes
    let mkView<'a> (root: Widget) : 'a =
        let definition = WidgetDefinitionStore.get root.Key
        let logger = ProgramDefaults.defaultLogger()

        let treeContext =
            { CanReuseView = ViewHelpers.canReuseView
              GetViewNode = ViewNode.get
              GetComponent = Component.get
              SetComponent = Component.set
              SyncAction = ViewHelpers.defaultSyncAction
              Logger = logger
              Dispatch = ignore }

        let envContext = new EnvironmentContext(logger)

        let struct (_, view) =
            definition.CreateView(root, envContext, treeContext, ValueNone)

        view |> unbox

    [<AvaloniaFact>]
    let ``Should increment counter`` () =
        let window = App.view().Compile() |> mkView<Window>
        window.Show()

        let content = window.Content :?> ReversibleStackPanel |> _.Children
        let counter = content[0] :?> TextBlock
        let incrementButton = content[1] :?> Button

        Assert.Equal("0", counter.Text)

        incrementButton.Focus() |> ignore

        window.KeyPressQwerty(PhysicalKey.Enter, RawInputModifiers.None)

        Assert.Equal("1", counter.Text)

    [<AvaloniaFact>]
    let ``Should decrement counter`` () =
        let window = App.view().Compile() |> mkView<Window>

        window.Show()

        let content = window.Content :?> ReversibleStackPanel |> _.Children

        let counter = content[0] :?> TextBlock
        let decrementButton = content[2] :?> Button

        Assert.Equal("0", counter.Text)

        decrementButton.Focus() |> ignore

        window.KeyPressQwerty(PhysicalKey.Enter, RawInputModifiers.None)

        Assert.Equal("-1", counter.Text)

    [<AvaloniaFact>]
    let ``Should reset counter`` () =
        let window = App.view().Compile() |> mkView<Window>

        window.Show()

        let content = window.Content :?> ReversibleStackPanel |> _.Children

        let counter = content[0] :?> TextBlock
        let incrementButton = content[1] :?> Button

        incrementButton.Focus() |> ignore
        window.KeyPressQwerty(PhysicalKey.Enter, RawInputModifiers.None)
        Assert.Equal("1", counter.Text)

        let resetButton = content[5] :?> Button
        resetButton.Focus() |> ignore
        window.KeyPressQwerty(PhysicalKey.Enter, RawInputModifiers.None)

        Assert.Equal("0", counter.Text)

    [<AvaloniaFact>]
    let ``Should render counter screenshot`` () =
        let window = App.view().Compile() |> mkView<Window>
        window.Width <- 420.
        window.Height <- 360.
        window.Show()

        saveScreenshot "avalonia-counter" window
