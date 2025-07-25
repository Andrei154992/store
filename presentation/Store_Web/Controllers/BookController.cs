using Microsoft.AspNetCore.Mvc;
using Store;

namespace Store_Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public IActionResult Index(int id)
        {
            var book = bookRepository.GetById(id);
            return View(book);
        }
    }
}
