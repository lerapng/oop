using System;

class TemperatureChangedEventArgs : EventArgs
{
    public double Temperature { get; }
    public TemperatureChangedEventArgs(double temperature) => Temperature = temperature;
}

class TemperatureSensor
{
    public event EventHandler<TemperatureChangedEventArgs> TemperatureChanged;

    private double _temperature;
    public double Temperature
    {
        get => _temperature;
        set
        {
            _temperature = value;
            TemperatureChanged?.Invoke(this, new TemperatureChangedEventArgs(_temperature));
        }
    }
}

class Display
{
    public void OnTemperatureChanged(object sender, TemperatureChangedEventArgs e)
    {
        Console.WriteLine($"[Display] Поточна температура: {e.Temperature}°C");
    }
}

class AirConditioner
{
    public void OnTemperatureChanged(object sender, TemperatureChangedEventArgs e)
    {
        if (e.Temperature < 17)
            Console.WriteLine("[AirConditioner] Увімкнено обігрів");
        else if (e.Temperature > 25)
            Console.WriteLine("[AirConditioner] Увімкнено охолодження");
        else
            Console.WriteLine("[AirConditioner] Вимкнений");
    }
}

class SecuritySystem
{
    public void OnTemperatureChanged(object sender, TemperatureChangedEventArgs e)
    {
        if (e.Temperature > 40)
            Console.WriteLine("[SecuritySystem] Небезпечний перегрів!");
        else if (e.Temperature < 5)
            Console.WriteLine("[SecuritySystem] Ризик замерзання систем!");
    }
}

class Program
{
    static void Main()
    {
        TemperatureSensor sensor = new TemperatureSensor();
        Display display = new Display();
        AirConditioner ac = new AirConditioner();
        SecuritySystem security = new SecuritySystem();

        sensor.TemperatureChanged += display.OnTemperatureChanged;
        sensor.TemperatureChanged += ac.OnTemperatureChanged;
        sensor.TemperatureChanged += security.OnTemperatureChanged;

        double[] temperatures = { 22, 10, 3, 30, 45, 18 };

        foreach (double temp in temperatures)
        {
            Console.WriteLine($"\nВстановлюємо температуру: {temp}°C");
            sensor.Temperature = temp;
        }
    }
}