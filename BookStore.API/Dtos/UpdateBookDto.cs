using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Dtos;

public record class UpdateBookDto
(
    [Required][StringLength(100)]string Title,
    [Required][StringLength(50)]string Author,
    [Required][Range(0, 200)]decimal Price,
    string Type,
    DateTime PublishedDate
);
