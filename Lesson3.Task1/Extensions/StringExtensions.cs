namespace Lesson3.Task1.Extensions
{
    using System;
    using System.Linq;

    internal static class StringExtensions
    {
        /// <summary>
        /// Проверка принадлежности символа к цифре
        /// </summary>
        public static bool IsDigit(this char symbol)
        {
            return symbol >= '0' && symbol <= '9';
        }

        /// <summary>
        /// Получения числа из символа цифры
        /// </summary>
        public static double ConvertDigitToNumber(this char digitSymbol)
        {
            double number = digitSymbol switch
            {
                '0' => 0,
                '1' => 1,
                '2' => 2,
                '3' => 3,
                '4' => 4,
                '5' => 5,
                '6' => 6,
                '7' => 7,
                '8' => 8,
                '9' => 9,
                _ => throw new InvalidCastException()
            };

            return number;
        }

        /// <summary>
        /// Определяет является ли символ корректным для выражения 
        /// </summary>
        public static bool IsValid(this char symbol)
        {
            return new[]
{
            '0','1','2','3','4','5','6','7','8','9','0','+','-','*','/','(',')'
        }.Contains(symbol);
        }
    }
}
