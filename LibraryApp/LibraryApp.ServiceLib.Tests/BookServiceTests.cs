using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApp.ServiceLib.Tests
{
    [TestClass]
    public class BookServiceTests
    {
        [TestMethod]
        public void AddBook_OneUniqueBook_SucessfullyAdded()
        {
            //arrange
            BookService bookService = new BookService();
            Book testBook = new Book
            {
                Author = "Turtle",
                Genre = Genres.Romance,
                Id = Guid.NewGuid(),
                PublishDate = new DateTime(1996, 5, 16),
                Title = "ClockWork"
            };
            //act
            bool actualResult = bookService.AddBook(testBook);
            //assert
            Assert.AreEqual(true, actualResult);
        }
        [TestMethod]
        public void AddBook_DuplicateBook_UnsucessfullyAdded()
        {
            //arrange
            BookService bookService = new BookService();
            Book testBook = new Book
            {
                Author = "Turtle",
                Genre = Genres.Romance,
                Id = Guid.NewGuid(),
                PublishDate = new DateTime(1996, 5, 16),
                Title = "ClockWork"
            };
            //act
            bool firstActualResult = bookService.AddBook(testBook);
            bool secondActualResult = bookService.AddBook(testBook);
            //assert
            Assert.AreEqual(false, secondActualResult);
        }
        [TestMethod]
        public void DeleteBook_OneExistingBook_SucessfullyDeleted()
        {
            //arrange
            BookService bookService = new BookService();
            Book testBook = new Book
            {
                Author = "Turtle",
                Genre = Genres.Romance,
                Id = Guid.NewGuid(),
                PublishDate = new DateTime(1996, 5, 16),
                Title = "ClockWork"
            };
            bookService.AddBook(testBook);
            //act
            bool deletedResult = bookService.DeleteBook(testBook.Id);
            //assert
            Assert.AreEqual(true, deletedResult);
        }
        [TestMethod]
        public void DeleteBook_OneExistingBook_UnsucessfullyDeleted()
        {
            //arrange
            Guid noExistingId = Guid.NewGuid();
            BookService bookService = new BookService();
            Book testBook = new Book
            {
                Author = "Turtle",
                Genre = Genres.Romance,
                Id = Guid.NewGuid(),
                PublishDate = new DateTime(1996, 5, 16),
                Title = "ClockWork"
            };
            bookService.AddBook(testBook);
            //act
            bool deletedResult = bookService.DeleteBook(noExistingId);
            //assert
            Assert.AreEqual(false, deletedResult);
        }
        [TestMethod]
        public void SearchBook_ValidSearchCriteria_SucessfullySearched()
        {
            //arrange
            BookService bookService = new BookService();
            Book testBook1 = new Book
            {
                Author = "Turtle",
                Genre = Genres.Romance,
                Id = Guid.NewGuid(),
                PublishDate = new DateTime(1996, 5, 16),
                Title = "ClockWork"
            };
            Book testBook2 = new Book
            {
                Author = "Turtle",
                Genre = Genres.Computer,
                Id = Guid.NewGuid(),
                PublishDate = new DateTime(1996, 5, 16),
                Title = "TestTitle1"
            };
            Book testBook3 = new Book
            {
                Author = "Turtle",
                Genre = Genres.Fantasy,
                Id = Guid.NewGuid(),
                PublishDate = new DateTime(1996, 5, 16),
                Title = "TestTitle2"
            };
            Book testBook4 = new Book
            {
                Author = "Turtle",
                Genre = Genres.Romance,
                Id = Guid.NewGuid(),
                PublishDate = new DateTime(1996, 5, 16),
                Title = "TestTitle3"
            };
            Book testBook5 = new Book
            {
                Author = "Turtle",
                Genre = Genres.Horror,
                Id = Guid.NewGuid(),
                PublishDate = new DateTime(1996, 5, 16),
                Title = "TestTitle2"
            };
            bookService.AddBook(testBook1);
            bookService.AddBook(testBook2);
            bookService.AddBook(testBook3);
            bookService.AddBook(testBook4);
            bookService.AddBook(testBook5);
            //act
            List<Book> searchedResult = bookService.SearchBook("TestTitle2",Genres.Computer).ToList();
            //assert
            Assert.AreEqual(3, searchedResult.Count);
            Assert.AreEqual(testBook2.Id,searchedResult[0].Id);
            Assert.AreEqual(testBook3.Id, searchedResult[1].Id);
            Assert.AreEqual(testBook5.Id, searchedResult[2].Id);
        }
        [TestMethod]
        public void SearchBook_ValidSearchCriteria_EmptySearched()
        {
            //arrange
            BookService bookService = new BookService();
            Book testBook1 = new Book
            {
                Author = "Turtle",
                Genre = Genres.Romance,
                Id = Guid.NewGuid(),
                PublishDate = new DateTime(1996, 5, 16),
                Title = "ClockWork"
            };
            Book testBook2 = new Book
            {
                Author = "Turtle",
                Genre = Genres.Computer,
                Id = Guid.NewGuid(),
                PublishDate = new DateTime(1996, 5, 16),
                Title = "TestTitle1"
            };
            Book testBook3 = new Book
            {
                Author = "Turtle",
                Genre = Genres.Fantasy,
                Id = Guid.NewGuid(),
                PublishDate = new DateTime(1996, 5, 16),
                Title = "TestTitle2"
            };
            Book testBook4 = new Book
            {
                Author = "Turtle",
                Genre = Genres.Romance,
                Id = Guid.NewGuid(),
                PublishDate = new DateTime(1996, 5, 16),
                Title = "TestTitle3"
            };
            Book testBook5 = new Book
            {
                Author = "Turtle",
                Genre = Genres.Horror,
                Id = Guid.NewGuid(),
                PublishDate = new DateTime(1996, 5, 16),
                Title = "TestTitle2"
            };
            bookService.AddBook(testBook1);
            bookService.AddBook(testBook2);
            bookService.AddBook(testBook3);
            bookService.AddBook(testBook4);
            bookService.AddBook(testBook5);
            //act
            List<Book> searchedResult = bookService.SearchBook("TestTitle4", Genres.Musical).ToList();
            //assert
            Assert.AreEqual(0, searchedResult.Count);
        }
        [TestMethod]
        public void Get_OneExistingBook_SucessfullyRetrieved()
        {
            //arrange
            BookService bookService = new BookService();
            Book testBook = new Book
            {
                Author = "Turtle",
                Genre = Genres.Romance,
                Id = Guid.NewGuid(),
                PublishDate = new DateTime(1996, 5, 16),
                Title = "ClockWork"
            };
            bookService.AddBook(testBook);
            //act
            var gettedResult = bookService.Get(testBook.Id);
            //assert
            Assert.AreEqual(testBook, gettedResult);
        }
        public void Get_OneExistingBook_UnsucessfullyRetrieved()
        {
            //arrange
            BookService bookService = new BookService();
            Guid noExistingId = Guid.NewGuid();
            Book testBook = new Book
            {
                Author = "Turtle",
                Genre = Genres.Romance,
                Id = Guid.NewGuid(),
                PublishDate = new DateTime(1996, 5, 16),
                Title = "ClockWork"
            };
            bookService.AddBook(testBook);
            //act
            var gettedResult = bookService.Get(noExistingId);
            //assert
            Assert.AreEqual(testBook, gettedResult);
        }
        [TestMethod]
        public void UpdatedBook_OneExistingBook_SucessfullyUpdated()
        {
            //arrange
            BookService bookService = new BookService();
            Book testBook = new Book
            {
                Author = "Turtle",
                Genre = Genres.Romance,
                Id = Guid.NewGuid(),
                PublishDate = new DateTime(1996, 5, 16),
                Title = "ClockWork"
            };
            bookService.AddBook(testBook);
            testBook.Author = "Panda";
            testBook.Genre = Genres.Horror;
            testBook.PublishDate = new DateTime(2000,02,10);
            testBook.Title = "Shining";
            //act
            bool updatedResult = bookService.Update(testBook);
            Book updatedBook = bookService.Get(testBook.Id);
            //assert
            Assert.AreEqual(true, updatedResult);
            Assert.AreEqual(testBook.Author, updatedBook.Author);
            Assert.AreEqual(testBook.Genre, updatedBook.Genre);
            Assert.AreEqual(testBook.PublishDate, updatedBook.PublishDate);
            Assert.AreEqual(testBook.Title, updatedBook.Title);
        }
        [TestMethod]
        public void UpdatedBook_OneExistingBook_UnsucessfullyUpdated()
        {
            //arrange
            BookService bookService = new BookService();
            Book testBook = new Book
            {
                Author = "Turtle",
                Genre = Genres.Romance,
                Id = Guid.NewGuid(),
                PublishDate = new DateTime(1996, 5, 16),
                Title = "ClockWork"
            };
            bookService.AddBook(testBook);
            Book testBook1 = new Book
            {
                Author = "Panda",
                Genre = Genres.Horror,
                Id = Guid.NewGuid(),
                PublishDate = new DateTime(1993, 5, 31),
                Title = "Shining"
            };
            //act
            bool updatedResult = bookService.Update(testBook1);
            //assert
            Assert.AreEqual(false, updatedResult);
        }
    }
}