namespace SimpleSnake.Core
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    using Contracts;
    using GameObjects;
    using Enums;

    public class Engine : IEngine
    {
        private const double DefaultSleepTime = 100;
        private const double EasyDifficultyStep = 0.01;
        private const double MediumDifficultyStep = 0.03;
        private const double HardDifficultyStep = 0.05;

        private readonly Stopwatch timer;

        private readonly Point[] directionPoints;
        private Direction direction;
        private Snake snake;
        private readonly Wall wall;
        private double sleepTime;
        private double difficultyStep;

        private Engine()
        {
            directionPoints = new Point[4];
            sleepTime = DefaultSleepTime;
            timer = new Stopwatch();
        }

        public Engine(Wall wall) : this()
        //public Engine(Wall wall, Snake snake) : this()
        {
            this.wall = wall;
            //this.snake = snake;
        }

        public void Run()
        {
            GetDirectionPoints();
            SetDifficultyLevel();

            while (true)
            {
                timer.Start();
                ShowScore();

                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool canMove = snake.IsMooving(directionPoints[(int)direction]);

                if (!canMove)
                {
                    AskUserForRestart();
                }

                sleepTime -= difficultyStep;
                Thread.Sleep((int)sleepTime);
            }
        }

        private void SetDifficultyLevel()
        {
            Console.SetCursorPosition(wall.LeftX + 1, 3);
            Console.Write("Choose game difficulty: ");
            Console.SetCursorPosition(wall.LeftX + 1, 4);
            Console.Write("1: Easy");
            Console.SetCursorPosition(wall.LeftX + 1, 5);
            Console.Write("2: Medium");
            Console.SetCursorPosition(wall.LeftX + 1, 6);
            Console.Write("3: Hard");
            Console.SetCursorPosition(wall.LeftX + 1, 7);

            string answer = Console.ReadLine();
            if (answer == "1")
            {
                difficultyStep = EasyDifficultyStep;
            }
            else if (answer == "2")
            {
                difficultyStep = MediumDifficultyStep;
            }
            else if (answer == "3")
            {
                difficultyStep = HardDifficultyStep;
            }
            else
            {
                StartUp.Main();
            }

            Console.Clear();
            wall.InitializeBoarders();
            snake = new Snake(wall);
        }

        private void GetDirectionPoints()
        {
            directionPoints[(int)Direction.Right] = new Point(1, 0);
            directionPoints[(int)Direction.Left] = new Point(-1, 0);
            directionPoints[(int)Direction.Down] = new Point(0, 1);
            directionPoints[(int)Direction.Up] = new Point(0, -1);
        }

        private void ShowScore()
        {
            Console.SetCursorPosition(wall.LeftX + 1, 0);
            Console.WriteLine($"Score: {snake.FoodEaten}");

            Console.SetCursorPosition(wall.LeftX + 1, 1);
            Console.WriteLine($"Game duration: {timer.ElapsedMilliseconds / 1000000:d2}:{timer.ElapsedMilliseconds / 1000:d2}");

            Console.CursorVisible = false;
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.LeftArrow || userInput.Key == ConsoleKey.A)
            {
                if (direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }

            else if (userInput.Key == ConsoleKey.RightArrow || userInput.Key == ConsoleKey.D)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }

            else if (userInput.Key == ConsoleKey.UpArrow || userInput.Key == ConsoleKey.W)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }

            else if (userInput.Key == ConsoleKey.DownArrow || userInput.Key == ConsoleKey.S)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;
        }

        private void AskUserForRestart()
        {
            int leftX = wall.LeftX + 1;
            int topY = 3;

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? y/n");
            Console.SetCursorPosition(leftX, topY + 1);

            string answer = Console.ReadLine();
            if (answer.ToLower() == "y")
            {
                Console.Clear();
                StartUp.Main(); // -> Engine.Run();
            }
            else
            {
                StopGame();
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(24, 10);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Game Over!");
            Console.ForegroundColor = ConsoleColor.Black;
            Environment.Exit(0);
        }
    }
}
