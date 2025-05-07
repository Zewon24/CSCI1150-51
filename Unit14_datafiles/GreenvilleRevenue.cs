using System;
using static System.Console;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class GreenvilleRevenue
{
    static void Main()
    {
        int lastYearContestants = GetContestantNumber("last year");
        int thisYearContestants = GetContestantNumber("this year");

        WriteLine($"\nLast year's competition had {lastYearContestants} contestants, and this year's has {thisYearContestants} contestants.");

        double totalRevenue = 0;

        Dictionary<char, List<Contestant>> talentDictionary = new()
        {
            { 'S', new List<Contestant>() },
            { 'D', new List<Contestant>() },
            { 'M', new List<Contestant>() },
            { 'O', new List<Contestant>() },
            { 'I', new List<Contestant>() }
        };

        GetContestantData(thisYearContestants, talentDictionary, ref totalRevenue);

        WriteLine($"\nRevenue expected this year is {totalRevenue.ToString("C", CultureInfo.GetCultureInfo("en-US"))}");

        DisplayRelationship(thisYearContestants, lastYearContestants);

        // Save to JSON
        List<Contestant> allContestants = new List<Contestant>();
        foreach (var list in talentDictionary.Values)
            allContestants.AddRange(list);

        string json = JsonSerializer.Serialize(allContestants, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("Greenville.json", json);
        WriteLine("\nData saved to Greenville.json.");

        // Load from JSON
        List<Contestant> loadedContestants = JsonSerializer.Deserialize<List<Contestant>>(File.ReadAllText("Greenville.json"));

        // Rebuild dictionary from loaded data
        talentDictionary = new()
        {
            { 'S', new List<Contestant>() },
            { 'D', new List<Contestant>() },
            { 'M', new List<Contestant>() },
            { 'O', new List<Contestant>() },
            { 'I', new List<Contestant>() }
        };
        foreach (var contestant in loadedContestants)
        {
            talentDictionary[contestant.TalentCode].Add(contestant);
        }

        GetLists(talentDictionary);

        WriteLine("\nThank you for using the Greenville Talent Tracker!");
    }

    static int GetContestantNumber(string year)
    {
        int contestants = -1;
        while (true)
        {
            try
            {
                Write($"Enter number of contestants {year} (0-30) >> ");
                string input = ReadLine();
                contestants = int.Parse(input);
                if (contestants < 0 || contestants > 30)
                    throw new ArgumentOutOfRangeException();
                break;
            }
            catch (FormatException)
            {
                WriteLine("Invalid input - please enter a valid number.");
            }
            catch (ArgumentOutOfRangeException)
            {
                WriteLine("Number must be between 0 and 30");
            }
        }
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

    static void GetContestantData(int contestantCount, Dictionary<char, List<Contestant>> talentDictionary, ref double totalRevenue)
    {
        for (int i = 0; i < contestantCount; i++)
        {
            Write($"\nEnter contestant {i + 1}'s name: ");
            string name = ReadLine();

            int age;
            do
            {
                Write("Enter age >> ");
            } while (!int.TryParse(ReadLine(), out age) || age < 0);

            char talentCode = 'I';
            WriteLine("Talent codes are:\n  S   Singing\n  D   Dancing\n  M   Musical instrument\n  O   Other");
            Write("       Enter talent code >> ");
            string inputCode = ReadLine();

            try
            {
                if (string.IsNullOrEmpty(inputCode) || inputCode.Length != 1)
                    throw new FormatException();

                char code = char.ToUpper(inputCode[0]);

                if (!Contestant.IsValidTalentCode(code))
                    throw new ArgumentException();

                talentCode = code;
            }
            catch (FormatException)
            {
                WriteLine("Invalid format - entry must be a single character. Assigned as Invalid.");
            }
            catch (ArgumentException)
            {
                WriteLine($"{inputCode} is not a valid talent code. Assigned as Invalid.");
            }

            Contestant contestant;
            if (age <= 12)
                contestant = new ChildContestant(name, talentCode);
            else if (age <= 17)
                contestant = new TeenContestant(name, talentCode);
            else
                contestant = new AdultContestant(name, talentCode);

            totalRevenue += contestant.Fee;

            WriteLine("Added: " + contestant.ToString());

            talentDictionary[contestant.TalentCode].Add(contestant);
        }
    }

    static void GetLists(Dictionary<char, List<Contestant>> talentDictionary)
    {
        WriteLine("\nThe types of talent are:");
        WriteLine($"Singing                   {talentDictionary['S'].Count}");
        WriteLine($"Dancing                   {talentDictionary['D'].Count}");
        WriteLine($"Musical instrument        {talentDictionary['M'].Count}");
        WriteLine($"Other                     {talentDictionary['O'].Count}");

        char searchTalent = '\0';
        do
        {
            Write("\nEnter a talent type or Z to quit >> ");
            string input = ReadLine();

            if (string.IsNullOrEmpty(input) || input.Length != 1)
            {
                WriteLine("Invalid format - entry must be a single character.");
                continue;
            }

            searchTalent = char.ToUpper(input[0]);

            if (searchTalent == 'Z')
                break;

            if (!talentDictionary.ContainsKey(searchTalent) || searchTalent == 'I')
            {
                WriteLine($"{searchTalent} is not a valid code");
                continue;
            }

            if (talentDictionary[searchTalent].Count > 0)
            {
                WriteLine($"\nContestants with talent {Contestant.GetTalentDescription(searchTalent)} are:");
                foreach (var contestant in talentDictionary[searchTalent])
                    WriteLine(contestant.ToString());
            }
            else
            {
                WriteLine($"\nNo contestants registered for talent type {Contestant.GetTalentDescription(searchTalent)}.");
            }

        } while (true);
    }
}

// ---- Contestant Classes Below ----

public class Contestant
{
    public static readonly char[] talentCodes = { 'S', 'D', 'M', 'O' };
    public static readonly string[] talentStrings = { "Singing", "Dancing", "Musical instrument", "Other" };

    public string Name { get; set; }
    private char talentCode;
    public double Fee { get; set; }
    public string ContestantType { get; set; }

    public char TalentCode
    {
        get => talentCode;
        set => talentCode = IsValidTalentCode(value) ? value : 'I';
    }

    public string Talent => GetTalentDescription(TalentCode);

    public Contestant() { }

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

    public override string ToString()
    {
        return $"{Name} {TalentCode}   Fee {Fee.ToString("C", CultureInfo.GetCultureInfo("en-US"))}";
    }
}

public class ChildContestant : Contestant
{
    public ChildContestant(string name, char code) : base(name, code)
    {
        Fee = 15.00;
        ContestantType = "Child";
    }

    public override string ToString()
    {
        return $"Child Contestant {base.ToString()}";
    }
}

public class TeenContestant : Contestant
{
    public TeenContestant(string name, char code) : base(name, code)
    {
        Fee = 20.00;
        ContestantType = "Teen";
    }

    public override string ToString()
    {
        return $"Teen Contestant {base.ToString()}";
    }
}

public class AdultContestant : Contestant
{
    public AdultContestant(string name, char code) : base(name, code)
    {
        Fee = 30.00;
        ContestantType = "Adult";
    }

    public override string ToString()
    {
        return $"Adult Contestant {base.ToString()}";
    }
}
