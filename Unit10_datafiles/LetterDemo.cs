using System;
using static System.Console;
using System.Globalization;
public class Letter
{
    public string Name { get; set; }
    public string DateMailed { get; set; }

    public Letter() { }

    public override string ToString()
    {
        return $"{GetType()} - Name: {Name}, Date Mailed: {DateMailed}";
    }
}

public class CertifiedLetter : Letter
{
    public string TrackingNumber { get; set; }

    public CertifiedLetter() { }

    public override string ToString()
    {
        return $"{GetType()} - Name: {Name}, Date Mailed: {DateMailed}, Tracking Number: {TrackingNumber}";
    }
}

public class LetterDemo
{
    public static void Main(string[] args)
    {
        //Letter instance
        Letter regularLetter = new Letter();
        regularLetter.Name = "Alice Johnson";
        regularLetter.DateMailed = "2025-04-08";

        //CertifiedLetter instance
        CertifiedLetter certifiedLetter = new CertifiedLetter();
        certifiedLetter.Name = "Bob Smith";
        certifiedLetter.DateMailed = "2025-04-07";
        certifiedLetter.TrackingNumber = "123456789US";

        //Display info
        WriteLine("Regular Letter Info:");
        WriteLine(regularLetter.ToString());
        WriteLine();

        WriteLine("Certified Letter Info:");
        WriteLine(certifiedLetter.ToString());
    }
}