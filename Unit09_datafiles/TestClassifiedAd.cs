using System;
using static System.Console;
using System.Globalization;
namespace ClassifiedAdApp
{
    // Define the ClassifiedAd class
    class ClassifiedAd
    {
        public string Category { get; set; }
        public int Words { get; set; }
        
        // Price is calculated at 9 cents per word
        public decimal Price => Words * 0.09m;
        
        // Constructor
        public ClassifiedAd(string category, int words)
        {
            Category = category;
            Words = words;
        }

        // Method to display ad information
        public void DisplayAdInfo()
        {
            Console.WriteLine("The classified ad with {0} words in category {1} costs {2}",
                Words, Category, Price.ToString("C", CultureInfo.GetCultureInfo("en-US")));
        }
    }

    // Main application class
    class TestClassifiedAd
    {
        static void Main()
        {
            // Instantiate ClassifiedAd objects
            ClassifiedAd ad1 = new ClassifiedAd("Used Cars", 100);
            ClassifiedAd ad2 = new ClassifiedAd("Help Wanted", 60);
            
            // Display ad information
            ad1.DisplayAdInfo();
            ad2.DisplayAdInfo();
        }
    }
}
