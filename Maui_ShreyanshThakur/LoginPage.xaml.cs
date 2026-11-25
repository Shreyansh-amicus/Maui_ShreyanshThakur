using Maui_ShreyanshThakur.ViewModels;

namespace Maui_ShreyanshThakur;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();

        BindingContext = new LoginViewModel();
    }
}