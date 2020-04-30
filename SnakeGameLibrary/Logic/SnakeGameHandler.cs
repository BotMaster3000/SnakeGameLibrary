using SnakeGameLibrary.Enums;
using SnakeGameLibrary.Generators;
using SnakeGameLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGameLibrary.Logic
{
    public class SnakeGameHandler : ISnakeGameHandler
    {
        public int GameWidth { get; private set; }
        public int GameHeight { get; private set; }

        public ISnake Snake { get; private set; }

        public bool IsGameOver()
        {
            throw new NotImplementedException();
        }

        public void NextTurn(Directions direction)
        {
            throw new NotImplementedException();
        }

        public void SetupGame(int gameWidth, int gameHeight, int snakeStartingXPos, int snakeStartingYPos, int snakeStartingLength)
        {
            GameWidth = gameWidth;
            GameHeight = gameHeight;
            Snake = SnakeGenerator.GenerateSnake(snakeStartingXPos, snakeStartingYPos, snakeStartingLength);
        }

        public void SetupGame(int gameWidth, int gameHeight, ISnake snake)
        {
            throw new NotImplementedException();
        }
    }
}
