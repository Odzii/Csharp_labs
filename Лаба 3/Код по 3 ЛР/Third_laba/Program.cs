using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdLaba
{
    class Program
    {
        static void PrintErrorInt(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ResetColor();
        }
        static void Main(string[] args)
        {
            int counter;  //  Переменная счетчик.
            while (true)
            {
                Console.WriteLine(
                    "1.Вычислить К-точек с целочисленными координатами попадающих в круг радиусом R\n"
                    + "2.Рассмотреть последовательность 6.10\n" + "3.Очистить вывод\n" + "4.Выйти"
                    );
                if (!int.TryParse(Console.ReadLine(), out int valueCase) || valueCase < 1 || valueCase > 4)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Ошибка: введите номер 1 до 6 и нажмите Enter");
                    Console.ResetColor();
                    continue; // снова показать меню
                }

                switch (valueCase)
                {
                    case 1:
                        int R;
                        counter = 0;

                        while (true)
                        {
                            Console.Write(
                                "Введите радиус круга, " +
                                "чтобы вычислить К-точек с целочисленными координатами" +
                                " попадающих в круг радиуса R с центром в начале координат.\n" + "R: ");
                            if (int.TryParse(Console.ReadLine(), out R) && R > 0)
                                break;
                            else
                                PrintErrorInt("Ошибка: необходимо целое положительное число.");

                        }

                        for (int x = -R; x <= R; x++)
                        {
                            for (int y = -R; y <= R; y++)
                            {
                                if (Math.Pow(x, 2) + Math.Pow(y, 2) <= Math.Pow(R, 2))
                                {
                                    counter += 1;
                                }
                            }
                        }
                        Console.WriteLine($"Количество точек: {counter}");
                        break;

                    case 2:
                        int counter_inter;
                        counter = 0;

                        while (true)
                        {
                            Console.WriteLine("Введите максимальное число итераций:");
                            if (int.TryParse(Console.ReadLine(), out counter_inter) && counter_inter > 0)
                                break;
                            else
                                PrintErrorInt("Ошибка: необходимо целое положительное число.");
                        }

                        double a = 10;
                        while (a < Math.Pow(10, -4) || counter <= counter_inter)
                        {
                            //a = 0.5f * (a + 1f / a);
                            a = 0.5 * (a + (1 / a));
                            counter++;
                        }
                        Console.WriteLine($"Число итераций {counter-1}\nРезультат вычисления {a}");
                        break;

                    case 3:
                        Console.Clear();
                        break;

                    case 4:
                        Console.WriteLine("Выход из программы.");
                        return; // завершаем Main

                }
            }




            
        }
    }
}
