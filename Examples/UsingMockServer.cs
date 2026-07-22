namespace ApiMockServer.Examples
{
    public static class UsingMockServer
    {
        public static void Run()
        {
            Console.WriteLine("Start the server with: dotnet run");
            Console.WriteLine("Then call endpoints like:");
            Console.WriteLine("  GET  http://localhost:5000/users");
            Console.WriteLine("  GET  http://localhost:5000/products");
            Console.WriteLine("  POST http://localhost:5000/auth");
        }
    }
}
