using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakeGameLibrary.Generators;
using System;
using System.Collections.Generic;
using System.Text;
using SnakeGameLibrary.Interfaces;

namespace SnakeGameLibrary.Generators.Tests
{
    [TestClass]
    public class SnakeGeneratorTests
    {
        private readonly Random rand = new Random();

        [TestMethod]
        public void GenerateSnakeTest()
        {
            int xPos = rand.Next(1000);
            int yPos = rand.Next(1000);
            int length = rand.Next(1000);
            ISnake snake = SnakeGenerator.GenerateSnake(xPos, yPos, length);
            Assert.AreEqual(length, snake.BodyParts.Length);
            for (int i = 0; i < snake.BodyParts.Length; ++i)
            {
                if (i == 0)
                {
                    Assert.IsTrue(snake.BodyParts[i].IsSnakeHead);
                }
                else
                {
                    Assert.IsFalse(snake.BodyParts[i].IsSnakeHead);
                }

                if (i == snake.BodyParts.Length - 1)
                {
                    Assert.IsNull(snake.BodyParts[i].NextBodyPart);
                }
                else
                {
                    Assert.AreEqual(snake.BodyParts[i + 1], snake.BodyParts[i].NextBodyPart);
                }
            }
        }
    }
}