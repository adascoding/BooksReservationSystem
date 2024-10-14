using BooksReservationAPI.Data;
using BooksReservationAPI.DTOs;
using BooksReservationAPI.Models;
using BooksReservationAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BooksReservationAPI.Repositories;

public class BookRepository(ApplicationContext context) : IBookRepository
{
    private readonly ApplicationContext _context = context;

    public async Task<IEnumerable<Book>> GetAllBooksAsync(string? name = null, int? year = null, BookType? type = null)
    {
        var query = _context.Books.AsQueryable();

        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(b => b.Name.ToLower().Contains(name.ToLower()));
        }

        if (year.HasValue)
        {
            query = query.Where(b => b.Year == year.Value);
        }

        if (type == BookType.NormalBook)
        {
            query = query.Where(b => b.HasNormalBook == true);
        }
        else if (type == BookType.AudioBook)
        {
            query = query.Where(b => b.HasAudioBook == true);
        }

        return await query.ToListAsync();
    }

    public async Task<Book?> GetBookByIdAsync(int id)
    {
        return await _context.Books
            .FirstOrDefaultAsync(b => b.Id == id);
    }
}