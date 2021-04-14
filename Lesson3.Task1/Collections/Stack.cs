namespace Lesson3.Task1.Collections
{
    public class Stack<T>
    {
        private readonly LinkedList<T> _items = new();

        /// <summary>
        /// Помещяет элемент в стек
        /// </summary>
        public void Push(T value)
        {
            this._items.AddLast(value);
        }

        /// <summary>
        /// Возвращает количество элементов стека
        /// </summary>
        public int Count => this._items.Count;

        /// <summary>
        /// Попытка извлечь элемент из стека, без его удаления
        /// </summary>
        /// <param name="value">Извлеченный элемент</param>
        /// <returns></returns>
        public bool TryPeek(out T value)
        {
            value = default;
            if (this.Count == 0)
            {
                return false;
            }

            value = this._items.Last.Value;
            return true;
        }

        /// <summary>
        /// Попытка извлечь элемент,
        /// с последующим его удалением из стека
        /// </summary>
        /// <param name="value">Извлеченный элемент</param>
        public bool TryPop(out T value)
        {
            value = default;
            if (this._items.Count == 0)
            {
                return false;
            }

            value = this._items.Last.Value;
            this._items.RemoveLast();
            return true;
        }
    }
}
