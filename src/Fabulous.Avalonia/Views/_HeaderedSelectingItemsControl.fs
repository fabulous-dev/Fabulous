namespace Fabulous.Avalonia

open Avalonia.Controls.Primitives
open Fabulous

type IFabHeaderedSelectingItemsControl =
    inherit IFabSelectingItemsControl

module HeaderedSelectingItemsControl =
    let HeaderString =
        Attributes.defineAvaloniaProperty<string, obj> HeaderedContentControl.HeaderProperty box ScalarAttributeComparers.equalityCompare

    let HeaderWidget =
        Attributes.defineAvaloniaPropertyWidget HeaderedContentControl.HeaderProperty
