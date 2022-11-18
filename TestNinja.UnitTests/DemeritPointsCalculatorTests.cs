using TestNinja.Fundamentals;

namespace TestNinja.UnitTests;

[TestFixture]
public class DemeritPointsCalculatorTests
{
    private DemeritPointsCalculator _demeritPointsCalculator;
    
    [SetUp]
    public void Setup()
    {
        _demeritPointsCalculator = new DemeritPointsCalculator();
    }
    
    [Test]
    [TestCase(-1)] //when speed is negative
    [TestCase(301)] //when speed is over 300 limit
    public void CalculateDemeritPoints_WhenSpeedArgumentIsInvalid_ThrowArgumentOutOfRangeException(int speed)
    {
        var actual = () => _demeritPointsCalculator.CalculateDemeritPoints(speed);
        var expected = Throws.TypeOf<ArgumentOutOfRangeException>(); //same as Throws.Exception.TypeOf<ArgumentOutOfRangeException>();
        Assert.That(actual, expected);
    }
    
    
    [Test]
    [TestCase(0, 0)]
    [TestCase(1, 0)]
    [TestCase(64, 0)]
    [TestCase(65, 0)]
    public void CalculateDemeritPoints_WhenSpeedArgumentIsValidAndLessThanSpeedLimit_ReturnZeroPoint(int speed, int expectedPoint)
    {
        var actualPoint = _demeritPointsCalculator.CalculateDemeritPoints(speed);
        Assert.That(actualPoint, Is.EqualTo(expectedPoint));
    }
    
    
    [Test]
    [TestCase(66, 0)]
    [TestCase(67, 0)]
    [TestCase(70, 1)]
    [TestCase(73, 1)]
    [TestCase(75, 2)]
    [TestCase(78, 2)]
    [TestCase(80, 3)]
    [TestCase(84, 3)]
    public void CalculateDemeritPoints_WhenSpeedArgumentIsValidAndGreaterThanSpeedLimit_ReturnValidPoint(int speed, int expectedPoint)
    {
        var actualPoint = _demeritPointsCalculator.CalculateDemeritPoints(speed);
        Assert.That(actualPoint, Is.EqualTo(expectedPoint));
    }
}