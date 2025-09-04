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
        static void Main(string[] args)
        {
            Console.Write("Введите число X: ");
            double x = double.Parse(Console.ReadLine());

            Console.Write("Введите степень N: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine($"{x}^{n} = {Power(x, n)}");
        }
    }
}
