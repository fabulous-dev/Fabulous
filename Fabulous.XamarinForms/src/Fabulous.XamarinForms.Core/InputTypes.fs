namespace Fabulous.XamarinForms

[<AutoOpen>]
module InputTypes =
    /// Represents an image source
    type Image =
        /// Use a path (URL, UNC) as the image source
        | Path of string
        /// Use a byte array representing the image
        | Bytes of byte[]
        /// Use an already defined ImageSource
        | Source of Xamarin.Forms.ImageSource
    
    /// Represents a dimension for either the row or column definition of a Grid    
    type Dimension =
        /// Choose a size that fits the children of the row or column.
        | Auto
        /// Use a proportional size of 1
        | Star
        /// Use a proportional size defined by the associated value
        | Stars of float
        /// Use the associated value as the number of device-specific units.
        | Absolute of float
        
    /// Represents a font size
    type FontSize =
        /// Use a named size
        | Named of Xamarin.Forms.NamedSize
        /// Use a value as the size
        | FontSize of float