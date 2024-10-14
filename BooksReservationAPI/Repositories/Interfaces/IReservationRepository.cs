using BooksReservationAPI.Models;

namespace BooksReservationAPI.Repositories.Interfaces;

public interface IReservationRepository
{
    Task<IEnumerable<Reservation>> GetAllReservationsAsync();
    Task AddReservationAsync(Reservation reservation);
    Task<Reservation?> GetReservationByIdAsync(int reservationId);
    Task<bool> DeleteReservationAsync(int reservationId);
}
