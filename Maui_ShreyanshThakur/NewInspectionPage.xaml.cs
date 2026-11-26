using Maui_ShreyanshThakur.Models;
using Maui_ShreyanshThakur.ViewModels;

namespace Maui_ShreyanshThakur;

public partial class NewInspectionPage : ContentPage
{
    public NewInspectionPage(Action<Inspection> onSave)
    {
        InitializeComponent();

        BindingContext = new NewInspectionViewModel(
            onSave,
            async () => await Navigation.PopModalAsync());
    }
}