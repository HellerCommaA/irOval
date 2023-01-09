using irOval.Settings;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace irOval
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        readonly SplashScreen splash = new("Images/Splash.png");
        readonly SettingsWindow settings = new();

        void ShowSplashScreen()
        {
            splash.Show(false, true);
            var splashTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(2)
            };
            splashTimer.Tick += (s, e) =>
            {
                splashTimer.Stop();
                splash.Close(TimeSpan.FromMilliseconds(200));
            };
            splashTimer.Start();
        }

        void ShowSettingsWindow()
        {
            settings.Width = 800;
            settings.Height = 450;
            settings.ResizeMode = ResizeMode.CanMinimize;
            settings.Show();
        }

        private static bool HasNoSplashArg(string[] args)
        {
            return args.Any(x => string.Equals("-nosplash", x, StringComparison.OrdinalIgnoreCase));
        }

        public void AppStart(object sender, StartupEventArgs e)
        {
            var noSplash = HasNoSplashArg(e.Args);
            if (!noSplash)
            {
                ShowSplashScreen();
            }
            ShowSettingsWindow();
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show($"Something went wrong ({e.Exception.Message})", "Oopsie daisy", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }
    }
}
