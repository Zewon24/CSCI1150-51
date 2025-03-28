using System;
using static System.Console;
using System.Globalization;
class Reverse3
{
	static void Main()
	{
		int firstInt = 23;
        int middleInt = 45;
        int lastInt = 67;

        WriteLine($"The numbers are {firstInt}, {middleInt}, {lastInt}");

        Reverse(ref firstInt, ref middleInt, ref lastInt);

        WriteLine($"The numbers are {firstInt}, {middleInt}, {lastInt}");
    }

    static void Reverse(ref int first, ref int middle, ref int last)
    {
        int temp = first;
        first = last;
        last = temp;
    }
	
}