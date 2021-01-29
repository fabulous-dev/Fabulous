// Copyright 2018-2020 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.XamarinForms.FFImageLoading

#nowarn "59" // cast always holds
#nowarn "66" // cast always holds
#nowarn "67" // cast always holds
#nowarn "760"

open Fabulous
open Fabulous.XamarinForms

module ViewAttributes =
    let SuccessAttribKey : AttributeKey<_> = AttributeKey<System.EventHandler<FFImageLoading.Forms.CachedImageEvents.SuccessEventArgs>>("Success")
    let ErrorAttribKey : AttributeKey<_> = AttributeKey<System.EventHandler<FFImageLoading.Forms.CachedImageEvents.ErrorEventArgs>>("Error")
    let FinishAttribKey : AttributeKey<_> = AttributeKey<System.EventHandler<FFImageLoading.Forms.CachedImageEvents.FinishEventArgs>>("Finish")
    let DownloadStartedAttribKey : AttributeKey<_> = AttributeKey<System.EventHandler<FFImageLoading.Forms.CachedImageEvents.DownloadStartedEventArgs>>("DownloadStarted")
    let DownloadProgressAttribKey : AttributeKey<_> = AttributeKey<System.EventHandler<FFImageLoading.Forms.CachedImageEvents.DownloadProgressEventArgs>>("DownloadProgress")
    let FileWriteFinishedAttribKey : AttributeKey<_> = AttributeKey<System.EventHandler<FFImageLoading.Forms.CachedImageEvents.FileWriteFinishedEventArgs>>("FileWriteFinished")
    let CachedImageAspectAttribKey : AttributeKey<_> = AttributeKey<Xamarin.Forms.Aspect>("CachedImageAspect")
    let IsOpaqueAttribKey : AttributeKey<_> = AttributeKey<bool>("IsOpaque")
    let CachedImageSourceAttribKey : AttributeKey<_> = AttributeKey<Fabulous.XamarinForms.InputTypes.Image.Value>("CachedImageSource")
    let RetryCountAttribKey : AttributeKey<_> = AttributeKey<int>("RetryCount")
    let RetryDelayAttribKey : AttributeKey<_> = AttributeKey<int>("RetryDelay")
    let LoadingDelayAttribKey : AttributeKey<_> = AttributeKey<System.Nullable<int>>("LoadingDelay")
    let DownsampleWidthAttribKey : AttributeKey<_> = AttributeKey<float>("DownsampleWidth")
    let DownsampleHeightAttribKey : AttributeKey<_> = AttributeKey<float>("DownsampleHeight")
    let DownsampleToViewSizeAttribKey : AttributeKey<_> = AttributeKey<bool>("DownsampleToViewSize")
    let DownsampleUseDipUnitsAttribKey : AttributeKey<_> = AttributeKey<bool>("DownsampleUseDipUnits")
    let CacheDurationAttribKey : AttributeKey<_> = AttributeKey<System.Nullable<System.TimeSpan>>("CacheDuration")
    let LoadingPriorityAttribKey : AttributeKey<_> = AttributeKey<FFImageLoading.Work.LoadingPriority>("LoadingPriority")
    let BitmapOptimizationsAttribKey : AttributeKey<_> = AttributeKey<System.Nullable<bool>>("BitmapOptimizations")
    let FadeAnimationForCachedImagesAttribKey : AttributeKey<_> = AttributeKey<System.Nullable<bool>>("FadeAnimationForCachedImages")
    let FadeAnimationEnabledAttribKey : AttributeKey<_> = AttributeKey<System.Nullable<bool>>("FadeAnimationEnabled")
    let FadeAnimationDurationAttribKey : AttributeKey<_> = AttributeKey<System.Nullable<int>>("FadeAnimationDuration")
    let LoadingPlaceholderAttribKey : AttributeKey<_> = AttributeKey<Fabulous.XamarinForms.InputTypes.Image.Value>("LoadingPlaceholder")
    let ErrorPlaceholderAttribKey : AttributeKey<_> = AttributeKey<Fabulous.XamarinForms.InputTypes.Image.Value>("ErrorPlaceholder")
    let TransformPlaceholdersAttribKey : AttributeKey<_> = AttributeKey<System.Nullable<bool>>("TransformPlaceholders")
    let TransformationsAttribKey : AttributeKey<_> = AttributeKey<System.Collections.Generic.List<FFImageLoading.Work.ITransformation>>("Transformations")
    let InvalidateLayoutAfterLoadedAttribKey : AttributeKey<_> = AttributeKey<System.Nullable<bool>>("InvalidateLayoutAfterLoaded")
    let CacheTypeAttribKey : AttributeKey<_> = AttributeKey<System.Nullable<FFImageLoading.Cache.CacheType>>("CacheType")

