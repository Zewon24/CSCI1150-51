using System;
using static System.Console;
using System.Globalization;
class SumInts
{
	static void Main()
	{
		int sum = 0;
        int number;
        WriteLine("Enter integers to sum (enter 999 to stop):");
        
        while (true)
        {
            Write("Enter an integer: ");
            while (!int.TryParse(ReadLine(), out number))
            {
                Write("Invalid. Please enter an integer: ");
            }
            
            if (number == 999)
                break;
            
            sum += number;
        }
        
        WriteLine($"The sum of the entered integers is: {sum}");
	}
}