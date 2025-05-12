using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Консольний калькулятор ===");
            Console.WriteLine("1 — Десятковий калькулятор");
            Console.WriteLine("2 — Двійковий калькулятор");
            Console.WriteLine("Q — Вийти");
            Console.Write("Ваш вибір: ");
            string input = Console.ReadLine()?.Trim().ToUpper();

            if (input == "Q")
                break;

            ICalculator calculator = input switch
            {
                "1" => new DecimalCalculator(),
                "2" => new BinaryCalculator(),
                _ => null
            };

            if (calculator != null)
            {
                calculator.Run();
            }
            else
            {
                Console.WriteLine("Невірний вибір. Натисніть будь-яку клавішу...");
                Console.ReadKey();
            }
        }
    }
}

interface ICalculator
{
    void Run();
}

class DecimalCalculator : ICalculator
{
    public void Run()
    {
        Console.Clear();
        Console.WriteLine("=== Десятковий калькулятор ===");

        Console.Write("Введіть перше число: ");
        if (!double.TryParse(Console.ReadLine(), out double num1))
        {
            Console.WriteLine("Некоректний ввід. Спробуйте ще раз.");
            Console.ReadKey();
            return;
        }

        Console.Write("Введіть оператор (+, -, *, /): ");
        char op = Console.ReadKey().KeyChar;
        Console.WriteLine();

        Console.Write("Введіть друге число: ");
        if (!double.TryParse(Console.ReadLine(), out double num2))
        {
            Console.WriteLine("Некоректний ввід. Спробуйте ще раз.");
            Console.ReadKey();
            return;
        }

        double result = 0;
        bool validOperation = true;

        switch (op)
        {
            case '+': result = num1 + num2; break;
            case '-': result = num1 - num2; break;
            case '*': result = num1 * num2; break;
            case '/':
                if (num2 == 0)
                {
                    Console.WriteLine("Помилка: ділення на нуль.");
                    validOperation = false;
                }
                else
                    result = num1 / num2;
                break;
            default:
                Console.WriteLine("Невідомий оператор.");
                validOperation = false;
                break;
        }

        if (validOperation)
        {
            Console.WriteLine($"Результат: {result}");
        }

        Console.WriteLine("Натисніть будь-яку клавішу для повернення в меню...");
        Console.ReadKey();
    }
}

class BinaryCalculator : ICalculator
{
    public void Run()
    {
        Console.Clear();
        Console.WriteLine("=== Двійковий калькулятор ===");

        Console.Write("Введіть перше двійкове число: ");
        string bin1 = Console.ReadLine();

        Console.Write("Введіть оператор (+, -, *, /): ");
        char op = Console.ReadKey().KeyChar;
        Console.WriteLine();

        Console.Write("Введіть друге двійкове число: ");
        string bin2 = Console.ReadLine();

        try
        {
            int num1 = Convert.ToInt32(bin1, 2);
            int num2 = Convert.ToInt32(bin2, 2);
            int result = 0;

            switch (op)
            {
                case '+': result = num1 + num2; break;
                case '-': result = num1 - num2; break;
                case '*': result = num1 * num2; break;
                case '/':
                    if (num2 == 0)
                    {
                        Console.WriteLine("Помилка: ділення на нуль.");
                        return;
                    }
                    result = num1 / num2; break;
                default:
                    Console.WriteLine("Невідомий оператор.");
                    return;
            }

            string binaryResult = Convert.ToString(result, 2);
            Console.WriteLine($"Результат у двійковій системі: {binaryResult}");
        }
        catch
        {
            Console.WriteLine("Помилка вводу. Перевірте двійкові значення.");
        }

        Console.WriteLine("Натисніть будь-яку клавішу для повернення в меню...");
        Console.ReadKey();
    }
}
