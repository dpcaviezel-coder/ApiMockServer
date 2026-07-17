using System.IO;
using System.Net;
using System.Text.Json;

namespace ApiMockServer.Endpoints
{
    public static class ProductsEndpoint
    {
        public static string Handle(HttpListenerRequest request)
        {
            using var reader = new StreamReader(request.InputStream);
            var body = reader.ReadToEnd();

            return JsonSerializer.Serialize(new
            {
                message = "Product created (mock)",
                received = body
            });
        }
    }
}
