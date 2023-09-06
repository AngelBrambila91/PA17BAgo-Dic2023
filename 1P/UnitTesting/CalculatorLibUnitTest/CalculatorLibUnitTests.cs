namespace CalculatorLibUnitTest;
using CalculatorLib;

public class CalculatorLibUnitTests
{
    // 3 Parts
    // Arrange : Declare all the necessary to test the function
    // Act : Call the function to test
    // Assert : Check if the expected result and the actual result are the same
    [Fact] // Annotations
    public void TestingAdd2And2()
    {
        // arrange
        double a = 2;
        double b = 2;
        double expected = 4;
        Calculator calc = new();
        // act
        double actual = calc.Add(a,b);
        // Assert
        Assert.Equal(expected, actual);
    }

        [Fact] // Annotations
    public void TestingAdd2And3()
    {
        // arrange
        double a = 2;
        double b = 3;
        double expected = 5;
        Calculator calc = new();
        // act
        double actual = calc.Add(a,b);
        // Assert
        Assert.Equal(expected, actual);
    }
}