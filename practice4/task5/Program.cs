using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(Dog), "dog")]
[JsonDerivedType(typeof(Cat), "cat")]
abstract class Animal
{
    public string Name { get; set; }
}

class Dog : Animal
{
    public int BarkVolume { get; set; }
}

class Cat : Animal
{
    public int Lives { get; set; }
}

class Program
{
    static void Main()
    {
        List<Animal> animals = new List<Animal>
        {
            new Dog { Name = "Рекс",   BarkVolume = 80 },
            new Cat { Name = "Мурка",  Lives = 9 },
            new Dog { Name = "Барсик", BarkVolume = 60 },
            new Cat { Name = "Пушок",  Lives = 7 }
        };

        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(animals, options);

        Console.WriteLine("JSON");
        Console.WriteLine(json);

        List<Animal> restored = JsonSerializer.Deserialize<List<Animal>>(json, options);

        Console.WriteLine("\nПісля десеріалізації");
        foreach (Animal a in restored)
        {
            if (a is Dog dog)
                Console.WriteLine($"Dog: {dog.Name}, гучність: {dog.BarkVolume} dB");
            else if (a is Cat cat)
                Console.WriteLine($"Cat: {cat.Name}, життів: {cat.Lives}");
        }
    }
}