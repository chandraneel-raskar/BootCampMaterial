using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{

    public class Book
    {
        public string bookName;
        public List<string> authorList;

        public Book(string bookName, List<string> authorList)
        {
            this.bookName = bookName;
            this.authorList = authorList;
        }
    }
}
