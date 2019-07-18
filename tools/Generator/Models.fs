namespace Fabulous.Generator

module Models =
    type EventBinding = {
        Name: string
        Type: string
        EventArgsType: string
    }
    
    type AttachedPropertyBinding = {
        Name: string
        Type: string
        DefaultValue: string
    }
    
    type PropertyBinding = {
        Name: string
        Type: string
        DefaultValue: string
    }
    
    type TypeBinding = {
        Name: string
        Events: EventBinding array
        AttachedProperties: AttachedPropertyBinding array
        Properties: PropertyBinding array
    }