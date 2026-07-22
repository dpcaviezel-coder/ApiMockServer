using System.Net;

namespace ApiMockServer.Endpoints
{
    public interface IEndpoint
    {
        object Handle(HttpListenerContext context);
    }
}
