using System;

namespace Task5
{
    public class Program
    {

        public static double GetAverage(int[] marks)
        {
            int numberOfMarks = marks.Length;
            double result = 0;
            double sumAllMarks = 0;

            for (int i = 0; i < numberOfMarks; ++i)
            {
                sumAllMarks += marks[i];
            }

            result = sumAllMarks / numberOfMarks;
            return result;
        }

        public static int GetMin(int[] marks)
        {
            int numberOfMarks = marks.Length;
            int min = marks[0];

            for (int i = 0; i < numberOfMarks; ++i)
            {
                if (min > marks[i])
                {
                    min = marks[i];
                }
            }

            return min;
        }

        public static int GetMax(int[] marks)
        {
            int numberOfMarks = marks.Length;
            int max = marks[0];

            for (int i = 0; i < numberOfMarks; ++i)
            {
                if (max < marks[i])
                {
                    max = marks[i];
                }
            }

            return max;
        }

        public static void PrintGroupStatistics(int[][] groups)
        {
            for (int i = 0; i < groups.Length; ++i)
            {
                double averageMark = GetAverage(groups[i]);
                double minMark = GetMin(groups[i]);
                double maxMark = GetMax(groups[i]);

                Console.WriteLine($"Група {i + 1}: Середній = {averageMark}, Мінімальний = {minMark}, Макстмальний = {maxMark}");
            }
        }

        public static void Main(string[] args)
        {
            int[][] groups = new int[][]
            {
                new int[] { 10, 20, 30, 40, 50 },
                new int[] { 60, 70, 80, 90, 100 },
                new int[] { 110, 120, 130, 140, 150 }
            };

            PrintGroupStatistics(groups);
        }
    }
}
