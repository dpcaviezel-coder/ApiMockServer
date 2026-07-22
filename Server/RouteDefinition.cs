namespace ApiMockServer.Server
{
    public class RouteDefinition
    {
        public string Path { get; set; } = "/";
        public string Method { get; set; } = "GET";
        public string Type { get; set; } = "custom";
        public string ResponseFile { get; set; } = "";
    }
}
