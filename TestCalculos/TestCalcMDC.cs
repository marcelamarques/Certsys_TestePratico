using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCalculos
{
    /// <summary>
    /// Summary description for TestCalcMDC
    /// </summary>
    [TestClass]
    public class TestCalcMDC
    {
        public TestCalcMDC()
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
        public void TestCalculoMDC()
        {
            Calculos.Calculos calculos = new Calculos.Calculos();
            double calc = calculos.TestCalcDistMax(3, 11);
            int reforco = calculos.TestCalcPilarReforco(calc, 10);
            Assert.AreEqual(2.75, calc);
        }

        [TestMethod]
        public void TestCalcReforco()
        {
            Calculos.Calculos calculos = new Calculos.Calculos();
            int reforco = calculos.TestCalcPilarReforco(2.75, 10);
            Assert.AreEqual(3, reforco);
        }
    }
}
