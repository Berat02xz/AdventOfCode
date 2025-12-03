using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace AdventOfCode_2025.Day_3
{
    public class AOC_Puzzle3
    {
        public static void Solution(string[] args)
        {
            var lines = File.ReadAllLines("../../../Day 3/input.txt")
                            .Where(l => !string.IsNullOrWhiteSpace(l))
                            .ToList();

            long total = 0;

            foreach (var line in lines)
            {
                string best12 = GetLargest12DigitNumber(line);

                Console.WriteLine("Largest 12 digits formed: " + best12);

                total += long.Parse(best12);
            }

            Console.WriteLine("Total sum of largest 12 digit numbers: " + total);
        }

        private static string GetLargest12DigitNumber(string line)
        {
            var digits = line.Where(char.IsDigit).Select(c => c - '0').ToList();

            int keep = 12;
            int remove = digits.Count - keep;

            Stack<int> stack = new Stack<int>();

            foreach (var d in digits)
            {
                while (remove > 0 && stack.Count > 0 && stack.Peek() < d)
                {
                    stack.Pop();
                    remove--;
                }

                stack.Push(d);
            }

            var result = stack.Reverse().Take(keep);

            return string.Join("", result);
        }
    }
}
