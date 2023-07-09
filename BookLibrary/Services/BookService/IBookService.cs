namespace BookLibrary.Services;

public interface IBookService
{
    Task<List<BookDto>> GetBooks();
    Task<Guid> CreateBook(BookDto bookDto);
    Task<BookDto> GetBookById(Guid id);
    Task<BookDto> UpdateBook(Guid id, BookDto bookDto);
    Task DeleteBook(Guid id);
}