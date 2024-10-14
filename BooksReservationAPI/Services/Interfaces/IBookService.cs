using BooksReservationAPI.DTOs;

namespace BooksReservationAPI.Services.Interfaces;

public interface IBookService
{
    Task<IEnumerable<BookDTO>> GetAllBooksAsync(string? name = null, int? year = null, BookType? type = null);
    Task<BookDTO?> GetBookByIdAsync(int id);
}
