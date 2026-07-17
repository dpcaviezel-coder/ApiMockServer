using System.IO;
using System.Net;

namespace ApiMockServer.Endpoints
{
    public static class UsersEndpoint
    {
        public static string Handle(HttpListenerRequest request)
        {
            var path = Path.Combine("Responses", "users.json");
            return File.ReadAllText(path);
        }
    }
}
