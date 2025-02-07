using System;
using static System.Console;
using System.Globalization;
class MoveEstimator
{
	static void Main()
	{
        Write("Nnumber of hours for the move: ");//the user input
        int hours = int.Parse(ReadLine());

        Write("Number of miles for the move: ");
        int miles = int.Parse(ReadLine());

        int baseRate = 200;//calculate cost
        int hourlyRate = 150;
        int mileRate = 2;
        
        double totalCost = baseRate + (hours * hourlyRate) + (miles * mileRate);

        Console.WriteLine("For a move taking {0} hours and going {1} miles the estimate is {2}", //display the result
        hours, miles, totalCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
	}
}