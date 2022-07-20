namespace Gallery

open Fabulous.XamarinForms
open Xamarin.Forms

open type Fabulous.XamarinForms.View

type SampleViewType =
    | Run
    | Code
    
type SampleView =
    { Value: SampleViewType
      Text: string }

module SampleViewSelector =
    let radioButton (text: string) (isSelected: bool) (onSelected: 'msg) =
        Frame(
            Label(text)
                .centerTextHorizontal()
                .centerTextVertical()
                .font(namedSize = NamedSize.Body, fontFamily = "Icomoon")
                .textColor(if isSelected then Color.White.ToFabColor() else Color.LightGray.ToFabColor())
        )
            .hasShadow(false)
            .size(width = 36., height = 36.)
            .padding(0.)
            .borderColor(if isSelected then FabColor.fromHex "#1a76d2" else Color.LightGray.ToFabColor())
            .backgroundColor(if isSelected then FabColor.fromHex "#2196f3" else Color.White.ToFabColor())
            .gestureRecognizers() {
                TapGestureRecognizer(onSelected)
            }
    
[<AutoOpen>]
module SampleViewSelectorBuilders =
    open SampleViewSelector
    
    type Fabulous.XamarinForms.View with
        static member inline SampleViewSelector(items: SampleView list, selectedItem: SampleViewType, onSelectionChanged: SampleViewType -> 'msg) =
            HStack() {
                for item in items do
                    radioButton item.Text (selectedItem = item.Value) (onSelectionChanged item.Value)
            }