using BooksReservationAPI.Data;
using BooksReservationAPI.Models;
using BooksReservationAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace BooksReservationAPI.Repositories;

public class ReservationRepository(ApplicationContext context) : IReservationRepository
{
    private readonly ApplicationContext _context = context;

    public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
    {
        return await _context.Reservations
                             .Include(r => r.Book)
                             .OrderByDescending(r => r.CreatedAt)
                             .ToListAsync();
    }
    public async Task AddReservationAsync(Reservation reservation)
    {
        await _context.Reservations.AddAsync(reservation);
        await _context.SaveChangesAsync();
    }
    public async Task<bool> DeleteReservationAsync(int reservationId)
    {
        var reservation = await _context.Reservations.FindAsync(reservationId);
        if (reservation == null)
        {
            return false;
        }

        _context.Reservations.Remove(reservation);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Reservation?> GetReservationByIdAsync(int reservationId)
    {
        return await _context.Reservations.FindAsync(reservationId);
    }

}
