using iRacingSDK;
using irOval.Models;

namespace irOval.Decoders
{
    /// <summary>
    /// This class manages the multitude of decoders and dispatches 
    /// updates to them as required.
    /// </summary>
    public class DecoderManager
    {
        public LapDecoder LapXDecoder = new(0);
        public LapDecoder LapYDecoder = new(0);
        public LapDecoder LapZDecoder = new(0);

        public LapCountDecoder LapCount = new();

        private float LastLap = 0f;

        public DecoderManager() { }

        public void Setup(SettingsModel model)
        {
            LapCount.Setup(ref model);
            LapXDecoder.Setup(ref model);
            LapYDecoder.Setup(ref model);
            LapZDecoder.Setup(ref model);

            int x = model.LastXLapsAvg;
            int y = model.LastYLapsAvg;
            int z = model.LastZLapsAvg;
            if (x > 0 && model.LastXEnabled)
            {
                LapXDecoder = new(x);
            }

            if (y > 0 && model.LastYEnabled)
            {
                LapYDecoder = new(y);
            }

            if (z > 0 && model.LastZEnabled)
            {
                LapZDecoder = new(z);
            }
        }


        internal void Process(DataSample data)
        {
            if (data.Telemetry.LapLastLapTime != LastLap)
            {
                LastLap = data.Telemetry.LapLastLapTime;
            }

            LapCount.Decode(data);

            LapXDecoder.Decode(data);

            LapYDecoder.Decode(data);

            LapZDecoder.Decode(data);
        }
    }
}
