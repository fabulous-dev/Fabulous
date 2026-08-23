namespace TestableApp

open Avalonia.Controls
open Avalonia.Headless
open Avalonia.Headless.XUnit
open Avalonia.Input
open Xunit

module AvaloniaTests =
    [<AvaloniaFact>]
    let ``Should add numbers in the calculator`` () =
        // Create a window
        let window = Window()
        let content = StackPanel()
        window.Content <- content

        // Show the window, as it's required to get layout processed:
        window.Show()

        // Set values to the input boxes by simulating text input:
        let firstOperandInput = TextBox()
        content.Children.Add(firstOperandInput)
        firstOperandInput.Focus() |> ignore
        window.KeyTextInput("10")

        // Or directly to the control:
        let secondOperandInput = TextBox()
        content.Children.Add(secondOperandInput)
        secondOperandInput.Focus() |> ignore
        secondOperandInput.Text <- "20"

        let addButton = Button()
        content.Children.Add(addButton)
        // Raise click event on the button:
        addButton.Focus() |> ignore
        window.KeyPressQwerty(PhysicalKey.Enter, RawInputModifiers.None)

        let resultBox = TextBox()
        resultBox.Text <- $"{int firstOperandInput.Text + int secondOperandInput.Text}"

        Assert.Equal("30", resultBox.Text)
