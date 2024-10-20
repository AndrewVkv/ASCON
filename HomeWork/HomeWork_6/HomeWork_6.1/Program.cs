using System;

namespace HomeWork_6._1
{
    enum ChickenState
    {
        ГолоднаяБезЯйца,
        ГолоднаяСЯйцом,
        СытаяБезЯйца,
        СытаяСЯйцом,
        Мертва
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] titleArray = { "Выберите действие:", "1 - Покормить курицу", "2 - Забрать яйцо", "3 - Ничего не делать" };
            Random random = new Random();

            int quantity = 3;
            int aliveChickens = quantity;

            ChickenState[] chickens = new ChickenState[quantity];
            for (int i = 0; i < chickens.Length; i++)
            {
                chickens[i] = ChickenState.ГолоднаяБезЯйца;
            }

            while (aliveChickens > 0)
            {
                aliveChickens = quantity;
                for (int i = 0; i < chickens.Length; i++)
                {
                    Console.WriteLine($"Курица {i + 1}: " + chickens[i]);

                    if (chickens[i] == ChickenState.Мертва)
                        aliveChickens--;
                }

                for (int i = 0; i < chickens.Length; i++)
                {
                    if (chickens[i] == ChickenState.Мертва)
                        continue;

                    Console.WriteLine($"\nДля куры #{i + 1}");
                    ShowTitle(titleArray);

                    Console.WriteLine();
                    var input = Console.ReadLine();
                    Console.WriteLine();

                    if (input == "1")
                    {
                        chickens[i] = ChickenState.СытаяСЯйцом;
                        Console.WriteLine("Покормил");
                    }
                    else if (input == "2")
                    {
                        if (chickens[i] == ChickenState.СытаяСЯйцом)
                        {
                            chickens[i] = ChickenState.ГолоднаяБезЯйца;
                            Console.WriteLine("Забрал яйцо");
                        }
                        else if (chickens[i] == ChickenState.ГолоднаяСЯйцом)
                        {
                            chickens[i] = ChickenState.ГолоднаяБезЯйца;
                            Console.WriteLine("Забрал яйцо");
                        }
                        else 
                        {
                            Console.WriteLine("Яйца нет");
                            i--;
                        }
                    }
                    else if (input == "3")
                    {
                        if (chickens[i] == ChickenState.ГолоднаяСЯйцом || chickens[i] == ChickenState.ГолоднаяБезЯйца)
                        {
                            chickens[i] = ChickenState.Мертва;
                            Console.WriteLine($"Кура {i + 1} умерла");
                            Console.WriteLine();
                        }
                        else if (chickens[i] == ChickenState.СытаяСЯйцом)
                        {
                            chickens[i] = ChickenState.ГолоднаяСЯйцом;
                        }
                        else if (chickens[i] == ChickenState.СытаяБезЯйца)
                        {
                            chickens[i] = ChickenState.ГолоднаяБезЯйца;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ввод не распознан");
                        i--;
                    }
                }
            }

            void ShowTitle(string[] myArray)
            {
                for (int i = 0; i < myArray.Length; i++)
                {
                    Console.WriteLine(myArray[i]);
                }
            }

        }
    }
}
