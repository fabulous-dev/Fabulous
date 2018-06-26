// include Fake lib
#I "packages/FAKE/tools"
#r "packages/FAKE/tools/FakeLib.dll"
open Fake
open Fake.AssemblyInfoFile
open Fake.Git
open Fake.ReleaseNotesHelper

let buildDir = "./build_output/"
let release = LoadReleaseNotes "RELEASE_NOTES.md"

let project = "Elmish.XamarinForms"
let summary = "F# bindings for using elmish in WPF"

Target "Build" (fun _ ->

    // needed or else 'project.assets.json' not found'
    DotNetCli.Restore (fun p -> { p with Project = "Elmish.XamarinForms/Elmish.XamarinForms.fsproj" })

    !! "Elmish.XamarinForms/Elmish.XamarinForms.fsproj"
       |> MSBuildRelease buildDir "Restore"
       |> Log "LibraryRestore-Output: "

    !! "Elmish.XamarinForms/Elmish.XamarinForms.fsproj"
       |> MSBuildRelease buildDir "Build"
       |> Log "LibraryBuild-Output: "
)

Target "BuildSamples" (fun _ ->

    // needed or else 'project.assets.json' not found'
    DotNetCli.Restore (fun p -> { p with Project = "Elmish.XamarinForms.sln" })

    // restore the apps debug
    !! "Elmish.XamarinForms.sln"
          |> MSBuildDebug null "Restore"
          |> Log "SamplesRestoreDebug-Output: "

    // build the apps debug
    !! "Elmish.XamarinForms.sln"
          |> MSBuildDebug null "Build"
          |> Log "SamplesBuildDebug-Output: "

)

Target "Clean" (fun _ ->
    CleanDir buildDir
)

// Generate assembly info files with the right version & up-to-date information
Target "AssemblyInfo" (fun _ ->
    let getAssemblyInfoAttributes projectName =
        [ Attribute.Title (projectName)
          Attribute.Product project
          Attribute.Description summary
          Attribute.Version release.AssemblyVersion
          Attribute.FileVersion release.AssemblyVersion ]

    let getProjectDetails projectPath =
        let projectName = System.IO.Path.GetFileNameWithoutExtension(projectPath)
        ( projectPath, 
          projectName,
          System.IO.Path.GetDirectoryName(projectPath),
          (getAssemblyInfoAttributes projectName)
        )

    !! "*/*.??proj"
    |> Seq.map getProjectDetails
    |> Seq.iter (fun (projFileName, projectName, folderName, attributes) ->
        match projFileName with
        | Fsproj -> CreateFSharpAssemblyInfo (folderName @@ "AssemblyInfo.fs") attributes
        | _ -> ()
        )
)

// Build a NuGet package
Target "LibraryNuGet" (fun _ ->
    Paket.Pack(fun p -> 
        { p with
            OutputPath = buildDir
            TemplateFile = "paket.template"
            Version = release.NugetVersion
            ReleaseNotes = toLines release.Notes})

)
// Build a NuGet package
Target "TemplatesNuGet" (fun _ ->

    NuGetHelper.NuGetPack (fun p -> 
        { p with
            WorkingDir = "templates"
            OutputPath = buildDir
            Version = release.NugetVersion
            ReleaseNotes = toLines release.Notes}) @"templates\Elmish.XamarinForms.Templates.nuspec"
)

Target "TestTemplatesNuGet" (fun _ ->

    // needed or else 'project.assets.json' not found'
    DotNetCli.Restore (fun p -> { p with Project = "Elmish.XamarinForms.sln" })
    DotNetCli.RunCommand id ("new -i " + buildDir + "Elmish.XamarinForms.Templates." + release.NugetVersion + ".nupkg")
    CleanDir "testapp"
    DotNetCli.RunCommand id "new elmish-forms-app -n testapp -lang F#" 
    DotNetCli.RunCommand id ("restore testapp/testapp/testapp.fsproj -s " + buildDir)
    !! "testapp/testapp.Android/testapp.*.fsproj"
       |> MSBuildDebug null "RestorePackages"
       |> Log "AppBuild-Output: "
    !! "testapp/testapp.Android/testapp.*.fsproj"
       |> MSBuildDebug null "Build"
       |> Log "AppBuild-Output: "

    (* Manual steps without building nupkg
        .\build LibraryNuGet
        dotnet new -i  templates
        rmdir /s /q testapp
        dotnet new elmish-forms-app -n testapp -lang F#
        dotnet restore testapp/testapp/testapp.fsproj -s build_output/
        dotnet new -i  templates && rmdir /s /q testapp && dotnet new elmish-forms-app -n testapp -lang F# && dotnet restore testapp/testapp/testapp.fsproj && msbuild testapp/testapp.Android/testapp.Android.fsproj /t:RestorePackages && msbuild testapp/testapp.Android/testapp.Android.fsproj
        dotnet new -i  templates && rmdir /s /q testapp && dotnet new elmish-forms-app -n testapp -lang F# && dotnet restore testapp/testapp/testapp.fsproj && msbuild testapp/testapp.iOS/testapp.iOS.fsproj /t:RestorePackages && msbuild testapp/testapp.iOS/testapp.iOS.fsproj
        dotnet new -i  templates && rmdir /s /q testapp && dotnet new elmish-forms-app -n testapp -lang F# --CreateMacProject && dotnet restore testapp/testapp/testapp.fsproj && msbuild testapp/testapp.macOS/testapp.macOS.fsproj /t:RestorePackages && msbuild testapp/testapp.macOS/testapp.macOS.fsproj
        *)

)


Target "PublishNuGets" (fun _ ->
    Paket.Push(fun p -> 
        { p with
            WorkingDir = buildDir })
)

Target "NuGet" DoNothing
Target "Test" DoNothing

//"Clean"
//  ==> "AssemblyInfo"
//  ==> 
"Build"
  ==> "LibraryNuGet" 
  ==> "TemplatesNuGet" 
  ==> "NuGet"

"Build"
  ==> "BuildSamples"
  ==> "Test"

"NuGet" 
  ==> "TestTemplatesNuGet"
  ==> "Test"
  ==> "PublishNuGets"


// start build
RunTargetOrDefault "Build"
