using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakeGameLibrary.Generators;
using SnakeGameLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace SnakeGameLibrary.Generators.Tests
{
    [TestClass]
    public class MapGeneratorTests
    {
        [TestMethod]
        public void GenerateMapTest()
        {
            const int ExpectedHeight = 10;
            const int ExpectedWidth = 15;
            IMap map = MapGenerator.GenerateMap(ExpectedWidth, ExpectedHeight);
            Assert.AreEqual(ExpectedWidth, map.Width);
            Assert.AreEqual(ExpectedHeight, map.Height);
            Assert.AreEqual(ExpectedHeight * ExpectedWidth, map.Tiles.Length);
        }

        [TestMethod]
        public void GenerateMapTest_InvalidParameters_HeightOf0()
        {
            const int ExpectedHeight = 0;
            const int ExpectedWidth = 15;
            Assert.ThrowsException<ArgumentException>(() => MapGenerator.GenerateMap(ExpectedWidth, ExpectedHeight));
        }

        [TestMethod]
        public void GenerateMapTest_InvalidParameters_NegativeWidth()
        {
            const int ExpectedHeight = 12;
            const int ExpectedWidth = -31;
            Assert.ThrowsException<ArgumentException>(() => MapGenerator.GenerateMap(ExpectedWidth, ExpectedHeight));
        }
    }
}