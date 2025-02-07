using System;
using static System.Console;
using System.Globalization;
class TestsInteractive
{
	static void Main()
	{
		Write("Enter test score 1 >> ");
        int score_1 = int.Parse(ReadLine());

		Write("Enter test score 2 >> ");
        int score_2 = int.Parse(ReadLine());

		Write("Enter test score 3 >> ");
        int score_3 = int.Parse(ReadLine());

		Write("Enter test score 4 >> ");
        int score_4 = int.Parse(ReadLine());

		Write("Enter test score 5 >> ");
        int score_5 = int.Parse(ReadLine());

		Write("Enter test score 6 >> ");
        int score_6 = int.Parse(ReadLine());

		Write("Enter test score 7 >> ");
        int score_7 = int.Parse(ReadLine());

		Write("Enter test score 8 >> ");
        int score_8 = int.Parse(ReadLine());

        double average = (score_1 + score_2 + score_3 + score_4 + score_5 + score_6 + score_7 + score_8) / 8.0;//calculate average

        WriteLine($"The average test score is {average:F2}.");//display avrage
	}
}