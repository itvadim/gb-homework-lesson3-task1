namespace Lesson3.Task1.Collections
{
    public class Queue<T>
    {
        private readonly LinkedList<T> _items = new();

        /// <summary>
        /// Метод добавляет новый элемент в конец очереди
        /// </summary>
        public void Enqueue(T value)
        {
            this._items.AddFirst(value);
        }

        /// <summary>
        /// Метод удаляет первый элемент из очереди
        /// </summary>
        public bool TryDequeue(out T value)
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

        /// <summary>
        /// Свойство хранит в себе количество элементов очереди
        /// </summary>
        public int Count => this._items.Count;

        /// <summary>
        /// Преобразование очереди в массив
        /// </summary>
        public T[] ToArray()
        {
            var arrayLength = this._items.Count;
            var array = new T[arrayLength];
            for (var i = 0; i < arrayLength; i++)
            {
                if (this.TryDequeue(out T value))
                {
                    array[i] = value;
                }
            }
            return array;
        }
    }
}
