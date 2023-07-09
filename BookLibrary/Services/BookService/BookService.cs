namespace BookLibrary.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly DataContext _context;
  

        public BookService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<BookDto>> GetBooks()
        {
            var books = await _context.Books.ToListAsync();
            var bookDtoList = books.Select(TransformerMapper<Book, BookDto>.Map).ToList();
            return bookDtoList;
        }

        public async Task<Guid> CreateBook(BookDto bookDto)
        {
            var book = TransformerMapper<BookDto, Book>.Map(bookDto);
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }

        public async Task<BookDto> GetBookById(Guid id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) throw new Exception($"Book with ID = {id} does not exists.");
            var bookDto = TransformerMapper<Book, BookDto>.Map(book);
            return bookDto;
        }

        public async Task<BookDto> UpdateBook(Guid id, BookDto bookDto)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) throw new Exception($"Book with ID = {id} does not exists.");
            
            await _context.SaveChangesAsync();
            
            return bookDto;
        }

        public async Task DeleteBook(Guid id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) throw new Exception($"Book with ID = {id} does not exists.");

            _context.Remove(book);
        }
    }
}

