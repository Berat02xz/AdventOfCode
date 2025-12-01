using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode_2025.Day_1
{
    public class AOC_Puzzle1
    {
        public static void Solution(string[] args)
        {
            var commands = File.ReadAllLines("../../../Day 1/input.txt")
                               .Where(l => !string.IsNullOrWhiteSpace(l))
                               .ToList();

            var dial = new LinkedList<int>(Enumerable.Range(0, 100));
            var current = dial.Find(50);

            int zeroHits = 0;

            foreach(var cmd in commands)
            {
                char dir = cmd[0];
                int steps = int.Parse(cmd.Substring(1));

                for(int i = 0; i<steps; i++)
                {
                    if(dir == 'R')
                    {
                        current = current.Next ?? dial.First;
                    } else
                    {
                        current = current.Previous ?? dial.Last;
                    }

                    if(current.Value == 0)
                    {
                        zeroHits++;
                    }
                }
            }

            Console.WriteLine("Password (method 0x434C49434B): " + zeroHits);
        }

    }
}
