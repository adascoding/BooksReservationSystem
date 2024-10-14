using BooksReservationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksReservationAPI.Data;

public class DataSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(
            new Book
            {
                Id = 1,
                Name = "Viskas primena tave",
                Year = 2024,
                ImageUrl = "https://thumb.knygos-static.lt/zTRxL3bbYFiQLZrj-UdzZwXpDX0=/fit-in/0x800/images/books/14536702/1707207686_0008361_viskas-primena-tave.jpg",
                NormalPrice = 2.0m,
                AudioPrice = 3.0m,
                HasNormalBook = true,
                HasAudioBook = true
            },
            new Book
            {
                Id = 2,
                Name = "Daydream",
                Year = 2024,
                ImageUrl = "https://thumb.knygos-static.lt/LdibMGnFBNZgeFsKxfJ1yVT1LgY=/fit-in/0x800/images/books/14729587/71ojnm5bsol--sl1500-.jpg",
                NormalPrice = 2.0m,
                AudioPrice = 3.0m,
                HasNormalBook = true,
                HasAudioBook = true
            },
            new Book
            {
                Id = 3,
                Name = "Scarred",
                Year = 2022,
                ImageUrl = "https://thumb.knygos-static.lt/d47A7iztTWQY-XYP-fPhUeXV21Q=/fit-in/0x800/https://libri-media.knygos-static.lt/a40f42ad-ce9d-42e1-82ea-d25abb50a72d/2",
                NormalPrice = 2.0m,
                AudioPrice = 3.0m,
                HasNormalBook = true,
                HasAudioBook = true
            },
            new Book
            {
                Id = 4,
                Name = "Anapus uždarų durų",
                Year = 2021,
                ImageUrl = "https://thumb.knygos-static.lt/D4RdmnGPen73eToWf1h28aoWEFA=/fit-in/0x800/images/books/1153381/1496064596_18700235_1349253291829100_4083575183174590972_n.jpg",
                NormalPrice = 2.0m,
                AudioPrice = 3.0m,
                HasNormalBook = true,
                HasAudioBook = true
            },
            new Book
            {
                Id = 5,
                Name = "Laiko kaina",
                Year = 2020,
                ImageUrl = "https://thumb.knygos-static.lt/gfdkGk42U5A5oXqSM80vMcIHzUg=/fit-in/0x800/images/books/1499284/1588837533_laiko-kaina-1.jpg",
                NormalPrice = 2.0m,
                AudioPrice = 3.0m,
                HasNormalBook = true,
                HasAudioBook = true
            },
            new Book
            {
                Id = 6,
                Name = "Supernova",
                Year = 2023,
                ImageUrl = "https://thumb.knygos-static.lt/Zdl8oh5yoWWNJ3sijD56JpF1Y8A=/fit-in/0x800/images/books/2704754/1671194420_Picture3.png",
                NormalPrice = 2.0m,
                AudioPrice = 3.0m,
                HasNormalBook = true,
                HasAudioBook = true
            },
            new Book
            {
                Id = 7,
                Name = "Pažadinkite savyje milžiną",
                Year = 2000,
                ImageUrl = "https://thumb.knygos-static.lt/J85ARtKE7xnxmJx17JVwzZPeVsI=/fit-in/0x800/images/books/13182/1532952392_pazadinkite_savyje_milzina.jpg",
                NormalPrice = 2.0m,
                AudioPrice = 0.0m,
                HasNormalBook = true,
                HasAudioBook = false
            },
            new Book
            {
                Id = 8,
                Name = "Įtakos galia: kaip pasiekti savo tikslus",
                Year = 2016,
                ImageUrl = "https://thumb.knygos-static.lt/3U4cl0qCRcGe9vfI6QSkzIWIdzQ=/fit-in/0x800/images/books/2660070/1643880318_000000000001112619-61f7e8a55239c-asset-knyguklubas-itakos-galia.jpg",
                NormalPrice = 0.0m,
                AudioPrice = 3.0m,
                HasNormalBook = false,
                HasAudioBook = true
            },
            new Book
            {
                Id = 9,
                Name = "Viešbutis Nr. 21",
                Year = 1998,
                ImageUrl = "https://thumb.knygos-static.lt/mxjvvG0LSZTxbArxRQ3HoU0GasE=/fit-in/0x800/images/books/14845446/book-4221727876851.png",
                NormalPrice = 2.0m,
                AudioPrice = 0.0m,
                HasNormalBook = true,
                HasAudioBook = false
            },
            new Book
            {
                Id = 10,
                Name = "Šešetas varnų. Pirma knyga",
                Year = 2000,
                ImageUrl = "https://thumb.knygos-static.lt/axoLYduhKIZ_GhK5cUNVTvzUeIw=/fit-in/0x800/images/books/1510842/1726483307_Sesetas-varnu.jpg",
                NormalPrice = 0.0m,
                AudioPrice = 3.0m,
                HasNormalBook = false,
                HasAudioBook = true
            }
        );
    }
}