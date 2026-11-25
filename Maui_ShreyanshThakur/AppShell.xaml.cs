namespace Maui_ShreyanshThakur
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(
                nameof(InspectorProfilePage),
                typeof(InspectorProfilePage));

            Routing.RegisterRoute(
                nameof(InspectionListPage),
                typeof(InspectionListPage));

            Routing.RegisterRoute(
                nameof(InspectionListListViewPage),
                typeof(InspectionListListViewPage));

            Routing.RegisterRoute(
                nameof(InspectionFilterPage),
                typeof(InspectionFilterPage));

            Routing.RegisterRoute(
                nameof(DashboardPage),
                typeof(DashboardPage));
        }
    }
}