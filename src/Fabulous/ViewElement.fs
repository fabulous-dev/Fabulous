namespace Fabulous

type ViewElement =
    { HandlerKey: int
      Attributes: (int * obj)[] }
    interface IViewElement

type ComponentViewElement<'arg, 'model, 'msg> =
    { Program: IProgram<'arg, 'model, 'msg> }
    interface IViewElement