namespace ModelClasses;

public class JoinDTO
{
    public long id { get; set; }
    public string isbn { get; set; }
    public string title { get; set; }
    public string author { get; set; }
    public string edition { get; set; }
    public string description { get; set; }
    public double price { get; set; }
    public string url { get; set; }
    public int qte { get; set; }

    public JoinDTO()
    {
    }

    public JoinDTO(long id, string isbn, string title, string author, string edition, string description, double price, string url, int qte)
    {
        this.id = id;
        this.isbn = isbn;
        this.title = title;
        this.author = author;
        this.edition = edition;
        this.description = description;
        this.price = price;
        this.url = url;
        this.qte = qte;
    }
}