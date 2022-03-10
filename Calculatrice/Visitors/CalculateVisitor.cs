using Calculatrice.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice.Visitors
{
    public class CalculateVisitor : IExpressionVisitor
    {
        public int Result { get; set; }

        public Stack<Operand> values = new Stack<Operand>();

        public Stack<Operator> operators = new Stack<Operator>();

        public void Visit(Operand _val) => values.Push(_val);

        public void Visit(CompositeExpression _expr)
        {
            operators.Push(_expr.Operator);
            CalculateResult();
        }

        public void CalculateResult()
        {
            if(values.Count < 2) return;
            if (operators.Count == 0) return;

            var _operator = operators.Pop();
            var _n1 = values.Pop().GetValue();
            var _n2 = values.Pop().GetValue();

            switch (_operator)
            {
                case Operator.ADD:
                    Result = _n2 + _n1;
                    break;
                case Operator.SUB:
                    Result = _n2 - _n1;
                    break;
                case Operator.DIV:
                    Result = _n2 / _n1;
                    break;
                case Operator.MUL:
                    Result = _n2 * _n1;
                    break;
                default:
                    throw new InvalidOperationException();
            }

            values.Push(new Operand(Result));
        }
    }
}
