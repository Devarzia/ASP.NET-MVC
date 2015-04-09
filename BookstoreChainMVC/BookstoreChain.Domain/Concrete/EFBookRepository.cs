using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreChain.Domain.Entities;
using BookstoreChain.Domain.Abstract;

namespace BookstoreChain.Domain.Concrete
{
    public class EFBookRepository : IBookRepository
    {
        // Creating a new instance of the Book Table in the database
        private EFDbContext context = new EFDbContext();

        // Retriving all of the Books from the book table
        public IQueryable<Book> Books
        {
            // Setting the get attribute to return all books from the database
            get
            {
                return context.Books;
            }
        }

        // Method to save the book to the database
        public void SaveBook(Book book)
        {
            // If statement to save book to the database
            if (book.BookID == 0) 
            {
                context.Books.Add(book);
            }

            else
            {
                // Find an existing book by ID
                Book bookEntry = context.Books.Find(book.BookID);

                // If the bookEntry is null, link bookEntry Information to book information
                if (bookEntry != null)
                {
                    bookEntry.Title = book.Title;
                    bookEntry.Genre = book.Genre;
                    bookEntry.AuthorName = book.AuthorName;
                }
            }

            // Saving the changes to the database
            context.SaveChanges();
        }

        // Deleting a book from the database
        public Book DeleteBook(int bookID)
        {
            // Finding the bookEntry in the database to be deleted
            Book bookEntry = context.Books.Find(bookID);

            // Deleting the bookEntry if the bookID is found and saving changes to the database
            if (bookEntry != null)
            {
                context.Books.Remove(bookEntry);
                context.SaveChanges();
            }

            // Return the bookEntry
            return bookEntry;
        }
    }
}