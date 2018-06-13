# Dev Notes - Building

    .\build NuGet
    
    .\build BuildSamples


# Dev Notes - Releasing

Use this:

    .\build NuGet
    set APIKEY=...
    .nuget\NuGet.exe push C:\GitHub\dsyme\Elmish.XamarinForms\build_output\Elmish.XamarinForms.*.nupkg  %APIKEY% -Source https://www.nuget.org
    copy C:\GitHub\dsyme\Elmish.XamarinForms\build_output\Elmish.XamarinForms.*.nupkg  %USERPROFILE%\Downloads

