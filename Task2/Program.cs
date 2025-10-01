namespace Task2
{
    public class Program
    {
        public static int[] GenerateRandomArray(int size, int min, int max)
        {
            Random rand = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(min, max + 1);
            }
            return array;
        }

        public static int GetSum(int[] numbers)
        {
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }
            return sum;
        }

        public static double GetAverage(int[] numbers)
        {
            return (double)GetSum(numbers) / numbers.Length;
        }

        public static int GetMin(int[] numbers)
        {
            int min = numbers[0];
            foreach (int num in numbers)
            {
                if (num < min) min = num;
            }
            return min;
        }

        public static int GetMax(int[] numbers)
        {
            int max = numbers[0];
            foreach (int num in numbers)
            {
                if (num > max) max = num;
            }
            return max;

        }
        static void Main(string[] args)
        {

        }
    }
}
