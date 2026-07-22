namespace ApiMockServer.Server
{
    public static class DelaySimulator
    {
        public static void Apply(int ms)
        {
            if (ms > 0)
                Thread.Sleep(ms);
        }
    }
}
