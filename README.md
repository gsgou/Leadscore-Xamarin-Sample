# Leadscore Xamarin Sample
Xamarin app for Android/iOS to explore [leadscore.io](https://www.leadscore.io/) API's using System.Reactive, ReactiveUI, xamvvm and Refit.

To test the app, you first need to [sign up for a staging leadscore account](https://app-staging.leadscore.io/#/signup).

## Required components
To build for Android and iOS, the following are required:
* macOS High Sierra (10.13) and above
* the latest version of Xcode and iOS SDK
* the latest version of Visual Studio for Mac

Visual Studio includes an Android SDK Manager that replaces Google's standalone Android SDK Manager and will also install OpenJDK as the preferred Java runtime for mobile development.

## Step-by-step setup instructions
The Xamarin documentation portal [has detailed setup and install instructions](https://docs.microsoft.com/en-us/visualstudio/mac/installation?view=vsmac-2017) for Xamarin.

## Build Instructions in macOS
Extending our bash_profile over the terminal:
```bash
echo 'export NugetPackagesPath=~/.nuget/packages' >> ~/.bash_profile
echo 'alias vs='"'"'/Applications/Visual\ Studio.app/Contents/MacOS/VisualStudio &'"'"'' >> ~/.bash_profile
. ~/.bash_profile
```
Visual Studio for Mac inherits the environment variable NugetPackagesPath when started with "vs" from terminal.
This is important in order to build the Android project which has in csproj the following dependency:
```
  <!-- https://github.com/dotnet/reactive/issues/803 -->
  <ItemGroup>
    <PackageReference Include="System.Runtime.CompilerServices.Unsafe" Version="4.5.2" />
    <Reference Include="System.Threading.Tasks.Extensions">
      <HintPath>$(NugetPackagesPath)\system.threading.tasks.extensions\4.5.1\lib\netstandard2.0\System.Threading.Tasks.Extensions.dll</HintPath>
    </Reference>
  </ItemGroup>
  ```

## Functionality
Beyond the standard functionality provides:

* LOGIN features:
  * Email entry, that remembers the last sucessfully used Email, is clearable and moves focus to a Password entry when keyboard button "Next" is pressed.
  * Password entry, that shows and hides the password.
  * Animated login button with IsEnabled and BackgroundColor properties reacting to valid Email and Password.

* REST features:
  * Retry algorithm/policy with exponential back-off plus some jitter to overcome peaks of similar retries coming from many clients in case of partial outages.
  * Exception handling that outputs error messages in console for a better Debugging experience.