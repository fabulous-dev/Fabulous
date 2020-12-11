// Copyright Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.XamarinForms.Tests

open Fabulous.XamarinForms
open NUnit.Framework
open FsUnit
open Xamarin.Forms

module ViewUpdatersTests =
    [<Test>]
    let ``UpdateLabelText All none``() =
        let prevTextOpt = ValueNone
        let currTextOpt = ValueNone
        
        let prevFormattedTextOpt = ValueNone
        let currFormattedTextOpt = ValueNone
        
        let target = Label(Text = null, FormattedText = null)
        
        ViewUpdaters.updateLabelText prevFormattedTextOpt currFormattedTextOpt prevTextOpt currTextOpt target
        
        target.Text |> should equal null
        target.FormattedText |> should equal null
        
    [<Test>]
    let ``UpdateLabelText Text None to Some``() =
        let prevTextOpt = ValueNone
        let currTextOpt = ValueSome "ABC"
        
        let prevFormattedTextOpt = ValueNone
        let currFormattedTextOpt = ValueNone
        
        let target = Label(Text = null, FormattedText = null)
        
        ViewUpdaters.updateLabelText prevFormattedTextOpt currFormattedTextOpt prevTextOpt currTextOpt target
        
        target.Text |> should equal "ABC"
        target.FormattedText |> should equal null
        
    [<Test>]
    let ``UpdateLabelText Text Some to Some``() =
        let prevTextOpt = ValueSome "ABC"
        let currTextOpt = ValueSome "DEF"
        
        let prevFormattedTextOpt = ValueNone
        let currFormattedTextOpt = ValueNone
        
        let target = Label(Text = "ABC", FormattedText = null)
        
        ViewUpdaters.updateLabelText prevFormattedTextOpt currFormattedTextOpt prevTextOpt currTextOpt target
        
        target.Text |> should equal "DEF"
        target.FormattedText |> should equal null
        
    [<Test>]
    let ``UpdateLabelText FormattedText None to Some``() =
        let prevTextOpt = ValueNone
        let currTextOpt = ValueNone
        
        let prevFormattedTextOpt = ValueNone
        let currFormattedTextOpt = ValueSome (View.FormattedString(spans = [ View.Span("ABC") ]))
        
        let target = Label(Text = null, FormattedText = null)
        
        ViewUpdaters.updateLabelText prevFormattedTextOpt currFormattedTextOpt prevTextOpt currTextOpt target
        
        target.Text |> should equal null
        target.FormattedText |> should not' (equal null)
        target.FormattedText.Spans.Count |> should equal 1
        target.FormattedText.Spans.[0].Text |> should equal "ABC"
        
    [<Test>]
    let ``UpdateLabelText FormattedText Some to Some``() =
        let prevTextOpt = ValueNone
        let currTextOpt = ValueNone
        
        let prevFormattedTextOpt = ValueSome (View.FormattedString(spans = [ View.Span("ABC") ]))
        let currFormattedTextOpt = ValueSome (View.FormattedString(spans = [ View.Span("DEF") ]))
        
        let formattedString = FormattedString()
        formattedString.Spans.Add(Span(Text = "ABC"))
        
        let target = Label(Text = null, FormattedText = formattedString)
        
        ViewUpdaters.updateLabelText prevFormattedTextOpt currFormattedTextOpt prevTextOpt currTextOpt target
        
        target.Text |> should equal null
        target.FormattedText |> should not' (equal null)
        target.FormattedText.Spans.Count |> should equal 1
        target.FormattedText.Spans.[0].Text |> should equal "DEF"
        
    [<Test>]
    let ``UpdateLabelText Text Some to FormattedText Some``() =
        let prevTextOpt = ValueSome "ABC"
        let currTextOpt = ValueNone
        
        let prevFormattedTextOpt = ValueNone
        let currFormattedTextOpt = ValueSome (View.FormattedString(spans = [ View.Span("DEF") ]))
                
        let target = Label(Text = "ABC", FormattedText = null)
        
        ViewUpdaters.updateLabelText prevFormattedTextOpt currFormattedTextOpt prevTextOpt currTextOpt target
        
        target.Text |> should equal null
        target.FormattedText |> should not' (equal null)
        target.FormattedText.Spans.Count |> should equal 1
        target.FormattedText.Spans.[0].Text |> should equal "DEF"
        
    [<Test>]
    let ``UpdateLabelText FormattedText Some to Text Some``() =
        let prevTextOpt = ValueNone
        let currTextOpt = ValueSome "DEF"
        
        let prevFormattedTextOpt = ValueSome (View.FormattedString(spans = [ View.Span("ABC") ]))
        let currFormattedTextOpt = ValueNone
        
        let formattedString = FormattedString()
        formattedString.Spans.Add(Span(Text = "ABC"))
        
        let target = Label(Text = null, FormattedText = formattedString)
        
        ViewUpdaters.updateLabelText prevFormattedTextOpt currFormattedTextOpt prevTextOpt currTextOpt target
        
        target.Text |> should equal "DEF"
        target.FormattedText |> should equal null
        
    [<Test>]
    let ``UpdateLabelText Text/FormattedText Some to Text/FormattedText Some``() =
        let prevTextOpt = ValueSome "ABC"
        let currTextOpt = ValueSome "DEF"
        
        let prevFormattedTextOpt = ValueSome (View.FormattedString(spans = [ View.Span("GHI") ]))
        let currFormattedTextOpt = ValueSome (View.FormattedString(spans = [ View.Span("JKL") ]))

        let formattedString = FormattedString()
        formattedString.Spans.Add(Span(Text = "GHI"))
        
        let target = Label(Text = null, FormattedText = formattedString)
        
        ViewUpdaters.updateLabelText prevFormattedTextOpt currFormattedTextOpt prevTextOpt currTextOpt target
        
        target.Text |> should equal null
        target.FormattedText |> should not' (equal null)
        target.FormattedText.Spans.Count |> should equal 1
        target.FormattedText.Spans.[0].Text |> should equal "JKL"
