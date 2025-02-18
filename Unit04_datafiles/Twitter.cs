using System;
using static System.Console;
using System.Globalization;
class Twitter
{
	static void Main()
	{
		const int MAX_LENGTH = 140;

        Write("Enter your message: ");
        string message = ReadLine();

        if (message.Length > MAX_LENGTH)
        {
            WriteLine("The message is too long.");
        }
        else
        {
            WriteLine("The message is okay.");
        }
	}
}