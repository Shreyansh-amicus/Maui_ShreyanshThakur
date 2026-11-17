using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
namespace Maui_ShreyanshThakur
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new AppShell());

            // Application lifecycle event logging

            /*
            * APPLICATION LIFECYCLE EVENT OBSERVATIONS
            *
            * Testing Environment: Android Emulator (Pixel 7)
            *
            * 1. Application Launch:
            *    - Created
            *    - Activated
            *
            *    Created is fired when the application window is created.
            *    Activated is fired when the application window becomes active.
            *
            * 2. Pressing the Android Home Button:
            *    - Deactivated
            *    - Stopped
            *
            *    Deactivated is fired when the application loses focus.
            *    Stopped is fired when the application moves out of the foreground.
            *
            * 3. Returning to the Application:
            *    - Resumed
            *    - Activated (depending on platform event ordering)
            *
            *    Resumed is fired when the application returns from the stopped state.
            *    Activated indicates that the application window becomes active again.
            *
            * 4. Closing the Application:
            *    - Destroying (if raised by the platform)
            *
            *    Destroying is fired when the application window is being destroyed.
            *
            * REAL-WORLD USE CASES:
            *
            * - Created:
            *   Initialize application resources and prepare the initial UI.
            *
            * - Activated:
            *   Refresh UI elements and resume interactions when the app becomes active.
            *
            * - Deactivated:
            *   Pause activities that require user attention or active interaction.
            *
            * - Stopped:
            *   Pause background-sensitive operations and save temporary application state.
            *
            * - Resumed:
            *   Refresh data, restart paused operations, and restore the user experience.
            *
            * - Destroying:
            *   Release resources associated with the window.
            *
            * NOTE:
            * The exact event sequence may vary depending on the platform.
            * Destroying is not guaranteed when the operating system terminates
            * the application process. Important data should therefore be saved
            * before relying on this event.
            */


            window.Created += (sender, args) =>
            {
                LogLifecycleEvent("Created");
            };

            window.Activated += (sender, args) =>
            {
                LogLifecycleEvent("Activated");
            };

            window.Deactivated += (sender, args) =>
            {
                LogLifecycleEvent("Deactivated");
            };

            window.Stopped += (sender, args) =>
            {
                LogLifecycleEvent("Stopped");
            };

            window.Resumed += (sender, args) =>
            {
                LogLifecycleEvent("Resumed");
            };

            window.Destroying += (sender, args) =>
            {
                LogLifecycleEvent("Destroying");
            };

            return window;
        }

        private static void LogLifecycleEvent(string eventName)
        {
            Debug.WriteLine(
                $"[{DateTime.Now:HH:mm:ss}] Lifecycle Event: {eventName}");
        }
    }
}