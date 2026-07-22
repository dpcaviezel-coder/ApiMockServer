namespace ApiMockServer.Examples
{
    public static class AddingCustomRoutes
    {
        public static void Run()
        {
            Console.WriteLine("To add a custom route:");
            Console.WriteLine("1. Edit Config/routes.json");
            Console.WriteLine("2. Add a new entry with path, method, type, responseFile");
            Console.WriteLine("3. Create the matching JSON file in Responses/");
            Console.WriteLine("4. Restart the server.");
        }
    }
}
