using System;

namespace simpleCalculator
{
    public class Logging
    {// Class for Logging Purposes on the Detailed mode

        public static string[] ConvertToStringFromDouble(double firstnumber, double secondnumber, double result)
        {//Converting Doubles to String for Logging
            string firstString = Convert.ToString(firstnumber);
            string secondString = Convert.ToString(secondnumber);
            string resultString = Convert.ToString(result);
            string[] final = { firstString, secondString, resultString }; 
            return final;
        }
        public static void SaveLog(string[] numbers, string process, int logCounter, string[] logDetails)
        {// Save the Log line to logDetails array
                logDetails[logCounter] = numbers[0] + process + numbers[1] + "=" + numbers[2];
                PrintLogs(logDetails); // Print the current logDetails Array
        }
        public static void PrintLogs(string[] logDetails)
        {// Print the current logDetails Array
            Console.WriteLine("\n\nMath History\n******");
            for (int i = 0; i < logDetails.Length; i++)
            {
                Console.WriteLine(logDetails[i]);
            }
            Console.WriteLine("******\nHistory END\n\n");
        }
    }
    class Mathematical
    {//Class for Math, seperated to two (Simple, Detailed)
        public static int Sum()
        {
            Console.Write("Enter First Number: ");
            int firstNumber = IsValidNumber.IsInteger("ERROR : Please enter a number");
            Console.Write("Enter Second Number: ");
            int secondNumber = IsValidNumber.IsInteger("ERROR : Please enter a number");
            int result = firstNumber + secondNumber;
            return result;
        }
        public static int Minus()
        {
            Console.Write("Enter First Number: ");
            int firstNumber = IsValidNumber.IsInteger("ERROR : Please enter a number");
            Console.Write("Enter Second Number: ");
            int secondNumber = IsValidNumber.IsInteger("ERROR : Please enter a number");
            int result = firstNumber - secondNumber;
            return result;
        }
        public static int Multiply()
        {
            Console.Write("Enter First Number: ");
            int firstNumber = IsValidNumber.IsInteger("ERROR : Please enter a number");
            Console.Write("Enter Second Number: ");
            int secondNumber = IsValidNumber.IsInteger("ERROR : Please enter a number");
            int result = firstNumber * secondNumber;
            return result;
        }
        public static int Division()
        {
            Console.Write("Enter First Number: ");
            int firstNumber = IsValidNumber.IsInteger("ERROR : Please enter a number");
            Console.Write("Enter Second Number: ");
            int secondNumber = IsValidNumber.IsInteger("ERROR : Please enter a number");
            int result = firstNumber / secondNumber;
            return result;
        }
        public static double SumDetailed(int logCounter, string[] logDetails)
        {
            Console.Write("Enter First Number: ");
            double firstNumber = IsValidNumber.IsDouble("ERROR : Please enter a number");
            Console.Write("Enter Second Number: ");
            double secondNumber = IsValidNumber.IsDouble("ERROR : Please enter a number");
            double result = firstNumber + secondNumber;
            string[] log = Logging.ConvertToStringFromDouble(firstNumber, secondNumber, result); //Adding the Result to log Array
            Logging.SaveLog(log, "+", logCounter, logDetails); // Save and Print the log
            return result;
        }
        public static double MinusDetailed(int logCounter, string[] logDetails)
        {
            Console.Write("Enter First Number: ");
            double firstNumber = IsValidNumber.IsDouble("ERROR : Please enter a number");
            Console.Write("Enter Second Number: ");
            double secondNumber = IsValidNumber.IsDouble("ERROR : Please enter a number");
            double result = firstNumber - secondNumber;
            string[] log = Logging.ConvertToStringFromDouble(firstNumber, secondNumber, result);//Adding the Result to log Array
            Logging.SaveLog(log, "-", logCounter, logDetails);// Save and Print the log
            return result;
        }
        public static double MultiplyDetailed(int logCounter, string[] logDetails)
        {
            Console.Write("Enter First Number: ");
            double firstNumber = IsValidNumber.IsDouble("ERROR : Please enter a number");
            Console.Write("Enter Second Number: ");
            double secondNumber = IsValidNumber.IsDouble("ERROR : Please enter a number");
            double result = firstNumber * secondNumber;
            string[] log = Logging.ConvertToStringFromDouble(firstNumber, secondNumber, result);//Adding the Result to log Array
            Logging.SaveLog(log, "*", logCounter, logDetails);// Save and Print the log
            return result;
        }
        public static double DivisionDetailed(int logCounter, string[] logDetails)
        {
            Console.Write("Enter First Number: ");
            double firstNumber = IsValidNumber.IsDouble("ERROR : Please enter a number");
            Console.Write("Enter Second Number: ");
            double secondNumber = IsValidNumber.IsDouble("ERROR : Please enter a number");
            double result = firstNumber / secondNumber;
            string[] log = Logging.ConvertToStringFromDouble(firstNumber, secondNumber, result);//Adding the Result to log Array
            Logging.SaveLog(log, "/", logCounter, logDetails);// Save and Print the log
            return result;
        }
    }
    class IsValidNumber
    { // If number: make process, else: try again.
        public static int IsInteger(string errorLine)
        {// Is the number integer or not.
            int value;
            bool isError;
            do
            {
            start:
                string readedLine = Console.ReadLine();
                switch (readedLine)
                {
                    case "author": //Author
                        Console.WriteLine("Test project of Batuhan Bulut, 2022");
                        goto start;
                    case "END": // For Close 
                        Environment.Exit(0);
                        break;
                }
                try
                {
                    value = Convert.ToInt32(readedLine);
                    isError = false;
                }
                catch (Exception) // if it's not vaild, try again.
                {
                    Console.WriteLine(errorLine);
                    isError = true;
                    value = 0;
                }
            } while (isError);
            return value;
        }
        public static double IsDouble(string errorLine)
        {
            double value;
            bool isError;
            do
            {
                string readedLine = Console.ReadLine();
                switch (readedLine)
                {
                    case "author":
                        Console.WriteLine("Test project of Batuhan Bulut, 2022");
                        break;
                    case "END":
                        Environment.Exit(0);
                        break;
                }
                readedLine = readedLine.Replace(',', '.'); //replace , with . for Doubles
                try
                {
                    value = Convert.ToDouble(readedLine);
                    isError = false;
                }
                catch (Exception)// if it's not vaild, try again.
                {
                    Console.WriteLine(errorLine);
                    isError = true;
                    value = 0;

                }
            } while (isError);
            return value;
        }
    }
    class Program
    {
        static void Main()
        {
        Start:
            int welcomeValue = Welcome(); // Calling the first class
            switch (welcomeValue)
            {
                case 1:
                    Simple();
                    break;
                case 2:
                    Detailed();
                    break;
                default:
                    Console.WriteLine("\nPlease Enter a number in limits. (1 or 2)\n");
                    goto Start;
            }
        }
        static int Welcome()
        {
            Console.WriteLine("Welcome to best calculator in the world!\n");
            Console.WriteLine("You can always write 'END' for exit or 'author' for author data\n");
            Console.WriteLine("Choose Calculator Type:");
            Console.WriteLine("1 : Simple (Without decimals)");
            Console.WriteLine("2 : Detailed");
            int finalWelcome = IsValidNumber.IsInteger("ERROR : Please enter a number");
            return finalWelcome;
        }
        static void Simple()
        {
            Console.WriteLine("\n\nYou choose Simple Calculator\n\nChoose the process | 1 for + ; 2 for - ; 3 for / ; 4 for *");
        Start:
            int choose = IsValidNumber.IsInteger("ERROR : Please enter a number");
            switch (choose)
            {
                case 1:
                    Console.WriteLine("Result is = {0}", Mathematical.Sum());
                    Console.WriteLine("END");
                    Console.ReadKey();
                    Simple();
                    break;
                case 2:
                    Console.WriteLine("Result is = {0}", Mathematical.Minus());
                    Console.WriteLine("END");
                    Console.ReadKey();
                    Simple();
                    break;
                case 3:
                    Console.WriteLine("Result is = {0}", Mathematical.Division());
                    Console.WriteLine("END");
                    Console.ReadKey();
                    Simple();
                    break;
                case 4:
                    Console.WriteLine("Result is = {0}", Mathematical.Multiply());
                    Console.WriteLine("END");
                    Console.ReadKey();
                    Simple();
                    break;
                default:
                    Console.WriteLine("Please choose between the limits");
                    goto Start;
            }
        }
        static void Detailed()
        {
            int logCounter = 0;

            string[] logDetails;
            logDetails = new string[10];  
        Loop:
            Console.WriteLine("\n\nYou choose Detailed Calculator\n\nChoose the process | 1 for + ; 2 for - ; 3 for / ; 4 for *");
            if (logCounter >= logDetails.Length) { logCounter = 0; }
            int choose = IsValidNumber.IsInteger("ERROR : Please enter a number");
            switch (choose)
            {
                case 1:
                    Console.WriteLine("Result is = {0}", Mathematical.SumDetailed(logCounter++, logDetails));
                    Console.WriteLine("END");
                    Console.ReadKey();
                    goto Loop;
                case 2:
                    Console.WriteLine("Result is = {0}", Mathematical.MinusDetailed(logCounter++, logDetails));
                    Console.WriteLine("END");
                    Console.ReadKey();
                    Detailed();
                    goto Loop;
                case 3:
                    Console.WriteLine("Result is = {0}", Mathematical.DivisionDetailed(logCounter++, logDetails));
                    Console.WriteLine("END");
                    Console.ReadKey();
                    Detailed();
                    goto Loop;
                case 4:
                    Console.WriteLine("Result is = {0}", Mathematical.MultiplyDetailed(logCounter++, logDetails));
                    Console.WriteLine("END");
                    Console.ReadKey();
                    Detailed();
                    goto Loop;
                default:
                    Console.WriteLine("Please choose between the limits");
                    goto Loop;
            }
        }
    }
}
