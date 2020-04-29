using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGameLibrary.Interfaces
{
    public interface IMap
    {
        int Width { get; }
        int Height { get; }
        public ITile[] Tiles { get; }
    }
}
