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

            for (int days = 0; days < 256; days++)
            {
                Console.WriteLine(days);
                int currentFishCount = allFish.Count;
                for (int currentFish = 0; currentFish < currentFishCount; currentFish++)
                {
                    if (allFish[currentFish] == 0)
                    {
                        allFish[currentFish] = 6;
                        allFish.Add(8);
                    }
                    else
                    {
                        allFish[currentFish]--;
                    }
                    
                }
            }
            
            Console.WriteLine(allFish.Count);
        }
    }
}