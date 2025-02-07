using System;
using static System.Console;
using System.Globalization;
class PigLatin
{
	static void Main()
	{
        Write("Enter a word: ");//input
        string word = ReadLine();

        if (string.IsNullOrEmpty(word))//checks if word
        {
            WriteLine("You must enter a valid word.");
            return;
        }

        string pigLatin = word.Substring(1) + word[0] + "ay";//convert word

        WriteLine("The word in Pig Latin is: " + pigLatin);//display result
	}
}