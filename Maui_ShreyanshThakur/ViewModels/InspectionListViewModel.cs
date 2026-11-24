
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Maui_ShreyanshThakur.Models;

namespace Maui_ShreyanshThakur.ViewModels;

public class InspectionListViewModel : BaseViewModel
{
    private bool _isBusy;
    private bool _isCollectionViewSelected = true;

    public ObservableCollection<Inspection> Inspections { get; }

    public string InspectionCountText =>
        $"{Inspections.Count} inspections";

    // Indicates whether the data is currently loading.
    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            if (SetProperty(ref _isBusy, value))
            {
                OnPropertyChanged(nameof(IsCollectionViewVisible));
                OnPropertyChanged(nameof(IsListViewVisible));
            }
        }
    }

    // Controls which view is selected.
    public bool IsCollectionViewSelected
    {
        get => _isCollectionViewSelected;
        set
        {
            if (SetProperty(ref _isCollectionViewSelected, value))
            {
                OnPropertyChanged(nameof(IsListViewSelected));
                OnPropertyChanged(nameof(IsCollectionViewVisible));
                OnPropertyChanged(nameof(IsListViewVisible));
            }
        }
    }

    public bool IsListViewSelected => !IsCollectionViewSelected;

    // A view should only be visible when loading is finished.
    public bool IsCollectionViewVisible =>
        !IsBusy && IsCollectionViewSelected;

    public bool IsListViewVisible =>
        !IsBusy && IsListViewSelected;

    public ICommand ShowCollectionViewCommand { get; }

    public ICommand ShowListViewCommand { get; }

    public ICommand InspectionSelectedCommand { get; }

    public InspectionListViewModel()
    {
        // Start with an empty collection.
        Inspections = new ObservableCollection<Inspection>();

        Inspections.CollectionChanged += OnInspectionsCollectionChanged;

        ShowCollectionViewCommand = new Command(
            () => IsCollectionViewSelected = true);

        ShowListViewCommand = new Command(
            () => IsCollectionViewSelected = false);

        InspectionSelectedCommand = new Command<Inspection>(
            async inspection => await OnInspectionSelectedAsync(inspection));

        // Begin loading inspections.
        _ = LoadInspectionsAsync();
    }

    private async Task LoadInspectionsAsync()
    {
        try
        {
            IsBusy = true;

            // Simulate a network/API loading delay.
            await Task.Delay(2000);

            // Load the sample inspection data after the delay.
            var inspections = InspectionSampleData.GetInspections();

            foreach (var inspection in inspections)
            {
                Inspections.Add(inspection);
            }
        }
        finally
        {
            IsBusy = false;
        }
    }

    private void OnInspectionsCollectionChanged(
        object? sender,
        NotifyCollectionChangedEventArgs e)
    {
        OnPropertyChanged(nameof(InspectionCountText));
    }

    private async Task OnInspectionSelectedAsync(
        Inspection? inspection)
    {
        if (inspection == null)
            return;

        await Application.Current!.MainPage!.DisplayAlert(
            "Inspection Selected",
            $"Title: {inspection.Title}\n" +
            $"Site: {inspection.SiteName}\n" +
            $"Status: {inspection.Status}\n" +
            $"Scheduled: {inspection.ScheduledOn:dd MMM yyyy}",
            "OK");
    }
}
