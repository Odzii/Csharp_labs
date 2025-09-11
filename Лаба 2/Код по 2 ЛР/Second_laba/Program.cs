using System;
using System.Numerics;  //  Для использования BiInteger

namespace SecondLaba
{
    class Program
    {
        static void PrintErrorInt(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ResetColor();
        }
        //  Данная функция вычисляет объём параллелепипеда по трем введенным переменным а, b, c
        static void TaskOne()
        {
            int a, b, c;

            while (true)
            {
                Console.Write("Введите переменную <a> = ");
                if (int.TryParse(Console.ReadLine(), out a) && a > 0)
                {
                    break;
                }
                else
                {
                    PrintErrorInt("Ошибка: нужно целое число <a>.");
                }
            }

            while (true)
            {
                Console.Write("Введите переменную <b> = ");
                if (int.TryParse(Console.ReadLine(), out b) && b > 0)
                {
                    break;
                }
                else
                {
                    PrintErrorInt("Ошибка: нужно целое число <b>.");
                }
            }

            while (true)
            {
                Console.Write("Введите переменную <c> = ");
                if (int.TryParse(Console.ReadLine(), out c) && c > 0)
                {
                    break;
                }
                else
                {
                    PrintErrorInt("Ошибка: нужно целое число <с>.");
                }
            }

            int resultVolume = a * b * c;  //  Объем параллелепипеда
            Console.WriteLine($"Объем равен: {resultVolume}\n");

        }

        /* 
         * Метод TaskFour принимает на вход значения координат х,у типа int. 
         * Далее выполняется расчет угла, если угол
         * отличен от 90 или равен выводит сообщения об этом.
        */
        static void TaskFour(int x_1, int y_1, int x_2, int y_2, int x_3, int y_3, int x_4, int y_4, int x_5, int y_5)
        {
            int countAngleNinty = 0;

            int alpha_1 = (x_5 - x_1) * (x_2 - x_1) + (y_5 - y_1) * (y_2 - y_1);
            int alpha_2 = (x_1 - x_2) * (x_3 - x_2) + (y_1 - y_2) * (y_3 - y_2);
            int alpha_3 = (x_2 - x_3) * (x_4 - x_3) + (y_2 - y_3) * (y_4 - y_3);
            int alpha_4 = (x_3 - x_4) * (x_5 - x_4) + (y_3 - y_4) * (y_5 - y_4);
            int alpha_5 = (x_4 - x_5) * (x_1 - x_5) + (y_4 - y_5) * (y_1 - y_5);

            if (alpha_1 == 0)
            {
                Console.WriteLine($"Угол между прямыми (x1;y1),(x2;y2),(y5;x5) равен 90 градусам");
                countAngleNinty++;
            }
            else
                Console.WriteLine($"Угол между прямыми (x1;y1),(x2;y2),(y5;x5) не равен 90 градусам");

            if (alpha_2 == 0)
            {
                Console.WriteLine($"Угол между прямыми (x1;y1),(x2;y2),(y3;x3) равен 90 градусам");
                countAngleNinty++;
            }                
            else
                Console.WriteLine($"Угол между прямыми (x1;y1),(x2;y2),(y3;x3) не равен 90 градусам");

            if (alpha_3 == 0)
            {
                Console.WriteLine($"Угол между прямыми (x2;y2),(x3;y3),(y4;x4) равен 90 градусам");
                countAngleNinty++;
            }                
            else
                Console.WriteLine($"Угол между прямыми (x2;y2),(x3;y3),(y4;x4) не равен 90 градусам");

            if (alpha_4 == 0)
            {
                Console.WriteLine($"Угол между прямыми (x3;y3),(x4;y4),(y5;x5) равен 90 градусам");
                countAngleNinty++;
            }                
            else
                Console.WriteLine($"Угол между прямыми (x3;y3),(x4;y4),(y5;x5) не равен 90 градусам");

            if (alpha_5 == 0)
            {
                Console.WriteLine($"Угол между прямыми (x1;y1),(x4;y4),(y5;x5) равен 90 градусам");
                countAngleNinty++;
            }
            else
                Console.WriteLine($"Угол между прямыми (x1;y1),(x4;y4),(y5;x5) не равен 90 градусам");

            if (countAngleNinty != 0)
                Console.WriteLine($"Всего углов равных 90 градусам: {countAngleNinty}\n");
            else
                Console.WriteLine("В данном пятиугольнике нет прямых углов\n");     
        }

