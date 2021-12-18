using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace day14
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] allLines = File.ReadAllLines("Input.txt");
            string pattern = @"(\S)(\S) -> (\S)";
            int steps = 40;
            
            Dictionary<char, int> letterCount = new Dictionary<char, int>();

            Dictionary<string, char> rules = new Dictionary<string, char>();

            

            for (int ruleNumber = 2; ruleNumber < allLines.Length; ruleNumber++)
            {
                var match = Regex.Match(allLines[ruleNumber], pattern);

                var key = match.Groups[1].Value +  match.Groups[2].Value;
                var value = match.Groups[3].Value.ToCharArray()[0];
                
                rules.Add(key, value);

                if (!letterCount.ContainsKey(value))
                {
                    letterCount.Add(value, 0);
                }
            }
            
            List<char> currentLine = new List<char>();
            foreach (var character in allLines[0])
            {
                currentLine.Add(character);
                letterCount[character]++;
            }

            for (int step = 1; step <= steps; step++)
            {
                Console.WriteLine(step);
                List<char> newLine = new List<char>();
                newLine.Add(currentLine[0]);

                for (int pos = 1; pos < currentLine.Count; pos++)
                { string searchKey = currentLine[pos - 1].ToString() + currentLine[pos].ToString();
                   newLine.Add(rules[searchKey]);
                   newLine.Add(currentLine[pos]);
                   letterCount[rules[searchKey]]++;
                }
                currentLine = newLine;
            }
            
            int mostCommon = Int32.MinValue;
            int leastCommon = Int32.MaxValue;

            foreach (var count in letterCount)
            {
                if (count.Value >= mostCommon)
                {
                    mostCommon = count.Value;
                }
                
                if (count.Value <= leastCommon)
                {
                    leastCommon = count.Value;
                }
            }
            
            Console.WriteLine(mostCommon - leastCommon);
        }
    }
}