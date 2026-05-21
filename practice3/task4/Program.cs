using System;
using System.IO;
using System.Collections.Generic;

class CacheCleaner
{
    // рекурсія
    public static (int count, long size) CleanRecursive(string path)
    {
        int count = 0;
        long size = 0;

        foreach (string file in Directory.GetFiles(path))
        {
            FileInfo info = new FileInfo(file);
            size += info.Length;
            File.Delete(file);
            count++;
        }

        foreach (string dir in Directory.GetDirectories(path))
        {
            var (c, s) = CleanRecursive(dir);
            count += c;
            size += s;
        }

        return (count, size);
    }

    // ьез рекурсії 
    public static (int count, long size) CleanIterative(string path)
    {
        int count = 0;
        long size = 0;

        Stack<string> stack = new Stack<string>();
        stack.Push(path);

        while (stack.Count > 0)
        {
            string current = stack.Pop();

            foreach (string file in Directory.GetFiles(current))
            {
                FileInfo info = new FileInfo(file);
                size += info.Length;
                File.Delete(file);
                count++;
            }

            foreach (string dir in Directory.GetDirectories(current))
                stack.Push(dir);
        }

        return (count, size);
    }
}

class Program
{
    static void CreateTestCache(string path)
    {
        Directory.CreateDirectory(Path.Combine(path, "sub1"));
        Directory.CreateDirectory(Path.Combine(path, "sub2", "deep"));
        File.WriteAllText(Path.Combine(path, "temp1.tmp"), new string('A', 1024));
        File.WriteAllText(Path.Combine(path, "sub1", "cache1.dat"), new string('B', 2048));
        File.WriteAllText(Path.Combine(path, "sub2", "cache2.dat"), new string('C', 512));
        File.WriteAllText(Path.Combine(path, "sub2", "deep", "log.tmp"), new string('D', 4096));
    }

    static void Main()
    {
        string cachePathRecursive = Path.Combine(Path.GetTempPath(), "test_cache_recursive");
        string cachePathIterative = Path.Combine(Path.GetTempPath(), "test_cache_iterative");

        // рекурс
        if (Directory.Exists(cachePathRecursive)) Directory.Delete(cachePathRecursive, true);
        CreateTestCache(cachePathRecursive);

        Console.WriteLine("Рекурсивне очищення");
        var (countR, sizeR) = CacheCleaner.CleanRecursive(cachePathRecursive);
        Console.WriteLine($"Видалено файлів: {countR}");
        Console.WriteLine($"Звільнено місця: {sizeR / 1024.0:F2} KB");

        // нерекурс
        if (Directory.Exists(cachePathIterative)) Directory.Delete(cachePathIterative, true);
        CreateTestCache(cachePathIterative);

        Console.WriteLine("\nІтеративне очищення");
        var (countI, sizeI) = CacheCleaner.CleanIterative(cachePathIterative);
        Console.WriteLine($"Видалено файлів: {countI}");
        Console.WriteLine($"Звільнено місця: {sizeI / 1024.0:F2} KB");
    }
}