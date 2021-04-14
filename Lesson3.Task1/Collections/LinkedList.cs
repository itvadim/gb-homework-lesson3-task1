namespace Lesson3.Task1.Collections
{
    public class LinkedList<T>
    {
        private LinkedNode<T> _first;
        private LinkedNode<T> _last;

        public LinkedNode<T> Last => this._last;
        public LinkedNode<T> First => this._first;

        public int Count
        {
            get;
            private set;
        }

        /// <summary>
        /// Добавляет новый элемент в начало списка
        /// </summary>
        public void AddFirst(T value)
        {
            var node = new LinkedNode<T>(value);

            // Сохранение узла head 
            LinkedNode<T> temp = this._first;

            // Указание нового значения начала списка 
            this._first = node;

            // Установка указателя.     
            this._first.Next = temp;

            if (this.Count == 0)
            {
                // Если список был пуст, то оба указателя указывают на новый узел.   
                this._last = this._first;
            }
            else
            {
                // Реализация указателя на предыдущий узел
                // ДО:     head -------> 5 <-> 7 -> null
                // После:  head -> 3 <-> 5 <-> 7 -> null 
                temp.Previous = this._first;
            }

            this.Count++;
        }

        /// <summary>
        /// Добавляет новый элемент в конец списка
        /// </summary>
        public void AddLast(T value)
        {
            var node = new LinkedNode<T>(value);

            if (this.Count == 0)
            {
                this._first = node;
            }
            else
            {
                this._last.Next = node;

                // До:    Head -> 3 <-> 5 -> null         
                // После: Head -> 3 <-> 5 <-> 7 -> null         
                // 7.Previous = 5   
                node.Previous = this._last;
            }
            this._last = node;
            this.Count++;
        }

        /// <summary>
        /// Удалеят последний элемента из списка
        /// </summary>
        public void RemoveLast()
        {
            switch (this.Count)
            {
                case 0:
                    return;
                case 1:
                    this._first = null;
                    this._last = null;
                    break;
                default:
                    // ДО: Head --> 3 <---> 7             
                    //         _last = 7             
                    // ПОСЛЕ:  Head --> 3 --> null             
                    //         _last = 3             
                    this._last.Previous.Next = null;
                    this._last = this._last.Previous;
                    break;
            }

            this.Count--;
        }
    }
}
