using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace day08
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] allLines = File.ReadAllLines("Input.txt");

            int[] numberFrequency = new int[10];
            
            int result = 0;
            
            foreach (var line in allLines)
            {
                string[] parts = line.Split('|');
                string digitsPattern = @"(\w+) (\w+) (\w+) (\w+) (\w+) (\w+) (\w+) (\w+) (\w+) (\w+) ";
                string numberPattern = @" (\w+) (\w+) (\w+) (\w+)";
                var digitsMatch = Regex.Match(parts[0], digitsPattern);
                var numberMatch = Regex.Match(parts[1], numberPattern);

                string[] fakeDigits = new string[10];
                for (int i = 0; i < 10; i++)
                {
                    fakeDigits[i] = digitsMatch.Groups[i + 1].Value;
                }
                
                string[] fakeNumber = new string[4];
                for (int i = 0; i < 4; i++)
                {
                    fakeNumber[i] = numberMatch.Groups[i + 1].Value;
                }

                int[] fakeCharFrequency = new int[7];
                string fakeOne = "xy";

                foreach (var fakeDigit in fakeDigits)
                {
                    if (fakeDigit.Length == 2)
                    {
                        fakeOne = fakeDigit;
                    }
                    foreach (var fakeChar in fakeDigit)
                    {
                        switch (fakeChar)
                        {
                            case 'a': fakeCharFrequency[0]++; break;
                            case 'b': fakeCharFrequency[1]++; break;
                            case 'c': fakeCharFrequency[2]++; break;
                            case 'd': fakeCharFrequency[3]++; break;
                            case 'e': fakeCharFrequency[4]++; break;
                            case 'f': fakeCharFrequency[5]++; break;
                            case 'g': fakeCharFrequency[6]++; break;
                        }
                    }
                }

                char trueA = 'x';
                char trueB = 'x';
                char trueC = 'x';
                char trueD = 'x';
                char trueE = 'x';
                char trueF = 'x';
                char trueG = 'x';
                
                HashSet<int> segmentsOf1 = new HashSet<int>(); 
                HashSet<int> segmentsOf7 = new HashSet<int>();
                

                for (int num = 0; num < 7; num++)
                {
                    if (fakeCharFrequency[num] == 6)
                        trueB = (char) ((int) 'a' + num);
                    else if (fakeCharFrequency[num] == 4)
                        trueE = (char) ((int) 'a' + num);
                    else if (fakeCharFrequency[num] == 9)
                        trueF = (char) ((int) 'a' + num);
                }


                int decPower = 1000;
                foreach (var number in fakeNumber)
                {
                    int thisDigit;
                    HashSet<char> currentSegments = new HashSet<char>();
                    for (int i = 0; i < number.Length; i++)
                    {
                        currentSegments.Add(number[i]);
                    }

                    if (number.Length == 2)
                    {
                        thisDigit = 1;
                    }
                    
                    else if (number.Length == 4)
                    {
                        thisDigit = 4;
                    }
                    
                    else if (number.Length == 3)
                    {
                        thisDigit = 7;
                    }
                    
                    else if (number.Length == 7)
                    {
                        thisDigit = 8;
                    }
                    
                    else if (number.Length == 5)
                    {
                        if (!currentSegments.Contains(trueB) && currentSegments.Contains(trueE) && !currentSegments.Contains(trueF))
                        {
                            thisDigit = 2;
                        }
                        else if (!currentSegments.Contains(trueB) && !currentSegments.Contains(trueE) && currentSegments.Contains(trueF))
                        {
                            thisDigit = 3;
                        }
                        else{
                            thisDigit = 5;
                        }
                    }
                    else
                    {
                        if (currentSegments.Contains(trueB) && !currentSegments.Contains(trueE) && currentSegments.Contains(trueF))
                        {
                            thisDigit = 9;
                        }
                        else
                        {
                            if (currentSegments.Contains(fakeOne[0]) && currentSegments.Contains(fakeOne[1]))
                            {
                                thisDigit = 0;
                            }
                            else
                            {
                                thisDigit = 6;
                            }
                        }
                    }

                    result += thisDigit * decPower;
                    numberFrequency[thisDigit]++;

                    decPower /= 10;
                }
            }

            Console.WriteLine(numberFrequency[1] +numberFrequency[4] + numberFrequency[7] + numberFrequency[8]);
            
            Console.WriteLine((result));
        }
    }
}