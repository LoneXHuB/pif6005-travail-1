using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculatrice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calculatrice
{
    [TestClass()]
    public class PostfixGeneratorTests
    {
        Calculator calculator;
        [TestInitialize]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TestMethod()]
        public void GeneratePostfix_Test()
        {
            var _test = "2 * 4 + 3 - 15 / 2";
            var _expct = "2 4 * 3 + 15 - 2 /";

            var _actual = String.Join(" ", PostfixGenerator.GeneratePostfix(_test).ToArray());

            Assert.AreEqual(_expct, _actual);
        }

        [TestMethod()]
        public void GeneratePostfix_Test2()
        {
            var _test = "2 / 4";
            var _expct = "2 4 /";

            var _actual = String.Join(" ", PostfixGenerator.GeneratePostfix(_test).ToArray());

            Assert.AreEqual(_expct, _actual);
        }

        [TestMethod()]
        public void Calculate_Test()
        {
            var _test = PostfixGenerator.GeneratePostfix("2 / 4 * 4");
            var _expct = 8;
            var _actual = PostfixGenerator.Calculate(_test);

            Assert.AreEqual(_expct, _actual);
        }

        [TestMethod()]
        public void Calculate_Test2()
        {
            var _test = PostfixGenerator.GeneratePostfix("2 * 4 + 4 * 2");
            var _expct = 24;
            var _actual = PostfixGenerator.Calculate(_test);

            Assert.AreEqual(_expct, _actual);
        }

        [TestMethod()]
        public void IsPostfix_Test_true()
        {
            var _test = PostfixGenerator.GeneratePostfix("5 + 5 + 1");
            Assert.IsTrue(PostfixGenerator.IsPostfix(_test));
        }

        [TestMethod()]
        public void CalculateNumber_Test()
        {
            var _test = PostfixGenerator.GeneratePostfix("5 + 5 + 1");
            var _expct = "11";
            var _actual = PostfixGenerator.CalculateNumber(_test);

            Assert.AreEqual( _expct, _actual);  
        }
    }
}