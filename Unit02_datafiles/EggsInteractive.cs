using System;
using static System.Console;
using System.Globalization;
class EggsInteractive
{
	static void Main()
	{
        int chick1, chick2, chick3, chick4;//declare the variables

		Write("Number of eggs laid by Chicken 1: ");//makes user put how many eggs
        chick1 = int.Parse(ReadLine());
        
        Write("Number of eggs laid by Chicken 2: ");
        chick2 = int.Parse(ReadLine());

        Write("Number of eggs laid by Chicken 3: ");
        chick3 = int.Parse(ReadLine());

        Write("Number of eggs laid by Chicken 4: ");
        chick4 = int.Parse(ReadLine());

        int totalEggs = chick1 + chick2 + chick3 + chick4;//calculate the eggs
        int dozens = totalEggs / 12;
        int remainingEggs = totalEggs % 12;

        WriteLine($"{totalEggs} eggs is {dozens} dozen and {remainingEggs} eggs.");//display result
	}
}