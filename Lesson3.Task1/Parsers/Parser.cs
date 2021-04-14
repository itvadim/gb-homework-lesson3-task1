namespace Lesson3.Task1.Parsers
{
    using Collections;
    using Extensions;
    using System;

    public abstract class Parser
    {
        public abstract Queue<object> ConvertToRpn(char[] symbols);

        protected virtual double GetNumber(char[] digitSymbols)
        {
            double number = 0;
            var arrayLength = digitSymbols.Length;
            var counter = 0;
            for (var i = 0; i < arrayLength; i++)
            {
                var digitSymbol = digitSymbols[arrayLength - 1 - i];
                try
                {
                    // Попробуем получить одноразрядное число из цифры
                    var realNumber = digitSymbol.ConvertDigitToNumber();

                    /* Преобразуем цифры в числа, умножаем разряды и складываем
                     *
                     * [2]   [1]  [0]
                     *
                     * '2'   '3' ' 4'
                     *  |     |    |
                     *  200 + 30 + 4
                     * = 234
                     */

                    if (counter == 0)
                    {
                        number = realNumber;
                    }
                    else
                    {
                        number += realNumber * Math.Pow(10, counter);
                    }
                }
                catch (InvalidCastException)
                {
                    // Если есть знак -, то инвертируем число 1 => -1
                    if (digitSymbol == '-')
                    {
                        number = 0 - number;
                    }
                    else
                    {
                        throw;
                    }
                }
                counter++;
            }
            return number;
        }
    }
}