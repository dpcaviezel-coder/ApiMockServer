using System.Text;
using System.Text.Json;

namespace ApiMockServer.Server
{
    public static class ResponseBuilder
    {
        public static void SendJson(HttpListenerContext ctx, object data)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            var buffer = Encoding.UTF8.GetBytes(json);

            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength64 = buffer.Length;

            ctx.Response.OutputStream.Write(buffer);
            ctx.Response.OutputStream.Close();
        }
    }
}
