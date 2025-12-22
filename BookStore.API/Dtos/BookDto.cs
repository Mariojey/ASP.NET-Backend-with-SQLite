namespace BookStore.API.Dtos;

public record class BookDto(
    int Id,
    string Title,
    string Author,
    decimal Price,
    string Type,
    DateTime PublishedDate
);
