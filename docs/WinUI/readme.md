## WinUI 3 Apps

We're looking into adding WinUI 3 App templates to Windows Template Studio.

Our templates for WinUI 3 Apps are currently in preview as WinUI3 itself. You can try them out in our [dev-nightly version](./../getting-started-extension.md#nightly--pre-release-feeds-for-windows-template-studio).

We currently provide templates for: 
- WinUI 3 Desktop App (C#)
- WinUI 3 Desktop App (C++)
- WinUI 3 Uwp App (C++)

We would love to get your feedback on our [tracking issues for WinUI3 templates](https://github.com/microsoft/WindowsTemplateStudio/issues?q=is%3Aopen+is%3Aissue+label%3Afeature+milestone%3AWinUI3).

If you miss anything or find an issue that is not mentioned in the known issues section please file a new issue.

### Prerequisites

1. Ensure that your development computer has Windows 10, version 1803 (build 17134), or newer installed.

2. Install [Visual Studio 2019, version 16.9 Preview](https://visualstudio.microsoft.com/vs/preview/). You must include the following workloads when installing Visual Studio:
   - .NET Desktop Development (this also installs .NET 5)
   - Universal Windows Platform development

3. To build C++ apps, you must also include the following workloads:

   - Desktop development with C++
   - The C++ (v142) Universal Windows Platform tools optional component for the Universal Windows Platform workload (see "Installation Details" under the "Universal Windows Platform development" section, on the right pane)


4. Make sure your system has a NuGet package source enabled for nuget.org. For more information, see [Common NuGet configurations](https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior)

5. Add a new Package source to the Windows Community DevOps feed: 
   - Go to Tools -> NuGet Package Manager -> Package Manager Settings -> Package Sources
   - Add a new Package Source for https://pkgs.dev.azure.com/dotnet/WindowsCommunityToolkit/_packaging/WindowsCommunityToolkit-WinUI3/nuget/v3/index.json
   - Confirm by clicking update, then Ok


### Known issues:
- [Windows Default theme issue](https://github.com/microsoft/WindowsTemplateStudio/issues/4086)
- [Dark/Light theme issue](https://github.com/microsoft/WindowsTemplateStudio/issues/4087)
- [Master/Detail Issue with WinUI](https://github.com/microsoft/WindowsTemplateStudio/issues/4088)
- [Localized tooltips + automationname issue](https://github.com/microsoft/WindowsTemplateStudio/issues/4039)
- [WebView2 exception](https://github.com/microsoft/WindowsTemplateStudio/issues/4073)
- [VisualStateManager initialization issue](https://github.com/microsoft/WindowsTemplateStudio/issues/4072)

### Additional docs:
- [Windows UI Library 3 Preview 4 (February 2021)](https://docs.microsoft.com/windows/apps/winui/winui3/)
- [Windows UI Library on GitHub](https://github.com/Microsoft/microsoft-ui-xaml)
- [Windows Community Toolkit 8.0.0-preview4 for WinUI 3 Preview 4](https://github.com/windows-toolkit/WindowsCommunityToolkit/issues/3295)
