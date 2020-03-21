// Copyright 2018-2020 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.XamarinForms.FFImageLoading

#nowarn "59" // cast always holds
#nowarn "66" // cast always holds
#nowarn "67" // cast always holds
#nowarn "760"

open Fabulous
open Fabulous.XamarinForms

module ViewAttributes =
    let SuccessAttribKey : AttributeKey<_> = AttributeKey<_>("Success")
    let ErrorAttribKey : AttributeKey<_> = AttributeKey<_>("Error")
    let FinishAttribKey : AttributeKey<_> = AttributeKey<_>("Finish")
    let DownloadStartedAttribKey : AttributeKey<_> = AttributeKey<_>("DownloadStarted")
    let DownloadProgressAttribKey : AttributeKey<_> = AttributeKey<_>("DownloadProgress")
    let FileWriteFinishedAttribKey : AttributeKey<_> = AttributeKey<_>("FileWriteFinished")
    let AspectAttribKey : AttributeKey<_> = AttributeKey<_>("Aspect")
    let IsOpaqueAttribKey : AttributeKey<_> = AttributeKey<_>("IsOpaque")
    let CachedImageSourceAttribKey : AttributeKey<_> = AttributeKey<_>("CachedImageSource")
    let RetryCountAttribKey : AttributeKey<_> = AttributeKey<_>("RetryCount")
    let RetryDelayAttribKey : AttributeKey<_> = AttributeKey<_>("RetryDelay")
    let LoadingDelayAttribKey : AttributeKey<_> = AttributeKey<_>("LoadingDelay")
    let DownsampleWidthAttribKey : AttributeKey<_> = AttributeKey<_>("DownsampleWidth")
    let DownsampleHeightAttribKey : AttributeKey<_> = AttributeKey<_>("DownsampleHeight")
    let DownsampleToViewSizeAttribKey : AttributeKey<_> = AttributeKey<_>("DownsampleToViewSize")
    let DownsampleUseDipUnitsAttribKey : AttributeKey<_> = AttributeKey<_>("DownsampleUseDipUnits")
    let CacheDurationAttribKey : AttributeKey<_> = AttributeKey<_>("CacheDuration")
    let LoadingPriorityAttribKey : AttributeKey<_> = AttributeKey<_>("LoadingPriority")
    let BitmapOptimizationsAttribKey : AttributeKey<_> = AttributeKey<_>("BitmapOptimizations")
    let FadeAnimationForCachedImagesAttribKey : AttributeKey<_> = AttributeKey<_>("FadeAnimationForCachedImages")
    let FadeAnimationEnabledAttribKey : AttributeKey<_> = AttributeKey<_>("FadeAnimationEnabled")
    let FadeAnimationDurationAttribKey : AttributeKey<_> = AttributeKey<_>("FadeAnimationDuration")
    let LoadingPlaceholderAttribKey : AttributeKey<_> = AttributeKey<_>("LoadingPlaceholder")
    let ErrorPlaceholderAttribKey : AttributeKey<_> = AttributeKey<_>("ErrorPlaceholder")
    let TransformPlaceholdersAttribKey : AttributeKey<_> = AttributeKey<_>("TransformPlaceholders")
    let TransformationsAttribKey : AttributeKey<_> = AttributeKey<_>("Transformations")
    let InvalidateLayoutAfterLoadedAttribKey : AttributeKey<_> = AttributeKey<_>("InvalidateLayoutAfterLoaded")
    let CacheTypeAttribKey : AttributeKey<_> = AttributeKey<_>("CacheType")

