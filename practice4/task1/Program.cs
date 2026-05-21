using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class TaskItem
{
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
}

class Program
{
    static string filePath = "tasks.json";
    static List<TaskItem> tasks = new List<TaskItem>();

    static void Main()
    {
        LoadTasks();

        while (true)
        {
            Console.WriteLine("\nTask Tracker");
            Console.WriteLine("1. Додати задачу");
            Console.WriteLine("2. Змінити статус задачі");
            Console.WriteLine("3. Переглянути список задач");
            Console.WriteLine("4. Вийти");
            Console.Write("Вибір: ");

            switch (Console.ReadLine())
            {
                case "1": AddTask(); break;
                case "2": ChangeStatus(); break;
                case "3": ShowTasks(); break;
                case "4":
                    SaveTasks();
                    Console.WriteLine("Задачі збережено. До побачення!");
                    return;
                default:
                    Console.WriteLine("Невірний вибір.");
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Назва задачі: ");
        string title = Console.ReadLine();
        tasks.Add(new TaskItem { Title = title, IsCompleted = false });
        Console.WriteLine("Задачу додано.");
    }

    static void ChangeStatus()
    {
        ShowTasks();
        if (tasks.Count == 0) return;

        Console.Write("Введіть номер задачі: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= tasks.Count)
        {
            tasks[index - 1].IsCompleted = !tasks[index - 1].IsCompleted;
            Console.WriteLine($"Статус змінено: {(tasks[index - 1].IsCompleted ? "✓ Виконано" : "○ Не виконано")}");
        }
        else
        {
            Console.WriteLine("Невірний номер.");
        }
    }

    static void ShowTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Список задач порожній.");
            return;
        }
        Console.WriteLine("\nСписок задач:");
        for (int i = 0; i < tasks.Count; i++)
            Console.WriteLine($"  {i + 1}. [{(tasks[i].IsCompleted ? "✓" : " ")}] {tasks[i].Title}");
    }

    static void SaveTasks()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        File.WriteAllText(filePath, JsonSerializer.Serialize(tasks, options));
    }

    static void LoadTasks()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
            Console.WriteLine($"Завантажено {tasks.Count} задач із файлу.");
        }
    }
}