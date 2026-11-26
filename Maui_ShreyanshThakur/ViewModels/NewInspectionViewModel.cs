using System.Windows.Input;
using Maui_ShreyanshThakur.Models;

namespace Maui_ShreyanshThakur.ViewModels;

public class NewInspectionViewModel : BaseViewModel
{
    private readonly Action<Inspection> _onSave;
    private readonly Func<Task> _closeModal;

    private string _title = string.Empty;
    private string _siteName = string.Empty;
    private string _status = "Pending";
    private string _priority = "Medium";
    private DateTime _scheduledOn = DateTime.Today;
    private string _inspectorName = string.Empty;
    private string _notes = string.Empty;

    public ICommand SaveCommand { get; }
    public ICommand CancelCommand { get; }

    public NewInspectionViewModel(
        Action<Inspection> onSave,
        Func<Task> closeModal)
    {
        _onSave = onSave;
        _closeModal = closeModal;

        SaveCommand = new Command(async () => await SaveAsync());
        CancelCommand = new Command(async () => await CancelAsync());
    }

    public string Title
    {
        get => _title;
        set
        {
            if (SetProperty(ref _title, value))
                OnPropertyChanged(nameof(IsDirty));
        }
    }

    public string SiteName
    {
        get => _siteName;
        set
        {
            if (SetProperty(ref _siteName, value))
                OnPropertyChanged(nameof(IsDirty));
        }
    }

    public string Status
    {
        get => _status;
        set
        {
            if (SetProperty(ref _status, value))
                OnPropertyChanged(nameof(IsDirty));
        }
    }

    public string Priority
    {
        get => _priority;
        set
        {
            if (SetProperty(ref _priority, value))
                OnPropertyChanged(nameof(IsDirty));
        }
    }

    public DateTime ScheduledOn
    {
        get => _scheduledOn;
        set
        {
            if (SetProperty(ref _scheduledOn, value))
                OnPropertyChanged(nameof(IsDirty));
        }
    }

    public string InspectorName
    {
        get => _inspectorName;
        set
        {
            if (SetProperty(ref _inspectorName, value))
                OnPropertyChanged(nameof(IsDirty));
        }
    }

    public string Notes
    {
        get => _notes;
        set
        {
            if (SetProperty(ref _notes, value))
                OnPropertyChanged(nameof(IsDirty));
        }
    }

    // Detects changes from the initial form values.
    public bool IsDirty =>
        !string.IsNullOrWhiteSpace(Title) ||
        !string.IsNullOrWhiteSpace(SiteName) ||
        !string.IsNullOrWhiteSpace(InspectorName) ||
        !string.IsNullOrWhiteSpace(Notes) ||
        Status != "Pending" ||
        Priority != "Medium" ||
        ScheduledOn.Date != DateTime.Today;

    private async Task SaveAsync()
    {
        if (string.IsNullOrWhiteSpace(Title) ||
            string.IsNullOrWhiteSpace(SiteName))
        {
            if (Shell.Current is not null)
            {
                await Shell.Current.DisplayAlert(
                    "Required Fields",
                    "Please enter an inspection title and site name.",
                    "OK");
            }

            return;
        }

        Inspection inspection = new()
        {
            Title = Title.Trim(),
            SiteName = SiteName.Trim(),
            Status = Status,
            Priority = Priority,
            ScheduledOn = ScheduledOn,
            InspectorName = InspectorName.Trim(),
            Notes = Notes.Trim()
        };

        _onSave(inspection);

        await _closeModal();
    }

    private async Task CancelAsync()
    {
        if (IsDirty)
        {
            if (Shell.Current is null)
                return;

            bool discard = await Shell.Current.DisplayAlert(
                "Discard Changes?",
                "You have unsaved changes. Are you sure you want to discard them?",
                "Discard",
                "Keep Editing");

            if (!discard)
                return;
        }

        await _closeModal();
    }
}