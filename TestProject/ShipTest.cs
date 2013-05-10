using Vsite.Battleship;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for ShipTest and is intended
    ///to contain all ShipTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ShipTest
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
        ///A test for Fire
        ///</summary>
        [TestMethod()]
        public void FireTest()
        {
            Grid grid = new Grid();
            int length = 3;
            Grid.Orientation orientation = Grid.Orientation.Horizontal;
            Square[] squares = grid.GetFreeStartingSquares(length, orientation);

            Square startingSquare = squares[10];
            Ship ship = grid.MakeShip(startingSquare, length, orientation);

            int row = startingSquare.Row;
            int column = startingSquare.Column;

            Assert.AreEqual(HitResults.Hit, ship.Fire(row, column));
            Assert.AreEqual(HitResults.Hit, ship.Fire(row, column + 1));
            Assert.AreEqual(HitResults.Sunk, ship.Fire(row, column + 2));
            Assert.AreEqual(HitResults.Missed, ship.Fire(row - 1, column));


            grid = new Grid();
            length = 5;
            orientation = Grid.Orientation.Vertical;
            squares = grid.GetFreeStartingSquares(length, orientation);

            startingSquare = squares[10];
            ship = grid.MakeShip(startingSquare, length, orientation);

            row = startingSquare.Row;
            column = startingSquare.Column;

            Assert.AreEqual(HitResults.Missed, ship.Fire(row, column - 1));
            Assert.AreEqual(HitResults.Hit, ship.Fire(row + length - 1, column));
            Assert.AreEqual(HitResults.Hit, ship.Fire(row + length - 2, column));
            Assert.AreEqual(HitResults.Hit, ship.Fire(row + length - 3, column));
            Assert.AreEqual(HitResults.Hit, ship.Fire(row + length - 3, column));
            Assert.AreEqual(HitResults.Hit, ship.Fire(row + length - 4, column));
            Assert.AreEqual(HitResults.Sunk, ship.Fire(row + length - 5, column));
            Assert.AreEqual(HitResults.Sunk, ship.Fire(row + length - 5, column));
            Assert.AreEqual(HitResults.Sunk, ship.Fire(row + length - 4, column));
        }
    }
}
