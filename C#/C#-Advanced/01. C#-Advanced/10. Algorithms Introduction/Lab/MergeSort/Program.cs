using System;
using System.Linq;

namespace MergeSort
{
    public class Program
    {
        public static void Main()
        {
            // 5 4 3 2 1 -> 1 2 3 4 5
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            MergeSort<int>.Sort(array);
            Console.Write(String.Join(" ", array));
        }

        public class MergeSort<T> where T : IComparable
        {
            private static T[] auxiliary;

            public static void Sort(T[] arr)
            {
                auxiliary = new T[arr.Length];
                Sort(arr, 0, arr.Length - 1);
            }

            private static void Merge(T[] arr, int lo, int mid, int hi)
            {
                Func<T, T, bool> IsLess = (a, b) => a.CompareTo(b) <= 0;

                if (IsLess(arr[mid], arr[mid + 1]))
                {
                    return;
                }

                for (int index = lo; index < hi + 1; index++)
                {
                    auxiliary[index] = arr[index];
                }

                int i = lo;
                int j = mid + 1;
                for (int k = lo; k <= hi; k++)
                {
                    if (i > mid)
                    {
                        arr[k] = auxiliary[j++];
                    }
                    else if (j > hi)
                    {
                        arr[k] = auxiliary[i++];
                    }
                    else if (IsLess(auxiliary[i], auxiliary[j]))
                    {
                        arr[k] = auxiliary[i++];
                    }
                    else
                    {
                        arr[k] = auxiliary[j++];
                    }
                }
            }

            private static void Sort(T[] arr, int lo, int hi)
            {
                if (lo >= hi)
                {
                    return;
                }

                int mid = lo + (hi - lo) / 2;
                Sort(arr, lo, mid);
                Sort(arr, mid + 1, hi);
                Merge(arr, lo, mid, hi);
            }
        }
    }
}