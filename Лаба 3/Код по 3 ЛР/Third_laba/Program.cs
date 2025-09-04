using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Third_laba
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите радиус круга, " +
                "чтобы вычислить К-точек с целочисленными координатами" +
                " попадающих в круг радиуса R с центром в начале координат.");
            Console.Write("R: ");
            int.TryParse(Console.ReadLine(), out int R);
            int counter = 0;
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
            Console.WriteLine("Колиство точек: {0}", counter);

            counter = 0;
            int iter = 0;
            //float a = 10f;
            double a = 10;
            while (a < Math.Pow(10, -4) || iter <= 250)
            {
                //a = 0.5f * (a + 1f / a);
                a = 0.5 * (a + (1 / a));
                iter++;
            }
            Console.WriteLine($"Число итераций {iter}\nРезультат вычисления {a}");
            Console.ReadLine();
        }
    }
}
