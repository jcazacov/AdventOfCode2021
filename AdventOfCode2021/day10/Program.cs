using System;
using System.Collections.Generic;
using System.IO;

namespace day10
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] allLines = File.ReadAllLines("Input.txt");
            int errorScore = 0;
            List<double> incompleteScore = new List<double>();
            foreach (var line in allLines)
            {
                List<char> stack = new List<char>();
                int stackPointer = -1;

                bool corruptedLine = false;
                
                foreach (var symbol in line)
                {
                    
                    if (symbol== '(' || symbol == '[' || symbol == '{' || symbol == '<')
                    {
                        stack.Add(symbol);
                        stackPointer++;
                    }
                    else
                    {
                        if (stack[stackPointer] == '(' && symbol == ')' ||
                            stack[stackPointer] == '[' && symbol == ']' ||
                            stack[stackPointer] == '{' && symbol == '}' ||
                            stack[stackPointer] == '<' && symbol == '>')
                        {
                            stack.RemoveAt(stackPointer);
                            stackPointer--;
                        }
                        else
                        {
                            switch (symbol)
                            {
                                case ')': errorScore += 3; break;
                                case ']': errorScore += 57; break;
                                case '}': errorScore += 1197; break;
                                case '>': errorScore += 25137; break;
                            }

                            corruptedLine = true;
                        }
                    }

                    if (corruptedLine)
                    {
                        break;
                    }
                }
                
                if (corruptedLine)
                {
                    continue;
                }

                double thisIncompleteScore = 0;
                while (stackPointer >= 0)
                {
                    int addendum = 0;
                    switch (stack[stackPointer])
                    {
                        case '(': addendum = 1; break;
                        case '[': addendum = 2; break;
                        case '{': addendum = 3; break;
                        case '<': addendum = 4; break;
                    }

                    thisIncompleteScore = thisIncompleteScore * 5 + addendum;
                    stackPointer--;
                }
                incompleteScore.Add(thisIncompleteScore);
            }
            Console.WriteLine(errorScore);
            incompleteScore.Sort();
            Console.WriteLine(incompleteScore[(incompleteScore.Count-1)/2]);
        }
    }
}