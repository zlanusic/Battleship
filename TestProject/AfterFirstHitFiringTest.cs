using Vsite.Battleship;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for AfterFirstHitFiringTest and is intended
    ///to contain all AfterFirstHitFiringTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AfterFirstHitFiringTest
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
            EnemyGrid grid = new EnemyGrid();
            Square firstSquareHit = grid.GetSquare(9, 0);
            //firstSquareHit.Occupy();
            int targetShipLength = 5;
            AfterFirstHitFiring tactics = new AfterFirstHitFiring(grid, firstSquareHit, targetShipLength);
            Square nextTarget = tactics.NextTarget();
            Assert.IsTrue(nextTarget == grid.GetSquare(9, 1) || nextTarget == grid.GetSquare(8, 0));

            Assert.IsFalse(nextTarget == grid.GetSquare(9, 0));
            Assert.IsFalse(nextTarget == grid.GetSquare(8, 1));


            firstSquareHit = grid.GetSquare(3, 3);
            //firstSquareHit.Occupy();
            tactics = new AfterFirstHitFiring(grid, firstSquareHit, targetShipLength);
            nextTarget = tactics.NextTarget();
            Assert.IsTrue(nextTarget == grid.GetSquare(3, 2) || nextTarget == grid.GetSquare(2, 3) 
                          || nextTarget == grid.GetSquare(3, 4) || nextTarget == grid.GetSquare(4, 3));

            Assert.IsFalse(nextTarget == grid.GetSquare(3, 3));
        }
    }
}
