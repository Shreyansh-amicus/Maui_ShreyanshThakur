using Maui_ShreyanshThakur.ViewModels;

namespace Maui_ShreyanshThakur;

public partial class InspectionDetailPage : ContentPage, IQueryAttributable
{
    private readonly InspectionDetailViewModel _viewModel;

    public InspectionDetailPage()
    {
        InitializeComponent();

        _viewModel = new InspectionDetailViewModel();
        BindingContext = _viewModel;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("inspectionId", out object? value) &&
            int.TryParse(value?.ToString(), out int inspectionId))
        {
            _viewModel.LoadInspection(inspectionId);
        }
    }
}