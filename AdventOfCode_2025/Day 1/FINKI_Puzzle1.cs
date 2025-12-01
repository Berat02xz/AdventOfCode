using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode_2025.Day_1
{
    public class FINKI_Puzzle1
    {
        public static void Solution(string[] args)
        {
            StreamReader reader = new StreamReader("../../../Day 1/user_input.txt");
            string[] lines = reader.ReadToEnd().Split("\n");

            int result = 0;

            int K = int.Parse(lines[0]);

            //LINQ magic
            List<int> friendlyScore = lines[1]
                .Split(',')
                .Select(int.Parse)
                .ToList();

            friendlyScore.Sort();
            int maxGroupSize = 0;

            for ( int i = 0; i<friendlyScore.Count; i++)
            {
                int start = friendlyScore[i];
                int maximumScore = start + K;
                int groupSize = 0;

                for (int j = i; j<friendlyScore.Count; j++)
                {
                    if (friendlyScore[j] <= maximumScore)
                    {
                        groupSize++;
                    }
                    else
                    {
                        break;
                    }
                }
                maxGroupSize = Math.Max(maxGroupSize, groupSize);
            }
            Console.WriteLine($"Number of capybaras: {friendlyScore.Count}");
            Console.WriteLine($"Max capybaras in valid group: {maxGroupSize}");
        }
    }
}

