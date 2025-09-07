using System;

class Program
{
    static void Main()
    {
        Console.Title = "Temperature Converter - Day 5";
        Console.WriteLine("=== Temperature Converter ===\n");

        while (true)
        {
            Console.WriteLine("Choose conversion:");
            Console.WriteLine("1) Celsius → Fahrenheit");
            Console.WriteLine("2) Fahrenheit → Celsius");
            Console.WriteLine("3) Celsius → Kelvin");
            Console.WriteLine("4) Kelvin → Celsius");
            Console.WriteLine("5) Fahrenheit → Kelvin");
            Console.WriteLine("6) Kelvin → Fahrenheit");
            Console.WriteLine("0) Exit");
            Console.Write("Option: ");

            string? choice = Console.ReadLine();
            if (choice == "0") break;

            Console.Write("Enter value: ");
            string? input = Console.ReadLine();

            if (!double.TryParse(input, out double value))
            {
                Warn("Invalid number. Try again.\n");
                continue;
            }

            double result = choice switch
            {
                "1" => CelsiusToFahrenheit(value),
                "2" => FahrenheitToCelsius(value),
                "3" => CelsiusToKelvin(value),
                "4" => KelvinToCelsius(value),
                "5" => FahrenheitToKelvin(value),
                "6" => KelvinToFahrenheit(value),
                _ => double.NaN
            };

            if (double.IsNaN(result))
                Warn("❌ Invalid option. Try again.\n");
            else
                Notify($"Result = {result:F2}\n");
        }

        Console.WriteLine("Bye! 👋");
    }

    // Conversion methods
    static double CelsiusToFahrenheit(double c) => (c * 9 / 5) + 32;
    static double FahrenheitToCelsius(double f) => (f - 32) * 5 / 9;
    static double CelsiusToKelvin(double c) => c + 273.15;
    static double KelvinToCelsius(double k) => k - 273.15;
    static double FahrenheitToKelvin(double f) => (f - 32) * 5 / 9 + 273.15;
    static double KelvinToFahrenheit(double k) => (k - 273.15) * 9 / 5 + 32;

    // Helpers for colored messages
    static void Warn(string msg) { Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine(msg); Console.ResetColor(); }
    static void Notify(string msg) { Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine(msg); Console.ResetColor(); }
}
