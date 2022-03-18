using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculatrice.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice.Expressions
{
    [TestClass()]
    public class ExpressionTests
    {
        Expression expression;
        [TestInitialize()]
        public void Init()
        {
            expression = new Expression(1);
        }
        [TestMethod()]
        public void Calculate_Test()
        {
            var _operand = new Number(1);
            var _operator = "+";
            expression.Push(_operand, _operator);

            var _expct = 2;
            var _actual = expression.Calculate();

            Assert.AreEqual(_expct, _actual);
        }

        [TestMethod()]
        public void Calculate_Test_complex()
        {
            var _operand1 = new Number(4);
            var _operand2 = new Number(5);
            var _operator1 = "+";
            var _operator2 = "-";

            expression.Push(_operand1, _operator1);
            expression.Push(_operand2, _operator2);

            var _expct = 0;
            var _actual = expression.Calculate();

            Assert.AreEqual(_expct, _actual);
        }

        [TestMethod()]
        public void ToString_Test()
        {
            var _operand1 = new Number(4);
            var _operand2 = new Number(5);
            var _operator1 = "+";
            var _operator2 = "-";

            expression.Push(_operand1, _operator1);
            expression.Push(_operand2, _operator2);

            var _expct = "1 + 4 - 5";
            var _actual = expression.ToString(false);

            Assert.AreEqual(_expct, _actual);
            _expct = "(1 + 4 - 5)";
            _actual = expression.ToString(true);

            Assert.AreEqual(_expct, _actual);
        }
    }
}