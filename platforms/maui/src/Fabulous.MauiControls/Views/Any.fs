namespace Fabulous.Maui

open Fabulous
open Fabulous.Maui

[<AutoOpen>]
module AnyBuilders =
    type Fabulous.Maui.View with

        /// <summary>Downcast to View widget to allow to return different types of views in a single expression (e.g. if/else, match with pattern, etc.)</summary>
        /// <param name="this">Current widget</param>
        static member AnyView(this: WidgetBuilder<'msg, #IFabView>) =
            WidgetBuilder<'msg, IFabView>(this.Key, this.Attributes)

        /// <summary>Downcast to View widget to allow to return different types of views in a single expression (e.g. if/else, match with pattern, etc.)</summary>
        /// <param name="this">Current widget</param>
        static member AnyView(this: WidgetBuilder<'msg, Memo.Memoized<#IFabView>>) =
            WidgetBuilder<'msg, IFabView>(this.Key, this.Attributes)

        /// <summary>Downcast to Page widget to allow to return different types of pages in a single expression (e.g. if/else, match with pattern, etc.)</summary>
        /// <param name="this">Current widget</param>
        static member AnyPage(this: WidgetBuilder<'msg, #IFabPage>) =
            WidgetBuilder<'msg, IFabPage>(this.Key, this.Attributes)

        /// <summary>Downcast to Page widget to allow to return different types of pages in a single expression (e.g. if/else, match with pattern, etc.)</summary>
        /// <param name="this">Current widget</param>
        static member AnyPage(this: WidgetBuilder<'msg, Memo.Memoized<#IFabPage>>) =
            WidgetBuilder<'msg, IFabPage>(this.Key, this.Attributes)

        /// <summary>Downcast to Cell widget to allow to return different types of cells in a single expression (e.g. if/else, match with pattern, etc.)</summary>
        /// <param name="this">Current widget</param>
        static member AnyCell(this: WidgetBuilder<'msg, #IFabCell>) =
            WidgetBuilder<'msg, IFabCell>(this.Key, this.Attributes)

        /// <summary>Downcast to Cell widget to allow to return different types of cells in a single expression (e.g. if/else, match with pattern, etc.)</summary>
        /// <param name="this">Current widget</param>
        static member AnyCell(this: WidgetBuilder<'msg, Memo.Memoized<#IFabCell>>) =
            WidgetBuilder<'msg, IFabCell>(this.Key, this.Attributes)
