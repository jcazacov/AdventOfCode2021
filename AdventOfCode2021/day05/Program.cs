using System;
using System.IO;
using System.Text.RegularExpressions;

namespace day05
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[][] seaBottom = new int[1000][];
            for (int row = 0; row < 1000; row++)
            {
                seaBottom[row] = new int[1000];
            }
            string[] allLines = File.ReadAllLines("Input.txt");
            
            foreach (var line in allLines)
            {
                string pattern = @"(\d*),(\d*) -> (\d*),(\d*)";
                var match = Regex.Match(line, pattern);
                int x1 = Int32.Parse("" + match.Groups[1].Value);
                int y1 = Int32.Parse("" + match.Groups[2].Value);
                int x2 = Int32.Parse("" + match.Groups[3].Value);
                int y2 = Int32.Parse("" + match.Groups[4].Value);
                
                seaBottom[x1][y1]++;
                while (!(x1 == x2 && y1 == y2))
                {
                    if (x1 < x2 && y1 == y2)
                    {
                        x1++;
                    }
                        
                    else if (x1 > x2 && y1 == y2)
                    {
                        x1--;
                    }
                       
                    else if (x1 == x2 && y1 < y2)
                    {
                        y1++;
                    }
                       
                    else if (x1 == x2 && y1 > y2)
                    {
                        y1--;
                    }
                       
                    else if (x1 > x2 && y1 > y2){
                        x1--;
                        y1--;
                    }
                       
                    else if (x1 > x2 && y1 < y2)
                    {
                        x1--;
                        y1++;
                    }
                        
                    else if (x1 < x2 && y1 > y2)
                    {
                        x1++;
                        y1--;
                    }
                        
                    else if (x1 < x2 && y1 < y2)
                    {
                        x1++;
                        y1++;
                    }
                       
                    seaBottom[x1][y1]++;
                } 

            }

            int sumOfSeveral = 0;
            foreach (var row in seaBottom)
            {
                foreach (var position in row)
                {
                    if (position > 1)
                        sumOfSeveral++;
                }
                
            }
            Console.WriteLine(sumOfSeveral);
        }
    }
}