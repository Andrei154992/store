using Store.Web.App;
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

        public IReadOnlyCollection<BookModel> GetAllByQuery(string query)
        {
            var books = Book.IsIsbn(query)
                        ? bookRepositiry.GetAllByIsbn(query)
                        : bookRepositiry.GetAllByTitleOrAuthor(query);

            return books.Select(Map).ToArray();
        }

        public BookModel GetById(int id)
        {
            Book book = bookRepositiry.GetById(id);

            return Map(book);
        }

        private BookModel Map(Book book)
        {
            return new BookModel
            {
                ID = book.ID,
                Isbn = book.Isbn,
                Author = book.Author,
                Title = book.Title,
                Description = book.Description,
                Price = book.Price
            };
        }
    }
}
