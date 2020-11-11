namespace AllControls

open Fabulous

module ViewOnlySample =
    type Msg = Nothing
    type CmdMsg = Nothing
    type ExternalMsg = Nothing
    type Model = Nothing

    let mapToCmd (_: CmdMsg) : Cmd<Msg> =
        Cmd.none

    let init () = Nothing, []

    let update _ _ = Nothing, [], None

