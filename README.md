# .NET MAUI Inspection Management Application

## Overview

This project is a cross-platform inspection management application developed using **.NET MAUI (Multi-platform App UI)**.

The application provides an interface for inspectors to view inspection summaries, browse inspection records, review inspection details, and access their profile information.

The project was developed as part of a .NET MAUI assignment covering application fundamentals, lifecycle events, layouts, controls, collection views, styling, reusable components, and XAML refactoring.

---

# SETUP & FUNDAMENTALS

## Task 1: Create a .NET MAUI Single-Project Application

### Overview

.NET MAUI allows developers to create cross-platform applications using a shared C# codebase and a single project structure.

The application shares its UI, business logic, models, and resources across platforms while maintaining platform-specific configuration and entry points.

### Project Structure

```text
Maui_ShreyanshThakur/
│
├── App.xaml
├── App.xaml.cs
│
├── AppShell.xaml
├── AppShell.xaml.cs
│
├── DashboardPage.xaml
├── DashboardPage.xaml.cs
│
├── InspectorProfilePage.xaml
├── InspectorProfilePage.xaml.cs
│
├── InspectionListPage.xaml
├── InspectionListPage.xaml.cs
│
├── InspectionListListViewPage.xaml
├── InspectionListListViewPage.xaml.cs
│
├── InspectionFilterPage.xaml
├── InspectionFilterPage.xaml.cs
│
├── Controls/
│   └── StatusBadge.xaml
│       StatusBadge.xaml.cs
│
├── Models/
│   ├── Inspection.cs
│   └── InspectionSampleData.cs
│
├── Resources/
│   ├── AppIcon/
│   ├── Fonts/
│   ├── Images/
│   ├── Raw/
│   ├── Splash/
│   └── Styles/
│       ├── Colors.xaml
│       ├── Dimensions.xaml
│       └── Styles.xaml
│
├── Platforms/
│   ├── Android/
│   ├── iOS/
│   ├── MacCatalyst/
│   └── Windows/
│
├── MauiProgram.cs
├── Maui_ShreyanshThakur.csproj
│
├── docs/
│   └── Screenshots/
│
└── REFACTOR.md
```

### Shared Application Files

The following files are shared across supported platforms:

| File | Purpose |
|---|---|
| `App.xaml` | Defines application-level resources and shared resource dictionaries. |
| `App.xaml.cs` | Creates the application and initial window, and handles application-level initialization. |
| `AppShell.xaml` | Defines the Shell navigation structure and application routes. |
| `AppShell.xaml.cs` | Contains Shell-related navigation and initialization logic. |
| `DashboardPage.xaml` | Defines the dashboard user interface. |
| `DashboardPage.xaml.cs` | Contains dashboard event handlers and page logic. |
| `InspectorProfilePage.xaml` | Defines the inspector profile interface. |
| `InspectionListPage.xaml` | Defines the inspection list using CollectionView. |
| `InspectionListListViewPage.xaml` | Defines the inspection list using ListView. |
| `InspectionFilterPage.xaml` | Defines the inspection filtering interface. |
| `Models/Inspection.cs` | Defines the inspection data model. |
| `Models/InspectionSampleData.cs` | Provides sample inspection records. |
| `MauiProgram.cs` | Configures application services, fonts, and MAUI initialization. |
| `Maui_ShreyanshThakur.csproj` | Contains project configuration, target frameworks, dependencies, and build settings. |

### Platforms Folder

The `Platforms` folder contains platform-specific code and configuration required by each operating system.

- **Android:** Contains the Android application entry point, manifest, application configuration, and platform-specific resources.
- **iOS:** Contains the iOS application entry point, application delegate, and configuration files.
- **MacCatalyst:** Contains configuration and entry-point files required to run the application on macOS through Mac Catalyst.
- **Windows:** Contains the Windows application entry point and platform-specific configuration.

Platform-specific files allow the application to integrate with native operating-system functionality while maintaining shared application code.

### Resources Folder

The `Resources` folder contains assets used throughout the application.

| Folder | Purpose |
|---|---|
| `AppIcon` | Application icon assets. |
| `Fonts` | Custom fonts used by the application. |
| `Images` | Images used throughout the application, including the inspector profile image. |
| `Raw` | Files packaged directly with the application. |
| `Splash` | Splash screen assets. |
| `Styles` | Shared colors, dimensions, and styles. |

### Application Startup

The application startup process follows this sequence:

