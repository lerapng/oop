using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputPath = "story.txt";
        string outputPath = "report.txt";

        if (!File.Exists(inputPath))
        {
            File.WriteAllText(inputPath, "Six seven six seven. Six seven. Sixxx seveeeennn. 67");
            Console.WriteLine($"Створено файл {inputPath}");
        }

        int lineCount = 0;
        int wordCount = 0;
        int charCount = 0;

        using (StreamReader reader = new StreamReader(inputPath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lineCount++;
                charCount += line.Length;
                wordCount += line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
            }
        }

        string report =
            $"Cтатистика файлу {inputPath}\n" +
            $"Рядків: {lineCount}\n" +
            $"Слів: {wordCount}\n" +
            $"Символів: {charCount}\n";

        using (StreamWriter writer = new StreamWriter(outputPath))
        {
            writer.Write(report);
        }

        Console.WriteLine(report);
        Console.WriteLine($"Звіт збережено у {outputPath}");
    }
}
