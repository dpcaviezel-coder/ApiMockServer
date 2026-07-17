using System;
using System.IO;
using System.Net;

namespace ApiMockServer.Server
{
    public static class Logger
    {
        private static readonly string LogFile = "MockServerLog.txt";

        public static void LogRequest(HttpListenerRequest request)
        {
            var line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {request.HttpMethod} {request.Url.AbsolutePath}";
            File.AppendAllText(LogFile, line + Environment.NewLine);
        }
    }
}
