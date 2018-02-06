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

// targetsAreOnSameLevel
Target "BuildApp" (fun _ ->
    MSBuildRelease buildDir "Restore"
    !! "Elmish.XamarinForms.sln"
       |> MSBuildRelease buildDir "Build"
       |> Log "AppBuild-Output: "
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

    !! "src/*/*.??proj"
    |> Seq.map getProjectDetails
    |> Seq.iter (fun (projFileName, projectName, folderName, attributes) ->
        match projFileName with
        | Fsproj -> CreateFSharpAssemblyInfo (folderName @@ "AssemblyInfo.fs") attributes
        | _ -> ()
        )
)

// Build a NuGet package
Target "NuGet" (fun _ ->
    Paket.Pack(fun p -> 
        { p with
            OutputPath = buildDir
            TemplateFile = "paket.template"
            Version = release.NugetVersion
            ReleaseNotes = toLines release.Notes})
)

Target "PublishNuget" (fun _ ->
    Paket.Push(fun p -> 
        { p with
            WorkingDir = buildDir })
)

Target "All" DoNothing

"Clean"
  ==> "AssemblyInfo"
  ==> "BuildApp"
  ==> "All"

"All" 
  ==> "NuGet"
  ==> "PublishNuget"


// start build
RunTargetOrDefault "All"