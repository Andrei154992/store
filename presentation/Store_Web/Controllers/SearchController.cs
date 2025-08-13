using Microsoft.AspNetCore.Mvc;
using Store.Web.App;

namespace Store_Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly BookService bookService;

        public SearchController(BookService bookService)
        {
            this.bookService = bookService;
        }

        public IActionResult Index(string query)
        {
            if (string.IsNullOrEmpty(query))
                return View(null);

            var books = bookService.GetAllByQuery(query);
            return View(books);
        }
    }
}
