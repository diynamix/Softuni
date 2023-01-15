namespace SimpleSnake.GameObjects.Foods
{
    using System;

    public class FoodHash : Food
    {
        private const char DefalutSymbol = '#';
        private const int DefaultPoints = 3;
        private const ConsoleColor DefaultColor = ConsoleColor.DarkYellow;
        
        public FoodHash(Wall wall) : base(wall, DefalutSymbol, DefaultPoints, DefaultColor)
        {
        }
    }
}
