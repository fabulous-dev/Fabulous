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
    member _.``Encoding then decoding a FabColor should return an identical FabColor``(value: FabColor) =
        let encoded = SmallScalars.FabColor.encode value
        let decoded = SmallScalars.FabColor.decode encoded

        Assert.AreEqual(value.R, decoded.R)
        Assert.AreEqual(value.G, decoded.G)
        Assert.AreEqual(value.B, decoded.B)
        Assert.AreEqual(value.A, decoded.A)

    [<Property>]
    member _.``Converting to System Color and back should be accurate enough``(value: Color) =
        let encoded = value.ToFabColor()
        let decoded = encoded.ToXFColor()

        // We lose a bit of accuracy when encoding/decoding colors, so we account for that by comparing only on 8 bits
        // Because of a rounding loss, we can't be sure that the values are equal, so we'll just check that they're close by 1 bit
        let assertAsU8 (expected: float) (actual: float) =
            let expectedU8 = uint8(expected * 255.0)
            let actualU8 = uint8(actual * 255.0)

            let lowerBound =
                if expectedU8 = 0uy then
                    0uy
                else
                    expectedU8 - 1uy

            Assert.GreaterOrEqual(actualU8, lowerBound)
            Assert.LessOrEqual(actualU8, expectedU8)

        assertAsU8 value.R decoded.R
        assertAsU8 value.G decoded.G
        assertAsU8 value.B decoded.B
        assertAsU8 value.A decoded.A
