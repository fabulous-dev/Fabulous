{% include_relative _header.md %}

{% include_relative contents.md %}

Interface objects (Views) for presentation
------
##### `topic last updated: v1.0 - 04.04.2021 - 02:51pm`
<br /> 

| Name                                          | Description                                                                                | Appearance                                                     |
|-----------------------------------------------|--------------------------------------------------------------------------------------------|----------------------------------------------------------------|
| [BoxView](interface/present/BoxView.md)       | renders a simple rectangle of a specified width, height, and color                         | <img src="images/views/BoxView-adr-styled.png" width="300">    |
| [Image](interface/present/Image.md)           | can be loaded specifically for each platform, or they can be downloaded for display        | <img src="images/views/Image-adr-styled.png" width="300">      |
| [Label](interface/present/Label.md)           | used for displaying text, both single and multi-line                                       | <img src="images/views/Label-adr-styled.png" width="300">      |
| [Map](interface/present/Map.md)               | a cross-platform view for displaying and annotating maps                                   | <img src="images/views/Map-adr-styled.png" width="300">        |
| [Ellipse](interface/present/Ellipse.md)       | derives from the Shape class, and can be used to draw ellipses and circles                 | <img src="images/views/Ellipse-adr-styled.png" width="300">    |
| [Line](interface/present/Line.md)             | derives from the Shape class, and can be used to draw lines                                | <img src="images/views/Line-adr-styled.png" width="300">       |
| [Path](interface/present/Path.md)             | derives from the Shape class, and can be used to draw curves and complex shapes            | <img src="images/views/Path-adr-styled.png" width="300">       |
| [Polygon](interface/present/Polygon.md)       | derives from the Shape class, and can be used to draw polygons                             | <img src="images/views/Polygon-adr-styled.png" width="300">    |
| [Polyline](interface/present/Polyline.md)     | derives from the Shape class, and can be used to draw a series of connected straight lines | <img src="images/views/Polyline-adr-styled.png" width="300">   |
| [Rectangle](interface/present/Rectangle.md)   | derives from the Shape class, and can be used to draw rectangles and squares.              | <img src="images/views/Rectangle-adr-styled.png" width="300">  |
| [WebView](interface/present/WebView.md)       | supports: HTML&CSS websites, Documents, HTML strings, Local Files                          | <img src="images/views/WebView-adr-styled.png" width="300">    |
| [OpenGlView](interface/present/OpenGlView.md) | displays OpenGL content                                                                    | <img src="images/views/OpenGlView-adr-styled.png" width="300"> |