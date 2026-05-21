using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

class Author
{
    public string Name { get; set; }
    public List<Book> Books { get; set; }
}

class Book
{
    public string Title { get; set; }

    [JsonIgnore]
    public Author Author { get; set; }
}

class Program
{
    static void Main()
    {
        Author author = new Author { Name = "author1", Books = new List<Book>() };

        Book b1 = new Book { Title = "book2", Author = author };
        Book b2 = new Book { Title = "book3", Author = author };
        author.Books.Add(b1);
        author.Books.Add(b2);

        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(author, options);

        Console.WriteLine("JSON");
        Console.WriteLine(json);

        Author restored = JsonSerializer.Deserialize<Author>(json, options);
        Console.WriteLine($"\nАвтор: {restored.Name}");
        foreach (Book b in restored.Books)
            Console.WriteLine($"  Книга: {b.Title}");
    }
}