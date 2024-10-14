using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BooksReservationAPI.DTOs;

namespace BooksReservationAPI.Models;

public class Reservation
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required BookType BookType { get; set; }

    [Required]
    [Range(1, 365)]
    public int DaysReserved { get; set; }

    [Required]
    public bool IsQuickPickup { get; set; } = false;

    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalPrice { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Required]
    public int BookId { get; set; }

    [ForeignKey(nameof(BookId))]
    public Book Book { get; set; }
}
