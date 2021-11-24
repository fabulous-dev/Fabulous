#!/bin/bash

# Allow FAKE to run on .NET Core 3.x
export DOTNET_ROLL_FORWARD=Major

dotnet tool restore
if [ $# -eq 0 ]; then
    dotnet fake build
else
    dotnet fake run build.fsx -t $@
fi