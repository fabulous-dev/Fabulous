// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.XamarinForms

open Fabulous

[<AutoOpen>]
module InputTypes =

    /// Represents a dimension for either the row or column definition of a Grid
    type [<Struct>] Dimension =
        /// Use a size that fits the children of the row or column.
        | Auto
        /// Use a proportional size of 1
        | Star
        /// Use a proportional size defined by the associated value
        | Stars of stars: float
        /// Use the associated value as the number of device-specific units.
        | Absolute of value: float

    /// Defines if the action should be animated or not
    type [<Struct>] AnimationKind =
        | Animated
        | NotAnimated

    /// Defines a scroll request to an item
    type [<Struct>] ScrollToItem =
        { /// Zero-based index of the item to scroll to
          Index: int
          /// Position to use
          Position: Xamarin.Forms.ScrollToPosition
          /// Determines whether the scroll will be animated or not
          Animate: AnimationKind }

    /// Defines a scroll request to an item in a grouped list
    type [<Struct>] ScrollToGroupedItem =
        { /// Zero-based index of the group containing the item to scroll to
          GroupIndex: int
          /// Zero-based index of the item to scroll to
          ItemIndex: int
          /// Position to use
          Position: Xamarin.Forms.ScrollToPosition
          /// Determines whether the scroll will be animated or not
          Animate: AnimationKind }

    /// Represents an image source
    module Image =
        type [<Struct>] Value =
            | ImagePath of path: string
            | ImageBytes of bytes: byte[]
            | ImageStream of stream: System.IO.Stream
            | ImageFont of fontImageSource: Xamarin.Forms.FontImageSource
            | ImageSource of source: Xamarin.Forms.ImageSource

        /// A path to the image file (local or network file)
        let fromPath path = ImagePath path
        /// A byte array representing the image
        let fromBytes bytes = ImageBytes bytes
        /// A data stream representing the image
        let fromStream stream = ImageStream stream
        /// A Font image
        let fromFont fontImageSource = ImageFont fontImageSource
        /// An already defined ImageSource
        let fromImageSource imageSource = ImageSource imageSource

    /// Represents a media source
    module Media =
        type [<Struct>] Value =
            | MediaPath of path: string
            | MediaSource of source: Xamarin.Forms.MediaSource

        /// A path to the media file (local or network file)
        let fromPath path = MediaPath path
        /// An already defined MediaSource
        let fromMediaSource src = MediaSource src

    /// Represents a font size
    module FontSize =
        type Value =
            | NamedSize of Xamarin.Forms.NamedSize
            | Size of float

        /// Use a named size
        let fromNamedSize namedSize = NamedSize namedSize
        /// Use a value as the size
        let fromValue value = Size value

    /// Represents a content that can be defined with several types
    module Content =
        type [<Struct>] Value =
            | String of string: string
            | ViewElement of element: ViewElement

        /// A string used as content
        let fromString str = String str
        /// An element used as content
        let fromElement viewElement = ViewElement viewElement

    module Points =
        type [<Struct>] Value =
            | String of string: string
            | PointsList of points: Xamarin.Forms.Point list

        let fromString str = String str
        let fromList points = PointsList points

    module Figures =
        type [<Struct>] Value =
            | String of string: string
            | FiguresList of figures: Fabulous.ViewElement array

        let fromString str = String str
        let fromList lst = FiguresList (Array.ofList lst)