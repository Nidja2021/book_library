namespace BookLibrary.Models.Dtos;

public record BookDto (string Title, string Author);

public record UpdateBookDto(Guid Id, string Title, string Author);