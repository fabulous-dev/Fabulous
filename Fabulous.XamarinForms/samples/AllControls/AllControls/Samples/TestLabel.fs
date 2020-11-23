namespace AllControls.Samples

open Fabulous
open Fabulous.XamarinForms

module TestLabel = 
    /// Test the extension API be making a 2nd wrapper for "Label":
    let TestLabelTextAttribKey = AttributeKey<_> "TestLabel_Text"
    let TestLabelFontFamilyAttribKey = AttributeKey<_> "TestLabel_FontFamily"

    type Fabulous.XamarinForms.View with 

        static member inline TestLabel(?text: string, ?fontFamily: string, ?backgroundColor, ?rotation) = 

            // Get the attributes for the base element. The number is the expected number of attributes.
            // You can add additional base element attributes here if you like
            let attribCount = 0
            let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match fontFamily with Some _ -> attribCount + 1 | None -> attribCount
            let attribs = ViewBuilders.BuildView(attribCount, ?backgroundColor = backgroundColor, ?rotation = rotation) 

            // Add our own attributes. They must have unique names.
            match text with None -> () | Some v -> attribs.Add(TestLabelTextAttribKey, v) 
            match fontFamily with None -> () | Some v -> attribs.Add(TestLabelFontFamilyAttribKey, v) 

            // The creation method
            let create () = Xamarin.Forms.Label()

            // The incremental update method
            let update (prevOpt: ViewElement voption) (source: ViewElement) (target: Xamarin.Forms.Label) = 
                ViewBuilders.UpdateView(prevOpt, source, target)
                source.UpdatePrimitive(prevOpt, target, TestLabelTextAttribKey, (fun target v -> target.Text <- v))
                source.UpdatePrimitive(prevOpt, target, TestLabelFontFamilyAttribKey, (fun target v -> target.FontFamily <- v))

            let updateAttachedProperties propertyKey prevOpt source targetChild =
                ViewBuilders.UpdateViewAttachedProperties(propertyKey, prevOpt, source, targetChild)

            ViewElement.Create<Xamarin.Forms.Label>(create, update, updateAttachedProperties, attribs)

