using AutoMapper;
using BooksReservationAPI.DTOs;
using BooksReservationAPI.Repositories.Interfaces;
using BooksReservationAPI.Services.Interfaces;

namespace BooksReservationAPI.Services;

public class BookService(IBookRepository bookRepository, IMapper mapper) : IBookService
{
    private readonly IBookRepository _bookRepository = bookRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<IEnumerable<BookDTO>> GetAllBooksAsync(string? name = null, int? year = null, BookType? type = null)
    {
        var books = await _bookRepository.GetAllBooksAsync(name, year, type);
        var bookDTOs = _mapper.Map<IEnumerable<BookDTO>>(books);

        return bookDTOs; 
    }

    public async Task<BookDTO?> GetBookByIdAsync(int id)
    {
        var book = await _bookRepository.GetBookByIdAsync(id);
        return _mapper.Map<BookDTO?>(book);
    }
}