
namespace Maui_ShreyanshThakur;

public partial class InspectionFilterPage : ContentPage
{
    public InspectionFilterPage()
    {
        InitializeComponent();

        StatusPicker.ItemsSource = new List<string>
        {
            "All",
            "Pending",
            "In Progress",
            "Completed"
        };

        StatusPicker.SelectedIndex = 0;

        ScheduledDatePicker.Date = DateTime.Today;
    }

    private async void OnApplyFiltersClicked(
        object sender,
        EventArgs e)
    {
        string searchTerm = string.IsNullOrWhiteSpace(SearchEntry.Text)
            ? "All"
            : SearchEntry.Text;

        string status = StatusPicker.SelectedItem?.ToString() ?? "All";

        string scheduledDate =
            ScheduledDatePicker.Date?.ToString("dd MMM yyyy") ?? "No date selected";

        string showCompleted =
            ShowCompletedSwitch.IsToggled ? "Yes" : "No";

        string message =
            $"Search: {searchTerm}\n" +
            $"Status: {status}\n" +
            $"Scheduled Date: {scheduledDate}\n" +
            $"Show Completed: {showCompleted}";

        await DisplayAlert(
            "Applied Filters",
            message,
            "OK");
    }

    private void OnResetFiltersClicked(
        object sender,
        EventArgs e)
    {
        SearchEntry.Text = string.Empty;
        StatusPicker.SelectedIndex = 0;
        ScheduledDatePicker.Date = DateTime.Today;
        ShowCompletedSwitch.IsToggled = true;
    }
}
