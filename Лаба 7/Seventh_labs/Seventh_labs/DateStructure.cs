using System;
using System.Collections.Generic;

namespace SeventhLabs
{
    // Структура Date
    struct Date
    {
        // Поля структуры
        public int day;  // 4 bytes
        public int month;  // 4 bytes
        public int year;  // 4 bytes

        // Конструктор с параметрами
        public Date(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        // Метод по определению следующего дня
        private void NextDay(int dayCount)
        {
            // Основное тело метода
            if (1 <= day && day < dayCount)
            {
                day++;
            }
            else if (day == dayCount)
            {
                day = 1;
                month++;
                if (month > 12)
                {
                    month = 1;
                    year++;
                }
            }
            Console.WriteLine(day + "." + month + "." + year);
            return;
        }
        public void Print()
        {
            var monthDict = new Dictionary<int, int>
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
            // Проверка корректности введеных данных пользователем
            if (day > 31 || day < 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Введите корректное числовое значение дня\n");
                Console.ResetColor();
                return;
            }

            if (month == 2)
            {
                // Проверка, если год високосный
                if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
                {
                    NextDay(29);
                }
                else
                {
                    NextDay(28);
                }
            }
            else if (monthDict.ContainsKey(month))
            {
                NextDay(monthDict[month]);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Введите корректное числовое значение месяца\n");
                Console.ResetColor();
                return;
            }
        }
    }
}

