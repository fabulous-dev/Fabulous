namespace Fabulous.XamarinForms

open Fabulous

[<AutoOpen>]
module InputTypes =
    
    /// Represents a dimension for either the row or column definition of a Grid
    type Dimension =
        /// Use a size that fits the children of the row or column.
        | Auto
        /// Use a proportional size of 1
        | Star
        /// Use a proportional size defined by the associated value
        | Stars of float
        /// Use the associated value as the number of device-specific units.
        | Absolute of float