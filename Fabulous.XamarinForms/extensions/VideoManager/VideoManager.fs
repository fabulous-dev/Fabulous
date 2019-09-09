// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.XamarinForms

[<AutoOpen>]
module VideoManagerExtension =

    open Fabulous
    open MediaManager.Forms
    open MediaManager.Video

    //// Define keys for the possible attributes
    let SourceAttribKey = AttributeKey<_> "VideoManager_Source"
    let VideoAspectAttribKey = AttributeKey<_> "VideoManager_VideoAspect"
    let ShowControlsAttribKey = AttributeKey<_> "VideoManager_ShowControls"

    type Fabulous.XamarinForms.View with
        /// Describes a VideoView in the view
        static member inline VideoView
            (?source: obj, ?videoAspect: VideoAspectMode , ?showControls: bool,
             // inherited attributes common to all views
             ?horizontalOptions, ?verticalOptions, ?margin, ?gestureRecognizers, ?anchorX, ?anchorY, ?backgroundColor, ?height,
             ?inputTransparent, ?isEnabled, ?isVisible, ?minimumHeight, ?minimumWidth, ?opacity,
             ?rotation, ?rotationX, ?rotationY, ?scale, ?style, ?translationX, ?translationY, ?width,
             ?resources, ?styles, ?styleSheets, ?classId, ?styleId, ?automationId, ?created, ?styleClass) =

            // Count the number of additional attributes
            let attribCount = 0
            let attribCount = match source with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match videoAspect with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match showControls with Some _ -> attribCount + 1 | None -> attribCount

            // Populate the attributes of the base element
            let attribs =
                ViewBuilders.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions,
                                       ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY,
                                       ?backgroundColor=backgroundColor, ?height=height, ?inputTransparent=inputTransparent,
                                       ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeight=minimumHeight,
                                       ?minimumWidth=minimumWidth, ?opacity=opacity, ?rotation=rotation,
                                       ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style,
                                       ?translationX=translationX, ?translationY=translationY, ?width=width,
                                       ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId,
                                       ?automationId=automationId, ?created=created, ?styleClass=styleClass)

            // Add our own attributes.
            match source with None -> () | Some v -> attribs.Add(SourceAttribKey, v)
            match videoAspect with None -> () | Some v -> attribs.Add(VideoAspectAttribKey, v)
            match showControls with None -> () | Some v -> attribs.Add(ShowControlsAttribKey, v)

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

#if DEBUG
    let sample1 =
        View.VideoView(
            source = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4",
            showControls = false,
            height = 500.,
            width = 200.)
#endif

