using SnakeGameLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGameLibrary.Interfaces
{
    public interface ISnake
    {
        IList<ISnakeBodyPart> BodyParts { get; }
        void Move(Directions direction);
    }
}
