using System;

namespace ThirdLaba
{
    class Program
    {   //  Данная функция закрашивает сообщения в случае неверного ввода значения типа int
        static void PrintErrorInt(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ResetColor();
        }
        static void Main(string[] args)
        {
            long counter;  //  Переменная счетчик.
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
                    Console.WriteLine("Ошибка: введите номер 1 до 4 и нажмите Enter");
                    Console.ResetColor();
                    continue; // снова показать меню
                }

                switch (valueCase)
                {
                    case 1:  //  Количество точек в круге радиусом R
                        long R;
                        counter = 0;

                        while (true)
                        {
                            Console.Write(
                                "Введите радиус круга, " +
                                "чтобы вычислить К-точек с целочисленными координатами" +
                                " попадающих в круг радиуса R с центром в начале координат.\n" + "R: ");
                            if (long.TryParse(Console.ReadLine(), out R) && R > 0)
                                break;
                            else
                                PrintErrorInt("Ошибка: необходимо целое положительное число.");

                        }

                        for (long x = -R; x <= R; x++)
                        {
                            for (long y = -R; y <= R; y++)
                            {
                                if (Math.Pow(x, 2) + Math.Pow(y, 2) <= Math.Pow(R, 2))
                                {
                                    counter += 1;
                                }
                            }
                        }
                        Console.WriteLine($"Количество точек: {counter}\n");
                        break;

                    case 2:  //  Расчет числовой последовательности
                        int counterIter;
                        counter = 0;
                        double eps = 1e-4;

                        while (true)
                        {
                            Console.WriteLine("Введите максимальное число итераций:");
                            if (int.TryParse(Console.ReadLine(), out counterIter) && counterIter > 0)
                                break;
                            else
                                PrintErrorInt("Ошибка: необходимо целое положительное число.");
                        }

                        double a = 10.0;
                        while (eps < Math.Abs(1-a) && counter < counterIter)
                        {
                            a = 0.5 * (a + (1.0 / a));
                            counter++;
                        }
                        Console.WriteLine($"Число итераций {counter}\nРезультат вычисления {a}");
                        Console.WriteLine($"Достигнутая точность {Math.Abs(1 - a)}\n");
                        if (Math.Abs(1.0 - a) > eps)
                            Console.WriteLine("Внимание: точность не достигнута — исчерпан лимит итераций.\n");
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
