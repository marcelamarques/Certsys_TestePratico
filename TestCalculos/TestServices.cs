using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Certsys.Domain;

namespace TestCalculos
{
    /// <summary>
    /// Summary description for TestServices
    /// </summary>
    [TestClass]
    public class TestServices
    {
        public TestServices()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestDistancePilars()
        {
            double dist = Certsys.Services.CalculatePilars.CalculateDistPilars(3, 11);
            double reforco = Certsys.Services.CalculatePilars.CalculateReinforcementPilar(dist, 10);
            int numPiliar = (int)(11 / dist);
            List<Pilar> pilars = Certsys.Services.CalculatePilars.GetPilars(numPiliar, dist);
            List<Pilar> pilarsRef = Certsys.Services.CalculatePilars.SetPilarReinforced(reforco, pilars);
            List<Pilar> pilwhere = Certsys.Services.CalculatePilars.GetPilarsReinforced(pilarsRef);
            Assert.AreEqual(2.75, dist);
            Assert.AreEqual(2.75*3, reforco);

        }
    }
}
