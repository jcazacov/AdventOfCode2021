using System;
using System.IO;
using System.Text.RegularExpressions;

namespace day04
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] allLines = File.ReadAllLines("Input.txt");
            int boardsAmount = (allLines.Length - 1) / 6;
            Board[] boards = new Board[boardsAmount];

            for (int boardNumber = 0; boardNumber < boardsAmount; boardNumber++)
            {
                int[] numbers = new int[25];
                for (int row = 0; row < 5; row++)
                {
                    string pattern = @"\s*(\d*)\s*(\d*)\s*(\d*)\s*(\d*)\s*(\d*)";
                    var match = Regex.Match(allLines[boardNumber * 6 + row + 2], pattern);
                    numbers[row * 5 + 0] = Int32.Parse("" + match.Groups[1].Value);
                    numbers[row * 5 + 1] = Int32.Parse("" + match.Groups[2].Value);
                    numbers[row * 5 + 2] = Int32.Parse("" + match.Groups[3].Value);
                    numbers[row * 5 + 3] = Int32.Parse("" + match.Groups[4].Value);
                    numbers[row * 5 + 4] = Int32.Parse("" + match.Groups[5].Value);
                }

                boards[boardNumber] = new Board(numbers);
            }

            string[] markers = allLines[0].Split(',');
            int notWinners = boardsAmount;

            foreach (var marker in markers)
            {
                for (int boardNumber = 0; boardNumber < boardsAmount; boardNumber++)
                {
                    if (boards[boardNumber].getWon())
                    {
                        continue;
                    }
                    int intMarker = Int32.Parse("" + marker);
                    boards[boardNumber].markNumber(intMarker);
                    if (boards[boardNumber].isWinner())
                    {
                        notWinners--;
                        if (notWinners == 0)
                        {
                            Console.WriteLine(boards[boardNumber].calculateScore(intMarker));
                            return;
                        }
                       
                    }
                }
            }

        }
    }
}