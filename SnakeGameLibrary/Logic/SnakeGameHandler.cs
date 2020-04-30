using SnakeGameLibrary.Enums;
using SnakeGameLibrary.Generators;
using SnakeGameLibrary.Helper;
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
            ISnake snake = SnakeGenerator.GenerateSnake(snakeStartingXPos, snakeStartingYPos, snakeStartingLength);
            SetupGame(gameWidth, gameHeight, snake);
        }

        public void SetupGame(int gameWidth, int gameHeight, ISnake snake)
        {
            ExceptionHelper.ThrowArgumentOutOfRangeIfZeroOrLower(nameof(gameWidth), gameWidth);
            ExceptionHelper.ThrowArgumentOutOfRangeIfZeroOrLower(nameof(gameHeight), gameHeight);
            GameWidth = gameWidth;
            GameHeight = gameHeight;
            Snake = snake;
        }
    }
}
