#!/bin/bash

# Allow FAKE to run on .NET Core 3.x
export DOTNET_ROLL_FORWARD=Major

sudo apt install -y gnupg ca-certificates
sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
echo "deb https://download.mono-project.com/repo/ubuntu stable-focal main" | sudo tee /etc/apt/sources.list.d/mono-official-stable.list
sudo apt update -y
sudo apt install -y mono-devel
sudo apt install -y mono-complete
sudo apt install -y mono-dbg
sudo apt install -y referenceassemblies-pcl
sudo apt install -y ca-certificates-mono
sudo apt install -y mono-xsp4
sudo apt-get update -y
sudo apt-get install -y gtk-sharp2

# dotnet tool restore
# if [ $# -eq 0 ]; then
#     dotnet fake build
# else
#     dotnet fake run build.fsx -t $@
# fi

msbuild /Users/sergejdick/Projects/Fabulous/test/test.GTK/test.GTK.csproj -target:Build

# dotnet build Fabulous.XamarinForms/samples/AllControls/Gtk/AllControls.Gtk.fsproj -target:Build

# dotnet build Fabulous.XamarinForms/samples/AllControls/Gtk/AllControls.Gtk.fsproj -target:Rebuild
# ls /usr/lib/mono/xbuild/Microsoft/VisualStudio/v14.0/FSharp/
# ls /usr/lib/mono/xbuild/Microsoft/VisualStudio/v12.0/FSharp/
# msbuild Fabulous.XamarinForms/samples/AllControls/Gtk/AllControls.Gtk.fsproj -target:Build