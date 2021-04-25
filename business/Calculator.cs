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

                    operation = element;
                    number = new List<char>();
                }
            }
            result.Add(GetNum(number));
            
            return result.Sum();

            static int GetNum(List<char> number)
            {
                return int.Parse(number.ToArray());
            }

            static bool CheckIfInteger(char element)
            {
                return int.TryParse(new char[] { element }, out var temp);
            }
        }

    }
}
