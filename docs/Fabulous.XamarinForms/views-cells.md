{% include_relative _header.md %}

{% include_relative contents.md %}

Cells 
------
##### `topic last updated: v 0.61.0 - 31.03.2021 - 02:29pm,`
<br /> 

A cell is a specialized element used for items in a table and describes how each item in a list should be rendered. A cell is not itself a visual element; it is instead a template for creating a visual element.

`Cell` is used exclusively with ListView and TableView controls. To learn how to use and customize cells, refer to the ListView and TableView documentation.

| Cell       | Description                                                 | Appearance |
|------------|-------------------------------------------------------------|------------|
| TextCell   | displays one or two text strings                            |            |
| ImageCell  | same as TextCel, but includes a bitmap                      |            |
| SwitchCell | contains text and an on/off switch                          |            |
| EntryCell  | defines a Label property and a single line of editable text |            |