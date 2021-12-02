using System;
using System.IO;
using System.Text.RegularExpressions;

namespace day02
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            string pattern = @"(\w+) (\d+)";

            int depth = 0;
            int position = 0;
            int aim = 0;

            string[] allLines = File.ReadAllLines("Input.txt");
            foreach (var line in allLines)
            {
                var match = Regex.Match(line, pattern);
                switch (match.Groups[1].Value)
                {
                    case "forward": position += Int32.Parse(match.Groups[2].Value);
                        depth = depth + (aim * Int32.Parse(match.Groups[2].Value));
                        break;
                    case "up": aim -= Int32.Parse(match.Groups[2].Value);
                        break;
                    case "down": aim += Int32.Parse(match.Groups[2].Value);
                        break;
                }
            }

            int result = depth * position;
            Console.WriteLine(result);
        }
    }
}