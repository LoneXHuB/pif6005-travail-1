using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculatrice.Visitors;

namespace Calculatrice.Expressions
{
    public interface IExpression
    {
        public int Calculate();
        public string ToString(bool parenthesis);
        public void Accept(IExpressionVisitor visitor);
    }
}
