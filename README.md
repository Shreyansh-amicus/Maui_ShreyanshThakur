# MauiAssignment

## Overview

MauiAssignment is a cross-platform application developed using .NET MAUI (Multi-platform App UI).

.NET MAUI allows us to build applications for Android, iOS, macOS, and Windows using a shared C# codebase and a single project structure.

## Project Structure

The application follows the .NET MAUI single-project architecture. Most application logic and user interface components are shared across platforms, while platform-specific configurations are maintained separately.

### 1. Shared Application Files

- **App.xaml:** Contains application-level resources, styles, and other shared XAML definitions.
- **App.xaml.cs:** Defines the application class and creates the initial application window.
- **AppShell.xaml:** Defines the application's navigation structure using Shell.
- **AppShell.xaml.cs:** Contains the code-behind associated with AppShell.
- **MainPage.xaml:** Defines the user interface of the initial application page.
- **MainPage.xaml.cs:** Contains the C# logic associated with MainPage.
- **MauiProgram.cs:** Configures and initializes the MAUI application, including dependency injection, fonts, and other application services.
- **MauiAssignment.csproj:** Contains project configuration, target frameworks, dependencies, and build settings.

### 2. Platforms Folder

The Platforms folder contains operating-system-specific implementations and configuration files.

- **Android:** Contains Android-specific entry points, application configuration, manifests, and resources.
- **iOS:** Contains iOS application lifecycle and configuration files.
- **MacCatalyst:** Contains configuration files required to run the application on macOS through Mac Catalyst.
- **Windows:** Contains Windows-specific application startup and configuration files.

This separation allows platform-specific functionality to coexist with shared application code.

### 3. Resources Folder

The Resources folder stores assets used throughout the application.

- **AppIcon:** Application icons.
- **Fonts:** Custom fonts.
- **Images:** Images and graphical assets.
- **Raw:** Files included directly in the application package.
- **Splash:** Splash screen assets.
- **Styles:** Shared application colors and styles.

### 4. Application Startup

The application startup process involves the following files:

1. The platform-specific native entry point initializes the MAUI application.
2. `MauiProgram.cs` configures the application and registers required services.
3. `App.xaml.cs` creates the application instance and its initial window.
4. `AppShell.xaml` defines the navigation structure.
5. `MainPage.xaml` displays the initial user interface.

### 5. Running the Application

The application can be executed on supported platforms using Visual Studio.

- Android: Run using an Android Emulator or physical Android device.
- iOS: Run using an iOS Simulator or physical iOS device from a Mac.
- Windows: Run using the Windows Machine target.
- Mac Catalyst: Run on a supported Mac environment.

## Architecture Benefits

- Shared code reduces duplication.
- Platform-specific implementations remain isolated.
- A single project simplifies development and maintenance.
- Shared UI and business logic can be reused across supported platforms.

### Task 4: Safe Area Handling

**Implementation:**

I configured the `SafeAreaEdges` property of the `InspectorProfilePage` to `All`.

```xml
<ContentPage
    ...
    SafeAreaEdges="All">
```

**Why it was needed:**

Modern mobile devices have screen features such as camera notches, status bars, rounded corners, navigation bars, and home indicators. Without appropriate safe-area handling, application content may overlap these areas or become difficult to access.

**What I did:**

- Used `SafeAreaEdges="All"` to ensure the page respects all safe-area insets.
- Retained the existing `ScrollView` so content remains accessible on smaller screens.
- Used the application's shared `ResourceDictionary` for page padding and layout spacing.
- Avoided manually adding device-specific top or bottom margins.

**Expected result:**

The Inspector Profile page remains properly positioned across different device sizes and avoids overlapping system UI elements, including the notch, status bar, home indicator, and on-screen keyboard.