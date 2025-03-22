using System;
using static System.Console;
using System.Globalization;
class PaintingEstimate
{
	static void Main()
	{
		Write("Enter length of the room in feet >> ");
        double length = Convert.ToDouble(ReadLine());

        Write("Enter width of the room in feet >> ");
        double width = Convert.ToDouble(ReadLine());

        double cost = CalculatePaintingCost(length, width);

        WriteLine("Cost of job for {0} X {1} foot room is {2}", length, width, cost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
    }

    static double CalculatePaintingCost(double length, double width)
    {
        const double pricePerSquareFoot = 6.0;
        const double ceilingHeight = 9.0;

        double totalWallArea = 2 * (length * ceilingHeight + width * ceilingHeight);
        double totalCost = totalWallArea * pricePerSquareFoot;

        return totalCost;
    }
	
}