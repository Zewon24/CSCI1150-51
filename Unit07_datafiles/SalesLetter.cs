using System;
using static System.Console;
using System.Globalization;
class SalesLetter
{
	static void Main()
	{
		WriteLine("From");
        DisplayContactInfo();
        WriteLine("____________________________\n");

        WriteLine("Dear Client,");
        WriteLine("We want to provide you good service.");
        WriteLine("Feel free to contact us at any time.");
        DisplayContactInfo();
        WriteLine("     *********\n");

        WriteLine("Looking forward to a long relationship.");
        DisplayContactInfo();
    }

    static void DisplayContactInfo()
    {
        WriteLine("Tech Solutions");
        WriteLine("Phone: 555-5678     Cell: 555-8765");
        WriteLine("Email: info@techsolutions.com");
        WriteLine("On the Web at www.techsolutions.com\n");
    }
	
}