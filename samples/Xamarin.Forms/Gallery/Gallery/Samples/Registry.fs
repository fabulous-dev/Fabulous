namespace Gallery.Samples

open System.Collections.Generic

open type Fabulous.XamarinForms.View

type Category =
    { Name: string
      Description: string
      Samples: Sample list }

    interface IEnumerable<Sample> with
        member this.GetEnumerator() : IEnumerator<Sample> =
            (Seq.ofList this.Samples).GetEnumerator()

        member this.GetEnumerator() : System.Collections.IEnumerator =
            (Seq.ofList this.Samples).GetEnumerator() :> System.Collections.IEnumerator

module Registry =
    let categories =
        [ { Name = "Controls"
            Description = "Controls"
            Samples =
                [ Label.sample
                  Button.sample ] } ]

    let getForIndex (index: int) =
        let mutable i = index
        let mutable found = Unchecked.defaultof<Sample>

        for category in categories do
            i <- i - 1

            for sample in category.Samples do
                if i = 0 then found <- sample
                i <- i - 1

        found
