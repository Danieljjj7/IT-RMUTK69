using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yaimakmak1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isPasswordCorrect = false;
            while (!isPasswordCorrect)
            {
                Console.Write("Please enter password: ");
                string inputPassword = Console.ReadLine();

                if (CheckPassword(inputPassword))
                {
                    isPasswordCorrect = true;
                    Console.WriteLine("\n[Success]\n");
                }
                else
                {
                    Console.WriteLine("[Error] Password must be more than 8 characters. Please try again!\n");
                }
            }

            DisplayWelcomeMessage();
            Console.WriteLine("\nPress Enter to continue to the main menu");
            Console.ReadLine();

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("                MAIN MENU");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("1. Display Welcome Message");
                Console.WriteLine("2. Convert Celsius to Fahrenheit");
                Console.WriteLine("3. Convert Base Digit (ConvertDigit)");
                Console.WriteLine("4. Calculate Grade");
                Console.WriteLine("5. Display Number Grid");
                Console.WriteLine("6. Display Multiplication Table");
                Console.WriteLine("7. Calculate Factorial");
                Console.WriteLine("8. Draw Christmas Tree");
                Console.WriteLine("9. Find Divisible Numbers");
                Console.WriteLine("0. Exit Program");
                Console.WriteLine("------------------------------------------");
                Console.Write("Select an option (0-9): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        DisplayWelcomeMessage();
                        break;

                    case "2":
                        Console.Write("Enter temperature in Celsius: ");
                        if (double.TryParse(Console.ReadLine(), out double celsius))
                        {
                            double fahrenheit = CelsiusToFahrenheit(celsius);
                            Console.WriteLine($"Result: {celsius}°C = {fahrenheit}°F");
                        }
                        else
                        {
                            Console.WriteLine("Invalid number input!");
                        }
                        break;

                    case "3":
                        Console.Write("Enter target base (2, 8, 16): ");
                        int targetBase = int.Parse(Console.ReadLine());
                        Console.Write("Enter base 10 number: ");
                        int number = int.Parse(Console.ReadLine());

                        string resultDigit = ConvertDigit(targetBase, number);
                        Console.WriteLine($"Result: ConvertDigit({targetBase}, {number}) = {resultDigit}");
                        break;

                    case "4":
                        Console.Write("Enter score 1 (Behavior): ");
                        int s1 = int.Parse(Console.ReadLine());
                        Console.Write("Enter score 2 (Assignment): ");
                        int s2 = int.Parse(Console.ReadLine());
                        Console.Write("Enter score 3 (Midterm): ");
                        int s3 = int.Parse(Console.ReadLine());
                        Console.Write("Enter score 4 (Final): ");
                        int s4 = int.Parse(Console.ReadLine());

                        string grade = CalculateGrade(s1, s2, s3, s4);
                        Console.WriteLine($"Calculated Grade: {grade}");
                        break;

                    case "5":
                        Console.Write("Enter start number: ");
                        int startNum = int.Parse(Console.ReadLine());
                        Console.Write("Enter end number: ");
                        int endNum = int.Parse(Console.ReadLine());
                        Console.Write("Enter numbers per row: ");
                        int countPerRow = int.Parse(Console.ReadLine());

                        Console.WriteLine("\n--- Output ---");
                        PrintNumberGrid(startNum, endNum, countPerRow);
                        break;

                    case "6":
                        Console.Write("Enter start multiplication table: ");
                        int startTable = int.Parse(Console.ReadLine());
                        Console.Write("Enter end multiplication table: ");
                        int endTable = int.Parse(Console.ReadLine());

                        Console.WriteLine();
                        PrintMultiplicationTable(startTable, endTable);
                        break;

                    case "7":
                        Console.Write("Enter number for Factorial (!): ");
                        int factNum = int.Parse(Console.ReadLine());

                        long factResult = Factorial(factNum);
                        Console.WriteLine($"Result: {factNum}! = {factResult}");
                        break;

                    case "8":
                        Console.Write("Enter number of Christmas bushes: ");
                        int bushes = int.Parse(Console.ReadLine());

                        Console.WriteLine();
                        PrintChristmasTree(bushes);
                        break;

                    case "9":
                        Console.Write("Enter start number: ");
                        int divStart = int.Parse(Console.ReadLine());
                        Console.Write("Enter end number: ");
                        int divEnd = int.Parse(Console.ReadLine());
                        Console.Write("Enter divisor: ");
                        int divisor = int.Parse(Console.ReadLine());

                        string divResult = FindDivisibleNumbers(divStart, divEnd, divisor);
                        Console.WriteLine($"Divisible numbers result: {divResult}");
                        break;

                    case "0":
                        keepRunning = false;
                        Console.WriteLine("Thank you for using the program!");
                        break;

                    default:
                        Console.WriteLine("Invalid option! Please select 0-9.");
                        break;
                }

                if (keepRunning)
                {
                    Console.Write("\nDo you want to return to the menu? (y/n): ");
                    string answer = Console.ReadLine();

                    if (answer != null && answer.Trim().ToLower() == "y")
                    {
                        keepRunning = true;
                    }
                    else
                    {
                        keepRunning = false;
                        Console.WriteLine("\nProgram terminated. Goodbye!");
                    }
                }
            }
        }

        static bool CheckPassword(string password)
        {
            bool isOk = false;
            if (password.Length >= 8)
            {
                Console.WriteLine("This password is Ok");
                isOk = true;
            }
            return isOk;
        }

        static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome User");
            Console.WriteLine("This is Program for beginner player.");
            Console.WriteLine("Warning :");
            Console.WriteLine("\t1. Players should be over 12 years old.");
            Console.WriteLine("\t2. You should play no more than 2 hours per day.");
        }

        static double CelsiusToFahrenheit(double celsius)
        {
            double fahrenheit = celsius * 9.0 / 5.0 + 32;
            return fahrenheit;
        }
        static string ConvertDigit(int targetBase, int number)
        {
            string result = "";
            try
            {
                result = Convert.ToString(number, targetBase).ToUpper();
            }
            catch
            {
                result = "Invalid Base";
            }
            return result;
        }
        static string CalculateGrade(int score1, int score2, int score3, int score4)
        {
            int totalScore = score1 + score2 + score3 + score4;
            string grade = "F";

            if (totalScore >= 80) grade = "A";
            else if (totalScore >= 75) grade = "B+";
            else if (totalScore >= 70) grade = "B";
            else if (totalScore >= 65) grade = "C+";
            else if (totalScore >= 60) grade = "C";
            else if (totalScore >= 55) grade = "D+";
            else if (totalScore >= 50) grade = "D";

            return grade;
        }
        static void PrintNumberGrid(int start, int end, int countPerRow)
        {
            int currentInLine = 0;
            for (int i = start; i <= end; i++)
            {
                Console.Write($"{i} ");
                currentInLine++;
                if (currentInLine == countPerRow)
                {
                    Console.WriteLine();
                    currentInLine = 0;
                }
            }
            if (currentInLine != 0) Console.WriteLine();
        }
        static void PrintMultiplicationTable(int startTable, int endTable)
        {
            for (int i = startTable; i <= endTable; i++)
            {
                Console.WriteLine($"Multiplication Table {i}");
                for (int j = 1; j <= 12; j++)
                {
                    Console.WriteLine($"{i} x {j,2} = {i * j}");
                }
                Console.WriteLine("********************");
            }
        }
        static long Factorial(int n)
        {
            long result = 0;
            if (n >= 0)
            {
                result = 1;
                for (int i = 1; i <= n; i++)
                {
                    result *= i;
                }
            }
            return result;
        }
        static void PrintChristmasTree(int bushes)
        {
            if (bushes < 3)
            {
                Console.WriteLine("error Christmas bush!!!");
            }
            else
            {
                int maxCols = bushes + 2;
                int totalWidth = maxCols * 2;

                for (int b = 1; b <= bushes; b++)
                {
                    int startRow = (b == 1) ? 1 : b;
                    int endRow = b + 2;

                    for (int row = startRow; row <= endRow; row++)
                    {
                        string line = "";
                        for (int col = 1; col <= row; col++)
                        {
                            line += col + " ";
                        }
                        Console.WriteLine(line.TrimEnd().PadLeft((totalWidth + line.TrimEnd().Length) / 2));
                    }
                }

                for (int i = 0; i < bushes; i++)
                {
                    string line = "1 1 1";
                    Console.WriteLine(line.PadLeft((totalWidth + line.Length) / 2));
                }
            }
        }
        static string FindDivisibleNumbers(int start, int end, int divisor)
        {
            var numbers = Enumerable.Range(start, end - start + 1)
                                    .Where(i => i % divisor == 0);
            string result = string.Join(", ", numbers);
            return result;
        }
    }
}