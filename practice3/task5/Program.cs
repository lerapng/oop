using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Використання: analyzer.exe <шлях>");
            Console.WriteLine("Приклад: analyzer.exe C:\\Test");
            return;
        }

        string path = args[0];

        if (!Directory.Exists(path))
        {
            Console.WriteLine($"Помилка папка не знайдена {path}");
            return;
        }

        int folderCount = 0;
        int fileCount = 0;
        long totalSize = 0;
        FileInfo largestFile = null;

        foreach (string dir in Directory.GetDirectories(path, "*", SearchOption.AllDirectories))
            folderCount++;

        foreach (string file in Directory.GetFiles(path, "*", SearchOption.AllDirectories))
        {
            FileInfo info = new FileInfo(file);
            fileCount++;
            totalSize += info.Length;

            if (largestFile == null || info.Length > largestFile.Length)
                largestFile = info;
        }

        double sizeMB = totalSize / 1024.0 / 1024.0;

        Console.WriteLine($"\nFile Analyzer: {path}");
        Console.WriteLine($"Folders: {folderCount}");
        Console.WriteLine($"Files: {fileCount}");
        Console.WriteLine($"Total size: {sizeMB:F2} MB");
        Console.WriteLine($"Largest file: {(largestFile != null ? largestFile.Name : "—")}");
    }
}