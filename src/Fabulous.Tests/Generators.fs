namespace Fabulous.Tests

open FsCheck
open NUnit.Framework

type IntTypedEnum =
    | One = 1
    | Two = 2
    | Three = 3
    | Four = 4
    | Five = 5
    | Six = 6

module SmallScalarGenerators =
    let intTypedEnum =
        gen {
            return!
                Gen.elements
                    [ IntTypedEnum.One
                      IntTypedEnum.Two
                      IntTypedEnum.Three
                      IntTypedEnum.Four
                      IntTypedEnum.Five
                      IntTypedEnum.Five
                      IntTypedEnum.Six ]
        }

type Generators =
    static member IntTypedEnum() =
        { new Arbitrary<IntTypedEnum>() with
            member this.Generator = SmallScalarGenerators.intTypedEnum }

[<SetUpFixture>]
type Setup() =
    [<OneTimeSetUp>]
    member _.Setup() = do Arb.register<Generators>() |> ignore
