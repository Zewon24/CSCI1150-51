using System;
using static System.Console;
using System.IO;
class FileComparison
{
   static void Main()
   {
      string notepadFile = "Quote.txt";
        string wordFile = "Quote.docx";

        try
        {
            FileInfo notepadInfo = new FileInfo(notepadFile);
            FileInfo wordInfo = new FileInfo(wordFile);

            long notepadSize = notepadInfo.Length;
            long wordSize = wordInfo.Length;

            WriteLine($"The size of the Word file is {wordSize} bytes");
            WriteLine($"and the size of the Notepad file is {notepadSize} bytes");

            if (wordSize > 0)
            {
                double ratio = ((double)notepadSize / wordSize) * 100;
               WriteLine($"The Notepad file is {ratio:F2}% of the size of the Word file");
            }
            else
            {
               WriteLine("The Word file has a size of 0 bytes. Cannot calculate ratio.");
            }
        }
        catch (FileNotFoundException ex)
        {
            WriteLine($"Error: {ex.FileName} was not found.");
        }
        catch (Exception ex)
        {
            WriteLine("An error occurred: " + ex.Message);
        }
   }
}