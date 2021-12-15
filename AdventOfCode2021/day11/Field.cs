using System;
using System.IO;

namespace day11
{
    public class Field
    {
        private int xSize;
        private int ySize;
        private Octopus[][] field;

        public Field(int xSize, int ySize, string inputFile)
        {
            this.xSize = xSize;
            this.ySize = ySize;
            field = new Octopus[ySize][];
            for (int i = 0; i < field.Length; i++)
            {
                field[i] = new Octopus[xSize];
            }
            
            string[] allLines = File.ReadAllLines(inputFile);
            for (int i = 0; i < ySize; i++)
            {
                for (int j = 0; j < xSize; j++)
                {
                    int currentPowerLevel = int.Parse(allLines[i][j].ToString());
                    field[i][j] = new Octopus(i, j, currentPowerLevel);
                }
            }
        }

        public bool isInField(int y, int x)
        {
            return y >= 0 && y < ySize && x >= 0 && x < xSize;
        }

        public Octopus getOctopus(int y, int x)
        {
            return field[y][x];
        }

        public int getYSize()
        {
            return ySize;
        }
        
        public int getXSize()
        {
            return xSize;
        }

        public void writeField()
        {
            for (int i = 0; i < ySize; i++)
            {
                for (int j = 0; j < xSize; j++)
                {
                    Console.Write(getOctopus(i,j).getPower());
                }
                Console.Write("\n");
            }
        }
    }
}