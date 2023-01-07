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

        Label runningLabel;

        Button startButton;

        iRacingEvents irc;

        bool showIracingData = false;


        void SetupIracingSdk()
        {
            irc = new iRacingEvents();
            irc.Connected += Irc_Connected;
            irc.Disconnected += Irc_Disconnected;
            irc.NewData += IracingNewData;
        }

        private void Irc_Disconnected()
        {
            startButton.Content = "Connect";
        }

        private void Irc_Connected()
        {
            startButton.Content = "Disconnect";
        }

        private void IracingNewData(DataSample data)
        {
            throttleTextBlock.Text = $"Throttle: {data.Telemetry.Throttle * 100}%";

        }

        void SetupWidgets()
        {
            throttleTextBlock = (TextBlock)FindName("ThrottleTextBlock");

            runningLabel = (Label)FindName("RunningLabel");

            startButton = (Button)FindName("StartButton");

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
                irc.StartListening();
                runningLabel.Content = "Running";
            }
            else
            {
                irc.StopListening();
                runningLabel.Content = "Not running";
            }
        }
    }
}
