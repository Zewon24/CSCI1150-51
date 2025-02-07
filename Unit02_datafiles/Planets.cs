using System;
using static System.Console;
using System.Globalization;
public enum Planet
{
    MERCURY = 1,
    VENUS,
    EARTH,
    MARS,
    JUPITER,
    SATURN,
    URANUS,
    NEPTUNE
}
class Planets

{
	static void Main()
	{
        Console.Write("Enter the numeric position of the planet (1-8): ");//input
        int position = int.Parse(Console.ReadLine());

        if (position < 1 || position > 8)//check if valid
        {
            Console.WriteLine("Invalid position! Please enter a number between 1 and 8.");
            return;
        }

        Planet planet = (Planet)position;//get planet name
        
        Console.WriteLine($"{planet} is {position} planet(s) from the sun.");//display result
	}
}