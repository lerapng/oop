using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double AverageScore { get; set; }
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student { Name = "Олena Ковaль", Age = 20, AverageScore = 4.8 },
            new Student { Name = "Іван iевченко", Age = 21, AverageScore = 3.9 },
            new Student { Name = "Марія Бондар", Age = 19, AverageScore = 4.5 },
            new Student { Name = "Дмитро Мельник", Age = 22, AverageScore = 3.2 },
            new Student { Name = "Анна Поліщук",Age = 20, AverageScore = 4.1 }
        };

        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(students, options);
        File.WriteAllText("students.json", json);
        Console.WriteLine("Список серіалізовано у students.json\n");

        string loaded = File.ReadAllText("students.json");
        List<Student> restored = JsonSerializer.Deserialize<List<Student>>(loaded);

        Console.WriteLine("Студенти після десеріалізації");
        foreach (Student s in restored)
            Console.WriteLine($"  {s.Name}, вік: {s.Age}, середній бал: {s.AverageScore}");
    }
}
