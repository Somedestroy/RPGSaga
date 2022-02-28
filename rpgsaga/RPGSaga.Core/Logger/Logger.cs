namespace RpgSaga.Logger
{
    using System;

    public static class Logger
    {
        public static void Info(string data)
        {
            Console.WriteLine(data);
        }

        public static void Error(string data)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(data);
            Console.ResetColor();
        }
    }
}
