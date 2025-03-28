using System;
using static System.Console;
using System.Globalization;
using System.Collections.Generic;

class GreenvilleRevenue
{
    static void Main()
    {
        int lastYearContestants = GetContestantNumber("last year");
        int thisYearContestants = GetContestantNumber("this year");

        WriteLine($"\nLast year's competition had {lastYearContestants} contestants, and this year's has {thisYearContestants} contestants.");

        double entranceFee = 25.00;
        double revenue = thisYearContestants * entranceFee;
        WriteLine($"Revenue expected this year is {revenue.ToString("C", CultureInfo.GetCultureInfo("en-US"))}");

        DisplayRelationship(thisYearContestants, lastYearContestants);

        Dictionary<char, List<string>> talentDictionary = new()
        {
            { 'S', new List<string>() },
            { 'D', new List<string>() },
            { 'M', new List<string>() },
            { 'O', new List<string>() }
        };

        GetContestantData(thisYearContestants, talentDictionary);
        GetLists(talentDictionary);

        WriteLine("\nThank you for using the Greenville Talent Tracker!");
    }

    static int GetContestantNumber(string year)
    {
        int contestants;
        do
        {
            Write($"Enter number of contestants {year} (0-30) >> ");
            if (!int.TryParse(ReadLine(), out contestants) || contestants < 0 || contestants > 30)
            {
                WriteLine("Invalid input - please enter a number between 0 and 30.");
            }
        } while (contestants < 0 || contestants > 30);

        return contestants;
    }

    static void DisplayRelationship(int thisYear, int lastYear)
    {
        if (thisYear > 2 * lastYear)
            WriteLine("The competition is more than twice as big this year!");
        else if (thisYear > lastYear)
            WriteLine("The competition is bigger than ever!");
        else
            WriteLine("A tighter race this year! Come out and cast your vote!");
    }

    static void GetContestantData(int contestantCount, Dictionary<char, List<string>> talentDictionary)
    {
        for (int i = 0; i < contestantCount; i++)
        {
            Write($"\nEnter contestant {i + 1}'s name: ");
            string name = ReadLine();

            char talentCode = '\0';
            do
            {
                WriteLine("Talent codes are:\n  S   Singing\n  D   Dancing\n  M   Musical instrument\n  O   Other");
                Write("       Enter talent code >> ");
                string input = ReadLine();

                if (string.IsNullOrEmpty(input) || input.Length != 1)
                {
                    WriteLine("Invalid format - entry must be a single character");
                    continue;
                }

                talentCode = char.ToUpper(input[0]);

                if (!talentDictionary.ContainsKey(talentCode))
                    WriteLine("That is not a valid code");

            } while (!talentDictionary.ContainsKey(talentCode));

            talentDictionary[talentCode].Add(name);
        }
    }

    static void GetLists(Dictionary<char, List<string>> talentDictionary)
    {
        WriteLine("\nThe types of talent are:");
        WriteLine($"Singing                   {talentDictionary['S'].Count}");
        WriteLine($"Dancing                   {talentDictionary['D'].Count}");
        WriteLine($"Musical instrument         {talentDictionary['M'].Count}");
        WriteLine($"Other                      {talentDictionary['O'].Count}");

        char searchTalent = '\0';
        do
        {
            Write("\nEnter a talent type or Z to quit >> ");
            string input = ReadLine();

            if (string.IsNullOrEmpty(input) || input.Length != 1)
            {
                WriteLine("Invalid format - entry must be a single character");
                continue;
            }

            searchTalent = char.ToUpper(input[0]);

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
                WriteLine($"\nThat is not a valid code");
            }

        } while (true);
    }
}

