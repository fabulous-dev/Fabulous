1. In `Packages.targets`
    - update Xamarin.Forms, Xamarin.Forms.Maps to new latest lowest major version (for example, Xamarin.Forms 4.5.0 the lowest major version is `4.5.0.356`)
    - update Xamarin.Forms.Platform.WPF, Xamarin.Forms.Maps.WPF to the latest version (e.g. `4.5.0.495` as of March 27th 2020)
2. In `paket.dependencies`
    - update all Xamarin.Forms and related packages to new major version (e.g. `<= 4.6.0`)
    - delete `paket.lock` and `paket-files` / `packages` folders if present
    - run `paket install`
3. In `Xamarin.Forms.Core.json` and `ViewConverters.fs` and `ViewUpdaters.fs`, do the appropriate changes in accordance to the API changes list of the new version of Xamarin.Forms
    - Only public properties (with setter) and events are interesting
    - Only the Xamarin.Forms namespace is interesting
    - Only control types are interesting (deriving from Xamarin.Forms.BindableObject)