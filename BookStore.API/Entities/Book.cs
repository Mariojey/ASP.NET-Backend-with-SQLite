namespace BookStore.API.Entities;

public class Book
{
    public int Id { get; set; }
    public required string Title { get; set; } = string.Empty;
    public required string Author { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public int BookTypeId { get; set; }

    public BookType? BookType { get; set; }
    public DateTime PublishedDate { get; set; }
}