type ViewBuilders() =
    /// Builds the attributes for a CachedImage in the view
    static member inline BuildCachedImage(attribCount: int,
                                          ?aspect: Xamarin.Forms.Aspect,
                                          ?isOpaque: bool,
                                          ?source: Fabulous.XamarinForms.InputTypes.Image,
                                          ?retryCount: int,
                                          ?retryDelay: int,
                                          ?loadingDelay: int option,
                                          ?downsampleWidth: float,
                                          ?downsampleHeight: float,
                                          ?downsampleToViewSize: bool,
                                          ?downsampleUseDipUnits: bool,
                                          ?cacheDuration: System.TimeSpan option,
                                          ?loadingPriority: FFImageLoading.Work.LoadingPriority,
                                          ?bitmapOptimizations: bool option,
                                          ?fadeAnimationForCachedImages: bool option,
                                          ?fadeAnimationEnabled: bool option,
                                          ?fadeAnimationDuration: int option,
                                          ?loadingPlaceholder: Fabulous.XamarinForms.InputTypes.Image,
                                          ?errorPlaceholder: Fabulous.XamarinForms.InputTypes.Image,
                                          ?transformPlaceholders: bool option,
                                          ?transformations: System.Collections.Generic.List<FFImageLoading.Work.ITransformation>,
                                          ?invalidateLayoutAfterLoaded: bool option,
                                          ?cacheType: FFImageLoading.Cache.CacheType option,
                                          ?gestureRecognizers: ViewElement list,
                                          ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                          ?margin: Xamarin.Forms.Thickness,
                                          ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                          ?anchorX: float,
                                          ?anchorY: float,
                                          ?backgroundColor: Xamarin.Forms.Color,
                                          ?behaviors: ViewElement list,
                                          ?flowDirection: Xamarin.Forms.FlowDirection,
                                          ?height: float,
                                          ?inputTransparent: bool,
                                          ?isEnabled: bool,
                                          ?isTabStop: bool,
                                          ?isVisible: bool,
                                          ?minimumHeight: float,
                                          ?minimumWidth: float,
                                          ?opacity: float,
                                          ?resources: (string * obj) list,
                                          ?rotation: float,
                                          ?rotationX: float,
                                          ?rotationY: float,
                                          ?scale: float,
                                          ?scaleX: float,
                                          ?scaleY: float,
                                          ?styles: Xamarin.Forms.Style list,
                                          ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                          ?tabIndex: int,
                                          ?translationX: float,
                                          ?translationY: float,
                                          ?visual: Xamarin.Forms.IVisual,
                                          ?width: float,
                                          ?style: Xamarin.Forms.Style,
                                          ?styleClasses: string list,
                                          ?shellBackButtonBehavior: ViewElement,
                                          ?shellBackgroundColor: Xamarin.Forms.Color,
                                          ?shellDisabledColor: Xamarin.Forms.Color,
                                          ?shellForegroundColor: Xamarin.Forms.Color,
                                          ?shellFlyoutBehavior: Xamarin.Forms.FlyoutBehavior,
                                          ?shellNavBarIsVisible: bool,
                                          ?shellSearchHandler: ViewElement,
                                          ?shellTabBarBackgroundColor: Xamarin.Forms.Color,
                                          ?shellTabBarDisabledColor: Xamarin.Forms.Color,
                                          ?shellTabBarForegroundColor: Xamarin.Forms.Color,
                                          ?shellTabBarIsVisible: bool,
                                          ?shellTabBarTitleColor: Xamarin.Forms.Color,
                                          ?shellTabBarUnselectedColor: Xamarin.Forms.Color,
                                          ?shellTitleColor: Xamarin.Forms.Color,
                                          ?shellTitleView: ViewElement,
                                          ?shellUnselectedColor: Xamarin.Forms.Color,
                                          ?shellNavBarHasShadow: bool,
                                          ?automationId: string,
                                          ?classId: string,
                                          ?effects: ViewElement list,
                                          ?menu: ViewElement,
                                          ?styleId: string,
                                          ?ref: ViewRef,
                                          ?tag: obj,
                                          ?success: FFImageLoading.Forms.CachedImageEvents.SuccessEventArgs -> unit,
                                          ?error: FFImageLoading.Forms.CachedImageEvents.ErrorEventArgs -> unit,
                                          ?finish: FFImageLoading.Forms.CachedImageEvents.FinishEventArgs -> unit,
                                          ?downloadStarted: FFImageLoading.Forms.CachedImageEvents.DownloadStartedEventArgs -> unit,
                                          ?downloadProgress: FFImageLoading.Forms.CachedImageEvents.DownloadProgressEventArgs -> unit,
                                          ?fileWriteFinished: FFImageLoading.Forms.CachedImageEvents.FileWriteFinishedEventArgs -> unit,
                                          ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                          ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                          ?created: obj -> unit) = 

        let attribCount = match aspect with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isOpaque with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match source with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match retryCount with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match retryDelay with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match loadingDelay with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match downsampleWidth with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match downsampleHeight with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match downsampleToViewSize with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match downsampleUseDipUnits with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match cacheDuration with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match loadingPriority with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match bitmapOptimizations with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fadeAnimationForCachedImages with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fadeAnimationEnabled with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fadeAnimationDuration with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match loadingPlaceholder with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match errorPlaceholder with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match transformPlaceholders with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match transformations with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match invalidateLayoutAfterLoaded with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match cacheType with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match success with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match error with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match finish with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match downloadStarted with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match downloadProgress with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fileWriteFinished with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildView(attribCount, ?gestureRecognizers=gestureRecognizers, ?horizontalOptions=horizontalOptions, ?margin=margin, ?verticalOptions=verticalOptions, ?anchorX=anchorX, 
                                                   ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?behaviors=behaviors, ?flowDirection=flowDirection, ?height=height, 
                                                   ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isTabStop=isTabStop, ?isVisible=isVisible, ?minimumHeight=minimumHeight, 
                                                   ?minimumWidth=minimumWidth, ?opacity=opacity, ?resources=resources, ?rotation=rotation, ?rotationX=rotationX, 
                                                   ?rotationY=rotationY, ?scale=scale, ?scaleX=scaleX, ?scaleY=scaleY, ?styles=styles, 
                                                   ?styleSheets=styleSheets, ?tabIndex=tabIndex, ?translationX=translationX, ?translationY=translationY, ?visual=visual, 
                                                   ?width=width, ?style=style, ?styleClasses=styleClasses, ?shellBackButtonBehavior=shellBackButtonBehavior, ?shellBackgroundColor=shellBackgroundColor, 
                                                   ?shellDisabledColor=shellDisabledColor, ?shellForegroundColor=shellForegroundColor, ?shellFlyoutBehavior=shellFlyoutBehavior, ?shellNavBarIsVisible=shellNavBarIsVisible, ?shellSearchHandler=shellSearchHandler, 
                                                   ?shellTabBarBackgroundColor=shellTabBarBackgroundColor, ?shellTabBarDisabledColor=shellTabBarDisabledColor, ?shellTabBarForegroundColor=shellTabBarForegroundColor, ?shellTabBarIsVisible=shellTabBarIsVisible, ?shellTabBarTitleColor=shellTabBarTitleColor, 
                                                   ?shellTabBarUnselectedColor=shellTabBarUnselectedColor, ?shellTitleColor=shellTitleColor, ?shellTitleView=shellTitleView, ?shellUnselectedColor=shellUnselectedColor, ?shellNavBarHasShadow=shellNavBarHasShadow, 
                                                   ?automationId=automationId, ?classId=classId, ?effects=effects, ?menu=menu, ?styleId=styleId, 
                                                   ?ref=ref, ?tag=tag, ?focused=focused, ?unfocused=unfocused, ?created=created)
        match aspect with None -> () | Some v -> attribBuilder.Add(ViewAttributes.AspectAttribKey, (v)) 
        match isOpaque with None -> () | Some v -> attribBuilder.Add(ViewAttributes.IsOpaqueAttribKey, (v)) 
        match source with None -> () | Some v -> attribBuilder.Add(ViewAttributes.CachedImageSourceAttribKey, (v)) 
        match retryCount with None -> () | Some v -> attribBuilder.Add(ViewAttributes.RetryCountAttribKey, (v)) 
        match retryDelay with None -> () | Some v -> attribBuilder.Add(ViewAttributes.RetryDelayAttribKey, (v)) 
        match loadingDelay with None -> () | Some v -> attribBuilder.Add(ViewAttributes.LoadingDelayAttribKey, Option.toNullable(v)) 
        match downsampleWidth with None -> () | Some v -> attribBuilder.Add(ViewAttributes.DownsampleWidthAttribKey, (v)) 
        match downsampleHeight with None -> () | Some v -> attribBuilder.Add(ViewAttributes.DownsampleHeightAttribKey, (v)) 
        match downsampleToViewSize with None -> () | Some v -> attribBuilder.Add(ViewAttributes.DownsampleToViewSizeAttribKey, (v)) 
        match downsampleUseDipUnits with None -> () | Some v -> attribBuilder.Add(ViewAttributes.DownsampleUseDipUnitsAttribKey, (v)) 
        match cacheDuration with None -> () | Some v -> attribBuilder.Add(ViewAttributes.CacheDurationAttribKey, Option.toNullable(v)) 
        match loadingPriority with None -> () | Some v -> attribBuilder.Add(ViewAttributes.LoadingPriorityAttribKey, (v)) 
        match bitmapOptimizations with None -> () | Some v -> attribBuilder.Add(ViewAttributes.BitmapOptimizationsAttribKey, Option.toNullable(v)) 
        match fadeAnimationForCachedImages with None -> () | Some v -> attribBuilder.Add(ViewAttributes.FadeAnimationForCachedImagesAttribKey, Option.toNullable(v)) 
        match fadeAnimationEnabled with None -> () | Some v -> attribBuilder.Add(ViewAttributes.FadeAnimationEnabledAttribKey, Option.toNullable(v)) 
        match fadeAnimationDuration with None -> () | Some v -> attribBuilder.Add(ViewAttributes.FadeAnimationDurationAttribKey, Option.toNullable(v)) 
        match loadingPlaceholder with None -> () | Some v -> attribBuilder.Add(ViewAttributes.LoadingPlaceholderAttribKey, (v)) 
        match errorPlaceholder with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ErrorPlaceholderAttribKey, (v)) 
        match transformPlaceholders with None -> () | Some v -> attribBuilder.Add(ViewAttributes.TransformPlaceholdersAttribKey, Option.toNullable(v)) 
        match transformations with None -> () | Some v -> attribBuilder.Add(ViewAttributes.TransformationsAttribKey, (v)) 
        match invalidateLayoutAfterLoaded with None -> () | Some v -> attribBuilder.Add(ViewAttributes.InvalidateLayoutAfterLoadedAttribKey, Option.toNullable(v)) 
        match cacheType with None -> () | Some v -> attribBuilder.Add(ViewAttributes.CacheTypeAttribKey, Option.toNullable(v)) 
        match success with None -> () | Some v -> attribBuilder.Add(ViewAttributes.SuccessAttribKey, (fun f -> System.EventHandler<FFImageLoading.Forms.CachedImageEvents.SuccessEventArgs>(fun _sender _args -> f _args))(v)) 
        match error with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ErrorAttribKey, (fun f -> System.EventHandler<FFImageLoading.Forms.CachedImageEvents.ErrorEventArgs>(fun _sender _args -> f _args))(v)) 
        match finish with None -> () | Some v -> attribBuilder.Add(ViewAttributes.FinishAttribKey, (fun f -> System.EventHandler<FFImageLoading.Forms.CachedImageEvents.FinishEventArgs>(fun _sender _args -> f _args))(v)) 
        match downloadStarted with None -> () | Some v -> attribBuilder.Add(ViewAttributes.DownloadStartedAttribKey, (fun f -> System.EventHandler<FFImageLoading.Forms.CachedImageEvents.DownloadStartedEventArgs>(fun _sender _args -> f _args))(v)) 
        match downloadProgress with None -> () | Some v -> attribBuilder.Add(ViewAttributes.DownloadProgressAttribKey, (fun f -> System.EventHandler<FFImageLoading.Forms.CachedImageEvents.DownloadProgressEventArgs>(fun _sender _args -> f _args))(v)) 
        match fileWriteFinished with None -> () | Some v -> attribBuilder.Add(ViewAttributes.FileWriteFinishedAttribKey, (fun f -> System.EventHandler<FFImageLoading.Forms.CachedImageEvents.FileWriteFinishedEventArgs>(fun _sender _args -> f _args))(v)) 
        attribBuilder

    static member CreateCachedImage () : FFImageLoading.Forms.CachedImage =
        FFImageLoading.Forms.CachedImage()

    static member UpdateCachedImage (prevOpt: ViewElement voption, curr: ViewElement, target: FFImageLoading.Forms.CachedImage) = 
        let mutable prevSuccessOpt = ValueNone
        let mutable currSuccessOpt = ValueNone
        let mutable prevErrorOpt = ValueNone
        let mutable currErrorOpt = ValueNone
        let mutable prevFinishOpt = ValueNone
        let mutable currFinishOpt = ValueNone
        let mutable prevDownloadStartedOpt = ValueNone
        let mutable currDownloadStartedOpt = ValueNone
        let mutable prevDownloadProgressOpt = ValueNone
        let mutable currDownloadProgressOpt = ValueNone
        let mutable prevFileWriteFinishedOpt = ValueNone
        let mutable currFileWriteFinishedOpt = ValueNone
        let mutable prevAspectOpt = ValueNone
        let mutable currAspectOpt = ValueNone
        let mutable prevIsOpaqueOpt = ValueNone
        let mutable currIsOpaqueOpt = ValueNone
        let mutable prevCachedImageSourceOpt = ValueNone
        let mutable currCachedImageSourceOpt = ValueNone
        let mutable prevRetryCountOpt = ValueNone
        let mutable currRetryCountOpt = ValueNone
        let mutable prevRetryDelayOpt = ValueNone
        let mutable currRetryDelayOpt = ValueNone
        let mutable prevLoadingDelayOpt = ValueNone
        let mutable currLoadingDelayOpt = ValueNone
        let mutable prevDownsampleWidthOpt = ValueNone
        let mutable currDownsampleWidthOpt = ValueNone
        let mutable prevDownsampleHeightOpt = ValueNone
        let mutable currDownsampleHeightOpt = ValueNone
        let mutable prevDownsampleToViewSizeOpt = ValueNone
        let mutable currDownsampleToViewSizeOpt = ValueNone
        let mutable prevDownsampleUseDipUnitsOpt = ValueNone
        let mutable currDownsampleUseDipUnitsOpt = ValueNone
        let mutable prevCacheDurationOpt = ValueNone
        let mutable currCacheDurationOpt = ValueNone
        let mutable prevLoadingPriorityOpt = ValueNone
        let mutable currLoadingPriorityOpt = ValueNone
        let mutable prevBitmapOptimizationsOpt = ValueNone
        let mutable currBitmapOptimizationsOpt = ValueNone
        let mutable prevFadeAnimationForCachedImagesOpt = ValueNone
        let mutable currFadeAnimationForCachedImagesOpt = ValueNone
        let mutable prevFadeAnimationEnabledOpt = ValueNone
        let mutable currFadeAnimationEnabledOpt = ValueNone
        let mutable prevFadeAnimationDurationOpt = ValueNone
        let mutable currFadeAnimationDurationOpt = ValueNone
        let mutable prevLoadingPlaceholderOpt = ValueNone
        let mutable currLoadingPlaceholderOpt = ValueNone
        let mutable prevErrorPlaceholderOpt = ValueNone
        let mutable currErrorPlaceholderOpt = ValueNone
        let mutable prevTransformPlaceholdersOpt = ValueNone
        let mutable currTransformPlaceholdersOpt = ValueNone
        let mutable prevTransformationsOpt = ValueNone
        let mutable currTransformationsOpt = ValueNone
        let mutable prevInvalidateLayoutAfterLoadedOpt = ValueNone
        let mutable currInvalidateLayoutAfterLoadedOpt = ValueNone
        let mutable prevCacheTypeOpt = ValueNone
        let mutable currCacheTypeOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.SuccessAttribKey.KeyValue then 
                currSuccessOpt <- ValueSome (kvp.Value :?> System.EventHandler<FFImageLoading.Forms.CachedImageEvents.SuccessEventArgs>)
            if kvp.Key = ViewAttributes.ErrorAttribKey.KeyValue then 
                currErrorOpt <- ValueSome (kvp.Value :?> System.EventHandler<FFImageLoading.Forms.CachedImageEvents.ErrorEventArgs>)
            if kvp.Key = ViewAttributes.FinishAttribKey.KeyValue then 
                currFinishOpt <- ValueSome (kvp.Value :?> System.EventHandler<FFImageLoading.Forms.CachedImageEvents.FinishEventArgs>)
            if kvp.Key = ViewAttributes.DownloadStartedAttribKey.KeyValue then 
                currDownloadStartedOpt <- ValueSome (kvp.Value :?> System.EventHandler<FFImageLoading.Forms.CachedImageEvents.DownloadStartedEventArgs>)
            if kvp.Key = ViewAttributes.DownloadProgressAttribKey.KeyValue then 
                currDownloadProgressOpt <- ValueSome (kvp.Value :?> System.EventHandler<FFImageLoading.Forms.CachedImageEvents.DownloadProgressEventArgs>)
            if kvp.Key = ViewAttributes.FileWriteFinishedAttribKey.KeyValue then 
                currFileWriteFinishedOpt <- ValueSome (kvp.Value :?> System.EventHandler<FFImageLoading.Forms.CachedImageEvents.FileWriteFinishedEventArgs>)
            if kvp.Key = ViewAttributes.AspectAttribKey.KeyValue then 
                currAspectOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Aspect)
            if kvp.Key = ViewAttributes.IsOpaqueAttribKey.KeyValue then 
                currIsOpaqueOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = ViewAttributes.CachedImageSourceAttribKey.KeyValue then 
                currCachedImageSourceOpt <- ValueSome (kvp.Value :?> Fabulous.XamarinForms.InputTypes.Image)
            if kvp.Key = ViewAttributes.RetryCountAttribKey.KeyValue then 
                currRetryCountOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = ViewAttributes.RetryDelayAttribKey.KeyValue then 
                currRetryDelayOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = ViewAttributes.LoadingDelayAttribKey.KeyValue then 
                currLoadingDelayOpt <- ValueSome (kvp.Value :?> System.Nullable<int>)
            if kvp.Key = ViewAttributes.DownsampleWidthAttribKey.KeyValue then 
                currDownsampleWidthOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.DownsampleHeightAttribKey.KeyValue then 
                currDownsampleHeightOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.DownsampleToViewSizeAttribKey.KeyValue then 
                currDownsampleToViewSizeOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = ViewAttributes.DownsampleUseDipUnitsAttribKey.KeyValue then 
                currDownsampleUseDipUnitsOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = ViewAttributes.CacheDurationAttribKey.KeyValue then 
                currCacheDurationOpt <- ValueSome (kvp.Value :?> System.Nullable<System.TimeSpan>)
            if kvp.Key = ViewAttributes.LoadingPriorityAttribKey.KeyValue then 
                currLoadingPriorityOpt <- ValueSome (kvp.Value :?> FFImageLoading.Work.LoadingPriority)
            if kvp.Key = ViewAttributes.BitmapOptimizationsAttribKey.KeyValue then 
                currBitmapOptimizationsOpt <- ValueSome (kvp.Value :?> System.Nullable<bool>)
            if kvp.Key = ViewAttributes.FadeAnimationForCachedImagesAttribKey.KeyValue then 
                currFadeAnimationForCachedImagesOpt <- ValueSome (kvp.Value :?> System.Nullable<bool>)
            if kvp.Key = ViewAttributes.FadeAnimationEnabledAttribKey.KeyValue then 
                currFadeAnimationEnabledOpt <- ValueSome (kvp.Value :?> System.Nullable<bool>)
            if kvp.Key = ViewAttributes.FadeAnimationDurationAttribKey.KeyValue then 
                currFadeAnimationDurationOpt <- ValueSome (kvp.Value :?> System.Nullable<int>)
            if kvp.Key = ViewAttributes.LoadingPlaceholderAttribKey.KeyValue then 
                currLoadingPlaceholderOpt <- ValueSome (kvp.Value :?> Fabulous.XamarinForms.InputTypes.Image)
            if kvp.Key = ViewAttributes.ErrorPlaceholderAttribKey.KeyValue then 
                currErrorPlaceholderOpt <- ValueSome (kvp.Value :?> Fabulous.XamarinForms.InputTypes.Image)
            if kvp.Key = ViewAttributes.TransformPlaceholdersAttribKey.KeyValue then 
                currTransformPlaceholdersOpt <- ValueSome (kvp.Value :?> System.Nullable<bool>)
            if kvp.Key = ViewAttributes.TransformationsAttribKey.KeyValue then 
                currTransformationsOpt <- ValueSome (kvp.Value :?> System.Collections.Generic.List<FFImageLoading.Work.ITransformation>)
            if kvp.Key = ViewAttributes.InvalidateLayoutAfterLoadedAttribKey.KeyValue then 
                currInvalidateLayoutAfterLoadedOpt <- ValueSome (kvp.Value :?> System.Nullable<bool>)
            if kvp.Key = ViewAttributes.CacheTypeAttribKey.KeyValue then 
                currCacheTypeOpt <- ValueSome (kvp.Value :?> System.Nullable<FFImageLoading.Cache.CacheType>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.SuccessAttribKey.KeyValue then 
                    prevSuccessOpt <- ValueSome (kvp.Value :?> System.EventHandler<FFImageLoading.Forms.CachedImageEvents.SuccessEventArgs>)
                if kvp.Key = ViewAttributes.ErrorAttribKey.KeyValue then 
                    prevErrorOpt <- ValueSome (kvp.Value :?> System.EventHandler<FFImageLoading.Forms.CachedImageEvents.ErrorEventArgs>)
                if kvp.Key = ViewAttributes.FinishAttribKey.KeyValue then 
                    prevFinishOpt <- ValueSome (kvp.Value :?> System.EventHandler<FFImageLoading.Forms.CachedImageEvents.FinishEventArgs>)
                if kvp.Key = ViewAttributes.DownloadStartedAttribKey.KeyValue then 
                    prevDownloadStartedOpt <- ValueSome (kvp.Value :?> System.EventHandler<FFImageLoading.Forms.CachedImageEvents.DownloadStartedEventArgs>)
                if kvp.Key = ViewAttributes.DownloadProgressAttribKey.KeyValue then 
                    prevDownloadProgressOpt <- ValueSome (kvp.Value :?> System.EventHandler<FFImageLoading.Forms.CachedImageEvents.DownloadProgressEventArgs>)
                if kvp.Key = ViewAttributes.FileWriteFinishedAttribKey.KeyValue then 
                    prevFileWriteFinishedOpt <- ValueSome (kvp.Value :?> System.EventHandler<FFImageLoading.Forms.CachedImageEvents.FileWriteFinishedEventArgs>)
                if kvp.Key = ViewAttributes.AspectAttribKey.KeyValue then 
                    prevAspectOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Aspect)
                if kvp.Key = ViewAttributes.IsOpaqueAttribKey.KeyValue then 
                    prevIsOpaqueOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = ViewAttributes.CachedImageSourceAttribKey.KeyValue then 
                    prevCachedImageSourceOpt <- ValueSome (kvp.Value :?> Fabulous.XamarinForms.InputTypes.Image)
                if kvp.Key = ViewAttributes.RetryCountAttribKey.KeyValue then 
                    prevRetryCountOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = ViewAttributes.RetryDelayAttribKey.KeyValue then 
                    prevRetryDelayOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = ViewAttributes.LoadingDelayAttribKey.KeyValue then 
                    prevLoadingDelayOpt <- ValueSome (kvp.Value :?> System.Nullable<int>)
                if kvp.Key = ViewAttributes.DownsampleWidthAttribKey.KeyValue then 
                    prevDownsampleWidthOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.DownsampleHeightAttribKey.KeyValue then 
                    prevDownsampleHeightOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.DownsampleToViewSizeAttribKey.KeyValue then 
                    prevDownsampleToViewSizeOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = ViewAttributes.DownsampleUseDipUnitsAttribKey.KeyValue then 
                    prevDownsampleUseDipUnitsOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = ViewAttributes.CacheDurationAttribKey.KeyValue then 
                    prevCacheDurationOpt <- ValueSome (kvp.Value :?> System.Nullable<System.TimeSpan>)
                if kvp.Key = ViewAttributes.LoadingPriorityAttribKey.KeyValue then 
                    prevLoadingPriorityOpt <- ValueSome (kvp.Value :?> FFImageLoading.Work.LoadingPriority)
                if kvp.Key = ViewAttributes.BitmapOptimizationsAttribKey.KeyValue then 
                    prevBitmapOptimizationsOpt <- ValueSome (kvp.Value :?> System.Nullable<bool>)
                if kvp.Key = ViewAttributes.FadeAnimationForCachedImagesAttribKey.KeyValue then 
                    prevFadeAnimationForCachedImagesOpt <- ValueSome (kvp.Value :?> System.Nullable<bool>)
                if kvp.Key = ViewAttributes.FadeAnimationEnabledAttribKey.KeyValue then 
                    prevFadeAnimationEnabledOpt <- ValueSome (kvp.Value :?> System.Nullable<bool>)
                if kvp.Key = ViewAttributes.FadeAnimationDurationAttribKey.KeyValue then 
                    prevFadeAnimationDurationOpt <- ValueSome (kvp.Value :?> System.Nullable<int>)
                if kvp.Key = ViewAttributes.LoadingPlaceholderAttribKey.KeyValue then 
                    prevLoadingPlaceholderOpt <- ValueSome (kvp.Value :?> Fabulous.XamarinForms.InputTypes.Image)
                if kvp.Key = ViewAttributes.ErrorPlaceholderAttribKey.KeyValue then 
                    prevErrorPlaceholderOpt <- ValueSome (kvp.Value :?> Fabulous.XamarinForms.InputTypes.Image)
                if kvp.Key = ViewAttributes.TransformPlaceholdersAttribKey.KeyValue then 
                    prevTransformPlaceholdersOpt <- ValueSome (kvp.Value :?> System.Nullable<bool>)
                if kvp.Key = ViewAttributes.TransformationsAttribKey.KeyValue then 
                    prevTransformationsOpt <- ValueSome (kvp.Value :?> System.Collections.Generic.List<FFImageLoading.Work.ITransformation>)
                if kvp.Key = ViewAttributes.InvalidateLayoutAfterLoadedAttribKey.KeyValue then 
                    prevInvalidateLayoutAfterLoadedOpt <- ValueSome (kvp.Value :?> System.Nullable<bool>)
                if kvp.Key = ViewAttributes.CacheTypeAttribKey.KeyValue then 
                    prevCacheTypeOpt <- ValueSome (kvp.Value :?> System.Nullable<FFImageLoading.Cache.CacheType>)
        // Unsubscribe previous event handlers
        let shouldUpdateSuccess = not ((identical prevSuccessOpt currSuccessOpt))
        if shouldUpdateSuccess then
            match prevSuccessOpt with
            | ValueSome prevValue -> target.Success.RemoveHandler(prevValue)
            | ValueNone -> ()
        let shouldUpdateError = not ((identical prevErrorOpt currErrorOpt))
        if shouldUpdateError then
            match prevErrorOpt with
            | ValueSome prevValue -> target.Error.RemoveHandler(prevValue)
            | ValueNone -> ()
        let shouldUpdateFinish = not ((identical prevFinishOpt currFinishOpt))
        if shouldUpdateFinish then
            match prevFinishOpt with
            | ValueSome prevValue -> target.Finish.RemoveHandler(prevValue)
            | ValueNone -> ()
        let shouldUpdateDownloadStarted = not ((identical prevDownloadStartedOpt currDownloadStartedOpt))
        if shouldUpdateDownloadStarted then
            match prevDownloadStartedOpt with
            | ValueSome prevValue -> target.DownloadStarted.RemoveHandler(prevValue)
            | ValueNone -> ()
        let shouldUpdateDownloadProgress = not ((identical prevDownloadProgressOpt currDownloadProgressOpt))
        if shouldUpdateDownloadProgress then
            match prevDownloadProgressOpt with
            | ValueSome prevValue -> target.DownloadProgress.RemoveHandler(prevValue)
            | ValueNone -> ()
        let shouldUpdateFileWriteFinished = not ((identical prevFileWriteFinishedOpt currFileWriteFinishedOpt))
        if shouldUpdateFileWriteFinished then
            match prevFileWriteFinishedOpt with
            | ValueSome prevValue -> target.FileWriteFinished.RemoveHandler(prevValue)
            | ValueNone -> ()
        // Update inherited members
        ViewBuilders.UpdateView (prevOpt, curr, target)
        // Update properties
        match prevAspectOpt, currAspectOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Aspect <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue FFImageLoading.Forms.CachedImage.AspectProperty
        | ValueNone, ValueNone -> ()
        match prevIsOpaqueOpt, currIsOpaqueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsOpaque <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue FFImageLoading.Forms.CachedImage.IsOpaqueProperty
        | ValueNone, ValueNone -> ()
        match prevCachedImageSourceOpt, currCachedImageSourceOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Source <- ViewConverters.convertFabulousImageToXamarinFormsImageSource currValue
        | ValueSome _, ValueNone -> target.ClearValue FFImageLoading.Forms.CachedImage.SourceProperty
        | ValueNone, ValueNone -> ()
        match prevRetryCountOpt, currRetryCountOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.RetryCount <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue FFImageLoading.Forms.CachedImage.RetryCountProperty
        | ValueNone, ValueNone -> ()
        match prevRetryDelayOpt, currRetryDelayOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.RetryDelay <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue FFImageLoading.Forms.CachedImage.RetryDelayProperty
        | ValueNone, ValueNone -> ()
        match prevLoadingDelayOpt, currLoadingDelayOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.LoadingDelay <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue FFImageLoading.Forms.CachedImage.LoadingDelayProperty
        | ValueNone, ValueNone -> ()
        match prevDownsampleWidthOpt, currDownsampleWidthOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.DownsampleWidth <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue FFImageLoading.Forms.CachedImage.DownsampleWidthProperty
        | ValueNone, ValueNone -> ()
        match prevDownsampleHeightOpt, currDownsampleHeightOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.DownsampleHeight <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue FFImageLoading.Forms.CachedImage.DownsampleHeightProperty
        | ValueNone, ValueNone -> ()
        match prevDownsampleToViewSizeOpt, currDownsampleToViewSizeOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.DownsampleToViewSize <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue FFImageLoading.Forms.CachedImage.DownsampleToViewSizeProperty
        | ValueNone, ValueNone -> ()
        match prevDownsampleUseDipUnitsOpt, currDownsampleUseDipUnitsOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.DownsampleUseDipUnits <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue FFImageLoading.Forms.CachedImage.DownsampleUseDipUnitsProperty
        | ValueNone, ValueNone -> ()
        match prevCacheDurationOpt, currCacheDurationOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.CacheDuration <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue FFImageLoading.Forms.CachedImage.CacheDurationProperty
        | ValueNone, ValueNone -> ()
        match prevLoadingPriorityOpt, currLoadingPriorityOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.LoadingPriority <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue FFImageLoading.Forms.CachedImage.LoadingPriorityProperty
        | ValueNone, ValueNone -> ()
        match prevBitmapOptimizationsOpt, currBitmapOptimizationsOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.BitmapOptimizations <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue FFImageLoading.Forms.CachedImage.BitmapOptimizationsProperty
        | ValueNone, ValueNone -> ()
        match prevFadeAnimationForCachedImagesOpt, currFadeAnimationForCachedImagesOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.FadeAnimationForCachedImages <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue FFImageLoading.Forms.CachedImage.FadeAnimationForCachedImagesProperty
        | ValueNone, ValueNone -> ()
        match prevFadeAnimationEnabledOpt, currFadeAnimationEnabledOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.FadeAnimationEnabled <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue FFImageLoading.Forms.CachedImage.FadeAnimationEnabledProperty
        | ValueNone, ValueNone -> ()
        match prevFadeAnimationDurationOpt, currFadeAnimationDurationOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.FadeAnimationDuration <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue FFImageLoading.Forms.CachedImage.FadeAnimationDurationProperty
        | ValueNone, ValueNone -> ()
        match prevLoadingPlaceholderOpt, currLoadingPlaceholderOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.LoadingPlaceholder <- ViewConverters.convertFabulousImageToXamarinFormsImageSource currValue
        | ValueSome _, ValueNone -> target.ClearValue FFImageLoading.Forms.CachedImage.LoadingPlaceholderProperty
        | ValueNone, ValueNone -> ()
        match prevErrorPlaceholderOpt, currErrorPlaceholderOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.ErrorPlaceholder <- ViewConverters.convertFabulousImageToXamarinFormsImageSource currValue
        | ValueSome _, ValueNone -> target.ClearValue FFImageLoading.Forms.CachedImage.ErrorPlaceholderProperty
        | ValueNone, ValueNone -> ()
        match prevTransformPlaceholdersOpt, currTransformPlaceholdersOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.TransformPlaceholders <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue FFImageLoading.Forms.CachedImage.TransformPlaceholdersProperty
        | ValueNone, ValueNone -> ()
        match prevTransformationsOpt, currTransformationsOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Transformations <-  currValue
        | ValueSome _, ValueNone -> target.Transformations <- System.Collections.Generic.List<FFImageLoading.Work.ITransformation>()
        | ValueNone, ValueNone -> ()
        match prevInvalidateLayoutAfterLoadedOpt, currInvalidateLayoutAfterLoadedOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.InvalidateLayoutAfterLoaded <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue FFImageLoading.Forms.CachedImage.InvalidateLayoutAfterLoadedProperty
        | ValueNone, ValueNone -> ()
        match prevCacheTypeOpt, currCacheTypeOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.CacheType <-  currValue
        | ValueSome _, ValueNone -> target.ClearValue FFImageLoading.Forms.CachedImage.CacheTypeProperty
        | ValueNone, ValueNone -> ()
        // Subscribe new event handlers
        if shouldUpdateSuccess then
            match currSuccessOpt with
            | ValueSome currValue -> target.Success.AddHandler(currValue)
            | ValueNone -> ()
        if shouldUpdateError then
            match currErrorOpt with
            | ValueSome currValue -> target.Error.AddHandler(currValue)
            | ValueNone -> ()
        if shouldUpdateFinish then
            match currFinishOpt with
            | ValueSome currValue -> target.Finish.AddHandler(currValue)
            | ValueNone -> ()
        if shouldUpdateDownloadStarted then
            match currDownloadStartedOpt with
            | ValueSome currValue -> target.DownloadStarted.AddHandler(currValue)
            | ValueNone -> ()
        if shouldUpdateDownloadProgress then
            match currDownloadProgressOpt with
            | ValueSome currValue -> target.DownloadProgress.AddHandler(currValue)
            | ValueNone -> ()
        if shouldUpdateFileWriteFinished then
            match currFileWriteFinishedOpt with
            | ValueSome currValue -> target.FileWriteFinished.AddHandler(currValue)
            | ValueNone -> ()

    static member inline ConstructCachedImage(?aspect: Xamarin.Forms.Aspect,
                                              ?isOpaque: bool,
                                              ?source: Fabulous.XamarinForms.InputTypes.Image,
                                              ?retryCount: int,
                                              ?retryDelay: int,
                                              ?loadingDelay: int option,
                                              ?downsampleWidth: float,
                                              ?downsampleHeight: float,
                                              ?downsampleToViewSize: bool,
                                              ?downsampleUseDipUnits: bool,
                                              ?cacheDuration: System.TimeSpan option,
                                              ?loadingPriority: FFImageLoading.Work.LoadingPriority,
                                              ?bitmapOptimizations: bool option,
                                              ?fadeAnimationForCachedImages: bool option,
                                              ?fadeAnimationEnabled: bool option,
                                              ?fadeAnimationDuration: int option,
                                              ?loadingPlaceholder: Fabulous.XamarinForms.InputTypes.Image,
                                              ?errorPlaceholder: Fabulous.XamarinForms.InputTypes.Image,
                                              ?transformPlaceholders: bool option,
                                              ?transformations: System.Collections.Generic.List<FFImageLoading.Work.ITransformation>,
                                              ?invalidateLayoutAfterLoaded: bool option,
                                              ?cacheType: FFImageLoading.Cache.CacheType option,
                                              ?gestureRecognizers: ViewElement list,
                                              ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                              ?margin: Xamarin.Forms.Thickness,
                                              ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                              ?anchorX: float,
                                              ?anchorY: float,
                                              ?backgroundColor: Xamarin.Forms.Color,
                                              ?behaviors: ViewElement list,
                                              ?flowDirection: Xamarin.Forms.FlowDirection,
                                              ?height: float,
                                              ?inputTransparent: bool,
                                              ?isEnabled: bool,
                                              ?isTabStop: bool,
                                              ?isVisible: bool,
                                              ?minimumHeight: float,
                                              ?minimumWidth: float,
                                              ?opacity: float,
                                              ?resources: (string * obj) list,
                                              ?rotation: float,
                                              ?rotationX: float,
                                              ?rotationY: float,
                                              ?scale: float,
                                              ?scaleX: float,
                                              ?scaleY: float,
                                              ?styles: Xamarin.Forms.Style list,
                                              ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                              ?tabIndex: int,
                                              ?translationX: float,
                                              ?translationY: float,
                                              ?visual: Xamarin.Forms.IVisual,
                                              ?width: float,
                                              ?style: Xamarin.Forms.Style,
                                              ?styleClasses: string list,
                                              ?shellBackButtonBehavior: ViewElement,
                                              ?shellBackgroundColor: Xamarin.Forms.Color,
                                              ?shellDisabledColor: Xamarin.Forms.Color,
                                              ?shellForegroundColor: Xamarin.Forms.Color,
                                              ?shellFlyoutBehavior: Xamarin.Forms.FlyoutBehavior,
                                              ?shellNavBarIsVisible: bool,
                                              ?shellSearchHandler: ViewElement,
                                              ?shellTabBarBackgroundColor: Xamarin.Forms.Color,
                                              ?shellTabBarDisabledColor: Xamarin.Forms.Color,
                                              ?shellTabBarForegroundColor: Xamarin.Forms.Color,
                                              ?shellTabBarIsVisible: bool,
                                              ?shellTabBarTitleColor: Xamarin.Forms.Color,
                                              ?shellTabBarUnselectedColor: Xamarin.Forms.Color,
                                              ?shellTitleColor: Xamarin.Forms.Color,
                                              ?shellTitleView: ViewElement,
                                              ?shellUnselectedColor: Xamarin.Forms.Color,
                                              ?shellNavBarHasShadow: bool,
                                              ?automationId: string,
                                              ?classId: string,
                                              ?effects: ViewElement list,
                                              ?menu: ViewElement,
                                              ?styleId: string,
                                              ?ref: ViewRef<FFImageLoading.Forms.CachedImage>,
                                              ?tag: obj,
                                              ?success: FFImageLoading.Forms.CachedImageEvents.SuccessEventArgs -> unit,
                                              ?error: FFImageLoading.Forms.CachedImageEvents.ErrorEventArgs -> unit,
                                              ?finish: FFImageLoading.Forms.CachedImageEvents.FinishEventArgs -> unit,
                                              ?downloadStarted: FFImageLoading.Forms.CachedImageEvents.DownloadStartedEventArgs -> unit,
                                              ?downloadProgress: FFImageLoading.Forms.CachedImageEvents.DownloadProgressEventArgs -> unit,
                                              ?fileWriteFinished: FFImageLoading.Forms.CachedImageEvents.FileWriteFinishedEventArgs -> unit,
                                              ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                              ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                              ?created: (FFImageLoading.Forms.CachedImage -> unit)) = 

        let attribBuilder = ViewBuilders.BuildCachedImage(0,
                               ?aspect=aspect,
                               ?isOpaque=isOpaque,
                               ?source=source,
                               ?retryCount=retryCount,
                               ?retryDelay=retryDelay,
                               ?loadingDelay=loadingDelay,
                               ?downsampleWidth=downsampleWidth,
                               ?downsampleHeight=downsampleHeight,
                               ?downsampleToViewSize=downsampleToViewSize,
                               ?downsampleUseDipUnits=downsampleUseDipUnits,
                               ?cacheDuration=cacheDuration,
                               ?loadingPriority=loadingPriority,
                               ?bitmapOptimizations=bitmapOptimizations,
                               ?fadeAnimationForCachedImages=fadeAnimationForCachedImages,
                               ?fadeAnimationEnabled=fadeAnimationEnabled,
                               ?fadeAnimationDuration=fadeAnimationDuration,
                               ?loadingPlaceholder=loadingPlaceholder,
                               ?errorPlaceholder=errorPlaceholder,
                               ?transformPlaceholders=transformPlaceholders,
                               ?transformations=transformations,
                               ?invalidateLayoutAfterLoaded=invalidateLayoutAfterLoaded,
                               ?cacheType=cacheType,
                               ?gestureRecognizers=gestureRecognizers,
                               ?horizontalOptions=horizontalOptions,
                               ?margin=margin,
                               ?verticalOptions=verticalOptions,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?behaviors=behaviors,
                               ?flowDirection=flowDirection,
                               ?height=height,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isTabStop=isTabStop,
                               ?isVisible=isVisible,
                               ?minimumHeight=minimumHeight,
                               ?minimumWidth=minimumWidth,
                               ?opacity=opacity,
                               ?resources=resources,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?tabIndex=tabIndex,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?visual=visual,
                               ?width=width,
                               ?style=style,
                               ?styleClasses=styleClasses,
                               ?shellBackButtonBehavior=shellBackButtonBehavior,
                               ?shellBackgroundColor=shellBackgroundColor,
                               ?shellDisabledColor=shellDisabledColor,
                               ?shellForegroundColor=shellForegroundColor,
                               ?shellFlyoutBehavior=shellFlyoutBehavior,
                               ?shellNavBarIsVisible=shellNavBarIsVisible,
                               ?shellSearchHandler=shellSearchHandler,
                               ?shellTabBarBackgroundColor=shellTabBarBackgroundColor,
                               ?shellTabBarDisabledColor=shellTabBarDisabledColor,
                               ?shellTabBarForegroundColor=shellTabBarForegroundColor,
                               ?shellTabBarIsVisible=shellTabBarIsVisible,
                               ?shellTabBarTitleColor=shellTabBarTitleColor,
                               ?shellTabBarUnselectedColor=shellTabBarUnselectedColor,
                               ?shellTitleColor=shellTitleColor,
                               ?shellTitleView=shellTitleView,
                               ?shellUnselectedColor=shellUnselectedColor,
                               ?shellNavBarHasShadow=shellNavBarHasShadow,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?effects=effects,
                               ?menu=menu,
                               ?styleId=styleId,
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<FFImageLoading.Forms.CachedImage>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?success=success,
                               ?error=error,
                               ?finish=finish,
                               ?downloadStarted=downloadStarted,
                               ?downloadProgress=downloadProgress,
                               ?fileWriteFinished=fileWriteFinished,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<FFImageLoading.Forms.CachedImage> target))))

        ViewElement.Create<FFImageLoading.Forms.CachedImage>(ViewBuilders.CreateCachedImage, (fun prevOpt curr target -> ViewBuilders.UpdateCachedImage(prevOpt, curr, target)), attribBuilder)

