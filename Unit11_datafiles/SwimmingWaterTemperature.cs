using System;
using static System.Console;
using System.Globalization;
class SwimmingWaterTemperature
{
	static void Main()
	{
		while (true)
        {
            Write("\nEnter a water temperature in Fahrenheit (999 to quit): ");
            string input = ReadLine();

            if (int.TryParse(input, out int temp))
            {
                if (temp == 999)
                {
                    WriteLine("Exiting program.");
                    break;
                }

                try
                {
                    if (IsComfortableTemperature(temp))
                    {
                        WriteLine($"{temp} degrees is comfortable for swimming.");
                    }
                    else
                    {
                        WriteLine($"{temp} degrees is not comfortable for swimming.");
                    }
                }
                catch (ArgumentException)
                {
                    WriteLine("Value does not fall within the expected range.");
                }
            }
            else
            {
                WriteLine("Please enter a valid number.");
            }
        }
    }

    static bool IsComfortableTemperature(int temperature)
    {
        if (temperature < 32 || temperature > 212)
        {
            throw new ArgumentException("Temperature must be between 32 and 212 degrees Fahrenheit.");
        }

        return temperature >= 70 && temperature <= 85;
    }
}