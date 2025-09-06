using System;
class Calculator
{
    static double tek = 0;
    static double data = 0;
    static void Main()
    {
        Console.WriteLine("=== КАЛЬКУЛЯТОР ===");
        pamyatka();
        while (true)
        {
            Console.WriteLine($"\nТекущее: {tek}");
            Console.WriteLine($"Память: {data}");
            Console.Write("Введите команду: ");
            string input = Console.ReadLine().ToLower();
            if (input == "выход") break;
            if (input == "help") { pamyatka(); continue; }
            
            deystvie(input);
        }
    }
    // Памятка с командами
    static void pamyatka()
    {
        Console.WriteLine("\nКОМАНДЫ:");
        Console.WriteLine("число - установить значение");
        Console.WriteLine("+ - сложение");
        Console.WriteLine("- - вычитание"); 
        Console.WriteLine("* - умножение");
        Console.WriteLine("/ - деление");
        Console.WriteLine("sqrt - квадратный корень");
        Console.WriteLine("sqr - квадрат числа");
        Console.WriteLine("1/ - 1/x");
        Console.WriteLine("m+ - добавить в память");
        Console.WriteLine("m- - вычесть из памяти");
        Console.WriteLine("mr - восстановить из памяти");
        Console.WriteLine("mc - очистить память");
        Console.WriteLine("очистить - очистить память");
        Console.WriteLine("help - показать памятку");
        Console.WriteLine("выход - выход из программы");
    }
    // Функция для действия
    static void deystvie(string s)
    {
        try
        {
            // Обработка чисел
            if (double.TryParse(s, out double num))
            {
                tek = num;
                return;
            }
            
            // Обработка команд
            switch (s)
            {
                case "+": 
                    Console.Write("Введите второе число: ");
                    if (double.TryParse(Console.ReadLine(), out double plusnum))
                        tek += plusnum;
                    break;
                    
                case "-":
                    Console.Write("Введите второе число: ");
                    if (double.TryParse(Console.ReadLine(), out double minusnum))
                        tek -= minusnum;
                    break;
                    
                case "*":
                    Console.Write("Введите второе число: ");
                    if (double.TryParse(Console.ReadLine(), out double umnnum))
                        tek *= umnnum;
                    break;
                    
                case "/":
                    Console.Write("Введите второе число: ");
                    if (double.TryParse(Console.ReadLine(), out double delnum))
                    {
                        if (delnum == 0) throw new Exception("Деление на ноль!");
                        tek /= delnum;
                    }
                    break;
                    
                case "sqrt":
                    if (tek < 0) throw new Exception("Отрицательное подкорневое выражение!");
                    tek = Math.Sqrt(tek);
                    break;
                    
                case "sqr":
                    tek = tek * tek;
                    break;
                    
                case "1/":
                    if (tek == 0) throw new Exception("Деление на ноль!");
                    tek = 1 / tek;
                    break;
                    
                case "m+":
                    data += tek;
                    Console.WriteLine($"Добавлено в память: {tek}");
                    break;
                    
                case "m-":
                    data -= tek;
                    Console.WriteLine($"Вычтено из памяти: {tek}");
                    break;
                    
                case "mr":
                    tek = data;
                    Console.WriteLine($"Восстановлено из памяти: {data}");
                    break;
                    
                case "mc":
                    data = 0;
                    Console.WriteLine("Память очищена");
                    break;
                    
                case "очистить":
                    tek = 0;
                    data = 0;
                    Console.WriteLine("Все очищено");
                    break;
                    
                default:
                    Console.WriteLine("Неизвестная команда! Введите 'help' для справки");
                    break;
            }
            
            // Проверка на бесконечность
            if (Math.Abs(tek) > 999999999)
            {
                Console.WriteLine("Бесконечность!");
                tek = 0;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка: {e.Message}");
            tek = 0;
        }
    }
}