using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using day12.Properties;

namespace day12
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] allLines = File.ReadAllLines("Input2.txt");
            string pattern = @"(\w+)-(\w+)";
            Dictionary<string, Cave> allCaves = new Dictionary<string, Cave>();

            foreach (var line in allLines)
            {
                var match = Regex.Match(line, pattern);
                
                string cave1 = match.Groups[1].Value;
                string cave2 = match.Groups[2].Value;

                if (!allCaves.ContainsKey(cave1))
                {
                    allCaves.Add(cave1, new Cave(cave1));
                }
                if (!allCaves.ContainsKey(cave2))
                {
                    allCaves.Add(cave2, new Cave(cave2));
                }
                
                allCaves[cave1].addNeighbour(allCaves[cave2]);
                allCaves[cave2].addNeighbour(allCaves[cave1]);
            }

            printCaves(allCaves);

            //solution for part 2
            //If both parameters of this findAllPaths-function are set to true, it will print the solution for part 1
            Console.WriteLine("There are " + allCaves["start"].findAllPaths(false, false) + " distinct paths.");
            
        }

        public static void printCaves(Dictionary<string, Cave> allCaves)
        {
            foreach (var cave in allCaves)
            {
                Console.WriteLine(cave.Value.ToString());
            }
        }
    }
}