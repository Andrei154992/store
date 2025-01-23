using Store;

namespace Store_Memory
{
    public class BookRepository : Store.IBookRepositiry
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "Искусство программирования"),
            new Book(2, "Рефакторинг"),
            new Book(3, "Язык программирования С"),
        };

        public Book[] GetAllByTitle(string titlePart)
        {
            return books.Where(book => book.Title.Contains(titlePart)).ToArray();
        }
    }
}
