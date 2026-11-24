
using Maui_ShreyanshThakur.ViewModels;

namespace Maui_ShreyanshThakur;

public partial class InspectionListPage : ContentPage
{
    public InspectionListPage()
    {
        InitializeComponent();

        BindingContext = new InspectionListViewModel();
    }
}
