# MauiAssignment

## Overview

MauiAssignment is a cross-platform application developed using **.NET MAUI (Multi-platform App UI)**.

.NET MAUI allows developers to build applications for Android, iOS, macOS, and Windows using a shared C# codebase and a single-project structure.

## Project Structure

The application follows the **.NET MAUI single-project architecture**. Most application logic and user interface components are shared across platforms, while platform-specific configurations are maintained separately.

### 1. Shared Application Files

- **App.xaml:** Contains application-level resources, styles, colors, and other shared XAML definitions.
- **App.xaml.cs:** Defines the application class, handles application lifecycle events, and creates the initial application window.
- **AppShell.xaml:** Defines the application's navigation structure using Shell.
- **AppShell.xaml.cs:** Contains the code-behind associated with AppShell and handles navigation configuration.
- **MainPage.xaml:** Defines the default MainPage user interface.
- **MainPage.xaml.cs:** Contains the C# logic associated with MainPage.
- **InspectorProfilePage.xaml:** Defines the Inspector Profile interface, including the inspector's photo and personal information.
- **InspectorProfilePage.xaml.cs:** Contains the code-behind associated with InspectorProfilePage, including its event handlers.
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

- **AppIcon:** Contains application icons.
- **Fonts:** Stores custom fonts used throughout the application.
- **Images:** Contains images and graphical assets, including the inspector profile image.
- **Raw:** Stores files included directly in the application package.
- **Splash:** Contains splash screen assets.
- **Styles:** Contains shared resource dictionaries for application colors, dimensions, and styles.

The Styles folder follows a centralized resource management approach:

- **Colors.xaml:** Defines reusable application colors.
- **Dimensions.xaml:** Defines shared spacing, font sizes, and layout dimensions.
- **Styles.xaml:** Defines implicit and explicit styles for reusable UI components.

These resource dictionaries are merged through App.xaml and referenced using `StaticResource` to maintain consistency and avoid hardcoded visual values across pages.

### 4. Application Startup

The application startup process involves the following files:

1. The platform-specific native entry point initializes the MAUI application.
2. `MauiProgram.cs` configures the application and registers required services.
3. `App.xaml.cs` creates the application instance and its initial window.
4. `AppShell.xaml` defines the application's navigation structure and initial page.
5. `InspectorProfilePage.xaml` displays the Inspector Profile interface through the Shell configuration.

### 5. Running the Application

The application can be executed on supported platforms using Visual Studio.

- **Android:** Run using an Android Emulator or physical Android device.
- **iOS:** Run using an iOS Simulator or physical iOS device from a Mac.
- **Windows:** Run using the Windows Machine target.
- **Mac Catalyst:** Run on a supported Mac environment.

### 6. Architecture Benefits

- **Code Reusability:** Shared code reduces duplication across supported platforms.
- **Separation of Concerns:** Platform-specific implementations remain isolated from shared application logic.
- **Maintainability:** A single project structure simplifies development and maintenance.
- **Resource Consistency:** Centralized resource dictionaries ensure consistent colors, dimensions, and styles throughout the application.
- **Cross-Platform Support:** Shared UI and business logic can be reused across supported platforms.

---

## Assignment Tasks

### Task 2: Application Lifecycle Events

**Implementation:**

Application lifecycle events are monitored through the `Window` events in `App.xaml.cs`.

The application logs lifecycle events such as:

- `Created`
- `Activated`
- `Deactivated`
- `Stopped`
- `Resumed`
- `Destroying`

**Why it was needed:**

Application lifecycle events help identify changes in the application's execution state, such as when an application starts, moves into the background, or returns to the foreground.

**What I did:**

- Registered event handlers for the relevant Window lifecycle events.
- Used `Debug.WriteLine()` to log lifecycle activity.
- Tested the application by launching it, pressing the Home button, returning to the application, and closing it.
- Documented the observed event sequence and potential real-world use cases.

### Task 3: Inspector Profile Page

**Implementation:**

Created `InspectorProfilePage` using XAML and .NET MAUI layout controls.

**What I did:**

- Used `VerticalStackLayout` to organize the page content vertically.
- Used `HorizontalStackLayout` to arrange profile information and other elements horizontally.
- Added an `Image` control to display the inspector's photograph.
- Displayed the inspector's name, employee ID, role, email address, and phone number.
- Added an Edit Profile button with a click event handler.
- Used shared resource dictionaries for colors, dimensions, and styles.

**Expected result:**

The application displays a structured Inspector Profile page with the inspector's personal information and an Edit Profile action.

### Task 4: Safe Area Handling

**Implementation:**

Configured the `SafeAreaEdges` property of `InspectorProfilePage` to `All`.

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

# CollectionView vs ListView Comparison

## Objective

The objective of this task was to implement the same inspection list using both CollectionView and ListView in .NET MAUI and compare their features and suitability for larger datasets.

## Implementation

Two separate pages were created:

- `InspectionListPage`: Uses CollectionView to display 12 hardcoded inspection records.
- `InspectionListListViewPage`: Uses ListView to display the same 12 inspection records.

Both implementations display:
- Inspection title
- Site
- Status
- Scheduled date

Both lists use an ItemTemplate to define the appearance of each inspection and support single-item selection with visual highlighting.

The inspection records are shared through a common model and sample-data class to avoid duplicating the data.

## Comparison

| Feature | CollectionView | ListView |
|---|---|---|
| Virtualization | Supported | Supported |
| Item selection | Supported | Supported |
| Custom item templates | Supported | Supported |
| Multiple layouts | Supported | Limited |
| Empty view | Built-in | Requires additional handling |
| Flexibility | High | More limited |
| API direction | Modern MAUI control | Older control |

## Choice for 1,000 Items

I would choose CollectionView for displaying 1,000 inspection records.

CollectionView provides efficient item virtualization, flexible layouts, built-in empty-view support and a modern API designed for collection-based interfaces.

ListView also supports virtualization and can display large collections, but CollectionView offers greater flexibility and is the recommended choice for new .NET MAUI applications.

Actual performance depends on the complexity of the item template, data retrieval, image loading and the device being used.

## Conclusion

Both controls were implemented successfully using the same inspection data.

CollectionView is the preferred option for the inspection-management application because it offers better layout flexibility, modern collection features and a more suitable foundation for future enhancements.