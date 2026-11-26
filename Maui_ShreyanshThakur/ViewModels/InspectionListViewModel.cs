
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using Maui_ShreyanshThakur.Commands;
using Maui_ShreyanshThakur.Models;

namespace Maui_ShreyanshThakur.ViewModels;

public class InspectionListViewModel : BaseViewModel
{
    // Keeps the original collection so searching doesn't permanently
    // remove inspections from the data source.
    private readonly List<Inspection> _allInspections = new();

    private bool _isBusy;
    private bool _isRefreshing;
    private bool _isCollectionViewSelected = true;
    private string _searchText = string.Empty;

    public ObservableCollection<Inspection> Inspections { get; }

    // Commands
    public RelayCommand ShowCollectionViewCommand { get; }
    public RelayCommand ShowListViewCommand { get; }
    public AsyncRelayCommand LoadInspectionsCommand { get; }

    public ICommand InspectionSelectedCommand { get; }

    // Collection information
    public string InspectionCountText =>
        $"{Inspections.Count} inspections";

    public bool HasInspections =>
        Inspections.Count > 0;

    // Pull-to-refresh state
    public bool IsRefreshing
    {
        get => _isRefreshing;
        set => SetProperty(ref _isRefreshing, value);
    }

    // Loading state
    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            if (SetProperty(ref _isBusy, value))
            {
                OnPropertyChanged(nameof(IsCollectionViewVisible));
                OnPropertyChanged(nameof(IsListViewVisible));

                // Notify every command whose CanExecute depends on IsBusy.
                LoadInspectionsCommand.NotifyCanExecuteChanged();
                ShowCollectionViewCommand.NotifyCanExecuteChanged();
                ShowListViewCommand.NotifyCanExecuteChanged();
            }
        }
    }

    // View selection
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

    public bool IsListViewSelected =>
        !IsCollectionViewSelected;

    public bool IsCollectionViewVisible =>
        !IsBusy && IsCollectionViewSelected;

    public bool IsListViewVisible =>
        !IsBusy && IsListViewSelected;

    // Search
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

    public InspectionListViewModel()
    {
        Inspections = new ObservableCollection<Inspection>();

        Inspections.CollectionChanged += OnInspectionsCollectionChanged;

        // Initialize view toggle commands.
        ShowCollectionViewCommand = new RelayCommand(
            () => IsCollectionViewSelected = true,
            () => !IsBusy);

        ShowListViewCommand = new RelayCommand(
            () => IsCollectionViewSelected = false,
            () => !IsBusy);

        // Initialize asynchronous loading command.
        LoadInspectionsCommand = new AsyncRelayCommand(
            LoadInspectionsAsync,
            () => !IsBusy);

        // Retain inspection selection for the ListView.
        InspectionSelectedCommand = new Command<Inspection>(
            async inspection => await OnInspectionSelectedAsync(inspection));

        // Automatically load inspections when the ViewModel is created.
        _ = LoadInspectionsCommand.ExecuteAsync();
    }

    // Load and refresh inspections.
    private async Task LoadInspectionsAsync()
    {
        try
        {
            IsBusy = true;

            // Simulate an API request.
            await Task.Delay(2000);

            foreach (Inspection sample in InspectionSampleData.GetInspections())
            {
                if (!_allInspections.Any(item => item.Id == sample.Id))
                {
                    _allInspections.Add(sample);
                }
            }

            ApplyFilter();
        }
        catch (Exception ex)
        {
            if (Shell.Current is not null)
            {
                await Shell.Current.DisplayAlert(
                    "Loading Error",
                    $"Unable to load inspections: {ex.Message}",
                    "OK");
            }
        }
        finally
        {
            IsBusy = false;

            // Stop the RefreshView indicator after the operation.
            IsRefreshing = false;
        }
    }

    // Apply the search filter to the original collection.
    private void ApplyFilter()
    {
        string searchTerm = SearchText.Trim();

        IEnumerable<Inspection> filteredInspections =
            _allInspections.Where(inspection =>
                string.IsNullOrWhiteSpace(searchTerm) ||
                MatchesSearch(inspection, searchTerm));

        UpdateDisplayedInspections(filteredInspections);
    }

    // Check whether an inspection matches the search term.
    private static bool MatchesSearch(
        Inspection inspection,
        string searchTerm)
    {
        return
            ContainsSearchTerm(inspection.Title, searchTerm) ||
            ContainsSearchTerm(inspection.SiteName, searchTerm) ||
            ContainsSearchTerm(inspection.Status, searchTerm) ||
            ContainsSearchTerm(inspection.Priority, searchTerm) ||
            ContainsSearchTerm(inspection.InspectorName, searchTerm) ||
            ContainsSearchTerm(inspection.Notes, searchTerm);
    }

    // Null-safe string matching.
    private static bool ContainsSearchTerm(
        string? value,
        string searchTerm)
    {
        return value?.Contains(
            searchTerm,
            StringComparison.OrdinalIgnoreCase) == true;
    }

    // Update the ObservableCollection displayed by the UI.
    private void UpdateDisplayedInspections(
        IEnumerable<Inspection> filteredInspections)
    {
        Inspections.Clear();

        foreach (Inspection inspection in filteredInspections)
        {
            Inspections.Add(inspection);
        }
    }

    // Update count and empty-state bindings whenever the collection changes.
    private void OnInspectionsCollectionChanged(
        object? sender,
        NotifyCollectionChangedEventArgs e)
    {
        OnPropertyChanged(nameof(InspectionCountText));
        OnPropertyChanged(nameof(HasInspections));
    }

    // Handle inspection selection.

    private async Task OnInspectionSelectedAsync(
        Inspection? inspection)
    {
        if (inspection is null)
            return;

        await Shell.Current.GoToAsync(
            nameof(InspectionDetailPage),
            new Dictionary<string, object>
            {
                ["inspectionId"] = inspection.Id
            });
    }

    public void AddInspection(Inspection inspection)
    {
        // Generate the next available inspection ID.
        inspection.Id = _allInspections.Count == 0
            ? 1
            : _allInspections.Max(item => item.Id) + 1;

        // Add to the original collection.
        _allInspections.Add(inspection);

        // Refresh the displayed collection while preserving search.
        ApplyFilter();
    }

}
