using BooksReservationAPI.DTOs;
using BooksReservationAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BooksReservationAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController(IBookService bookService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetBooks([FromQuery] string? name = null, [FromQuery] int? year = null, [FromQuery] BookType? type = null)
    {
        try
        {
            var books = await bookService.GetAllBooksAsync(name, year, type);
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while fetching reservations.");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        try
        {
            var book = await bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while fetching reservations.");
        }
    }
}