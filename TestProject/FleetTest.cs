﻿using Vsite.Battleship;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for FleetTest and is intended
    ///to contain all FleetTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FleetTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetShips
        ///</summary>
        [TestMethod()]
        public void MakeShipsTest()
        {
            ShipBuilder sb = new ShipBuilder();
            Fleet fleet = sb.MakeFleet();
            Assert.AreEqual(Fleet.ShipLengths.Length, fleet.NumberOfShips);

            for (int i = 0; i < fleet.NumberOfShips; ++i)
            {
                Ship ship = fleet.GetShips()[i];
                int left = ship.Squares[0].Column - 1;
                if (left < 0)
                    left = 0;
                int top = ship.Squares[0].Row - 1;
                if (top < 0)
                    top = 0;

                int right = ship.Squares[ship.Squares.Length - 1].Column + 1;
                if (right >= Grid.NumberOfColumns)
                    right = Grid.NumberOfColumns - 1;
                int bottom = ship.Squares[ship.Squares.Length - 1].Row + 1;
                if (bottom >= Grid.NumberOfRows)
                    bottom = Grid.NumberOfRows - 1;

                for (int j = i + 1; j < fleet.NumberOfShips; ++j)
                {
                    Ship shipToCompare = fleet.GetShips()[j];
                    foreach (Square square in shipToCompare.Squares)
                        Assert.IsFalse(IsSquareInside(square, top, left, bottom, right));
                }
            }
        }

        bool IsSquareInside(Square square, int top, int left, int bottom, int right)
        {
            return square.Row >= top && square.Row < bottom && square.Column >= left && square.Column < right;
        }
    }
}
