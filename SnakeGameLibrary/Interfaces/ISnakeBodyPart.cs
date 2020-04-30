using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGameLibrary.Interfaces
{
    public interface ISnakeBodyPart
    {
        bool IsSnakeHead { get; }
        int XPos { get; }
        int YPos { get; }
        ISnakeBodyPart NextBodyPart { get; }
    }
}
