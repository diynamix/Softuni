namespace SimpleSnake.GameObjects.Foods
{
    using System;

    public class FoodAsterisk : Food
    {
        private const char DefalutSymbol = '*';
        private const int DefaultPoints = 1;
        private const ConsoleColor DefaultColor = ConsoleColor.Red;
        
        public FoodAsterisk(Wall wall) : base(wall, DefalutSymbol, DefaultPoints, DefaultColor)
        {
        }
    }
}
