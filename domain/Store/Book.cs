namespace Store
{

    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public Book(int id, string title)
        {
            ID = id;
            Title = title;
        }



    }
}
