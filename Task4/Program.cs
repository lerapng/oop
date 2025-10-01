using System;
namespace Task4
{
    public class Program
    {
        public static bool IsValidTriangle(double a, double b,
        double c)
        {
            bool isValid;
            if ((a > 0 && b > 0 && c > 0) && ((a + b) > c && (a +
            c) > b && (b + c) > a))
            {
                isValid = true;
            }
            else
            {
                isValid = false;
            }
            return isValid;
        }
        public static double GetPerimeter(double a, double b,
        double c)
        {
            if (IsValidTriangle(a, b, c))
            {
                return a + b + c;
            }
            else
            {
                throw new ArgumentException();
            }
        }
        public static double GetArea(double a, double b, double c)
        {
            if (IsValidTriangle(a, b, c))
            {
                double p = (a + b + c) / 2;
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
            else
            {
                throw new ArgumentException();
            }
        }
        public static string GetTriangleType(double a, double b,
        double c)
        {
            if (IsValidTriangle(a, b, c))
            {
                if (a == b && a == c) return "рівносторонній";
                else if (a == c || a == b || c == b) return
                "рівнобедрений";
                else if ((Math.Pow(a, 2)) + (Math.Pow(b, 2)) ==
                (Math.Pow(c, 2)) || (Math.Pow(c, 2)) + (Math.Pow(b, 2)) ==
                (Math.Pow(a, 2)) || (Math.Pow(a, 2)) + (Math.Pow(c, 2)) ==
                (Math.Pow(b, 2))) return "прямокутний";
                else return "довільний";
            }
            else
            {
                throw new ArgumentException();
            }
        }
        public static void Main(string[] args)
        {
            double a = 10;
            double b = 20;
            double c = 30;
            bool isValidTriangle = Program.IsValidTriangle(a, b,
            c);
            if (isValidTriangle)
            {
                Console.WriteLine($"Периметр трикутника:{GetPerimeter(a, b, c)}");
                Console.WriteLine($"Площа трикутника за формулою Герона: {GetArea(a, b, c)}");
                Console.WriteLine($"Вид трикутника: {GetTriangleType(a, b, c)}");
            }
        }
    }
}