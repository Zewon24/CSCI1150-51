using System;
using static System.Console;
using System.Globalization;
class SubscriptExceptionTest
{
	static void Main()
	{
		double[] numbers = { 67.5, 14.6, 20.3, 40.6, 50.8, 60.9, 70.0, 80.3, 90.4, 100.7 };
        int index;

        WriteLine("Enter an array subscript (0-9) to view the value, or enter 99 to quit.");

        while (true)
        {
            Write("\nEnter subscript: ");
            string input = ReadLine();

            if (int.TryParse(input, out index))
            {
                if (index == 99)
                {
                    WriteLine("Exiting program.");
                    break;
                }

                try
                {
                    WriteLine($"Value at index {index} is {numbers[index]}");
                }
                catch (IndexOutOfRangeException)
                {
                    WriteLine("Index was outside the bounds of the array.");
                }
            }
            else
            {
                WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
	
}