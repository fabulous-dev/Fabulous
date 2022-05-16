namespace Fabulous.XamarinForms.Tests

open Fabulous.XamarinForms
open FsCheck
open NUnit.Framework
open FsCheck.NUnit
open Xamarin.Forms   

[<TestFixture>]
type ``Small scalar encode tests``() =    
    [<Property>]
    member _.``Encoding then decoding a LayoutOptions should return an identical LayoutOptions`` (value: LayoutOptions) =
        let encoded = SmallScalars.LayoutOptions.encode value
        let decoded = SmallScalars.LayoutOptions.decode encoded
        Assert.AreEqual(value.Alignment, decoded.Alignment)
        Assert.AreEqual(value.Expands, decoded.Expands)
    