using System;

namespace irOval.Config
{
    public class irOvalConfig
    {
        // How often to poll iracing shared memory
        public static TimeSpan IRACING_POLL_TIME = TimeSpan.FromMilliseconds(100);
    }
}
