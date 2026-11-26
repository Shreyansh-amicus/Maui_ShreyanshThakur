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

# MauiAssignment

## Overview

This project is a .NET MAUI application developed to understand and implement the MVVM architecture, data binding, value converters, commands, events, and navigation.

The application is an Inspection Management app where users can log in, view inspections, search and filter records, switch between different list layouts, view inspection details, and create new inspections.

The assignment focuses on implementing these features using native .NET MAUI functionality without relying on MVVM toolkits or source generators.

## Project Structure

```text
Maui_ShreyanshThakur
│
├── Commands
│   ├── RelayCommand.cs
│   └── AsyncRelayCommand.cs
│
├── Converters
│   ├── StatusToColorConverter.cs
│   ├── DateToRelativeTextConverter.cs
│   └── InverseBooleanConverter.cs
│
├── Controls
│   └── StatusBadge.cs
│
├── Models
│   ├── Inspection.cs
│   └── InspectionSampleData.cs
│
├── ViewModels
│   ├── BaseViewModel.cs
│   ├── LoginViewModel.cs
│   ├── InspectionListViewModel.cs
│   ├── InspectionDetailViewModel.cs
│   └── NewInspectionViewModel.cs
│
├── Resources
│   └── Styles
│       ├── Colors.xaml
│       ├── Dimensions.xaml
│       └── Styles.xaml
│
├── App.xaml
├── AppShell.xaml
├── LoginPage.xaml
├── DashboardPage.xaml
├── InspectionListPage.xaml
├── InspectionDetailPage.xaml
├── NewInspectionPage.xaml
├── InspectorProfilePage.xaml
└── MauiProgram.cs
```

The project follows a separation of concerns by keeping the data models, application logic, and user interface in separate folders.

---

## 1. Create Models, ViewModels and Views folders and an Inspection model

### Implementation

Created separate folders for Models, ViewModels, and Views to organize the application according to the MVVM architecture.

Created the `Inspection` model with the following properties:

| Property | Data Type | Description |
|---|---|---|
| Id | int | Unique inspection identifier |
| Title | string | Inspection title |
| SiteName | string | Name of the inspection site |
| Status | string | Current inspection status |
| Priority | string | Inspection priority |
| ScheduledOn | DateTime | Scheduled inspection date |
| InspectorName | string | Name of the assigned inspector |
| Notes | string | Additional inspection information |

Created a `BaseViewModel` class that implements `INotifyPropertyChanged` manually.

```csharp
public class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(
        [CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetProperty<T>(
        ref T backingField,
        T value,
        [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(backingField, value))
            return false;

        backingField = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
```

### What I did

- Used `INotifyPropertyChanged` to notify the UI whenever a property value changes.
- Created a reusable `SetProperty` method to avoid repeating property-change notification logic.
- Inherited `BaseViewModel` in the application's ViewModels.
- Did not use CommunityToolkit.Mvvm or any source generators.

### Result

The application follows a basic MVVM structure, and property changes in the ViewModels are automatically reflected in the UI through data binding.

---

## 2. Create InspectionListViewModel with an ObservableCollection

### Implementation

Created `InspectionListViewModel` with an `ObservableCollection<Inspection>` to maintain the inspection records displayed on the Inspection List page.

Created `InspectionSampleData` to provide sample inspection records.

```csharp
public ObservableCollection<Inspection> Inspections { get; }
```

The `InspectionListPage` is bound to the ViewModel through its BindingContext.

```csharp
public InspectionListPage()
{
    InitializeComponent();
    BindingContext = new InspectionListViewModel();
}
```

### What I did

- Used `ObservableCollection` to store and display inspection records.
- Bound the CollectionView and ListView to the same collection.
- Added inspection records dynamically.
- Kept the page code-behind limited to UI initialization and BindingContext assignment, apart from the event handler required by Task 8.

### Experiment: ObservableCollection vs List

I replaced the `ObservableCollection` with a normal `List<Inspection>` and added an item at runtime.

**Observation:**

| ObservableCollection | List |
|---|---|
| Automatically notifies the UI when items are added or removed. | Does not notify the UI when items are added or removed. |
| Supports collection-change notifications. | Does not implement collection-change notifications. |
| Suitable for dynamically updated UI collections. | Suitable when the collection does not need automatic UI updates. |

When an item is added to a normal List, the underlying collection changes, but the UI does not automatically know that it needs to refresh.

`ObservableCollection` implements `INotifyCollectionChanged`, which notifies the UI about collection changes.

### Result

The Inspection List updates automatically whenever an inspection is added or removed from the ObservableCollection.

---

## 3. Add IsBusy and simulate loading

### Implementation

Added an `IsBusy` property to `InspectionListViewModel`.

```csharp
private bool _isBusy;

public bool IsBusy
{
    get => _isBusy;
    set => SetProperty(ref _isBusy, value);
}
```

