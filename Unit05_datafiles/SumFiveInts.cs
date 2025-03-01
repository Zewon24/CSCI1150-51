using System;
using static System.Console;
using System.Globalization;
class SumFiveInts
{
	static void Main()
	{
		int sum = 0;
        WriteLine("Enter five integers:");
        
        for (int i = 0; i < 5; i++)
        {
            int number;
            Write($"Enter integer {i + 1}: ");
            while (!int.TryParse(ReadLine(), out number))
            {
                Write("Invalid. Please enter an integer: ");
            }
            sum += number;
        }
        
        WriteLine($"The sum of the five integers is: {sum}");
	}
}