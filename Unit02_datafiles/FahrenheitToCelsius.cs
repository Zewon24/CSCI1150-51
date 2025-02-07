using System;
using static System.Console;
using System.Globalization;
class FahrenheitToCelsius
{
	static void Main()
	{
        Write("Enter temperature in Fahrenheit: ");//input
        double fahrenheit = Convert.ToDouble(ReadLine());

        double celsius = (fahrenheit - 32) * 5.0 / 9.0;//convert f to c

        WriteLine($"{fahrenheit:F1} F is {celsius:F1} C.");//display result
	}
}