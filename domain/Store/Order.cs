using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Order
    {
        public int Id { get; }

        private List<OrderItem> items;

        public Order(int id, IEnumerable<OrderItem> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            Id = id;
            this.items = new List<OrderItem>(items);
        }

        public IReadOnlyCollection<OrderItem> Items
        {
            get {  return items; }
        }

        public int TotalCount
        {
            get { return items.Sum(items => items.Count); }
        }

        public decimal TotalPrice
        {
            get { return items.Sum(items => items.Price * items.Count); }
        }

        public OrderItem GetItem(int bookId)
        {
            int index = items.FindIndex(item => bookId == item.BookId);

            if (index == -1)
                ThrowBookException("Book not found.", bookId);

            return items[index];
        }

        public void AddOrUpdateItem(Book book, int count)
        {
            if (book == null) 
                throw new ArgumentNullException(nameof (book));

            int index = items.FindIndex(item => book.ID == item.BookId);

            if (index == -1)
            {
                items.Add(new OrderItem(book.ID, count, book.Price));
            }
            else
            {
                items[index].Count += count;
            }
        }

        public void RemoveItem(int bookId)
        {
            int index = items.FindIndex(item => bookId == item.BookId);

            if (index == -1)
                ThrowBookException("Order does not contain specified book.", bookId);

            items.RemoveAt(index);
        }

        private void ThrowBookException(string message, int bookId)
        {
            var exception = new InvalidOperationException(message);

            exception.Data["BookId"] = bookId;

            throw exception;
        }
    }
}
