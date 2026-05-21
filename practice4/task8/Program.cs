using System;
using System.IO;
using System.Text.Json;

class Config
{
    public string Username { get; set; }
    public int Timeout { get; set; }
}

class Program
{
    static void Main()
    {
        string[] testCases =
        {
            """{ "Username": "admin", "Timeout": 30 }""",   // валідний
            """{ "Username": "user", "Timeout": "abc" }""", // невірний 
            """{ "Username": "test" """,                     // незакритий джсон
            ""                                               // порожній 
        };

        foreach (string json in testCases)
        {
            Console.WriteLine($"\nВхідний JSON: {(json.Length > 0 ? json : "(порожній)")}");
            Config config = TryDeserialize(json);

            if (config != null)
                Console.WriteLine($"  Username: {config.Username}, Timeout: {config.Timeout}");
        }
    }

    static Config TryDeserialize(string json)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(json))
                throw new JsonException("JSON рядок порожній.");

            return JsonSerializer.Deserialize<Config>(json);
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Помилка десеріалізації: {ex.Message}");
            return new Config { Username = "guest", Timeout = 10 };
        }
    }
}