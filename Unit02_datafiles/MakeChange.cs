using System;
using static System.Console;
using System.Globalization;
class MakeChange
{
	static void Main()
	{
        Console.Write("Enter the amount in dollars: ");//the promt
        int amount = int.Parse(Console.ReadLine());

        int twenties = amount / 20;//calculate twenties
        amount %= 20;

        int tens = amount / 10;//calculate tens
        amount %= 10;

        int fives = amount / 5;//calculate fives
        amount %= 5;

        int ones = amount;//remaining amount

        WriteLine($"twenties: {twenties} tens: {tens} fives: {fives} ones: {ones}");//display results
	}
}