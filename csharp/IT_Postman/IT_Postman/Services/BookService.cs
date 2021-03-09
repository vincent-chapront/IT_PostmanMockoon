using IT_Postman.Models;
using IT_Postman.Store;
using System;
using System.Linq;

namespace IT_Postman.Services
{
    public class BookService
    {
        private readonly DataStore dataStore;

        public BookService(DataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        public Book[] GetBooks()
        {
            return dataStore.Books.ToArray();
        }

        internal Book Create(string title, string author, string publisher)
        {
            var newBook =
                new Book
                {
                    Id = Guid.NewGuid(),
                    Author = author,
                    Publisher = publisher,
                    Title = title
                };

            dataStore.Books.Add(newBook);
            return newBook;
        }

        internal Book GetBook(Guid BookId)
        {
            return dataStore.Books.FirstOrDefault(a => a.Id == BookId);
        }
    }
}