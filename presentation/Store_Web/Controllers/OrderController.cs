using Microsoft.AspNetCore.Mvc;
using Store;
using Store_Memory;
using Store_Web.Models;

namespace Store_Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IBookRepository bookRepository;
        private readonly IOrderRepository orderRepository;

        public OrderController(IBookRepository bookRepository, IOrderRepository orderRepository)
        {
            this.bookRepository = bookRepository;
            this.orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.TryGetCart(out Cart cart))
            {
                var order = orderRepository.GetById(cart.OrderId);
                OrderModel model = Map(order);

                return View(model);
            }
            return View("Empty");
        }

        public IActionResult AddItem(int bookId, int count = 1)
        {
            (Order order, Cart cart) = GetOrCreateOrderAndCart(bookId);

            var book = bookRepository.GetById(bookId);

            order.AddOrUpdateItem(book, count);

            SaveOrderAndCart(order, cart);

            return RedirectToAction("Index", "Book", new { id = bookId });
        }

        [HttpPost]
        public IActionResult UpdateItem(int bookId, int count)
        {
            (Order order, Cart cart) = GetOrCreateOrderAndCart(bookId);

            order.GetItem(bookId).Count = count;

            SaveOrderAndCart(order, cart);

            return RedirectToAction("Index", "Book", new { bookId });
        }

        public IActionResult RemoveItem(int id)
        {
            (Order order, Cart cart) = GetOrCreateOrderAndCart(id);

            order.RemoveItem(id);

            SaveOrderAndCart(order, cart);

            return RedirectToAction("Index", "Book", new { id });
        }




        private void SaveOrderAndCart(Order order, Cart cart)
        {
            orderRepository.Update(order);

            cart.TotalCount = order.TotalCount;
            cart.TotalPrice = order.TotalPrice;

            HttpContext.Session.Set(cart);
        }

        private (Order order, Cart cart) GetOrCreateOrderAndCart(int id)
        {
            Order order;
            Cart cart;

            if (HttpContext.Session.TryGetCart(out cart))
            {
                order = orderRepository.GetById(cart.OrderId);
            }
            else
            {
                order = orderRepository.Create();
                cart = new Cart(order.Id);
            }

            return (order, cart);
        }

        private OrderModel Map(Order order)
        {
            var bookIds = order.Items.Select(item => item.BookId);
            var books = bookRepository.GetAllByIds(bookIds);
            var itemModels = from item in order.Items
                             join book in books on item.BookId equals book.ID
                             select new OrderItemModel
                             {
                                 BookId = book.ID,
                                 Title = book.Title,
                                 Author = book.Author,
                                 Price = item.Price,
                                 Count = item.Count,
                             };
            return new OrderModel
            {
                Id = order.Id,
                Items = itemModels.ToArray(),
                TotalCount = order.TotalCount,
                TotalPrice = order.TotalPrice,
            };
        }
    }
}
