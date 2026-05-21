using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Введіть шлях до папки: ");
        string path = Console.ReadLine();

        if (!Directory.Exists(path))
        {
            Console.WriteLine("Папку не знайдено.");
            return;
        }

        FileInfo largest = null;

        foreach (string file in Directory.GetFiles(path, "*", SearchOption.AllDirectories))
        {
            FileInfo info = new FileInfo(file);
            if (largest == null || info.Length > largest.Length)
                largest = info;
        }

        if (largest == null)
        {
            Console.WriteLine("Файлів не знайдено.");
            return;
        }

        Console.WriteLine($"\nНайбільший файл:");
        Console.WriteLine($"Name: {largest.Name}");
        Console.WriteLine($"Size: {largest.Length / 1024.0 / 1024.0:F2} MB ({largest.Length} байт)");
        Console.WriteLine($"Path: {largest.FullName}");
    }
}