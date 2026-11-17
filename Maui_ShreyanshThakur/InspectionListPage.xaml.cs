using Maui_ShreyanshThakur.Models;

namespace Maui_ShreyanshThakur
{
    public partial class InspectionListPage : ContentPage
    {
        public List<Inspection> Inspections { get; set; }

        public InspectionListPage()
        {
            InitializeComponent();

            Inspections = InspectionSampleData.GetInspections();

            BindingContext = this;
        }

        private async void OnSelectionChanged(
            object sender,
            SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Inspection selectedInspection)
            {
                await DisplayAlert(
                    "Inspection Selected",
                    $"Title: {selectedInspection.Title}\n" +
                    $"Site: {selectedInspection.Site}\n" +
                    $"Status: {selectedInspection.Status}\n" +
                    $"Scheduled: {selectedInspection.ScheduledDate:dd MMM yyyy}",
                    "OK");
            }
        }
    }
}