1. The platform-specific entry point initializes the MAUI application.
2. `MauiProgram.cs` configures the application, fonts, and services.
3. `App.xaml.cs` creates the application instance and initial window.
4. `AppShell.xaml` defines the navigation structure and initial route.
5. The initial page is displayed to the user.

### Running the Application

The application can be run using Visual Studio on supported platforms.

| Platform | Execution Environment |
|---|---|
| Android | Android Emulator or physical Android device |
| iOS | iOS Simulator or physical iOS device using a Mac |
| Windows | Windows Machine target |
| MacCatalyst | Supported macOS environment |

### Architecture Benefits

- **Code Reusability:** Application logic and UI can be shared across platforms.
- **Maintainability:** Shared code reduces duplication and makes changes easier.
- **Separation of Concerns:** Platform-specific functionality is isolated in the Platforms folder.
- **Resource Consistency:** Shared resources maintain consistent styling across pages.
- **Cross-Platform Development:** Multiple platforms can be supported using a common project.

---

## Task 2: Application Lifecycle Events

### Implementation

Application lifecycle events are monitored through the Window lifecycle events in `App.xaml.cs`.

The application logs lifecycle events using `Debug.WriteLine()`.

The events monitored include:

- `Created`
- `Activated`
- `Deactivated`
- `Stopped`
- `Resumed`
- `Destroying`

### Testing Procedure

The following actions were performed to observe application lifecycle behavior:

1. Launch the application.
2. Observe the initial lifecycle events.
3. Press the Android Home button.
4. Return to the application.
5. Close the application.

### Observed Event Sequence

> Replace this section with the actual sequence observed in the Debug Output window. Lifecycle event ordering can vary depending on the platform and how the application is closed.

```text
[Insert the observed lifecycle event sequence here]
```

### Lifecycle Events and Their Real-World Uses

| Event | Description | Real-World Use |
|---|---|---|
| Created | The application window is created. | Initialize window-specific resources and UI state. |
| Activated | The application window becomes active. | Refresh information or resume user interaction. |
| Deactivated | The application window loses focus. | Pause animations, save temporary state, or stop sensitive activities. |
| Stopped | The application window is no longer actively visible. | Save application state and suspend background operations. |
| Resumed | The application resumes after being suspended. | Restore the previous state and refresh outdated information. |
| Destroying | The application window is being destroyed. | Release window-specific resources. |

### What I Learned

Lifecycle events help applications respond to changes in their execution state. They are useful for saving state, managing resources, refreshing data, and handling transitions between foreground and background execution.

---

# INSPECTOR PROFILE SCREEN

## Task 3: Create InspectorProfilePage

### Implementation

Created `InspectorProfilePage` using XAML and .NET MAUI layout controls.

### Controls and Layouts Used

- `VerticalStackLayout` to organize the page content vertically.
- `HorizontalStackLayout` to arrange profile information and controls horizontally.
- `Image` to display the inspector's photograph.
- `Label` to display text information.
- `Button` to provide the Edit Profile action.
- `Border` to create visually grouped sections and cards.

### Profile Information Displayed

- Inspector photograph
- Name
- Employee ID
- Role
- Email address
- Phone number
- Edit Profile button

### Result

The Inspector Profile page provides a structured interface for displaying inspector information and an action to edit the profile.

---

## Task 4: Safe Area Handling

### Implementation

Configured the `SafeAreaEdges` property on the page.

```xml
<ContentPage
    ...
    SafeAreaEdges="All">
```

### Why Safe Areas Are Needed

Modern mobile devices have screen features such as:

- Camera notches and cutouts.
- Status bars.
- Rounded screen corners.
- Home indicators.
- System navigation areas.

Without safe-area handling, application content may overlap system UI or become difficult to access.

### What I Did

- Used `SafeAreaEdges="All"` to respect safe-area insets.
- Retained the `ScrollView` to allow content to remain accessible on smaller screens.
- Used shared page padding and spacing resources.
- Avoided manually adding device-specific top and bottom margins.

### Result

The page content is positioned within the available safe area, reducing the risk of overlapping the notch, status bar, navigation bar, and home indicator.

---

# DASHBOARD

## Task 5: Create DashboardPage

### Implementation

Created a dashboard using a `Grid` layout with four summary cards and a Today's Inspections section.

The summary cards display:

- Total Inspections
- Pending
- In Progress
- Completed

The dashboard also includes a Priority Overview section containing High, Medium, and Low priority tags.

### Grid Layout

The dashboard uses a two-column grid for the summary cards.

```xml
<Grid
    ColumnDefinitions="*,*"
    RowDefinitions="Auto,Auto"
    ColumnSpacing="{StaticResource DashboardGridSpacing}"
    RowSpacing="{StaticResource DashboardGridSpacing}">
```

