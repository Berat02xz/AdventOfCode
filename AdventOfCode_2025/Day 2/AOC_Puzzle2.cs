using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode_2025.Day_2
{
    public class AOC_Puzzle2
    {
        public static void Solution(string[] args)
        {
            var lines = File.ReadAllLines("../../../Day 2/input.txt")
                               .Where(l => !string.IsNullOrWhiteSpace(l))
                               .ToList();

            List<string> ranges = new List<string>(lines[0].Split(","));
            
            long sumOfInvalidIds = 0;

            foreach (var id in ranges)
            {

                long firstId = long.Parse(id.Split("-")[0]);
                long lastId = long.Parse(id.Split("-")[1]);

                for (long i = firstId; i <= lastId; i++)
                {
                   bool isRepeated = CheckForRepeatedDigits(i.ToString());
                    if (isRepeated)
                    {
                        sumOfInvalidIds += i;
                        Console.WriteLine("Repeated Digits found at: "+i);
                    }
                }
            }

            Console.WriteLine("Sum of invalid ID's: "+sumOfInvalidIds);

        }
        private static bool CheckForRepeatedDigits(string v)
        {
            int len = v.Length;

            for (int blockSize = 1; blockSize <= len / 2; blockSize++)
            {
                if (len % blockSize != 0)
                    continue;

                string block = v.Substring(0, blockSize);
                int repeats = len / blockSize;

                StringBuilder sb = new StringBuilder(len);
                for (int i = 0; i < repeats; i++)
                {
                    sb.Append(block);
                }

                if (sb.ToString() == v)
                    return true;
            }
            return false;
        }
    }
}
