using System.Text.Json;
using ApiMockServer.Endpoints;
using ApiMockServer.Server;


namespace ApiMockServer.Server
{
    public class RouteHandler
    {
        private readonly Dictionary<string, IEndpoint> _routes = new();

        public void Load(string json)
        {
            var routeDefs = JsonSerializer.Deserialize<List<RouteDefinition>>(json)!;

            foreach (var route in routeDefs)
            {
                _routes[route.Path] = route.Method switch
                {
                    "GET" => CreateEndpoint(route),
                    "POST" => CreateEndpoint(route),
                    _ => new CustomEndpoint(route)
                };
            }
        }

        private IEndpoint CreateEndpoint(RouteDefinition def)
        {
            return def.Type switch
            {
                "users" => new UsersEndpoint(),
                "products" => new ProductsEndpoint(),
                "auth" => new AuthEndpoint(),
                _ => new CustomEndpoint(def)
            };
        }

        public IEndpoint? Resolve(string path, string method)
        {
            return _routes.TryGetValue(path, out var ep) ? ep : null;
        }
    }
}