### Grid Sizing Explanation

| Grid Sizing | Usage | Reason |
|---|---|---|
| `Auto` | Rows containing content with natural height. | The row adjusts to the size required by its content. |
| `*` | Summary card columns. | Available space is distributed evenly between the columns. |
| Absolute sizes | Fixed dimensions for elements such as icons or specific visual indicators where required. | Provides predictable dimensions for elements that should not expand or shrink. |

### Today's Inspections

The dashboard includes an inspection section containing:

- Inspection title
- Site
- Scheduled time
- Priority tag
- Status badge
- View All navigation action

### Priority Tags

Priority tags are displayed using `FlexLayout`.

```xml
<FlexLayout
    Direction="Row"
    Wrap="Wrap"
    AlignItems="Start">
```

The `Wrap="Wrap"` property allows the tags to move onto the next line when there is insufficient horizontal space.

### Status Indicators

The dashboard uses the reusable `StatusBadge` control to display inspection statuses.

### Result

The dashboard provides an overview of inspection counts, priority levels, and scheduled inspection activities.

---

## Task 6: Responsive Layout Testing

### Objective

Test the dashboard in portrait and landscape orientations and on both small and large emulator screen sizes.

The objective was to ensure:

- No content is clipped.
- No elements overlap.
- Cards remain readable.
- Priority tags wrap correctly.
- The inspection list remains accessible.
- Layout spacing adapts to different screen sizes.


### Screenshots

Vertical layout             
![Vertical layout](docs/screenshots/Vertical%20layout.png)


Landscape layout           
![Landscape layout](docs/screenshots/Landscape%20layout.png)         

### Result

[Complete this section after testing all four configurations. Confirm whether any clipping or overlapping issues remain.]

---

# CONTROLS & LISTS

## Task 7: Inspection List Using CollectionView and ListView

### Objective

Create an inspection list using both `CollectionView` and `ListView` and compare their capabilities.

### Implementation

Two pages were created:

- `InspectionListPage` – uses `CollectionView`.
- `InspectionListListViewPage` – uses `ListView`.

Both pages use the same inspection model and sample data.

The sample dataset contains at least 10 inspection records with the following properties:

- Inspection title
- Site
- Status
- Scheduled date

Each control uses an `ItemTemplate` to define the appearance of individual inspection records.

### Selection

Single-item selection is enabled, and the selected inspection is visually highlighted.

### Shared Data

Inspection records are defined in:

```text
Models/Inspection.cs
Models/InspectionSampleData.cs
```

The same sample data is reused by both list implementations to ensure a fair comparison.

### CollectionView vs ListView

| Feature | CollectionView | ListView |
|---|---|---|
| Item virtualization | Supported | Supported |
| Item selection | Supported | Supported |
| Custom item templates | Supported | Supported |
| Layout flexibility | High | More limited |
| Multiple layouts | Supported | More limited |
| Empty view | Built-in support | Requires additional handling |
| API | Modern collection control | Older collection control |

### Which Control Would I Choose for 1,000 Items?

I would choose `CollectionView` for displaying 1,000 inspection records.

Both controls support virtualization, which allows them to display large collections without creating every item visually at the same time.

However, `CollectionView` provides a more flexible layout system, built-in empty-view support, and a modern API that is better suited to new .NET MAUI applications.

Actual performance also depends on the complexity of the item template, data retrieval, image loading, and device hardware.

### Conclusion

Both controls were implemented using the same inspection data.

`CollectionView` is the preferred choice for the inspection management application because it provides greater layout flexibility and is a better foundation for future enhancements.

---

## Task 8: Common Controls and Custom Resources

### Objective

Use at least five common .NET MAUI controls across the application and include an image and custom font.

### Controls Used

| Control | Usage |
|---|---|
| `Label` | Display headings, names, descriptions, and inspection information. |
| `Button` | Provide actions such as Edit Profile and navigation actions. |
| `Image` | Display the inspector's profile photograph. |
| `Entry` | Accept text input where required. |
| `Picker` | Allow selection from predefined options. |
| `Switch` | Provide a Boolean toggle where required. |
| `DatePicker` | Select a date for inspection filtering. |
| `CollectionView` | Display inspection records. |
| `ListView` | Demonstrate an alternative collection implementation. |
| `Border` | Create cards, badges, and visually grouped content. |
| `Grid` | Arrange dashboard summary cards and page sections. |
| `FlexLayout` | Display priority tags with wrapping support. |

