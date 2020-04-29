using SnakeGameLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGameLibrary.Models
{
    public class Map : IMap
    {
        public ITile[] Tiles { get; }
        public int Width { get; }
        public int Height { get; }

        public Map(ITile[] tiles, int? width = null, int? height = null)
        {
            Tiles = tiles;
            Width = width ?? tiles?.Max(tile => tile.XPos) + 1 ?? 0;
            Height = height ?? tiles?.Max(tile => tile.YPos) + 1 ?? 0;
        }
    }
}
