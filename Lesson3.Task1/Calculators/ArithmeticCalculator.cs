namespace Lesson3.Task1.Calculators
{
    using Parsers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ArithmeticCalculator : Calculator
    {
        private readonly Collections.Stack<double> _operands = new();
        private readonly Dictionary<string, Func<double, double, double>> _supportBinaryOperation;
        private Collections.Queue<object> _reversePolishNotation = new();

        public override string SupportedOperation => 
            this._primaryOperation
                .Union(this._supportBinaryOperation.Keys)
                .Aggregate((currentOperation, nextOperation) => currentOperation + ", " + nextOperation);

        public override ResultExpression Calculate(string expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            var symbols = expression.ToCharArray();

            this._reversePolishNotation = this._expressionParser.ConvertToRpn(symbols);

            var rpnBuilder = new StringBuilder();

            while (this._reversePolishNotation.TryDequeue(out var value))
            {
                rpnBuilder.Append(value);
                rpnBuilder.Append(' ');
                if (value is double number)
                {
                    this._operands.Push(number);
                    continue;
                }

                if (!this._operands.TryPop(out var rightOperand))
                {
                    continue;
                }

                if (!this._operands.TryPop(out var leftOperand))
                {
                    continue;
                }

                var resultOperation = this.CalculateBinaryOperation(leftOperand, rightOperand, Convert.ToString(value));
                this._operands.Push(resultOperation);
            }

            if (this._operands.TryPop(out var result))
            {
                return new ResultExpression()
                {
                    Value = result,
                    ReversePolishNotation = rpnBuilder.ToString()
                };
            }

            throw new Exception();
        }

        private double CalculateBinaryOperation(double leftOperand, double rightOperand, string signOperation)
        {
            try
            {
                return this._supportBinaryOperation[signOperation](leftOperand, rightOperand);
            }
            catch
            {
                throw new NotSupportedException();
            }
        }

        public ArithmeticCalculator() : base(new ArithmeticParser())
        {
            this._supportBinaryOperation = new Dictionary<string, Func<double, double, double>>()
            {
                { "+", (leftOperand, rightOperand) => leftOperand + rightOperand },
                { "-", (leftOperand, rightOperand) => leftOperand - rightOperand },
                { "*", (leftOperand, rightOperand) => leftOperand * rightOperand },
                { "/", (leftOperand, rightOperand) => leftOperand / rightOperand }
            };
        }
    }
}