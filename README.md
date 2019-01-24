# Leadscore Xamarin Sample
Xamarin app for Android/iOS to explore leadscore.io API's using System.Reactive, ReactiveUI, xamvvm and Refit.

## Building the project in macOS

Extending our bash_profile over the terminal:
```bash
echo 'export NugetPackagesPath=~/.nuget/packages' >> ~/.bash_profile
echo 'alias vs='"'"'/Applications/Visual\ Studio.app/Contents/MacOS/VisualStudio &'"'"'' >> ~/.bash_profile
. ~/.bash_profile
```
Visual Studio for Mac inherits the environment variable NugetPackagesPath when started with "vs" from terminal.
This is important in order to build the Android project which has in csproj following workaround:
```
  <!-- https://github.com/dotnet/reactive/issues/803 -->
  <ItemGroup>
    <PackageReference Include="System.Runtime.CompilerServices.Unsafe" Version="4.5.2" />
    <Reference Include="System.Threading.Tasks.Extensions">
      <HintPath>$(NugetPackagesPath)\system.threading.tasks.extensions\4.5.1\lib\netstandard2.0\System.Threading.Tasks.Extensions.dll</HintPath>
    </Reference>
  </ItemGroup>
  ```