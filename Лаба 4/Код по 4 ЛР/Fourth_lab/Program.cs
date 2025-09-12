using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace FourthLab
{
    internal class Program
    {


        //  Метод позволяет создать массив размером [row, col] целочисленного типа.
        static int[,] CreateMatrix()
        {
            Random rnd = new Random();
            int col, row;
            int[,] matrix;
            while (true)
            {
                //  Ввод и проверка корректности                
                Console.Write("Введите число столбцов массива:");
                if (!int.TryParse(Console.ReadLine(), out col) && col > 0)
                {
                    Console.WriteLine("Введите целое положительное число");
                    continue;
                }
                Console.Write("Введите число строк массива:");
                if (!int.TryParse(Console.ReadLine(), out row) && row > 0)
                {
                    Console.WriteLine("Введите целое положительное число");
                    continue;
                }
                matrix = new int[row, col];
                for (int i = 0; i < matrix.GetLength(0); i++)  //  строки
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)  //  столбцы
                    {
                        int rnd_value = rnd.Next(1, 6);
                        matrix[i, j] = rnd_value;
                        Console.Write(matrix[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Массив размером [{0}, {1}] создан\n", row, col);
                break;
            }
            return matrix;
        }


        //  Вывод и подсвечивание текста при ошибочном вводе пользователя.
        static void PrintErrorInt()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Введите целое число");
            Console.ResetColor();
        }


        //  Данная функция принимает на вход (текст ввода, текст при ошибки ввода).
        //  Возвращает вводимое пользователем число.
        static int EnterData(string text, string textError)
        {
            int value;
            while (true)
            {
                Console.WriteLine(text);
                if (!int.TryParse(Console.ReadLine(), out value))
                {
                    Console.WriteLine(textError);
                    continue;
                }
                break;
            }
            return value;   //  Возврат значения введеного пользователем.
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[,] matrix;
            int min;
            int index;

            while (true)
            {
                Console.WriteLine("\n1. Одномерный массив расчет" +
                    "элементов имеющих четные порядковые"
                    + "номера и являющихся нечетными числами.\n"
                    + "2. Поиск лучшего спортсмена по пятиборью.\n"
                    + "3. Метод доп№1\n" + "4. Метод доп№2\n"
                    + "5. Очистить консоль.\n" + "6. Выход.\n" + "7. Тест создания массива"
                    );

                if (!int.TryParse(Console.ReadLine(), out int valueCase) || valueCase < 1 || valueCase > 7)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Введите число из списка  меню");
                    Console.ResetColor();
                }

                switch (valueCase)
                {
                    case 1:

                        /*  В данном блоке происходит расчет количества элементов
                         *  имеющих четные порядковые номера и 
                         *  являющиеся нечетными числами
                         */

                        Console.Write("Введите значение n ");
                        int.TryParse(Console.ReadLine(), out int length);
                        int[] array = new int[length];

                        //  Random rnd = new Random();
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
                        break;

                    case 2:

                        //  Задание по поиску лучшего спортсмена по пятиборью

                        matrix = new int[5, 5];
                        int[] array_sum = new int[5];
                        min = 1000;
                        index = 0;
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
                        Console.WriteLine("Выиграл спортсмен под номером {0} с суммой очков {1}", index + 1, min);
                        Console.ReadLine();
                        break;

                    case 3:
                        counter = 0;
                        matrix = CreateMatrix();
                        int len = matrix.GetLength(0) * matrix.GetLength(1);
                        int[] vector = new int[len];
                        //  Перевод двумерного массива в одномерный
                        if (matrix.GetLength(0) >= 1)
                        {
                            foreach (int i in matrix)
                            {
                                vector[counter] = i;
                                if (counter == 0)
                                {

                                    Console.Write("[" + vector[counter] + ", ");
                                    counter++;
                                    continue;
                                }
                                else if (counter == len - 1)
                                {
                                    Console.Write(vector[counter] + "]\n");
                                    break;
                                }
                                else
                                {
                                    Console.Write(vector[counter] + ", ");
                                    counter++;
                                }
                            }

                            //Console.WriteLine("\n" + counter);
                        }
                        index = 0;
                        for (int i = 0; i < len - 1; i++)
                        {
                            min = vector[i];
                            index = i;
                            for (int j = (i + 1); j < len; j++)
                            {
                                if (min > vector[j])
                                {
                                    min = vector[j];
                                    index = j;
                                }
                                else
                                    continue;
                            }
                            vector[index] = vector[i];
                            vector[i] = min;
                        }
                        foreach (int i in vector)
                        {
                            Console.Write(i + " ");
                        }
                        Console.WriteLine();

                        counter = 1;
                        int copyValue;
                        int maxIter = ((len - len / 2) / 2) + len / 2;
                        for (int i = len/2; i < maxIter; i++)
                        {
                                copyValue = vector[i];
                                vector[i] = vector[len-counter];
                                vector[len - counter] = copyValue;
                                counter++;
                        }
                            Console.WriteLine();
                        foreach (int i in vector)
                        {
                            Console.Write(i + " ");
                        }

                        break;

                    case 4:
                        //  Здесь будет допметод сложнее №4
                        break;

                    case 5:
                        Console.Clear();
                        break;
                    case 6:
                        Console.WriteLine("Завершение программы");
                        return;

                    case 7:
                        Console.WriteLine("Тест метода");
                        CreateMatrix();
                        break;
                }
            }



        }
    }
}
