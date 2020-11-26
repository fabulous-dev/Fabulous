namespace AllControls.Samples

open Fabulous
open Fabulous.XamarinForms

module TestLabel =
    /// Test the extension API be making a 2nd wrapper for "Label":
    let TestLabelTextAttribKey = AttributeKey<_> "TestLabel_Text"
    let TestLabelFontFamilyAttribKey = AttributeKey<_> "TestLabel_FontFamily"

    type Fabulous.XamarinForms.View with

        static member inline TestLabel(?text: string, ?fontFamily: string, ?backgroundColor, ?rotation) = 

            let attribs = ViewBuilders.BuildView(?backgroundColor = backgroundColor, ?rotation = rotation)

            match text with None -> () | Some v -> attribs.Add(TestLabelTextAttribKey, v)
            match fontFamily with None -> () | Some v -> attribs.Add(TestLabelFontFamilyAttribKey, v)

            let create () = Xamarin.Forms.Label()

            let update (definition: ProgramDefinition) (prevOpt: DynamicViewElement voption) (source: DynamicViewElement) (target: Xamarin.Forms.Label) =
                ViewBuilders.UpdateView(definition, prevOpt, source, target)
                source.UpdatePrimitive(definition, prevOpt, target, TestLabelTextAttribKey, (fun target v -> target.Text <- v))
                source.UpdatePrimitive(definition, prevOpt, target, TestLabelFontFamilyAttribKey, (fun target v -> target.FontFamily <- v))

            let updateAttachedProperties propertyKey definition prevOpt source targetChild =
                ViewBuilders.UpdateViewAttachedProperties(propertyKey, definition, prevOpt, source, targetChild)

            let handler =
                Registrar.Register("AllControls.Samples.TestLabel", create, update, updateAttachedProperties)

            DynamicViewElement.Create(handler, attribs)

