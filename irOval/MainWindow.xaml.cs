using iRacingSDK;
using System.Windows;
using System.Windows.Controls;

namespace irOval
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBlock throttleTextBlock;

        private Label runningLabel;

        iRacingConnection irc;

        bool showIracingData = false;


        void SetupIracingSdk()
        {
            irc = new iRacingConnection();
            irc.NewSessionData += IracingNewData;
        }

        private void IracingNewData(DataSample data)
        {
            if (!showIracingData) return;

            throttleTextBlock.Text = $"Throttle: {data.Telemetry.Throttle}%";

        }

        void SetupWidgets()
        {
            throttleTextBlock = (TextBlock)FindName("ThrottleTextBlock");

            runningLabel = (Label)FindName("RunningLabel");

        }

        public MainWindow()
        {
            //AllowsTransparency="True"
            //WindowStyle="None"
            //Background="Transparent"
            InitializeComponent();

            SetupWidgets();

            SetupIracingSdk();
        }

        private void StartButtonMouseClick(object sender, RoutedEventArgs e)
        {
            showIracingData = !showIracingData;
            if (showIracingData)
            {
                runningLabel.Content = "Running";
            }
            else
            {
                runningLabel.Content = "Not running";
            }
        }
    }
}
