using System;
using static System.Console;
using System.Globalization;
class MarshallsRevenue
{
   static void Main()
   {
      int interiorMurals, exteriorMurals;//declare var
      decimal interiorRevenue, exteriorRevenue, totalRevenue;

      Write("Enter number of interior murals scheduled >> ");//input from user
      interiorMurals = int.Parse(ReadLine());
        
      Write("Enter number of exterior murals scheduled >> ");
      exteriorMurals = int.Parse(ReadLine());

      interiorRevenue = interiorMurals * 500;//calculate revenue for type of mural
      exteriorRevenue = exteriorMurals * 750;

      totalRevenue = interiorRevenue + exteriorRevenue;//calculate expected revenue

      WriteLine("{0} interior murals are scheduled at {1} each for a total of {2}", //display revenue
         interiorMurals, 
         500.ToString("C", CultureInfo.GetCultureInfo("en-US")),
         interiorRevenue.ToString("C", CultureInfo.GetCultureInfo("en-US")));

      WriteLine("{0} exterior murals are scheduled at {1} each for a total of {2}", 
         exteriorMurals, 
         750.ToString("C", CultureInfo.GetCultureInfo("en-US")),
         exteriorRevenue.ToString("C", CultureInfo.GetCultureInfo("en-US")));

      WriteLine("Total revenue expected is {0}", totalRevenue.ToString("C", CultureInfo.GetCultureInfo("en-US")));//display total revenue

      bool moreInteriorThanExterior = interiorMurals > exteriorMurals;//check if more interior are scheduled than exterior.
      WriteLine("It is {0} that there are more interior murals scheduled than exterior ones.", moreInteriorThanExterior);
   }
}
