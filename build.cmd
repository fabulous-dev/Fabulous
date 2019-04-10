@echo off
cls
dotnet restore build.proj
if "%~1"=="" (dotnet fake build) else (dotnet fake run build.fsx -t %*)
