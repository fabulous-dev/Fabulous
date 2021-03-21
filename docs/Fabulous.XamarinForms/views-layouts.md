{% include_relative _header.md %}

{% include_relative contents.md %}

Layouts 
------
Layouts ...

### Layouts with single content 
<br /> 

| Layout      | Description                                          | Appearance |
|-------------|------------------------------------------------------|------------|
| ContentView | contains a single child                              |            |
| Frame       | displays a border, or frame, around its single child |            |
| ScrollView  | capable of scrolling its contents                    |            |
 
<br /> 

### Layouts with multiple children
<br /> 

| Layout         | Description                                                                           | Appearance |
|----------------|---------------------------------------------------------------------------------------|------------|
| StackLayout    | positions child elements in a stack either horizontally or vertically                 |            |
| Grid           | positions its child elements in a grid of rows and columns                            |            |
| AbsoluteLayout | positions child elements at specific locations relative to its parent                 |            |
| RelativeLayout | positions child elements relative to the RelativeLayout itself or to their siblings   |            |
| FlexLayout     | allows children to be stacked or wrapped with many alignment and orientation options. |            |

<br /> 

Examples
------
<br />

### Content View
```fsharp 
    let view model dispatch =
        View.ContentPage(
            View.ContentView(
                View.Label("content")
            )
        )
```

### Frame
```fsharp 
    let view model dispatch =
        View.ContentPage( content = 
            View.StackLayout( children = [
                View.Frame(
                        hasShadow = true, 
                        content = View.Label("framed content")
                    )
            ])    
        )
```

### ScrollView
```fsharp 
    let view model dispatch =
        View.ContentPage(
            View.ScrollView(
                View.StackLayout(children = [
                    for i in 1 .. 100 -> View.Label(text = sprintf "item %i" i)
                ])
            )
        )
```

### StackLayout
```ScrollView 
    let view model dispatch =
        View.ContentPage(
            View.StackLayout(children = [
                View.Label("first label")
                View.Button(text = "first button")
                View.Label("second label")
            ])
        )
```

### Grid
```fsharp 
        View.ContentPage(
            View.Grid(
                rowdefs = [
                    Dimension.Auto
                    Dimension.Absolute 150.
                    Dimension.Auto
                    Dimension.Star                    
                ],
                coldefs = [
                    Dimension.Absolute 200.
                    Dimension.Star
                ],
                children = [
                    View.Label(text = "first row", backgroundColor = Color.Red).Row(0)                    
                    View.Label(text = "second row", backgroundColor = Color.Blue).Row(1)
                    View.Label(text = "first column", backgroundColor = Color.Yellow).Row(2).Column(0)
                    View.Label(text = "second column", backgroundColor = Color.Green).Row(2).Column(1)
                    View.Label(text = "column spanning", backgroundColor = Color.Orange).Row(3).ColumnSpan(2)
                ]
            )
        )
```

### AbsoluteLayout
```fsharp 
        View.ContentPage(
            View.AbsoluteLayout(
                backgroundColor = Color.Blue.WithLuminosity(0.9),
                children = [
                   View.Label(text = "Top Left", textColor = Color.Black)
                       .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                       .LayoutBounds(Rectangle(0.0, 0.0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize))
                   View.Label(text = "Centered", textColor = Color.Black)
                       .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                       .LayoutBounds(Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize))
                   View.Label(text = "Bottom Right", textColor = Color.Black)
                       .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                       .LayoutBounds(Rectangle(1.0, 1.0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize))
                ]
            )
        )
```

### RelativeLayout
```fsharp 
        View.ContentPage(
            View.RelativeLayout(
                children =
                    [ View.Label(text = "RelativeLayout Example", textColor = Color.Red)
                          .XConstraint(Constraint.RelativeToParent(fun parent -> 0.0))
                      View.Label(text = "Positioned relative to my parent", textColor = Color.Red)
                          .XConstraint(Constraint.RelativeToParent(fun parent -> parent.Width / 3.0))
                          .YConstraint(Constraint.RelativeToParent(fun parent -> parent.Height / 2.0))
                    ]
            )
        )
```

### FlexLayout
```fsharp 
        View.ContentPage(
            View.FlexLayout(
                direction=FlexDirection.Column,
                children = [
                    View.Label(text = "Seated Monkey", fontSize = FontSize.fromNamedSize NamedSize.Large, textColor=Color.Blue)
                    View.Label(text = "This monkey is laid back and relaxed.")
                    View.Label(text = "  - Often smiles mysteriously")
                    View.Label(text = "  - Sleeps sitting up")

                    View.Image(
                        source = Image.ImagePath "images/160px-Vervet_monkey_Krugersdorp_game_reserve_%285657678441%29.jpg"
                    ).Order(-1).AlignSelf(FlexAlignSelf.Center)        
        
                    View.Label(margin = Thickness(0.0, 4.0)).Grow(1.0)
                    View.Button(text = "Learn More", fontSize = FontSize.fromNamedSize NamedSize.Large, cornerRadius = 20)
                ]
            )
        )
```

