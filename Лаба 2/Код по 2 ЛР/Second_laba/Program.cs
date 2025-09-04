using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;  //  Для использования BiInteger

namespace Second_laba
{
    class Program
    {
        //  Данная функция вычисляет объём параллелепипеда по трем введенным переменным а, b, c
        static void task_one()
        {
            Console.Write("Введите переменную <a> = ");
            int.TryParse(Console.ReadLine(), out int a);
            Console.Write("Введите переменную <b> = ");
            int.TryParse(Console.ReadLine(), out int b);
            Console.Write("Введите переменную <c> = ");
            int.TryParse(Console.ReadLine(), out int c);
            int result_task_1 = a * b * c;  //  Объем параллелепипеда
            Console.WriteLine($"Объем равен: {result_task_1}");
        }

        static void task_four(int x_1, int y_1, int x_2, int y_2, int x_3, int y_3, int x_4, int y_4, int x_5, int y_5)
        {
            int alpha_1 = (x_5 - x_1) * (x_2 - x_1) + (y_5 - y_1) * (y_2 - y_1);
            int alpha_2 = (x_1 - x_2) * (x_3 - x_2) + (y_1 - y_2) * (y_3 - y_2);
            int alpha_3 = (x_2 - x_3) * (x_4 - x_3) + (y_2 - y_3) * (y_4 - y_3);
            int alpha_4 = (x_3 - x_4) * (x_5 - x_4) + (y_3 - y_4) * (y_5 - y_4);
            int alpha_5 = (x_4 - x_5) * (x_1 - x_5) + (y_4 - y_5) * (y_1 - y_5);

            if (alpha_1 == 0)
            {
                Console.WriteLine($"Угол между прямыми (x1;y1),(x2;y2),(y5;x5) равен 90 градусам");
            }
            else
            {
                Console.WriteLine($"Угол между прямыми (x1;y1),(x2;y2),(y5;x5) не равен 90 градусам");
            }

            if (alpha_2 == 0)
            {
                Console.WriteLine($"Угол между прямыми (x1;y1),(x2;y2),(y3;x3) равен 90 градусам");
            }
            else
            {
                Console.WriteLine($"Угол между прямыми (x1;y1),(x2;y2),(y3;x3) не равен 90 градусам");
            }

            if (alpha_3 == 0)
            {
                Console.WriteLine($"Угол между прямыми (x2;y2),(x3;y3),(y4;x4) равен 90 градусам");
            }
            else
            {
                Console.WriteLine($"Угол между прямыми (x2;y2),(x3;y3),(y4;x4) не равен 90 градусам");
            }

            if (alpha_4 == 0)
            {
                Console.WriteLine($"Угол между прямыми (x3;y3),(x4;y4),(y5;x5) равен 90 градусам");
            }
            else
            {
                Console.WriteLine($"Угол между прямыми (x3;y3),(x4;y4),(y5;x5) не равен 90 градусам");
            }

            if (alpha_5 == 0)
            {
                Console.WriteLine($"Угол между прямыми (x1;y1),(x4;y4),(y5;x5) равен 90 градусам");
            }
            else
            {
                Console.WriteLine($"Угол между прямыми (x1;y1),(x4;y4),(y5;x5) не равен 90 градусам");
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите номер задания:");
                Console.WriteLine(
                    "1. Программа для вычисления объема прямоугольного параллелепипеда\n" +
                    "2. Получить a^44 за 6 операций\n" +
                    "3. Получить a^12 и a^38 за 6 операций\n" +
                    "4. Пятиугольник: количество прямых углов\n" +
                    "5. Выход");

                if (!int.TryParse(Console.ReadLine(), out int value_case))
                {
                    Console.WriteLine("Ошибка: введите номер 1–5.\n");
                    continue; // снова показать меню
                }

                switch (value_case)
                {
                    case 1:
                        task_one();
                        break;

                    case 2:
                        Console.Write("Введите переменную <a> = ");
                        if (!int.TryParse(Console.ReadLine(), out int a))
                        {
                            Console.WriteLine("Ошибка: нужно целое число.");
                            break;
                        }
                        long a_2 = a * a;
                        BigInteger a_4 = a_2 * a_2;
                        BigInteger a_8 = a_4 * a_4;
                        BigInteger a_16 = a_8 * a_8;
                        BigInteger a_20 = a_16 * a_4;
                        BigInteger a_22 = a_20 * a_2;
                        BigInteger result_value_1_44 = a_22 * a_22;

                        BigInteger a_32 = a_16 * a_16;
                        BigInteger a_40 = a_32 * a_8;
                        BigInteger result_value_2_44 = a_40 * a_4;
                        Console.WriteLine($"a^44: вариант1={result_value_1_44}, вариант2={result_value_2_44}");
                        break;

                    case 3:
                        Console.Write("Введите переменную <a> = ");
                        if (!int.TryParse(Console.ReadLine(), out int x))
                        {
                            Console.WriteLine("Ошибка: нужно целое число.");
                            break;
                        }
                        long x_2 = x * x;
                        BigInteger x_4 = x_2 * x_2;
                        BigInteger x_8 = x_4 * x_4;
                        BigInteger result_value_12 = x_8 * x_4;

                        BigInteger x_3 = x_2 * x;
                        BigInteger x_6 = x_3 * x_3;
                        BigInteger x_12 = x_6 * x_6;
                        BigInteger x_18 = x_12 * x_6;
                        BigInteger x_36 = x_18 * x_18;
                        BigInteger result_value_38 = x_36 * x_2;
                        Console.WriteLine($"a^12 за 4 операции: {result_value_12}; a^38 за 7 операций: {result_value_38}");
                        break;

                    case 4:
                        Console.WriteLine("1-й пятиугольник");
                        task_four(0, 0, 4, 0, 4, 3, 1, 4, -1, 1);
                        Console.WriteLine("2-й пятиугольник");
                        task_four(0, 0, 2, 1, 5, 1, 5, 4, 1, 3);
                        Console.WriteLine("3-й пятиугольник");
                        task_four(-3, -1, -1, 2, 2, 3, 2, -1, -2, -1);
                        Console.WriteLine("4-й пятиугольник");
                        task_four(0, 0, 1, 1, 3, 0, 4, 2, 1, -2);
                        break;

                    case 5:
                        Console.WriteLine("Выход из программы.");
                        return; // завершаем Main

                    default:
                        Console.WriteLine("Нет такого пункта. Введите 1–5.");
                        break;
                }

                Console.WriteLine(); // пустая строка между итерациями
            }
        }

    }
}
