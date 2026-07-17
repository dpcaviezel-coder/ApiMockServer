using System;
using System.Net;

namespace ApiMockServer.Server
{
    public static class ErrorSimulator
    {
        private static readonly Random _random = new Random();

        public static bool TryInjectError(HttpListenerResponse response, ServerConfig config)
        {
            if (!config.EnableRandomErrors)
                return false;

            var roll = _random.Next(0, 10);
            if (roll < 3) // 30% chance
            {
                int[] codes = { 400, 401, 403, 404, 500 };
                int code = codes[_random.Next(codes.Length)];
                response.StatusCode = code;

                using var writer = new System.IO.StreamWriter(response.OutputStream);
                writer.Write($"{{\"error\":\"Injected error\",\"status\":{code}}}");
                writer.Flush();
                return true;
            }

            return false;
        }
    }
}
