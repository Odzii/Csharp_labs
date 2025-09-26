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

        //  Данная функция выполняет конвертацию 2D массива в 1D
        static int[] MatrixToVector(int[,] matrix)
        {
            int counter = 0;
            int len = matrix.GetLength(0) * matrix.GetLength(1);  //  Получаем длину вектора
            int[] vector = new int[len];
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
            }
            return vector;
        }

        //  Алгоритм быстрой сортировки, когда опорный элемент в конце
        static void Pivot(int[] vector, int indexStart, int indexEnd)
        {
            int start = indexStart;

            if (indexEnd != indexStart)
            {
                for (int i = indexStart; i <= indexEnd; i++)
                {
                    Console.Write(vector[i].ToString() + "\t");
                }
                Console.WriteLine();
            }

            int countEnd = 0;
            int countPivot = 1;
            int pivot = vector[indexEnd];
            if (indexStart == indexEnd)
            {
                return;
            }

            while (indexStart < indexEnd + 1 - countPivot)
            {
                //  Перестановка элементов массива
                if (vector[indexStart] > pivot)
                {
                    //  Перестановка двух элементов, когда
                    // pivot и сравниваемый элемент соседи
                    if (indexEnd - countPivot - indexStart == 0)
                    {
                        var temp = vector[indexStart];
                        vector[indexEnd - countPivot] = pivot;
                        vector[indexEnd - countEnd] = temp;
                        countPivot++;
                    }
                    else
                    {
                        var temp = vector[indexEnd - countPivot];
                        vector[indexEnd - countPivot] = pivot;
                        vector[indexEnd - countEnd] = vector[indexStart];
                        vector[indexStart] = temp;
                        countPivot++;
                        countEnd++;
                    }
                }
                else
                {
                    indexStart++;
                }
            }

            Console.WriteLine();

            Pivot(vector, start, indexEnd - countPivot);
            Pivot(vector, indexEnd - countPivot + 1, indexEnd);
        }

        // Ввод и вывод ошибки при вводе неверного типа при целочисленном значении
        static int IntegerMessage(string text)
        {
            int digit;
            Console.Write("\n" + text);
            while (!int.TryParse(Console.ReadLine(), out digit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка: введите целое число!");
                Console.ResetColor();
                Console.Write(text + " "); // повторяем подсказку
            }
            return digit;
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();  // Создаем объект Random
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
                         *  являющихся нечетными числами
                         */

                        int length = IntegerMessage("Введите размер массива: ");
                        int[] array = new int[length];
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
                        //  Участвует 5 спорстменов в пяти различных соревнованиях
                        matrix = new int[5, 5];
                        min = 30;
                        index = 0;
                        //  строки i = номер спортсмена
                        for (int i = 0; i < matrix.GetLength(0); i++)  
                        {
                            int sum = 0;
                            //  столбцы j = места в соревнования для i-го спортсмена
                            for (int j = 0; j < matrix.GetLength(1); j++)  
                            {
                                int rnd_value = rnd.Next(1, 6);
                                matrix[i, j] = rnd_value;
                                sum += matrix[i, j];
                                Console.Write(matrix[i, j] + "\t");

                            }
                            //  Поиск по минимуму и выполнение перестановок
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
                        /* Рассматривается метод доп№1: 
                         * Метод простых вставок. 
                         * До середины - по возрастанию, после – по убыванию
                         */

                        matrix = CreateMatrix();
                        int[] vector = MatrixToVector(matrix);
                        int len = matrix.GetLength(0) * matrix.GetLength(1);  //  Получаем длину вектора                        
                        index = 0;
                        int extreme;
                        for (int i = 0; i < len - 1; i++)
                        {
                            extreme = vector[i];
                            index = i;
                            for (int j = (i + 1); j < len; j++)  // Смотрим следующий элемент массива и сравниваем с i-м
                            {
                                if (extreme > vector[j] && i <= (len / 2) - 1)
                                {
                                    extreme = vector[j];
                                    index = j;
                                }
                                else if ((extreme < vector[j] && i > (len / 2) - 1))
                                {
                                    extreme = vector[j];
                                    index = j;
                                }
                            }
                            vector[index] = vector[i];
                            vector[i] = extreme;
                        }
                        // Вывод 1D массива после сортировки
                        foreach (int i in vector)
                        {
                            Console.Write(i + " ");
                        }
                        Console.WriteLine();

                        // Старая сортировка отражением половины
                        //counter = 1;
                        //int copyValue;
                        //int maxIter = ((len - len / 2) / 2) + len / 2;
                        //for (int i = len/2; i < maxIter; i++)
                        //{
                        //        copyValue = vector[i];
                        //        vector[i] = vector[len-counter];
                        //        vector[len - counter] = copyValue;
                        //        counter++;
                        //}
                        //    Console.WriteLine();
                        //foreach (int i in vector)
                        //{
                        //    Console.Write(i + " ");
                        //}
                        break;

                    case 4:
                        //  Доп№2: Быстрая сортировка

                        //matrix = CreateMatrix();
                        //len = matrix.GetLength(0) * matrix.GetLength(1);  //  Получаем длину вектора
                        //vector = new int[len];
                        //vector = MatrixToVector(matrix);

                        vector = new int[] { 3, 7, 8, 5, 2, 1, 9, 5, 4 };
                        Pivot(vector, 0, 8);
                        
                        // Вывод массива после сортировки
                        foreach (var item in vector)
                        {
                            Console.Write(item.ToString() + "\t");
                        }
                        Console.WriteLine();
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
