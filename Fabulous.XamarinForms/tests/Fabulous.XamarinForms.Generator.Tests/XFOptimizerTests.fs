namespace Fabulous.XamarinForms.Generator.Tests

open Fabulous.CodeGen.Binder.Models
open Fabulous.XamarinForms.Generator
open NUnit.Framework
open FsUnit
open XFOptimizer

module XFOptimizerTests =
    let createBoundModelWithProperties properties =
        { Assemblies = [||]
          OutputNamespace = "OutputNamespace"
          AdditionalNamespaces = [||]
          Types =
              [| { Id = "Id"
                   FullName = "FullName"
                   ShouldGenerateBinding = true
                   GenericConstraint = None
                   CanBeInstantiated = true
                   TypeToInstantiate = "TypeToInstantiate"
                   BaseTypeName = None
                   BaseGenericConstraint = None
                   Name = "Name"
                   Events = [||]
                   CreateCode = None
                   PrimaryConstructorMembers = None
                   Properties = properties } |] }

    [<Test>]
    let ``Given a System.Windows.Input.ICommand property with no customization, OptimizeCommands should return 1 Execute property and 1 CanExecute property``() =
        let boundModel =
            createBoundModelWithProperties
                [| { Name = "Name"
                     ShortName = "ShortName"
                     UniqueName = "UniqueName"
                     CanBeUpdated = true
                     CustomAttributeKey = None
                     DefaultValue = "DefaultValue"
                     OriginalType = "OriginalType"
                     InputType = "System.Windows.Input.ICommand"
                     ModelType = "System.Windows.Input.ICommand"
                     ConvertInputToModel = ""
                     ConvertModelToValue = ""
                     UpdateCode = ""
                     CollectionData = None
                     HasPriority = false
                     IsInherited = false
                     UnmountCode = "" } |]

        let expectedBoundModel =
            createBoundModelWithProperties
                [| { Name = "Name"
                     ShortName = "ShortName"
                     UniqueName = "UniqueName"
                     CanBeUpdated = true
                     CustomAttributeKey = None
                     DefaultValue = "DefaultValue"
                     OriginalType = "OriginalType"
                     InputType = "unit -> unit"
                     ModelType = "unit -> unit"
                     ConvertInputToModel = ""
                     ConvertModelToValue = ""
                     UpdateCode = "(fun _ _ _ _ -> ())"
                     CollectionData = None
                     HasPriority = false
                     IsInherited = false
                     UnmountCode = "" }

                   { Name = "NameCanExecute"
                     ShortName = "ShortNameCanExecute"
                     UniqueName = "UniqueNameCanExecute"
                     CanBeUpdated = true
                     CustomAttributeKey = None
                     DefaultValue = "true"
                     OriginalType = "bool"
                     InputType = "bool"
                     ModelType = "bool"
                     ConvertInputToModel = ""
                     ConvertModelToValue = ""
                     UpdateCode = "ViewUpdaters.updateCommand prevUniqueNameOpt currUniqueNameOpt (fun _target -> ()) (fun (target: FullName) cmd -> target.Name <- cmd)"
                     CollectionData = None
                     HasPriority = false
                     IsInherited = false
                     UnmountCode = "" } |]

        boundModel |> OptimizeCommands.apply |> should equal expectedBoundModel

    [<Test>]
    let ``Given a System.Windows.Input.ICommand property with custom convert input type to model type, OptimizeCommands should not optimize property``() =
        let boundModel =
            createBoundModelWithProperties
                [| { Name = "Name"
                     ShortName = "ShortName"
                     UniqueName = "UniqueName"
                     CanBeUpdated = true
                     CustomAttributeKey = None
                     DefaultValue = "DefaultValue"
                     OriginalType = "OriginalType"
                     InputType = "CustomImageType"
                     ModelType = "System.Windows.Input.ICommand"
                     ConvertInputToModel = "ViewConverters.convertCustomImageTypeToImageSource"
                     ConvertModelToValue = ""
                     UpdateCode = ""
                     CollectionData = None
                     HasPriority = false
                     IsInherited = false
                     UnmountCode = "" } |]

        let expectedBoundModel = boundModel

        boundModel |> OptimizeCommands.apply |> should equal expectedBoundModel

    [<Test>]
    let ``Given a System.Windows.Input.ICommand property with custom update code, OptimizeCommands should not optimize property``() =
        let boundModel =
            createBoundModelWithProperties
                [| { Name = "Name"
                     ShortName = "ShortName"
                     UniqueName = "UniqueName"
                     CanBeUpdated = true
                     CustomAttributeKey = None
                     DefaultValue = "DefaultValue"
                     OriginalType = "OriginalType"
                     InputType = "System.Windows.Input.ICommand"
                     ModelType = "System.Windows.Input.ICommand"
                     ConvertInputToModel = ""
                     ConvertModelToValue = ""
                     UpdateCode = "ViewUpdaters.updateNameProperty"
                     CollectionData = None
                     HasPriority = false
                     IsInherited = false
                     UnmountCode = "" } |]

        let expectedBoundModel = boundModel

        boundModel |> OptimizeCommands.apply |> should equal expectedBoundModel

    [<Test>]
    let ``Given a non-command property, OptimizeCommands should not optimize property``() =
        let boundModel =
            createBoundModelWithProperties
                [| { Name = "Name"
                     ShortName = "ShortName"
                     UniqueName = "UniqueName"
                     CanBeUpdated = true
                     CustomAttributeKey = None
                     DefaultValue = "DefaultValue"
                     OriginalType = "OriginalType"
                     InputType = "int"
                     ModelType = "int"
                     ConvertInputToModel = ""
                     ConvertModelToValue = ""
                     UpdateCode = ""
                     CollectionData = None
                     HasPriority = false
                     IsInherited = false
                     UnmountCode = "" } |]

        let expectedBoundModel = boundModel

        boundModel |> OptimizeCommands.apply |> should equal expectedBoundModel

    [<Test>]
    let ``Given a Xamarin.Forms.ImageSource property with no customization, OptimizeImageSource should return a Fabulous.XamarinForms.InputTypes.Image property``() =
        let boundModel =
            createBoundModelWithProperties
                [| { Name = "Name"
                     ShortName = "ShortName"
                     UniqueName = "UniqueName"
                     CanBeUpdated = true
                     CustomAttributeKey = None
                     DefaultValue = "DefaultValue"
                     OriginalType = "OriginalType"
                     InputType = "Xamarin.Forms.ImageSource"
                     ModelType = "Xamarin.Forms.ImageSource"
                     ConvertInputToModel = ""
                     ConvertModelToValue = ""
                     UpdateCode = ""
                     CollectionData = None
                     HasPriority = false
                     IsInherited = false
                     UnmountCode = "" } |]

        let expectedBoundModel =
            createBoundModelWithProperties
                [| { Name = "Name"
                     ShortName = "ShortName"
                     UniqueName = "UniqueName"
                     CanBeUpdated = true
                     CustomAttributeKey = None
                     DefaultValue = "DefaultValue"
                     OriginalType = "OriginalType"
                     InputType = "Fabulous.XamarinForms.InputTypes.Image.Value"
                     ModelType = "Fabulous.XamarinForms.InputTypes.Image.Value"
                     ConvertInputToModel = ""
                     ConvertModelToValue = "ViewConverters.convertFabulousImageToXamarinFormsImageSource"
                     UpdateCode = ""
                     CollectionData = None
                     HasPriority = false
                     IsInherited = false
                     UnmountCode = "" } |]

        boundModel |> OptimizeImageSource.apply |> should equal expectedBoundModel

    [<Test>]
    let ``Given a Xamarin.Forms.ImageSource property with custom convert input type to model type, OptimizeImageSource should not optimize property``() =
        let boundModel =
            createBoundModelWithProperties
                [| { Name = "Name"
                     ShortName = "ShortName"
                     UniqueName = "UniqueName"
                     CanBeUpdated = true
                     CustomAttributeKey = None
                     DefaultValue = "DefaultValue"
                     OriginalType = "OriginalType"
                     InputType = "CustomImageType"
                     ModelType = "Xamarin.Forms.ImageSource"
                     ConvertInputToModel = "ViewConverters.convertCustomImageTypeToImageSource"
                     ConvertModelToValue = ""
                     UpdateCode = ""
                     CollectionData = None
                     HasPriority = false
                     IsInherited = false
                     UnmountCode = "" } |]

        let expectedBoundModel = boundModel

        boundModel |> OptimizeImageSource.apply |> should equal expectedBoundModel

    [<Test>]
    let ``Given a Xamarin.Forms.ImageSource property with custom update code, OptimizeImageSource should not optimize property``() =
        let boundModel =
            createBoundModelWithProperties
                [| { Name = "Name"
                     ShortName = "ShortName"
                     UniqueName = "UniqueName"
                     CanBeUpdated = true
                     CustomAttributeKey = None
                     DefaultValue = "DefaultValue"
                     OriginalType = "OriginalType"
                     InputType = "Xamarin.Forms.ImageSource"
                     ModelType = "Xamarin.Forms.ImageSource"
                     ConvertInputToModel = ""
                     ConvertModelToValue = ""
                     UpdateCode = "ViewUpdaters.updateNameProperty"
                     CollectionData = None
                     HasPriority = false
                     IsInherited = false
                     UnmountCode = "" } |]

        let expectedBoundModel = boundModel

        boundModel |> OptimizeImageSource.apply |> should equal expectedBoundModel

    [<Test>]
    let ``Given a non-image property, OptimizeImageSource should not optimize property``() =
        let boundModel =
            createBoundModelWithProperties
                [| { Name = "Name"
                     ShortName = "ShortName"
                     UniqueName = "UniqueName"
                     CanBeUpdated = true
                     CustomAttributeKey = None
                     DefaultValue = "DefaultValue"
                     OriginalType = "OriginalType"
                     InputType = "int"
                     ModelType = "int"
                     ConvertInputToModel = ""
                     ConvertModelToValue = ""
                     UpdateCode = ""
                     CollectionData = None
                     HasPriority = false
                     IsInherited = false
                     UnmountCode = "" } |]

        let expectedBoundModel = boundModel

        boundModel |> OptimizeImageSource.apply |> should equal expectedBoundModel

    [<Test>]
    let ``Given a Xamarin.Forms.MediaSource property with no customization, OptimizeMediaSource should return a Fabulous.XamarinForms.InputTypes.Media property``() =
        let boundModel =
            createBoundModelWithProperties
                [| { Name = "Name"
                     ShortName = "ShortName"
                     UniqueName = "UniqueName"
                     CanBeUpdated = true
                     CustomAttributeKey = None
                     DefaultValue = "DefaultValue"
                     OriginalType = "OriginalType"
                     InputType = "Xamarin.Forms.MediaSource"
                     ModelType = "Xamarin.Forms.MediaSource"
                     ConvertInputToModel = ""
                     ConvertModelToValue = ""
                     UpdateCode = ""
                     CollectionData = None
                     HasPriority = false
                     IsInherited = false
                     UnmountCode = "" } |]

        let expectedBoundModel =
            createBoundModelWithProperties
                [| { Name = "Name"
                     ShortName = "ShortName"
                     UniqueName = "UniqueName"
                     CanBeUpdated = true
                     CustomAttributeKey = None
                     DefaultValue = "DefaultValue"
                     OriginalType = "OriginalType"
                     InputType = "Fabulous.XamarinForms.InputTypes.Media.Value"
                     ModelType = "Fabulous.XamarinForms.InputTypes.Media.Value"
                     ConvertInputToModel = ""
                     ConvertModelToValue = "ViewConverters.convertFabulousMediaToXamarinFormsMediaSource"
                     UpdateCode = ""
                     CollectionData = None
                     HasPriority = false
                     IsInherited = false
                     UnmountCode = "" } |]

        boundModel |> OptimizeMediaSource.apply |> should equal expectedBoundModel

    [<Test>]
    let ``Given a Xamarin.Forms.MediaSource property with custom convert input type to model type, OptimizeMediaSource should not optimize property``() =
        let boundModel =
            createBoundModelWithProperties
                [| { Name = "Name"
                     ShortName = "ShortName"
                     UniqueName = "UniqueName"
                     CanBeUpdated = true
                     CustomAttributeKey = None
                     DefaultValue = "DefaultValue"
                     OriginalType = "OriginalType"
                     InputType = "CustomMediaType"
                     ModelType = "Xamarin.Forms.MediaSource"
                     ConvertInputToModel = "ViewConverters.convertCustomMediaTypeToMediaSource"
                     ConvertModelToValue = ""
                     UpdateCode = ""
                     CollectionData = None
                     HasPriority = false
                     IsInherited = false
                     UnmountCode = "" } |]

        let expectedBoundModel = boundModel

        boundModel |> OptimizeMediaSource.apply |> should equal expectedBoundModel

    [<Test>]
    let ``Given a Xamarin.Forms.MediaSource property with custom update code, OptimizeMediaSource should not optimize property``() =
        let boundModel =
            createBoundModelWithProperties
                [| { Name = "Name"
                     ShortName = "ShortName"
                     UniqueName = "UniqueName"
                     CanBeUpdated = true
                     CustomAttributeKey = None
                     DefaultValue = "DefaultValue"
                     OriginalType = "OriginalType"
                     InputType = "Xamarin.Forms.MediaSource"
                     ModelType = "Xamarin.Forms.MediaSource"
                     ConvertInputToModel = ""
                     ConvertModelToValue = ""
                     UpdateCode = "ViewUpdaters.updateNameProperty"
                     CollectionData = None
                     HasPriority = false
                     IsInherited = false
                     UnmountCode = "" } |]

        let expectedBoundModel = boundModel

        boundModel |> OptimizeMediaSource.apply |> should equal expectedBoundModel

    [<Test>]
    let ``Given a non-media property, OptimizeMediaSource should not optimize property``() =
        let boundModel =
            createBoundModelWithProperties
                [| { Name = "Name"
                     ShortName = "ShortName"
                     UniqueName = "UniqueName"
                     CanBeUpdated = true
                     CustomAttributeKey = None
                     DefaultValue = "DefaultValue"
                     OriginalType = "OriginalType"
                     InputType = "int"
                     ModelType = "int"
                     ConvertInputToModel = ""
                     ConvertModelToValue = ""
                     UpdateCode = ""
                     CollectionData = None
                     HasPriority = false
                     IsInherited = false
                     UnmountCode = "" } |]

        let expectedBoundModel = boundModel

        boundModel |> OptimizeMediaSource.apply |> should equal expectedBoundModel
