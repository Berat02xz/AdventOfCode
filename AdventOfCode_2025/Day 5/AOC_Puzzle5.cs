using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace AdventOfCode_2025.Day_5
{
    public class AOC_Puzzle5
    {
        public static void Solution(string[] args)
        {
            var lines = File.ReadAllLines("../../../Day 5/input.txt").ToList();

            int blankIndex = lines.FindIndex(string.IsNullOrWhiteSpace);

            var firstSection = lines.Take(blankIndex).ToList();
            var secondSection = lines.Skip(blankIndex + 1).ToList();

            int freshIngrediant = 0;

            foreach (var line in secondSection)
            {
               long numberToCheck = long.Parse(line);
                foreach(var Check in firstSection)
                {
                    long first = long.Parse(Check.Split('-')[0]);
                    long second = long.Parse(Check.Split('-')[1]);
                    if(numberToCheck >= first && numberToCheck <= second)
                    {
                        freshIngrediant++;
                        break;
                    }
                }
            }
            Console.WriteLine("Number of fresh ingrediants: "+ freshIngrediant);

            //Part 2
            var intervals = new List<(long Start, long End)>();
            foreach (var line in firstSection)
            {
                long start = long.Parse(line.Split('-')[0]);
                long end = long.Parse(line.Split('-')[1]);
                intervals.Add((start, end));
            }

            intervals.Sort((a, b) => a.Start.CompareTo(b.Start));

            long totalNumbers = 0;
            long currentStart = intervals[0].Start;
            long currentEnd = intervals[0].End;

            foreach (var (start, end) in intervals.Skip(1))
            {
                if (start <= currentEnd + 1)  
                {
                    currentEnd = Math.Max(currentEnd, end);
                }
                else
                {
                    totalNumbers += currentEnd - currentStart + 1;
                    currentStart = start;
                    currentEnd = end;
                }
            }
            totalNumbers += currentEnd - currentStart + 1;
            Console.WriteLine("Total number of valid ingredients: " + totalNumbers);
        }
    }
}