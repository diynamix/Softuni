namespace SimpleSnake.GameObjects.Foods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Food : Point
    {
        private char foodSymbol;
        private ConsoleColor color;
        private Wall wall;

        private Random random;

        protected Food(Wall wall, char foodSymbol, int points, ConsoleColor color) : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.foodSymbol = foodSymbol;
            this.color = color;
            FoodPoints = points;
            random = new Random();
        }

        public int FoodPoints { get; set; }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            LeftX = random.Next(2, wall.LeftX - 2);
            TopY = random.Next(2, wall.TopY - 2);

            bool isSnakeElement = snakeElements.Any(e => e.LeftX == LeftX && e.TopY == TopY);

            while (isSnakeElement)
            {
                LeftX = random.Next(2, wall.LeftX - 2);
                TopY = random.Next(2, wall.TopY - 2);

                isSnakeElement = snakeElements.Any(e => e.LeftX == LeftX && e.TopY == TopY);
            }

            Console.BackgroundColor = color;

            Draw(foodSymbol);

            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snakeHead) => snakeHead.LeftX == LeftX && snakeHead.TopY == TopY;
    }
}
