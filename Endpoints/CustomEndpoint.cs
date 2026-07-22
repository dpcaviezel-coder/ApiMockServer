using System.Net;
using System.Text.Json;

namespace ApiMockServer.Endpoints
{
    public class CustomEndpoint : IEndpoint
    {
        private readonly string _responseFile;

        public CustomEndpoint(RouteDefinition def)
        {
            _responseFile = def.ResponseFile;
        }

        public object Handle(HttpListenerContext ctx)
        {
            var json = File.ReadAllText(Path.Combine("Responses", _responseFile));
            return JsonSerializer.Deserialize<object>(json)!;
        }
    }
}
