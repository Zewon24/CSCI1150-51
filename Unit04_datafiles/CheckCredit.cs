using System;
using static System.Console;
using System.Globalization;
class CheckCredit
{
	static void Main()
	{
		const double CREDIT_LIMIT = 8000.0;

        Write("Enter the purchase price: ");
        if (double.TryParse(ReadLine(), out double purchasePrice))
        {
            if (purchasePrice > CREDIT_LIMIT)
            {
                WriteLine("You have exceeded the credit limit.");
            }
            else
            {
                WriteLine("Approved.");
            }
        }
        else
        {
            WriteLine("Invalid input. Please enter a numeric value.");
        }
	}
}