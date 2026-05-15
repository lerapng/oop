class Program
{
    static void Main()
    {
        Func<double, double, double> add = (a, b) => a + b;
        Func<double, double, double> multiply = (a, b) => a * b;

        Console.WriteLine($"5 + 3 = {add(5, 3)}");
        Console.WriteLine($"5 * 3 = {multiply(5, 3)}");

        List<string> students = new List<string> { "Anna", "Bohdan", "Alina", "Vasyl", "Anton", "Mykola" };
        List<string> filtered = students.FindAll(name => name.StartsWith("A"));

        Console.Write("Імена на 'A': ");
        filtered.ForEach(name => Console.Write(name + " "));
        Console.WriteLine();
    }
}