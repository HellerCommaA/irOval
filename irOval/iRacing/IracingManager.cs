using iRacingSDK;
using irOval.Config;
using System;

namespace irOval.iRacing
{
    /**
     * This class owns the connection and incoming data callbacks
     * from the iRacingSdkNet package
     **/
    public class IracingManager
    {
        private iRacingEvents events;

        private Action? connectAction = null;
        private Action? disconnectAction = null;
        private Action<DataSample>? newEventAction = null;

        public IracingManager()
        {
            events = new iRacingEvents(irOvalConfig.IRACING_POLL_TIME);
            events.Connected += EventsConnected;
            events.Disconnected += EventsDisconnected;
            events.NewData += EventsNewData;
        }
        public void Dispose()
        {
            events.Dispose();
        }

        public void Connect()
        {
            events.StartListening();
        }

        public void Disconnect()
        {
            events.StopListening();
        }

        public void OnConnected(Action action)
        {
            connectAction = action;
        }

        public void OnDisconnected(Action action)
        {
            disconnectAction = action;
        }

        public void OnNewData(Action<DataSample> action)
        {
            newEventAction = action;
        }


        private void EventsNewData(DataSample data)
        {
            newEventAction?.Invoke(data);
        }

        private void EventsDisconnected()
        {
            disconnectAction?.Invoke();
        }

        private void EventsConnected()
        {
            connectAction?.Invoke();
        }
    }
}
