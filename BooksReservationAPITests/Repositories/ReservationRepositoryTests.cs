using BooksReservationAPI.Data;
using BooksReservationAPI.DTOs;
using BooksReservationAPI.Models;
using BooksReservationAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksReservationAPI.Tests.Repositories
{
    [TestClass]
    public class ReservationRepositoryTests
    {
        private DbContextOptions<ApplicationContext> _dbContextOptions;
        private ApplicationContext _context;
        private ReservationRepository _reservationRepository;

        [TestInitialize]
        public void Setup()
        {
            // Setting up the in-memory database for testing
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "ReservationTestDb")
                .Options;

            _context = new ApplicationContext(_dbContextOptions);
            _reservationRepository = new ReservationRepository(_context);

            // Seed the in-memory database
            SeedDatabase();
        }

        private void SeedDatabase()
        {
            var book = new Book { Id = 1, Name = "Book One", ImageUrl = "www.book.com/1.jpg", Year = 2020, HasNormalBook = true, HasAudioBook = false };
            _context.Books.Add(book);

            var reservations = new List<Reservation>
            {
                new Reservation { Id = 1, BookId = 1, BookType = BookType.AudioBook, CreatedAt = DateTime.UtcNow.AddDays(-2) },
                new Reservation { Id = 2, BookId = 1, BookType = BookType.NormalBook, CreatedAt = DateTime.UtcNow.AddDays(-1) }
            };

            _context.Reservations.AddRange(reservations);
            _context.SaveChanges();
        }

        [TestMethod]
        public async Task GetAllReservationsAsync_ShouldReturnAllReservations()
        {
            // Act
            var result = await _reservationRepository.GetAllReservationsAsync();

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.First().CreatedAt > result.Last().CreatedAt);  // Check the sorting by CreatedAt
        }

        [TestMethod]
        public async Task AddReservationAsync_ShouldAddNewReservation()
        {
            // Arrange
            var newReservation = new Reservation
            {
                Id = 3,
                BookId = 1,
                BookType = BookType.NormalBook,
                CreatedAt = DateTime.UtcNow
            };

            // Act
            await _reservationRepository.AddReservationAsync(newReservation);
            var result = await _context.Reservations.FindAsync(3);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Id);
        }

        [TestMethod]
        public async Task DeleteReservationAsync_ShouldDeleteReservation_WhenReservationExists()
        {
            // Act
            var result = await _reservationRepository.DeleteReservationAsync(1);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, _context.Reservations.Count()); 
        }

        [TestMethod]
        public async Task DeleteReservationAsync_ShouldReturnFalse_WhenReservationDoesNotExist()
        {
            // Act
            var result = await _reservationRepository.DeleteReservationAsync(99);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(2, _context.Reservations.Count());
        }

        [TestMethod]
        public async Task GetReservationByIdAsync_ShouldReturnReservation_WhenReservationExists()
        {
            // Act
            var result = await _reservationRepository.GetReservationByIdAsync(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }

        [TestMethod]
        public async Task GetReservationByIdAsync_ShouldReturnNull_WhenReservationDoesNotExist()
        {
            // Act
            var result = await _reservationRepository.GetReservationByIdAsync(99);

            // Assert
            Assert.IsNull(result);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
