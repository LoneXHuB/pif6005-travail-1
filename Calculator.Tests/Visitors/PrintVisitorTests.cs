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
    public class PrintVisitorTests
    {
        internal Number number;
        internal Expression expression;
        internal PrintVisitor printVisitor;
        [TestInitialize]
        public void init()
        {
            number = new Number(1);
            expression = new Expression(1);
            expression.Push(number, "+");
            printVisitor = new PrintVisitor();
        }

        [TestMethod()]
        public void Visit_Number_Test()
        {
            printVisitor.Visit(number);
            var _expct = "1";
            var _actual = printVisitor.ToString();

            Assert.AreEqual(_expct, _actual);
        }

        [TestMethod()]
        public void Visit_Expression_Test()
        {
            printVisitor.Visit(expression);
            var _expct = "1 + 1";
            var _actual = printVisitor.ToString();

            Assert.AreEqual(_expct, _actual);
        }
    }
}