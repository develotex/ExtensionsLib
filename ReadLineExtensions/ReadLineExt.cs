using System;

namespace ReadLineExtensions
{
    public static class ReadLineExt
    {
        public static int? TryReadAsInt(string prompt = "", string @default = "")
        {
            var input = ReadLine.Read(prompt, @default);
            return int.TryParse(input, out var result) ? result : (int?)null;
        }

        public static bool ReadAsBool(string prompt = "(y/N)> ", string @default = "N")
        {
            var input = ReadLine.Read(prompt, @default);
            return input.Length > 0 && input.Trim().Substring(0, 1).ToLowerInvariant() == "y";
        }
    }
}
