using iRacingSDK;
using irOval.Models;

namespace irOval.Decoders
{
    public class LapDecoder : IDecoder
    {

        private readonly int Laps = 0;

        private float[] Laptimes;

        private int LastIdx = 0;
        private int LastLap = -1;

        public bool Enabled { get; private set; }

        public LapDecoder(int laps)
        {
            Laps = laps;

            if (Laps > 0) Enabled = true;

            Laptimes = new float[Laps];
            ClearTimes();
        }

        void ClearTimes()
        {
            for (var i = 0; i < Laptimes.Length; i++)
            {
                Laptimes[i] = -1f;
            }
        }

        public override void Decode(DataSample data)
        {
            Decode(data.Telemetry.Lap, data.Telemetry.LapLastLapTime);
        }

        // part testing harness too
        public void Decode(int xLastLap, float xLastLapTime)
        {
            if (!Enabled) return;

            if (LastLap != xLastLap)
            {
                LastLap = xLastLap;

                if (LastLap <= 0) ClearTimes();
                if (xLastLapTime <= 0) return;

                Laptimes[LastIdx] = xLastLapTime;
                if (LastIdx + 1 > Laptimes.Length - 1)
                {
                    LastIdx = 0;
                }
                else
                {
                    LastIdx++;
                }
            }
        }

        public override string ToOverlay()
        {
            int count = 0;
            float times = 0f;
            for (int i = 0; i < Laptimes.Length; i++)
            {
                float ea = Laptimes[i];
                // if valid lap
                if (ea > 0)
                {
                    count++;
                    times += ea;
                }
            }
            if (count != 0)
            {
                times /= count;
            }
            return $"{times:0.###}";
        }

        public override void Setup(ref SettingsModel model)
        {
            // get instance specific configs here
        }

        public override string InitialOverlay()
        {
            return "0";
        }
    }
}
