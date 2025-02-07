using System;
using static System.Console;
using System.Globalization;
class HoursAndMinutes
{
	static void Main()
	{
        int min = 197; //minutes total
        int hours = min / 60; //computaion for turning into hours
        int remainingMin = min % 60; //finds the remainig min

		WriteLine($"{min} minutes is {hours} hours and {remainingMin} minutes.");
	}
}