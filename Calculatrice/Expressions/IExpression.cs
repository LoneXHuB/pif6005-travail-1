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
        public void Accept(IExpressionVisitor _visitor);
    }
}
