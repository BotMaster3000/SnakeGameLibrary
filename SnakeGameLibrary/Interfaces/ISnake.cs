using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGameLibrary.Interfaces
{
    public interface ISnake
    {
        ISnakeBodyPart[] BodyParts { get; }
    }
}
