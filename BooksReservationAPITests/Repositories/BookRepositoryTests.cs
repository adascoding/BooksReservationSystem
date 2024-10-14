using BooksReservationAPI.Data;
using BooksReservationAPI.DTOs;
using BooksReservationAPI.Models;
using BooksReservationAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BooksReservationAPI.Tests.Repositories
{
    [TestClass]
    public class BookRepositoryTests
    {
        private DbContextOptions<ApplicationContext> _dbContextOptions;
        private ApplicationContext _context;
        private BookRepository _bookRepository;

        [TestInitialize]
        public void Setup()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "BookReservationTestDb")
                .Options;

            _context = new ApplicationContext(_dbContextOptions);
            _bookRepository = new BookRepository(_context);

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            var books = new List<Book>
            {
                new Book { Id = 1, Name = "Book One", ImageUrl="www.book.com/1.jpg", Year = 2020, HasNormalBook = true, HasAudioBook = false },
                new Book { Id = 2, Name = "Book Two", ImageUrl="www.book.com/2.jpg", Year = 2021, HasNormalBook = true, HasAudioBook = true },
                new Book { Id = 3, Name = "Book Three", ImageUrl="www.book.com/3.jpg",Year = 2022, HasNormalBook = false, HasAudioBook = true }
            };

            _context.Books.AddRange(books);
            _context.SaveChanges();
        }

        [TestMethod]
        public async Task GetAllBooksAsync_ShouldReturnAllBooks_WhenNoFilterIsApplied()
        {
            // Act
            var result = await _bookRepository.GetAllBooksAsync();

            // Assert
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public async Task GetAllBooksAsync_ShouldFilterBooksByName()
        {
            // Act
            var result = await _bookRepository.GetAllBooksAsync(name: "Book One");

            // Assert
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("Book One", result.First().Name);
        }

        [TestMethod]
        public async Task GetAllBooksAsync_ShouldFilterBooksByYear()
        {
            // Act
            var result = await _bookRepository.GetAllBooksAsync(year: 2021);

            // Assert
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(2021, result.First().Year);
        }

        [TestMethod]
        public async Task GetAllBooksAsync_ShouldFilterBooksByType_NormalBook()
        {
            // Act
            var result = await _bookRepository.GetAllBooksAsync(type: BookType.NormalBook);

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.All(b => b.HasNormalBook));
        }

        [TestMethod]
        public async Task GetAllBooksAsync_ShouldFilterBooksByType_AudioBook()
        {
            // Act
            var result = await _bookRepository.GetAllBooksAsync(type: BookType.AudioBook);

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.All(b => b.HasAudioBook));
        }

        [TestMethod]
        public async Task GetBookByIdAsync_ShouldReturnCorrectBook_WhenBookExists()
        {
            // Act
            var result = await _bookRepository.GetBookByIdAsync(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Book One", result.Name);
        }

        [TestMethod]
        public async Task GetBookByIdAsync_ShouldReturnNull_WhenBookDoesNotExist()
        {
            // Act
            var result = await _bookRepository.GetBookByIdAsync(99);

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
