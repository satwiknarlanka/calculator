using System;
using Xunit;
using business;
using FluentAssertions;

namespace tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Calculator_GivenOnlyOperatorsPlusMinus_ReturnsEvaluatedExpression_Success()
        {
            // Arrange
            var expression = "2+3-1+4";

            // Act
            var sut = new Calculator();
            var result = sut.Calculate(expression);

            // Assert
            result.Should().Be(8);
        }

        [Fact]
        public void Calculator_GivenOnlyOperators_ReturnsEvaluatedExpression_Success()
        {
            // Arrange
            var expression = "3+3*2+4";

            // Act
            var sut = new Calculator();
            var result = sut.Calculate(expression);

            // Assert
            result.Should().Be(13);
        }
    }
}
