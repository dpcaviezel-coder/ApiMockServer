using System;
using System.IO;
using System.Net;
using System.Text.Json;
using ApiMockServer.Server;

namespace ApiMockServer.Server
{
    public static class MockServer
    {
        public static void Run()
        {
            Console.WriteLine("API Mock Server");

            var configPath = Path.Combine("Config", "server.json");
            var configJson = File.ReadAllText(configPath);
            var config = JsonSerializer.Deserialize<ServerConfig>(configJson);

            var listener = new HttpListener();
            listener.Prefixes.Add($"http://localhost:{config.Port}/");
            listener.Start();

            Console.WriteLine($"Server running on http://localhost:{config.Port}/");
            Console.WriteLine("Press Ctrl+C to stop.");

            while (true)
            {
                var context = listener.GetContext();
                HandleRequest(context, config);
            }
        }

        private static void HandleRequest(HttpListenerContext context, ServerConfig config)
        {
            var request = context.Request;
            var response = context.Response;

            Logger.LogRequest(request);

            DelaySimulator.ApplyDelay(config.DelayMs);
            if (ErrorSimulator.TryInjectError(response, config))
                return;

            var route = RouteHandler.MatchRoute(request, config);
            var body = ResponseBuilder.BuildResponse(route, request);

            response.ContentType = "application/json";
            using var writer = new StreamWriter(response.OutputStream);
            writer.Write(body);
            writer.Flush();
        }
    }

    public class ServerConfig
    {
        public int Port { get; set; } = 5000;
        public int DelayMs { get; set; } = 0;
        public bool EnableRandomErrors { get; set; } = false;
        public string RoutesFile { get; set; } = "Config/routes.json";
    }
}
