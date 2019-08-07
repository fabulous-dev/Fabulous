// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.CodeGen

module Models =
    type IMember =
        /// Indicates the source property/event name as found by the Assembly Reader to include (and override if needed)
        /// If none is provided, the generator will consider it's a non-existent property and other fields will be mandatory
        abstract member Source : string option with get
        
        /// The name to use (e.g. ItemsSource => Items)
        abstract member Name : string option with get
        
        /// The unique identifier of the member to use inside the generated code (e.g. Text => ButtonText)
        /// If a Name is provided, the ShortName will be automatically determined from it
        abstract member UniqueName : string option with get
        
        /// The type which the user should provide for the member
        abstract member InputType : string option with get
        
        /// The type as which the member's value will be stored in the ViewElement
        /// If the InputType is an F# List, the ModelType will automatically set to an array
        abstract member ModelType : string option with get
        
        /// The function that converts the input value to the model type
        /// If the InputType is an F# List, the convert function will automatically be Array.ofList
        abstract member ConvertInputToModel : string option with get

    type IConstructorMember =  
        /// The name of the member in the constructor, should be in a lower camel case (e.g. ItemsSource => items | View.ListView(items=...))
        /// If a Name is provided, the ShortName will be automatically determined from it
        abstract member ShortName : string option with get

    type IProperty =
        /// The type of the elements if the property is a collection
        abstract member ElementType : string option with get
        
        /// The function that converts the model value to the actual type expected by the property
        abstract member ConvertModelToValue : string option with get
        
        /// The function that will handle the update process for this property
        /// Completely replace the code generated for this property in Update*ControlType*
        abstract member UpdateCode : string option with get

    type Property =
        { Source: string option
          Name: string option
          ShortName: string option
          UniqueName: string option
          DefaultValue: string option
          ElementType: string option
          InputType: string option
          ModelType: string option
          ConvertInputToModel: string option
          ConvertModelToValue: string option
          UpdateCode: string option }
        interface IMember with
            member x.Source = x.Source
            member x.Name = x.Name
            member x.UniqueName = x.UniqueName
            member x.InputType = x.InputType
            member x.ModelType = x.ModelType
            member x.ConvertInputToModel = x.ConvertInputToModel
        interface IConstructorMember with
            member x.ShortName = x.ShortName
        interface IProperty with
            member x.ElementType = x.ElementType
            member x.ConvertModelToValue = x.ConvertModelToValue
            member x.UpdateCode = x.UpdateCode

    type Event =
        { Source: string option
          Name: string option
          ShortName: string option
          UniqueName: string option
          InputType: string option
          ModelType: string option
          ConvertInputToModel: string option
          RelatedProperties: string[] option }
        interface IMember with
            member x.Source = x.Source
            member x.Name = x.Name
            member x.UniqueName = x.UniqueName
            member x.InputType = x.InputType
            member x.ModelType = x.ModelType
            member x.ConvertInputToModel = x.ConvertInputToModel
        interface IConstructorMember with
            member x.ShortName = x.ShortName
        
    type AttachedProperty =
        { Source: string option
          TargetType: string option
          Name: string option
          UniqueName: string option
          DefaultValue: string option
          ElementType: string option
          InputType: string option
          ModelType: string option
          ConvertInputToModel: string option
          ConvertModelToValue: string option
          UpdateCode: string option }
        interface IMember with
            member x.Source = x.Source
            member x.Name = x.Name
            member x.UniqueName = x.UniqueName
            member x.InputType = x.InputType
            member x.ModelType = x.ModelType
            member x.ConvertInputToModel = x.ConvertInputToModel
        interface IProperty with
            member x.ElementType = x.ElementType
            member x.ConvertModelToValue = x.ConvertModelToValue
            member x.UpdateCode = x.UpdateCode
    
    type Type =
        { /// The full name of the type to include (e.g. Xamarin.Forms.Button)
          Type: string
          
          /// The full name of the type to instantiate (e.g. Fabulous.XamarinForms.CustomButton)
          CustomType: string option

          /// The name of the type as used inside Fabulous (e.g. MyWonderfulButton => View.MyWonderfulButton(...))
          Name: string option
          
          /// The events to include/create/override for this type
          Events: Event[] option
          
          /// The properties to include/create/override for this type
          Properties: Property[] option
          
          /// The attached properties to include/create/override for this type
          AttachedProperties: AttachedProperty[] option
          
          /// An ordered list of all direct members (events and properties, not attached properties) to determine the order of the constructor (e.g. ["Text", "TextChanged", "Font"] => View.Entry(text=..., textChanged=..., font=...)
          /// Values must be Name
          /// Can order inherited members
          ConstructorMemberOrdering: string[] option }
    
    type OverwriteData =
        { /// Assemblies to read (can be relative paths to dlls)
          Assemblies: string[]
          
          /// The namespace under which all the generated code will be put
          OutputNamespace: string
          
          /// The base type that will get all the attached properties (e.g. Xamarin.Forms.Element)
          BaseAttachedPropertyTargetType: string
          
          /// The types to include in the generated code
          Types: Type[] }