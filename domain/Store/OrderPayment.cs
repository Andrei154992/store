namespace Store
{
    public class OrderPayment
    {
        public string? UniqueCode { get; }

        public string? Description { get; }

        public IReadOnlyDictionary<string, string>? Pararmetres { get; }

        public OrderPayment(string? uniqueCode, string? description, IReadOnlyDictionary<string, string>? pararmetres)
        {
            if (string.IsNullOrWhiteSpace(uniqueCode) || string.IsNullOrWhiteSpace(description))
                throw new ArgumentException(string.IsNullOrWhiteSpace(uniqueCode) ?
                    nameof (uniqueCode) : nameof (description));

            if (pararmetres == null)
                throw new ArgumentNullException(nameof (pararmetres));

            UniqueCode = uniqueCode;
            Description = description;
            Pararmetres = pararmetres;
        }
    }
}
