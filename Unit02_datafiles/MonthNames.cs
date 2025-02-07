using System;
using static System.Console;
using System.Globalization;
class MonthNames
{
	public enum Month
{
    JANUARY = 1,
    FEBRUARY = 2,
    MARCH = 3,
    APRIL = 4,
    MAY = 5,
    JUNE = 6,
    JULY = 7,
    AUGUST = 8,
    SEPTEMBER = 9,
    OCTOBER = 10,
    NOVEMBER = 11,
    DECEMBER = 12
}
	static void Main()
	{
        Write("Enter a month number >> ");//input
        int monthNumber = int.Parse(ReadLine());

        if (Enum.IsDefined(typeof(Month), monthNumber))//convert number to month
        {
            Month month = (Month)monthNumber;
            WriteLine($"The month is: {month}");
        }
        else
        {
            WriteLine("Invalid month number.");
        }
	}
}