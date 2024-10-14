using AutoMapper;
using BooksReservationAPI.Repositories.Interfaces;
using BooksReservationAPI.Services.Interfaces;
using BooksReservationAPI.DTOs;
using BooksReservationAPI.Models;

namespace BooksReservationAPI.Services;

public class ReservationService(IReservationRepository reservationRepository, IBookRepository bookRepository, IMapper mapper) : IReservationService
{
    private readonly IReservationRepository _reservationRepository = reservationRepository;
    private readonly IBookRepository _bookRepository = bookRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<ReservationDTO>> GetAllReservationsAsync()
    {
        var reservations = await _reservationRepository.GetAllReservationsAsync();
        return _mapper.Map<IEnumerable<ReservationDTO>>(reservations);
    }

    public async Task<ReservationDTO> AddReservationAsync(CreateReservationDTO createReservationDTO)
    {
        var book = await _bookRepository.GetBookByIdAsync(createReservationDTO.BookId);
        if (book == null)
        {
            throw new ArgumentException("Book not found");
        }

        var reservation = new Reservation
        {
            BookType = createReservationDTO.BookType,
            DaysReserved = createReservationDTO.DaysReserved,
            IsQuickPickup = createReservationDTO.IsQuickPickup,
            BookId = createReservationDTO.BookId
        };

        reservation.TotalPrice = CalculateTotalPrice(reservation, book);
        await _reservationRepository.AddReservationAsync(reservation);

        return _mapper.Map<ReservationDTO>(reservation);
    }
    public async Task<ReservationDTO?> GetReservationByIdAsync(int reservationId)
    {
        var reservation = await _reservationRepository.GetReservationByIdAsync(reservationId);

        if (reservation == null)
        {
            return null;
        }

        return _mapper.Map<ReservationDTO>(reservation);
    }
    public async Task<bool> DeleteReservationAsync(int reservationId)
    {
        var reservationExists = await _reservationRepository.GetReservationByIdAsync(reservationId);
        if (reservationExists == null)
        {
            return false;
        }

        await _reservationRepository.DeleteReservationAsync(reservationId);
        return true;
    }
    public decimal CalculateTotalPrice(Reservation reservation, Book book)
    {
        decimal dailyRate = reservation.BookType == BookType.NormalBook ? book.NormalPrice : book.AudioPrice;
        decimal totalPrice = dailyRate * reservation.DaysReserved;

        if (reservation.DaysReserved > 10)
        {
            totalPrice *= 0.80m; // 20% off
        }
        else if (reservation.DaysReserved > 3)
        {
            totalPrice *= 0.90m; // 10% off
        }

        // service fee €3
        totalPrice += 3;

        // quick pickup fee €5
        if (reservation.IsQuickPickup)
        {
            totalPrice += 5;
        }

        return totalPrice;
    }
}