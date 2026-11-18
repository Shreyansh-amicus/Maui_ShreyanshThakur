namespace Maui_ShreyanshThakur
{
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        private async void OnViewAllInspectionsClicked(
            object sender,
            TappedEventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(InspectionListPage));
        }

        private async void OnOpenProfileClicked(
            object sender,
            TappedEventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(InspectorProfilePage));
        }
    }
}