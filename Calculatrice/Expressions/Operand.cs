using Calculatrice.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice.Expressions
{
    public class Operand : IExpression
    {
        private readonly int value;

        public Operand(int _value) => value = _value;

        public void Accept(IExpressionVisitor _visitor) => _visitor.Visit(this);

        public override string ToString() => value.ToString();

        public int GetValue() => value;
    }
}
