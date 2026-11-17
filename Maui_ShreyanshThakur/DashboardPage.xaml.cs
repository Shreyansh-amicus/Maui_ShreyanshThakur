namespace Maui_ShreyanshThakur
{
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        private async void OnOpenCollectionViewClicked(
            object sender,
            EventArgs e)
        {
            await Shell.Current.GoToAsync(
                nameof(InspectionListPage));
        }

        private async void OnOpenListViewClicked(
            object sender,
            EventArgs e)
        {
            await Shell.Current.GoToAsync(
                nameof(InspectionListListViewPage));
        }
    }
}