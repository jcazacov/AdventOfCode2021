using System;
using System.IO;

namespace day11
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Field field = new Field(10, 10, "Input.txt");
            int totalDays = 100;
            int totalFlashes = 0;
            Console.WriteLine("Day: 0");
            field.writeField();

            int currentday = 0;
            int synchronized = 0;
            while (synchronized != 100)
            {
                synchronized = 0;
                for (int i = 0; i < field.getYSize(); i++)
                {
                    for (int j = 0; j < field.getXSize(); j++)
                    {
                        totalFlashes += field.getOctopus(i, j).increasePower(field);
                    }
                }
                
                for (int i = 0; i < field.getYSize(); i++)
                {
                    for (int j = 0; j < field.getXSize(); j++)
                    {
                        if (field.getOctopus(i, j).getPower() == 0)
                        {
                            synchronized++;
                        }

                        if (field != null) field.getOctopus(i, j).resetFlash();
                    }
                }

                currentday++;

            }
            Console.WriteLine(currentday);
            
            Console.WriteLine(totalFlashes);
        }
    }
}