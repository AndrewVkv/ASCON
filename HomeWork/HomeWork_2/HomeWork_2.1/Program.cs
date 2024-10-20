using System;


namespace HomeWork_2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            uint myArrayLength = 0;
            const uint myArrayLengthMin = 3;
            const uint myArrayLengthMax = 7;
            double sum = 0;

            while (true)
            {
                Console.Clear();
                sum = 0;
                Console.WriteLine($"Укажите длинну массива в диапазоне от { myArrayLengthMin} до { myArrayLengthMax}");
                try
                {
                    myArrayLength = uint.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Не удалось распознать ввод! " + ex.Message);
                }

                if (myArrayLength >= myArrayLengthMax || myArrayLength < myArrayLengthMin) 
                {
                    Console.WriteLine("Ввод противоречит условию");
                    Console.ReadLine();
                    continue;
                }

                double[] myArray = new double[myArrayLength];

                for (int i = 0; i < myArrayLength; i++)
                {
                    Console.WriteLine("Введите число " + (i + 1));
                    try
                    {
                        myArray[i] = double.Parse(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Не удалось распознать ввод! " + ex.Message);
                        continue;
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Среднее арифметическое:");

                for (int i = 0; i < myArray.Length; i++)
                    sum += myArray[i];

                Console.WriteLine(Convert.ToDouble(sum / myArray.Length));
                Console.ReadLine();
            }
        }
    }
}
