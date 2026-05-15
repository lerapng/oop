namespace practice1
{
    class Program
    {
        public delegate double MathOperation(double a, double b);
        public static double Add(double a, double b)
        {
            return a + b;
        }
        public static double Subtract(double a, double b)
        {
            return a - b;
        }
        public static double Multiply(double a, double b)
        {
            return a * b;
        }
        public static double Divide(double a, double b)
        {
            return a / b;
        }
        static void Main(string[] args)
        {
            MathOperation operation = Add;
            Console.WriteLine(operation(3, 5));

            operation = Subtract;
            Console.WriteLine(operation(10, 2));

            operation = Multiply;
            Console.WriteLine(operation(5, 2));

            operation = Divide;
            Console.WriteLine(operation(16, 4));
        }
    }
}