using System;
using static System.Console;
using System.Globalization;
class InchesToCentimeters
{
	static void Main()
	{
		const double centi_per_inch = 2.54; //constant

		double inches = 3; //measurement in in
        double centimeters = inches * centi_per_inch; //makes in into cenimeters
        
        WriteLine($"{inches} inches is {centimeters:F2} centimeters"); //prints the result
	}
}