using System;

namespace LibraryApp.ServiceLib
{
    public class Book
    {
        public string Title { get; set; }
        public Genres Genre { get; set; }
        public Guid Id { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
