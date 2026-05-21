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

        Console.WriteLine($"\nІнспекція {path}");

        string[] subDirs = Directory.GetDirectories(path);
        Console.WriteLine($"\nПідпапки ({subDirs.Length}):");
        foreach (string dir in subDirs)
            Console.WriteLine($"  [DIR] {Path.GetFileName(dir)}");

        string[] files = Directory.GetFiles(path);
        Console.WriteLine($"\nФайли ({files.Length}):");
        foreach (string file in files)
        {
            FileInfo info = new FileInfo(file);
            Console.WriteLine($"  {info.Name}");
            Console.WriteLine($"Розмір: {info.Length} байт");
            Console.WriteLine($"Дата створення: {info.CreationTime:yyyy-MM-dd HH:mm:ss}");
        }
    }
}
