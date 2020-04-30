using SnakeGameLibrary.Enums;
using SnakeGameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGameLibrary.Interfaces
{
    public interface ISnakeGameHandler
    {
        int GameWidth { get; }
        int GameHeight { get; }

        ISnake Snake { get; }

        void SetupGame(int gameWidth, int gameHeight, int snakeStartingXPos, int snakeStartingYPos, int snakeStartingLength);
        void SetupGame(int gameWidth, int gameHeight, ISnake snake);

        void NextTurn(Directions direction);
        bool IsGameOver();
    }
}
