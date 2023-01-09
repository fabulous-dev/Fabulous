namespace Fabulous.Tests

open Fabulous.Tests
open NUnit.Framework
open FsCheck.NUnit
open Fabulous

[<TestFixture>]
type AttributesTests() =
    [<Property>]
    member _.``Encoding then decoding a bool should return an identical bool``(value: bool) =
        let encoded = SmallScalars.Bool.encode value
        let decoded = SmallScalars.Bool.decode encoded
        Assert.AreEqual(value, decoded)

    [<Property>]
    member _.``Encoding then decoding a float should return an identical float``(value: float) =
        let encoded = SmallScalars.Float.encode value
        let decoded = SmallScalars.Float.decode encoded
        Assert.AreEqual(value, decoded)

    [<Property>]
    member _.``Encoding then decoding an int should return an identical int``(value: int) =
        let encoded = SmallScalars.Int.encode value
        let decoded = SmallScalars.Int.decode encoded
        Assert.AreEqual(value, decoded)

    [<Property>]
    member _.``Encoding then decoding an int-typed enum should return an identical int-typed enum``(value: IntTypedEnum) =
        let encoded = SmallScalars.IntEnum.encode value

        let decoded = SmallScalars.IntEnum.decode<IntTypedEnum> encoded

        Assert.AreEqual(value, decoded)
