using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests
{
    public class BookServiceTests
    {
        [Fact]
        public void GetAlByQuery_WithIsbn_CallsGetAllByIsbn()
        {
            var bookRepositoryStub = new Mock<IBookRepositiry>();

            bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                .Returns(new[] {new Book(1, "", "", "")});

            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                .Returns(new[] { new Book(2, "", "", "") });

            var bookService = new BookService(bookRepositoryStub.Object);
            var validIsbn = "ISBN 12345-67890";

            var actual = bookService.GetAlByQuery(validIsbn);

            Assert.Collection(actual, book => Assert.Equal(1, book.ID));
        }

        [Fact]
        public void GetAlByQuery_WithAuthor_CallsGetAllByTitleOrAuthor()
        {
            var bookRepositoryStub = new Mock<IBookRepositiry>();

            bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                .Returns(new[] { new Book(1, "", "", "") });

            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                .Returns(new[] { new Book(2, "", "", "") });

            var bookService = new BookService(bookRepositoryStub.Object);
            var invalidIsbn = "12345-67890";

            var actual = bookService.GetAlByQuery(invalidIsbn);

            Assert.Collection(actual, book => Assert.Equal(2, book.ID));
        }
    }
}
