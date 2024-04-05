using UnitTestingClassProj;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FizzTest()
        {
            var testresult= new FizzBuzzSoln();
            var test = testresult.FizzBuzz(5);
            Assert.AreEqual("Fizz", test, "Expected Fizz.");
        }
    }
}