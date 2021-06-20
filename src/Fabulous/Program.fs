namespace Fabulous

type IViewElement = interface end

type IProgram<'arg, 'model, 'msg> =
    abstract Init: 'arg -> 'model
    abstract Update: 'msg * 'model -> 'model
    abstract View: 'model -> IViewElement