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
    public class HandleCalculator : IEvaluateExpression
    {


        /// <summary>
        /// Cette fonction prend en entrée une expression arithmétique et retourne le resultat.
        /// </summary>
        /// <param name="input">Chaîne contenant l'expression arithmétique.</param>
        /// <returns>resultat du calcul.</returns>
        /// <exception cref="ArgumentNullException">Si <paramref name="input"/> est null.</exception>
        public string EvaluateExpression(string input)
        {
            //prend en parametre l'expression et retourne le resultat 
            Stack<int> operands = new Stack<int>();
            Stack<string> operators = new Stack<string>();
            var input_parsed = ParseData(input);
            var priorities = new Dictionary<string, int>
            {   
                ["^"] = 3,
                ["*"] = 2,
                ["/"] = 2,
                ["-"] = 1,
                ["+"] = 1
            };
            string currentOperator = "";
            string finalResult = "";
            int a = 0;
            int b = 0;
            int result = 0;
            foreach (var item in input_parsed)
            {
                if (int.TryParse(item, NumberStyles.Integer, CultureInfo.InvariantCulture, out int value))
                {

                    operands.Push(int.Parse(item));
                }
                else if (item == "(")
                {
                    operators.Push(item);
                }

                else if (item == ")")
                {
                    while (operators.Peek() != "(")
                    {
                        a = operands.Pop();
                        b = operands.Pop();
                        currentOperator = operators.Peek();
                        operators.Pop();
                        result = Apply_operation(a, b, currentOperator);
                        operands.Push(result);
                    }
                    if (operators.Count > 0 && operators.Peek() == "(")
                        operators.Pop();
                }
                else
                {
                    while (operators.Count > 0 && operators.Peek() != "(" && (priorities[operators.Peek()] > priorities[item]))
                    {
                            var currentPeek = operators.Peek();
                            a = operands.Pop();
                            b = operands.Pop();
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
            finalResult = operands.Peek().ToString();
            return finalResult;
        }


        /// <summary>
        /// Cette fonction utilise le regex pour diviser une expression arithmétique en nombres signés et opérateurs).
        /// </summary>
        /// <param name="input">Chaîne à analyser.</param>
        /// <returns>Liste des éléments trouvés.</returns>
        /// <exception cref="ArgumentNullException">Si <paramref name="input"/> est null.</exception>
        public  List<string> ParseData(string input)
        {
            // cette fonction capture les pattern et les converti en list
            var pattern = @"[+\-]?\d+|[()^*/+\-]";
            return Regex.Matches(input, pattern)
                        .Cast<Match>()
                        .Select(m => m.Value)
                        .ToList();
        }


        /// <summary>
        /// fonction privee qui permet d'effectuer le calcul en fonctione de l'operateur .
        /// </summary>
        /// <param name="input">Chaîne à analyser.</param>
        /// <returns>Liste des tokens trouvés.</returns>
        /// <exception cref="ArgumentNullException">Si <paramref name="input"/> est null.</exception>
        private static int Apply_operation(int a, int b, string op)
        {
            switch (op)
            {
                case "+": return a + b;
                case "-": return b - a;
                case "*": return a * b;
                case "^": return (int)Math.Pow(b,a);
                case "/":
                    if (a == 0) throw new DivideByZeroException("Division by zero is  forbiden.");
                    return b / a;
                default:
                    throw new InvalidOperationException($"Unsupported operator '{op}'.");
            }
        }
    }
    
}
