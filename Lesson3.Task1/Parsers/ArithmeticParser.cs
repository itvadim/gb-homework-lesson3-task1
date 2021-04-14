namespace Lesson3.Task1.Parsers
{
    using Collections;
    using Exceptions;
    using Extensions;

    public class ArithmeticParser : Parser
    {
        private readonly Queue<char> _digits = new();
        private readonly Stack<char> _operations = new();
        private readonly Queue<object> _reversePolishNotation = new();

        public override Queue<object> ConvertToRpn(char[] symbols)
        {
            char? previousSymbol = null;

            foreach (var symbol in symbols)
            {
                if (symbol == ' ')
                {
                    continue;
                }

                if (!symbol.IsValid())
                {
                    throw new InvalidSymbolException("Недопустимые символы в выражении.", symbol.ToString());
                }

                if (symbol.IsDigit())
                {
                    this._digits.Enqueue(symbol);
                    previousSymbol = symbol;
                    continue;
                }

                // Определяем принадлежность знака к числу или операции
                if (symbol == '-' && (previousSymbol == null || previousSymbol != ')' && !((char)previousSymbol).IsDigit()))
                {
                    this._digits.Enqueue(symbol);
                    continue;
                }

                // Сборка многоразрадного числа
                if (previousSymbol != null && ((char)previousSymbol).IsDigit())
                {
                    var number = this.GetNumber(this._digits.ToArray());
                    this._reversePolishNotation.Enqueue(number);
                }

                switch (symbol)
                {
                    case ')':
                        {
                            while (this._operations.TryPop(out var value))
                            {
                                if (value == '(')
                                {
                                    break;
                                }

                                this._reversePolishNotation.Enqueue(value);
                            }

                            break;
                        }
                    case '(':
                        this._operations.Push(symbol);
                        break;
                    default:
                        if (this._operations.TryPeek(out var value1) && Priority(symbol) <= Priority(value1) && this._operations.TryPop(out var operation))
                        {
                            this._reversePolishNotation.Enqueue(operation);
                        }

                        this._operations.Push(symbol);
                        break;
                }
                previousSymbol = symbol;
            }

            // Выводим оставшиеся цифры в ОПН
            if (this._digits.Count > 0)
            {
                var number = this.GetNumber(this._digits.ToArray());
                this._reversePolishNotation.Enqueue(number);
            }

            // Выводим оставшиеся операторы в ОПН
            while (this._operations.TryPop(out var value))
            {
                this._reversePolishNotation.Enqueue(value);
            }

            return this._reversePolishNotation;
        }

        private static int Priority(char operation)
        {
            return operation switch
            {
                '+' => 10,
                '-' => 10,
                '*' => 20,
                '/' => 20,
                _ => 0
            };
        }
    }
}
