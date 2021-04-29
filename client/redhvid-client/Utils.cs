using System;

namespace Redhvid
{
    public static class Utils
    {
        public static String GetGRPCUrl()
        {
            String proto = Properties.Settings.Default.GrpcSSL ? "https" : "http";
            String host = Properties.Settings.Default.GrpcHost;
            uint port = Properties.Settings.Default.GrpcPort;
            return $"{proto}://{host}:{port}";
        }
    }
}
