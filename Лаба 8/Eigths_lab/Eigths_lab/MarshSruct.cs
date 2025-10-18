using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json;

namespace EigthsLab
{
    public struct Marsh
    {
        public string startBusStop { get; set; }
        public string endBusStop { get; set; }
        public int numberBus { get; set; }

        // конструктор для удобства
        public Marsh(string startBusStop, string endBusStop, int numberBus)
        {
            this.startBusStop = startBusStop;
            this.endBusStop = endBusStop;
            this.numberBus = numberBus;
        }
        public string Print()
        {
            string write_marsh = "N№" + numberBus + " от " + startBusStop + " до " + endBusStop;
            return write_marsh;
        }

        // Запись маршрутов введеных пользователем
        public static List<Marsh> Create(int len)
        {
            int count = 0;
            List<Marsh> massiv = new List<Marsh> { };
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
                massiv.Add(objectMarsh);
                count++;
            }
            return massiv;
        }

        // Поиск маршрутов по остановке
        public static List<Marsh> FindMarsh(List<Marsh> massiv)

        {
            Console.Write("!!!Введите номер желаемой остановки, если необходимо закончить работу напишете");
            Console.ForegroundColor= ConsoleColor.Magenta;
            Console.Write(" <stop>.");
            Console.ResetColor();
            Console.Write("!!!\nВвод: ");
            var LEN = massiv.Count;
            string input = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("Ошибка: введена пустая строка");
                Console.ResetColor();
                Console.Write("Ввод: ");
                input = Console.ReadLine();
            }
            
            var count = 0;
            bool flag = input == "<stop>";
            if (!flag)
            {
                for (int i = 0; i < LEN; i++)
                {
                    bool startBus = massiv[i].startBusStop.ToLower().Equals(input.ToLower());
                    bool stopBus = massiv[i].endBusStop.ToLower().Equals(input.ToLower());
                    if (startBus || stopBus)
                    {
                        Console.WriteLine(massiv[i].Print());
                        count++;
                        continue;
                    }
                }
                if (count == 0)
                {
                    Console.WriteLine($"Нет маршрутов у которых есть остановка '{input}'");
                }
            }

            return massiv; 
        
        
        }

    }
}