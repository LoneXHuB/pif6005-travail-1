using Calculatrice.Expressions;
using Calculatrice.Visitors;
using System;

namespace Calculatrice
{
    public class Calculator
    {
        public int Calculate(string input)
        {
            var _eBuilder = new ExpressionBuilder(input);
            var _expression = _eBuilder.Build();

           return Calculate(_expression);
        }

        public int Calculate(IExpression expr)
        {
            var _calcVisitor = new CalculateVisitor();
            Visit(expr, _calcVisitor);
            return _calcVisitor.Result;
        }

        public void Visit(IExpression expr, IExpressionVisitor visitor) => expr.Accept(visitor);
    }
}
