using iRacingSDK;
using irOval.Models;

namespace irOval.Decoders
{
    abstract public class IDecoder
    {
        // setup user configurable options for this decoder
        // based off the model, which is based on the UI
        public abstract void Setup(ref SettingsModel model);

        // decode iracing data into what ever the concrete class needs
        public abstract void Decode(DataSample data);

        // The decoder should know how to display itself
        // although it is ultimately not responsible for it
        public abstract string ToOverlay();

        // Setup initial text for overlay use, if any
        public abstract string InitialOverlay();
    }
}
