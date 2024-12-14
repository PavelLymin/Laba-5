// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using MyLibrary;
using System;

namespace Laboratornaya5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Stroka = "ЧастныйЖилДом" + '\n' +
                "ЧастныйЖилДом \"Михаил\" 2020.05.06 32000" + '\n' +
                "ЧастныйЖилДом    2024.09.04 25000" + '\n' +
                "ЧастныйЖилДом \"\" 2020.05.06 32000" + '\n' +
                "ДачныйДом \"Петр Петрович\" 2020.05.06 32000 256,3" + '\n' +
                "ДачныйДом \"Федор Федоров Федорович\"     20n50.05.06 1150 256,5" + '\n' +
                "ДачныйДом \"Петр Павлович\" 2020.05.06     32000 256,3" + '\n' +
                "Новостройка \"Михаил Михайлович\" 2020.05.06     5566 10" + '\n' +
                "Новостройка     \"Петр Петрович Петров\"   2020.05.06 35l00 25" + '\n' +
                "Новостройка \"Федор Федоров Федорович\" 2020.05.06 32000 5" + '\n' +
                "Новостройка \"Федор Федоров Федорович\" 2020.05.06 32000 5";

            Console.WriteLine("Выберите откуда считать данные\n1 - текстовый файл\n2 - строка");
            string choose = Console.ReadLine();
            if (int.TryParse(choose, out var number) && (number == 1 || number == 2))
            {
                ShowInstance(Stroka, number);
            }
            else
            {
                Console.WriteLine("Некорректный ввод, выберите 1 или 2");
            }
        }

        private static void ShowInstance(string Stroka, int number)
        {
            if (number == 1)
            {
                string text = Factory.readFromFile("text.txt");
                foreach (var line in Factory.splitTextToLine(text))
                {
                    try
                    {
                        var obj = Factory.createRealty(line);
                        Console.WriteLine(obj.ToString());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            else
            {
                foreach (var line in Factory.splitTextToLine(Stroka))
                {
                    try
                    {
                        var obj = Factory.createRealty(line);
                        Console.WriteLine(obj.ToString());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}
