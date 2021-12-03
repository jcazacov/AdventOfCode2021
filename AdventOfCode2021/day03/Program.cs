using System;
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
        }
    }
}