using BookStore.API.Data;
using BookStore.API.Dtos;
using BookStore.API.Entities;
using BookStore.API.Mapping;

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

        booksRouter.MapPost("/", (CreateBookDto newBook, BooksContext context) =>
        {

            Book book = newBook.ToEntity();
            book.BookType = context.BookTypes.Find(newBook.BookTypeId);



            context.Books.Add(book);
            context.SaveChanges();



            return Results.CreatedAtRoute("GetBookById", new { id = book.Id }, book.ToDto());
        });

        booksRouter.MapPut("/{id}", (int id, UpdateBookDto updatedBook, BooksContext context) =>
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
                context.BookTypes.Find(updatedBook.BookTypeId)!.Name,
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
