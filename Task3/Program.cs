using System;

namespace Task3
{
    public class Program
    {
        public static string ClassifyAge(int age)
        {
            string result = "";
            if (age < 0 || age > 120)
            {
                result = "Нереальний вік";
            }
            else if (age < 12)
            {
                result = "Ви дитина";
            }
            else if (12 <= age && age <= 17)
            {
                result = "Підліток";
            }
            else if (18 <= age && age <= 59)
            {
                result = "Дорослий";
            }
            else if (60 <= age && age <= 120)
            {
                result = "Пенсіонер";
            }

            return result;
        }

        public static int ReadLineToInt()
        {
            string str;
            str = Console.ReadLine();
            return Int32.Parse(str);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Введіть ваш вік:");
            int age = ReadLineToInt();

            Console.WriteLine(ClassifyAge(age));
        }
    }
}
