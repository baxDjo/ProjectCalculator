// See https://aka.ms/new-console-template for more information
using ProjectCalculator;

Console.WriteLine("Hello, World!");


HandleCalculator handleCalculator = new HandleCalculator();

//string input =  "3 + 5 * 2 - 4 / 2";
//string input = "1 * 4 * 2 * 2 - 2";
string input = "9 - 8";

//Console.WriteLine(handleCalculator.ParseData(input));


Console.WriteLine(handleCalculator.EvaluateExpression(input));