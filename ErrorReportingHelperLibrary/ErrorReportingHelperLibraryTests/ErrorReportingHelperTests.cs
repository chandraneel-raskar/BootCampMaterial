using ErrorReportingHelperLibrary;

namespace ErrorReportingHelperLibraryTests
{
    public class Tests
    {
        ErrorLogger errorLogger=new ErrorLogger();

        [Test]
        public void TestTextFileLogger_GiveError_ShouldReturnTrue()
        {
            // Arrange
            Error error = new Error(404, "Not Found", "Page you are looking for is not found");

            // Act
            bool actual = errorLogger.LogError(new TextFileLogger(),error);
            bool expected = true;

            // Assert
            Assert.AreEqual(expected,actual);
        }        
        
        [Test]
        public void TestEmailLogger_GiveError_ShouldReturnTrue()
        {
            // Arrange
            Error error = new Error(404, "Not Found", "Page you are looking for is not found");

            // Act
            bool actual = errorLogger.LogError(new EmailLogger(), error);
            bool expected = true;

            // Assert
            Assert.AreEqual(expected,actual);
        }        
        
        [Test]
        public void TestWindowsEventLogger_GiveError_ShouldReturnTrue()
        {
            // Arrange
            Error error = new Error(404, "Not Found", "Page you are looking for is not found");

            // Act
            bool actual = errorLogger.LogError(new WindowsEventLogger(), error);
            bool expected = true;

            // Assert
            Assert.AreEqual(expected,actual);
        }
    }
}