using Store;
namespace Store;

public class Book
{
    public int ID { get; set; }
    public string Title { get; set; }

    public Book(string title, int id)
    {
        ID = id;
        Title = title;
    }



}
