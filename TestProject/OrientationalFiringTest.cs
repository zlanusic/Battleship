using Vsite.Battleship;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for OrientationalFiringTest and is intended
    ///to contain all OrientationalFiringTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OrientationalFiringTest
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
        ///A test for NextTarget
        ///</summary>
        [TestMethod()]
        public void NextTargetTest()
        {
            // test for a horizontal ship in the middle of playground
            EnemyGrid grid = new EnemyGrid();
            Square sq1 = grid.GetSquare(3, 3);
            Square sq2 = grid.GetSquare(3, 4);
            Square sq3 = grid.GetSquare(3, 5);
            Square[] squaresHit = new Square[] { sq1, sq2, sq3 };
            int targetShipLength = 4;
            OrientationalFiring tactics = new OrientationalFiring(grid, squaresHit, targetShipLength); 
            Square next = tactics.NextTarget();
            Assert.IsTrue(next.Row == 3 && (next.Column == 2 || next.Column == 6));
            
            // now occupy a square at one of ends
            grid.GetSquare(3, 2).Occupy();
            next = tactics.NextTarget();
            Assert.IsTrue(next.Row == 3 && next.Column == 6);

            // test for a vertical ship at the bottom of playground
            grid = new EnemyGrid();
            sq1 = grid.GetSquare(7, 1);
            sq2 = grid.GetSquare(8, 1);
            sq3 = grid.GetSquare(9, 1);
            squaresHit = new Square[] { sq1, sq2, sq3 };
            targetShipLength = 4;
            tactics = new OrientationalFiring(grid, squaresHit, targetShipLength);
            next = tactics.NextTarget();
            Assert.IsTrue(next.Row == 6 && next.Column == 1);

            // test for a vertical ship in the middle of playground
            grid = new EnemyGrid();
            sq1 = grid.GetSquare(3, 1);
            sq2 = grid.GetSquare(4, 1);
            sq3 = grid.GetSquare(5, 1);
            squaresHit = new Square[] { sq1, sq2, sq3 };
            targetShipLength = 4;
            tactics = new OrientationalFiring(grid, squaresHit, targetShipLength);
            next = tactics.NextTarget();
            Assert.IsTrue((next.Row == 6 || next.Row == 2) && next.Column == 1);

            // now occupy a square at one of ends
            grid.GetSquare(6, 1).Occupy();
            next = tactics.NextTarget();
            Assert.IsTrue(next.Row == 2 && next.Column == 1);

            // test for a vertical ship at the bottom of playground
            grid = new EnemyGrid();
            sq1 = grid.GetSquare(7, 1);
            sq2 = grid.GetSquare(8, 1);
            sq3 = grid.GetSquare(9, 1);
            squaresHit = new Square[] { sq1, sq2, sq3 };
            targetShipLength = 4;
            tactics = new OrientationalFiring(grid, squaresHit, targetShipLength);
            next = tactics.NextTarget();
            Assert.IsTrue(next.Row == 6 && next.Column == 1);

            grid = new EnemyGrid();
            sq1 = grid.GetSquare(3, 1);
            sq2 = grid.GetSquare(5, 1);
            sq3 = grid.GetSquare(4, 1);
            squaresHit = new Square[] { sq1, sq2, sq3 };
            targetShipLength = 4;
            tactics = new OrientationalFiring(grid, squaresHit, targetShipLength);
            tactics.AddNewHit(grid.GetSquare(6, 1));
            next = tactics.NextTarget();
            Assert.IsTrue((next.Row == 7 || next.Row == 2) && next.Column == 1);

        }
    }
}
