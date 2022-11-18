using TestNinja.Fundamentals;

namespace TestNinja.UnitTests;

[TestFixture]
public class FizzBuzzTests
{
    [TestCase(3, "Fizz")]
    [TestCase(9, "Fizz")]
    [TestCase(5, "Buzz")]
    [TestCase(10, "Buzz")]
    [TestCase(15, "FizzBuzz")]
    [TestCase(1, "1")]
    [TestCase(2, "2")]
    [TestCase(4, "4")]

    public void GetOutput_WhenCalledWithValidNumberArgument_ReturnValidStringOutput(int numberArgument,
        string expectedStringOutput)
    {
        //ACT
        var actualStringOutput = FizzBuzz.GetOutput(numberArgument);

        //ASSERT
        Assert.That(actualStringOutput, Is.EqualTo(expectedStringOutput));
    }
}