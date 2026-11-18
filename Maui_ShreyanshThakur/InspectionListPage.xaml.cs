using Maui_ShreyanshThakur.Models;
using System.Collections.ObjectModel;

namespace Maui_ShreyanshThakur;

public partial class InspectionListPage : ContentPage
{
    public ObservableCollection<Inspection> Inspections { get; set; }

    public Inspection? SelectedInspection { get; private set; }

    public string InspectionCountText =>
        $"{Inspections.Count} inspections scheduled";

    public InspectionListPage()
    {
        InitializeComponent();

        Inspections = new ObservableCollection<Inspection>(
            InspectionSampleData.GetInspections());

        BindingContext = this;
    }

    private void OnCollectionViewClicked(object sender, EventArgs e)
    {
        InspectionCollection.IsVisible = true;
        InspectionList.IsVisible = false;

        CollectionViewButton.Style =
            (Style)Application.Current!.Resources[
                "InspectionViewSelectedButtonStyle"];

        ListViewButton.Style =
            (Style)Application.Current.Resources[
                "InspectionViewUnselectedButtonStyle"];
    }

    private void OnListViewClicked(object sender, EventArgs e)
    {
        InspectionCollection.IsVisible = false;
        InspectionList.IsVisible = true;

        CollectionViewButton.Style =
            (Style)Application.Current!.Resources[
                "InspectionViewUnselectedButtonStyle"];

        ListViewButton.Style =
            (Style)Application.Current.Resources[
                "InspectionViewSelectedButtonStyle"];
    }

    private void OnSelectionChanged(
        object sender,
        SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0)
            return;

        if (e.CurrentSelection.FirstOrDefault() is Inspection inspection)
        {
            SelectInspection(inspection);
        }
    }

    private void OnItemSelected(
        object sender,
        SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Inspection inspection)
        {
            SelectInspection(inspection);
        }
    }

    private void SelectInspection(Inspection selectedInspection)
    {
        SelectedInspection = selectedInspection;

        foreach (var inspection in Inspections)
        {
            inspection.IsSelected =
                inspection.Id == selectedInspection.Id;
        }

        System.Diagnostics.Debug.WriteLine(
            $"Selected inspection ID: {selectedInspection.Id}");

        System.Diagnostics.Debug.WriteLine(
            $"Selected inspection: {selectedInspection.Title}");
    }
}