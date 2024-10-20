using System;

namespace HomeWork_2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const uint personsQuantityMin = 3;
            const uint personsQuantityMax = 5;

            string[] personMetadata = { "Фамилия", "Имя", "Отчество" };
            uint personsQuantity = 0;
            uint personNumber = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Введите количество человек от {personsQuantityMin} до {personsQuantityMax}");
                Console.WriteLine();

                try
                {
                    personsQuantity = uint.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Не удалось преобразовать в целое положительное число. " + ex.Message);
                    Console.ReadLine();
                    continue;
                }

                if (personsQuantity > personsQuantityMax || personsQuantity < personsQuantityMin)
                {
                    Console.WriteLine("Ввод противоречит условию");
                    Console.ReadLine();
                    continue;
                }

                string[][] personsArray = new string[personsQuantity][];

                for (int i = 0; i < personsArray.Length; i++)
                {
                    Console.WriteLine($"Человек {(i + 1)}");
                    personsArray[i] = new string[personMetadata.Length];

                    for (int j = 0; j < personsArray[i].Length; j++)
                    {
                        Console.WriteLine($"Введите {personMetadata[j]}");
                        personsArray[i][j] = Console.ReadLine();
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("Введите порядковый номер человека");
                try
                {
                    personNumber = uint.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Не удалось преобразовать в целое положительное число. " + ex.Message);
                    Console.ReadLine();
                    continue;
                }

                Console.WriteLine();
                Console.WriteLine("Информация о человеке");
                for (int i = 0; i < personsArray[personNumber - 1].Length; i++)
                {
                    Console.WriteLine(personMetadata[i] + ": \t" + personsArray[personNumber - 1][i]);
                }
                Console.ReadLine();
            }
        }
    }
}
