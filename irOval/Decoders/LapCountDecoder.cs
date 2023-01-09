using iRacingSDK;
using irOval.Models;

namespace irOval.Decoders
{
    public class LapCountDecoder : IDecoder
    {
        int currentLap = 0;

        public override void Decode(DataSample data)
        {
            if (data.Telemetry.Lap != currentLap)
            {
                currentLap = data.Telemetry.Lap;
            }
        }

        public override string InitialOverlay()
        {
            return "0";
        }

        public override void Setup(ref SettingsModel model)
        {
            //
        }

        public override string ToOverlay()
        {
            return $"{currentLap}";
        }
    }
}
