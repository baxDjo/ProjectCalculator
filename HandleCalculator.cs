using ProjectCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectCalculator
{
    public class HandleCalculator : IEvaluateExpression, IParserData
    {
        private string data;

        public int EvaluateExpression(string input)
        {
            //prend en parametre l'expression et retourne le resultat 
            Stack<int> operands = new Stack<int>();
            Stack<string> operators = new Stack<string>();
            var input_parsed = ParseData(input);
            var priorities = new Dictionary<string, int>
            {
                ["*"] = 2,
                ["/"] = 2,
                ["-"] = 1,
                ["+"] = 1
            };
            string currentOperator = "";
            int a = 0;
            int b = 0;
            int result = 0;

            foreach (var item in input_parsed)
            {
                if (int.TryParse(item, NumberStyles.Integer, CultureInfo.InvariantCulture, out int value))
                {
                    operands.Push(int.Parse(item));
                }
                else
                {
                    while (operators.Count > 0 && (priorities[operators.Peek()] > priorities[item]))
                    {
                        a = operands.Pop();
                        b =  operands.Pop();
                        currentOperator = operators.Peek();
                        operators.Pop();
                        result = Apply_operation(a, b, currentOperator);
                        operands.Push(result);

                        
                    }
                    operators.Push(item);
                }
            }

            while (operators.Count > 0)
            {
                a = operands.Pop();
                b = operands.Pop();
                currentOperator = operators.Peek();
                operators.Pop();
                result = Apply_operation(a, b, currentOperator);
                operands.Push(result);

            }

            return operands.Peek();
        }

        public List<string> ParseData(string input)
        {
            // cette fonction capture les pattern et les converti en list
            var pattern = @"[+\-]?\d+|[()*/+\-]";

            return Regex.Matches(input, pattern)
                        .Cast<Match>()
                        .Select(m => m.Value)
                        .ToList();
        }

        /* fonction privee qui permet d'effectuer le calcul en fonctione de l'operateur */
        private static int Apply_operation(int a, int b, string op)
        {
            switch (op)
            {
                case "+": return a + b;
                case "-": return b - a;
                case "*": return a * b;
                case "/":
                    if (b == 0) throw new DivideByZeroException("Division by zero is  forbiden.");
                    return b / a;
                default:
                    throw new InvalidOperationException($"Unsupported operator '{op}'.");
            }
        }

    }
}
