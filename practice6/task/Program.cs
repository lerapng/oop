using System;
using System.Threading;

class Program
{
    static int _counter = 0;
    static bool _paused = false;
    static bool _running = true;

    static readonly object _lock = new object();

    static ConsoleColor[] _colors = {
        ConsoleColor.White,
        ConsoleColor.Cyan,
        ConsoleColor.Green,
        ConsoleColor.Yellow,
        ConsoleColor.Magenta
    };
    static int _colorIndex = 0;

    static void Main()
    {
        Console.WriteLine("Запущено. P=пауза  R=скинути  C=колір  Q=вихід\n");

        Thread keyThread = new Thread(KeyHandler)
        {
            IsBackground = true,
            Name = "KeyHandlerThread"
        };
        keyThread.Start();

        while (true)
        {
            bool shouldRun;
            lock (_lock) shouldRun = _running;
            if (!shouldRun) break;

            bool paused;
            lock (_lock) paused = _paused;

            if (!paused)
            {
                int current;
                lock (_lock)
                {
                    _counter++;
                    current = _counter;
                }

                ConsoleColor color;
                lock (_lock) color = _colors[_colorIndex];

                Console.ForegroundColor = color;
                Console.WriteLine($"Counter: {current}");
                Console.ResetColor();
            }

            Thread.Sleep(1000);
        }

        Console.ResetColor();
        Console.WriteLine("\nПрограму завершено.");
    }

    static void KeyHandler()
    {
        while (true)
        {
            bool shouldRun;
            lock (_lock) shouldRun = _running;
            if (!shouldRun) break;

            if (!Console.KeyAvailable)
            {
                Thread.Sleep(50);
                continue;
            }

            ConsoleKey key = Console.ReadKey(intercept: true).Key;

            switch (key)
            {
                case ConsoleKey.P:
                    lock (_lock) _paused = !_paused;
                    bool isPaused;
                    lock (_lock) isPaused = _paused;
                    Console.WriteLine(isPaused ? "[ПАУЗА]" : "[ПРОДОВЖЕННЯ]");
                    break;

                case ConsoleKey.R:
                    lock (_lock) _counter = 0;
                    Console.WriteLine("[СКИНУТО]");
                    break;

                case ConsoleKey.C:
                    lock (_lock) _colorIndex = (_colorIndex + 1) % _colors.Length;
                    ConsoleColor next;
                    lock (_lock) next = _colors[_colorIndex];
                    Console.WriteLine($"[КОЛІР: {next}]");
                    break;

                case ConsoleKey.Q:
                    lock (_lock) _running = false;
                    return;
            }
        }
    }
}