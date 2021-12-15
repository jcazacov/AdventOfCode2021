using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace day13
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int maxX = 2000;
            int maxY = 2000;
            bool firstFolding = true;
            
            string[] allLines = File.ReadAllLines("Input.txt");

            string[][] field = new String[maxY][];
            for (int i = 0; i < maxY; i++)
            {
                field[i] = new String[maxX];
                for (int j = 0; j < maxX; j++)
                {
                    field[i][j] = ".";
                }
            }
            
            string dotPattern = @"(\d+),(\d+)";
            string foldPattern = @"fold along (\w)=(\d+)";
            List<string[]> instructions = new List<string[]>();

            foreach (var line in allLines)
            {
                
                if (Regex.IsMatch(line, dotPattern))
                {
                    var dotMatch = Regex.Match(line, dotPattern);
                    
                    var dotX = int.Parse(dotMatch.Groups[1].Value);
                    var dotY = int.Parse(dotMatch.Groups[2].Value);

                    field[dotY][dotX] = "#";
                }
                
                else if (Regex.IsMatch(line, foldPattern))
                {
                    var foldMatch = Regex.Match(line, foldPattern);
                    
                    var foldDirection = foldMatch.Groups[1].Value;
                    var foldLine = foldMatch.Groups[2].Value;
                    
                    instructions.Add(new string[]{foldDirection, foldLine});
                }
            }
            
            //printPaper(maxY, maxX, field);
            
            foreach (var instruction in instructions)
            {
                string foldDirection = instruction[0];
                int foldLine = int.Parse(instruction[1]);

                

                if (foldDirection.Equals("x"))
                {
                    maxX = foldLine;
                }
                else if (foldDirection.Equals("y"))
                {
                    maxY = foldLine;
                }
                
                string[][] newField = new String[maxY][];
                for (int i = 0; i < maxY; i++)
                {
                    newField[i] = new String[maxX];
                    for (int j = 0; j < maxX; j++)
                    {
                        newField[i][j] = field[i][j];
                    }

                    
                }

                for (int i = 0; i < maxY; i++)
                {
                    for (int j = 0; j < maxX; j++)
                    {
                        if (foldDirection.Equals("x"))
                        {
                            if (field[i][foldLine + (foldLine - j)].Equals("#"))
                            {
                                newField[i][j] = "#";
                            }
                        }
                        else if (foldDirection.Equals("y"))
                        {
                            if (field[foldLine + (foldLine - i)][j].Equals("#"))
                            {
                                newField[i][j] = "#";
                            }
                        }
                    }
                }

                field = newField;

                if (firstFolding)
                {
                    amountOfDots(maxY, maxX, field);
                }
                
                firstFolding = false;

                //printPaper(maxY, maxX, field);
            }
            printPaper(maxY, maxX, field);
        }

        private static void printPaper(int maxY, int maxX, string[][] field)
        {
            for (int i = 0; i < maxY; i++)
            {
                for (int j = 0; j < maxX; j++)
                {
                    Console.Write(field[i][j]);
                }
                Console.Write("\n");
            }
        }

        private static void amountOfDots(int maxY, int maxX, string[][] field)
        {
            int amountOfDots = 0;
            for (int i = 0; i < maxY; i++)
            {
                for (int j = 0; j < maxX; j++)
                {
                    if (field[i][j].Equals("#"))
                    {
                        amountOfDots++;
                    }
                    
                }
                
            }
            Console.WriteLine(amountOfDots);
        }
    }
}