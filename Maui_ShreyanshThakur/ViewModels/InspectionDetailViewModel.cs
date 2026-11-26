
using Maui_ShreyanshThakur.Models;

namespace Maui_ShreyanshThakur.ViewModels;

public class InspectionDetailViewModel : BaseViewModel
{
    private Inspection? _selectedInspection;

    public Inspection? SelectedInspection
    {
        get => _selectedInspection;
        set
        {
            if (SetProperty(ref _selectedInspection, value))
            {
                OnPropertyChanged(nameof(IsInspectionFound));
            }
        }
    }

    public bool IsInspectionFound =>
        SelectedInspection is not null;

    public void LoadInspection(int inspectionId)
    {
        SelectedInspection = InspectionSampleData
            .GetInspections()
            .FirstOrDefault(inspection => inspection.Id == inspectionId);
    }
}
