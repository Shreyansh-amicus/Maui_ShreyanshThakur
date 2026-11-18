
using Microsoft.Maui.Controls;

namespace Maui_ShreyanshThakur.Controls;

public partial class StatusBadge : ContentView
{
    public static readonly BindableProperty StatusProperty =
        BindableProperty.Create(
            nameof(Status),
            typeof(string),
            typeof(StatusBadge),
            "Pending",
            propertyChanged: OnStatusChanged);

    public string Status
    {
        get => (string)GetValue(StatusProperty);
        set => SetValue(StatusProperty, value);
    }

    public StatusBadge()
    {
        InitializeComponent();
        UpdateBadgeAppearance();
    }

    private static void OnStatusChanged(
        BindableObject bindable,
        object oldValue,
        object newValue)
    {
        if (bindable is StatusBadge badge)
        {
            badge.UpdateBadgeAppearance();
        }
    }

    private void UpdateBadgeAppearance()
    {
        if (BadgeBorder == null || BadgeLabel == null)
            return;

        var status = Status?.Trim();

        switch (status)
        {
            case "Pending":
                BadgeBorder.BackgroundColor =
                    (Color)Application.Current!.Resources["StatusPendingBackgroundColor"];

                BadgeLabel.TextColor =
                    (Color)Application.Current.Resources["StatusPendingTextColor"];
                break;

            case "In Progress":
                BadgeBorder.BackgroundColor =
                    (Color)Application.Current!.Resources["StatusInProgressBackgroundColor"];

                BadgeLabel.TextColor =
                    (Color)Application.Current.Resources["StatusInProgressTextColor"];
                break;

            case "Completed":
                BadgeBorder.BackgroundColor =
                    (Color)Application.Current!.Resources["StatusCompletedBackgroundColor"];

                BadgeLabel.TextColor =
                    (Color)Application.Current.Resources["StatusCompletedTextColor"];
                break;

            default:
                BadgeBorder.BackgroundColor =
                    (Color)Application.Current!.Resources["StatusPendingBackgroundColor"];

                BadgeLabel.TextColor =
                    (Color)Application.Current.Resources["StatusPendingTextColor"];
                break;
        }
    }
}
