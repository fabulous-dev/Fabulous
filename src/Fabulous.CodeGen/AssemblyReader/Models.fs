namespace Fabulous.CodeGen.AssemblyReader

module Models =
    type EventReaderData =
        { Name: string
          Type: string
          EventArgsType: string }
    
    type AttachedPropertyReaderData =
        { Name: string
          Type: string
          DefaultValue: string }
    
    type PropertyReaderData =
        { Name: string
          Type: string
          DefaultValue: string }
    
    type TypeReaderData =
        { Name: string
          InheritanceHierarchy: string[]
          Events: EventReaderData array
          AttachedProperties: AttachedPropertyReaderData array
          Properties: PropertyReaderData array }
        
    type ReflectedAttachedPropertyReaderData =
        { Name: string
          Type: string
          DefaultValue: obj }

