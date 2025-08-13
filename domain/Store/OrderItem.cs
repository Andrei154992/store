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

        public OrderItem(int bookId, decimal price, int count)
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
