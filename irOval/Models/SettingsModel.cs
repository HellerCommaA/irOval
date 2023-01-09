namespace irOval.Models
{
    public class SettingsModel
    {

        private readonly static SettingsModel instance = new();

        public bool CurrentLapTime = false;

        public int LastXLapsAvg = -1;

        public int LastYLapsAvg = -1;

        public int LastZLapsAvg = -1;

        private SettingsModel()
        {

        }

        public static SettingsModel Instance { get { return instance; } }

        public bool LastXEnabled { get; internal set; } = false;
        public bool LastYEnabled { get; internal set; } = false;
        public bool LastZEnabled { get; internal set; } = false;
    }

}
