namespace SimpleSnake.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Foods;
    using Utilities;

    public class Snake
    {
        //private const int SnakeStartTopY = 1;
        private const int SnakeStartLenght = 6;
        //private const int SnakeEndTopY = SnakeStartTopY + SnakeStartLenght;
        private const char snakeSymbol = '\u25CF';
        private const char EmptySpace = ' ';

        private readonly Queue<Point> snakeElements;
        private readonly Wall wall;
        private readonly ReflectionHelper reflectionHelper;
        private IList<Food> food;

        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;

        private Snake()
        {
            snakeElements = new Queue<Point>();
            food = new List<Food>();
            foodIndex = RandomFoodNumber;
            reflectionHelper = new ReflectionHelper();

            CreateSnake();
        }

        public Snake(Wall wall) : this()
        {
            this.wall = wall;

            GetFoods();
        }

        public int FoodEaten { get; set; }

        private int RandomFoodNumber => new Random().Next(0, food.Count);

        public bool IsMooving(Point direction)
        {
            Point currentSnakeHead = snakeElements.Last();
            GetNextPoint(direction, currentSnakeHead);

            bool hasSnakeOverlapped = snakeElements.Any(e => e.LeftX == nextLeftX && e.TopY == nextTopY);

            if (hasSnakeOverlapped)
            {
                return false;
            }

            Point snakeNewHead = new Point(nextLeftX, nextTopY);

            if (wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }

            snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(snakeSymbol);

            if (food[foodIndex].IsFoodPoint(snakeNewHead))
            {
                Eat(direction, currentSnakeHead);
            }

            Point snakeTail = snakeElements.Dequeue();
            snakeTail.Draw(EmptySpace);

            return true;
        }

        private void CreateSnake()
        {
            for (int topY = 0; topY < SnakeStartLenght; topY++)
            {
                snakeElements.Enqueue(new Point(2, topY));
            }
        }

        private void GetFoods()
        {
            //food.Add(new FoodAsterisk(wall));
            //food.Add(new FoodDollar(wall));
            //food.Add(new FoodHash(wall));

            //Use Reflection
            food = reflectionHelper.GenerateFoods(wall).ToList();
            SpawnFood();
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            nextLeftX = snakeHead.LeftX + direction.LeftX;
            nextTopY = snakeHead.TopY + direction.TopY;
        }

        private void Eat(Point direction, Point currentSnakeHead)
        {
            int foodPoints = food[foodIndex].FoodPoints;

            for (int i = 0; i < foodPoints; i++)
            {
                snakeElements.Enqueue(new Point(nextLeftX, nextTopY));
                GetNextPoint(direction, currentSnakeHead);
            }

            FoodEaten += foodPoints;
            SpawnFood();
        }

        private void SpawnFood()
        {
            foodIndex = RandomFoodNumber;
            food[foodIndex].SetRandomPosition(snakeElements);
        }
    }
}
