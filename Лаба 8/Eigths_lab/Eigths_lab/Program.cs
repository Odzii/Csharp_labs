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
    //  Инициализация сериализации
    [XmlRoot("Routes")]
    public struct MarshArray
    {
        [XmlElement("Route")]
        public List<Marsh> Items;
    }


    internal class Program
    {
       
        // Внизу будут описаны методы для работы с XML и Json
        // Метод для сохранения XML
        static void SaveToXml<T>(T data, string path)
        {
            try
            {
                var s = new XmlSerializer(typeof(T));
                using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                    s.Serialize(fs, data);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("XML сохранён: ");
                Console.ResetColor();
                Console.WriteLine($"{Path.GetFullPath(path)}");

                //fs.Close();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка сохранения XML" + ex.Message);
                Console.ResetColor();
            }
        }
        
        // Метод для загрузки XML
        static T LoadFromXml<T>(string path)
        {
            
            var s = new XmlSerializer(typeof(T));
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("XML загружен: ");
            Console.ResetColor();
            Console.WriteLine($"{Path.GetFullPath(path)}");
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                return (T)s.Deserialize(fs);
            
        }

        // Метод для сохранения Json        
        static void SaveToJson<T>(T data, string path)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true }; // красивое форматирование
                string json = JsonSerializer.Serialize(data, options);
                File.WriteAllText(path, json);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("Json сохранён: ");
                Console.ResetColor();
                Console.WriteLine($"{Path.GetFullPath(path)}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка сохранения Json" + ex.Message);
                Console.ResetColor();
            }
            
        }

        // Метод для загрузки Json   
        static T LoadFromJson<T>(string path)
        {
            string json = File.ReadAllText(path);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("Json загружен: ");
            Console.ResetColor();
            Console.WriteLine($"{Path.GetFullPath(path)}");
            return JsonSerializer.Deserialize<T>(json);
        }


        // Обработка ввода, если пользователь ввел значение не целочисленного типа, то вывести информацию об этом
        static int ReadInputInteger(int startCom, int endCom)
        {
            while (true)
            {
                Console.Write("Введите число из меню, для выбора задания: ");
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input < startCom || input > endCom)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введите от {0} до {1}", startCom, endCom);
                        Console.ResetColor();
                    }
                    else return input;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка, необходимо целое число");
                    Console.ResetColor();
                    continue;
                }
            }
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

        // Вывод содержимого routes
        static void PrintRoutes(IEnumerable<Marsh> routes)
        {
            foreach (var r in routes) Console.WriteLine(r.Print());
        }

        static void Main(string[] args)
        {
            while (true)
            {
                int LEN;
                List<Marsh> massiv;
                MarshArray routes;
                Console.WriteLine("Введите число из меню, для выбора задания:");
                Console.WriteLine("1. Работа с XML\n" 
                    + "2. Работа с Json\n"
                    + "3. Очистить консоль.\n"
                    + "4. Завершить работу программы.");
                int caseValue;
                caseValue = ReadInputInteger(1, 4);

                switch(caseValue)
                {
                    case 1: // часть 1 работа с XML
                        LEN = ReadInteger("Введите количество маршрутов");
                        massiv = Marsh.Create(LEN);
                        routes = new MarshArray { Items = massiv };
                        string xmlPath = "routes.xml";
                        SaveToXml(routes, xmlPath);
                        MarshArray loaded = LoadFromXml<MarshArray>(xmlPath);
                        var sorted = loaded.Items.OrderBy(m => m.numberBus);
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Считано из XML:");
                        Console.ResetColor();
                        PrintRoutes(sorted);
                        Marsh.FindMarsh(massiv);
                        Console.WriteLine();
                        break;

                    case 2: // часть 2 работа с Json
                        LEN = ReadInteger("Введите количество маршрутов");
                        massiv = Marsh.Create(LEN);
                        routes = new MarshArray { Items = massiv };                        
                        string jsonPath = "routes.json";
                        SaveToJson(massiv, jsonPath);
                        Marsh[] json_loaded = LoadFromJson<Marsh[]>(jsonPath);
                        Console.ForegroundColor= ConsoleColor.DarkMagenta;
                        Console.WriteLine("Считано из JSON:");
                        Console.ResetColor();
                        PrintRoutes(json_loaded);
                        Marsh.FindMarsh(massiv);
                        Console.WriteLine();
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
