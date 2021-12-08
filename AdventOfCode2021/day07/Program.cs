using System;
using System.IO;
using System.Text.RegularExpressions;

namespace day07
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] inputLine = File.ReadAllLines("Input.txt");
            string[] startPositions = inputLine[0].Split(',');

            int minFuel = Int32.MaxValue;
            for (int targetPosition = 0; targetPosition < 2000; targetPosition++)
            {
                int currentFuel = 0;
                foreach (var startPosition in startPositions)
                {
                    currentFuel += Math.Abs(targetPosition - Int32.Parse(startPosition));
                }
                if (currentFuel < minFuel)
                {
                    minFuel = currentFuel;
                }
            }
            Console.WriteLine(minFuel);
            
            double minFuel2 = Int32.MaxValue;
            for (int targetPosition = 0; targetPosition < 2000; targetPosition++)
            {
                double currentFuel = 0;
                foreach (var startPosition in startPositions)
                {
                    currentFuel += fuelConsumption(targetPosition, Int32.Parse(startPosition));
                }
                if (currentFuel < minFuel2)
                {
                    minFuel2 = currentFuel;
                }
            }
            Console.WriteLine(minFuel2);
            
        }

        public static double fuelConsumption(int startPos, int targetPos)
        {
            int distance = Math.Abs(startPos - targetPos);
            double consumedFuel = (distance + 1) * (distance / 2.0);
            return consumedFuel;
        }
    }
}