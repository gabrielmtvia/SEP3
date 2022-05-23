package via.sep3.group2.shared;

import via.sep3.grpc.order.Order;

public class JoinDTO {
    private long id;
    private String isbn;
    private String title;
    private String author;
    private String edition;
    private String description;
    private double price;
    private String url;
    private int qte;

    public JoinDTO(long id, String isbn, String title, String author, String edition, String description, String url, double price, int qte) {
        this.id = id;
        this.isbn = isbn;
        this.title = title;
        this.author = author;
        this.edition = edition;
        this.description = description;
        this.url = url;
        this.price = price;
        this.qte = qte;

    }

    public JoinDTO(long id, String isbn, String title, double price, int qte) {
        this.id = id;
        this.isbn = isbn;
        this.title = title;
        this.price = price;
        this.qte = qte;
    }

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public String getIsbn() {
        return isbn;
    }

    public void setIsbn(String isbn) {
        this.isbn = isbn;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getAuthor() {
        return author;
    }

    public void setAuthor(String author) {
        this.author = author;
    }

    public String getEdition() {
        return edition;
    }

    public void setEdition(String edition) {
        this.edition = edition;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public String getUrl() {
        return url;
    }

    public void setUrl(String url) {
        this.url = url;
    }

    public int getQte() {
        return qte;
    }

    public void setQte(int qte) {
        this.qte = qte;
    }

    public Order.OrderLineMessage buildOrderLineMessage(){
        return Order.OrderLineMessage.newBuilder().setId(id).setIsbn(isbn).setTitle(title).setAuthor(author).setEdition(edition)
                .setDescription(description).setUrl(url).setPrice(price).setQte(qte).build();
    }
}
