// See https://aka.ms/new-console-template for more information

namespace App
{

    public static class Program
    {


        public static void Main(string[] args){
            Console.WriteLine("====================================================");
            Console.WriteLine("Welcome to my Advent of code project");
            Console.WriteLine("");
            Console.WriteLine("To run any day's solution please provide your input as a .txt file in the ./input/ directory");
            Console.WriteLine("Input files should be named as 'day_XX.txt' where XX is the 2 digit numeric date");
            Console.WriteLine("");
            Console.WriteLine("====================================================");
            while(true){
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("Please enter the day you would like to run: ");
                string? dayToRun = Console.ReadLine();
                if(dayToRun == null || !Int32.TryParse(dayToRun, out int j)){
                    Console.WriteLine("Error: Please enter a day to run");
                    Console.WriteLine("");
                    continue;
                }
                Console.WriteLine("Enter the solution you would like to run for the selected day (1/2): ");
                string? solutionToRun = Console.ReadLine();

                if(solutionToRun == null || !Int32.TryParse(dayToRun, out int k)){
                    Console.WriteLine("Error: Please enter a solution to run");
                    Console.WriteLine("");
                    continue;
                }

                var objCont = Activator.CreateInstance(null, $"Days.Day{dayToRun}");
                Days.DayClass? dayClass;
                if(objCont != null){
                    dayClass = (Days.DayClass) objCont.Unwrap();
                    if(dayClass == null){
                        Console.WriteLine("Unable to load solution for given day");
                        Console.WriteLine("");
                        continue;
                    }
                } else {
                    Console.WriteLine("Unable to load solution for given day");
                    Console.WriteLine("");
                    continue;
                }
                
                string output = dayClass.RunSolution(dayToRun, solutionToRun);
                Console.WriteLine("=============================");
                Console.WriteLine($"Day {dayToRun} output: " + output);
                Console.WriteLine("=============================");
                Console.Write("Would you like to run another day? (y/n) ");
                string? runAgain = Console.ReadLine();
                if(runAgain != null){
                    runAgain = runAgain.ToLower();
                    if(runAgain == "y" || runAgain == "yes"){
                        continue;
                    } else {
                        break;
                    }
                } else {
                    break;
                }
            }
            Console.Write("Program terminated, Press any key to continue.");
            Console.ReadKey();
        }
    }
}
