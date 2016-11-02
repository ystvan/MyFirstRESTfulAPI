using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyFirstRESTfulAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BookService.svc or BookService.svc.cs at the Solution Explorer and start debugging.
    public class BookService : IBookService
    {
        static IBookRepository repository = new BookRepository();

        /// <summary>
        /// Adding a new book object to our repository
        /// </summary>
        /// <param name="book">New book object</param>
        /// <param name="id">New book object's ID</param>
        /// <returns>A string rpresenation of book ID</returns>
        public string AddBook(Book book, string id)
        {
            Book newBook = repository.AddNewBook(book);
            return "id=" + newBook.BookId;
        }

        /// <summary>
        /// Deleting a book object from our repository
        /// </summary>
        /// <param name="id">Book object's ID</param>
        /// <returns>A string representation of deleted book ID</returns>
        public string DeleteBook(string id)
        {
            bool deleted = repository.DeleteBook(int.Parse(id));

            if (deleted)
            {
                return "Book with id = " + id + " has been deleted successfully!";
            }
            else
            {
                return "Unable to delete book with id = " + id;
            }
        }

        /// <summary>
        /// Retrieving a book with corresponding ID
        /// </summary>
        /// <param name="id">Retriveable book object's ID</param>
        /// <returns>A corrsponding book object</returns>
        public Book GetBookById(string id)
        {
            return repository.GetBookById(int.Parse(id));
        }

        /// <summary>
        /// Retriving our book repository as a list
        /// </summary>
        /// <returns>A list of book</returns>
        public List<Book> GetBookList()
        {
            return repository.GetAllBooks();
        }

        /// <summary>
        /// Updating a selected book
        /// </summary>
        /// <param name="book">A book object to be updated</param>
        /// <param name="id">Corresponding ID</param>
        /// <returns>A string representation of updated book</returns>
        public string UpdateBook(Book book, string id)
        {
            bool updated = repository.UpdateBook(book);

            if (updated)
            {
                return "Book with id = " + id + " has been updated successfully";
            }
            else
            {
                return "Unable to update book with id = " + id;
            }
        }
    }
}
