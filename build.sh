#!/bin/bash

# Allow FAKE to run on .NET Core 3.x
#export DOTNET_ROLL_FORWARD=Major

# dotnet tool restore
# if [ $# -eq 0 ]; then
#     dotnet fake build
# else
#     dotnet fake run build.fsx -t $@
# fi

msbuild Fabulous.XamarinForms/samples/AllControls/Gtk/AllControls.Gtk.fsproj -target:Rebuild
ls /usr/lib/mono/xbuild/Microsoft/VisualStudio/v16.0/FSharp/
ls /usr/lib/mono/xbuild/Microsoft/VisualStudio/v15.0/FSharp/
ls /usr/lib/mono/xbuild/Microsoft/VisualStudio/v14.0/FSharp/
ls /usr/lib/mono/xbuild/Microsoft/VisualStudio/v12.0/FSharp/
ls /usr/lib/mono/xbuild/Microsoft/VisualStudio/v11.0/FSharp/
ls /usr/lib/mono/xbuild/Microsoft/VisualStudio/v10.0/FSharp/
ls /usr/lib/mono/xbuild/Microsoft/VisualStudio/v/FSharp/