using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeventhLabs
{
    struct Marsh
    {
        public string startBusStop;
        public string endBusStop;
        public int numberBus;

        public Marsh(string startBusStop, string endBusStop, int numberBus)
        {
            this.startBusStop = startBusStop;
            this.endBusStop = endBusStop;
            this.numberBus = numberBus;
        }

        // Данный метод выводит: номер : начало : конец - заданного маршрута
        public string Print()
        {
            string writeMarsh = "N№" + numberBus + " от " + startBusStop + " до " + endBusStop;
            return writeMarsh;
        }

        // Данный метод создает массив 1D с типом Marsh, принимает на вход количество маршрутов
        public static Marsh[] Create(int len)
        {
            int count = 0;
            Marsh[] massiv = new Marsh[len];
            while (count < len)
            {
                Console.Write("Введите номер маршрута: ");
                int.TryParse(Console.ReadLine(), out int numberBus);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"--------Маршрут номер {numberBus}--------");
                Console.ResetColor();
                Console.Write("Введите нальную остановку: ");
                string startBusStop = Console.ReadLine();
                Console.Write("Введите конечную остановку: ");
                string endBusStop = Console.ReadLine();
                Marsh objectMarsh = new Marsh(startBusStop, endBusStop, numberBus);
                massiv[count] = objectMarsh;
                count++;
            }
            return massiv;
        }

        // Сортировка массива пузырьком
        // sort = True по возрастанию номера, иначе по убыванию номера.
        public static Marsh[] SortMarsh(Marsh[] massiv, bool sort)
        {
            Marsh temp;
            if (sort)
            {
                for (int i = 0; i + 1 < massiv.Length; i++)
                {
                    for (int j = 0; j + 1 < massiv.Length - i; j++)
                    {
                        if (massiv[j + 1].numberBus < massiv[j].numberBus)
                        {
                            temp = massiv[j];
                            massiv[j] = massiv[j + 1];
                            massiv[j + 1] = temp;
                        }
                    }
                }
                return massiv;
            }
            else
            {
                for (int i = 0; i + 1 < massiv.Length; i++)
                {
                    for (int j = 0; j + 1 < massiv.Length - i; j++)
                    {
                        if (massiv[j + 1].numberBus < massiv[j].numberBus)
                        {
                            temp = massiv[j];
                            massiv[j] = massiv[j + 1];
                            massiv[j + 1] = temp;
                        }
                    }
                }
                return massiv;
            }
        }

        //  Запись введеных маршрутов в файл
        public static void AllMarsh(Marsh[] massiv, string path)
        {
            bool flag = true;
            foreach (Marsh value in massiv)
            {
                if (flag)
                {
                    File.AppendAllText(path, $"{value.Print()}");
                    flag = false;
                }
                else
                    File.AppendAllText(path, $"\n{value.Print()}");
            }
            
        }

        public static string CreateFileMarsh(string path)
        {
            //string path = "marsh.txt";
            using (FileStream fs = File.Create(path))
            {
                Console.WriteLine("Файл создан");
            }
            return path;
        }

        // Вывод всех элементов
        public static void PrintAll(Marsh[] massiv)
        {            
            Console.WriteLine("Вывод всех маршрутов");
            foreach (Marsh value in massiv)
            {  
                Console.WriteLine("Номер" + value.numberBus + " от " + value.startBusStop + " до " + value.endBusStop);
            }
        }
    }
}
