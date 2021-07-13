using System;

namespace ReverseGeo
{
    public static class Logger
    {

        public static void LogDebug(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }

    }
}
