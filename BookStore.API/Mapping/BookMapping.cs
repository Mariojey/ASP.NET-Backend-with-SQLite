using BookStore.API.Dtos;
using BookStore.API.Entities;

namespace BookStore.API.Mapping;

public static class BookMapping
{
    public static Book ToEntity(this CreateBookDto book)
    {
        return new Book()
            {
                Title = book.Title,
                Author = book.Author,
                Price = book.Price,
                BookTypeId = book.BookTypeId,
                PublishedDate = book.PublishedDate
            };
    }

    public static BookDto ToDto(this Book book)
    {
        return new(
                book.Id,
                book.Title,
                book.Author,
                book.Price,
                book.BookType!.Name,
                book.PublishedDate
            );
    }
}


