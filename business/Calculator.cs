using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace business
{
    public class Calculator
    {
        /// <summary>
        /// Evaluates the mathematical expression.
        /// Assumes the expression will not evalute to a decimal.
        /// No rounding of expression has been taken care of.
        /// </summary>
        /// <param name="expression">string expression to evaluate</param>
        /// <returns>evaulated result</returns>
        public int Calculate(string expression)
        {
            expression = expression.Replace(")(", ")*(");
            var pureExpression = EvalutateBrackets(new StringBuilder(expression));
            return EvaluateArithematic(pureExpression.ToString());
        }

        /// <summary>
        /// Attempts to get a pure expression with brackets
        /// Eg: 1+(2-1)+4 will become 1+1+4
        /// Recursively evalutes all exprssion in brackets
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>Pure expression</returns>
        private StringBuilder EvalutateBrackets(StringBuilder expression)
        {
            // If expression if pure return after evaluating arithematic
            if(!expression.ToString().Contains('('))
            {
                return new StringBuilder($"{EvaluateArithematic(expression.ToString())}");
            }

            var pureExpression = new StringBuilder();
            for(var i=0; i<expression.Length; i++)
            {
                var element = expression[i];
                if (ElementIsPure(element))
                {
                    pureExpression.Append(expression[i]);
                }
                else
                {
                    var bracketCount = 1;
                    var subExpression = new StringBuilder();
                    BracketPreProcessor(expression, pureExpression, i);
                    while (bracketCount != 0 && i < expression.Length)
                    {
                        element = expression[++i];
                        if (element == '(') bracketCount++;
                        if (element == ')') bracketCount--;
                        // Append all elements to sub expression except last closing bracket
                        if (bracketCount != 0) subExpression.Append(element);
                    }
                    pureExpression.Append(EvalutateBrackets(subExpression));
                    BracketPostProcessor(expression, pureExpression, i);
                }
            }
            return pureExpression;
        }

        /// <summary>
        /// Returns true if element is a number or an operator
        /// Returns false if it finds a bracket
        /// </summary>
        /// <param name="element"></param>
        /// <returns>true/false</returns>
        private static bool ElementIsPure(char element)
        {
            return IsNumber(element) || "+-*/".Contains(element);
        }

        /// <summary>
        /// If the element after bracket is a number, append * to the pure expression
        /// Eg: (2+1)3 will become (2+1)*3
        /// </summary>
        private static void BracketPostProcessor(StringBuilder expression, StringBuilder pureExpression, int i)
        {
            if (i < expression.Length - 1)
            {
                var next = expression[i + 1];
                if (IsNumber(next))
                {
                    pureExpression.Append('*');
                }
            }
        }

        /// <summary>
        /// If the element before bracket is a number, append * to the pure expression
        /// Eg: 3(2+1) will become 3*(2+1)
        /// </summary>
        private static void BracketPreProcessor(StringBuilder expression, StringBuilder pureExpression, int i)
        {
            if (i > 0)
            {
                var prev = expression[i - 1];
                if (IsNumber(prev))
                {
                    pureExpression.Append('*');
                }
            }
        }

        /// <summary>
        /// Traverses from left to right.
        /// Stores numbers in a list.
        /// When it encounters an operation it stores that in a variable.
        /// When it encounters another operation it computes the new value 
        /// based on business rules and stores it in the numbers list.
        /// </summary>
        /// <param name="subExpression">expression with numbers and + - * / operators</param>
        /// <returns>evaulated expression</returns>
        private int EvaluateArithematic(string subExpression)
        {
            var result = new List<int>();
            var number = new List<char>();
            char operation = '+';
            foreach(var element in subExpression)
            {
                if (IsNumber(element))
                {
                    number.Add(element);
                }
                else if ("+-*/".Contains(element))
                {
                    UpdateResult(result, number, operation);
                    operation = element;
                    number = new List<char>();
                }
            }

            //Update result for last number
            UpdateResult(result, number, operation);
            
            return result.Sum();
        }

        private static bool IsNumber(char element)
        {
            return int.TryParse(new char[] { element }, out var temp);
        }

        /// <summary>
        /// Appends number with appropriate sign to result list for + - operators
        /// For * / it Multiplies or divides the number with the last element in the result list
        /// </summary>
        /// <param name="result">Result List</param>
        /// <param name="number">char array of current number</param>
        /// <param name="operation">+-*/</param>
        private static void UpdateResult(List<int> result, List<char> number, char operation)
        {
            if (operation == '+')
            {
                result.Add(GetNum(number));
            }
            else if (operation == '-')
            {
                result.Add(-GetNum(number));
            }
            else if (operation == '*')
            {
                result[result.Count - 1] *= GetNum(number);
            }
            else if (operation == '/')
            {
                result[result.Count - 1] /= GetNum(number);
            }
        }

        /// <summary>
        /// Converts character array to int
        /// </summary>
        /// <param name="number">char array</param>
        /// <returns>int</returns>
        private static int GetNum(List<char> number) => int.Parse(number.ToArray());
    }
}
