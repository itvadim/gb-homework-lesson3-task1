namespace Lesson3.Task1.Calculators
{
    using System.Collections.Generic;
    using Parsers;

    public abstract class Calculator
    {
        protected Parser _expressionParser;
        protected string[] _primaryOperation = {"(", ")"};

        protected Calculator(Parser parser)
        {
            this._expressionParser = parser;
            ;
        }

        /// <summary>
        /// Поддерживаемые калькулятором операций вычислений
        /// </summary>
        public abstract string SupportedOperation
        {
            get;
        }

        /// <summary>
        /// Расчет математического выражения
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public abstract ResultExpression Calculate(string expression);
    }
}