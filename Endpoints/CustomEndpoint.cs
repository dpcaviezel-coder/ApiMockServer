using System.IO;
using System.Net;
using System.Text.Json;

namespace ApiMockServer.Endpoints
{
    public static class CustomEndpoint
    {
        public static string Handle(HttpListenerRequest request)
        {
            // Read request body (if any)
            string body = "";
            if (request.HasEntityBody)
            {
                using var reader = new StreamReader(request.InputStream);
                body = reader.ReadToEnd();
            }

            // Example: respond with whatever the user sent
            var response = new
            {
                message = "Custom endpoint reached",
                method = request.HttpMethod,
                path = request.Url.AbsolutePath,
                receivedBody = body
            };

            return JsonSerializer.Serialize(response);
        }
    }
}
