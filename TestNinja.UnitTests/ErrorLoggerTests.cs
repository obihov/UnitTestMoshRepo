using TestNinja.Fundamentals;

namespace TestNinja.UnitTests;


[TestFixture]
public class ErrorLoggerTests
{
    private ErrorLogger _errorLogger;

    [SetUp]
    public void Setup()
    {
        _errorLogger = new ErrorLogger();
    }
    
    [Test]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase(null)]
    public void Log_WhenInvalidErrorStringIsProvided_ThrowsArgumentNullException(string invalidErrorString)
    {
       //ACT
       var errorDelegate = () => _errorLogger.Log(invalidErrorString);
       
       //ASSERT
       Assert.That(errorDelegate, Throws.ArgumentNullException);
       
    }
    
}