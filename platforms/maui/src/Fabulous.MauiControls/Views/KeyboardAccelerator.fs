namespace Fabulous.Maui

open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls

type IFabKeyboardAccelerator =
    interface
    end

module KeyboardAccelerator =
    let WidgetKey = Widgets.register<KeyboardAccelerator>()

    let Key =
        Attributes.defineBindableWithEquality<string> KeyboardAccelerator.KeyProperty

    let Modifiers =
        Attributes.defineBindableWithEquality<KeyboardAcceleratorModifiers> KeyboardAccelerator.ModifiersProperty

[<AutoOpen>]
module KeyboardAcceleratorBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a KeyboardAccelerator widget with a key</summary>
        /// <param name="key">The key triggering the accelerator</param>
        static member inline KeyboardAccelerator<'msg when 'msg: equality>(key: string) =
            WidgetBuilder<'msg, IFabKeyboardAccelerator>(KeyboardAccelerator.WidgetKey, KeyboardAccelerator.Key.WithValue(key))

        /// <summary>Create a KeyboardAccelerator widget with a key and a modifier</summary>
        /// <param name="key">The key triggering the accelerator</param>
        /// <param name="modifiers">The modifiers required to trigger the accelerator</param>
        static member inline KeyboardAccelerator<'msg when 'msg: equality>(key: string, modifiers: KeyboardAcceleratorModifiers) =
            WidgetBuilder<'msg, IFabKeyboardAccelerator>(
                KeyboardAccelerator.WidgetKey,
                KeyboardAccelerator.Key.WithValue(key),
                KeyboardAccelerator.Modifiers.WithValue(modifiers)
            )
