using SnakeGameLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGameLibrary.Models
{
    internal class SnakeBodyPart : ISnakeBodyPart
    {
        public bool IsSnakeHead { get; }
        public int XPos { get; }
        public int YPos { get; }
        public ISnakeBodyPart NextBodyPart { get; }

        internal SnakeBodyPart(int xPos, int yPos, bool isSnakeHead, ISnakeBodyPart nextBodyPart)
        {
            XPos = xPos;
            YPos = yPos;
            IsSnakeHead = isSnakeHead;
            NextBodyPart = nextBodyPart;
        }
    }
}
