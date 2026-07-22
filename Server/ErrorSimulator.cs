using System.Text;
using System.Net;


namespace ApiMockServer.Server
{
    public static class ErrorSimulator
    {
        public static void SendNotFound(HttpListenerContext ctx)
        {
            var msg = Encoding.UTF8.GetBytes("{\"error\":\"Not Found\"}");
            ctx.Response.StatusCode = 404;
            ctx.Response.OutputStream.Write(msg);
            ctx.Response.OutputStream.Close();
        }
    }
}
