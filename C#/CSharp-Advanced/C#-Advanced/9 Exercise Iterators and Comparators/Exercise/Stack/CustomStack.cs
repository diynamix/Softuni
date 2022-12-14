using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private T[] internalArray;
        private int index = -1;

        public CustomStack()
        {
            internalArray = new T[8];
        }


        public void Push(params T[] elements)
        {
            foreach (T element in elements)
            {
                if (index + 1 >= internalArray.Length)
                {
                    Resize();
                }
                internalArray[++index] = element;
            }
        }

        public void Pop()
        {
            try
            {
                internalArray[index] = internalArray[index + 1];
                index--;
            }
            catch
            {
                Console.WriteLine("No elements");
            }
        }

        private void Resize()
        {
            T[] copy = new T[internalArray.Length * 2];
            for (int i = 0; i <= index; i++)
            {
                copy[i] = internalArray[i];
            }
            internalArray = copy;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T element in internalArray)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
