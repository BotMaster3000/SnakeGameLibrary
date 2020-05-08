using SnakeGameLibrary.Enums;
using SnakeGameLibrary.Generators;
using SnakeGameLibrary.Helper;
using SnakeGameLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            ISnakeBodyPart headBodyPart = Array.Find(Snake.BodyParts, bodyPart => bodyPart.IsSnakeHead);
            return Snake.BodyParts
                .Any(bodyPart // Any Bodypart out of Borders
                    => bodyPart.XPos >= GameWidth
                    || bodyPart.XPos < 0
                    || bodyPart.YPos >= GameHeight
                    || bodyPart.YPos < 0)
                ||
                (
                    Snake.BodyParts // Snakehead hitting other bodypart
                        .Any(bodyPart
                            => bodyPart.XPos == headBodyPart.XPos
                            && bodyPart.YPos == headBodyPart.YPos)
                    && Snake.BodyParts // Not all bodyparts are in the same position
                        .Count(bodyPart
                            => bodyPart.XPos == headBodyPart.XPos
                            && bodyPart.YPos == headBodyPart.YPos)
                        != Snake.BodyParts.Length
                );
        }

        public void NextTurn(Directions direction)
        {
            Snake.Move(direction);
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
