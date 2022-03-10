using Calculatrice.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice.Expressions
{
    public class Expression : IExpression
    {
        private readonly List<IExpression> expressions = new();
        private readonly List<string> operators = new();

        public Expression(int i) => expressions.Add(new Number(i));
        public int Calculate()
        {
            var strNumbers = new List<string>();
            foreach(IExpression e in expressions) strNumbers.Add(e.Calculate().ToString());
            var postfix = strNumbers.Reverse<string>().Concat(operators);
            return PostfixGenerator.Calculate(postfix);
        }
        public void Push(IExpression n, string o)
        {
            expressions.Add(n);
            operators.Add(o);
        }
        public void Accept(IExpressionVisitor visitor) => visitor.Visit(this);
        public string ToString(bool parenthesis)
        {
            var rslt = "";
            int i = 0;
            if (parenthesis) rslt += "(";

            foreach (IExpression e in expressions)
            {
                rslt += e.ToString(true);
                if (i < operators.Count) rslt += " "+operators[i]+" ";
                i++;
            }

            if (parenthesis) rslt += ")";
            return rslt;
        }
    }
}
