class Logger
{
    public Action<string> LogHandler;
 
    public void Log(string message)
    {
        if (LogHandler != null)
            LogHandler(message);
    }
}
 
class Program
{
    static void Main()
    {
        Logger logger = new Logger();
        logger.LogHandler = message => Console.WriteLine($"[LOG]: {message}");
 
        logger.Log("Програма запущена");
        logger.Log("З'єднання встановлено");
 
        logger.LogHandler = message => Console.WriteLine($"[LOG]: {message.ToUpper()}");
 
        logger.Log("Режим змінено");
        logger.Log("Новий запис");
    }
}