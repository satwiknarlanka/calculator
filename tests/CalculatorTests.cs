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
            var expression = "2+3-1";

            // Act
            var sut = new Calculator();
            var result = sut.Calculate(expression);

            // Assert
            result.Should().Be(4);
        }
    }
}
