namespace Fabulous

[<Struct>]
type FabColor =
    { RGBA: int32 }
    member inline x.R: uint8 =
        (x.RGBA &&& 0xFF000000) >>> 24 |> uint8

    member inline x.G: uint8 =
        (x.RGBA &&& 0x00FF0000) >>> 16 |> uint8

    member inline x.B: uint8 =
        (x.RGBA &&& 0x0000FF00) >>> 8 |> uint8

    member inline x.A: uint8 =
        x.RGBA &&& 0x000000FF |> uint8

module FabColor =
    let inline fromHex (rgba: int32) : FabColor = { RGBA = rgba }

    let inline fromRGBA (r: uint8) (g: uint8) (b: uint8) (a: uint8) : FabColor =
        { RGBA =
            ((int32(r) <<< 24)
             ||| (int32(g) <<< 16)
             ||| (int32(b) <<< 8)
             ||| int32(a)) }
