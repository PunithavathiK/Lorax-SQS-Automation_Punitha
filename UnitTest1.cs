using NUnit.Framework;

[TestFixture]
public class CalculatorTests
{
    private Calculator calculator;

    [SetUp]
    public void Setup()
    {
        calculator = new Calculator();
    }

    [Test]
    public void Add_PositiveNumbers_ReturnsCorrectSum()
    {
        double result = calculator.Add(5, 10);
        NUnit.Framework.Assert.AreEqual(15, result, "Addition of positive numbers failed.");
    }

    [Test]
    public void Add_NegativeNumbers_ReturnsCorrectSum()
    {
        double result = calculator.Add(-5, -10);
        NUnit.Framework.Assert.AreEqual(-15, result, "Addition of negative numbers failed.");
    }

    [Test]
    public void Add_PositiveAndNegative_ReturnsCorrectSum()
    {
        double result = calculator.Add(5, -10);
        NUnit.Framework.Assert.AreEqual(-5, result, "Addition of a positive and a negative number failed.");
    }

    [Test]
    public void Subtract_PositiveNumbers_ReturnsCorrectDifference()
    {
        double result = calculator.Subtract(10, 5);
        NUnit.Framework.Assert.AreEqual(5, result, "Subtraction of positive numbers failed.");
    }

    [Test]
    public void Subtract_NegativeNumbers_ReturnsCorrectDifference()
    {
        double result = calculator.Subtract(-10, -5);
        NUnit.Framework.Assert.AreEqual(-5, result, "Subtraction of negative numbers failed.");
    }

    [Test]
    public void Subtract_PositiveAndNegative_ReturnsCorrectDifference()
    {
        double result = calculator.Subtract(5, -10);
        NUnit.Framework.Assert.AreEqual(15, result, "Subtraction of a positive and a negative number failed.");
    }

    [Test]
    public void Multiply_PositiveNumbers_ReturnsCorrectProduct()
    {
        double result = calculator.Multiply(5, 10);
        NUnit.Framework.Assert.AreEqual(50, result, "Multiplication of positive numbers failed.");
    }

    [Test]
    public void Multiply_NegativeNumbers_ReturnsCorrectProduct()
    {
        double result = calculator.Multiply(-5, -10);
        NUnit.Framework.Assert.AreEqual(50, result, "Multiplication of negative numbers failed.");
    }

    [Test]
    public void Multiply_PositiveAndNegative_ReturnsCorrectProduct()
    {
        double result = calculator.Multiply(5, -10);
        NUnit.Framework.Assert.AreEqual(-50, result, "Multiplication of a positive and a negative number failed.");
    }

    [Test]
    public void Divide_PositiveNumbers_ReturnsCorrectQuotient()
    {
        double result = calculator.Divide(10, 5);
        NUnit.Framework.Assert.AreEqual(2, result, "Division of positive numbers failed.");
    }

    [Test]
    public void Divide_NegativeNumbers_ReturnsCorrectQuotient()
    {
        double result = calculator.Divide(-10, -5);
        NUnit.Framework.Assert.AreEqual(2, result, "Division of negative numbers failed.");
    }

    [Test]
    public void Divide_PositiveAndNegative_ReturnsCorrectQuotient()
    {
        double result = calculator.Divide(10, -5);
        NUnit.Framework.Assert.AreEqual(-2, result, "Division of a positive and a negative number failed.");
    }

    [Test]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0), "Division by zero did not throw an exception.");
    }
}
