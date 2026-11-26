using Maui_ShreyanshThakur.Models;
using Maui_ShreyanshThakur.ViewModels;

namespace Maui_ShreyanshThakur;

public partial class InspectionListPage : ContentPage
{
    public InspectionListPage()
    {
        InitializeComponent();

        BindingContext = new InspectionListViewModel();
    }

    private async void OnNewInspectionClicked(
        object sender,
        EventArgs e)
    {
        if (BindingContext is not InspectionListViewModel viewModel)
            return;

        await Navigation.PushModalAsync(
            new NewInspectionPage(viewModel.AddInspection));
    }

    private async void OnInspectionSelectionChanged(
        object sender,
        SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Inspection inspection)
            return;

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