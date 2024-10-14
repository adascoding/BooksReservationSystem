namespace BooksReservationAPI.DTOs;

public class BookDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public string ImageUrl { get; set; }
    public bool HasAudioBook { get; set; }
    public bool HasNormalBook { get; set; }
}