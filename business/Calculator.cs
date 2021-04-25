using System;
using System.Linq;
using System.Collections.Generic;

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
            var result = EvaluateArithematic(expression);
            return result;
        }


        /// <summary>
        /// Traverses from left to right.
        /// Stores numbers in a list.
        /// When it encounter an operation it stores that in a variable
        /// When it encounters another operation it computes the new value
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
                if (CheckIfInteger(element))
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

            static bool CheckIfInteger(char element)
            {
                return int.TryParse(new char[] { element }, out var temp);
            }
        }

        /// <summary>
        /// 
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
