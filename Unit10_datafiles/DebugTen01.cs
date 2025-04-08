// Defines a base class named Customer
// And a child class FrequentCustomer who receives a discount
// Main program demonstrates a customer of each type
using System;
using static System.Console;
using System.Globalization;

class DebugTen01
{
    static void Main()
    {
        Customer aRegularCustomer = new Customer();
        aRegularCustomer.CustNum = 2514;
        aRegularCustomer.CustBalance = 765.00;

        FrequentCustomer aFrequentCustomer = new FrequentCustomer();
        aFrequentCustomer.CustNum = 5719;
        aFrequentCustomer.CustBalance = 2500.00;
        aFrequentCustomer.DiscountRate = 0.15;

        WriteLine("\naRegularCustomer #{0} owes {1}",
            aRegularCustomer.CustNum,
            aRegularCustomer.CustBalance.ToString("C", CultureInfo.GetCultureInfo("en-US")));

        WriteLine("\naFrequentCustomer #{0} would owe {1} without the discount",
            aFrequentCustomer.CustNum,
            aFrequentCustomer.CustBalance.ToString("C", CultureInfo.GetCultureInfo("en-US")));

        double newBal = (1 - aFrequentCustomer.DiscountRate) * aFrequentCustomer.CustBalance;

        WriteLine("...with {0} discount, customer owes {1}",
            aFrequentCustomer.DiscountRate.ToString("P"),
            newBal.ToString("C", CultureInfo.GetCultureInfo("en-US")));
    }
}

class Customer
{
    public int CustNum { get; set; }
    public double CustBalance { get; set; }
}

class FrequentCustomer : Customer
{
    public double DiscountRate { get; set; }
}

