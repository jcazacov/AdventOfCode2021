using System;
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
            for (int row = 0; row <heights.Length; row++)
            {
                for (int column = 0; column < heights[0].Length; column++)
                {
                    riskSum += riskLevel(row, column, heights);
                }
            }
            Console.WriteLine(riskSum);
        }
        
        public static int riskLevel(int row, int column, int[][] heights){
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
                        return 0;
                    }
                }
            }

            return heights[row][column] + 1;
        }
        
    }
}