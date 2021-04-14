namespace Lesson3.Task1.Collections
{
    public class LinkedNode<T>
    {
        /// <summary>
        /// Создание нового узла со специальным значением
        /// </summary>
        public LinkedNode(T value)
        {
            this.Value = value;

        }

        /// <summary>
        /// Значение узла
        /// </summary>
        public T Value
        {
            get;
            internal set;
        }

        /// <summary>
        /// Установка следующего значения для узла (null если последний)
        /// </summary>
        public LinkedNode<T> Next
        {
            get;
            internal set;
        }

        /// <summary>
        /// Установка следующего значения для узла (null если первый)
        /// </summary>
        public LinkedNode<T> Previous
        {
            get;
            internal set;
        }
    }
}
