using AutoMapper;
using BooksReservationAPI.DTOs;
using BooksReservationAPI.Models;

namespace BooksReservationAPI.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookDTO>();

        CreateMap<BookDTO, Book>();

        CreateMap<Reservation, ReservationDTO>()
            .ForMember(dest => dest.Book, opt => opt.MapFrom(src => new BookDTO
            {
                Id = src.Book.Id,
                Name = src.Book.Name,
                Year = src.Book.Year,
                ImageUrl = src.Book.ImageUrl
            }));

        CreateMap<ReservationDTO, Reservation>();
    }
}