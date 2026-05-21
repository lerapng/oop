using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Player
{
    public string Name { get; set; }
    public Inventory Inventory { get; set; }
}

class Inventory
{
    public List<string> Items { get; set; }
}

class Program
{
    static void Main()
    {
        Player player = new Player
        {
            Name = "Герой",
            Inventory = new Inventory { Items = new List<string> { "Меч", "Щит", "Зілля" } }
        };

        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(player, options);
        File.WriteAllText("player.json", json);
        Console.WriteLine("Збережено player.json:\n" + json);

        string modified = JsonSerializer.Serialize(new { player.Name }, options);
        Console.WriteLine("\nJSON без Inventory:\n" + modified);

        Player restored = JsonSerializer.Deserialize<Player>(modified, options);

        restored.Inventory ??= new Inventory { Items = new List<string>() };

        Console.WriteLine($"\nГравець: {restored.Name}");
        Console.WriteLine($"Інвентар: {(restored.Inventory.Items.Count == 0 ? "(порожній)" : string.Join(", ", restored.Inventory.Items))}");
    }
}