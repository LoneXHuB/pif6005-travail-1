using Calculatrice.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice.Expressions
{
    public class Number : IExpression
    {
        private int Value { get; set; }

        public Number(int a) { Value = a; }

        public int Calculate() => Value;

        public void Accept(IExpressionVisitor visitor) => visitor.Visit(this);

        public string ToString(bool parenthesis) => Value.ToString();
    }
}
