using irOval.Models;
using System.Windows;
using System.Windows.Controls;

namespace irOval.Settings
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {

        OverlayWindow overlay;

        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (StartButton.Content.Equals("Start"))
            {
                overlay = new();
                overlay.Topmost = true;
                overlay.ResizeMode = ResizeMode.NoResize;
                overlay.AllowsTransparency = true;
                overlay.WindowStyle = WindowStyle.None;
                overlay.Background = System.Windows.Media.Brushes.Transparent;
                overlay.Init();
                overlay.Show();

                overlay.Closed += Overlay_Closed;

                this.WindowState = WindowState.Minimized;
                StartButton.Content = "Stop";
            }
            else
            {
                overlay.Close();
                StartButton.Content = "Start";
            }
        }

        private void Overlay_Closed(object? sender, System.EventArgs e)
        {
            this.WindowState = WindowState.Normal;
            StartButton.Content = "Start";
        }

        private void SliderLaps_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider)sender;
            if (slider.Tag.Equals("X"))
            {
                SettingsModel.Instance.LastXLapsAvg = (int)e.NewValue;
            }
            if (slider.Tag.Equals("Y"))
            {
                SettingsModel.Instance.LastYLapsAvg = (int)e.NewValue;
            }
            if (slider.Tag.Equals("Z"))
            {
                SettingsModel.Instance.LastZLapsAvg = (int)e.NewValue;
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;

            if (cb.Tag.Equals("X"))
            {
                SettingsModel.Instance.LastXEnabled = cb.IsEnabled;
            }

            if (cb.Tag.Equals("Y"))
            {
                SettingsModel.Instance.LastYEnabled = cb.IsEnabled;
            }

            if (cb.Tag.Equals("Z"))
            {
                SettingsModel.Instance.LastZEnabled = cb.IsEnabled;
            }
        }
    }
}
