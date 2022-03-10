using Calculatrice.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice.Visitors
{
    public class PrintVisitor : IExpressionVisitor
    {
        private string result;

        public override string ToString() => result;

        public void Visit(Operand _val) => result = _val.ToString();

        public void Visit(CompositeExpression _expr) => result = _expr.ToString();
    }
}
