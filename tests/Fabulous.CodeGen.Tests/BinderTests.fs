namespace Fabulous.CodeGen.Tests

open NUnit.Framework
open FsUnit
open Fabulous.CodeGen.Models
open Fabulous.CodeGen.Binder

module BinderTests =
    [<Test>]
    let ``bindProperty should return binding using reader values if no overwrite values are given``() =
        let typeFullName = "Xamarin.Forms.View"
        
        let propertyReaderData =
            { Name = "HorizontalOptions"
              Type = "Xamarin.Forms.LayoutOptions"
              DefaultValue = "Xamarin.Forms.LayoutOptions.Start" }
            
        let propertyOverwriteData =
            { Position = None
              Source = None
              Name = None
              ShortName = None
              UniqueName = None
              DefaultValue = None
              InputType = None
              ModelType = None
              ConvertInputToModel = None
              ConvertModelToValue = None }

        Binder.bindProperty typeFullName propertyReaderData propertyOverwriteData
        |> should equal
            { Name = "HorizontalOptions"
              ShortName = "horizontalOptions"
              UniqueName = "ViewHorizontalOptions"
              DefaultValue = "Xamarin.Forms.LayoutOptions.Start"
              InputType = "Xamarin.Forms.LayoutOptions"
              ModelType = "Xamarin.Forms.LayoutOptions"
              ConvertInputToModel = ""
              ConvertModelToValue = "" }

    [<Test>]
    let ``bindProperty should return binding using the given overwrite name``() =
        let typeFullName = "Xamarin.Forms.View"
        
        let propertyReaderData =
            { Name = "HorizontalOptions"
              Type = "Xamarin.Forms.LayoutOptions"
              DefaultValue = "Xamarin.Forms.LayoutOptions.Start" }
            
        let propertyOverwriteData =
            { Position = None
              Source = None
              Name = Some "HorizontalAlignment"
              ShortName = None
              UniqueName = None
              DefaultValue = None
              InputType = None
              ModelType = None
              ConvertInputToModel = None
              ConvertModelToValue = None }

        Binder.bindProperty typeFullName propertyReaderData propertyOverwriteData
        |> should equal
            { Name = "HorizontalAlignment"
              ShortName = "horizontalAlignment"
              UniqueName = "ViewHorizontalAlignment"
              DefaultValue = "Xamarin.Forms.LayoutOptions.Start"
              InputType = "Xamarin.Forms.LayoutOptions"
              ModelType = "Xamarin.Forms.LayoutOptions"
              ConvertInputToModel = ""
              ConvertModelToValue = "" }

    [<Test>]
    let ``bindProperty should return binding using the given overwrite values``() =
        let typeFullName = "Xamarin.Forms.ListView"
        
        let propertyReaderData =
            { Name = "ItemsSource"
              Type = "ViewElement list"
              DefaultValue = "[]" }
            
        let propertyOverwriteData =
            { Position = None
              Source = None
              Name = Some "Items"
              ShortName = Some "shortItems"
              UniqueName = Some "UniqueItems"
              DefaultValue = Some "DefaultValue"
              InputType = Some "InputType"
              ModelType = Some "ModelType"
              ConvertInputToModel = Some "ConvertInputToModel"
              ConvertModelToValue = Some "ConvertModelToValue" }

        Binder.bindProperty typeFullName propertyReaderData propertyOverwriteData
        |> should equal
            { Name = "Items"
              ShortName = "shortItems"
              UniqueName = "UniqueItems"
              DefaultValue = "DefaultValue"
              InputType = "InputType"
              ModelType = "ModelType"
              ConvertInputToModel = "ConvertInputToModel"
              ConvertModelToValue = "ConvertModelToValue" }
    [<Test>]
    let ``bindEvent should return binding using reader values if no overwrite values are given``() =
        let typeFullName = "Xamarin.Forms.ScrollView"
        
        let eventReaderData =
            { Name = "Scrolled"
              Type = "System.EventHandler<Xamarin.Forms.ScrolledEventArgs>"
              EventArgsType = "Xamarin.Forms.ScrolledEventArgs" }
            
        let eventOverwriteData =
            { Position = None
              Source = None
              Name = None
              ShortName = None
              UniqueName = None
              Type = None
              EventArgsType = None }

        Binder.bindEvent typeFullName eventReaderData eventOverwriteData
        |> should equal
            { Name = "Scrolled"
              ShortName = "scrolled"
              UniqueName = "ScrollViewScrolled"
              Type = "System.EventHandler<Xamarin.Forms.ScrolledEventArgs>"
              EventArgsType = "Xamarin.Forms.ScrolledEventArgs" }

    [<Test>]
    let ``bindEvent should return binding using the given overwrite name``() =
        let typeFullName = "Xamarin.Forms.ScrollView"
        
        let eventReaderData =
            { Name = "Scrolled"
              Type = "System.EventHandler<Xamarin.Forms.ScrolledEventArgs>"
              EventArgsType = "Xamarin.Forms.ScrolledEventArgs" }
            
        let eventOverwriteData =
            { Position = None
              Source = None
              Name = Some "ScrollFinished"
              ShortName = None
              UniqueName = None
              Type = None
              EventArgsType = None }

        Binder.bindEvent typeFullName eventReaderData eventOverwriteData
        |> should equal
            { Name = "ScrollFinished"
              ShortName = "scrollFinished"
              UniqueName = "ScrollViewScrollFinished"
              Type = "System.EventHandler<Xamarin.Forms.ScrolledEventArgs>"
              EventArgsType = "Xamarin.Forms.ScrolledEventArgs" }

    [<Test>]
    let ``bindEvent should return binding using the given overwrite values``() =
        let typeFullName = "Xamarin.Forms.ScrollView"
        
        let eventReaderData =
            { Name = "Scrolled"
              Type = "System.EventHandler<Xamarin.Forms.ScrolledEventArgs>"
              EventArgsType = "Xamarin.Forms.ScrolledEventArgs" }
            
        let eventOverwriteData =
            { Position = None
              Source = None
              Name = Some "Name"
              ShortName = Some "ShortName"
              UniqueName = Some "UniqueName"
              Type = Some "Type"
              EventArgsType = Some "EventArgsType" }

        Binder.bindEvent typeFullName eventReaderData eventOverwriteData
        |> should equal
            { Name = "Name"
              ShortName = "ShortName"
              UniqueName = "UniqueName"
              Type = "Type"
              EventArgsType = "EventArgsType" }
        