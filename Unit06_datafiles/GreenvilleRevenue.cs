using System;
using static System.Console;
using System.Globalization;
using System.Collections.Generic;

class GreenvilleRevenue
{
    static void Main()
    {
        int lastYearContestants;
        int thisYearContestants;

        do
        {
            Write("Enter number of contestants last year (0-30) >> ");
        } while (!int.TryParse(ReadLine(), out lastYearContestants) || lastYearContestants < 0 || lastYearContestants > 30);

        do
        {
            Write("Enter number of contestants this year (0-30) >> ");
        } while (!int.TryParse(ReadLine(), out thisYearContestants) || thisYearContestants < 0 || thisYearContestants > 30);

        WriteLine($"\nLast year's competition had {lastYearContestants} contestants, and this year's has {thisYearContestants} contestants.");

        double entranceFee = 25.00;
        double revenue = thisYearContestants * entranceFee;
        WriteLine($"Revenue expected this year is {revenue.ToString("C", CultureInfo.GetCultureInfo("en-US"))}");

        if (thisYearContestants > 2 * lastYearContestants)
            WriteLine("The competition is more than twice as big this year!");
        else if (thisYearContestants > lastYearContestants)
            WriteLine("The competition is bigger than ever!");
        else
            WriteLine("A tighter race this year! Come out and cast your vote!");

        Dictionary<char, List<string>> talentDictionary = new()
        {
            { 'S', new List<string>() }, // Singing
            { 'D', new List<string>() }, // Dancing
            { 'M', new List<string>() }, // Musical instrument
            { 'O', new List<string>() }  // Other
        };

        for (int i = 0; i < thisYearContestants; i++)
        {
            Write($"\nEnter contestant {i + 1}'s name: ");
            string name = ReadLine();

            char talentCode;
            do
            {
                Write("Enter talent code (S for Singing, D for Dancing, M for Musical Instrument, O for Other) >> ");
                talentCode = char.ToUpper(ReadKey().KeyChar);
                WriteLine();

                if (!talentDictionary.ContainsKey(talentCode))
                    WriteLine($"{talentCode} is not a valid code. Please enter S, D, M, or O.");

            } while (!talentDictionary.ContainsKey(talentCode));

            talentDictionary[talentCode].Add(name);
        }

        WriteLine("\nThe types of talent are:");
        WriteLine($"Singing             {talentDictionary['S'].Count}");
        WriteLine($"Dancing             {talentDictionary['D'].Count}");
        WriteLine($"Musical instrument  {talentDictionary['M'].Count}");
        WriteLine($"Other               {talentDictionary['O'].Count}");

        char searchTalent;
        do
        {
            Write("\nEnter a talent code to see contestants (Z to exit) >> ");
            searchTalent = char.ToUpper(ReadKey().KeyChar);
            WriteLine();

            if (searchTalent == 'Z')
                break;

            if (talentDictionary.ContainsKey(searchTalent))
            {
                if (talentDictionary[searchTalent].Count > 0)
                {
                    string talentName = searchTalent switch
                    {
                        'S' => "Singing",
                        'D' => "Dancing",
                        'M' => "Musical instrument",
                        'O' => "Other",
                        _ => "Unknown"
                    };

                    WriteLine($"\nContestants with talent {talentName} are:");
                    foreach (var contestant in talentDictionary[searchTalent])
                        WriteLine(contestant);
                }
                else
                {
                    WriteLine($"\nNo contestants registered for talent type {searchTalent}.");
                }
            }
            else
            {
                WriteLine($"\n{searchTalent} is not a valid code. Please enter S, D, M, O, or Z to exit.");
            }

        } while (true);

        WriteLine("\nThank you for using the Greenville Talent Tracker!");
    }
}
