// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.DynamicViews

[<AutoOpen>]
module VideoManagerExtension =

    open Fabulous.DynamicViews
    open MediaManager.Forms
    open MediaManager.Video

    //// Define keys for the possible attributes
    let SourceAttribKey = AttributeKey<_> "VideoManager_Source"
    let VideoAspectAttribKey = AttributeKey<_> "VideoManager_VideoAspect"
    let ShowControlsAttribKey = AttributeKey<_> "VideoManager_ShowControls"

    type Fabulous.DynamicViews.View with
        /// Describes a VideoView in the view
        static member inline VideoView
            (source: obj, ?videoAspect: VideoAspectMode , ?ShowControls: bool,
             // inherited attributes common to all views
             ?horizontalOptions, ?verticalOptions, ?margin, ?gestureRecognizers, ?anchorX, ?anchorY, ?backgroundColor, ?heightRequest,
             ?inputTransparent, ?isEnabled, ?isVisible, ?minimumHeightRequest, ?minimumWidthRequest, ?opacity,
             ?rotation, ?rotationX, ?rotationY, ?scale, ?style, ?translationX, ?translationY, ?widthRequest,
             ?resources, ?styles, ?styleSheets, ?classId, ?styleId, ?automationId, ?created, ?styleClass) =

            // Count the number of additional attributes
            let attribCount = 1 // source
            let incIfSome attr count = match attr with Some _ -> count + 1 | None -> count
            let attribCount = incIfSome videoAspect attribCount
            let attribCount = incIfSome ShowControls attribCount

            // Populate the attributes of the base element
            let attribs =
                ViewBuilders.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions,
                                       ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY,
                                       ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent,
                                       ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest,
                                       ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation,
                                       ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style,
                                       ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest,
                                       ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId,
                                       ?automationId=automationId, ?created=created, ?styleClass=styleClass)

            // Add our own attributes.
            attribs.Add(SourceAttribKey, source)
            let addIfSome (attribs: AttributesBuilder) prop key = match prop with None -> () | Some v -> attribs.Add(key, v)
            addIfSome attribs videoAspect VideoAspectAttribKey
            addIfSome attribs ShowControls ShowControlsAttribKey

            // The create method
            let create () = new VideoView()

            // The update method
            let update (prevOpt: ViewElement voption) (source: ViewElement) (target: VideoView) =
                ViewBuilders.UpdateView(prevOpt, source, target)
                source.UpdatePrimitive(prevOpt, target, SourceAttribKey, (fun target v -> target.Source <- v))
                source.UpdatePrimitive(prevOpt, target, VideoAspectAttribKey, (fun target v -> target.VideoAspect <- v))
                source.UpdatePrimitive(prevOpt, target, ShowControlsAttribKey, (fun target v -> target.ShowControls <- v))

            // The element
            ViewElement.Create(create, update, attribs)

