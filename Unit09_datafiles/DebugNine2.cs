using System;
using static System.Console;
using System.Globalization;

class DebugNine2
{
    static void Main()
    {
        Breakfast special = new Breakfast("French toast", 4.99);

        WriteLine(Breakfast.INFO);

        WriteLine("Today we are having {0} for {1}",
            special.Name, special.Price.ToString("C2", CultureInfo.GetCultureInfo("en-US")));
    }
}

public class Breakfast
{
    public const string INFO = "Breakfast is the most important meal of the day.";

    public string Name { get; set; }
    public double Price { get; set; }

    public Breakfast(string name, double price)
    {
        Name = name;
        Price = price;
    }
}