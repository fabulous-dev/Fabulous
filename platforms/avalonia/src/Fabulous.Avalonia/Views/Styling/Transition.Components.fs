namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Avalonia

type ComponentTransitionCollectionModifiers =
    /// <summary>Sets the Transitions property.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline transition(this: WidgetBuilder<'msg, IFabAnimatable>) =
        AttributeCollectionBuilder<'msg, IFabAnimatable, IFabTransition>(this, Animatable.Transitions)

    /// <summary>Sets the Transition property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Transition value.</param>
    [<Extension>]
    static member inline transition(this: WidgetBuilder<'msg, IFabAnimatable>, value: WidgetBuilder<'msg, IFabTransition>) =
        ComponentTransitionCollectionModifiers.transition(this) { value }
