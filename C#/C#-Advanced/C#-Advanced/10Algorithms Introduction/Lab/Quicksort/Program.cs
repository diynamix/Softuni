using System;
using System.Linq;

namespace Quicksort
{
    public class Program
    {
        public static void Main()
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Quick.Sort<int>(array);
            Console.WriteLine(String.Join(" ", array));
        }
    }

    public class Quick
    {
        public static void Sort<T>(T[] a) where T : IComparable<T>
        {
            Random random = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                int r = i + random.Next(0, a.Length - i);
                Swap(a, i, r);
            }
            Sort(a, 0, a.Length - 1);
        }

        private static void Sort<T>(T[] a, int lo, int hi) where T : IComparable<T>
        {
            if (lo >= hi)
            {
                return;
            }

            int p = Partition(a, lo, hi);
            Sort(a, lo, p - 1);
            Sort(a, p + 1, hi);
        }

        private static int Partition<T>(T[] a, int lo, int hi) where T : IComparable<T>
        {
            Func<T, T, bool> Less = (a, b) => a.CompareTo(b) < 0;

            if (lo >= hi)
            {
                return lo;
            }

            int i = lo;
            int j = hi + 1;
            while (true)
            {
                while (Less(a[++i], a[lo]))
                {
                    if (i == hi)
                    {
                        break;
                    }
                }

                while (Less(a[lo], a[--j]))
                {
                    if (j == lo)
                    {
                        break;
                    }
                }

                if (i >= j)
                {
                    break;
                }

                Swap(a, i, j);
            }

            Swap(a, lo, j);
            return j;
        }

        private static void Swap<T>(T[] a, int i, int j)
        {
            T temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}