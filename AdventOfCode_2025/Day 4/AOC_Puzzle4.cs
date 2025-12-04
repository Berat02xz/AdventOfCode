using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace AdventOfCode_2025.Day_4
{
    public class AOC_Puzzle5
    {
        public static void Solution(string[] args)
        {
            var lines = File.ReadAllLines("../../../Day 4/input.txt")
                            .Where(l => !string.IsNullOrWhiteSpace(l))
                            .ToList();

            //Positions to check
            int[,] gridPos = new int[,]
            {
                { -1, -1 },
                { -1, 0 },
                { -1, 1 },
                { 0, -1 },
                { 0, 1 },
                { 1, -1 },
                { 1, 0 },
                { 1, 1 }
            };

            int result = 0;
            bool changed = true;

            while (changed) {
                changed = false;
                for (int i = 0; i < lines.Count; i++)
                {
                    for (int j = 0; j < lines[i].Length; j++)
                    {
                        if (lines[i][j] != '@')
                            continue;

                        int totalAllowed = 0;

                        for (int k = 0; k < gridPos.GetLength(0); k++)
                        {
                            int newX = i + gridPos[k, 0];
                            int newY = j + gridPos[k, 1];

                            if (newX >= 0 && newX < lines.Count &&
                                newY >= 0 && newY < lines[newX].Length)
                            {
                                if (lines[newX][newY] == '@')
                                {
                                    totalAllowed++;
                                }
                            }
                        }

                        if (totalAllowed < 4)
                        {
                            result++;
                            
                            var row = lines[i].ToCharArray();
                            row[j] = 'x';
                            lines[i] = new string(row);

                            changed = true;
                        }
                    }
                }
            }

            Console.WriteLine($"Result: {result}");
        }
    }
}