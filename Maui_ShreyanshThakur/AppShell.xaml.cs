
using Maui_ShreyanshThakur;

namespace Maui_ShreyanshThakur;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(
            nameof(InspectionDetailPage),
            typeof(InspectionDetailPage));

        Routing.RegisterRoute(
            nameof(InspectionFilterPage),
            typeof(InspectionFilterPage));
    }
}
