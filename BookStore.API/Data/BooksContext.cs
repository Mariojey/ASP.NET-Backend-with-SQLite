using BookStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Data;

public class BooksContext(DbContextOptions<BooksContext> options) : DbContext(options)
{
    public DbSet<Book> Books => Set<Book>();

    public DbSet<BookType> BookTypes => Set<BookType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookType>().HasData(
            new { Id = 1, Name = "Science Fiction" },
            new { Id = 2, Name = "Fantasy" },
            new { Id = 3, Name = "Mystery" },
            new { Id = 4, Name = "Non-Fiction" }
        );
    }
}
