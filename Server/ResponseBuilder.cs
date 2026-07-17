using System;
using System.IO;
using System.Net;
using System.Text.Json;
using ApiMockServer.Endpoints;

namespace ApiMockServer.Server
{
    public static class ResponseBuilder
    {
        public static string BuildResponse(RouteDefinition route, HttpListenerRequest request)
        {
            switch (route.Endpoint)
            {
                case "Users":
                    return UsersEndpoint.Handle(request);

                case "Products":
                    return ProductsEndpoint.Handle(request);

                case "Auth":
                    return AuthEndpoint.Handle(request);

                case "NotFound":
                default:
                    return JsonSerializer.Serialize(new { error = "Route not found", path = route.Path });
            }
        }
    }
}
