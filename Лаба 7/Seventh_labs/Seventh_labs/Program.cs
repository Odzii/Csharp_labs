using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Seventh_labs
{
    internal class Program
    {
        struct Date
        {
            public int day { get; set; }
            public int month { get; set; }
            public int year { get; set; }

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
            Console.Write("Введите день\n");
            int.TryParse(Console.ReadLine(), out int d);
            Console.Write("Введите месяц\n");
            int.TryParse(Console.ReadLine(), out int m);
            Console.Write("Введите год\n");
            int.TryParse(Console.ReadLine(), out int y);
            Date get_date = new Date(d, m, y);
            get_date.Print();
            }

    }
}
