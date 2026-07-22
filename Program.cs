using ApiMockServer.Server;

namespace ApiMockServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var server = new MockServer();
            server.Start();
        }
    }
}
