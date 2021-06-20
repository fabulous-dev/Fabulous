namespace Fabulous.XamarinForms

module Program =
    open Fabulous
    open Xamarin.Forms

    let run (element: Element) (program: IProgram<'arg, 'model, 'msg>) =
        let runner = Runner.Create(program)
        //let adapter = Adapter.Create(runner.Key)
        //adapter.AttachTo(element)
        runner.Start(ValueSome(box ()))
        runner

    let run2 (program: IProgram<'arg, 'model, 'msg>) =
        let runner = Runner.Create(program)
        let adapter = Adapter.Create(runner.Key)
        let element = Xamarin.Forms.Application() //adapter.Create(element)
        runner.Start(ValueSome(box ()))
        runner, element

module Toto =
    open Fabulous

    let runner =
        Program.mkSimple (fun () -> ()) (fun () () -> ()) (fun () -> { HandlerKey = 0; Attributes = [||] })
        |> Program.run (new Xamarin.Forms.Application())

    let runner2, app =
        Program.mkSimple (fun () -> ()) (fun () () -> ()) (fun () -> { HandlerKey = 0; Attributes = [||] })
        |> Program.run2
