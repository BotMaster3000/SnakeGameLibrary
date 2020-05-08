using SnakeGameLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGameLibrary.Models
{
    internal class SnakeBodyPart : ISnakeBodyPart
    {
        public bool IsSnakeHead { get; }
        public int XPos { get; private set; }
        public int YPos { get; private set; }
        public ISnakeBodyPart NextBodyPart { get; }

        internal SnakeBodyPart(int xPos, int yPos, bool isSnakeHead, ISnakeBodyPart nextBodyPart)
        {
            XPos = xPos;
            YPos = yPos;
            IsSnakeHead = isSnakeHead;
            NextBodyPart = nextBodyPart;
        }

        public void SetPosition(int xPos, int yPos)
        {
            XPos = xPos;
            YPos = yPos;
        }
    }
}
