using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakeGameLibrary.Generators;
using SnakeGameLibrary.Interfaces;
using SnakeGameLibrary.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [TestMethod]
        public void IsGameOverTest_SnakeOutOfBordersWidth_IsGameOver()
        {
            const int Width = 10;
            const int Height = 10;
            int startingXPos = rand.Next(Width, 1000);
            int startingYPos = rand.Next(0, Height);
            const int startingSnakeLength = 5;
            SnakeGameHandler gameHandler = new SnakeGameHandler();
            gameHandler.SetupGame(Width, Height, startingXPos, startingYPos, startingSnakeLength);
            Assert.IsTrue(gameHandler.IsGameOver());
        }

        [TestMethod]
        public void IsGameOverTest_SnakeOutOfBordersHeight_IsGameOver()
        {
            const int Width = 10;
            const int Height = 10;
            int startingXPos = rand.Next(0, Width);
            int startingYPos = rand.Next(Height, 1000);
            const int startingSnakeLength = 5;
            SnakeGameHandler gameHandler = new SnakeGameHandler();
            gameHandler.SetupGame(Width, Height, startingXPos, startingYPos, startingSnakeLength);
            Assert.IsTrue(gameHandler.IsGameOver());
        }

        [TestMethod]
        public void IsGameOverTest_SnakeWithinBorders_IsNotGameOver()
        {
            const int Width = 10;
            const int Height = 10;
            int startingXPos = rand.Next(0, Width);
            int startingYPos = rand.Next(0, Height);
            const int startingSnakeLength = 5;
            SnakeGameHandler gameHandler = new SnakeGameHandler();
            gameHandler.SetupGame(Width, Height, startingXPos, startingYPos, startingSnakeLength);
            Assert.IsFalse(gameHandler.IsGameOver());
        }

        [TestMethod]
        public void IsGameOverTest_AllSnakeBodyPartsInSamePosition_IsNotGameOver() // In the scenario of the beginning of the Game
        {
            const int Width = 10;
            const int Height = 10;
            int startingXPos = rand.Next(0, Width);
            int startingYPos = rand.Next(0, Height);
            const int startingSnakeLength = 5;
            SnakeGameHandler gameHandler = new SnakeGameHandler();
            gameHandler.SetupGame(Width, Height, startingXPos, startingYPos, startingSnakeLength);
            Assert.IsFalse(gameHandler.IsGameOver());
        }

        [TestMethod]
        public void NextTurnTest_DirectionLeft()
        {
            const int Width = 10;
            const int Height = 10;
            const int startingXPos = 5;
            const int startingYPos = 5;
            const int startingSnakeLength = 1;
            SnakeGameHandler gameHandler = new SnakeGameHandler();
            gameHandler.SetupGame(Width, Height, startingXPos, startingYPos, startingSnakeLength);
            const int expectedXPosition = startingXPos - 1;
            const int expectedYPosition = startingYPos;
            gameHandler.NextTurn(Enums.Directions.Left);
            ISnakeBodyPart snakeHead = Array.Find(gameHandler.Snake.BodyParts, bodyPart => bodyPart.IsSnakeHead);
            Assert.AreEqual(expectedXPosition, snakeHead.XPos);
            Assert.AreEqual(expectedYPosition, snakeHead.YPos);
        }

        [TestMethod]
        public void NextTurnTest_DirectionRight()
        {
            const int Width = 10;
            const int Height = 10;
            const int startingXPos = 5;
            const int startingYPos = 5;
            const int startingSnakeLength = 1;
            SnakeGameHandler gameHandler = new SnakeGameHandler();
            gameHandler.SetupGame(Width, Height, startingXPos, startingYPos, startingSnakeLength);
            const int expectedXPosition = startingXPos + 1;
            const int expectedYPosition = startingYPos;
            gameHandler.NextTurn(Enums.Directions.Right);
            ISnakeBodyPart snakeHead = Array.Find(gameHandler.Snake.BodyParts, bodyPart => bodyPart.IsSnakeHead);
            Assert.AreEqual(expectedXPosition, snakeHead.XPos);
            Assert.AreEqual(expectedYPosition, snakeHead.YPos);
        }

        [TestMethod]
        public void NextTurnTest_DirectionUp()
        {
            const int Width = 10;
            const int Height = 10;
            const int startingXPos = 5;
            const int startingYPos = 5;
            const int startingSnakeLength = 1;
            SnakeGameHandler gameHandler = new SnakeGameHandler();
            gameHandler.SetupGame(Width, Height, startingXPos, startingYPos, startingSnakeLength);
            const int expectedXPosition = startingXPos;
            const int expectedYPosition = startingYPos - 1;
            gameHandler.NextTurn(Enums.Directions.Up);
            ISnakeBodyPart snakeHead = Array.Find(gameHandler.Snake.BodyParts, bodyPart => bodyPart.IsSnakeHead);
            Assert.AreEqual(expectedXPosition, snakeHead.XPos);
            Assert.AreEqual(expectedYPosition, snakeHead.YPos);
        }

        [TestMethod]
        public void NextTurnTest_DirectionDown()
        {
            const int Width = 10;
            const int Height = 10;
            const int startingXPos = 5;
            const int startingYPos = 5;
            const int startingSnakeLength = 1;
            SnakeGameHandler gameHandler = new SnakeGameHandler();
            gameHandler.SetupGame(Width, Height, startingXPos, startingYPos, startingSnakeLength);
            const int expectedXPosition = startingXPos;
            const int expectedYPosition = startingYPos + 1;
            gameHandler.NextTurn(Enums.Directions.Down);
            ISnakeBodyPart snakeHead = Array.Find(gameHandler.Snake.BodyParts, bodyPart => bodyPart.IsSnakeHead);
            Assert.AreEqual(expectedXPosition, snakeHead.XPos);
            Assert.AreEqual(expectedYPosition, snakeHead.YPos);
        }
    }
}