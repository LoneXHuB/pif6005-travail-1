using Calculatrice.Expressions;
using Calculatrice.Visitors;
using System;

namespace Calculatrice
{
    public class Calculator
    {
        public int Calculate(string input) => Calculate(new ExpressionBuilder(input).Build());

        public int Calculate(IExpression expr) => expr.Calculate();

        public void Visit(IExpression expr, IExpressionVisitor visitor) => expr.Accept(visitor);
    }
}
