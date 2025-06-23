using Store;

namespace Store_Memory
{
    public class BookRepository : IBookRepositiry
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "ISBN 12312-31231", "D. Knuth", "Искусство программирования"),
            new Book(2, "ISBN 12312-31232", "M. Fowler", "Рефакторинг"),
            new Book(3, "ISBN 12312-31233", "M. Kernighan, D. Ritchie", "Язык программирования С"),
        };

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn).ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Author.Contains(query)
                                    || book.Title.Contains(query))
                .ToArray();
        }
    }
}
