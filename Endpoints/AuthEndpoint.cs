using System.IO;
using System.Net;
using System.Text.Json;

namespace ApiMockServer.Endpoints
{
    public static class AuthEndpoint
    {
        public static string Handle(HttpListenerRequest request)
        {
            using var reader = new StreamReader(request.InputStream);
            var body = reader.ReadToEnd();

            if (body.Contains("\"password\":\"secret\""))
            {
                var path = Path.Combine("Responses", "auth_success.json");
                return File.ReadAllText(path);
            }
            else
            {
                var path = Path.Combine("Responses", "auth_fail.json");
                return File.ReadAllText(path);
            }
        }
    }
}
