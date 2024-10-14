using System.ComponentModel.DataAnnotations;

namespace BooksReservationAPI.DTOs;

public class CreateReservationDTO
{
    [Required(ErrorMessage = "Book Type is required.")]
    public BookType BookType { get; set; }

    [Required(ErrorMessage = "Days Reserved is required.")]
    [Range(1, 365, ErrorMessage = "Days Reserved must be between 1 and 365.")]
    public int DaysReserved { get; set; }

    [Required]
    public bool IsQuickPickup { get; set; }

    [Required(ErrorMessage = "Book ID is required.")]
    public int BookId { get; set; }
}