The inspection list is loaded using an asynchronous method with a simulated two-second delay.

```csharp
private async Task LoadInspectionsAsync()
{
    try
    {
        IsBusy = true;

        await Task.Delay(2000);

        _allInspections.AddRange(
            InspectionSampleData.GetInspections());

        ApplyFilter();
    }
    finally
    {
        IsBusy = false;
        IsRefreshing = false;
    }
}
```

An ActivityIndicator is displayed while the data is loading.

```xml
<ActivityIndicator
    IsRunning="{Binding IsBusy}"
    IsVisible="{Binding IsBusy}"
    HorizontalOptions="Center"
    VerticalOptions="Center" />
```

### MVVM Responsibilities

The application separates responsibilities into three main layers.

| Layer | Responsibilities |
|---|---|
| Model | Represents application data. The Inspection model contains properties such as Title, SiteName, Status, Priority, and ScheduledOn. |
| View | Displays the user interface. XAML pages contain controls such as Entry, Button, CollectionView, ListView, and ActivityIndicator. |
| ViewModel | Handles presentation logic, commands, data binding, filtering, loading states, and communication between the Model and View. |

### Result

The loading indicator appears while the inspection list is being loaded. The simulated delay demonstrates asynchronous loading without blocking the UI thread.

---

# DATA BINDING & CONVERTERS

## 4. Add TwoWay search binding

### Implementation

Added a search Entry to `InspectionListPage.xaml` and bound its Text property to `SearchText`.

```xml
<Entry
    Placeholder="Search by title, site, status, priority..."
    Text="{Binding SearchText, Mode=TwoWay}"
    ClearButtonVisibility="WhileEditing"
    ReturnType="Search" />
```

The ViewModel applies the filter whenever the SearchText property changes.

```csharp
public string SearchText
{
    get => _searchText;
    set
    {
        if (SetProperty(ref _searchText, value))
        {
            ApplyFilter();
        }
    }
}
```

The filtering logic checks multiple inspection properties:

- Title
- SiteName
- Status
- Priority
- InspectorName
- Notes

The search is case-insensitive and handles empty search values.

### What I did

- Used TwoWay binding so changes in the Entry update the ViewModel.
- Applied filtering directly inside the SearchText setter.
- Did not add a separate Search button.
- Maintained the original inspection collection separately so filtering does not permanently remove records.

### Binding Table

The following table contains examples of bindings used throughout the application.

| Control | Property | Mode | Direction | Reason |
|---|---|---|---|---|
| Entry (Search) | Text | TwoWay | View ↔ ViewModel | User input updates SearchText, and ViewModel changes can update the Entry. |
| CollectionView | ItemsSource | OneWay | ViewModel → View | The inspection collection is provided by the ViewModel. |
| ListView | ItemsSource | OneWay | ViewModel → View | Displays the inspection records from the ViewModel. |
| ActivityIndicator | IsRunning | OneWay | ViewModel → View | The loading state is controlled by IsBusy. |
| ActivityIndicator | IsVisible | OneWay | ViewModel → View | Visibility depends on the loading state. |
| DatePicker | Date | TwoWay | View ↔ ViewModel | The selected date must be updated in the ViewModel. |
| Entry (Inspection Title) | Text | TwoWay | View ↔ ViewModel | The entered title is stored in the ViewModel. |
| Editor (Notes) | Text | TwoWay | View ↔ ViewModel | User-entered notes are stored in the ViewModel. |
| Button | Command | OneWay | ViewModel → View | The button executes a command exposed by the ViewModel. |

### Result

The inspection list filters automatically as the user types. Clearing the search restores the full list.

---

## 5. Create Value Converters

### Implementation

Created three custom value converters inside the `Converters` folder.

### 5.1 StatusToColorConverter

Converts the inspection status into a corresponding color.

| Status | Color |
|---|---|
| Pending | Orange |
| In Progress | Blue |
| Completed | Green |

The converter is used by the `StatusBadge` control to display status information visually.

### 5.2 DateToRelativeTextConverter

Converts a DateTime value into relative text without using an external library.

Examples:

| Date Difference | Display Text |
|---|---|
| 1 day ago | Yesterday |
| 3 days ago | 3 days ago |
| 1 day ahead | Tomorrow |
| 5 days ahead | In 5 days |
| Same day | Today |

This makes scheduled inspection dates easier to understand at a glance.

### 5.3 InverseBooleanConverter

Returns the opposite of a Boolean value.

```csharp
public class InverseBooleanConverter : IValueConverter
{
    public object Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture)
    {
        return value is bool result && !result;
    }

    public object ConvertBack(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture)
    {
        return value is bool result && !result;
    }
}
```

It is used to display the empty-state message when no inspections match the search.

### Result

Value converters allow the application to transform ViewModel values into UI-friendly representations without adding presentation logic to the Model.

