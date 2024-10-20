using System;

namespace HomeWork_5._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            int count = 0;
            int number = 1;

            Console.WriteLine("Введите N (номер простого числа):");
            try
            {
                n = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            while (count < n)
            {
                number++;
                if (IsPrime(number))
                    count++;
            }

            Console.WriteLine($"{n}-е простое число: {number}");

        }
        static bool IsPrime(int num)
        {
            if (num < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if(num % i == 0)
                    return false;
            }

            return true;
        }
    }
}
