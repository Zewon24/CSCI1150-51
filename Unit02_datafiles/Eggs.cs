using System;
using static System.Console;
using System.Globalization;
class Eggs
{
	static void Main()
	{
        int chick1 = 31;//declare the variables
        int chick2 = 31;
        int chick3 = 31;
        int chick4 = 34;

        int totalEggs = chick1 + chick2 + chick3 + chick4;//calculate the eggs
        int dozens = totalEggs / 12;
        int remainingEggs = totalEggs % 12;

        Console.WriteLine($"{totalEggs} eggs is {dozens} dozen and {remainingEggs} eggs.");//display result
	}
}