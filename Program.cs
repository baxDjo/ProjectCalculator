// See https://aka.ms/new-console-template for more information
using ProjectCalculator;

HandleCalculator handleCalculator = new HandleCalculator();

string input = "1 * 4 * 2 * 2 - 2";

Console.WriteLine(handleCalculator.EvaluateExpression(input));