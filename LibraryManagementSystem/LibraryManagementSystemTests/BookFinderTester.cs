using LibraryManagementSystem;

namespace LibraryManagementSystemTests
{
    [TestClass]
    public class BookFinderTester
    {
        [TestMethod]
        public void SearchBookByNameTester()
        {
            // Arrange
            BookFinder bookFinder = new BookFinder();

            // Act
            bool response = bookFinder.SearchBookByName("Harry Potter");

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(true, response);

        }

        [TestMethod]
        public void SearchBookByAuthorTester()
        {
            // Arrange
            BookFinder bookFinder = new BookFinder();


            // Act
            bool response = bookFinder.SearchBookByAuthor("J K Rowling");

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(true, response);

        }

    }
}