using Microsoft.AspNetCore.Mvc;
using Store;

namespace Store_Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IBookRepositiry bookRepositiry;

        public SearchController(IBookRepositiry bookRepositiry)
        {
            this.bookRepositiry = bookRepositiry;
        }

        public IActionResult Index(string query)
        {
            var books = bookRepositiry.GetAllByTitle(query);

            return View(books);
        }
    }
}
