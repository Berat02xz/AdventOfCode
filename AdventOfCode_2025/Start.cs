// This is the main class that calls the other classes to run the solutions for the problems
// At the end of the advent this class will be the one that will run all the solutions for the problems by letting you choose which day you want to run and compare times


using AdventOfCode_2025.Day_1;
using AdventOfCode_2025.Day_2;
using AdventOfCode_2025.Day_3;

namespace AdventOfCode_2025
{
    public class Start
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Advent Of Code Solution:");
            // FINKI_Puzzle1.Solution(args);
            // AOC_Puzzle1.Solution(args);
            // AOC_Puzzle2.Solution(args);
            AOC_Puzzle3.Solution(args);


        }
    }
}
