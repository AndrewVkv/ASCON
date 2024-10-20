namespace HomeWork_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool repeatInput = true;

            string userInput = string.Empty;
            string fileLocation = string.Empty;
            string fileName = string.Empty;
            string path = string.Empty;

            Console.WriteLine("Работа с файлами \n");

            while (repeatInput)
            {
                Console.WriteLine("Выберите действие: \n 1-Записать в файл. \n 2-Прочитать из файла. \n 3-Дописать в файл \n 4-Очистить консоль \n 5-Выход");
                userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    WriteToFile(ref fileName, ref fileLocation, ref userInput, ref path, ref repeatInput);
                }
                else if (userInput == "2")
                {
                    ReadFromFile(ref path);
                }
                else if (userInput == "3")
                {
                    AppendToFile(ref path);
                }
                else if (userInput == "4")
                    Console.Clear();
                else if (userInput == "5")
                    Environment.Exit(0);
                else
                    Console.WriteLine($"Не удалось распознать, повторите ввод \n");
            }
        }

        /// <summary>
        /// Ввод имени файла и его расположения
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="location">Расположение</param>
        static void InputNameAndLocation(ref string name, ref string location)
        {
            bool repeatLocation = true;
            while (repeatLocation)
            {
                Console.WriteLine(@"Укажите расположение в формате: D:\NewFolder");
                location = Console.ReadLine();

                if (Directory.Exists(location))
                    repeatLocation = !repeatLocation;
                else
                    Console.WriteLine("Расположение не найдено");

                Console.WriteLine("Введите имя файла: ");
                name = Console.ReadLine();
            }
        }
        /// <summary>
        /// Запись в файл
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <param name="fileLocation">Расположение</param>
        /// <param name="userInput">Ввод пользователя</param>
        /// <param name="path">Путь к файлу</param>
        /// <param name="repeatInput">Повтор ввода</param>
        static void WriteToFile(ref string fileName, ref string fileLocation, ref string userInput, ref string path, ref bool repeatInput) 
        {
            InputNameAndLocation(ref fileName, ref fileLocation);

            Console.WriteLine("Напишите текст, чтобы сохранить в файл");
            userInput = Console.ReadLine();

            path = $@"{fileLocation}\{fileName}.txt";

            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(userInput);
                }
            }
            else
            {
                Console.WriteLine("Файл с таким именем уже существует.");

                bool repeatTempInput = true;
                while (repeatTempInput)
                {
                    Console.WriteLine("Выберите действие: \n 1-Перезаписать файл. \n 2-Отменить");
                    string tempInput = Console.ReadLine();
                    if (tempInput == "1")
                    {
                        using (StreamWriter sw = new StreamWriter(path))
                        {
                            sw.WriteLine(userInput, true);
                        }
                        repeatTempInput = !repeatTempInput;
                    }
                    else if (tempInput == "2")
                    {
                        Console.WriteLine("Отмена");
                        repeatTempInput = !repeatTempInput;
                        repeatInput = true;
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Не удалось распознать ввод.");
                    }
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Чтение из файла
        /// </summary>
        /// <param name="path">путь к файлк</param>
        static void ReadFromFile(ref string path) 
        {
            bool repeatTempInput = true;
            while (repeatTempInput)
            {
                Console.WriteLine(@"Укажите расположение в формате: D:\NewFolder");
                string location = Console.ReadLine();

                if (Directory.Exists(location))
                {
                    repeatTempInput = !repeatTempInput;
                    string[] files = Directory.GetFiles(location);

                    if (files.Length == 0)
                    {
                        Console.WriteLine("\n Отсутствуют файлы в заданном расположении \n");
                        break;
                    }

                    Console.WriteLine("\nСписок файлов:");
                    for (int i = 0; i < files.Length; i++)
                    {
                        Console.WriteLine($"{i}-{files[i]}");
                    }

                    Console.WriteLine();
                    bool repeatFileNumber = true;

                    while (repeatFileNumber)
                    {
                        Console.WriteLine("Укажите номер файла:");

                        string fileNumberInput = Console.ReadLine();
                        int fileNumber = 0;
                        try
                        {
                            fileNumber = int.Parse(fileNumberInput);
                            Console.WriteLine(files[fileNumber]);
                            repeatFileNumber = !repeatFileNumber;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            continue;
                        }
                        path = files[fileNumber];

                        using (StreamReader sr = new StreamReader(path))
                        {
                            Console.WriteLine("\nИнформация из файла:");
                            while (!sr.EndOfStream)
                            {
                                Console.WriteLine(sr.ReadLine());
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Дописать в файл
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        static void AppendToFile(ref string path) 
        {
            bool repeatLocation = true;
            while (repeatLocation)
            {
                Console.WriteLine(@"Укажите расположение в формате: D:\NewFolder");
                string location = Console.ReadLine();

                if (Directory.Exists(location))
                {
                    repeatLocation = !repeatLocation;

                    string[] files = Directory.GetFiles(location);

                    if (files.Length == 0)
                    {
                        Console.WriteLine("\n Отсутствуют файлы в заданном расположении \n");
                        break;
                    }

                    Console.WriteLine("\nСписок файлов:");
                    for (int i = 0; i < files.Length; i++)
                    {
                        Console.WriteLine($"{i}-{files[i]}");
                    }

                    Console.WriteLine();

                    bool repeatFileNumber = true;
                    while (repeatFileNumber)
                    {
                        Console.WriteLine("Укажите номер файла:");

                        string fileNumberInput = Console.ReadLine();
                        int fileNumber = 0;
                        try
                        {
                            fileNumber = int.Parse(fileNumberInput);
                            Console.WriteLine(files[fileNumber]);
                            repeatFileNumber = !repeatFileNumber;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            continue;
                        }
                        path = files[fileNumber];

                        Console.WriteLine("Допишите информацию:");
                        string appendString = Console.ReadLine();
                        using (StreamWriter sw = new StreamWriter(path, true))
                        {
                            sw.WriteLine(appendString);
                        }
                    }
                    Console.WriteLine();
                }
                else
                    Console.WriteLine("Расположение не найдено");
            }
        }
    }
}


