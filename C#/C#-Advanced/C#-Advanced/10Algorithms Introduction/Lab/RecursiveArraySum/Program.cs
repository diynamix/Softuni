using System;
using System.Linq;

//namespace RecursiveArraySum
//{
public class Program
{
    public static void Main()
    {
        int[] array = Console
            .ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        long sum = Sum(array, 0);
        Console.WriteLine(sum);
    }

    private static long Sum(int[] array, int index)
    {
        //Console.WriteLine("Enter: index = " + index);
        if (index >= array.Length)
        {
            return 0;
        }

        if (index == array.Length - 1)
        {
            // Bottom of the recursion
            //Console.WriteLine("Bottom -> Exit");
            return array[index];
        }

        long sum = array[index] + Sum(array, index + 1);
        //Console.WriteLine("Exit: index = " + index);
        return sum;
    }
}
//}