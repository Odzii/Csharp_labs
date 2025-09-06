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
        string text = 
                        "192.168.1.10 0300.0250.0001.0012 c0.a8.01.0a 0xc0.0xa8.0x01.0x0a " +  // 192.168.1.10
                        
                        "127.0.0.1 0177.000.000.0001 7f.00.00.01 0x7f.0x00.0x00.0x01 " +  // 127.0.0.1
                                                                                         
                        "10.0.0.1 0012.000.000.0001 0a.00.00.01 0x0a.0x00.0x00.0x01 " +  // 10.0.0.1
                                                                                       
                        "8.8.8.8 0010.0010.0010.0010 08.08.08.08 0x08.0x08.0x08.0x08 " +  // 8.8.8.8
                                                                                          
                        "255.255.255.255 0377.0377.0377.0377 ff.ff.ff.ff 0xff.0xff.0xff.0xff " +  // 255.255.255.255
                                                                                                 
                        "0.0.0.0 000.000.000.000 00.00.00.00 0x00.0x00.0x00.0x00 " +  // 0.0.0.0
                                                                                     
                        "172.16.254.1 0254.0020.0376.0001 ac.10.fe.01 0xac.0x10.0xfe.0x01 " +  // 172.16.254.1
                                                                                             
                        "192.0.2.146 0300.000.0002.0222 c0.00.02.92 0xc0.0x00.0x02.0x92";  // 192.0.2.146
        
        Console.WriteLine(text);
        
        Console.WriteLine("\n10-e");
        string pattern_10_dote = @"\b((25[0-5]|2[0-4]\d|1\d{2}|[0-9]\d?)\.){3}((25[0-5]|2[0-4]\d|1\d{2}|[0-9]\d?))\b";
        foreach (Match m in Regex.Matches(text, pattern_10_dote)) //  10-я система
        {
             Console.WriteLine(m.Value);
        }

        Console.WriteLine("\n8-e");
        string pattern_8_dote = @"\b(0?(37[0-7]|3[0-6][0-7]|2[0-7]{2}|0?1[0-7]{2}|[0-7]{2}[0-7])\.){3}(0?(37[0-7]|3[0-6][0-7]|2[0-7]{2}|1[0-7]{2}|0?[0-7]{3}))\b";
        foreach (Match m in Regex.Matches(text, pattern_8_dote)) // 8-я система
        {
            Console.WriteLine(m.Value);
        }

        Console.WriteLine("\n16-e");
        string pattern_16_dote = @"((0[xX])?([A-Fa-f]{2}|[A-Fa-f][0-9]|[0-9][A-Fa-f]|[0-9]{2})\.){3}((0[xX])?([A-Fa-f]{2}|[A-Fa-f][0-9]|[0-9][A-Fa-f]|[0-9]{2})\s)";
        foreach (Match m in Regex.Matches(text, pattern_16_dote)) // 16-я система
        {
            Console.WriteLine(m.Value);
        }

        // тестовая строка (здесь вперемешку примеры в разных СИ + ошибки)
        text =
                "3232235786 030052000412 c0a8010a 0xC0A8010A " +  // 192.168.1.10
                "2130706433 017700000001 7f000001 0x7F000001 " +  // 127.0.0.1
                "167772161 000120000001 0a000001 0x0A000001 " +   // 10.0.0.1
                "134744072 001001001010 08080808 0x08080808 " +   // 8.8.8.8
                "4294967295 037777777777 ffffffff 0xFFFFFFFF " +  // 255.255.255.255
                "0 0x0 " +                                    // 0.0.0.0
                "2886794753 025020376001 ac10fe01 0xAC10FE01 " +  // 172.16.254.1
                "3221226210 030000002222 c0000292 0xC0000292";    // 192.0.2.146

        Console.WriteLine("\n10-e");
        string pattern_10 = @"\b(429496729[0-5]|42949672[0-8][0-9]|4294967[0-1][0-9]{2}|429496[0-6][0-9]{3}|42949[0-5][0-9]{4}|4294[0-8][0-9]{5}|429[0-3][0-9]{6}|42[0-8][0-9]{7}|4[0-1][0-9]{8}|[1-3][0-9]{9}|[1-9][0-9]{8}|[0])\b";
        foreach (Match m in Regex.Matches(text, pattern_10)) // 10-я система
        {
            Console.WriteLine(m.Value);
        }
        Console.WriteLine("\n8-e");
        string pattern_8 = @"(\b(3[0-7]{10}|[0][0-7]{11}|[0]{11}|0)\b)";
        foreach (Match m in Regex.Matches(text, pattern_8)) // 8-я система
        {
            Console.WriteLine(m.Value);
        }

        Console.WriteLine("\n16-e");
        string pattern_16 = @"\b(?:0[xX][0-9A-Fa-f]{1,8}|[0-9A-Fa-f]{1,8})\b";
        foreach (Match m in Regex.Matches(text, pattern_16)) // 16-я система
        {
            Console.WriteLine(m.Value);
        }
    }
}
