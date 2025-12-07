using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace AdventOfCode_2025.Day_7
{
    public class AOC_Puzzle7
    {
        public static void Solution(string[] args)
        {
            var lines = File.ReadAllLines("../../../Day 7/input.txt").ToList();

            char Start = 'S';
            char Beam = '^';

            HashSet<(int, int)> PositionsOfBreaks = new HashSet<(int, int)>();

            int[,] startbeam = new int[1, 1];

            for (int row = 0; row < lines.Count; row++)
            {
                for (int col = 0; col < lines[row].Length; col++)
                {
                    if (lines[row][col] == Beam)
                        PositionsOfBreaks.Add((row, col));

                    if (lines[row][col] == Start)
                        startbeam[0, 0] = col;
                }
            }

            int startCol = startbeam[0, 0];
            int totalRows = lines.Count;
            int totalBreaks = 0;

            HashSet<(int row, int col)> currentBeams = new();
            currentBeams.Add((0, startCol));

            while (currentBeams.Count > 0)
            {
                HashSet<(int row, int col)> nextBeams = new();

                foreach (var (row, col) in currentBeams)
                {
                    int nextRow = row + 1;

                    if (nextRow >= totalRows)
                        continue;

                    if (PositionsOfBreaks.Contains((nextRow, col)))
                    {
                        totalBreaks++;

                        if (col > 0)
                            nextBeams.Add((nextRow, col - 1));

                        if (col < lines[0].Length - 1)
                            nextBeams.Add((nextRow, col + 1));
                    }
                    else
                    {
                        nextBeams.Add((nextRow, col));
                    }
                }
                currentBeams = nextBeams;
            }

            Console.WriteLine($"Total Breaks: {totalBreaks}");
        }


    }
}