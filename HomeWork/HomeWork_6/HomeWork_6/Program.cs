using System;

namespace HomeWork_6
{
    enum VitalSign
    {
        Alive,
        Dead
    }
    enum ChickenFeedState
    {
        Hungry,
        Full
    }
    enum EggState
    {
        NotReady,
        ReadyToPickUp
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] titleArray = { "Выберите действие:", "1 - Покормить курицу", "2 - Забрать яйцо", "3 - Ничего не делать" };

            Random random = new Random();
            VitalSign vitalSign = VitalSign.Alive;
            ChickenFeedState chickenFeedState = ChickenFeedState.Hungry;
            EggState eggState = EggState.NotReady;


            while (vitalSign == VitalSign.Alive)
            {
                PrintChickenState();
                ShowTitle(titleArray);

                Console.WriteLine();
                var input = Console.ReadLine();
                Console.WriteLine();

                if (input == "1")
                {
                    int grains = random.Next(3, 6);
                    Console.WriteLine($"Курица получила {grains} зерен.");

                    chickenFeedState = ChickenFeedState.Full;
                    eggState = EggState.ReadyToPickUp;
                }
                else if (input == "2")
                {
                    if (eggState == EggState.ReadyToPickUp)
                    {
                        Console.WriteLine("Вы забрали яйцо.");
                        eggState = EggState.NotReady;
                        chickenFeedState = ChickenFeedState.Hungry;
                    }
                    else
                        Console.WriteLine("Нет яйца для забора.");

                }
                else if (input == "3")
                {
                    if (chickenFeedState == ChickenFeedState.Hungry)
                    {
                        vitalSign = VitalSign.Dead;
                        Console.WriteLine("Курица умерла от голода.");
                    }
                    else
                        chickenFeedState = ChickenFeedState.Hungry; // Курица проголодалась  
                }
                else
                    Console.WriteLine("Не удалось распознать ввод, повторите попытку.");


                Console.WriteLine();
            }

            void ShowTitle(string[] myArray)
            {
                for (int i = 0; i < myArray.Length; i++)
                {
                    Console.WriteLine(myArray[i]);
                }
            }

            void PrintChickenFeedState()
            {
                Console.Write(chickenFeedState == ChickenFeedState.Full ? "Курица сытая, " : "Курица голодная, ");
            }

            void PrintEggState()
            {
                Console.Write(eggState == EggState.ReadyToPickUp ? "можно забрать яйцо \n \n" : "нет яйца для забора \n \n");
            }

            void PrintChickenState()
            {
                PrintChickenFeedState();
                PrintEggState();
            }
        }
    }
}
