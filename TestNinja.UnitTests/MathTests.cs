using Math = TestNinja.Fundamentals.Math;

namespace TestNinja.UnitTests;

[TestFixture]
public class MathTests
{
    private Math _math;

    [SetUp]
    public void Setup()
    {
        //ARRANGE
        _math = new Math();
    }

    [Test]
    public void DoSomething()
    {
        Console.WriteLine("<strong>Hi</strong>");
    }
    
    [Test]
    [TestCase(1, 2, 3)]
    [TestCase(1, 1, 2)]
    [TestCase(10, 11, 21)]
    public void ADD_WhenBothArgumentsAreAdded_ReturnedTheSumOfArguments(int arg1, int arg2, int expected)
    {
        //ACT
        var actual = _math.Add(arg1, arg2);
        
        //ASSERT
        Assert.That(actual, Is.EqualTo(expected), "Mismatch values.");
    }

    [Test]
    [Ignore("Test is currently disabled.")]
    [TestCase(1, 2, 2)]
    [TestCase(2, 1, 2)]
    public void Max_WhenTwoNumbersAreCompared_ReturnTheMaximumNumber(int number1, int number2, int expected)
    {
        //ACT
        var actual = _math.Max(number1, number2);
        
        //ASSERT
        Assert.That(actual, Is.EqualTo(expected), "Maximum value returned is invalid.");
    }
    
}