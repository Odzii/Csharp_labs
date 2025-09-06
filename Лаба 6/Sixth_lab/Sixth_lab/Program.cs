using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;  //  Библиотека для регулярных выражений

namespace Sixth_lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  Работа со строковыми методами

            Console.WriteLine("Введите текст:");
            string input = Console.ReadLine();

            string[] words = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("\nСлова в обратном порядке:");
            foreach (string word in words)
            {
                char[] chars = word.ToCharArray();
                Array.Reverse(chars);
                Console.Write(new string(chars) + " ");
            }


            //  1-я программа по лабе
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

            //  Работа с регулярными выражениями
            /*
             * Дан текст и строка s, Переписать в новый файл g все строки файла f, 
             * содержащие значения переменной s в качестве подстроки. 
             */
            string row_1 = "Сегодня хорошая погода, светит солнце и дует лёгкий ветер. ";
            string row_2 = "Многие люди вышли гулять в парк или поехать на дачу. ";
            string row_3 = "Некоторые предпочитают остаться дома и читать интересную книгу. ";
            string row_4 = "Вечером ожидается небольшой дождь, поэтому стоит взять зонт.";
            Console.WriteLine(row_1 + row_2 + row_3 + row_4);
            Console.WriteLine("Выберете подстроку из текста");
            string substring = Console.ReadLine();





            /*
             * Выбрать IPv4 адреса во всех возможных, представлениях: десятичном,
             * шестнадцатеричном и восьмеричном. С точками и без.
             */
        }


    }
}
