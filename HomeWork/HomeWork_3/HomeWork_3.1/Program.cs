using System;

namespace HomeWork_3._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double [] myArray = new double[2];
            int count = 0;
            int errors = 0;
            bool programIsRunning = true;
            bool choosing = false;

            while (programIsRunning)
            {
                Console.WriteLine("Введите число");
                var input = Console.ReadLine();

                if (input == "q" || input == "Q") 
                {
                    Console.WriteLine();
                    Console.WriteLine("Введенные данные");

                    for (int i = 0; i < count; i++)
                        Console.WriteLine(myArray[i]);

                    choosing = true;
                    while (choosing)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Выберите действие:");
                        Console.WriteLine("Введите 1, чтобы продолжить");
                        Console.WriteLine("Введите 2, чтобы очистить данные");
                        Console.WriteLine("Введите 3, чтобы выйти");
                        Console.WriteLine();

                        var action = Console.ReadLine();

                        if (action == "1")
                        {
                            Console.WriteLine("Продолжаем ввод чисел");
                            choosing = false;
                        }
                        else if (action == "2")
                        {
                            myArray = new double[2];
                            count = 0;
                            errors = 0;
                            Console.WriteLine("Массив очищен");
                            continue;
                        }
                        else if (action == "3")
                        {
                            Console.WriteLine("Завершение программы");
                            Console.WriteLine("Вы ввели " + count + " элементов");
                            Console.WriteLine("Количество ошибок: " + errors);
                            choosing = false;
                            programIsRunning = false;
                        }
                        else
                        {
                            Console.WriteLine("Не удалось распознать ввод");
                            errors++;
                        }

                    }
                }
                else
                {
                    try
                    {
                        double number = double.Parse(input);

                        if (count >= myArray.Length)
                        {
                            double[] newMyArray = new double[myArray.Length * 2];

                            for (int i = 0; i < myArray.Length; i++)
                                newMyArray[i] = myArray[i];

                            myArray = newMyArray;
                        }

                        myArray[count] = number;
                        count++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        errors++;
                    }
                }

            }
        }
    }
}
