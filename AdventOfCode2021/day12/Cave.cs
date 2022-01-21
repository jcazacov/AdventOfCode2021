using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace day12.Properties
{
    public class Cave
    {
        private readonly List<Cave> neighbours;
        private readonly string name;
        private readonly bool smallCave;
        private int visits;
        private bool twice;

        public Cave(string name)
        {
            neighbours = new List<Cave>();
            this.name = name;
            visits = 0;
            twice = false;
            
            smallCave = Char.ToLower(name[0]) == name[0];
            
        }
        
        public int findAllPaths(bool twiceChosen, bool twiceUsed)
        {
            if (name == "end" && !(twiceChosen && !twiceUsed))
            {
                return 1;
            }
            else if (name == "end")
            {
                return 0;
            }

            if (smallCave && (twice && visits > 1 || !twice && visits > 0))
                return 0;

            visits++;
            
            int allPaths = 0;
            
            
            if (!twiceChosen && name != "start" && smallCave)
            {
                twice = true;
                foreach (var neighbour in neighbours)
                {
                    if (neighbour.getName() != "start")
                    {
                        allPaths += neighbour.findAllPaths(true, twiceUsed);
                    }
                }
                twice = false;
            }

            if (!twiceUsed && twice)
            {
                twiceUsed = true;
                foreach (var neighbour in neighbours)
                {
                    if (neighbour.getName() != "start")
                    {
                        allPaths += neighbour.findAllPaths(twiceChosen, twiceUsed);
                    }
                }
                twiceUsed = false;
            }
            else
            {
                foreach (var neighbour in neighbours)
                {
                    if (neighbour.getName() != "start")
                    {
                        allPaths += neighbour.findAllPaths(twiceChosen, twiceUsed);
                    }
                }
            }
            
            visits--;
            
            return allPaths;
        }

        public void addNeighbour(Cave neighbour)
        {
            if (!neighbours.Contains(neighbour))
            {
                neighbours.Add(neighbour);
            }
        }

        public List<Cave> getNeighbours()
        {
            return neighbours;
        }

        public bool isBigCave()
        {
            return smallCave;
        }

        public string getName()
        {
            return name;
        }

        public override string ToString()
        {
            string result = name + " (";
            for (int i = 0; i < neighbours.Count; i++)
            {
                result += neighbours[i].getName();
                if (i < neighbours.Count - 1)
                    result += ",";
            }

            result += ")";
            return result;
        }
    }
}