using System;
using System.Threading;

namespace ApiMockServer.Server
{
    public static class DelaySimulator
    {
        public static void ApplyDelay(int delayMs)
        {
            if (delayMs > 0)
                Thread.Sleep(delayMs);
        }
    }
}
