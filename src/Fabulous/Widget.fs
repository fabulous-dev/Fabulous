namespace Fabulous

type Attribute =
    { Name: string
      Value: obj }

type Key = struct end
type StateKey = struct end

/// Base logical element
type IWidget =
    abstract Key: Key option

/// Logical element able to instantiate a real UI type
type StaticWidget =
    { Key: Key option
      Attributes: Attribute[]
      Create: unit -> obj }
    interface IWidget with
        member x.Key = x.Key

/// Logical element without state able to generate a logical tree composed of child widgets
type StatelessWidget =
    { Key: Key option
      View: Attribute[] -> IWidget
      ExtendedAttributes: Attribute[] voption }
    interface IWidget with
        member x.Key = x.Key

/// Logical element with MVU state able to generate a logical tree composed of child widgets
type StatefulWidget =
    { Key: Key option
      State: StateKey option
      Init: obj -> obj
      Update: obj * obj -> obj
      View: obj * Attribute[] -> IWidget }
    interface IWidget with
        member x.Key = x.Key

// Runner is created for the widget itself. No point in reusing a runner for another widget
type Runner(widget: StatefulWidget) =
    member x.State = StateKey()
    member x.Start() = ()
    member x.Pause() = ()
    member x.Restart() = ()
    member x.Stop() = ()