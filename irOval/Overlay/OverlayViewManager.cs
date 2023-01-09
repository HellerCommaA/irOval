using irOval.Decoders;
using irOval.Models;
using System.Windows;

namespace irOval.Overlay
{
    /**
     * This class behaves as a view abstraction for
     * OverlayWindow.xaml.cs
     **/
    public class OverlayViewManager
    {
        public OverlayViewManager() { }

        public OverlayWindow Context { get; set; }

        internal void Setup(SettingsModel model, ref DecoderManager dcm)
        {
            Context.LapTextBlock.Text = dcm.LapCount.InitialOverlay();

            int x = model.LastXLapsAvg;
            int y = model.LastYLapsAvg;
            int z = model.LastZLapsAvg;
            if (x > 0 && model.LastXEnabled)
            {
                Context.TextBlockX.Text = $"Last {x}";
            }
            else
            {
                Context.TextBlockX.Visibility = Visibility.Hidden;
                Context.LastX.Visibility = Visibility.Hidden;
            }

            if (y > 0 && model.LastYEnabled)
            {
                Context.TextBlockY.Text = $"Last {y}";
            }
            else
            {
                Context.TextBlockY.Visibility = Visibility.Hidden;
                Context.LastY.Visibility = Visibility.Hidden;
            }

            if (z > 0 && model.LastZEnabled)
            {
                Context.TextBlockZ.Text = $"Last {z}";
            }
            else
            {
                Context.TextBlockZ.Visibility = Visibility.Hidden;
                Context.LastZ.Visibility = Visibility.Hidden;
            }
        }
    }
}
