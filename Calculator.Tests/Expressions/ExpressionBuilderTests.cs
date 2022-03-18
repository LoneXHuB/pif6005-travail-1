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
    public class ExpressionBuilderTests
    {
        public ExpressionBuilder builder;

        [TestInitialize]
        public void Init()
        {
            builder = new ExpressionBuilder(1);
        }
        [TestMethod()]
        public void Operate_number_Test()
        {
            var _n = new Number(1);
            //actual expression is built with the builder
            builder.Operate(_n.Calculate(), "+");
            var _actual = builder.Build();

            //expcted expression is built manually via already tested methods
            var _expct = new Expression(1);
            _expct.Push(_n, "+");

            Assert.AreEqual(_actual.ToString(), _expct.ToString());
        }

        [TestMethod()]
        public void Operate_builder_Test()
        {
            var _n = new Number(1);
            //actual is built with the builder
            builder.Operate(builder, "+");
            var _actual = builder.Build();
            var _expct = new Expression(1);
            _expct.Push(_n, "+");

            Assert.AreEqual(_actual.ToString(), _expct.ToString());
        }
    }
}