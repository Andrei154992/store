using Store;

namespace Store_Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "ISBN 12312-31231", "Д. Кнут", "Искусство программирования", 
                "Фундаментальная монография американского математика" +
                " и специалиста в области компьютерных наук Дональда Кнута. " +
                "Посвящена рассмотрению" +
                " и анализу важнейших алгоритмов, используемых в информатике.", 540),
            new Book(2, "ISBN 12312-31232", "М. Фаулер", "Рефакторинг", "" +
                "В книге автор описывает процесс рефакторинга, объясняет, " +
                "почему его нужно проводить, как распознавать код," +
                " который нуждается в рефакторинге, и как успешно его выполнять, " +
                "независимо от используемого языка.", 620),
            new Book(3, "ISBN 12312-31233", "М. Керниган, Д. Риччи", "Язык программирования C",
                "книга Брайана Кернигана и Денниса Ритчи, одного из авторов и разработчиков языка Си." +
                " Охватывает основные концепции и предоставляет " +
                "множество примеров кода.", 700),
        };

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.
            Isbn.Replace("-", "").Replace(" ", "").ToUpper() == 
            isbn.Replace("-", "").Replace(" ", "").ToUpper())
                .ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Author.Contains(query, StringComparison.OrdinalIgnoreCase)
                                    || book.Title.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToArray();
        }

        public Book GetById(int id)
        {
            return books.Single(book => book.ID == id);
        }

        public Book[] GetAllByIds(IEnumerable<int> bookIds)
        {
            var founfBooks = from book in books
                             join bookId in bookIds on book.ID equals bookId
                             select book;

            return founfBooks.ToArray();
        }
    }
}
