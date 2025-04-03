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

        Dictionary<char, List<Contestant>> talentDictionary = new()
        {
            { 'S', new List<Contestant>() },
            { 'D', new List<Contestant>() },
            { 'M', new List<Contestant>() },
            { 'O', new List<Contestant>() },
            { 'I', new List<Contestant>() }
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

    static void GetContestantData(int contestantCount, Dictionary<char, List<Contestant>> talentDictionary)
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

            } while (!Contestant.IsValidTalentCode(talentCode));

            Contestant contestant = new(name, talentCode);
            talentDictionary[contestant.TalentCode].Add(contestant);
        }
    }

    static void GetLists(Dictionary<char, List<Contestant>> talentDictionary)
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
                    WriteLine($"\nContestants with talent {Contestant.GetTalentDescription(searchTalent)} are:");
                    foreach (var contestant in talentDictionary[searchTalent])
                        WriteLine(contestant.Name);
                }
                else
                {
                    WriteLine($"\nNo contestants registered for talent type {Contestant.GetTalentDescription(searchTalent)}.");
                }
            }
            else
            {
                WriteLine("\nThat is not a valid code.");
            }

        } while (true);
    }
}

public class Contestant
{
    public static readonly char[] talentCodes = { 'S', 'D', 'M', 'O' };
    public static readonly string[] talentStrings = { "Singing", "Dancing", "Musical instrument", "Other" };

    public string Name { get; set; }
    private char talentCode;
    public char TalentCode
    {
        get => talentCode;
        set
        {
            if (Array.IndexOf(talentCodes, value) != -1)
                talentCode = value;
            else
                talentCode = 'I';
        }
    }

    public string Talent => GetTalentDescription(TalentCode);

    public Contestant(string name, char code)
    {
        Name = name;
        TalentCode = code;
    }

    public static bool IsValidTalentCode(char code)
    {
        return Array.IndexOf(talentCodes, code) != -1;
    }

    public static string GetTalentDescription(char code)
    {
        int index = Array.IndexOf(talentCodes, code);
        return index != -1 ? talentStrings[index] : "Invalid";
    }
}