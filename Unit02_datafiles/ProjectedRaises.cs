using System;
using static System.Console;
using System.Globalization;
class ProjectedRaises
{
	static void Main()
	{
        const double raise_percent = 0.04;//constant for raise percentage
        
        double employee_1 = 25000;//salaries
        double employee_2 = 38000;
        double employee_3 = 51000;
        
        double newEmployee_1 = employee_1 + (employee_1 * raise_percent);//calculate future salaries
        double newEmployee_2 = employee_2 + (employee_2 * raise_percent);
        double newEmployee_3 = employee_3 + (employee_3 * raise_percent);
        
        Console.WriteLine("Next year's salary for the first employee will be {0}", newEmployee_1.ToString("C", CultureInfo.GetCultureInfo("en-US")));//display results
        Console.WriteLine("Next year's salary for the second employee will be {0}", newEmployee_2.ToString("C", CultureInfo.GetCultureInfo("en-US")));
        Console.WriteLine("Next year's salary for the third employee will be {0}", newEmployee_3.ToString("C", CultureInfo.GetCultureInfo("en-US")));
	}
}