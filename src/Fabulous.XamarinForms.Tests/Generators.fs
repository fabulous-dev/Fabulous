namespace Fabulous.XamarinForms.Tests

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

type Generators =
    static member LayoutOptions() =
        { new Arbitrary<LayoutOptions>() with
            member this.Generator =
                SmallScalarGenerators.layoutOptionsGenerator }

[<SetUpFixture>]
type Setup() =
    [<OneTimeSetUp>]
    member _.Setup() = do Arb.register<Generators>() |> ignore
