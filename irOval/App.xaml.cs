using System.Windows;

namespace irOval
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public void AppStart(object sender, StartupEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Title = "This is a test";
            mw.Show();
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show($"Something went wrong ({e.Exception.Message})", "Oopsie daisy", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }
    }
}
