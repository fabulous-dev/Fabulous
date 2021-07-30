namespace Fabulous

module StatefulWidget =
    let mkSimple init update view =
        let widget =
            { State = None
              Init = init
              Update = (fun (msg, model) -> update msg model)
              View = (fun (model, _) -> view model) }
        
        Runners.createRunner widget

