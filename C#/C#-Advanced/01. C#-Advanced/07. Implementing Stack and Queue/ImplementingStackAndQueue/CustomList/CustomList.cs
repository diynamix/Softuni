using System;

namespace CustomList
{
    public class CustomList
    {
        // Fields
        private const int InitialCapacity = 2;
        private int[] items;

        // Constructors
        public CustomList()
        {
            this.items = new int[InitialCapacity];
        }

        // Properties
        public int Count { get; private set; }

        // Methods
        public int this[int index]
        {
            get 
            {
                this.CheckIndex(index);

                return this.items[index];
            }
            set
            {
                this.CheckIndex(index);

                this.items[index] = value;
            }
        }

        public void Add(int item)
        {
            if (this.items.Length == this.Count)
            {
                this.Resize();
            }

            this.items[this.Count] = item;

            this.Count++;
        }

        public void AddRange(int[] array)
        {
            foreach (int item in array)
            {
                this.Add(item);
            }
        }

        public int RemoveAt(int index)
        {
            this.CheckIndex(index);

            int removedItem = this.items[index];

            this.items[index] = default(int);

            this.ShiftLeft(index);

            this.Count--;

            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }

            return removedItem;
        }

        public void InsetAt(int index, int item)
        {
            this.CheckIndex(index);

            if (this.items.Length == this.Count)
            {
                this.Resize();
            }

            ShiftRight(index);

            this.items[index] = item;

            this.Count++;
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i] == item)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firsIndex, int secondIndex)
        {
            this.CheckIndex(firsIndex);
            this.CheckIndex(secondIndex);

            int temp = this.items[firsIndex];
            this.items[firsIndex] = this.items[secondIndex];
            this.items[secondIndex] = temp;
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

        private void Shrink()
        {
            int[] copy = new int[this.items.Length / 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }
        
        private void ShiftRight(int index)
        {
            for (int i = this.Count - 1; i >= index; i--)
            {
                this.items[i + 1] = this.items[i];
            }
        }

        private void CheckIndex(int index)
        {
            if ((index < 0) || (index >= this.Count))
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}