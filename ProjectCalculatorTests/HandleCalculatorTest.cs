using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectCalculator;

namespace ProjectCalculatorTests
{
    [TestClass]
    public class HandleCalculatorTest
    {


        private readonly HandleCalculator _handleCalculator;

        // This acts like a [SetUp] for each test
        public HandleCalculatorTest()
        {
            _handleCalculator = new HandleCalculator();
        }

        [DataTestMethod]
        [DataRow("1 + 2", "3")]    // a = -1, b = 5, expected = 4
        public void EvaluateExpression_Addition_ReturnsExpected(string input, string expected)
        {

            // Act
            string result = _handleCalculator.EvaluateExpression(input);

            // Assert
            Assert.AreEqual(expected, result);
        }


        [DataTestMethod]
        [DataRow("1 - 5", "-4")]    // "1 - 5", expected = -4
        public void EvaluateExpression_Substraction_ReturnsExpected(string input, string expected)
        {

            // Act
            string result = _handleCalculator.EvaluateExpression(input);

            // Assert
            Assert.AreEqual(expected, result);
        }


        [DataTestMethod]
        [DataRow("-1 - 1", "-2")]    // "-1 - 1", expected = -2
        public void EvaluateExpression_AdditionWithSign_ReturnsExpected(string input, string expected)
        {

            // Act
            string result = _handleCalculator.EvaluateExpression(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("-1 - -3", "2")]    // "-1 - -3", expected = "2"
        public void EvaluateExpression_AdditionWithTwoSign_ReturnsExpected(string input, string expected)
        {

            // Act
            string result = _handleCalculator.EvaluateExpression(input);

            // Assert
            Assert.AreEqual(expected, result);
        }



        [DataTestMethod]
        [DataRow("2^3", "8")]    // "2^3", expected = "8"
        public void EvaluateExpression_Power_ReturnsExpected(string input, string expected)
        {

            // Act
            string result = _handleCalculator.EvaluateExpression(input);

            // Assert
            Assert.AreEqual(expected, result);
        }


        [DataTestMethod]
        [DataRow("2^3 + 4", "12")]    // "2^3 + 4", expected = "12"
        public void EvaluateExpression_PowerAndPriority_ReturnsExpected(string input, string expected)
        {

            // Act
            string result = _handleCalculator.EvaluateExpression(input);

            // Assert
            Assert.AreEqual(expected, result);
        }


        [DataTestMethod]
        [DataRow("5 * 2 - 1", "9")] // "5 * 2 - 1", expected = "9"
        public void EvaluateExpression_MultiplicationAndPriority_ReturnsExpected(string input, string expected)
        {

            // Act
            string result = _handleCalculator.EvaluateExpression(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("3 + 5 * 2 - 4 / 2", "11")] // "3 + 5 * 2 - 4 / 2", expected = "11"
        public void EvaluateExpression_DivisionnAndPriority_ReturnsExpected(string input, string expected)
        {

            // Act
            string result = _handleCalculator.EvaluateExpression(input);

            // Assert
            Assert.AreEqual(expected, result);
        }


        [DataTestMethod]
        [DataRow("5*2", "10")] // "5*2", expected = "10"
        public void EvaluateExpression_Multiplication_ReturnsExpected(string input, string expected)
        {

            // Act
            string result = _handleCalculator.EvaluateExpression(input);

            // Assert
            Assert.AreEqual(expected, result);
        }


        [DataTestMethod]
        [DataRow("10/2", "5")] // "10/2"", expected = "5"
        public void EvaluateExpression_Division_ReturnsExpected(string input, string expected)
        {

            // Act
            string result = _handleCalculator.EvaluateExpression(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

    }
}