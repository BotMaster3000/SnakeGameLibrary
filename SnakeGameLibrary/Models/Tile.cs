using SnakeGameLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGameLibrary.Models
{
    public class Tile : ITile
    {
        public int XPos { get; }
        public int YPos { get; }

        public Tile(int xPos, int yPos)
        {
            XPos = xPos;
            YPos = yPos;
        }
    }
}
