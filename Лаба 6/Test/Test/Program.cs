using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string text = "192.129.23.123 ds 11 2 3.99.99.999 05.016.012.91 5. 6. 7. 255.5.0.0b 255.5.0.0  300.250.001.012  001.310.001.377  377.100.007.377";
        text = "192.168.1.10 dec 300.250.001.012 oct c0.a8.01.0a hex 127.0.0.1 dec 177.000.000.001 oct 7f.00.00.01 hex 8.8.8.8 dec 010.010.010.010 oct" +
            " 08.08.08.08 hex 255.255.255.255 dec 377.377.377.377 oct ff.ff.ff.ff hex 999.999.999.999 wrong 400.1.1.1 wrong 0x100.0xa8.0x01.0x0a hex-with - 0x";
        ;
        Console.WriteLine(text);

        Console.WriteLine("\n10-e");
        foreach (Match m in Regex.Matches(text, @"\b((25[0-5]|2[0-4]\d|1\d{2}|[1-9]\d?)\.)((25[0-5]|2[0-4]\d|1\d{2}|[0-9]\d?)\.){2}((25[0-5]|2[0-4]\d|1\d{2}|[0-9]\d?))\b")) //  10-я система
        {
             Console.WriteLine(m.Value);
        }

        Console.WriteLine("\n8-e");
        foreach (Match m in Regex.Matches(text, @"\b((37[0-7]|3[0-6][0-7]|2[0-7]{2}|1[0-7]{2}|[0-7]{2}[1-7])\.)((37[0-7]|3[0-6][0-7]|2[0-7]{2}|1[0-7]{2}|[0-7]{2}[0-7])\.){2}((37[0-7]|3[0-6][0-7]|2[0-7]{2}|1[0-7]{2}|[0-7]{3}))\b")) // 8-я система
        {
            Console.WriteLine(m.Value);
        }

        Console.WriteLine("\n16-e");
        foreach (Match m in Regex.Matches(text.ToLower(), @"(([a-f]{2}|[a-f][0-9]|[1-9][a-f]|[0-9]{2})\.)(([a-f]{2}|[a-f][0-9]|[0-9][a-f]|[0-9]{2})\.){2}(([a-f]{2}|[a-f][0-9]|[0-9][a-f]|[0-9]{2})\s)")) // 16-я система
        {
            Console.WriteLine(m.Value);
        }
    }
}
