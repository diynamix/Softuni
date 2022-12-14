﻿namespace SimpleSnake
{
    using Core;
    using Core.Contracts;
    using GameObjects;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Wall wall = new Wall(60, 20);
            //Snake snake = new Snake(wall);

            //IEngine engine = new Engine(wall, snake);
            IEngine engine = new Engine(wall);
            engine.Run();
        }
    }
}
