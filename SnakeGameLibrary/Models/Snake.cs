using SnakeGameLibrary.Enums;
using SnakeGameLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGameLibrary.Models
{
    internal class Snake : ISnake
    {
        public IList<ISnakeBodyPart> BodyParts { get; }

        internal Snake(ISnakeBodyPart[] bodyParts)
        {
            BodyParts = bodyParts;
        }

        public void Move(Directions direction)
        {
            int xPosIncrement = 0, yPosIncrement = 0;
            switch (direction)
            {
                case Directions.Up:
                    --yPosIncrement;
                    break;
                case Directions.Right:
                    ++xPosIncrement;
                    break;
                case Directions.Down:
                    ++yPosIncrement;
                    break;
                case Directions.Left:
                    --xPosIncrement;
                    break;
            }
            ISnakeBodyPart currentBodyPart = BodyParts.First();
            int previousSnakeBodyPartXPosition = currentBodyPart.XPos;
            int previousSnakeBodyPartYPosition = currentBodyPart.YPos;
            currentBodyPart.SetPosition(currentBodyPart.XPos + xPosIncrement, currentBodyPart.YPos + yPosIncrement);
            for (int i = 1; i < BodyParts.Count; ++i)
            {
                currentBodyPart = BodyParts[i];
                currentBodyPart.SetPosition(previousSnakeBodyPartXPosition, previousSnakeBodyPartYPosition);
                previousSnakeBodyPartXPosition = currentBodyPart.XPos;
                previousSnakeBodyPartYPosition = currentBodyPart.YPos;
            }
        }
    }
}
