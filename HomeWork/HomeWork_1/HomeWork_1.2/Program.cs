using System;

namespace HomeWork_1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                double firstValue = 0, secondValue = 0, result = 0;
                string action;

                try
                {
                    Console.WriteLine("Введите число 1");
                    firstValue = double.Parse(Console.ReadLine());

                    Console.WriteLine("Введите число 2");
                    secondValue = double.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Не удалось распознать число!" + ex.Message);
                    Console.ReadLine();
                    continue;
                }

                Console.WriteLine("Введите вычислительную операцию (+, -, *, /)");
                action = Console.ReadLine();

                switch (action)
                {
                    case "+":
                        result = firstValue + secondValue;
                        Console.WriteLine("Результат: " + result);
                        break;

                    case "-":
                        result = firstValue - secondValue;
                        Console.WriteLine("Результат: " + result);
                        break;

                    case "*":
                        result = firstValue * secondValue;
                        Console.WriteLine("Результат: " + result);
                        break;

                    case "/":
                        if (secondValue == 0)
                            Console.WriteLine("На 0 делить нельзя!");
                        else
                        {
                            result = firstValue / secondValue;
                            Console.WriteLine("Результат: " + result);
                        }
                        break;

                    default:
                        Console.WriteLine("Не удалось распознать операцию!");
                        break;
                }
                Console.ReadLine();
            }
        }
    }
}
