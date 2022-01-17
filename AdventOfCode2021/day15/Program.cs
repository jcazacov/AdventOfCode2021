using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace day15
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] allLines = File.ReadAllLines("Input.txt");
            int maxY = allLines.Length;
            int maxX = allLines[0].Length;
            int[][] riskGrid = new int[maxY][];
            for (int i = 0; i < riskGrid.Length; i++)
            {
                riskGrid[i] = new int[maxX];
                for (int j = 0; j < riskGrid[0].Length; j++)
                {
                    riskGrid[i][j] = int.Parse(allLines[i][j].ToString());
                }
            }
            
            int[][] fullMap = new int[maxY*5][];
            for (int i = 0; i < maxY*5; i++)
            {
                fullMap[i] = new int[maxX*5];
                for (int j = 0; j < maxX*5; j++)
                {
                    int newRisc = riskGrid[i % maxY][j % maxX];
                    newRisc += (i/maxY);
                    newRisc += (j/maxX);
                    while (newRisc > 9)
                    {
                        newRisc -= 9;
                    }
                    
                    fullMap[i][j] = newRisc;
                }
            }
            
            //printMap(fullMap);

            Console.WriteLine(riskOfPath(fullMap, 0, 0, maxY*5-1, maxX*5-1, maxY*5, maxX*5));
        }

        private static int riskOfPath(int[][] riskGrid, int startY, int startX, int endY, int endX, int maxY, int maxX)
        {
            int[][][] pathGrid = new int[maxY][][];
            for (int i = 0; i <maxY; i++)
            {
                pathGrid[i] = new int[maxX][];
                for (int j = 0; j < maxX; j++)
                {
                    pathGrid[i][j] = new[]{Int32.MaxValue, 0}
                    ;
                }
            }

            pathGrid[0][0][0] = 0;

            int unvisitedLeft = maxX * maxY;

            pathGrid[startY][startX][0] = 0;

            while (unvisitedLeft > 0)
            {
                Console.WriteLine(unvisitedLeft);
                int[] unvisitedPoint = findUnvisited(pathGrid, maxY, maxX);
                int y = unvisitedPoint[0];
                int x = unvisitedPoint[1];

                pathGrid[y][x][1] = 1;
                unvisitedLeft--;
                
                int[][] neighbours = findNeighbors(pathGrid, y, x, maxY, maxX);

                foreach (var neighbour in neighbours)
                {
                    int neighY = neighbour[0];
                    int neighX = neighbour[1];

                    if (pathGrid[neighY][neighX][0] > (pathGrid[y][x][0] + riskGrid[neighY][neighX]))
                    {
                        pathGrid[neighY][neighX][0] = pathGrid[y][x][0] + riskGrid[neighY][neighX];
                    }
                }
            }

            return pathGrid[endY][endX][0];
        }

        private static void printMap(int[][] map)
        {
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[0].Length; j++)
                {
                    Console.Write(map[i][j]);
                } 
                Console.WriteLine();
            }
        }
        
        private static int[] findUnvisited(int[][][] pathGrid, int maxY, int maxX)
        {

            int resX = 0;
            int resY = 0;
            int minPath = Int32.MaxValue;

            for (int i = 0; i <maxY; i++)
            {
                for (int j = 0; j <maxX; j++)
                {
                    if (pathGrid[i][j][0] < minPath && pathGrid[i][j][1] == 0)
                    {
                        resX = j;
                        resY = i;
                        minPath = pathGrid[i][j][0];
                    }
                }
            }

            return new int[] {resY, resX};
        }

        private static int[][] findNeighbors(int[][][] pathGrid, int y, int x, int maxY, int maxX)
        {
            List<int[]> neighbours = new List<int[]>();
            if (y > 0 && pathGrid[y-1][x][1] == 0)
                neighbours.Add(new int[] {y - 1, x});
            
            if (x > 0 && pathGrid[y][x-1][1] == 0)
                neighbours.Add(new int[] {y, x - 1});
            
            if (y < maxY - 1 && pathGrid[y+1][x][1] == 0)
                neighbours.Add(new int[] {y + 1, x});

            if (x < maxX - 1 && pathGrid[y][x+1][1] == 0)
                neighbours.Add(new int[] {y, x + 1});
            

            return neighbours.ToArray();

        }

        private static bool validMove(int[][][] riskGrid,int y, int x, int maxY, int maxX)
        {
            return (y >= 0 && x >= 0 && y < maxY && x < maxX && riskGrid[y][x][1] == 0);
        }

        private static int[][][] copyGrid(int[][][] original)
        {
            int maxY = original.Length;
            int maxX = original[0].Length;
            int[][][] newGrid = new int[maxY][][];
            for (int i = 0; i < newGrid.Length; i++)
            {
                newGrid[i] = new int[maxX][];
                for (int j = 0; j < newGrid[0].Length; j++)
                {
                    newGrid[i][j] = new int[]
                        {original[i][j][0], original[i][j][1]};
                }
            }

            return newGrid;
        }
    }
}