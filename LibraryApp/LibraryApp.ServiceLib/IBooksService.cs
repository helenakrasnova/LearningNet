using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.ServiceLib
{
    //CRUD - create read update delete
    public interface IBooksService
    {
        bool AddBook(Book book);
        bool DeleteBook(Guid id);
        IEnumerable<Book> SearchBook(string title, Genres genre, DateTime publishDate);
        bool Update(Book book);
        IEnumerable<Book> GetAll();

    }
}
