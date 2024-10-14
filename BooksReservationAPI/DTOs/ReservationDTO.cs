namespace BooksReservationAPI.DTOs;

public class ReservationDTO
{
    public int Id { get; set; }
    public BookType BookType { get; set; }
    public int DaysReserved { get; set; }
    public bool IsQuickPickup { get; set; } = false;
    public decimal TotalPrice { get; set; }
    public BookDTO Book { get; set; }
}
