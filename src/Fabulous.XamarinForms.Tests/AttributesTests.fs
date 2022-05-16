namespace Fabulous.XamarinForms.Tests

open Fabulous.XamarinForms
open FsCheck
open NUnit.Framework
open FsCheck.NUnit
open Xamarin.Forms

[<TestFixture>]
type ``Small scalar encode tests``() =
    [<Property>]
    member _.``Encoding then decoding a LayoutOptions should return an identical LayoutOptions``(value: LayoutOptions) =
        let encoded = SmallScalars.LayoutOptions.encode value

        let decoded =
            SmallScalars.LayoutOptions.decode encoded

        Assert.AreEqual(value.Alignment, decoded.Alignment)
        Assert.AreEqual(value.Expands, decoded.Expands)

    [<Property>]
    member _.``Encoding then decoding a Color should return an identical Color``(value: Color) =
        let encoded = SmallScalars.Color.encode value
        let decoded = SmallScalars.Color.decode encoded

        // We lose a bit of accuracy when encoding/decoding colors, so we account for that here
        let assertWithin expected actual =
            Assert.GreaterOrEqual(actual, expected * 0.995)
            Assert.LessOrEqual(actual, expected * 1.005)

        assertWithin value.R decoded.R
        assertWithin value.G decoded.G
        assertWithin value.B decoded.B
        assertWithin value.A decoded.A
