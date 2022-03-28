using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculatrice.Expressions;

namespace Calculatrice
{
    public class PostfixGenerator
    {
        private static Number number;
        
        public static string CalculateNumber(IEnumerable<string> postfix)
        {
            var _result = Calculate(postfix);
            number = new Number(_result);

            return number.ToString(true);
        }

        public static bool IsPostfix(IEnumerable<String> input)
        {
            var _it = 0;
            var _lastWasNum = false;
            foreach(var token in input)
            { 
                if (int.TryParse(token, out var _))
                {
                    if (_it > 1 && _lastWasNum) return false;
                    _lastWasNum = true;
                }
                else
                {
                    if (!_lastWasNum) return false; 
                    _lastWasNum = false;
                    if (_it == 0) return false;
                }
                _it++; 
            }

            return true;
        }
    
        public static IEnumerable<string> GeneratePostfix(string input)
        {
            var postfixStack = new Stack<string>();
            var operatorStack = new Stack<string>();

            var tokens = input.Split(' ');
            postfixStack.Push(tokens[0]);

            foreach (var token in tokens.Skip(1))
            {
                if (int.TryParse(token, out var _))
                {
                    postfixStack.Push(token);
                    if (operatorStack.Any())
                        postfixStack.Push(operatorStack.Pop());
                }
                else
                {
                    operatorStack.Push(token);
                }
            }

            return postfixStack.Reverse();
        }

        public static int Calculate(IEnumerable<string> postfix)
        {
            var stack = new Stack<int>();

            foreach (var token in postfix)
            {
                if (int.TryParse(token, out var i))
                    stack.Push(i);
                else
                {
                    var n2 = stack.Pop();
                    var n1 = stack.Pop();
                    int result;
                    switch (token)
                    {
                        case "+":
                            result = n2 + n1;
                            break;
                        case "-":
                            result = n2 - n1;
                            break;
                        case "/":
                            result = n2 / n1;
                            break;
                        case "*":
                            result = n2 * n1;
                            break;
                        default:
                            throw new InvalidOperationException();
                    }

                    stack.Push(result);
                }
            }

            return stack.Pop();
        }
    }
}
