// Copyright 2018-2020 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.XamarinForms.VideoManager

#nowarn "59" // cast always holds
#nowarn "66" // cast always holds
#nowarn "67" // cast always holds
#nowarn "760"

open Fabulous
open Fabulous.XamarinForms

module ViewAttributes =
    let AutoPlayAttribKey : AttributeKey<_> = AttributeKey<bool>("AutoPlay")
    let RepeatAttribKey : AttributeKey<_> = AttributeKey<MediaManager.Playback.RepeatMode>("Repeat")
    let ShowControlsAttribKey : AttributeKey<_> = AttributeKey<bool>("ShowControls")
    let ShuffleAttribKey : AttributeKey<_> = AttributeKey<MediaManager.Queue.ShuffleMode>("Shuffle")
    let SpeedAttribKey : AttributeKey<_> = AttributeKey<single>("Speed")
    let VideoViewSourceAttribKey : AttributeKey<_> = AttributeKey<obj>("VideoViewSource")
    let VideoAspectAttribKey : AttributeKey<_> = AttributeKey<MediaManager.Video.VideoAspectMode>("VideoAspect")
    let VideoPlaceholderAttribKey : AttributeKey<_> = AttributeKey<Fabulous.XamarinForms.InputTypes.Image.Value>("VideoPlaceholder")
    let VolumeAttribKey : AttributeKey<_> = AttributeKey<int>("Volume")

