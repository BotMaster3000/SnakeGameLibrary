using SnakeGameLibrary.Interfaces;
using SnakeGameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGameLibrary.Generators
{
    public static class MapGenerator
    {
        public static IMap GenerateMap(int width, int height)
        {
            ITile[] tiles = new ITile[width * height];
            int indexCounter = 0;
            for (int xPos = 0; xPos < width; ++xPos)
            {
                for (int yPos = 0; yPos < height; ++yPos)
                {
                    tiles[indexCounter] = new Tile(xPos, yPos);
                    ++indexCounter;
                }
            }
            return new Map(tiles, width, height);
        }
    }
}
