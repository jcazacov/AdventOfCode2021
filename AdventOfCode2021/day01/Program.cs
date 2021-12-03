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
            
           
            int biggerNumbers = 0;

            for (int i = 3; i < allLines.Length; i++)
            {
                if (Int32.Parse(allLines[i]) > Int32.Parse(allLines[i-3]))
                {
                    biggerNumbers++;
                }
                
            }
            Console.WriteLine(biggerNumbers);
        }
    }
}