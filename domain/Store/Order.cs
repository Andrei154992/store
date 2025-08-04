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

        public void AddOrUpdateItem(Book book, int count)
        {
            if (book == null) 
                throw new ArgumentNullException(nameof (book));

            var item = items.SingleOrDefault(x => x.BookId == book.ID);

            if (item == null)
            {
                items.Add(new OrderItem(book.ID, count, book.Price));
            }
            else
            {
                items.Remove(item);
                items.Add(new OrderItem(book.ID, item.Count + count,  book.Price));
            }
        }

        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            AddOrUpdateItem(book, 1);
        }

        public void RemoveBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            AddOrUpdateItem(book, -1);
        }

        public void RemoveItem(Book book, int count)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            if (items.Count == 0)
                throw new InvalidOperationException("Cart must contain items");

            var item = items.SingleOrDefault(x => x.BookId == book.ID);

            if (item == null)
                throw new InvalidOperationException("Cart does not contain item with ID: " + book.ID);

            items.Remove(item);

            if (item.Count - count == 0)
                return;

            items.Add(new OrderItem(book.ID, item.Count - count, book.Price));
        }

        public void RemoveItem(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            if (items.Count == 0)
                throw new InvalidOperationException("Cart must contain items");

            var item = items.SingleOrDefault(x => x.BookId == book.ID);

            if (item == null)
                throw new InvalidOperationException("Cart does not contain item with ID: " + book.ID);

            items.RemoveAll(x => x.BookId == book.ID);
        }
    }
}
