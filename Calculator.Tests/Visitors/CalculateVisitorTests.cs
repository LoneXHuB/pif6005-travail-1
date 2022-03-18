using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculatrice.Visitors;
using Calculatrice.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice.Visitors
{
    [TestClass()]
    public class CalculateVisitorTests
    {
        internal Number number;
        internal Expression expression;
        internal CalculateVisitor calculateVisitor;
        [TestInitialize]
        public void init()
        {
            number = new Number(1);
            expression = new Expression(1);
            expression.Push(number, "+");
            calculateVisitor = new CalculateVisitor();
        }

        [TestMethod()]
        public void Visit_Number_Test()
        {
            calculateVisitor.Visit(number);
            var _expct = 1;
            var _actual = calculateVisitor.Result;

            Assert.AreEqual(_expct, _actual);
        }

        [TestMethod()]
        public void Visit_Expression_Test()
        {
            calculateVisitor.Visit(expression);
            var _expct = 2;
            var _actual = calculateVisitor.Result;

            Assert.AreEqual(_expct, _actual);
        }
    }
}