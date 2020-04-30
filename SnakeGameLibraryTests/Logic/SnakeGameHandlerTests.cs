using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakeGameLibrary.Generators;
using SnakeGameLibrary.Interfaces;
using SnakeGameLibrary.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGameLibrary.Logic.Tests
{
    [TestClass]
    public class SnakeGameHandlerTests
    {
        private readonly Random rand = new Random();

        [TestMethod]
        public void SetupGameTest()
        {
            int width = rand.Next();
            int height = rand.Next();
            int startingXPos = rand.Next();
            int startingYPos = rand.Next();
            int startingSnakeLength = rand.Next(1000);
            SnakeGameHandler gameHandler = new SnakeGameHandler();
            gameHandler.SetupGame(width, height, startingXPos, startingYPos, startingSnakeLength);
            Assert.AreEqual(width, gameHandler.GameWidth);
            Assert.AreEqual(height, gameHandler.GameHeight);
            Assert.AreEqual(startingXPos, gameHandler.Snake.BodyParts[0].XPos);
            Assert.AreEqual(startingYPos, gameHandler.Snake.BodyParts[0].YPos);
            Assert.AreEqual(startingSnakeLength, gameHandler.Snake.BodyParts.Length);
        }

        [TestMethod]
        public void SetupGameTest_NegativeWidth_ArgumentOutOfRangeException()
        {
            int width = -rand.Next();
            int height = rand.Next();
            int startingXPos = rand.Next();
            int startingYPos = rand.Next();
            int startingSnakeLength = rand.Next(1000);
            SnakeGameHandler gameHandler = new SnakeGameHandler();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => gameHandler.SetupGame(width, height, startingXPos, startingYPos, startingSnakeLength));
        }

        [TestMethod]
        public void SetupGameTest_NegativeHeight_ArgumentOutOfRangeException()
        {
            int width = rand.Next();
            int height = -rand.Next();
            int startingXPos = rand.Next();
            int startingYPos = rand.Next();
            int startingSnakeLength = rand.Next(1000);
            SnakeGameHandler gameHandler = new SnakeGameHandler();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => gameHandler.SetupGame(width, height, startingXPos, startingYPos, startingSnakeLength));
        }

        [TestMethod]
        public void SetupGameTest_InvalidSnakeLength_ArgumentOutOfRangeException()
        {
            int width = rand.Next();
            int height = rand.Next();
            int startingXPos = rand.Next();
            int startingYPos = rand.Next();
            int startingSnakeLength = -rand.Next(1000);
            SnakeGameHandler gameHandler = new SnakeGameHandler();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => gameHandler.SetupGame(width, height, startingXPos, startingYPos, startingSnakeLength));
        }

        [TestMethod]
        public void SetupGameSnakeParameterTest()
        {
            int width = rand.Next();
            int height = rand.Next();
            int startingXPos = rand.Next();
            int startingYPos = rand.Next();
            int startingSnakeLength = rand.Next(1000);
            ISnake snake = SnakeGenerator.GenerateSnake(startingXPos, startingYPos, startingSnakeLength);
            SnakeGameHandler gameHandler = new SnakeGameHandler();
            gameHandler.SetupGame(width, height, snake);
            Assert.AreEqual(width, gameHandler.GameWidth);
            Assert.AreEqual(height, gameHandler.GameHeight);
            Assert.AreEqual(snake, gameHandler.Snake);
        }

        [TestMethod]
        public void SetupGameSnakeParameterTest_NegativeWidth_ArgumentOutOfRangeException()
        {
            int width = -rand.Next();
            int height = rand.Next();
            int startingXPos = rand.Next();
            int startingYPos = rand.Next();
            int startingSnakeLength = rand.Next(1000);
            ISnake snake = SnakeGenerator.GenerateSnake(startingXPos, startingYPos, startingSnakeLength);
            SnakeGameHandler gameHandler = new SnakeGameHandler();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => gameHandler.SetupGame(width, height, snake));
        }

        [TestMethod]
        public void SetupGameSnakeParameterTest_NegativeHeight_ArgumentOutOfRangeException()
        {
            int width = rand.Next();
            int height = -rand.Next();
            int startingXPos = rand.Next();
            int startingYPos = rand.Next();
            int startingSnakeLength = rand.Next(1000);
            ISnake snake = SnakeGenerator.GenerateSnake(startingXPos, startingYPos, startingSnakeLength);
            SnakeGameHandler gameHandler = new SnakeGameHandler();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => gameHandler.SetupGame(width, height, snake));
        }
    }
}