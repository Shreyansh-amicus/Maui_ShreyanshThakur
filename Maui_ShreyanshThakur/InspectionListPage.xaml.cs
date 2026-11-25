
using Maui_ShreyanshThakur.Models;
using Maui_ShreyanshThakur.ViewModels;

namespace Maui_ShreyanshThakur;

public partial class InspectionListPage : ContentPage
{
    public InspectionListPage()
    {
        InitializeComponent();

        // Connect the page to its ViewModel.
        BindingContext = new InspectionListViewModel();
    }

    private async void OnInspectionSelectionChanged(
        object sender,
        SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Inspection inspection)
            return;

        // Event handling is used here because SelectionChangedEventArgs
        // provides CurrentSelection and PreviousSelection, which are
        // specific to the CollectionView selection event.
        if (sender is CollectionView collectionView)
        {
            collectionView.SelectedItem = null;
        }

        await DisplayAlert(
            "Inspection Selected",
            $"Title: {inspection.Title}\n" +
            $"Site: {inspection.SiteName}\n" +
            $"Status: {inspection.Status}\n" +
            $"Scheduled: {inspection.ScheduledOn:dd MMM yyyy}",
            "OK");
    }
}
