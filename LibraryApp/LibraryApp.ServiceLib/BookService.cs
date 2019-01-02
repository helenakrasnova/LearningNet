using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.ServiceLib
{
    public class BookService : IBooksService
    {
        private readonly List<Book> _books;
        public BookService ()
        {
            _books = new List<Book>();
        }
        public bool AddBook(Book book)
        {
            foreach (var currentBook in _books)
            {
                if (currentBook.Id == book.Id)
                {
                    return false;
                }
            }
            _books.Add(book);
            return true;
        }

        public bool DeleteBook(Guid id)
        {
            Book searchedBook=null;
            foreach (Book currentBook in _books)
            {
                if (currentBook.Id == id)
                {
                    searchedBook = currentBook;
                    break;
                }
                else
                {
                    return false;
                }
            }
            _books.Remove(searchedBook);
            return true;
        }

        public IEnumerable<Book> Get()
        {
            return _books;
        }
        public Book Get(Guid id)
        {
            foreach (Book currentBook in _books)
            {
                if (currentBook.Id == id)
                {
                    return currentBook;
                }
            }
            return null;
        }

        public IEnumerable<Book> SearchBook(string title, Genres genre)
        {
            List<Book> findedBooks = new List<Book>();
            foreach (Book currentBook in _books)
            {
                if (currentBook.Title == title || currentBook.Genre == genre)
                {
                    findedBooks.Add(currentBook);
                }
            }
            return findedBooks;
        }

        public bool Update(Book updatedBook)
        {
            foreach (Book currentBook in _books)
            {
                if (currentBook.Id == updatedBook.Id)
                {
                    currentBook.Author = updatedBook.Author;
                    currentBook.Genre = updatedBook.Genre;
                    currentBook.PublishDate = updatedBook.PublishDate;
                    currentBook.Title = updatedBook.Title;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
