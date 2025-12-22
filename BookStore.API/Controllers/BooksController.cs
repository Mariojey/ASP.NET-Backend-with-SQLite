using BookStore.API.Dtos;

namespace BookStore.API.Controllers;

public static class BooksController
{
    private static readonly List<BookDto> books = [
        new BookDto(1, "The Great Gatsby", "F. Scott Fitzgerald", 10.99m, "Classic", new DateTime(1925, 4, 10)),
        new BookDto(2, "To Kill a Mockingbird", "Harper Lee", 7.99m, "Classic", new DateTime(1960, 7, 11)),
        new BookDto(3, "1984", "George Orwell", 8.99m, "Dystopian Fiction", new DateTime(1949, 6, 8))
    ];

    public static RouteGroupBuilder MapBooksController(this WebApplication app)
    {

        var booksRouter = app.MapGroup("/api/books");

        booksRouter.MapGet("/", () => books);
        
        booksRouter.MapGet("/{id}", (int id) =>
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            
            if(book is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(book);
        }).WithName("GetBookById");
        
        booksRouter.MapPost("/", (CreateBookDto newBook) =>
        {
            BookDto book = new BookDto(
                books.Max(b => b.Id) + 1,
                newBook.Title,
                newBook.Author,
                newBook.Price,
                newBook.Type,
                newBook.PublishedDate
            );
        
            books.Add(book);
        
            return Results.CreatedAtRoute("GetBookById", new { id = book.Id }, book);
        });

        booksRouter.MapPut("/{id}", (int id, UpdateBookDto updatedBook) =>
        {
            var bookIndex = books.FindIndex(b => b.Id == id);
        
            if(bookIndex == -1)
            {
                return Results.NotFound();
            }
        
            books[bookIndex] = new BookDto(
                id,
                updatedBook.Title,
                updatedBook.Author,
                updatedBook.Price,
                updatedBook.Type,
                updatedBook.PublishedDate
            );
        
            return Results.NoContent();
        });
        
        booksRouter.MapDelete("/{id}", (int id) =>
        {
            var bookIndex = books.FindIndex(b => b.Id == id);
            books.RemoveAt(bookIndex);
            Results.NoContent();
        });

        return booksRouter;
    }
}