/// Viewer that allows to read the properties of a ViewElement representing a CachedImage
type CachedImageViewer(element: ViewElement) =
    inherit ViewViewer(element)
    do if not ((typeof<FFImageLoading.Forms.CachedImage>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'FFImageLoading.Forms.CachedImage' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the Aspect member
    member this.Aspect = element.GetAttributeKeyed(ViewAttributes.AspectAttribKey)
    /// Get the value of the IsOpaque member
    member this.IsOpaque = element.GetAttributeKeyed(ViewAttributes.IsOpaqueAttribKey)
    /// Get the value of the Source member
    member this.Source = element.GetAttributeKeyed(ViewAttributes.CachedImageSourceAttribKey)
    /// Get the value of the RetryCount member
    member this.RetryCount = element.GetAttributeKeyed(ViewAttributes.RetryCountAttribKey)
    /// Get the value of the RetryDelay member
    member this.RetryDelay = element.GetAttributeKeyed(ViewAttributes.RetryDelayAttribKey)
    /// Get the value of the LoadingDelay member
    member this.LoadingDelay = element.GetAttributeKeyed(ViewAttributes.LoadingDelayAttribKey)
    /// Get the value of the DownsampleWidth member
    member this.DownsampleWidth = element.GetAttributeKeyed(ViewAttributes.DownsampleWidthAttribKey)
    /// Get the value of the DownsampleHeight member
    member this.DownsampleHeight = element.GetAttributeKeyed(ViewAttributes.DownsampleHeightAttribKey)
    /// Get the value of the DownsampleToViewSize member
    member this.DownsampleToViewSize = element.GetAttributeKeyed(ViewAttributes.DownsampleToViewSizeAttribKey)
    /// Get the value of the DownsampleUseDipUnits member
    member this.DownsampleUseDipUnits = element.GetAttributeKeyed(ViewAttributes.DownsampleUseDipUnitsAttribKey)
    /// Get the value of the CacheDuration member
    member this.CacheDuration = element.GetAttributeKeyed(ViewAttributes.CacheDurationAttribKey)
    /// Get the value of the LoadingPriority member
    member this.LoadingPriority = element.GetAttributeKeyed(ViewAttributes.LoadingPriorityAttribKey)
    /// Get the value of the BitmapOptimizations member
    member this.BitmapOptimizations = element.GetAttributeKeyed(ViewAttributes.BitmapOptimizationsAttribKey)
    /// Get the value of the FadeAnimationForCachedImages member
    member this.FadeAnimationForCachedImages = element.GetAttributeKeyed(ViewAttributes.FadeAnimationForCachedImagesAttribKey)
    /// Get the value of the FadeAnimationEnabled member
    member this.FadeAnimationEnabled = element.GetAttributeKeyed(ViewAttributes.FadeAnimationEnabledAttribKey)
    /// Get the value of the FadeAnimationDuration member
    member this.FadeAnimationDuration = element.GetAttributeKeyed(ViewAttributes.FadeAnimationDurationAttribKey)
    /// Get the value of the LoadingPlaceholder member
    member this.LoadingPlaceholder = element.GetAttributeKeyed(ViewAttributes.LoadingPlaceholderAttribKey)
    /// Get the value of the ErrorPlaceholder member
    member this.ErrorPlaceholder = element.GetAttributeKeyed(ViewAttributes.ErrorPlaceholderAttribKey)
    /// Get the value of the TransformPlaceholders member
    member this.TransformPlaceholders = element.GetAttributeKeyed(ViewAttributes.TransformPlaceholdersAttribKey)
    /// Get the value of the Transformations member
    member this.Transformations = element.GetAttributeKeyed(ViewAttributes.TransformationsAttribKey)
    /// Get the value of the InvalidateLayoutAfterLoaded member
    member this.InvalidateLayoutAfterLoaded = element.GetAttributeKeyed(ViewAttributes.InvalidateLayoutAfterLoadedAttribKey)
    /// Get the value of the CacheType member
    member this.CacheType = element.GetAttributeKeyed(ViewAttributes.CacheTypeAttribKey)
    /// Get the value of the Success member
    member this.Success = element.GetAttributeKeyed(ViewAttributes.SuccessAttribKey)
    /// Get the value of the Error member
    member this.Error = element.GetAttributeKeyed(ViewAttributes.ErrorAttribKey)
    /// Get the value of the Finish member
    member this.Finish = element.GetAttributeKeyed(ViewAttributes.FinishAttribKey)
    /// Get the value of the DownloadStarted member
    member this.DownloadStarted = element.GetAttributeKeyed(ViewAttributes.DownloadStartedAttribKey)
    /// Get the value of the DownloadProgress member
    member this.DownloadProgress = element.GetAttributeKeyed(ViewAttributes.DownloadProgressAttribKey)
    /// Get the value of the FileWriteFinished member
    member this.FileWriteFinished = element.GetAttributeKeyed(ViewAttributes.FileWriteFinishedAttribKey)

[<AbstractClass; Sealed>]
type View private () =
    /// Describes a CachedImage in the view
    static member inline CachedImage(?anchorX: float,
                                     ?anchorY: float,
                                     ?aspect: Xamarin.Forms.Aspect,
                                     ?automationId: string,
                                     ?backgroundColor: Xamarin.Forms.Color,
                                     ?behaviors: ViewElement list,
                                     ?bitmapOptimizations: bool option,
                                     ?cacheDuration: System.TimeSpan option,
                                     ?cacheType: FFImageLoading.Cache.CacheType option,
                                     ?classId: string,
                                     ?created: (FFImageLoading.Forms.CachedImage -> unit),
                                     ?downloadProgress: FFImageLoading.Forms.CachedImageEvents.DownloadProgressEventArgs -> unit,
                                     ?downloadStarted: FFImageLoading.Forms.CachedImageEvents.DownloadStartedEventArgs -> unit,
                                     ?downsampleHeight: float,
                                     ?downsampleToViewSize: bool,
                                     ?downsampleUseDipUnits: bool,
                                     ?downsampleWidth: float,
                                     ?effects: ViewElement list,
                                     ?error: FFImageLoading.Forms.CachedImageEvents.ErrorEventArgs -> unit,
                                     ?errorPlaceholder: Fabulous.XamarinForms.InputTypes.Image,
                                     ?fadeAnimationDuration: int option,
                                     ?fadeAnimationEnabled: bool option,
                                     ?fadeAnimationForCachedImages: bool option,
                                     ?fileWriteFinished: FFImageLoading.Forms.CachedImageEvents.FileWriteFinishedEventArgs -> unit,
                                     ?finish: FFImageLoading.Forms.CachedImageEvents.FinishEventArgs -> unit,
                                     ?flowDirection: Xamarin.Forms.FlowDirection,
                                     ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                     ?gestureRecognizers: ViewElement list,
                                     ?height: float,
                                     ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                     ?inputTransparent: bool,
                                     ?invalidateLayoutAfterLoaded: bool option,
                                     ?isEnabled: bool,
                                     ?isOpaque: bool,
                                     ?isTabStop: bool,
                                     ?isVisible: bool,
                                     ?loadingDelay: int option,
                                     ?loadingPlaceholder: Fabulous.XamarinForms.InputTypes.Image,
                                     ?loadingPriority: FFImageLoading.Work.LoadingPriority,
                                     ?margin: Xamarin.Forms.Thickness,
                                     ?menu: ViewElement,
                                     ?minimumHeight: float,
                                     ?minimumWidth: float,
                                     ?opacity: float,
                                     ?ref: ViewRef<FFImageLoading.Forms.CachedImage>,
                                     ?resources: (string * obj) list,
                                     ?retryCount: int,
                                     ?retryDelay: int,
                                     ?rotation: float,
                                     ?rotationX: float,
                                     ?rotationY: float,
                                     ?scale: float,
                                     ?scaleX: float,
                                     ?scaleY: float,
                                     ?shellBackButtonBehavior: ViewElement,
                                     ?shellBackgroundColor: Xamarin.Forms.Color,
                                     ?shellDisabledColor: Xamarin.Forms.Color,
                                     ?shellFlyoutBehavior: Xamarin.Forms.FlyoutBehavior,
                                     ?shellForegroundColor: Xamarin.Forms.Color,
                                     ?shellNavBarHasShadow: bool,
                                     ?shellNavBarIsVisible: bool,
                                     ?shellSearchHandler: ViewElement,
                                     ?shellTabBarBackgroundColor: Xamarin.Forms.Color,
                                     ?shellTabBarDisabledColor: Xamarin.Forms.Color,
                                     ?shellTabBarForegroundColor: Xamarin.Forms.Color,
                                     ?shellTabBarIsVisible: bool,
                                     ?shellTabBarTitleColor: Xamarin.Forms.Color,
                                     ?shellTabBarUnselectedColor: Xamarin.Forms.Color,
                                     ?shellTitleColor: Xamarin.Forms.Color,
                                     ?shellTitleView: ViewElement,
                                     ?shellUnselectedColor: Xamarin.Forms.Color,
                                     ?source: Fabulous.XamarinForms.InputTypes.Image,
                                     ?style: Xamarin.Forms.Style,
                                     ?styleClasses: string list,
                                     ?styleId: string,
                                     ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                     ?styles: Xamarin.Forms.Style list,
                                     ?success: FFImageLoading.Forms.CachedImageEvents.SuccessEventArgs -> unit,
                                     ?tabIndex: int,
                                     ?tag: obj,
                                     ?transformPlaceholders: bool option,
                                     ?transformations: System.Collections.Generic.List<FFImageLoading.Work.ITransformation>,
                                     ?translationX: float,
                                     ?translationY: float,
                                     ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                     ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                     ?visual: Xamarin.Forms.IVisual,
                                     ?width: float) =

        ViewBuilders.ConstructCachedImage(?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?aspect=aspect,
                               ?automationId=automationId,
                               ?backgroundColor=backgroundColor,
                               ?behaviors=behaviors,
                               ?bitmapOptimizations=bitmapOptimizations,
                               ?cacheDuration=cacheDuration,
                               ?cacheType=cacheType,
                               ?classId=classId,
                               ?created=created,
                               ?downloadProgress=downloadProgress,
                               ?downloadStarted=downloadStarted,
                               ?downsampleHeight=downsampleHeight,
                               ?downsampleToViewSize=downsampleToViewSize,
                               ?downsampleUseDipUnits=downsampleUseDipUnits,
                               ?downsampleWidth=downsampleWidth,
                               ?effects=effects,
                               ?error=error,
                               ?errorPlaceholder=errorPlaceholder,
                               ?fadeAnimationDuration=fadeAnimationDuration,
                               ?fadeAnimationEnabled=fadeAnimationEnabled,
                               ?fadeAnimationForCachedImages=fadeAnimationForCachedImages,
                               ?fileWriteFinished=fileWriteFinished,
                               ?finish=finish,
                               ?flowDirection=flowDirection,
                               ?focused=focused,
                               ?gestureRecognizers=gestureRecognizers,
                               ?height=height,
                               ?horizontalOptions=horizontalOptions,
                               ?inputTransparent=inputTransparent,
                               ?invalidateLayoutAfterLoaded=invalidateLayoutAfterLoaded,
                               ?isEnabled=isEnabled,
                               ?isOpaque=isOpaque,
                               ?isTabStop=isTabStop,
                               ?isVisible=isVisible,
                               ?loadingDelay=loadingDelay,
                               ?loadingPlaceholder=loadingPlaceholder,
                               ?loadingPriority=loadingPriority,
                               ?margin=margin,
                               ?menu=menu,
                               ?minimumHeight=minimumHeight,
                               ?minimumWidth=minimumWidth,
                               ?opacity=opacity,
                               ?ref=ref,
                               ?resources=resources,
                               ?retryCount=retryCount,
                               ?retryDelay=retryDelay,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?shellBackButtonBehavior=shellBackButtonBehavior,
                               ?shellBackgroundColor=shellBackgroundColor,
                               ?shellDisabledColor=shellDisabledColor,
                               ?shellFlyoutBehavior=shellFlyoutBehavior,
                               ?shellForegroundColor=shellForegroundColor,
                               ?shellNavBarHasShadow=shellNavBarHasShadow,
                               ?shellNavBarIsVisible=shellNavBarIsVisible,
                               ?shellSearchHandler=shellSearchHandler,
                               ?shellTabBarBackgroundColor=shellTabBarBackgroundColor,
                               ?shellTabBarDisabledColor=shellTabBarDisabledColor,
                               ?shellTabBarForegroundColor=shellTabBarForegroundColor,
                               ?shellTabBarIsVisible=shellTabBarIsVisible,
                               ?shellTabBarTitleColor=shellTabBarTitleColor,
                               ?shellTabBarUnselectedColor=shellTabBarUnselectedColor,
                               ?shellTitleColor=shellTitleColor,
                               ?shellTitleView=shellTitleView,
                               ?shellUnselectedColor=shellUnselectedColor,
                               ?source=source,
                               ?style=style,
                               ?styleClasses=styleClasses,
                               ?styleId=styleId,
                               ?styleSheets=styleSheets,
                               ?styles=styles,
                               ?success=success,
                               ?tabIndex=tabIndex,
                               ?tag=tag,
                               ?transformPlaceholders=transformPlaceholders,
                               ?transformations=transformations,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?unfocused=unfocused,
                               ?verticalOptions=verticalOptions,
                               ?visual=visual,
                               ?width=width)


[<AutoOpen>]
module ViewElementExtensions = 

    type ViewElement with

        /// Adjusts the Success property in the visual element
        member x.Success(value: FFImageLoading.Forms.CachedImageEvents.SuccessEventArgs -> unit) = x.WithAttribute(ViewAttributes.SuccessAttribKey, (fun f -> System.EventHandler<FFImageLoading.Forms.CachedImageEvents.SuccessEventArgs>(fun _sender _args -> f _args))(value))

        /// Adjusts the Error property in the visual element
        member x.Error(value: FFImageLoading.Forms.CachedImageEvents.ErrorEventArgs -> unit) = x.WithAttribute(ViewAttributes.ErrorAttribKey, (fun f -> System.EventHandler<FFImageLoading.Forms.CachedImageEvents.ErrorEventArgs>(fun _sender _args -> f _args))(value))

        /// Adjusts the Finish property in the visual element
        member x.Finish(value: FFImageLoading.Forms.CachedImageEvents.FinishEventArgs -> unit) = x.WithAttribute(ViewAttributes.FinishAttribKey, (fun f -> System.EventHandler<FFImageLoading.Forms.CachedImageEvents.FinishEventArgs>(fun _sender _args -> f _args))(value))

        /// Adjusts the DownloadStarted property in the visual element
        member x.DownloadStarted(value: FFImageLoading.Forms.CachedImageEvents.DownloadStartedEventArgs -> unit) = x.WithAttribute(ViewAttributes.DownloadStartedAttribKey, (fun f -> System.EventHandler<FFImageLoading.Forms.CachedImageEvents.DownloadStartedEventArgs>(fun _sender _args -> f _args))(value))

        /// Adjusts the DownloadProgress property in the visual element
        member x.DownloadProgress(value: FFImageLoading.Forms.CachedImageEvents.DownloadProgressEventArgs -> unit) = x.WithAttribute(ViewAttributes.DownloadProgressAttribKey, (fun f -> System.EventHandler<FFImageLoading.Forms.CachedImageEvents.DownloadProgressEventArgs>(fun _sender _args -> f _args))(value))

        /// Adjusts the FileWriteFinished property in the visual element
        member x.FileWriteFinished(value: FFImageLoading.Forms.CachedImageEvents.FileWriteFinishedEventArgs -> unit) = x.WithAttribute(ViewAttributes.FileWriteFinishedAttribKey, (fun f -> System.EventHandler<FFImageLoading.Forms.CachedImageEvents.FileWriteFinishedEventArgs>(fun _sender _args -> f _args))(value))

        /// Adjusts the Aspect property in the visual element
        member x.Aspect(value: Xamarin.Forms.Aspect) = x.WithAttribute(ViewAttributes.AspectAttribKey, (value))

        /// Adjusts the IsOpaque property in the visual element
        member x.IsOpaque(value: bool) = x.WithAttribute(ViewAttributes.IsOpaqueAttribKey, (value))

        /// Adjusts the CachedImageSource property in the visual element
        member x.CachedImageSource(value: Fabulous.XamarinForms.InputTypes.Image) = x.WithAttribute(ViewAttributes.CachedImageSourceAttribKey, (value))

        /// Adjusts the RetryCount property in the visual element
        member x.RetryCount(value: int) = x.WithAttribute(ViewAttributes.RetryCountAttribKey, (value))

        /// Adjusts the RetryDelay property in the visual element
        member x.RetryDelay(value: int) = x.WithAttribute(ViewAttributes.RetryDelayAttribKey, (value))

        /// Adjusts the LoadingDelay property in the visual element
        member x.LoadingDelay(value: int option) = x.WithAttribute(ViewAttributes.LoadingDelayAttribKey, Option.toNullable(value))

        /// Adjusts the DownsampleWidth property in the visual element
        member x.DownsampleWidth(value: float) = x.WithAttribute(ViewAttributes.DownsampleWidthAttribKey, (value))

        /// Adjusts the DownsampleHeight property in the visual element
        member x.DownsampleHeight(value: float) = x.WithAttribute(ViewAttributes.DownsampleHeightAttribKey, (value))

        /// Adjusts the DownsampleToViewSize property in the visual element
        member x.DownsampleToViewSize(value: bool) = x.WithAttribute(ViewAttributes.DownsampleToViewSizeAttribKey, (value))

        /// Adjusts the DownsampleUseDipUnits property in the visual element
        member x.DownsampleUseDipUnits(value: bool) = x.WithAttribute(ViewAttributes.DownsampleUseDipUnitsAttribKey, (value))

        /// Adjusts the CacheDuration property in the visual element
        member x.CacheDuration(value: System.TimeSpan option) = x.WithAttribute(ViewAttributes.CacheDurationAttribKey, Option.toNullable(value))

        /// Adjusts the LoadingPriority property in the visual element
        member x.LoadingPriority(value: FFImageLoading.Work.LoadingPriority) = x.WithAttribute(ViewAttributes.LoadingPriorityAttribKey, (value))

        /// Adjusts the BitmapOptimizations property in the visual element
        member x.BitmapOptimizations(value: bool option) = x.WithAttribute(ViewAttributes.BitmapOptimizationsAttribKey, Option.toNullable(value))

        /// Adjusts the FadeAnimationForCachedImages property in the visual element
        member x.FadeAnimationForCachedImages(value: bool option) = x.WithAttribute(ViewAttributes.FadeAnimationForCachedImagesAttribKey, Option.toNullable(value))

        /// Adjusts the FadeAnimationEnabled property in the visual element
        member x.FadeAnimationEnabled(value: bool option) = x.WithAttribute(ViewAttributes.FadeAnimationEnabledAttribKey, Option.toNullable(value))

        /// Adjusts the FadeAnimationDuration property in the visual element
        member x.FadeAnimationDuration(value: int option) = x.WithAttribute(ViewAttributes.FadeAnimationDurationAttribKey, Option.toNullable(value))

        /// Adjusts the LoadingPlaceholder property in the visual element
        member x.LoadingPlaceholder(value: Fabulous.XamarinForms.InputTypes.Image) = x.WithAttribute(ViewAttributes.LoadingPlaceholderAttribKey, (value))

        /// Adjusts the ErrorPlaceholder property in the visual element
        member x.ErrorPlaceholder(value: Fabulous.XamarinForms.InputTypes.Image) = x.WithAttribute(ViewAttributes.ErrorPlaceholderAttribKey, (value))

        /// Adjusts the TransformPlaceholders property in the visual element
        member x.TransformPlaceholders(value: bool option) = x.WithAttribute(ViewAttributes.TransformPlaceholdersAttribKey, Option.toNullable(value))

        /// Adjusts the Transformations property in the visual element
        member x.Transformations(value: System.Collections.Generic.List<FFImageLoading.Work.ITransformation>) = x.WithAttribute(ViewAttributes.TransformationsAttribKey, (value))

        /// Adjusts the InvalidateLayoutAfterLoaded property in the visual element
        member x.InvalidateLayoutAfterLoaded(value: bool option) = x.WithAttribute(ViewAttributes.InvalidateLayoutAfterLoadedAttribKey, Option.toNullable(value))

        /// Adjusts the CacheType property in the visual element
        member x.CacheType(value: FFImageLoading.Cache.CacheType option) = x.WithAttribute(ViewAttributes.CacheTypeAttribKey, Option.toNullable(value))

        member inline x.With(?success: FFImageLoading.Forms.CachedImageEvents.SuccessEventArgs -> unit, ?error: FFImageLoading.Forms.CachedImageEvents.ErrorEventArgs -> unit, ?finish: FFImageLoading.Forms.CachedImageEvents.FinishEventArgs -> unit, ?downloadStarted: FFImageLoading.Forms.CachedImageEvents.DownloadStartedEventArgs -> unit, ?downloadProgress: FFImageLoading.Forms.CachedImageEvents.DownloadProgressEventArgs -> unit, 
                             ?fileWriteFinished: FFImageLoading.Forms.CachedImageEvents.FileWriteFinishedEventArgs -> unit, ?aspect: Xamarin.Forms.Aspect, ?isOpaque: bool, ?cachedImageSource: Fabulous.XamarinForms.InputTypes.Image, ?retryCount: int, 
                             ?retryDelay: int, ?loadingDelay: int option, ?downsampleWidth: float, ?downsampleHeight: float, ?downsampleToViewSize: bool, 
                             ?downsampleUseDipUnits: bool, ?cacheDuration: System.TimeSpan option, ?loadingPriority: FFImageLoading.Work.LoadingPriority, ?bitmapOptimizations: bool option, ?fadeAnimationForCachedImages: bool option, 
                             ?fadeAnimationEnabled: bool option, ?fadeAnimationDuration: int option, ?loadingPlaceholder: Fabulous.XamarinForms.InputTypes.Image, ?errorPlaceholder: Fabulous.XamarinForms.InputTypes.Image, ?transformPlaceholders: bool option, 
                             ?transformations: System.Collections.Generic.List<FFImageLoading.Work.ITransformation>, ?invalidateLayoutAfterLoaded: bool option, ?cacheType: FFImageLoading.Cache.CacheType option) =
            let x = match success with None -> x | Some opt -> x.Success(opt)
            let x = match error with None -> x | Some opt -> x.Error(opt)
            let x = match finish with None -> x | Some opt -> x.Finish(opt)
            let x = match downloadStarted with None -> x | Some opt -> x.DownloadStarted(opt)
            let x = match downloadProgress with None -> x | Some opt -> x.DownloadProgress(opt)
            let x = match fileWriteFinished with None -> x | Some opt -> x.FileWriteFinished(opt)
            let x = match aspect with None -> x | Some opt -> x.Aspect(opt)
            let x = match isOpaque with None -> x | Some opt -> x.IsOpaque(opt)
            let x = match cachedImageSource with None -> x | Some opt -> x.CachedImageSource(opt)
            let x = match retryCount with None -> x | Some opt -> x.RetryCount(opt)
            let x = match retryDelay with None -> x | Some opt -> x.RetryDelay(opt)
            let x = match loadingDelay with None -> x | Some opt -> x.LoadingDelay(opt)
            let x = match downsampleWidth with None -> x | Some opt -> x.DownsampleWidth(opt)
            let x = match downsampleHeight with None -> x | Some opt -> x.DownsampleHeight(opt)
            let x = match downsampleToViewSize with None -> x | Some opt -> x.DownsampleToViewSize(opt)
            let x = match downsampleUseDipUnits with None -> x | Some opt -> x.DownsampleUseDipUnits(opt)
            let x = match cacheDuration with None -> x | Some opt -> x.CacheDuration(opt)
            let x = match loadingPriority with None -> x | Some opt -> x.LoadingPriority(opt)
            let x = match bitmapOptimizations with None -> x | Some opt -> x.BitmapOptimizations(opt)
            let x = match fadeAnimationForCachedImages with None -> x | Some opt -> x.FadeAnimationForCachedImages(opt)
            let x = match fadeAnimationEnabled with None -> x | Some opt -> x.FadeAnimationEnabled(opt)
            let x = match fadeAnimationDuration with None -> x | Some opt -> x.FadeAnimationDuration(opt)
            let x = match loadingPlaceholder with None -> x | Some opt -> x.LoadingPlaceholder(opt)
            let x = match errorPlaceholder with None -> x | Some opt -> x.ErrorPlaceholder(opt)
            let x = match transformPlaceholders with None -> x | Some opt -> x.TransformPlaceholders(opt)
            let x = match transformations with None -> x | Some opt -> x.Transformations(opt)
            let x = match invalidateLayoutAfterLoaded with None -> x | Some opt -> x.InvalidateLayoutAfterLoaded(opt)
            let x = match cacheType with None -> x | Some opt -> x.CacheType(opt)
            x

    /// Adjusts the Success property in the visual element
    let success (value: FFImageLoading.Forms.CachedImageEvents.SuccessEventArgs -> unit) (x: ViewElement) = x.Success(value)
    /// Adjusts the Error property in the visual element
    let error (value: FFImageLoading.Forms.CachedImageEvents.ErrorEventArgs -> unit) (x: ViewElement) = x.Error(value)
    /// Adjusts the Finish property in the visual element
    let finish (value: FFImageLoading.Forms.CachedImageEvents.FinishEventArgs -> unit) (x: ViewElement) = x.Finish(value)
    /// Adjusts the DownloadStarted property in the visual element
    let downloadStarted (value: FFImageLoading.Forms.CachedImageEvents.DownloadStartedEventArgs -> unit) (x: ViewElement) = x.DownloadStarted(value)
    /// Adjusts the DownloadProgress property in the visual element
    let downloadProgress (value: FFImageLoading.Forms.CachedImageEvents.DownloadProgressEventArgs -> unit) (x: ViewElement) = x.DownloadProgress(value)
    /// Adjusts the FileWriteFinished property in the visual element
    let fileWriteFinished (value: FFImageLoading.Forms.CachedImageEvents.FileWriteFinishedEventArgs -> unit) (x: ViewElement) = x.FileWriteFinished(value)
    /// Adjusts the Aspect property in the visual element
    let aspect (value: Xamarin.Forms.Aspect) (x: ViewElement) = x.Aspect(value)
    /// Adjusts the IsOpaque property in the visual element
    let isOpaque (value: bool) (x: ViewElement) = x.IsOpaque(value)
    /// Adjusts the CachedImageSource property in the visual element
    let cachedImageSource (value: Fabulous.XamarinForms.InputTypes.Image) (x: ViewElement) = x.CachedImageSource(value)
    /// Adjusts the RetryCount property in the visual element
    let retryCount (value: int) (x: ViewElement) = x.RetryCount(value)
    /// Adjusts the RetryDelay property in the visual element
    let retryDelay (value: int) (x: ViewElement) = x.RetryDelay(value)
    /// Adjusts the LoadingDelay property in the visual element
    let loadingDelay (value: int option) (x: ViewElement) = x.LoadingDelay(value)
    /// Adjusts the DownsampleWidth property in the visual element
    let downsampleWidth (value: float) (x: ViewElement) = x.DownsampleWidth(value)
    /// Adjusts the DownsampleHeight property in the visual element
    let downsampleHeight (value: float) (x: ViewElement) = x.DownsampleHeight(value)
    /// Adjusts the DownsampleToViewSize property in the visual element
    let downsampleToViewSize (value: bool) (x: ViewElement) = x.DownsampleToViewSize(value)
    /// Adjusts the DownsampleUseDipUnits property in the visual element
    let downsampleUseDipUnits (value: bool) (x: ViewElement) = x.DownsampleUseDipUnits(value)
    /// Adjusts the CacheDuration property in the visual element
    let cacheDuration (value: System.TimeSpan option) (x: ViewElement) = x.CacheDuration(value)
    /// Adjusts the LoadingPriority property in the visual element
    let loadingPriority (value: FFImageLoading.Work.LoadingPriority) (x: ViewElement) = x.LoadingPriority(value)
    /// Adjusts the BitmapOptimizations property in the visual element
    let bitmapOptimizations (value: bool option) (x: ViewElement) = x.BitmapOptimizations(value)
    /// Adjusts the FadeAnimationForCachedImages property in the visual element
    let fadeAnimationForCachedImages (value: bool option) (x: ViewElement) = x.FadeAnimationForCachedImages(value)
    /// Adjusts the FadeAnimationEnabled property in the visual element
    let fadeAnimationEnabled (value: bool option) (x: ViewElement) = x.FadeAnimationEnabled(value)
    /// Adjusts the FadeAnimationDuration property in the visual element
    let fadeAnimationDuration (value: int option) (x: ViewElement) = x.FadeAnimationDuration(value)
    /// Adjusts the LoadingPlaceholder property in the visual element
    let loadingPlaceholder (value: Fabulous.XamarinForms.InputTypes.Image) (x: ViewElement) = x.LoadingPlaceholder(value)
    /// Adjusts the ErrorPlaceholder property in the visual element
    let errorPlaceholder (value: Fabulous.XamarinForms.InputTypes.Image) (x: ViewElement) = x.ErrorPlaceholder(value)
    /// Adjusts the TransformPlaceholders property in the visual element
    let transformPlaceholders (value: bool option) (x: ViewElement) = x.TransformPlaceholders(value)
    /// Adjusts the Transformations property in the visual element
    let transformations (value: System.Collections.Generic.List<FFImageLoading.Work.ITransformation>) (x: ViewElement) = x.Transformations(value)
    /// Adjusts the InvalidateLayoutAfterLoaded property in the visual element
    let invalidateLayoutAfterLoaded (value: bool option) (x: ViewElement) = x.InvalidateLayoutAfterLoaded(value)
    /// Adjusts the CacheType property in the visual element
    let cacheType (value: FFImageLoading.Cache.CacheType option) (x: ViewElement) = x.CacheType(value)
