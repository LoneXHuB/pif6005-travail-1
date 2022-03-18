using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculatrice.Simple;

namespace CalculatriceTests.Simple
{
    [TestClass]
    public class SimpleTests
    {
        SimpleCalculator calculator;

        [TestInitialize]
        public void Init()
        {
            calculator = new SimpleCalculator();
        }

        [TestMethod]
        public void TestDiv()
        {
            //preparation
            int _a = 4;
            int _b = 2;
            int _r = 2;

            //Assert
            Assert.AreEqual(_r, calculator.Div(_a, _b));
        }
    }
}
