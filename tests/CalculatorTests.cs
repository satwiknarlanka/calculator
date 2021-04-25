using System;
using Xunit;
using business;
using FluentAssertions;

namespace tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData("2+3-1+4", 8)]
        [InlineData("50+29-4", 75)]
        [InlineData("4+20-10+4", 18)]
        public void Calculator_GivenOnlyOperatorsPlusMinus_ReturnsEvaluatedExpression_Success(string expression, int expected)
        {
            // Act
            var sut = new Calculator();
            var result = sut.Calculate(expression);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("3+3*2+4", 13)]
        [InlineData("3*3*2+4", 22)]
        [InlineData("30*3-2+4", 92)]
        [InlineData("3+8*2/4", 7)]
        public void Calculator_GivenOnlyOperators_ReturnsEvaluatedExpression_Success(string expression, int expected)
        {
            // Act
            var sut = new Calculator();
            var result = sut.Calculate(expression);

            // Assert
            result.Should().Be(expected);
        }
    }
}
