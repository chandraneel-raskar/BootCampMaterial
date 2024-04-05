using LibraryManagementSystem;

namespace LibraryManagementSystemTests
{
    [TestClass]
    public class FrontDeskTester
    {
        // Arrange
        FrontDesk frontDesk = new FrontDesk();

        [TestMethod]
        public void IssueBookTester()
        {
            // Arrange
            //Generating dummy data objects Student and Book to pass into IssueBook method
            int studentId = 1;

            int bookId = 1;

            // Act
            var response= frontDesk.IssueBook(studentId, bookId);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(true, response);
        }

        [TestMethod]
        public void ReturnBookTester()
        {
            // Arrange
            //Generating dummy data objects Student and Book to pass into IssueBook method
            Student student = new Student(1, "Neel");


            // Generating Author list to pass into book object as a parameter
            int studentId = 1;

            int bookId = 1;

            // Act
            var response = frontDesk.ReturnBook(studentId, bookId);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(true, response);
        }
    }
}