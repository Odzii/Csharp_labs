using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        static void Main(string[] args)
        {
            Console.Write("Введите число X: ");
            double x = double.Parse(Console.ReadLine());

            Console.Write("Введите степень N: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine($"{x}^{n} = {Power(x, n)}");

            //  Задание №2
            int[] a = { 2, 3, 4, 5, 6 };  // пример массива

            // начиная с i=2 (по условию), а в C# это индекс 1
            double result = RecSum(a, 1);

            Console.WriteLine("Сумма = " + result);
        }
    }
}
