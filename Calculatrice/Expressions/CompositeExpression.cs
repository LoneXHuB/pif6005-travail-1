using Calculatrice.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice.Expressions
{
    public enum Operator { ADD = '+', SUB = '-', MUL = '*', DIV = '/'}
    public class CompositeExpression : IExpression
    {
        public IExpression A { get; private set; }
        public IExpression B { get; private set; }
        public Operator Operator { get; private set; }
        public bool Priority { get; set; }

        public CompositeExpression(IExpression _a) => A = _a;

        public CompositeExpression(IExpression _a, IExpression _b, Operator _operator) : this(_a)
        {
            B = _b;
            Operator = _operator;
        }
        public CompositeExpression(IExpression _a, IExpression _b, Operator _operator , bool _priority) : this (_a,_b,_operator)
        {
            Priority = _priority;
        }

        public void Accept(IExpressionVisitor _visitor)
        {
            if (A != null) A.Accept(_visitor);
            else return;
            if (B != null) B.Accept(_visitor);
            else return;

            _visitor.Visit(this);
        }

        public override string ToString()
        {
            var _a = A.ToString();
            var _b = B.ToString();

            var _brkt1 = Priority ? "(" : "";
            var _brkt2 = Priority ? ")" : "";

            return $"{_brkt1}{_a} {(char)Operator} {_b}{_brkt2}";
        }
    }
}
