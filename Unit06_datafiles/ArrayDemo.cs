using System;
using static System.Console;
using System.Globalization;

class ArrayDemo
{
    enum Menu
    {
        IN_ORIGINAL_ORDER = 1, REVERSE_ORDER, SPECIFIC_POSITION, QUIT
    }

    static void Main()
    {
        int[] nums = { 7, 6, 3, 2, 10, 8, 4, 5, 9, 1 };
        int choice;
        
        do
        {
            DisplayMenu();
            choice = GetChoice();
            ProcessChoice(choice, nums);
        } while (choice != (int)Menu.QUIT);
    }

    static void DisplayMenu()
    {
        WriteLine("\nMenu:");
        WriteLine("1 View list in original order");
        WriteLine("2 View list in reverse order");
        WriteLine("3 View a specific position");
        WriteLine("4 Quit");
        Write("Enter choice: ");
    }

    static int GetChoice()
    {
        int choice;
        while (!int.TryParse(ReadLine(), out choice) || choice < 1 || choice > 4)
        {
            Write("Invalid. Enter a number between 1 and 4: ");
        }
        return choice;
    }

    static void ProcessChoice(int choice, int[] nums)
    {
        switch ((Menu)choice)
        {
            case Menu.IN_ORIGINAL_ORDER:
                DisplayArray(nums);
                break;
            case Menu.REVERSE_ORDER:
                DisplayArrayReverse(nums);
                break;
            case Menu.SPECIFIC_POSITION:
                DisplaySpecificPosition(nums);
                break;
            case Menu.QUIT:
                WriteLine("Exiting application");
                break;
        }
    }

    static void DisplayArray(int[] nums)
    {
        WriteLine("Array in original order:");
        foreach (int num in nums)
        {
            Write(num + " ");
        }
        WriteLine();
    }

    static void DisplayArrayReverse(int[] nums)
    {
        WriteLine("Array in reverse order:");
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            Write(nums[i] + " ");
        }
        WriteLine();
    }

    static void DisplaySpecificPosition(int[] nums)
    {
        int index;
        Write("Enter an index (0-9): ");
        while (!int.TryParse(ReadLine(), out index) || index < 0 || index >= nums.Length)
        {
            Write("Invalid. Enter a number between 0 and 9: ");
        }
        WriteLine($"Value at index {index}: {nums[index]}");
    }
}
