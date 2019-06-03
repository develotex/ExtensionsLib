using System;

namespace ConsoleExtensions
{
    public static class ConsoleExt
    {
        public static void WriteLines(params string[] lines)
        {
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }

        public static void WriteLineWarn(string line)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void WriteLineError(string line)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void WriteHr()
        {
            var width = Console.WindowWidth;
            for (var i = 0; i < width; i++)
                Console.Write("-");
            Console.WriteLine();
        }

        public static void SkipScreen()
        {
            var consoleHeight = Console.WindowHeight;
            for (var i = 0; i < consoleHeight; i++)
                Console.WriteLine();
        }

        public static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}