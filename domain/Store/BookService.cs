using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class BookService
    {
        private readonly IBookRepositiry bookRepositiry;

        public BookService(IBookRepositiry bookRepositiry)
        {
            this.bookRepositiry = bookRepositiry;
        }

        public Book[] GetAlByQuery(string query)
        {
            if (Book.IsIsbn(query))
            {
                return bookRepositiry.GetAllByIsbn(query);
            }
            return bookRepositiry.GetAllByTitleOrAuthor(query);
        }
    }
}
