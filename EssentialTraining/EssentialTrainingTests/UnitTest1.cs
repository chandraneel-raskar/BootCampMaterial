using EssentialTraining;
namespace EssentialTrainingTests

{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var TestInstance = new Class1();
            var TestResult = TestInstance.Add(9, 5);
            Assert.AreEqual(14, TestResult);
        }
    }
}