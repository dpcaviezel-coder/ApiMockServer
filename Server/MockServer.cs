using System.Text.Json;
using ApiMockServer.Server;

namespace ApiMockServer.Server
{
    public class MockServer
    {
        private ServerConfig _config = new();
        private RouteHandler _routes = new();

        public void Start()
        {
            LoadConfig();
            LoadRoutes();

            Console.WriteLine($"Mock API Server running on port {_config.Port}");
            Console.WriteLine("Press Ctrl+C to stop.");

            using var listener = new HttpListener();
            listener.Prefixes.Add($"http://localhost:{_config.Port}/");
            listener.Start();

            while (true)
            {
                var context = listener.GetContext();
                HandleRequest(context);
            }
        }

        private void LoadConfig()
        {
            var json = File.ReadAllText("Config/server.json");
            _config = JsonSerializer.Deserialize<ServerConfig>(json)!;
        }

        private void LoadRoutes()
        {
            var json = File.ReadAllText("Config/routes.json");
            _routes.Load(json);
        }

        private void HandleRequest(HttpListenerContext context)
        {
            var path = context.Request.Url!.AbsolutePath;
            var method = context.Request.HttpMethod;

            Logger.Log($"{method} {path}");

            var endpoint = _routes.Resolve(path, method);

            if (endpoint == null)
            {
                ErrorSimulator.SendNotFound(context);
                return;
            }

            DelaySimulator.Apply(_config.Delay);

            var response = endpoint.Handle(context);
            ResponseBuilder.SendJson(context, response);
        }
    }
}
