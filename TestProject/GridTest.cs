using VsiTe.BattleShipModul;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for GridTest and is intended
    ///to contain all GridTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GridTest
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
        ///A test for GetFreeStartingSquares
        ///</summary>
        [TestMethod()]
        public void GetFreeStartingSquaresTest()
        {
            Grid grid = new Grid(); // TODO: Initialize to an appropriate value
            int lenght = 3; // TODO: Initialize to an appropriate value
            Grid.Orientation orientation = Grid.Orientation.Horizontal; // TODO: Initialize to an appropriate value
            Square[] actual;
            actual = grid.GetFreeStartingSquares(lenght, orientation);
            Assert.AreEqual(80, actual.Length);

            Assert.IsNotNull(GetSquare(actual, 3, 3));
            Assert.IsNull(GetSquare(actual, 4, 8));


            lenght = 4; // TODO: Initialize to an appropriate value
            orientation = Grid.Orientation.Vertical; // TODO: Initialize to an appropriate value
            actual = grid.GetFreeStartingSquares(lenght, orientation);
            Assert.AreEqual(70, actual.Length);

            Assert.IsNotNull(GetSquare(actual, 5, 2));
            Assert.IsNull(GetSquare(actual, 7, 0));


        }
        [TestMethod()]
        public void GetStartingSquaresTest()
        {
            Grid grid = new Grid(); // TODO: Initialize to an appropriate value
            int lenght = 3; // TODO: Initialize to an appropriate value
            Grid.Orientation orientation = Grid.Orientation.Horizontal; // TODO: Initialize to an appropriate value
            Square[] actual;
            actual = grid.GetFreeStartingSquares(lenght, orientation);
            Assert.AreEqual(80, actual.Length);

            Square startSquare = GetSquare(actual, 3, 3);
            grid.MakeShip(startSquare, lenght, orientation);

            Assert.IsNotNull(GetSquare(actual, 3, 3));
            Assert.IsNull(GetSquare(actual, 4, 8));


            //lenght = 4; // TODO: Initialize to an appropriate value
            orientation = Grid.Orientation.Vertical; // TODO: Initialize to an appropriate value
            actual = grid.GetFreeStartingSquares(lenght, orientation);
            Assert.IsNull(GetSquare(actual, 3, 3));
            Assert.IsNull(GetSquare(actual, 3, 4));
            Assert.IsNull(GetSquare(actual, 3, 5));
            Assert.IsNull(GetSquare(actual, 2, 2));
            Assert.IsNull(GetSquare(actual, 4, 6));


            Assert.AreEqual(55, actual.Length);
        }

            //Assert.IsNotNull(GetSquare(actual, 5, 2));
            //Assert.IsNull(GetSquare(actual, 7, 0));


        private Square GetSquare(Square[] squares, int row, int column) {

            foreach (Square square in squares) {

                if (square.Row == row && square.Column == column)
                    return square;
            }
            return null;
        }
    }
}
