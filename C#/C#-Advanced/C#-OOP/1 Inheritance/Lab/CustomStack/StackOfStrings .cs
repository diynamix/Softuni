using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    internal class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return Count == 0;
        }

        public Stack<string> AddRange(IEnumerable<string> range)
        //public StackOfStrings AddRange(IEnumerable<string> range)
        {
            foreach (string item in range)
            {
                Push(item);
            }

            return this;
        }
    }
}
