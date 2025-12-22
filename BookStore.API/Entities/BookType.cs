namespace BookStore.API.Entities;

public class BookType
{
    public int Id { get; set; }
    public required string Name { get; set; } = string.Empty;
}