### Custom Font

The application uses the Poppins font family.

Font files are stored in:

```text
Resources/Fonts/
```

Fonts are registered in `MauiProgram.cs` and referenced through font aliases.

Example:

```csharp
fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
fonts.AddFont("Poppins-SemiBold.ttf", "PoppinsSemiBold");
```

### Images

Images are stored in:

```text
Resources/Images/
```

The inspector's photograph is displayed using the MAUI `Image` control.

### Result

Common controls, custom fonts, and image assets are used throughout the application to provide a consistent and functional UI.

---

# STYLING & CUSTOM UI

## Task 9: Centralized ResourceDictionary

### Objective

Move colors, font sizes, and spacing values into shared resource dictionaries.

No page should contain hardcoded color values or repeated visual styling values.

### Resource Files

```text
Resources/Styles/
├── Colors.xaml
├── Dimensions.xaml
└── Styles.xaml
```

### Colors.xaml

Contains reusable color definitions used throughout the application.

Examples include:

- Page background colors
- Primary colors
- Text colors
- Card backgrounds
- Border colors
- Status colors
- Priority colors

### Dimensions.xaml

Contains reusable dimensions such as:

- Page padding
- Layout spacing
- Font sizes
- Card padding
- Corner radii
- Icon sizes
- Control heights

### Styles.xaml

Contains shared styles for controls and components.

The dictionary includes implicit styles and explicit styles.

### Implicit Styles

Implicit styles are applied automatically to controls based on their target type.

For example, a shared Label style can apply a default font family and text color to Labels without requiring each Label to explicitly reference the style.

### Explicit Styles

Explicit styles are applied using a specific resource key.

Example:

```xml
<Label
    Text="Dashboard"
    Style="{StaticResource DashboardHeaderTitleStyle}" />
```

Explicit styles allow different visual variants of the same control to be used throughout the application.

### ResourceDictionary Integration

The shared dictionaries are merged into the application's resource dictionary through `App.xaml`.

Pages reference resources using:

```xml
{StaticResource ResourceKey}
```

### Benefits

- Eliminates repeated styling declarations.
- Improves visual consistency.
- Simplifies maintenance.
- Allows global styling changes without modifying every page.
- Reduces hardcoded values in page XAML.

---

## Task 10: Reusable StatusBadge and ControlTemplate

### Reusable StatusBadge

Created a custom `StatusBadge` control using `ContentView`.

Location:

```text
Controls/
├── StatusBadge.xaml
└── StatusBadge.xaml.cs
```

The control exposes a bindable `Status` property.

Supported statuses:

- Pending
- In Progress
- Completed

Each status displays a different background color and text color.

### Usage

```xml
<controls:StatusBadge Status="{Binding Status}" />
```

The same control is reused on the Dashboard and Inspection List pages.

### Benefits

- Removes duplicated status badge XAML.
- Centralizes status-specific styling.
- Provides consistent appearance across pages.
- Makes future status changes easier.

### Reusable Card ControlTemplate

A reusable card `ControlTemplate` was created in the shared resource dictionary.

The template provides a common card appearance, including:

- Background
- Border
- Corner radius
- Padding

The content of the card can be supplied by the page using the template.

### Usage

The reusable card template is used for card-based layouts on the Dashboard and Inspector Profile pages.

### Benefits

- Avoids duplicating card container markup.
- Maintains consistent card appearance.
- Simplifies page XAML.
- Allows card styling to be updated centrally.

---

## Task 11: XAML Refactoring

Detailed before-and-after examples of duplicated XAML that was removed and layouts that were simplified are documented separately.

See:

[REFACTOR.md](REFACTOR.md)

The refactoring document describes:

1. Replacing duplicated status badge markup with a reusable `StatusBadge` control.
2. Centralizing colors, dimensions, and styles into resource dictionaries.
3. Simplifying layouts and reusing common card structures.

---

# Conclusion

This assignment provided practical experience building a cross-platform application using .NET MAUI.

The application demonstrates:

- Single-project cross-platform architecture.
- Application lifecycle event handling.
- Page creation using XAML.
- Safe-area handling.
- Responsive layouts using Grid, FlexLayout, and stack layouts.
- CollectionView and ListView implementations.
- Common MAUI controls.
- Custom fonts and images.
- Centralized resource dictionaries.
- Reusable custom controls.
- ControlTemplate-based UI reuse.
- XAML refactoring and maintainability improvements.

The resulting application provides a foundation for a cross-platform inspection management interface while demonstrating the core concepts of .NET MAUI development.