---

## 6. Create LoginPage with validation

### Implementation

Created `LoginPage` with Email and Password Entry controls.

Created `LoginViewModel` to handle validation and authentication.

The email is validated using an email format check, and the password must contain at least eight characters.

### Validation Rules

| Field | Validation |
|---|---|
| Email | Must be in a valid email format. |
| Password | Must contain at least 8 characters. |

Error messages are displayed below the corresponding fields.

The Login button remains disabled until both fields are valid.

### What I did

- Used TwoWay binding for Email and Password.
- Added validation properties for both fields.
- Displayed individual validation messages.
- Used command CanExecute logic to control the Login button.
- Checked the entered credentials against a hardcoded user for this assignment.

### Authentication Flow

1. User enters email and password.
2. The ViewModel validates both fields.
3. If either field is invalid, the corresponding error message is displayed.
4. The Login button remains disabled until both fields are valid.
5. Valid credentials allow the user to proceed to the main application.

### Result

The login page provides basic client-side validation and prevents the Login command from executing when the input is invalid.

---

# COMMANDS & EVENTS

## 7. Implement RelayCommand and AsyncRelayCommand

### Implementation

Created two custom command classes inside the `Commands` folder.

### 7.1 RelayCommand

Implemented `RelayCommand` using `ICommand`.

It supports:

- Execute
- CanExecute
- CanExecuteChanged

The `CanExecute` method determines whether a command can run.

This is used for synchronous actions such as switching between CollectionView and ListView.

### 7.2 AsyncRelayCommand

Created `AsyncRelayCommand` to handle asynchronous operations.

It prevents the same command from executing again while an earlier execution is still running.

An internal running-state flag is used to prevent multiple simultaneous executions.

### What I did

Used the commands for:

- Login
- Loading inspections
- Refreshing the inspection list
- Switching between CollectionView and ListView
- Selecting an inspection in the ListView

### Double-Tap Login Experiment

| Scenario | Behaviour |
|---|---|
| Without execution protection | Two quick taps may start multiple login operations before the first one finishes. This can result in duplicate requests or navigation attempts. |
| With AsyncRelayCommand | The command enters a running state after the first execution. Further taps are ignored until the operation completes. |

### Result

Custom commands provide a reusable way to execute actions from the ViewModel while keeping the View free from unnecessary business logic.

---

## 8. Add Pull-to-Refresh using RefreshView

### Implementation

Added a `RefreshView` around the inspection display area.

```xml
<RefreshView
    Command="{Binding LoadInspectionsCommand}"
    IsRefreshing="{Binding IsRefreshing, Mode=TwoWay}">

    <CollectionView
        ItemsSource="{Binding Inspections}" />

</RefreshView>
```

The RefreshView is bound to the existing asynchronous loading command.

### What I did

- Added `IsRefreshing` to the ViewModel.
- Bound `IsRefreshing` using TwoWay binding.
- Connected the refresh command to `LoadInspectionsCommand`.
- Reset the refreshing state after loading completes.

### Event-Based Handler

Used the `SelectionChanged` event on the CollectionView.

```xml
<CollectionView
    ItemsSource="{Binding Inspections}"
    SelectionMode="Single"
    SelectionChanged="OnInspectionSelectionChanged" />
```

The event handler receives `SelectionChangedEventArgs`, which provides information about the current and previous selection.

### Why an Event Instead of a Command?

The SelectionChanged event provides event-specific information through `SelectionChangedEventArgs`, particularly `CurrentSelection` and `PreviousSelection`.

This makes an event-based handler suitable for this case because the page needs to identify the selected inspection directly from the event arguments.

### Result

The inspection list supports pull-to-refresh, and selecting an inspection triggers the event handler.

---

# NAVIGATION

## 9. Configure AppShell with TabBar and detail navigation

### Implementation

Configured `AppShell` with a TabBar containing three main sections:

- Dashboard
- Inspections
- Profile

The Login page is kept outside the TabBar so that users must authenticate before accessing the main application.

### Shell Structure

```text
AppShell
│
├── Login
│
└── TabBar (main)
    │
    ├── Dashboard
    │
    ├── Inspections
    │
    └── Profile
```

Registered `InspectionDetailPage` as a Shell route.

```csharp
Routing.RegisterRoute(
    nameof(InspectionDetailPage),
    typeof(InspectionDetailPage));
```

### Passing Parameters

When an inspection is selected, its Id is passed to the detail page.

```csharp
await Shell.Current.GoToAsync(
    nameof(InspectionDetailPage),
    new Dictionary<string, object>
    {
        ["inspectionId"] = inspection.Id
    });
```

The detail page implements `IQueryAttributable` to receive the parameter.

