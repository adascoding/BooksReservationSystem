using BooksReservationAPI.DTOs;
using BooksReservationAPI.Models;

namespace BooksReservationAPI.Services.Tests;

[TestClass()]
public class PriceCalculationTests
{
    private readonly ReservationService _reservationService;

    public PriceCalculationTests()
    { 
        _reservationService = new ReservationService(null, null, null);
    }

    [TestMethod()]
    public void CalculateTotalPrice_NormalBook_NoDiscount_NoQuickPickup_ReturnsCorrectTotal()
    {
        // Arrange
        var reservation = new Reservation
        {
            DaysReserved = 2,
            BookType = BookType.NormalBook,
            IsQuickPickup = false
        };

        var book = new Book
        {
            Id = 1,
            Name = "Test Normal Book",
            Year = 2024,
            ImageUrl = "http://example.com/normalbook.jpg",
            NormalPrice = 10.00m,
            HasNormalBook = true
        };

        // Act
        var totalPrice = _reservationService.CalculateTotalPrice(reservation, book);

        // Assert
        Assert.AreEqual(23.00m, totalPrice); // ( 10 * 2 ) + 3 service fee
    }

    [TestMethod()]
    public void CalculateTotalPrice_NormalBook_With10PercentDiscount_NoQuickPickup_ReturnsCorrectTotal()
    {
        // Arrange
        var reservation = new Reservation
        {
            DaysReserved = 5,
            BookType = BookType.NormalBook,
            IsQuickPickup = false
        };

        var book = new Book
        {
            Id = 2,
            Name = "Test Normal Book 2",
            Year = 2024,
            ImageUrl = "http://example.com/normalbook2.jpg",
            NormalPrice = 20.00m,
            HasNormalBook = true
        };

        // Act
        var totalPrice = _reservationService.CalculateTotalPrice(reservation, book);

        // Assert
        Assert.AreEqual(93.00m, totalPrice); // (20 * 5 * 0.90) + 3 service fee
    }

    [TestMethod()]
    public void CalculateTotalPrice_AudioBook_With20PercentDiscount_AndQuickPickup_ReturnsCorrectTotal()
    {
        // Arrange
        var reservation = new Reservation
        {
            DaysReserved = 12,
            BookType = BookType.AudioBook,
            IsQuickPickup = true
        };

        var book = new Book
        {
            Id = 3,
            Name = "Test Audio Book",
            Year = 2024,
            ImageUrl = "http://example.com/audiobook.jpg",
            AudioPrice = 25.00m,
            HasAudioBook = true
        };

        // Act
        var totalPrice = _reservationService.CalculateTotalPrice(reservation, book);

        // Assert
        Assert.AreEqual(248.00m, totalPrice); // ( 25 * 12 * 0.8) + 3 service fee + 5 quick pickup
    }

    [TestMethod()]
    public void CalculateTotalPrice_NormalBook_WithNoDiscount_AndQuickPickup_ReturnsCorrectTotal()
    {
        // Arrange
        var reservation = new Reservation
        {
            DaysReserved = 2,
            BookType = BookType.NormalBook,
            IsQuickPickup = true
        };

        var book = new Book
        {
            Id = 4,
            Name = "Test Normal Book 3",
            Year = 2024,
            ImageUrl = "http://example.com/normalbook3.jpg",
            NormalPrice = 10.00m,
            AudioPrice = 15.00m
        };

        // Act
        var totalPrice = _reservationService.CalculateTotalPrice(reservation, book);

        // Assert
        Assert.AreEqual(28.00m, totalPrice); // ( 10 * 2 ) + 3 service fee + 5 quick pickup
    }
}
