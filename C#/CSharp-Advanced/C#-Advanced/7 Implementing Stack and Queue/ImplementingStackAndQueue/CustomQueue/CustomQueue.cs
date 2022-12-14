using System;

namespace CustomQueue
{
    public class CustomQueue
    {
        // Fields
        private const int InitialCapacity = 4;
        private const int FirstElementIndex = 0;
        private int[] items;

        // Constructors
        public CustomQueue()
        {
            this.items = new int[InitialCapacity];
        }

        // Properties
        public int Count { get; private set; }

        // Methods
        public void Enqueue(int item)
        {
            if (this.items.Length == this.Count)
            {
                this.Resize();
            }

            this.items[this.Count] = item;

            this.Count++;
        }

        public int Dequeue()
        {
            this.IsEmpty();

            int dequeuedItem = this.items[FirstElementIndex];

            this.ShiftLeft(FirstElementIndex);

            this.Count--;

            return dequeuedItem;
        }

        public int Peek()
        {
            this.IsEmpty();

            return this.items[FirstElementIndex];
        }

        public void Clear()
        {
            this.items = new int[InitialCapacity];

            this.Count = 0;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                int currentItem = this.items[i];

                action(currentItem);
            }
        }

        // private methods
        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        private void IsEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }

    }
}