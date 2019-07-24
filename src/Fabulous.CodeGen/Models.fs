// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.CodeGen

module Models =
    /// Reader models
    type EventReaderData = {
        Name: string
        Type: string
        EventArgsType: string
    }
    
    type AttachedPropertyReaderData = {
        Name: string
        Type: string
        DefaultValue: string
    }
    
    type PropertyReaderData = {
        Name: string
        Type: string
        DefaultValue: string
    }
    
    type TypeReaderData = {
        Name: string
        Events: EventReaderData array
        AttachedProperties: AttachedPropertyReaderData array
        Properties: PropertyReaderData array
    }
    
    /// Overwrite models
    type AttachedPropertyOverwriteData =
        { Position: int option
          Source: string option
          TargetType: string }
        
    type PropertyOverwriteData =
        { Position: int option
          Source: string option
          Name: string option
          ShortName: string option
          UniqueName: string option
          DefaultValue: string option
          InputType: string option
          ModelType: string option
          ConvertInputToModel: string option
          ConvertModelToValue: string option }
        
    type EventOverwriteData =
        { Position: int option
          Source: string option
          Name: string option
          ShortName: string option
          UniqueName: string option
          Type: string option
          EventArgsType: string option }
    
    type TypeOverwriteData() =
        member val Name: string = "" with get, set
        member val CustomType: string option = None with get, set
        member val Events: EventOverwriteData array = [||] with get, set
        member val Properties: PropertyOverwriteData array = [||] with get, set
        member val AttachedProperties: AttachedPropertyOverwriteData array = [||] with get, set
    
    type OverwriteData() =
        member val Assemblies: string array = [||] with get, set
        member val OutputNamespace: string = "" with get, set
        member val Types: TypeOverwriteData array = [||] with get, set
        
    /// Binding models    
    type AttachedPropertyBinding = {
        Name: string
        ShortName: string
        UniqueName: string
        DefaultValue: string
        InputType: string
        ModelType: string
        ConvertInputToModel: string
        ConvertModelToValue: string
    }
    
    type PropertyBinding = {
        Name: string
        ShortName: string
        UniqueName: string
        DefaultValue: string
        InputType: string
        ModelType: string
        ConvertInputToModel: string
        ConvertModelToValue: string
    }
    
    type EventBinding = {
        Name: string
        ShortName: string
        UniqueName: string
        Type: string
        EventArgsType: string
    }
    
    type TypeBinding = {
        Name: string
        CustomType: string option
        Properties: PropertyBinding array
    }
    
    type Bindings = {
        Assemblies: string array
        OutputNamespace: string
        Types: TypeBinding array
    }