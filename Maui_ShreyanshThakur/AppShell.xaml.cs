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
        }
    }
}