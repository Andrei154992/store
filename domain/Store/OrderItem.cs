using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class OrderItem
    {
        private int count;

        public int BookId { get; }

        public int Count 
        {
            get
            {
                return count;
            } 
            set
            {
                ThrowsIfInvalidCount(value);

                count = value;
            }
        }

        public decimal Price { get; }

        public OrderItem(int bookId, int count, decimal price)
        {
            ThrowsIfInvalidCount(count);

            BookId = bookId;
            Count = count;
            Price = price;
        }

        public static void ThrowsIfInvalidCount(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("Count must be greater then zero.");
        }
    }
}