```csharp
public void ApplyQueryAttributes(
    IDictionary<string, object> query)
{
    if (query.TryGetValue("inspectionId", out object? value) &&
        int.TryParse(value?.ToString(), out int inspectionId))
    {
        _viewModel.LoadInspection(inspectionId);
    }
}
```

The detail ViewModel retrieves the matching inspection from the sample data and exposes it to the page.

### Result

The application uses Shell navigation for its main sections and supports parameter-based navigation to the inspection detail page.

---

## 10. Open New Inspection as a Modal

### Implementation

Created a `NewInspectionPage` with a form for entering inspection information.

The form contains:

- Inspection Title
- Site Name
- Status
- Priority
- Scheduled Date
- Inspector Name
- Notes

Added Save and Cancel buttons.

The page is opened as a modal using `Navigation.PushModalAsync()`.

```csharp
await Navigation.PushModalAsync(
    new NewInspectionPage(viewModel.AddInspection));
```

### Save Functionality

When the user taps Save:

1. The ViewModel validates the required fields.
2. A new Inspection object is created.
3. The inspection is passed to the parent list ViewModel through a callback.
4. The new inspection is added to the collection.
5. The modal page is closed.

### Cancel and Unsaved Changes

Implemented an `IsDirty` property in `NewInspectionViewModel` to detect whether the user has modified the form.

When Cancel is pressed:

- If the form is unchanged, the modal closes immediately.
- If the form contains unsaved changes, a confirmation dialog is displayed.

```csharp
bool discard = await Shell.Current.DisplayAlert(
    "Discard Changes?",
    "You have unsaved changes. Are you sure you want to discard them?",
    "Discard",
    "Keep Editing");
```

| User Action | Behaviour |
|---|---|
| Discard | Closes the modal and discards entered information. |
| Keep Editing | Keeps the modal open and preserves the entered information. |
| Cancel without changes | Closes the modal without showing a confirmation dialog. |

### Result

The New Inspection page opens as a modal, supports saving new inspection records, and protects users from accidentally losing unsaved changes.

**Note:** Inspection records are currently maintained in memory using the ViewModel collection. They are not persisted to a database or API.

---

## 11. Document Routes and Navigation Decisions

### Route Table

The following table describes the navigation structure of the application.

| Route | Page | Parameters |
|---|---|---|
| `//login` | LoginPage | None |
| `//main/dashboard` | DashboardPage | None |
| `//main/inspections` | InspectionListPage | None |
| `//main/profile` | InspectorProfilePage | None |
| `InspectionDetailPage` | InspectionDetailPage | `inspectionId` |
| Modal navigation | NewInspectionPage | Save callback |

The Login page is outside the TabBar, while the Dashboard, Inspections, and Profile pages are part of the main application navigation.

### Why Shell Navigation?

Shell navigation was used because the application contains multiple main sections that need a consistent navigation structure.

Benefits include:

- Centralized route registration.
- Built-in TabBar navigation.
- Support for absolute and relative routes.
- Passing parameters between pages.
- Easier management of navigation across the application.

### Shell Navigation vs PushAsync

| Shell Navigation | PushAsync |
|---|---|
| Uses registered routes. | Navigates directly to a page instance. |
| Supports route-based navigation. | Uses the navigation stack. |
| Supports route parameters. | Parameters can be passed through constructors or other mechanisms. |
| Suitable for applications with structured navigation. | Suitable for simple, direct page navigation. |

### When Would PushAsync Be Better?

Direct navigation using `PushAsync()` would be suitable for simple navigation flows where a page does not need to participate in the application's Shell route structure.

For example, opening a temporary page or a simple secondary screen in a straightforward navigation stack.

For this application, Shell navigation is used for the main application sections and the inspection detail route, while modal navigation is used for creating a new inspection because the form is a temporary workflow that should appear above the current page.

### Result

The application has a centralized navigation structure using Shell routes, with modal navigation for the New Inspection workflow.

---

# Conclusion

Through this assignment, I implemented the core concepts of .NET MAUI and the MVVM architecture.

The main concepts covered include:

- Manual implementation of `INotifyPropertyChanged`.
- Separation of Models, Views, and ViewModels.
- ObservableCollection and data binding.
- TwoWay binding and real-time search.
- Custom value converters.
- Form validation.
- Custom synchronous and asynchronous commands.
- Prevention of duplicate command execution.
- Pull-to-refresh using RefreshView.
- Event-based selection handling.
- Shell navigation and route parameters.
- Modal navigation with unsaved-change confirmation.

The assignment helped me understand how to build a maintainable .NET MAUI application by separating UI responsibilities from application logic and using the built-in MAUI features effectively.

## Limitations

- Inspection records currently use sample data.
- New inspections are stored in memory and are not persisted after the application is restarted.
- Authentication uses hardcoded credentials and is intended only for assignment purposes.
- The two-second loading delay simulates an asynchronous data-loading operation; it does not represent an actual API request.