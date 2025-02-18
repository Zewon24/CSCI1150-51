using System;
using static System.Console;
using System.Globalization;

class GreenvilleRevenue
{
   static void Main()
   {
      Write("Enter number of contestants last year >> ");
      int lastYearContestants = int.Parse(ReadLine());

      Write("Enter number of contestants this year >> ");
      int thisYearContestants = int.Parse(ReadLine());

      WriteLine($"Last year's competition had {lastYearContestants} contestants, and this year's has {thisYearContestants} contestants");

      double entranceFee = 25.00;
      double revenue = thisYearContestants * entranceFee;

      WriteLine($"Revenue expected this year is {revenue.ToString("C", CultureInfo.GetCultureInfo("en-US"))}");

      if (thisYearContestants > 2 * lastYearContestants)
      {
         WriteLine("The competition is more than twice as big this year!");
      }
      else if (thisYearContestants > lastYearContestants)
      {
         WriteLine("The competition is bigger than ever!");
      }
      else
      {
         WriteLine("A tighter race this year! Come out and cast your vote!");
      }
   }
}
