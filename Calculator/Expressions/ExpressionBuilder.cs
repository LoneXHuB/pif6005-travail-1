using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice.Expressions
{
    public class ExpressionBuilder
    {
        private Expression expression;
        public ExpressionBuilder(int initial) { expression = new Expression(initial); }
        public ExpressionBuilder(string input)
        {
            var tokens = input.Split(' ');

            expression = new Expression(int.Parse(tokens[0]));
            var op = "";
            foreach (var token in tokens.Skip(1))
            {
                if (int.TryParse(token, out var i))
                    expression.Push(new Number(i), op);
                else
                    op = token;
            }
        }

        public void Operate(int n, string op) => expression.Push(new Number(n), op);
        public void Operate(ExpressionBuilder e, string op) => expression.Push(e.Build(), op);
        public void Add(int n) => Operate(n, "+");
        public void Add(ExpressionBuilder e) { Operate(e, "+"); }
        public void Subtract(int n) => Operate(n, "-");
        public void Subtract(ExpressionBuilder e) { expression.Push(e.Build(), "-"); }
        public void Multiply(int n) => Operate(n, "*");
        public void Multiply(ExpressionBuilder e) { expression.Push(e.Build(), "*"); }
        public void Divide(int n) => Operate(n, "/");
        public void Divide(ExpressionBuilder e) { expression.Push(e.Build(), "/"); }

        public IExpression Build() => expression;
    }
}
