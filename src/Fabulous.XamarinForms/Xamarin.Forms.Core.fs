namespace Fabulous.XamarinForms

open Fabulous

type [<Struct>] Builder<'T when 'T: Builder<'T>>() =
    new(toto: string) = Builder<'T>()