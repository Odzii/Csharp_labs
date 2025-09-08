using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json;

namespace Eigths_lab
{
    public struct Marsh
    {
        public string start_busstop { get; set; }
        public string end_busstop { get; set; }
        public int number_bus { get; set; }

        // конструктор для удобства
        public Marsh(string start, string end, int number)
        {
            start_busstop = start;
            end_busstop = end;
            number_bus = number;
        }
        public string Print() 
        { 
            string write_marsh = "N№" + number_bus + " от " + start_busstop + " до " + end_busstop; 
            return write_marsh; 
        }
    }

    [XmlRoot("Routes")]
    public struct MarshArray
    {
        [XmlElement("Route")]
        public Marsh[] Items;
    }
    internal class Program
    {
        
        static void SaveToXml<T>(T data, string path)
        {
            var serializer = new XmlSerializer(typeof(T));
            var fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            serializer.Serialize(fs, data);
            fs.Close();
        }

        static T LoadFromXml<T>(string path)
        {
            var serializer = new XmlSerializer(typeof(T));
            var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            return (T)serializer.Deserialize(fs);
        }

        //////////////////////////
        
        static void SaveToJson<T>(T data, string path)
        {
            var options = new JsonSerializerOptions { WriteIndented = true }; // красивое форматирование
            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(path, json);
        }

        static T LoadFromJson<T>(string path)
        {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T>(json);
        }

        static void Main(string[] args)
        {
            int len = 3;
            Marsh[] massiv = new Marsh[len];

            for (int i = 0; i < len; i++)
            {
                Console.WriteLine("Введите начальную остановку:");
                string start = Console.ReadLine();
                Console.WriteLine("Введите конечную остановку:");
                string end = Console.ReadLine();
                Console.WriteLine("Введите номер маршрута:");
                int.TryParse(Console.ReadLine(), out int number);

                massiv[i] = new Marsh(start, end, number);
            }

            // Заворачиваем в контейнер
            MarshArray routes = new MarshArray { Items = massiv };

            // Запись
            string xmlPath = "routes.xml";
            SaveToXml(routes, xmlPath);
            Console.WriteLine("XML сохранён.");

            // Чтение
            MarshArray loaded = LoadFromXml<MarshArray>(xmlPath);
            Console.WriteLine("Считано из XML:");

            // Пример обработки — сортировка по номеру
            var sorted = loaded.Items.OrderBy(m => m.number_bus);

            foreach (var marsh in sorted)
                Console.WriteLine(marsh.Print());
            Console.ReadLine();

            string jsonPath = "routes.json";

            // запись
            SaveToJson(massiv, jsonPath);
            Console.WriteLine("JSON сохранён.");

            // чтение
            Marsh[] json_loaded = LoadFromJson<Marsh[]>(jsonPath);
            Console.WriteLine("Считано из JSON:");

            foreach (var marsh in json_loaded)
                Console.WriteLine(marsh.Print());
        }
    }
}
