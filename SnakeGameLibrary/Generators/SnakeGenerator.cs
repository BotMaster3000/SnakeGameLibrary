using SnakeGameLibrary.Interfaces;
using SnakeGameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGameLibrary.Generators
{
    public static class SnakeGenerator
    {
        public static ISnake GenerateSnake(int startingXpos, int startingYPos, int length)
        {
            ISnakeBodyPart[] snakeBodyParts = new ISnakeBodyPart[length];
            ISnakeBodyPart nextBodyPart = null;
            for (int i = length - 1; i >= 0; --i)
            {
                ISnakeBodyPart currentSnakeBodyPart = new SnakeBodyPart(startingXpos, startingYPos, i == 0, nextBodyPart);
                snakeBodyParts[i] = currentSnakeBodyPart;
                nextBodyPart = currentSnakeBodyPart;
            }
            return new Snake(snakeBodyParts);
        }
    }
}
