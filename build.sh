#!/bin/bash
dotnet restore build.proj
if [ $# -eq 0 ]; then
    dotnet fake build
else
    dotnet fake run build.fsx -t $@
fi