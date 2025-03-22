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
        } while (!int.TryParse(ReadLine(), out contestants) || contestants < 0 || contestants > 30);
        
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
    }
    
    static void GetLists(Dictionary<char, List<string>> talentDictionary)
    {
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
    }
}
