using System;
using static System.Net.Mime.MediaTypeNames;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Fifth_laba
{
    class Program
    {
        static double Power(double x, int n)
        {
            if (n == 0)
                return 1;
            else if (n < 0)
                return 1 / Math.Pow(x, -n);
            else
                return x * Math.Pow(x, n - 1);
        }

        static double RecSum(int[] array, int i)
        {
            if (i >= array.Length) // база рекурсии
                return 0;

            double term = 1.0 / ((array[i] - 1) * array[i] * (array[i] + 1));
            return term + RecSum(array, i + 1); // шаг рекурсии
        }

        static int ReadInteger(string text)
        {
            Console.Write(text + " ");
            int intValue;
            while (!int.TryParse(Console.ReadLine(), out intValue))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введите целое число!");
                Console.ResetColor();
                Console.Write("\n" + text + " ");
            }
            //Console.WriteLine();
            return intValue;
        }

        static double ReadDouble(string text)
        {
            Console.Write(text + " ");
            double doubleValue;
            while (!double.TryParse(Console.ReadLine(), out doubleValue))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введите число с плавающей запятой!");
                Console.ResetColor();
                Console.Write("\n" + text + " ");
            }
            //Console.WriteLine();
            return doubleValue;
        }

        static void Main(string[] args)
        {
            while (true)
            {                
                Console.WriteLine("1. Возведение в степень;" + "\n2. Дополнительное задание." 
                    + "3. Очистить консоль; " + "\n4. Выход.");

                int valueCase = ReadInteger("Выберите вариант из списка. ");
                if (valueCase < 1 || valueCase > 4)
                    return;

                switch (valueCase)
                {
                    case 1:
                        double x = ReadDouble("Введите число Х");
                        int n = ReadInteger("Введите степень N: ");
                        Console.WriteLine($"{x}^{n} = {Power(x, n)}");
                        break;
                    case 2:
                        //  Задание №2
                        int[] a = { 2, 3, 4, 5, 6 };
                        // начиная с i=2 (по условию), а в C# это индекс 1
                        double result = RecSum(a, 1);
                        Console.WriteLine("Сумма = " + result);
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
