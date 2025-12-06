using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace AdventOfCode_2025.Day_6
{
    public class AOC_Puzzle6
    {
        public static void Solution(string[] args)
        {
            var lines = File.ReadAllLines("../../../Day 6/input.txt").ToList();

            long totalSum = 0;

            int rowCount = lines.Count - 1; 
            int colCount = lines[0].Split(
                (char[])null!,
                StringSplitOptions.RemoveEmptyEntries
            ).Length;

            long[,] numbers = new long[rowCount, colCount];
            char[] ops = new char[colCount];

            for (int r = 0; r < rowCount; r++)
            {
                var rowValues = lines[r].Split(
                    (char[])null!,
                    StringSplitOptions.RemoveEmptyEntries
                );

                for (int c = 0; c < colCount; c++)
                    numbers[r, c] = long.Parse(rowValues[c]);
            }

            var opTokens = lines[^1].Split(
                (char[])null!,
                StringSplitOptions.RemoveEmptyEntries
            );

            for (int c = 0; c < colCount; c++)
                ops[c] = opTokens[c][0];

            for (int c = 0; c < colCount; c++)
            {
                long result = (ops[c] == '*') ? 1 : 0;

                for (int r = 0; r < rowCount; r++)
                {
                    if (ops[c] == '+')
                        result += numbers[r, c];
                    else
                        result *= numbers[r, c];
                }

                totalSum += result;
            }

            Console.WriteLine("Total Sum: " + totalSum);
        }
    }
}