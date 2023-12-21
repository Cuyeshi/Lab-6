
using System;

namespace LibraryForRecords
{
    /// <summary>
    /// Класс исключений.
    /// </summary>
    public class RecordsException : Exception
    {
        public RecordsException(string message) : base(message)
        {
        }

        /// <summary>
        /// Метод исключения для дней.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <exception cref="MatrixException"></exception>
        public static void ValidateDay(string input, out int result)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new RecordsException("Строка пуста!");
            }

            if (!Int32.TryParse(input, out result))
            {
                throw new RecordsException("Строка содержит символ или текст!");
            }

            if (Convert.ToInt32(input) < 0 || Convert.ToInt32(input) > 31)
            {
                throw new RecordsException("Не является днём!");
            }
        }

        /// <summary>
        /// Метод исключений для месяцев.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <exception cref="RecordsException"></exception>
        public static void ValidateMonth(string input, out int result)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new RecordsException("Строка пуста!");
            }

            if (!Int32.TryParse(input, out result))
            {
                throw new RecordsException("Строка содержит символ или текст!");
            }

            if (Convert.ToInt32(input) < 0 || Convert.ToInt32(input) > 12)
            {
                throw new RecordsException("Не является месяцом!");
            }
        }

        /// <summary>
        /// Метод исключений для годов.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <exception cref="RecordsException"></exception>
        public static void ValidateYear(string input, out int result)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new RecordsException("Строка пуста!");
            }

            if (!Int32.TryParse(input, out result))
            {
                throw new RecordsException("Строка содержит символ или текст!");
            }

            if (Convert.ToInt32(input) < 0)
            {
                throw new RecordsException("Не является годом!");
            }
        }
        /// <summary>
        /// Метод исключения для переменных тип Int.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <exception cref="MatrixException"></exception>
        public static void ValidateInt(string input, out int result)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new RecordsException("Строка пуста!");
            }

            if (!Int32.TryParse(input, out result))
            {
                throw new RecordsException("Строка содержит вещественное число или текст!");
            }
        }

        /// <summary>
        /// Метод исключения для выбора специальности.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <exception cref="MatrixException"></exception>
        public static void ValidateSpeciality(string input, out int result)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new RecordsException("Строка пуста!\n");
            }

            if (!Int32.TryParse(input, out result))
            {
                throw new RecordsException("Строка содержит вещественное число или текст!\n");
            }

            if (Convert.ToInt32(input) < 1 || Convert.ToInt32(input) > 5)
            {
                throw new RecordsException("Такой специальности нет!\n");
            }
        }
    }
}