        static void Main(string[] args)
        {
            int a, x;  //  Используется при расчете степеней для п.2 и п.3
            while (true)
            {
                Console.WriteLine("Введите номер задания:");
                Console.WriteLine
                    (
                    "1. Программа для вычисления объема прямоугольного параллелепипеда\n" +
                    "2. Получить a^44 за 6 операций\n" +
                    "3. Получить a^12 и a^38 за 6 операций\n" +
                    "4. Пятиугольник: количество прямых углов\n" +
                    "5. Выход\n" + "6. Очистить консоль"
                    );

                // Данное условие выполняет проверку ввода пользотелем.

                if (!int.TryParse(Console.ReadLine(), out int valueCase) || valueCase < 1 || valueCase > 6)
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
                        TaskOne();
                        break;

                    case 2:                        
                        Console.Write("Введите переменную <a> = ");
                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out a))
                            {
                                break;
                            }
                            else
                            {
                                PrintErrorInt("Ошибка: нужно целое число <a>.");
                            }
                        }

                        //  Способ №1

                        BigInteger a_2 = a * a;
                        BigInteger a_4 = a_2 * a_2;
                        BigInteger a_8 = a_4 * a_4;
                        BigInteger a_16 = a_8 * a_8;
                        BigInteger a_20 = a_16 * a_4;
                        BigInteger a_22 = a_20 * a_2;
                        BigInteger resultValue_1_44 = a_22 * a_22;

                        //  Способ №2

                        BigInteger a_32 = a_16 * a_16;
                        BigInteger a_40 = a_32 * a_8;
                        BigInteger resultValue_2_44 = a_40 * a_4;
                        Console.WriteLine($"Результаты расчета a^44:\nвариант 1 = {resultValue_1_44};\nвариант 2 = {resultValue_2_44}.\n");
                        break;

                    case 3:
                        Console.Write("Введите переменную <a> = ");
                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out x))
                            {
                                break;
                            }
                            else
                            {
                                PrintErrorInt("Ошибка: нужно целое число <a>.");
                            }
                        }

                        //  Способ №1

                        BigInteger x_2 = x * x;
                        BigInteger x_4 = x_2 * x_2;
                        BigInteger x_8 = x_4 * x_4;
                        BigInteger resultValue_12 = x_8 * x_4;

                        //  Способ №2

                        BigInteger x_3 = x_2 * x;
                        BigInteger x_6 = x_3 * x_3;
                        BigInteger x_12 = x_6 * x_6;
                        BigInteger x_18 = x_12 * x_6;
                        BigInteger x_36 = x_18 * x_18;
                        BigInteger resultValue_38 = x_36 * x_2;
                        Console.WriteLine($"Результат расчета a^12\nЗа 4 операции: {resultValue_12};\na^38 за 7 операций: {resultValue_38}.\n");
                        break;

                    case 4:
                        Console.WriteLine("1-й пятиугольник");
                        TaskFour(0, 0, 4, 0, 4, 3, 1, 4, -1, 1);
                        Console.WriteLine("2-й пятиугольник");
                        TaskFour(0, 0, 2, 1, 5, 1, 5, 4, 1, 3);
                        Console.WriteLine("3-й пятиугольник");
                        TaskFour(-3, -1, -1, 2, 2, 3, 2, -1, -2, -1);
                        Console.WriteLine("4-й пятиугольник");
                        TaskFour(0, 0, 1, 1, 3, 0, 4, 2, 1, -2);
                        break;

                    case 5:
                        Console.WriteLine("Выход из программы.");
                        return; // завершаем Main

                    case 6:
                        Console.Clear();
                        break;
                }
            }
        }

    }
}
