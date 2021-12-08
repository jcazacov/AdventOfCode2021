using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day06
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            
            string[] inputLine = File.ReadAllLines("Input.txt");
            string[] startingFish = inputLine[0].Split(',');

            List<int> allFish = new List<int>();
            foreach (var fish in startingFish)
            {
                allFish.Add(Int32.Parse(fish));
            }
            
            Dictionary<int, long> descendants = new Dictionary<int, long>();
            for (int finalAge = 0; finalAge <= 256; finalAge++)
            {
                descendants[finalAge] = 1;
                if (finalAge >= 9)
                {
                    for (int currentAge = finalAge - 9; currentAge >= 0; currentAge -= 7)
                    {
                        descendants[finalAge] += descendants[currentAge];
                    }

                    //descendants[finalAge]++;
                }
            }

            var result1 = countFishes(allFish,80, descendants);
            Console.WriteLine(result1);
            var result2 = countFishes(allFish,256, descendants);
            Console.WriteLine(result2);
        }

        private static long countFishes(List<int> fishes, int days, Dictionary<int, long> descendants)
        {
            long result = 0;
            foreach (var fish in fishes)
            {
                var age = days - fish - 1;
                result += 1;

                while (age >= 0)
                {
                    result += descendants[age];
                    age -= 7;
                }
                //result += descendants[88 - fish];
            }

            return result;
        }
    }
}