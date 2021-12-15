using System;
using System.Collections.Generic;
using System.IO;

namespace day09
{
    internal class Program
    {
        public static int[][] Read(string fileName)
        {
            string[] allLines = File.ReadAllLines(fileName);

            int[][] heights = new int[allLines.Length][];
            
            for (int row = 0; row < allLines.Length; row++)
            {
                heights[row] = new int[allLines[0].Length];
                for (int column = 0; column < allLines[0].Length; column++)
                {
                    heights[row][column] = Int32.Parse("" + allLines[row][column]);
                }
            }
            return heights;
        }

        public static void Main()
        {
            int[][] heights = Read("Input.txt");
            int riskSum = 0;
            List<int> basinSizes = new List<int>();
            for (int row = 0; row <heights.Length; row++)
            {
                for (int column = 0; column < heights[0].Length; column++)
                {
                    
                    if (isLow(row, column, heights))
                    {
                        riskSum += riskLevel(row, column, heights);
                        basinSizes.Add(findBasinSize(row, column, heights, new List<string>()));
                    }
                }
            }
            Console.WriteLine(riskSum);

            int largest1 = 0;
            int largest2 = 0;
            int largest3 = 0;
            foreach (var basinSize in basinSizes)
            {
                if (basinSize > largest3)
                {
                    if (basinSize > largest2)
                    {
                        if (basinSize > largest1)
                        {
                            largest3 = largest2;
                            largest2 = largest1;
                            largest1 = basinSize;
                        }
                        else
                        {
                            largest3 = largest2;
                            largest2 = basinSize;
                        }
                    }
                    else
                    {
                        largest3 = basinSize;
                    }
                    
                }
                
            }
            
            Console.WriteLine(largest1*largest2*largest3);
        }
        
        public static bool isLow(int row, int column, int[][] heights){
            int maxX = heights[0].Length - 1;
            int maxY = heights.Length - 1;
            
            // Von y-1 (bzw 0 wenn am linken Brettrand) bis y+1 (bzw maxY wenn am rechten Brettrand)
            for (int currentRow = (row > 0? row-1: 0); currentRow <= (row < maxY? row+1: maxY); currentRow++){
                // Von x-1 (bzw 0 wenn am oberen Brettrand) bis x+1 (bzw maxX wenn am unteren Brettrand)
                for (int currentColumn = (column > 0? column-1: 0); currentColumn <= (column < maxX? column+1: maxX); currentColumn++){
                    // Falls momentanes Feln nicht tiefer als zu prüfendes Feld liegt und letzteres senkrecht oder
                    // waagrecht angrenzt.
                    if (heights[row][column] >= heights[currentRow][currentColumn] && (row == currentRow || column == currentColumn) && !(column == currentColumn && row == currentRow))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static int riskLevel(int row, int column, int[][] heights)
        {
            if (isLow(row, column, heights))
            {
                return heights[row][column] + 1;
            }

            return 0;
        }

        public static int findBasinSize(int y, int x, int[][] heights, List<string> partOfBasin)
        {
            int maxX = heights[0].Length - 1;
            int maxY = heights.Length - 1;
            if (x < 0 || x > maxX || y < 0 || y > maxY || heights[y][x] == 9 || partOfBasin.Contains("y"+(y)+"x"+(x)))
            {
                return 0;
            }
            else
            {
                partOfBasin.Add("y"+(y)+"x"+(x));
                return 1 + findBasinSize(y-1, x, heights, partOfBasin) +
                       findBasinSize(y+1, x, heights, partOfBasin) +
                       findBasinSize(y, x-1, heights, partOfBasin) +
                       findBasinSize(y, x+1, heights, partOfBasin);
            }
            
        }
    }
}