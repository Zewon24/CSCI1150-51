using System;
using static System.Console;
using System.IO;
class DirectoryInformation
{
   static void Main()
   {
      string input;

        while (true)
        {
            Write("Enter a directory >> ");
            input = ReadLine();

            if (input.ToLower() == "end")
                break;

            if (Directory.Exists(input))
            {
                string[] files = Directory.GetFiles(input);
                WriteLine($"{input} contains the following files");

                if (files.Length == 0)
                {
                    WriteLine("  (No files found)");
                }
                else
                {
                    foreach (string file in files)
                    {
                        WriteLine("  " + file);
                    }
                }
            }
            else
            {
                WriteLine($"Directory {input} does not exist");
            }

            WriteLine();
            Write("Enter another directory or type end to quit >> ");
        }
   }
}