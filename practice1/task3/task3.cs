class Program
{
    delegate bool FilterPredicate(int number);

    static void FilterArray(int[] numbers, FilterPredicate predicate)
    {
        foreach (int n in numbers)
        {
            if (predicate(n))
                Console.Write(n + " ");
        }
        Console.WriteLine();
    }

    static bool IsEven(int n) => n % 2 == 0;
    static bool IsGreaterThanFive(int n) => n > 5;

    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        Console.Write("Парні: ");
        FilterArray(numbers, IsEven);

        Console.Write("Більше 5: ");
        FilterArray(numbers, IsGreaterThanFive);

        Console.Write("Непарні: ");
        FilterArray(numbers, n => n % 2 != 0);
    }
}