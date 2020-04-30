using SnakeGameLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGameLibrary.Models
{
    internal class Snake : ISnake
    {
        public ISnakeBodyPart[] BodyParts { get; }

        internal Snake(ISnakeBodyPart[] bodyParts)
        {
            BodyParts = bodyParts;
        }
    }
}
