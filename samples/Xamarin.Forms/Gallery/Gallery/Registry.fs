namespace Gallery

open System.Collections.Generic

module Registry =
    type Widget =
        { Name: string
          Description: string
          SampleCode: string }
    
    type Category =
        { Name: string
          Description: string
          Widgets: Widget list }
        
        interface IEnumerable<Widget> with
            member this.GetEnumerator(): IEnumerator<Widget> = (Seq.ofList this.Widgets).GetEnumerator()
            member this.GetEnumerator(): System.Collections.IEnumerator = (Seq.ofList this.Widgets).GetEnumerator() :> System.Collections.IEnumerator
        
    let categories =
        [ { Name = "Controls"
            Description = "Controls"
            Widgets =
                [ { Name = "Button"
                    Description = "Button"
                    SampleCode = "let button = new Button()" }
                  { Name = "Label"
                    Description = "Label"
                    SampleCode = "let label = new Label()" } ] }
        
          { Name = "GestureRecognizers"
            Description = "GestureRecognizers"
            Widgets =
                [ { Name = "TapGestureRecognizer"
                    Description = "TapGestureRecognizer"
                    SampleCode = "" } ] }
          
          { Name = "Pages"
            Description = "Pages"
            Widgets =
                [ { Name = "ContentPage"
                    Description = "ContentPage"
                    SampleCode = "" } ] } ]
        
    let getForIndex (index: int) =
        let mutable i = index
        let mutable found = Unchecked.defaultof<Widget>

        for category in categories do
            i <- i - 1

            for widget in category.Widgets do
                if i = 0 then found <- widget
                i <- i - 1

        found