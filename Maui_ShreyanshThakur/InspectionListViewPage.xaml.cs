using Maui_ShreyanshThakur.Models;

namespace Maui_ShreyanshThakur
{
    public partial class InspectionListListViewPage : ContentPage
    {
        public List<Inspection> Inspections { get; set; }

        public InspectionListListViewPage()
        {
            InitializeComponent();

            Inspections = InspectionSampleData.GetInspections();

            BindingContext = this;
        }

        private async void OnItemSelected(
            object sender,
            SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Inspection selectedInspection)
            {
                await DisplayAlert(
                    "Inspection Selected",
                    $"Title: {selectedInspection.Title}\n" +
                    $"Site: {selectedInspection.SiteName}\n" +
                    $"Status: {selectedInspection.Status}\n" +
                    $"Scheduled: {selectedInspection.ScheduledOn:dd MMM yyyy}",
                    "OK");
            }
        }
    }
}