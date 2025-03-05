using System;
using static System.Console;
using System.Globalization;
class TestScoreList
{
	static void Main()
	{
		int[] scores = new int[8];
        int sum = 0;

        WriteLine("Enter 8 test scores:"); //input from the user
        for (int i = 0; i < scores.Length; i++)
        {
            Write($"Test # {i}: ");
            scores[i] = int.Parse(ReadLine());
            sum += scores[i];
        }

        double average = sum / (double)scores.Length; //calculate the average
        WriteLine("\nResults:");

        for (int i = 0; i < scores.Length; i++) //display
        {
            double deviation = scores[i] - average;
            WriteLine($"Test # {i}: {scores[i],5} From average: {deviation,6:F1}");
        }
	}
}