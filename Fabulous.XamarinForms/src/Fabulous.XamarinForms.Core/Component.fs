namespace Fabulous.XamarinForms

open Fabulous

module Component =
    let ComponentRunnerProperty = Xamarin.Forms.BindableProperty.CreateAttached("ComponentRunner", typeof<obj>, typeof<Xamarin.Forms.BindableObject>, null)

    let canReuseView (prev: IComponentViewElement) (curr: IComponentViewElement) =
        prev.TargetType = curr.TargetType

    type ComponentHandler<'arg, 'msg, 'model, 'externalMsg>() =
        interface IComponentHandler<'arg, 'msg, 'model, 'externalMsg> with
            member x.CreateRunner() = Runner<'arg, 'msg, 'model, 'externalMsg>() :> IRunner<'arg, 'msg, 'model, 'externalMsg>

            member x.GetRunnerForTarget(target) =
                match (target :?> Xamarin.Forms.BindableObject).GetValue(ComponentRunnerProperty) with
                | null -> ValueNone
                | runner -> ValueSome (runner :?> IRunner<'arg, 'msg, 'model, 'externalMsg>)

            member x.SetRunnerForTarget(runner, target) =
                (target :?> Xamarin.Forms.BindableObject).SetValue(ComponentRunnerProperty, runner)

    let forProgram(program) =
        let handler = ComponentHandler<unit, 'msg, 'model, 'externalMsg>()
        ComponentViewElement(handler, program, ValueNone, (), ValueNone, ValueNone)

    let forProgramWithArgs(program, args) =
        let handler = ComponentHandler<'arg, 'msg, 'model, 'externalMsg>()
        ComponentViewElement(handler, program, ValueNone, args, ValueNone, ValueNone)

    let forProgramWithState(program, state, onStateChanged) =
        let handler = ComponentHandler<unit, 'msg, 'model, 'externalMsg>()
        ComponentViewElement(handler, program, ValueNone, (), ValueSome (onStateChanged, state), ValueNone)

    let forProgramWithExternalMsg(program, onExternalMsg) =
        let handler = ComponentHandler<unit, 'msg, 'model, 'externalMsg>()
        ComponentViewElement(handler, program, ValueNone, (), ValueNone, ValueSome onExternalMsg)