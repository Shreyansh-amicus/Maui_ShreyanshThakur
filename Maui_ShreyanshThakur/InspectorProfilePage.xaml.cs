
namespace Maui_ShreyanshThakur
{
    public partial class InspectorProfilePage : ContentPage
    {
        public InspectorProfilePage()
        {
            InitializeComponent();
        }

        private async void OnEditProfileClicked(
            object sender,
            EventArgs e)
        {
            await DisplayAlert(
                "Edit Profile",
                "Edit Profile button clicked!",
                "OK");
        }
    }
}
