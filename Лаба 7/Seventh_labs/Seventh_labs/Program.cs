using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Seventh_labs
{
    internal class Program
    {
        struct Date
        {
            public int day;
            public int month;
            public int year;

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
        static void Main(string[] args)
        {
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
            //Console.Write("Введите день\n");
            //int.TryParse(Console.ReadLine(), out int d);
            //Console.Write("Введите месяц\n");
            //int.TryParse(Console.ReadLine(), out int m);
            //Console.Write("Введите год\n");
            //int.TryParse(Console.ReadLine(), out int y);
            //Date get_date = new Date(d, m, y);
            //get_date.Print();
            //get_date.day = 1;
            //get_date.month = 2;
            //Console.WriteLine(get_date.month);

            //  Задание 2
            int count = 0;
            Marsh [] massiv = new Marsh[8];
            while (count < 8)
            {
                string start_busstop = Console.ReadLine();
                string end_busstop = Console.ReadLine();
                int.TryParse(Console.ReadLine(), out int number_bus);
                Marsh object_marsh = new Marsh(start_busstop, end_busstop, number_bus);
                massiv[count] = object_marsh;
                count++;
            }
            string path = "marsh.txt";
            using (FileStream fs = File.Create(path));
            {
                Console.WriteLine("Файл создан");
            }
            foreach(Marsh value in massiv)
            {
                File.AppendAllText(path, $"{value.Print()}\n");
            }
            Console.WriteLine("Содержимое:");
            Console.WriteLine(File.ReadAllText(path));

        }
    }
}
