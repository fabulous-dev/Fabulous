{% include_relative _header.md %}

{% include_relative contents-view.md %}

Cells 
------
##### `topic last updated: v1.0 - 04.04.2021 - 02:51pm`
<br /> 

A cell is a specialized element used for items in a table and describes how each item in a list should be rendered. A cell is not itself a visual element; it is instead a template for creating a visual element.

`Cell` is used exclusively with ListView and TableView controls. To learn how to use and customize cells, refer to the [ListView](view-if-di-listview.html) and [TableView](view-if-di-tableview.html) documentation.

| Cell       | Description                                                 |
|------------|-------------------------------------------------------------|
| TextCell   | displays one or two text strings                            |            
| ImageCell  | same as TextCel, but includes a bitmap                      |            
| SwitchCell | contains text and an on/off switch                          |            
| EntryCell  | defines a Label property and a single line of editable text |            

<br/>

<img src="images/view/TableView-adr-basic.png" width="300">