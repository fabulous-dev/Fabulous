{% include_relative _header.md %}

{% include_relative contents-view.md %}

Pages 
------

##### `topic last updated: v1.0 - 24.04.2021 - 11:47pm`
<br /> 

 These visual elements occupy all or most of the screen and usually contain several layers of lower tier visual elements. 
 For example, a ContentPage may contain a StackLayout which in turn contains several buttons, labeles or other view elements. 

| Page type                                 | Description                                                                                          | Appearance                                                    |
|-------------------------------------------|------------------------------------------------------------------------------------------------------|---------------------------------------------------------------|
| [ContentPage](view-pages-contentpage.html)       | a simple page, containing a single View object (usually a layout)                                    | <img src="images/pages/content-adr-styled.png" width="100">   |
| [FlyoutPage](view-pages-flyoutpage.html)         | contains a flyout pane (usually a list or menu) plus a detail pane (usually showing a selected item) | <img src="images/pages/flyout-adr-basic.png" width="100">     |
| [NavigationPage](view-pages-navigationpage.html) | manages navigation among other pages using a stack-based architecture                                | <img src="images/pages/navigation-adr-basic.png" width="100"> |
| [TabbedPage](view-pages-tabbedpage.html)         | allows navigation among child pages using tabs                                                       | <img src="images/pages/tabbed-adr-styled.png" width="100">    |
| [CarouselPage](view-pages-carouselpage.html)     | allows navigation among child pages through finger swiping                                           | <img src="images/pages/carousel-adr-styled.png" width="100">  |


<br /> 

See also 
* [Multi-page Applications and Navigation](view-pages-navigation.html)
* [Shells](view-pages-shells.html)