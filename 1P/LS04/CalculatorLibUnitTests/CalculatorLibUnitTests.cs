using System;
using Xunit;
using CalculatorLib;

namespace CalculatorLibUnitTests
{
    public class CalculatorLibUnitTests
    {
        // Arrange : Declare variables and instantiate for input and output
        // Act : Call the method i want to test.
        // Assert : This part make one or more assertions about the ouput.
        // Adding 2 and 2 , we EXPECT result to be 4.
        
        [Fact]
        public void TestAdding2And2()
        {
            // Arrange
            double a = 2;
            double b = 2;
            double expected = 4;
            var calc = new Calculator();
            // Act
            double actual = calc.Add(a,b);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestingAdd2And3()
        {
            // Arrange
            double a = 2;
            double b = 3;
            double expected = 5;
            var calc = new Calculator();
            // Act
            double actual = calc.Add(a, b);
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
