namespace Store.Tests
{
    public class OrderItemCollectionTests
    {
        [Fact]
        public void Get_WithExistingItem_ReturnsItem()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 10m, 3),
                new OrderItem(2, 100m, 5),
            });

            var orderItem = order.Items.Get(1);

            Assert.Equal(3, orderItem.Count);
        }

        [Fact]
        public void Get_WithNotExistingItem_ThrowsInvalidOperationException()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 10m, 3),
                new OrderItem(2, 100m, 5),
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                order.Items.Get(100);
            });
        }

        [Fact]
        public void Add_WithExistingItem_ThrowsInvalidOperationException()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 10m, 3),
                new OrderItem(2, 100m, 5),
            });

            var book = new Book(1, null, null, null, null, 0m);

            Assert.Throws<InvalidOperationException>(() =>
            {
                order.Items.Add(1, 10m, 10);
            });
        }

        [Fact]
        public void Add_WithNotExistingItem_AddsCount()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 10m, 3),
                new OrderItem(2, 100m, 5),
            });

            order.Items.Add(3, 1000m, 7);

            Assert.Equal(7, order.Items.Get(3).Count);
        }

        [Fact]
        public void Remove_WithExistingItem_RemovesItem()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 10m, 3),
                new OrderItem(2, 100m, 5),
            });

            order.Items.Remove(1);

            Assert.Collection(order.Items, item =>
                                            Assert.Equal(2, item.BookId));
        }

        [Fact]
        public void Remove_WithNotExistingItem_ThrowsInvalidOperationException()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 10m, 3),
                new OrderItem(2, 100m, 5),
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                order.Items.Remove(3);
            });
        }
    }
}