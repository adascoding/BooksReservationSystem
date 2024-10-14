using BooksReservationAPI.DTOs;
using BooksReservationAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BooksReservationAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController(IBookService bookService) : ControllerBase
{
    private readonly IBookService _bookService = bookService;

    [HttpGet]
    public async Task<IActionResult> GetBooks([FromQuery] string? name = null, [FromQuery] int? year = null, [FromQuery] BookType? type = null)
    {
        var books = await _bookService.GetAllBooksAsync(name, year, type);
        if (books == null)
        {
            return NotFound();
        }

        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        return Ok(book);
    }
}