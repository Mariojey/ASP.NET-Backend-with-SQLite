using BookStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Data;

public class BooksContext(DbContextOptions<BooksContext> options) : DbContext(options)
{
    public DbSet<Book> Books => Set<Book>();

    public DbSet<BookType> BookTypes => Set<BookType>();
}
