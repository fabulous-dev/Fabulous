namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Automation
open Avalonia.Automation.Peers
open Fabulous

module AutomationProperties =
    let AcceleratorKey =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.AcceleratorKeyProperty

    let AccessibilityView =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.AccessibilityViewProperty

    let AccessKey =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.AccessKeyProperty

    let AutomationId =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.AutomationIdProperty

    let ControlTypeOverride =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.ControlTypeOverrideProperty

    let HelpText =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.HelpTextProperty

    let IsIsColumnHeader =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.IsColumnHeaderProperty

    let IsRequiredForForm =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.IsRequiredForFormProperty

    let IsRowHeader =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.IsRowHeaderProperty

    let IsOffscreenBehavior =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.IsOffscreenBehaviorProperty

    let ItemStatus =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.ItemStatusProperty

    let ItemType =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.ItemTypeProperty

    let LiveSetting =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.LiveSettingProperty

    let Name =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.NameProperty

    let PositionInSet =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.PositionInSetProperty

    let SizeOfSet =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.SizeOfSetProperty

type AutomationPropertiesModifiers =
    /// <summary>Sets the AcceleratorKey property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AcceleratorKey value.</param>
    [<Extension>]
    static member inline acceleratorKey(this: WidgetBuilder<'msg, #IFabStyledElement>, value: string) =
        this.AddScalar(AutomationProperties.AcceleratorKey.WithValue(value))

    /// <summary>Sets the AccessibilityView property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AccessibilityView value.</param>
    [<Extension>]
    static member inline accessibilityView(this: WidgetBuilder<'msg, #IFabStyledElement>, value: AccessibilityView) =
        this.AddScalar(AutomationProperties.AccessibilityView.WithValue(value))

    /// <summary>Sets the AccessKey property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AccessKey value.</param>
    [<Extension>]
    static member inline accessKey(this: WidgetBuilder<'msg, #IFabStyledElement>, value: string) =
        this.AddScalar(AutomationProperties.AccessKey.WithValue(value))

    /// <summary>Sets the AutomationId property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AutomationId value.</param>
    [<Extension>]
    static member inline automationId(this: WidgetBuilder<'msg, #IFabStyledElement>, value: string) =
        this.AddScalar(AutomationProperties.AutomationId.WithValue(value))

    /// <summary>Sets the ControlTypeOverride property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ControlTypeOverride value.</param>
    [<Extension>]
    static member inline controlTypeOverride(this: WidgetBuilder<'msg, #IFabStyledElement>, value: AutomationControlType) =
        this.AddScalar(AutomationProperties.ControlTypeOverride.WithValue(value))

    /// <summary>Sets the HelpText property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HelpText value.</param>
    [<Extension>]
    static member inline helpText(this: WidgetBuilder<'msg, #IFabStyledElement>, value: string) =
        this.AddScalar(AutomationProperties.HelpText.WithValue(value))

    /// <summary>Sets the IsIsColumnHeader property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsIsColumnHeader value.</param>
    [<Extension>]
    static member inline isColumnHeader(this: WidgetBuilder<'msg, #IFabStyledElement>, value: bool) =
        this.AddScalar(AutomationProperties.IsIsColumnHeader.WithValue(value))

    /// <summary>Sets the IsRequiredForForm property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsRequiredForForm value.</param>
    [<Extension>]
    static member inline isRequiredForForm(this: WidgetBuilder<'msg, #IFabStyledElement>, value: bool) =
        this.AddScalar(AutomationProperties.IsRequiredForForm.WithValue(value))

    /// <summary>Sets the IsRowHeader property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsRowHeader value.</param>
    [<Extension>]
    static member inline isRowHeader(this: WidgetBuilder<'msg, #IFabStyledElement>, value: bool) =
        this.AddScalar(AutomationProperties.IsRowHeader.WithValue(value))

    /// <summary>Sets the IsOffscreenBehavior property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsOffscreenBehavior value.</param>
    [<Extension>]
    static member inline isOffscreenBehavior(this: WidgetBuilder<'msg, #IFabStyledElement>, value: IsOffscreenBehavior) =
        this.AddScalar(AutomationProperties.IsOffscreenBehavior.WithValue(value))

    /// <summary>Sets the ItemStatus property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ItemStatus value.</param>
    [<Extension>]
    static member inline itemStatus(this: WidgetBuilder<'msg, #IFabStyledElement>, value: string) =
        this.AddScalar(AutomationProperties.ItemStatus.WithValue(value))

    /// <summary>Sets the ItemType property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ItemType value.</param>
    [<Extension>]
    static member inline itemType(this: WidgetBuilder<'msg, #IFabStyledElement>, value: string) =
        this.AddScalar(AutomationProperties.ItemType.WithValue(value))

    /// <summary>Sets the LiveSetting property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The LiveSetting value.</param>
    [<Extension>]
    static member inline liveSetting(this: WidgetBuilder<'msg, #IFabStyledElement>, value: AutomationLiveSetting) =
        this.AddScalar(AutomationProperties.LiveSetting.WithValue(value))

    /// <summary>Sets the PositionInSet property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PositionInSet value.</param>
    [<Extension>]
    static member inline positionInSet(this: WidgetBuilder<'msg, #IFabStyledElement>, value: int) =
        this.AddScalar(AutomationProperties.PositionInSet.WithValue(value))

    /// <summary>Sets the SizeOfSet property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SizeOfSet value.</param>
    [<Extension>]
    static member inline sizeOfSet(this: WidgetBuilder<'msg, #IFabStyledElement>, value: int) =
        this.AddScalar(AutomationProperties.SizeOfSet.WithValue(value))
