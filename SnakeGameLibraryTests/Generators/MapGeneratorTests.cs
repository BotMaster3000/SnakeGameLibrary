using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakeGameLibrary.Generators;
using SnakeGameLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}