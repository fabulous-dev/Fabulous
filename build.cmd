@echo off
cls
if "%~1"=="" (fake build) else (fake run build.fsx -t %*)
