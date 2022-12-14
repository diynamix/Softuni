using System;

namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int length, T element)
        {
            T[] array = new T[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = element;
            }

            return array;
        }
    }
}