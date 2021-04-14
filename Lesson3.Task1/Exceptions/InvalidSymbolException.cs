namespace Lesson3.Task1.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    internal class InvalidSymbolException : Exception
    {
        public string InvalidSymbol { get; private set; }
        public InvalidSymbolException()
        {
        }

        public InvalidSymbolException(string message) : base(message)
        {
        }

        public InvalidSymbolException(string message, string symbol) : base($"{message} (Некорректный симвод: {symbol})")
        {
            this.InvalidSymbol = symbol;
        }

        public InvalidSymbolException(string message, string symbol, Exception innerException) : base($"{message} (Некорректный симвод: {symbol})", innerException)
        {
            this.InvalidSymbol = symbol;
        }

        protected InvalidSymbolException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}