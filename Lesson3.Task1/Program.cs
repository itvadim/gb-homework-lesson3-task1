namespace Lesson3.Task1
{
    using Calculators;
    using System;

    internal static class Program
    {
        /*
         * Урок 3. Практическое задание.
         * Паписать консольную программу вычисления значения произвольного
         * математического выражения,содержащего следующие операции:
         * +---------+------------------+
         * |Опрерации| Название         |
         * |---------+------------------+
         * | +       | Унарный плюс     |
         * | -       | Унарный минус    |
         * | +       | Сложение         |
         * | -       | Вычитание        |
         * | *       | Умножение        |
         * | /       | Деление          |
         * | ()      | Скобки           |
         *
         * Для решения этой задачи требуется
         * воспользоваться обратной польской записью
         *
         * Ввод:
         * (1 + 2) * 4 + 3
         *
         * Вывод:
         * 1 2 + 4 * 3 +
         * 15
         */

        internal static void Main()
        {
            Calculator calculator = new ArithmeticCalculator();

            Console.WriteLine($"Поддерживаемые операции: {calculator.SupportedOperation}");
            Console.WriteLine("Ввод: ");
            var expression = Console.ReadLine();
            try
            {
                Console.WriteLine();
                var resultCalculation = calculator.Calculate(expression);
                Console.WriteLine("Вывод:");
                Console.WriteLine($"Выражение в ОПН: {resultCalculation.ReversePolishNotation}");
                Console.WriteLine($"Результат выражения: {resultCalculation.Value}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
        }
    }
}
