using System;
using System.IO;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace day01
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] allLines = File.ReadAllLines("Input.txt");
            
            int previousSum = Int32.MaxValue;
            int biggerNumbers = 0;

            for (int i = 2; i < allLines.Length; i++)
            {
                int currentSum = Int32.Parse(allLines[i]) + Int32.Parse(allLines[i - 1]) + Int32.Parse(allLines[i - 2]);
                if (currentSum > previousSum)
                {
                    biggerNumbers++;
                }

                previousSum = currentSum;
            }
            Console.WriteLine(biggerNumbers);
        }
    }
}