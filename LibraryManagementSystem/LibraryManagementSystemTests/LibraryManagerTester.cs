using LibraryManagementSystem;

namespace LibraryManagementSystemTests
{

    [TestClass]
    public class LibraryManagerTester
    {
        // Arrange
        LibraryManager manager = new LibraryManager();

        [TestMethod]
        public void AddNewBookTester()
        {
            List<string> authorList = new List<string> { "J K Rowling" };

            Book book = new Book("Harry Potter", authorList);

            // Act
            var response = manager.AddNewBook(book);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(true, response);
        }

        [TestMethod]
        public void DeleteBookTester()
        {
            // Arrange
            // Generating dummy data for populating Book Object
            List<string> authorList = new List<string> { "J K Rowling" };

            Book book = new Book("Harry Potter", authorList);

            // Act
            var response = manager.DeleteBook(book.bookName);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(true, response);
        }

        [TestMethod]
        public void AddNewStudentTester()
        {
            // Arrange
            string studentName = "Neel";
            int studentId = 1;

            // Act
            var response = manager.AddNewStudent(studentName,studentId);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(true, response);
        }

        [TestMethod]
        public void RemoveStudentTester()
        {
            // Arrange
            string studentName = "Neel";
            int studentId = 1;
            // Act
            var response = manager.RemoveStudent(studentName,studentId);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(true, response);
        }

    }
}