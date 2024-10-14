using BooksReservationAPI.DTOs;
using BooksReservationAPI.Models;

namespace BooksReservationAPI.Repositories.Interfaces;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllBooksAsync(string? name = null, int? year = null, BookType? type = null);
    Task<Book?> GetBookByIdAsync(int id);
}
