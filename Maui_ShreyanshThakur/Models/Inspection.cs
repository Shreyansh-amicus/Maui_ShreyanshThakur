
using Maui_ShreyanshThakur.ViewModels;

namespace Maui_ShreyanshThakur.Models;

public class Inspection : BaseViewModel
{
    private int _id;
    private string _title = string.Empty;
    private string _siteName = string.Empty;
    private string _status = "Pending";
    private string _priority = "Medium";
    private DateTime _scheduledOn;
    private string _inspectorName = string.Empty;
    private string _notes = string.Empty;

    // Additional property retained for list selection highlighting.
    private bool _isSelected;

    public int Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public string SiteName
    {
        get => _siteName;
        set => SetProperty(ref _siteName, value);
    }

    public string Status
    {
        get => _status;
        set => SetProperty(ref _status, value);
    }

    public string Priority
    {
        get => _priority;
        set => SetProperty(ref _priority, value);
    }

    public DateTime ScheduledOn
    {
        get => _scheduledOn;
        set => SetProperty(ref _scheduledOn, value);
    }

    public string InspectorName
    {
        get => _inspectorName;
        set => SetProperty(ref _inspectorName, value);
    }

    public string Notes
    {
        get => _notes;
        set => SetProperty(ref _notes, value);
    }

    public bool IsSelected
    {
        get => _isSelected;
        set => SetProperty(ref _isSelected, value);
    }
}
