using System;
using System.IO;
using System.Text.Json;

class Player
{
    public string Name { get; set; }
    public int Level { get; set; } = 1; 
}

class Program
{
    static void Main()
    {
        string oldJson = """{ "Name": "Артем" }""";
        File.WriteAllText("old_player.json", oldJson);
        Console.WriteLine("Старий JSON:\n" + oldJson);

        Player loaded = JsonSerializer.Deserialize<Player>(File.ReadAllText("old_player.json"));

        Console.WriteLine($"\nПісля завантаження у нову модель:");
        Console.WriteLine($"Name:  {loaded.Name}");
        Console.WriteLine($"Level: {loaded.Level}  ← значення за замовчуванням");

        var options = new JsonSerializerOptions { WriteIndented = true };
        string newJson = JsonSerializer.Serialize(loaded, options);
        File.WriteAllText("new_player.json", newJson);
        Console.WriteLine("\nОновлений JSON:\n" + newJson);
    }
}