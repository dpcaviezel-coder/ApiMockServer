using System.Net;
using System.Text.Json;

namespace ApiMockServer.Endpoints
{
    public class ProductsEndpoint : IEndpoint
    {
        public object Handle(HttpListenerContext ctx)
        {
            var json = File.ReadAllText("Responses/products.json");
            return JsonSerializer.Deserialize<object>(json)!;
        }
    }
}
