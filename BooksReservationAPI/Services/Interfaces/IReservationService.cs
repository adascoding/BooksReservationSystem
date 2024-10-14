using BooksReservationAPI.DTOs;

namespace BooksReservationAPI.Services.Interfaces;

public interface IReservationService
{
    Task<IEnumerable<ReservationDTO>> GetAllReservationsAsync();
    Task<ReservationDTO> AddReservationAsync(CreateReservationDTO createReservationDTO);
    Task<ReservationDTO?> GetReservationByIdAsync(int reservationId);
    Task<bool> DeleteReservationAsync(int reservationId);
}
