using iRacingSDK;
using irOval.Decoders;
using irOval.iRacing;
using irOval.Models;
using irOval.Overlay;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace irOval
{
    /// <summary>
    /// Interaction logic for OverlayWindow.xaml
    /// </summary>
    public partial class OverlayWindow : Window
    {
        IracingManager mgr = new();

        OverlayViewManager ovm = new();

        DecoderManager dcm = new();

        void SetupIracingSdk()
        {
            mgr.OnConnected(SdkConnected);
            mgr.OnDisconnected(SdkDisconnected);

            mgr.OnNewData(SdkNewData);

            mgr.Connect();
        }

        private void SdkNewData(DataSample data)
        {
            dcm.Process(data);
        }

        private void SdkConnected()
        {
            // 
        }

        private void SdkDisconnected()
        {
            //
        }

        void SetupDataProcessor()
        {
            dcm.Setup(SettingsModel.Instance);
        }

        void SetupViewManager()
        {
            ovm.Context = this;

            ovm.Setup(SettingsModel.Instance, ref dcm);
        }

        public void Init()
        {
            SetupIracingSdk();

            SetupDataProcessor();

            SetupViewManager();
        }

        public OverlayWindow()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            mgr.Dispose();
        }

        void BackgroundOnMouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        void BackgroundOnMouseUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
