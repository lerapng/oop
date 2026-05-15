namespace practice1
{
    class Program
    {
        delegate void NotificationHandler(string message);

        static void SendEmail(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }

        static void SendSMS(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }

        static void Main()
        {
            NotificationHandler handler = null;
            handler += SendEmail;
            handler += SendSMS;

            handler("Your order has been confirmed!");
        }
    }
}