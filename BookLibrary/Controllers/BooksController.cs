using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBooks()
    {
        return Ok(await _bookService.GetBooks());
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateBook(BookDto bookDto)
    {
        if (!ModelState.IsValid) return BadRequest(new { Message = ModelState });
        
        return CreatedAtAction(nameof(GetBook), await _bookService.CreateBook(bookDto), bookDto);
    }
    
    [HttpGet("/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetBook(Guid id)
    {
        try
        {
            return Ok(await _bookService.GetBookById(id));
        }
        catch (Exception e)
        {
            return NotFound(new { Message = e.Message });
        }
    }
    
    [HttpPatch("/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateBook(Guid id, BookDto bookDto)
    {
        if (!ModelState.IsValid) return BadRequest(new { Message = ModelState });

        try
        {
            return Ok(await _bookService.UpdateBook(id, bookDto));
        }
        catch (Exception e)
        {
            return NotFound(new { Message = e.Message });
        }
    }
    
    [HttpDelete("/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteBook(Guid id)
    {
        try
        {
            await _bookService.DeleteBook(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(new { Message = e.Message });
        }
    }
}