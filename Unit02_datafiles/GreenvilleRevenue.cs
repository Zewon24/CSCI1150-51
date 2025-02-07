using System;
using static System.Console;
using System.Globalization;
class GreenvilleRevenue
{
   static void Main()
   {
      Write("Enter number of contestants last year >> ");// input for # of contestance
      int lastYearContestants = int.Parse(ReadLine());

      Write("Enter number of contestants this year >> ");
      int thisYearContestants = int.Parse(ReadLine());

      WriteLine($"Last year's competition had {lastYearContestants} contestants, and this year's has {thisYearContestants} contestants");//display

      double entranceFee = 25.00;//calculate expected revenue
      double revenue = thisYearContestants * entranceFee;

      WriteLine($"Revenue expected this year is {revenue.ToString("C", CultureInfo.GetCultureInfo("en-US"))}");//display revenue

      bool isBigger = thisYearContestants > lastYearContestants;
      WriteLine($"It is {isBigger} that this year's competition is bigger than last year's.");//check if more contestants this year
   }
}
