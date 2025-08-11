namespace Store
{
    public class OrderDelivery
    {
        public string? UniqueCode { get; }

        public string? Description { get; }

        public decimal Amount { get; }

        public IReadOnlyDictionary<string, string>? Pararmetres { get; }

        public OrderDelivery(string? uniqueCode, string? description,
            decimal amount, IReadOnlyDictionary<string, string>? pararmetres)
        {
            if (string.IsNullOrWhiteSpace(uniqueCode) || string.IsNullOrWhiteSpace(description))
                throw new ArgumentException(string.IsNullOrWhiteSpace(uniqueCode) ?
                    nameof (uniqueCode) : nameof (description));

            if (pararmetres == null)
                throw new ArgumentNullException(nameof (pararmetres));

            UniqueCode = uniqueCode;
            Description = description;
            Amount = amount;
            Pararmetres = pararmetres;
        }
    }
}
