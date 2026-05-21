using System;
using System.Text.Json;
using System.Text.Json.Serialization;

enum OrderStatus
{
    Pending,
    Processing,
    Completed
}

class Order
{
    public int Id { get; set; }
    public OrderStatus Status { get; set; }
}

class Program
{
    static void Main()
    {
        Order order = new Order { Id = 1, Status = OrderStatus.Processing };

        Console.WriteLine("Без конвертера (числош)");
        string jsonDefault = JsonSerializer.Serialize(order, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine(jsonDefault);

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };

        Console.WriteLine("З JsonStringEnumConverter (текст)");
        string jsonString = JsonSerializer.Serialize(order, options);
        Console.WriteLine(jsonString);

        Order restored = JsonSerializer.Deserialize<Order>(jsonString, options);
        Console.WriteLine($"\nДесеріалізовано: Id={restored.Id}, Status={restored.Status}");
    }
}