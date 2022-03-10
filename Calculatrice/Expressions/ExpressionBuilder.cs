using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculatrice.William;

namespace Calculatrice.Expressions
{
    public class ExpressionBuilder
    {
        private IExpression expression;

        public ExpressionBuilder(int initial) => expression = new Operand(initial);
        public ExpressionBuilder(string expr) : this(expr, false) { }
        public ExpressionBuilder(string expr , bool _priority)
        {
            var postfix = PostfixGenerator.GeneratePostfix(expr);
            var stack = new Stack<int>();
            var _first = int.Parse(postfix.First());

            expression = new Operand(_first);
            for(int i = 1; i < postfix.Count(); i++)
            {
                var token = postfix.ElementAt(i);
                if (int.TryParse(token, out var _value))
                    stack.Push(_value);
                else
                {
                    var n = stack.Pop();
                    var _operator = (Operator)(token.ToCharArray()[0]);
                    expression = new CompositeExpression(expression, new Operand(n), _operator , _priority);
                }
            }
        }

        public void Add(int n) => expression = new CompositeExpression(expression, new Operand(n), Operator.ADD);

        public void Add(ExpressionBuilder e) => expression = new CompositeExpression(expression, e.Build(true), Operator.ADD);

        public void Subtract(int n) => expression = new CompositeExpression(expression, new Operand(n), Operator.SUB);

        public void Subtract(ExpressionBuilder e) => expression = new CompositeExpression(expression, e.Build(true), Operator.SUB);

        public void Multiply(int n) => expression = new CompositeExpression(expression, new Operand(n), Operator.MUL);

        public void Multiply(ExpressionBuilder e) => expression = new CompositeExpression(expression, e.Build(true), Operator.MUL);

        public void Divide(int n) => expression = new CompositeExpression(expression, new Operand(n), Operator.DIV);

        public void Divide(ExpressionBuilder e) => expression = new CompositeExpression(expression, e.Build(true), Operator.DIV);

        public IExpression Build() => expression;
        public IExpression Build(bool _priority) { ((CompositeExpression)expression).Priority = true; return expression; }
    }
}
