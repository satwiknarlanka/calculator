using System;
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
            var result = EvaluatePlusMinus(expression.ToCharArray());
            return result;
        }

        private int EvaluatePlusMinus(char[] subExpression)
        {
            var computedValue = 0;
            var number = new List<char>();
            var operation = 1;
            foreach(var element in subExpression)
            {
                if(element == '+')
                {
                    computedValue += int.Parse(number.ToArray()) * operation;;
                    operation = 1;
                    number = new List<char>();
                }
                else if(element == '-')
                {
                    computedValue += int.Parse(number.ToArray()) * operation;
                    operation = -1;
                    number = new List<char>();
                }
                else
                {
                    number.Add(element);
                }
            }
            
            computedValue += int.Parse(number.ToArray()) * operation;
            return computedValue;
        }
    }
}
