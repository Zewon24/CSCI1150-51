using System;
using static System.Console;
using System.Globalization;
class InchesToCentimeterslnteractive
{
	static void Main()
	{
		const double centi_per_inch = 2.54; //constant

		Write("Enter the amount of inches: "); 
		double inches = Convert.ToDouble(ReadLine()); //takes input as a string then convert to double

        double centimeters = inches * centi_per_inch; //makes in into cenimeters
        
        WriteLine($"{inches} inches is {centimeters:F2} centimeters"); //prints the result
	}
}
