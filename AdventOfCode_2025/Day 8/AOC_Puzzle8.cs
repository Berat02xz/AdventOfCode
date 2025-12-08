using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace AdventOfCode_2025.Day_8
{
    public class AOC_Puzzle8
    {
        public static void Solution(string[] args)
        {
            var lines = File.ReadAllLines("../../../Day 8/user_input.txt").ToList();

            int[] nums = lines[0].Split(',').Select(int.Parse).ToArray();

            int maxEndingHere = nums[0];
            int maxSoFar = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                maxEndingHere = Math.Max(nums[i], maxEndingHere + nums[i]);
                maxSoFar = Math.Max(maxSoFar, maxEndingHere);
            }
            Console.WriteLine($"The maximum subarray sum is: {maxSoFar}");
        }

    }
}