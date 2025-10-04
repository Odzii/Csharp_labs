using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Seventh_labs
{
    internal class Program
    {
        // Структура Date
        struct Date
        {
            // Поля структуры
            public int day;  // 4 bytes
            public int month;  // 4 bytes
            public int year;  // 4 bytes

            // Конструктор с параметрами
            public Date(int d, int m, int y)
            {
                day = d;
                month = m;
                year = y;
            }

            // Метод внутри структуры
            public void Nextday(int day_count)
            {
                if (1 <= day & day < day_count)
                {
                    day++;
                }
                else if (day == day_count)
                {
                    day = 1;
                    month++;
                    if (month == 13)
                    {
                        Console.WriteLine("Ебать ты долбаеб");
                        month = 1;
                        year++;
                    }
                    else
                        Console.WriteLine("Тебе повезло, ты же долбаеб");
                }
                else
                {
                    Console.WriteLine("Давай по новой Миша всё хуйня?");
                    return;
                }
                Console.WriteLine(day + "." + month + "." + year);
            }
            public void Print()
            {
                var month_dict = new Dictionary<int, int>
                   {
                       {1, 31 },
                       {2, 28 },
                       {3, 31 },
                       {4, 30 },
                       {5, 31 },
                       {6, 30},
                       {7, 31},
                       {8, 31},
                       {9, 30},
                       {10, 31},
                       {11, 30},
                       {12, 31}
                   };

                if (month == 2)
                {
                    if ((year % 4 == 0 & year % 100 != 0) || (year % 400 == 0))
                    {
                        Nextday(29);
                    }
                    else
                    {
                        Nextday(28);
                    }
                }
                else
                    Nextday(month_dict[month]);


            }
        }

        struct Marsh
        {
            public string start_busstop;
            public string end_busstop;
            public int number_bus;

            public Marsh(string start, string end, int number)
            {
                start_busstop = start;
                end_busstop = end;
                number_bus = number;
            }
            public string Print()
            {
                string write_marsh = "N№" + number_bus + " от " + start_busstop + " до " + end_busstop;
                return write_marsh;
            }
        }

        // Обработка ввода, если пользователь ввел значение не целочисленного типа, то вывести информацию об этом
        static int readInputInteger(int startCom, int endCom)
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
                caseValue = readInputInteger(1, 4);

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
                        
                        Console.Write("Введите день\n");
                        int.TryParse(Console.ReadLine(), out int d);
                        Console.Write("Введите месяц\n");
                        int.TryParse(Console.ReadLine(), out int m);
                        Console.Write("Введите год\n");
                        int.TryParse(Console.ReadLine(), out int y);
                        Date get_date = new Date(d, m, y);
                        get_date.Print();
                        get_date.day = 1;
                        get_date.month = 2;
                        Console.WriteLine(get_date.month);
                        break;

                    case 2:
                        //  Задание 2
                        int len = 3;
                        int count = 0;
                        Marsh[] massiv = new Marsh[len];
                        while (count < len)
                        {
                            string start_busstop = Console.ReadLine();
                            string end_busstop = Console.ReadLine();
                            int.TryParse(Console.ReadLine(), out int number_bus);
                            Marsh object_marsh = new Marsh(start_busstop, end_busstop, number_bus);
                            massiv[count] = object_marsh;
                            count++;
                        }
                        string path = "marsh.txt";
                        using (FileStream fs = File.Create(path)) ;
                        {
                            Console.WriteLine("Файл создан");
                        }
                        bool flag = true;
                        foreach (Marsh value in massiv)
                        {
                            if (flag == true)
                            {
                                File.AppendAllText(path, $"{value.Print()}");
                                flag = false;
                            }
                            else
                                File.AppendAllText(path, $"\n{value.Print()}");
                        }
                        Console.WriteLine("Содержимое:");
                        string text = File.ReadAllText(path);
                        Console.WriteLine(text);

                        string[] strings = text.Split(new char[] { '\n' });
                        var pattern = @"^N№\s*(?<route>\d+)\s+от\s+(?<from>.+?)\s+до\s+(?<to>.+)$";
                        var rx = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

                        count = 0;
                        foreach (string value in strings)
                        {
                            var match = rx.Match(value);
                            //Console.WriteLine(value);

                            string from = match.Groups["from"].Value.Trim();
                            string to = match.Groups["to"].Value.Trim();
                            string route = match.Groups["route"].Value.Trim();
                            Marsh object_marsh = new Marsh(from, to, int.Parse(route));
                            massiv[count] = object_marsh;
                            //Console.WriteLine(massiv[count].Print());
                            count++;
                            //string[] parts = { route, from, to };
                            //Console.WriteLine($"Маршрут: {parts[0]}, из: {parts[1]}, в: {parts[2]}");
                        }
                        // Сортировка
                        for (int i = 0; i < len; i++)
                        {
                            int x = massiv[i].number_bus;
                            int j = i - 1;
                            while (j >= 0 && massiv[j].number_bus > x)
                            {
                                massiv[j + 1] = massiv[j];
                                j = j - 1;
                            }
                            massiv[j + 1] = massiv[i];
                        }
                        Console.WriteLine("Введите остановку:");
                        string busstop = Console.ReadLine();
                        for (int i = 0; i < len; i++)
                        {
                            if ((massiv[i].start_busstop.Equals(busstop)) | (massiv[i].end_busstop.Equals(busstop)))
                            {
                                Console.WriteLine(massiv[i].Print());
                            }
                        }
                        break;

                    case 3:
                        Console.Clear();
                        break;

                    case 4:
                        return;
                        break;
                }
            }


            

        }
    }
}
