using System;
using System.Collections.Generic;
using System.IO;

namespace day03
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] allLines = File.ReadAllLines("Input.txt");
            int gamma = 0;
            int epsilon = 0;
            int binPower = 1;
            int lineLength = allLines[0].Length;

            for (int position = lineLength - 1; position >= 0; position--)
            {
                int ones = 0;
                int zeroes = 0;
                foreach (var line in allLines)
                {
                    if (line[position].Equals('1'))
                    {
                        ones++;
                    }
                    else
                    {
                        zeroes++;
                    }
                }

                if (ones >= zeroes)
                {
                    gamma += 1 * binPower;
                }
                else
                {
                    epsilon += 1 * binPower;
                  
                }

                binPower = binPower * 2;
            }

            int result = gamma * epsilon;
            Console.WriteLine(result);

            List<string> oxygenLines = new List<string>(allLines);
            List<string> co2Lines = new List<string>(allLines);

            int stelle = 0;
            bool oxygenFound = false;

            while (!oxygenFound)
            {
                int zeroes = 0;
                int ones = 0;
                
                foreach (string line in oxygenLines)
                {
                    if (line[stelle] == '0')
                    {
                        zeroes++;
                    }
                    else
                    {
                        ones++;
                    }
                }

                char mostCommon;

                if (ones >= zeroes)
                {
                    mostCommon = '1';
                }
                else
                {
                    mostCommon = '0';
                }
                
                for(int lineNumber = 0; lineNumber < oxygenLines.Count; lineNumber++)
                {
                    if (oxygenLines[lineNumber][stelle] != mostCommon)
                    {
                        oxygenLines.Remove(oxygenLines[lineNumber]);
                        lineNumber--;
                    }
                }

                if (oxygenLines.Count == 1)
                {
                    oxygenFound = true;
                }

                stelle++;
            }
            
            stelle = 0;
            bool co2Found = false;

            while (!co2Found)
            {
                int zeroes = 0;
                int ones = 0;
                
                foreach (string line in co2Lines)
                {
                    if (line[stelle] == '0')
                    {
                        zeroes++;
                    }
                    else
                    {
                        ones++;
                    }
                }

                char mostCommon;

                if (ones >= zeroes)
                {
                    mostCommon = '1';
                }
                else
                {
                    mostCommon = '0';
                }
                
                for(int lineNumber = 0; lineNumber < co2Lines.Count; lineNumber++)
                {
                    if (co2Lines[lineNumber][stelle] == mostCommon)
                    {
                        co2Lines.Remove(co2Lines[lineNumber]);
                        lineNumber--;
                    }
                }

                if (co2Lines.Count == 1)
                {
                    co2Found = true;
                }

                stelle++;
            }

            int oxygenRate = 0;
            int co2Rate = 0;
            binPower = 1;

            for (int pos = allLines[0].Length - 1; pos >= 0; pos--)
            {
                if (oxygenLines[0][pos].Equals('1'))
                {
                    oxygenRate += binPower * 1;
                }
                
                if (co2Lines[0][pos].Equals('1'))
                {
                    co2Rate += binPower * 1;
                }
                binPower = binPower * 2;
            }
            
            
            Console.WriteLine(oxygenRate*co2Rate);
        }
    }
}