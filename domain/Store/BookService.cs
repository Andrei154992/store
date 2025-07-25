using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class BookService
    {
        private readonly IBookRepository bookRepositiry;

        public BookService(IBookRepository bookRepositiry)
        {
            this.bookRepositiry = bookRepositiry;
        }

        public Book[] GetAllByQuery(string query)
        {
            if (Book.IsIsbn(query))
            {
                return bookRepositiry.GetAllByIsbn(query);
            }
            return bookRepositiry.GetAllByTitleOrAuthor(query);
        }
    }
}
