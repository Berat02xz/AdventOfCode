// This is the main class that calls the other classes to run the solutions for the problems
// At the end of the advent this class will be the one that will run all the solutions for the problems by letting you choose which day you want to run and compare times


using AdventOfCode_2025.Day_1;

namespace AdventOfCode_2025
{
    public class Start
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Pick Solution From Commented Lines To Run (Open in editor)");
            // FINKI_Puzzle1.Solution(args);
            AOC_Puzzle1.Solution(args);
            // Puzzle3.Solution(args);
            // Puzzle4.Solution(args);
            // Puzzle5.Solution(args);
            // Puzzle6.Solution(args);
            // Puzzle7.Solution(args);
            // Puzzle8.Solution(args);
            // Puzzle9.Solution(args);
            // Puzzle10.Solution(args);
            // Puzzle11.Solution(args);

        }
    }
}
