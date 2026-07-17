using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;

namespace ApiMockServer.Server
{
    public class RouteDefinition
    {
        public string Method { get; set; }
        public string Path { get; set; }
        public string Endpoint { get; set; }
    }

    public static class RouteHandler
    {
        private static RouteDefinition[] _routes;

        public static RouteDefinition MatchRoute(HttpListenerRequest request, ServerConfig config)
        {
            if (_routes == null)
            {
                var json = File.ReadAllText(config.RoutesFile);
                _routes = JsonSerializer.Deserialize<RouteDefinition[]>(json);
            }

            var path = request.Url.AbsolutePath.TrimEnd('/');
            var method = request.HttpMethod.ToUpperInvariant();

            var match = _routes.FirstOrDefault(r =>
                r.Method.Equals(method, StringComparison.OrdinalIgnoreCase) &&
                r.Path.Equals(path, StringComparison.OrdinalIgnoreCase));

            return match ?? new RouteDefinition
            {
                Method = method,
                Path = path,
                Endpoint = "NotFound"
            };
        }
    }
}
