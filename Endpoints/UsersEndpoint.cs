using System.Net;
using System.Text.Json;

namespace ApiMockServer.Endpoints
{
    public class UsersEndpoint : IEndpoint
    {
        public object Handle(HttpListenerContext ctx)
        {
            var json = File.ReadAllText("Responses/users.json");
            return JsonSerializer.Deserialize<object>(json)!;
        }
    }
}
