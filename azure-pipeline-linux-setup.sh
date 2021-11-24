#!/bin/bash

sudo apt install -y gnupg ca-certificates
sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
echo "deb https://download.mono-project.com/repo/ubuntu stable-focal main" | sudo tee /etc/apt/sources.list.d/mono-official-stable.list
sudo apt update -y
sudo apt install -y mono-devel mono-complete mono-dbg referenceassemblies-pcl ca-certificates-mono mono-xsp4
sudo apt-get update -y
sudo apt-get install -y gtk-sharp2 fsharp

# replace the visualstudioversion for pipeline
FILES= find . -type f -name "*.Gtk.fsproj" 

for file in $FILES 
do
    sed -i ""  -e "s/v\$(VisualStudioVersion)/v/g" file
done