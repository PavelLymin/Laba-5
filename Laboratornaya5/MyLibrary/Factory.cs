// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Globalization;
using System.IO;

namespace MyLibrary
{
    /// <summary>
    /// Этот класс выполняет выжные функции.
    /// </summary>
    public static class Factory
    {
        /// <summary>
        /// Разделение строки на абзацы.
        /// </summary>
        /// <param name="входная строка"></param>
        /// <returns></returns>
        public static string[] splitTextToLine(string text)
        {
            return text.Trim().Split('\n');
        }

        /// <summary>
        /// Чтение из файлового потока.
        /// </summary>
        /// <param name="путь к файлу"></param>
        /// <returns></returns>
        public static string readFromFile(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не найден.");
                return string.Empty;
            }
            else
                return File.ReadAllText(path);
        }

        /// <summary>
        /// Парсинг в дату.
        /// </summary>
        /// <param name="строка для парсинга"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DateTime parseDate(string text)
        {
            if (!DateTime.TryParseExact(text, "yyyy.MM.dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var tempDate))
                throw new Exception("Неверный формат даты");

            return DateTime.ParseExact(text, "yyyy.MM.dd", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Парсинг в целое число.
        /// </summary>
        /// <param name="строка для парсинга"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int parseInt(string text)
        {
            if (!int.TryParse(text, out var tempInt))
                throw new Exception("Неверный формат числа");
            return int.Parse(text);
        }

        /// <summary>
        /// Парсинг в число с плавающей запятой.
        /// </summary>
        /// <param name="строка для парсинга"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static double parseDouble(string text)
        {
            if (!double.TryParse(text, out var tempDouble))
                throw new Exception("Неверный формат числа с плавающей точкой");
            return double.Parse(text);
        }

        /// <summary>
        /// Проверка наличия имени в строке.
        /// </summary>
        /// <param name="Входная строка"></param>
        /// <returns></returns>
        public static bool CheckQuoteIndex(string text)
        {
            int firstQuoteIndex = text.IndexOf('"');
            int lastQuoteIndex = text.LastIndexOf('"');
            return (firstQuoteIndex != -1 || lastQuoteIndex != -1) && (lastQuoteIndex - firstQuoteIndex > 1);
        }

        /// <summary>
        /// Создание объекта PrivateResidentBuilding.
        /// </summary>
        /// <param name="Входная строка"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Realty CreatePrivateResidentBuilding(string text)
        {
            if (!CheckQuoteIndex(text))
                throw new Exception("Строка не содержит имени");

            string name = text.Substring(text.IndexOf('"') + 1, text.LastIndexOf('"') - text.IndexOf('"') - 1).Trim();
            string[] otherPart = text.Substring(text.LastIndexOf('"') + 1).Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (otherPart.Length < 2)
                throw new Exception("Недостаточно данных для создания PrivateResidentBuilding");

            return new PrivateResidentBuilding(name, parseDate(otherPart[0]), parseInt(otherPart[1]));
        }

        /// <summary>
        /// Создание объекта CountryHouse.
        /// </summary>
        /// <param name="Входная строка"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Realty CreateCountryHouse(string text)
        {
            if (!CheckQuoteIndex(text))
                throw new Exception("Строка не содержит имени");

            string name = text.Substring(text.IndexOf('"') + 1, text.LastIndexOf('"') - text.IndexOf('"') - 1).Trim();
            string[] otherPart = text.Substring(text.LastIndexOf('"') + 1).Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (otherPart.Length < 3)
                throw new Exception("Недостаточно данных для создания CountryHouse");

            return new CountryHouse(name, parseDate(otherPart[0]), parseInt(otherPart[1]), parseDouble(otherPart[2]));
        }

        /// <summary>
        /// Создание объекта ApartmentBuilding.
        /// </summary>
        /// <param name="Входная строка"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Realty CreateApartmentBuilding(string text)
        {
            if (!CheckQuoteIndex(text))
                throw new Exception("Строка не содержит имени");

            string name = text.Substring(text.IndexOf('"') + 1, text.LastIndexOf('"') - text.IndexOf('"') - 1).Trim();
            string[] otherPart = text.Substring(text.LastIndexOf('"') + 1).Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (otherPart.Length < 3)
                throw new Exception("Недостаточно данных для создания ApartmentBuilding");

            return new ApartmentBuilding(name, parseDate(otherPart[0]), parseInt(otherPart[1]), parseInt(otherPart[2]));
        }

        /// <summary>
        /// Создание объекта по первому слову входной строки
        /// </summary>
        /// <param name="Входная строка"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Realty createRealty(string text)
        {
            string type = text.Split(' ')[0];

            switch (type)
            {
                case "ЧастныйЖилДом":
                    return CreatePrivateResidentBuilding(text);
                case "ДачныйДом":
                    return CreateCountryHouse(text);
                case "Новостройка":
                    return CreateApartmentBuilding(text);
                default:
                    throw new Exception("Не удалось создать экзепляр объекта");
            }
        }
    }
}
