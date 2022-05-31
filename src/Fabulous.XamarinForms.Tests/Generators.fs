namespace Fabulous.XamarinForms.Tests

open Fabulous.XamarinForms
open FsCheck
open NUnit.Framework
open Xamarin.Forms

module SmallScalarGenerators =
    let layoutOptionsGenerator =
        gen {
            let! layoutAlignment =
                Gen.elements [ LayoutAlignment.Start
                               LayoutAlignment.Center
                               LayoutAlignment.End
                               LayoutAlignment.Fill ]

            let! expands = Arb.generate<bool>
            return LayoutOptions(layoutAlignment, expands)
        }

    let fabcolorGenerator =
        gen {
            let fabcolorGen =
                Arb.generate<uint8>
                |> Gen.where(fun x -> x >= 0uy && x <= 255uy)

            let! red = fabcolorGen
            let! green = fabcolorGen
            let! blue = fabcolorGen
            let! alpha = fabcolorGen
            return FabColor.fromRGBA red green blue alpha
        }

    let colorGenerator =
        gen {
            let colorGen =
                Arb.generate<float>
                |> Gen.where(fun x -> x >= 0.0 && x <= 1.0)

            let! red = colorGen
            let! green = colorGen
            let! blue = colorGen
            let! alpha = colorGen
            return Color(red, green, blue, alpha)
        }

type Generators =
    static member LayoutOptions() =
        { new Arbitrary<LayoutOptions>() with
            member this.Generator =
                SmallScalarGenerators.layoutOptionsGenerator }

    static member Color() =
        { new Arbitrary<Color>() with
            member this.Generator = SmallScalarGenerators.colorGenerator }

[<SetUpFixture>]
type Setup() =
    [<OneTimeSetUp>]
    member _.Setup() = do Arb.register<Generators>() |> ignore
