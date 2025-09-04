using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fourth_lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  Задание по одномерным массивам данных
            Console.Write("Введите значение n ");
            int.TryParse(Console.ReadLine(), out int length);
            int[] array = new int[length];
            
            Random rnd = new Random();
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int rnd_value = rnd.Next(0, 10);
                array[i] = rnd_value;
                Console.WriteLine($"A[{i}] = " + rnd_value);
                if ((i % 2 == 0) & (array[i] % 2 != 0))
                {
                    counter++;
                }

            }
                        
            Console.WriteLine($"Количество таких элементов: {counter}");

            //  Задание по двумерным массивам
            int[,] matrix = new int[5, 5];
            int[] array_sum = new int[5];
            int min = 1000;
            int index = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)  //  строки
            {
                int sum = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)  //  столбцы
                {
                    int rnd_value = rnd.Next(1, 6);
                    matrix[i, j] = rnd_value;
                    sum += matrix[i, j];
                    Console.Write(matrix[i, j] + "\t");

                }
                if (sum < min)
                {
                    min = sum;
                    index = i;
                }
                Console.WriteLine();
            }
            Console.WriteLine("Выиграл спортсмен под номером {0} с суммой очков {1}", index+1, min);
            Console.ReadLine();
        }
    }
}
