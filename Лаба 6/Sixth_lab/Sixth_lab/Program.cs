using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;  //  Библиотека для регулярных выражений

namespace Sixth_lab
{
    internal class Program
    {
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
        static void Main(string[] args)
        {
            string input;

            while (true)
            {
                Console.WriteLine("1. Вывести слова в обратном порядке в предложении.\n"
                    + "2. Заменить все цифры на их текстовые значения\n"
                    + "3. Совпадения в тексте по подстроке"
                    + "4. IPv4 регулярные выражения\n"
                    + "5. Очистить консоль\n"
                    + "6. Завершить программу."
                    );
                int valueCase = ReadInteger("Выберите вариант из списка.");
                switch (valueCase)
                {
                    case 1:
                        /*
                        Написать программу, которая вводит текст, состоящий из нескольких предложений, 
                        и выводит каждое слово в обратном порядке. 
                        */
                        Console.WriteLine("Введите текст:");
                        input = Console.ReadLine();

                        string[] words = input.Split(new char[] { ' ', ',', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
                        Console.WriteLine("\nСлова в обратном порядке:");
                        foreach (string word in words)
                        {
                            char[] chars = word.ToCharArray();
                            Array.Reverse(chars);
                            Console.Write(new string(chars) + " ");
                        }
                        break;
                    case 2:
                        /*
                         * Из данной строки сделать новую строку, заменив в ней все цифры 
                         * на соответствующие слова: "один", "два", "три" и т.д.
                         */
                        Console.WriteLine();
                        Console.WriteLine("Введите строку с цифрами:");
                        input = Console.ReadLine();

                        Dictionary<char, string> digits = new Dictionary<char, string>
                        {
                            {'0', "ноль"},
                            {'1', "один"},
                            {'2', "два"},
                            {'3', "три"},
                            {'4', "четыре"},
                            {'5', "пять"},
                            {'6', "шесть"},
                            {'7', "семь"},
                            {'8', "восемь"},
                            {'9', "девять"}
                        };
                        string result = "";
                        foreach (char c in input)
                        {
                            if (digits.ContainsKey(c))
                                result += digits[c] + " ";
                            else
                                result += c;
                        }
                        Console.WriteLine("\nРезультат:");
                        Console.WriteLine(result);
                        Console.WriteLine(result);
                        break;

                    case 3:
                        //  Работа с регулярными выражениями
                        /*
                         * Дан текст и строка s, Переписать в новый файл g все строки файла f, 
                         * содержащие значения переменной s в качестве подстроки. 
                         */
                        string str1 = "Машина стоит у дома.";
                        string str2 = "Сегодня солнечный день.";
                        string str3 = "Дом построен в прошлом году.";
                        string str4 = "Собака бежит по улице.";
                        Console.WriteLine($"\n{str1}\n{str2}\n{str3}\n{str4}");
                        Console.WriteLine("\nВыберете подстроку из текста");
                        string pattern = Console.ReadLine();                       
                        List<string> text = new List<string>() {str1, str2, str3, str4};

                        int count = 0;
                        while (count <= text.Count - 1)
                        {
                            if (Regex.IsMatch(text[count].ToLower(), pattern.ToLower()))
                                Console.WriteLine(text[count]);
                            count++;  
                        }                        
                        break;
                    case 4:
                        /*
                         * Выбрать IPv4 адреса во всех возможных, представлениях: десятичном,
                         * шестнадцатеричном и восьмеричном. С точками и без.
                         */                        
                        string textIPv4 = "192.168.1.10 dec 300.250.001.012 oct c0.a8.01.0a hex 127.0.0.1 dec 177.000.000.001 oct 7f.00.00.01 hex 8.8.8.8 dec 010.010.010.010 oct" +
                            " 08.08.08.08 hex 255.255.255.255 dec 377.377.377.377 oct ff.ff.ff.ff hex 999.999.999.999 wrong 400.1.1.1 wrong 0x100.0xa8.0x01.0x0a hex-with - 0x";
                        ;
                        Console.WriteLine(textIPv4);

                        Console.WriteLine("\n10-e");
                        foreach (Match m in Regex.Matches(textIPv4, @"\b((25[0-5]|2[0-4]\d|1\d{2}|[1-9]\d?)\.)((25[0-5]|2[0-4]\d|1\d{2}|[0-9]\d?)\.){2}((25[0-5]|2[0-4]\d|1\d{2}|[0-9]\d?))\b")) //  10-я система
                        {
                            Console.WriteLine(m.Value);
                        }

                        Console.WriteLine("\n8-e");
                        foreach (Match m in Regex.Matches(textIPv4, @"\b((37[0-7]|3[0-6][0-7]|2[0-7]{2}|1[0-7]{2}|[0-7]{2}[1-7])\.)((37[0-7]|3[0-6][0-7]|2[0-7]{2}|1[0-7]{2}|[0-7]{2}[0-7])\.){2}((37[0-7]|3[0-6][0-7]|2[0-7]{2}|1[0-7]{2}|[0-7]{3}))\b")) // 8-я система
                        {
                            Console.WriteLine(m.Value);
                        }

                        Console.WriteLine("\n16-e");
                        foreach (Match m in Regex.Matches(textIPv4.ToLower(), @"(([a-f]{2}|[a-f][0-9]|[1-9][a-f]|[0-9]{2})\.)(([a-f]{2}|[a-f][0-9]|[0-9][a-f]|[0-9]{2})\.){2}(([a-f]{2}|[a-f][0-9]|[0-9][a-f]|[0-9]{2})\s)")) // 16-я система
                        {
                            Console.WriteLine(m.Value);
                        }
                        break;
                    case 5:
                        Console.Clear();
                        break;
                    case 6:
                        return;
                }
            }










            
        }


    }
}
