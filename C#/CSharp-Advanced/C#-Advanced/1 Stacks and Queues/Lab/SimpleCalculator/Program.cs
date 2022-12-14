﻿using System;
using System.Collections.Generic;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] expression = Console.ReadLine().Split();

            Stack<string> stack = new Stack<string>();


            for (int i = 0; i < expression.Length; i++)
            {
                stack.Push(expression[i]);

                if (stack.Count == 3)
                {
                    int first = int.Parse(stack.Pop());
                    string sign = stack.Pop();
                    int second = int.Parse(stack.Pop());
                    int result = 0;
                    if (sign == "+")
                    {
                        result = first + second;
                    }
                    else if (sign == "-")
                    {
                        result = second - first;
                    }
                    stack.Push(result.ToString());
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}