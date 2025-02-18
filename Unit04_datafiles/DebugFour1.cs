// Program takes a hot dog order
// And determines price
using System;
using static System.Console;
using System.Globalization;
class DebugFour1
{
   static void Main()
   {
      const double BASIC_DOG_PRICE = 2.00;
      const double CHILI_PRICE = 0.69;
      const double CHEESE_PRICE = 0.49;
      string wantChili, wantCheese;          
      double price = BASIC_DOG_PRICE; // Initialize price with basic dog price

      Write("Do you want chili on your dog? (Y/N): ");
      wantChili = ReadLine().ToUpper(); // Convert input to uppercase for consistency
      Write("Do you want cheese on your dog? (Y/N): ");
      wantCheese = ReadLine().ToUpper();

      if (wantChili == "Y")
         price += CHILI_PRICE;
      
      if (wantCheese == "Y")
         price += CHEESE_PRICE;

      WriteLine("Your total is {0}", price.ToString("C", CultureInfo.GetCultureInfo("en-US")));
   }
}
