using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice.William
{
    public class PostfixGenerator
    {
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
    }
}
