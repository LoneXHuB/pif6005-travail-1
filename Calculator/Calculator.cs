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

        public bool IsPostfix(IExpression expr)
        {
            if (expr is Number) return true;

            var _visitor = new PrintVisitor();
            _visitor.Visit(expr as Expression);
            var _strExpr = _visitor.ToString();

            var _postfix = PostfixGenerator.GeneratePostfix(_strExpr);
            return PostfixGenerator.IsPostfix(_postfix);
        }
    }
}
