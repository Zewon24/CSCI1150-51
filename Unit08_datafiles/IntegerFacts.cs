using System;
using static System.Console;
using System.Globalization;
class IntegerFacts
{
	static void Main()
	{
		int[] numbers = new int[10];
        int count = FillArray(numbers);

        int max, min, sum;
        double avg;
        Statistics(numbers, count, out max, out min, out sum, out avg);

        WriteLine($"The array has {count} values");
        WriteLine($"The highest value is {max}");
        WriteLine($"The lowest value is {min}");
        WriteLine($"The sum of the values is {sum}");
        WriteLine($"The average is {avg}");
    }

    static int FillArray(int[] array)
    {
        int count = 0;
        WriteLine("Enter up to 10 integers (999 to stop):");

        while (count < 10)
        {
            Write("Enter a number: ");
            if (int.TryParse(ReadLine(), out int input))
            {
                if (input == 999)
                    break;

                array[count++] = input;
            }
            else
            {
                WriteLine("Invalid input. Please enter an integer.");
            }
        }
        return count;
    }

    static void Statistics(int[] array, int valueCount, out int max, out int min, out int sum, out double avg)
    {
        max = int.MinValue;
        min = int.MaxValue;
        sum = 0;

        for (int i = 0; i < valueCount; i++)
        {
            if (array[i] > max)
                max = array[i];
            if (array[i] < min)
                min = array[i];
            sum += array[i];
        }

        avg = valueCount > 0 ? (double)sum / valueCount : 0;
	}
}