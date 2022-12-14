using System;

namespace CustomStack
{
    public class CustomStack
    {
        // Fields
        private const int InitialCapacity = 4;
        private int[] items;

        // Constructors
        public CustomStack()
        {
            this.items = new int[InitialCapacity];
        }

        // Properties
        public int Count { get; private set; }

        // Methods
        public void Push(int item)
        {
            if (this.items.Length == this.Count)
            {
                this.Resize();
            }

            this.items[this.Count] = item;

            this.Count++;
        }

        public int Pop()
        {
            this.IsEmpty();

            int poppedItem = this.items[this.Count - 1];

            this.items[this.Count - 1] = default(int);

            this.Count--;

            return poppedItem;
        }

        public int Peek()
        {
            this.IsEmpty();

            return this.items[this.Count - 1];
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                int currentItem = this.items[i];

                action(currentItem);
            }

            // Reversed
            //for (int i = this.Count - 1; i >= 0; i--)
            //{
            //    int currentItem = this.items[i];

            //    action(currentItem);
            //}
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
                throw new InvalidOperationException("The stack is empty");
            }
        }
    }
}