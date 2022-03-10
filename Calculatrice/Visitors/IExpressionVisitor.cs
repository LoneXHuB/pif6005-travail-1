using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculatrice.Expressions;

namespace Calculatrice.Visitors
{
    public interface IExpressionVisitor
    {
        public void Visit(Operand _op);
        public void Visit(CompositeExpression _expr);
    }
}
