using System;
using System.Reflection;
using System.Text;

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

        public static void WriteCopyright()
        {
            var assembly = Assembly.GetEntryAssembly();
            string name = assembly.GetName().Name;
            string version = assembly.GetName().Version.ToString();

            int rowLength = name.Length + version.Length + 6 + 2;
            string spacerRow = GenerateRepeatable('*', rowLength);
            string spaces = GenerateRepeatable(' ', rowLength - 4);
            Console.WriteLine(spacerRow);
            Console.WriteLine(spacerRow);
            Console.WriteLine($"**{spaces}**");
            Console.WriteLine($"** {name} v{version} **");
            Console.WriteLine($"**{spaces}**");
            Console.WriteLine(spacerRow);
            Console.WriteLine(spacerRow);
        }

        static string GenerateRepeatable(char ch, int length)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < length; i++)
                sb.Append(ch);
            return sb.ToString();
        }
    }
}