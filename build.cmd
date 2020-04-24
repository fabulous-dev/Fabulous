@echo off
cls

REM Allow FAKE to run on .NET Core 3.x
set DOTNET_ROLL_FORWARD=Major

dotnet restore build.proj
if "%~1"=="" (dotnet fake build) else (dotnet fake run build.fsx -t %*)
