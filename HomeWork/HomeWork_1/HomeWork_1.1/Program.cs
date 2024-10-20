using System;

namespace HomeWork_1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name, surname, patronymic;

            Console.WriteLine("Введите имя");
            name = Console.ReadLine();

            Console.WriteLine("Введите фамилию");
            surname = Console.ReadLine();

            Console.WriteLine("Введите отчество");
            patronymic = Console.ReadLine();

            Console.WriteLine("ФИО: " + surname + " " + name + " " + patronymic + " ");
        }
    }
}
