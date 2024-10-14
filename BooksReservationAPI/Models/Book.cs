using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksReservationAPI.Models;

public class Book
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    [Range(1900, 2024)]
    public int Year { get; set; }

    [Url]
    public required string ImageUrl { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal NormalPrice { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal AudioPrice { get; set; }

    public bool HasAudioBook { get; set; } = false;

    public bool HasNormalBook { get; set; } = false;

    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
