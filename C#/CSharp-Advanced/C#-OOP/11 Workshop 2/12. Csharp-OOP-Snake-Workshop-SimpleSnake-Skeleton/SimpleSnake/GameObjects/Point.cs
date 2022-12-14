namespace SimpleSnake.GameObjects
{
    using System;

    public class Point
    {
        public Point(int leftX, int topY)
        {
            LeftX = leftX;
            TopY = topY;
        }

        //Column
        public int LeftX;

        //Row
        public int TopY;

        public void Draw(char symbol)
        {
            Console.SetCursorPosition(LeftX, TopY);
            Console.Write(symbol);
        }

        //TODO: Try to make it static
        public void Draw(int leftX, int topY, char symbol)
        {
            Console.SetCursorPosition(leftX, topY);
            Console.Write(symbol);
        }
    }
}