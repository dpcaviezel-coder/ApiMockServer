using System.Net;
using System.Text.Json;

namespace ApiMockServer.Endpoints
{
    public class AuthEndpoint : IEndpoint
    {
        public object Handle(HttpListenerContext ctx)
        {
            using var reader = new StreamReader(ctx.Request.InputStream);
            var body = reader.ReadToEnd();

            var payload = JsonSerializer.Deserialize<Dictionary<string, string>>(body);
            var username = payload?["username"];
            var password = payload?["password"];

            if (username == "testuser" && password == "password123")
            {
                var json = File.ReadAllText("Responses/auth_success.json");
                return JsonSerializer.Deserialize<object>(json)!;
            }
            else
            {
                var json = File.ReadAllText("Responses/auth_fail.json");
                return JsonSerializer.Deserialize<object>(json)!;
            }
        }
    }
}
