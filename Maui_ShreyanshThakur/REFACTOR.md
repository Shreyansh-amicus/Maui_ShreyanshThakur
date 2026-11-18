# XAML Refactoring Documentation

This document describes refactoring improvements made to the MAUI inspection application to reduce duplicated XAML, improve maintainability, and create reusable UI components.

## 1. Replaced Duplicated Status Badge Markup with a Reusable Control

**Location:** Dashboard and Inspection List pages

### Before
Each inspection displayed its status using separate XAML elements, such as a `Border` and a `Label`. The background color, text color, padding, and styling had to be repeated for Pending, In Progress, and Completed statuses.

```xml
<Border BackgroundColor="..."
        Padding="...">
    <Label Text="Pending"
           TextColor="..."
           FontSize="..." />
</Border>
```

The same structure was repeated for other statuses, with different colors and text.

### After
Created a reusable `StatusBadge` ContentView with a bindable `Status` property.

```xml
<controls:StatusBadge Status="{Binding Status}" />
```

The control determines the appropriate background and text colors based on the status.

**Benefits:**
- Eliminated repeated badge markup.
- Centralized status-specific styling and behavior.
- Made status badges consistent across different pages.
- Easier to maintain and update in the future.

---

## 2. Centralized Styles, Colors, and Dimensions

**Location:** `Resources/Styles/Colors.xaml`, `Dimensions.xaml`, and `Styles.xaml`

### Before
Visual properties such as colors, padding, spacing, font sizes, and corner radii were specified directly on individual XAML elements.

```xml
<Label
    Text="Dashboard"
    FontSize="24"
    FontFamily="PoppinsSemiBold"
    TextColor="#1F2937" />
```

Similar styling values were repeated across multiple pages and controls.

### After
Moved reusable visual properties into shared resource dictionaries and referenced them using `StaticResource`.

```xml
<Label
    Text="Dashboard"
    Style="{StaticResource DashboardHeaderTitleStyle}" />
```

Common dimensions and colors are also referenced through resource keys.

**Benefits:**
- Reduced repeated styling declarations.
- Improved consistency throughout the application.
- Changes to common styling can be made in one location.
- Pages contain less presentation-related code.

---

## 3. Simplified Dashboard Priority Overview Layout

**Location:** `DashboardPage.xaml`

### Before
The priority overview and its controls required separate layout elements with individually specified positioning and alignment.

### After
Used a `Grid` with two columns to organize the section title and Filter button in a single header row.

```xml
<Grid ColumnDefinitions="*,Auto">

    <Label
        Text="Priority Overview"
        Style="{StaticResource DashboardSectionTitleStyle}" />

    <Border
        Grid.Column="1"
        Style="{StaticResource DashboardFilterButtonStyle}">

        <Border.GestureRecognizers>
            <TapGestureRecognizer
                Tapped="OnOpenFilterClicked" />
        </Border.GestureRecognizers>

        <Label
            Text="Filter"
            Style="{StaticResource DashboardFilterButtonLabelStyle}" />

    </Border>

</Grid>
```

The priority tags are displayed using a `FlexLayout` with wrapping enabled.

```xml
<FlexLayout
    Direction="Row"
    Wrap="Wrap"
    AlignItems="Start">

    <!-- High, Medium, and Low priority tags -->

</FlexLayout>
```

**Benefits:**
- Simplified the section header layout.
- Kept the title and Filter button aligned.
- Allowed priority tags to wrap naturally on smaller screens.
- Improved responsiveness across different screen sizes.

---

## Conclusion

These refactoring changes improve the maintainability and consistency of the application by introducing reusable controls, centralized styling resources, and simpler responsive layouts. They also make future UI changes easier because common components and styles can be updated without modifying every individual page.
