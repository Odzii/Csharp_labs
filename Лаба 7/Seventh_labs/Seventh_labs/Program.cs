using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace SeventhLabs
{
    internal class Program
    {
        // Обработка ввода, если пользователь ввел значение не целочисленного типа, то вывести информацию об этом
        static int ReadInputInteger(int startCom, int endCom)
        {            
            while (true)
            {
                Console.Write("Введите число из меню, для выбора задания: ");
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input < startCom || input > endCom)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введите от {0} до {1}", startCom, endCom);
                        Console.ResetColor();
                    }
                    else return input;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка, необходимо целое число");
                    Console.ResetColor();
                    continue;
                }
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                int caseValue;

                Console.WriteLine("1. Задание №1 - Структуры."
                    + "\n2. Задание №2 - Файлы;"
                    + "\n3. Очистить;"
                    + "\n4. Выход из программы."
                    );
                caseValue = ReadInputInteger(1, 4);

                switch (caseValue)
                {
                    case 1:

                        /*
                        Дана структура, задающая дату вида: 
                        struct date 
                        {
                        int day; 
                        int month; 
                        int year;
                        }; 
                        Пользуясь таким структурным типом, составить программу, определяющую: 
                        а) дату следующего (относительно сегодняшнего) дня,
                         */                        
                        // Ввод от пользователя
                        Console.Write("Введите день: ");
                        int.TryParse(Console.ReadLine(), out int d);
                        Console.Write("Введите месяц: ");
                        int.TryParse(Console.ReadLine(), out int m);
                        Console.Write("Введите год: ");
                        int.TryParse(Console.ReadLine(), out int y);
                        //  Вызов структуры
                        Date get_date = new Date(d, m, y);
                        get_date.Print();
                        break;

                    case 2:
                        //  Задание 2
                        // Дана структура с именем MARSH, содержащая следующие поля:
                        // Название начального пункта назначения. 
                        // Название конечного пункта назначения. 
                        // Номер маршрута. 
                        // Написать программу, которая выполняет следующие действия:
                        // Ввод с клавиатуры данных в массив, состоящий из 8 элементов типа MARSH, и занесение их в файл данных. 
                        // Чтение данных из файла и вывод их на экран.
                        // Вывод на экран информации о маршруте, номер которого введен с клавиатуры(если таких нет — вывести об этом сообщение). 
                        // Список должен быть упорядочен по номерам маршрутов.

                        int count;
                        int LEN = 3;  // Количество маршрутов
                        Marsh[] massiv = Marsh.Create(LEN);
                        string path = "marsh.txt"; // Имя и тип файлу куда писать маршруты и остановки                        
                        Marsh.CreateFileMarsh(path);
                        Marsh.AllMarsh(massiv, path);
                        // Читаем содержимое файла
                        Console.WriteLine("Содержимое:");
                        string text = File.ReadAllText(path);
                        Console.WriteLine(text);
                        // Открываем файл через блокнот
                        Process.Start("notepad.exe", path);

                        // Заполняем файл текстом из файла path
                        string[] strings = text.Split(new char[] { '\n' });
                        var pattern = @"^N№\s*(?<route>\d+)\s+от\s+(?<from>.+?)\s+до\s+(?<to>.+)$";
                        var rx = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
                        count = 0;
                        foreach (string value in strings)
                        {
                            var match = rx.Match(value);
                            string from = match.Groups["from"].Value.Trim();
                            string to = match.Groups["to"].Value.Trim();
                            string route = match.Groups["route"].Value.Trim();
                            Marsh object_marsh = new Marsh(from, to, int.Parse(route));
                            massiv[count] = object_marsh;
                            count++;
                        }
                        // Сортировка массива
                        massiv = Marsh.SortMarsh(massiv, true);
                        Marsh.PrintAll(massiv);
                        // Поиск маршрутов по остановкам
                        while(true)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine("\nЧтобы выйти введите <stop> со скобками");
                            Console.ResetColor();
                            Console.Write("Введите остановку: ");
                            string input = Console.ReadLine();
                            bool flag = input == "<stop>";
                            count = 0;
                            if (!flag)
                            {
                                for (int i = 0; i < LEN; i++)
                                {
                                    bool startBus = massiv[i].startBusStop.ToLower().Equals(input.ToLower());
                                    bool stopBus = massiv[i].endBusStop.ToLower().Equals(input.ToLower());
                                    if (startBus || stopBus)
                                    {
                                        Console.WriteLine(massiv[i].Print());
                                        count++;
                                        continue;
                                    }
                                }
                                if (count == 0)
                                {
                                    Console.WriteLine($"Нет маршрутов у которых есть остановка '{input}'");
                                }
                            }
                            else
                                break;
                        }

                        break;

                    case 3:
                        Console.Clear();
                        break;

                    case 4:
                        return;
                }
            }


            

        }
    }
}
