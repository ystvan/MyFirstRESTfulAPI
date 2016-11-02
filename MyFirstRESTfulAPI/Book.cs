using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

namespace MyFirstRESTfulAPI
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public int BookId { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string ISBN { get; set; }

    }

    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        Book AddNewBook(Book item);
        bool DeleteABook(int id);
        bool UpdateABook(Book item);
    }

    public class BookRepository : IBookRepository
    {
        private List<Book> books = new List<Book>();
        private int counter = 1;

        public BookRepository()
        {
            AddNewBook(new Book() {Title = "Ungdomskort i alle zoner", ISBN = "061116-051216"});
            AddNewBook(new Book() { Title = "Rage Against the answering Machine", ISBN = "161205-161106" });
            AddNewBook(new Book() { Title = "Blue Bird Cafe", ISBN = "589302-986987" });
            AddNewBook(new Book() { Title = "Pap og Carton", ISBN = "859632-025145" });
        }

        //CRUD operations:

        /// <summary>
        /// Adding a new book object to the list
        /// </summary>
        /// <param name="newBook">Book item</param>
        /// <returns>A book item</returns>
        public Book AddNewBook(Book newBook)
        {
            //Check if adding an object at all
            if (newBook == null)
            {
                throw new ArgumentNullException(nameof(newBook));
            }

            //increment the ID by one
            newBook.BookId = counter++;

            //Add the item
            books.Add(newBook);
            return newBook;
            
        }

        
        /// <summary>
        /// Retrieving all books
        /// </summary>
        /// <returns>A list of books</returns>
        public List<Book> GetAllBooks()
        {
            return books;
        }

        /// <summary>
        /// Retrieve the book by its id
        /// </summary>
        /// <param name="bookId">BookID</param>
        /// <returns>Matching/Corresponding book</returns>
        public Book GetBookById(int bookId)
        {
            return books.Find(b => b.BookId == bookId);
        }


        /// <summary>
        /// Updating a book object
        /// </summary>
        /// <param name="updatedBook"></param>
        /// <returns></returns>
        public bool UpdateBook(Book updatedBook)
        {
            //Checking if updating an object at all
            if (updatedBook == null)
            {
                throw new ArgumentNullException(nameof(updatedBook));
            }
            //If exist find by its index
            int idx = books.FindIndex(b => b.BookId == updatedBook.BookId);

            //Check not to get negative index by deleting "too many"
            if (idx == -1)
            {
                return false;
            }

            //Removing old index and update with new book
            books.RemoveAt(idx);
            books.Add(updatedBook);
            return true;
            
        }


        /// <summary>
        /// Deleting a book by its Id
        /// </summary>
        /// <param name="bookId">BookID</param>
        /// <returns>True if the book exist</returns>
        public bool DeleteBook(int bookId)
        {
            //Find book object by its index
            int idx = books.FindIndex(b => b.BookId == bookId);

            //Check not to get negative index by deleting "too many"
            if (idx == -1)
            {
                return false;
            }

            //Remove all object with corresponding index from list
            books.RemoveAll(b => b.BookId == bookId);
            return true;
        }

       
    }
}