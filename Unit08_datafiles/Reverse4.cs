using System;
using static System.Console;
using System.Globalization;
class Reverse4
{
	static void Main()
	{
	
        int firstInt = 23;
        int secondInt = 45;
        int thirdInt = 55;
        int fourthInt = 67;

        WriteLine($"The numbers are {firstInt}, {secondInt}, {thirdInt}, {fourthInt}");

        Reverse(ref firstInt, ref secondInt, ref thirdInt, ref fourthInt);

        WriteLine($"The numbers are {firstInt}, {secondInt}, {thirdInt}, {fourthInt}");
    }

    static void Reverse(ref int first, ref int second, ref int third, ref int fourth)
    {
        int temp = first;
        first = fourth;
        fourth = temp;

        temp = second;
        second = third;
        third = temp;
    }
}