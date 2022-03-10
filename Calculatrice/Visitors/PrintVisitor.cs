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

        public void Visit(Number n) => result = n.ToString(false);

        public void Visit(Expression e) => result = e.ToString(false);
    }
}
