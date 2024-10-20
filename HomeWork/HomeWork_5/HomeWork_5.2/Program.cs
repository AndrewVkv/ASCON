using System;

namespace HomeWork_5._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string chooseAction = "Выберите действие:";
            const string feedChicken = "1 - Покормить курицу";
            const string takeEgg = "2 - Забрать яйцо";
            const string doNothing = "3 - Ничего не делать";

            bool chickenIsFed = false;
            bool eggAvailable = false;
            bool isAlive = true;

            Random random = new Random();

            Console.WriteLine("Курица голодная");
            Console.WriteLine();

            while (isAlive)
            {
                Console.WriteLine(chooseAction);
                Console.WriteLine(feedChicken);
                Console.WriteLine(takeEgg);
                Console.WriteLine(doNothing);

                var input = Console.ReadLine();

                if (input == "1")
                {
                    int grains = random.Next(3, 6);
                    Console.WriteLine($"Курица получила {grains} зерен.");

                    chickenIsFed = true;
                    eggAvailable = true;
                    Console.WriteLine("Курица накормлена и высидела яйцо.");
                }
                else if (input == "2")
                {
                    if (eggAvailable)
                    {
                        Console.WriteLine("Вы забрали яйцо.");
                        eggAvailable = false;
                        chickenIsFed = false;
                    }
                    else
                        Console.WriteLine("Нет яйца для забора.");

                }
                else if (input == "3")
                {
                    if (!chickenIsFed)
                    {
                        Console.WriteLine("Курица умерла от голода.");
                        isAlive = false;
                    }
                    else
                    {
                        chickenIsFed = false; // Курица проголодалась
                        Console.WriteLine("Курица высидела яйцо.");
                    }
                }
                else
                {
                    Console.WriteLine("Не удалось распознать ввод, повторите попытку.");
                }

                Console.WriteLine();
            }
        }
    }
}
